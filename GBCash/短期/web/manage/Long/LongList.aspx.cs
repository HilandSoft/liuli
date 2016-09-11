namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;
	using YingNet.Common.Utils;

    public class LongList : CommonBasePage
    {
        protected Button Button1;
        protected CheckBox CheckBox1;
        protected DataGridTable DataGridTable1;
        protected DropDownList DropDownList1;
        protected Label Label1;
        protected TextBox txCondition;
        protected TextBox txKey;
        protected TextBox txtParamstr;

        private void Button1_Click(object sender, EventArgs e)
        {
            this.txCondition.Text = "";
            string str = "";
            string text = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            switch (this.DropDownList1.SelectedValue)
            {
                case "0":
                    str = " 1=1";
                    break;

                case "1":
                    if (!this.txKey.Text.Equals(""))
                    {
                        str = " sid=" + this.txKey.Text + " ";
                        break;
                    }
                    return;

                case "2":
                    if (!this.txKey.Text.Equals(""))
                    {
                        str = " Fname like '%" + this.txKey.Text + "%' ";
                        break;
                    }
                    return;

                case "3":
                    if (!this.txKey.Text.Equals(""))
                    {
                        str = " Sname like '%" + this.txKey.Text + "%' ";
                        break;
                    }
                    return;

                case "4":
                    if (!this.txKey.Text.Equals(""))
                    {
                        text = this.txKey.Text;
                        str3 = text.Substring(0, 2);
                        str4 = text.Substring(3, 2);
                        str5 = text.Substring(6, 4);
                        str = " day(Regtime) =" + str3 + " and month(Regtime)=" + str4 + " and year(Regtime)=" + str5 + " ";
                        break;
                    }
                    return;

                case "5":
                    if (!this.txKey.Text.Equals(""))
                    {
                        text = this.txKey.Text;
                        str3 = text.Substring(0, 2);
                        str4 = text.Substring(3, 2);
                        str5 = text.Substring(6, 4);
                        str = " substring(DBirth,1,2)='" + str3 + "' and  substring(DBirth,4,2)='" + str4 + "' and  substring(DBirth,7,4)='" + str5 + "'";
                        break;
                    }
                    return;

                case "6":
                    str = " Status=1 ";
                    break;

                case "7":
                    str = " Status=2 ";
                    break;

                case "98":
                    str = " Status=98 ";
                    break;

                case "99":
                    str = " Status=99 ";
                    break;

                case "100":
                    str = " Status=0 ";
                    break;

                case "101":
                    str = " Status=101 ";
                    break;
				case "15":
					str= " Status=15 ";//Pre-Approved
					break;
				case "18":
					str= " E.EName like '%"+ this.txKey.Text+ "%'";
					break;
            }

			switch(this.DropDownList1.SelectedValue)
			{
				case "18":
					this.ViewState["SearchJoinEmployment"]= "true";
					break;
				default:
					this.ViewState["SearchJoinEmployment"]= string.Empty;
					break;
			}

            this.txCondition.Text = str;
            this.DataGridTable1.DataBind();
        }

        private void DataGridTable1_DataBinding(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string commandText = "";
            if (this.txCondition.Text != "")
            {
				if(this.ViewState["SearchJoinEmployment"]==null||this.ViewState["SearchJoinEmployment"].ToString()==string.Empty)
				{
					if(this.DropDownList1.SelectedValue!="98")
					{
						commandText="select * from LPerson where Status<>-1 and Status<>98 and "+this.txCondition.Text+" order by Sid desc";
					}
					else
					{
						commandText="select * from LPerson where Status=98 and "+this.txCondition.Text+" order by Sid desc";
					}
				}
				else
				{
					if(this.DropDownList1.SelectedValue!="98")
					{
						commandText="select P.* from LPerson P join LEmployment E on P.sid=E.LoanSid where P.Status<>-1 and P.Status<>98 and "+this.txCondition.Text+" order by P.Sid desc";
					}
					else
					{
						commandText="select * from LPerson where Status=98 and "+this.txCondition.Text+" order by Sid desc";
					}
				}
                /*
				if (this.DropDownList1.SelectedValue != "98")
                {
                    commandText = "select * from LPerson where Status<>-1 and Status<>98 and " + this.txCondition.Text + " order by Sid desc";
                }
                else
                {
                    commandText = "select * from LPerson where Status=98 and " + this.txCondition.Text + " order by Sid desc";
                }
				*/
            }
            else
            {
                commandText = "select * from LPerson where Status<>-1 and Status<>98 order by Sid desc";
            }
            dt = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
            CommonBasePage.SetPage(this.DataGridTable1, dt);
            base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
            this.txtParamstr.Text = base.PackPart(base.ParamValue);
        }

        private void DataGridTable1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            DateTime time2;
            if (e.Item.ItemIndex <= -1)
            {
                return;
            }
            string text = e.Item.Cells[4].Text;
            string str2 = e.Item.Cells[12].Text;
            string str3 = e.Item.Cells[11].Text;
            string str4 = "";
            try
            {
                DateTime time = Convert.ToDateTime(str3);
                TimeSpan span = (TimeSpan) (SafeDateTime.LocalNow - time);
                if (span.Days >= 15)
                {
                    string commandText = "";
                    commandText = "update LPerson set Status=101 where sid=" + text + " and Status=0";
                    int num = SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText);
                }
            }
            catch (Exception exception)
            {
                this.Label1.Text = exception.Message;
            }
            switch (str2)
            {
                case "-1":
                    str4 = "Uncompleted";
                    goto Label_016F;

                case "0":
                    str4 = "New";
                    goto Label_016F;

                case "1":
                    str4 = "Approved";
                    goto Label_016F;

                case "2":
                    str4 = "Completed";
                    goto Label_016F;

                case "98":
                    str4 = "Deleted";
                    goto Label_016F;

                case "99":
                    str4 = "Rejected";
                    break;

                case "101":
                    str4 = "Expired";
                    break;
				case "15":
					str4="Pre-Approved";
					break;
				case "24":
            		str4 = "Collection";
            		break;
            }
        Label_016F:
            time2 = Convert.ToDateTime(str3);
            e.Item.Cells[11].Text = time2.ToString("dd/MM/yyyy hh:mm:ss");
            e.Item.Cells[12].Text = str4;
            e.Item.Cells[18].Text = "<a href='../../Long/CustomInfo.aspx?sid=" + Cipher.DesEncrypt(text, "12345678") + "' target=_blank>Agreement</a>";
        	
			//处理用户的Note和 FollowUpHistory
			try
			{
				DataRowView rowMember= (DataRowView)e.Item.DataItem;
				string noteDisplay= string.Empty;
				string followUpDisplay= string.Empty;
				if(rowMember.Row["Other1"]==null||rowMember.Row["Other1"] is DBNull||rowMember.Row["Other1"].ToString()==string.Empty)
				{
					noteDisplay= "Empty";
					e.Item.Cells[15].Text= string.Format("<a href='LMemberLoadNotes.aspx?id={0}'>{1}</a>",text,noteDisplay);
				}
				else
				{
					noteDisplay= "Attention";
					e.Item.Cells[15].Text= string.Format("<a dealed='Attention' href='LMemberLoadNotes.aspx?id={0}'>{1}</a>",text,noteDisplay);
				}

				if(rowMember.Row["Other2"]==null||rowMember.Row["Other2"] is DBNull||rowMember.Row["Other2"].ToString()==string.Empty)
				{
					followUpDisplay= "Empty";
					e.Item.Cells[16].Text= string.Format("<a href='LMemberLoadFollowUpHistory.aspx?id={0}'>{1}</a>",text,followUpDisplay);
				}
				else
				{
					followUpDisplay= "Attention";
					e.Item.Cells[16].Text= string.Format("<a dealed='Attention' href='LMemberLoadFollowUpHistory.aspx?id={0}'>{1}</a>",text,followUpDisplay);
				}
			}
			catch
			{}
        	//--结束
        }

        private void DataGridTable1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.DataGridTable1.CurrentPageIndex = e.NewPageIndex;
            this.DataGridTable1.DataBind();
        }

        private void InitializeComponent()
        {
            this.Button1.Click += new EventHandler(this.Button1_Click);
            this.DataGridTable1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridTable1_PageIndexChanged);
            this.DataGridTable1.DataBinding += new EventHandler(this.DataGridTable1_DataBinding);
            this.DataGridTable1.ItemDataBound += new DataGridItemEventHandler(this.DataGridTable1_ItemDataBound);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.txtParamstr.Text = base.PackPart(base.ParamValue);
                string str = base.GetValue("pageno");
                if (str != null)
                {
                    this.DataGridTable1.CurrentPageIndex = Convert.ToInt32(str) - 1;
                }
                this.DataGridTable1.DataBind();
            }
            else
            {
                base.ParamValue = base.UnPackPart(this.txtParamstr.Text);
            }
        }
    }
}

