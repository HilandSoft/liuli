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
            string str6;
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
                    if (this.txKey.Text.Equals(""))
                    {
                        return;
                    }
                    str = " sid=" + this.txKey.Text + " ";
                    break;

                case "2":
                    if (this.txKey.Text.Equals(""))
                    {
                        return;
                    }
                    str = " Fname like '%" + this.txKey.Text + "%' ";
                    break;

                case "3":
                    if (this.txKey.Text.Equals(""))
                    {
                        return;
                    }
                    str = " Sname like '%" + this.txKey.Text + "%' ";
                    break;

                case "4":
                    if (this.txKey.Text.Equals(""))
                    {
                        return;
                    }
                    text = this.txKey.Text;
                    str3 = text.Substring(0, 2);
                    str4 = text.Substring(3, 2);
                    str5 = text.Substring(6, 4);
                    str = " day(Regtime) =" + str3 + " and month(Regtime)=" + str4 + " and year(Regtime)=" + str5 + " ";
                    break;

                case "5":
                    if (this.txKey.Text.Equals(""))
                    {
                        return;
                    }
                    text = this.txKey.Text;
                    str3 = text.Substring(0, 2);
                    str4 = text.Substring(3, 2);
                    str5 = text.Substring(6, 4);
                    str = " substring(DBirth,1,2)='" + str3 + "' and  substring(DBirth,4,2)='" + str4 + "' and  substring(DBirth,7,4)='" + str5 + "'";
                    break;

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
                    str = " Status=15 ";
                    break;

                case "18":
                    str = " E.EName like '%" + this.txKey.Text + "%'";
                    break;
            }
            if (((str6 = this.DropDownList1.SelectedValue) != null) && (string.IsInterned(str6) == "18"))
            {
                this.ViewState["SearchJoinEmployment"] = "true";
            }
            else
            {
                this.ViewState["SearchJoinEmployment"] = string.Empty;
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
                if ((this.ViewState["SearchJoinEmployment"] == null) || (this.ViewState["SearchJoinEmployment"].ToString() == string.Empty))
                {
                    if (this.DropDownList1.SelectedValue != "98")
                    {
                        commandText = "select * from LPerson where Status<>-1 and Status<>98 and " + this.txCondition.Text + " order by Sid desc";
                    }
                    else
                    {
                        commandText = "select * from LPerson where Status=98 and " + this.txCondition.Text + " order by Sid desc";
                    }
                }
                else if (this.DropDownList1.SelectedValue != "98")
                {
                    commandText = "select P.* from LPerson P join LEmployment E on P.sid=E.LoanSid where P.Status<>-1 and P.Status<>98 and " + this.txCondition.Text + " order by P.Sid desc";
                }
                else
                {
                    commandText = "select * from LPerson where Status=98 and " + this.txCondition.Text + " order by Sid desc";
                }
            }
            else
            {
                commandText = "select * from LPerson where Status<>-1 and Status<>98 order by Sid desc";
            }
            dt = SqlHelper.ExecuteDataset(Config.DataSource, 1, commandText).Tables[0];
            CommonBasePage.SetPage(this.DataGridTable1, dt);
            base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
            this.txtParamstr.Text = base.PackPart(base.ParamValue);
        }

        private void DataGridTable1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex > -1)
            {
                string text = e.Item.Cells[4].Text;
                string str2 = e.Item.Cells[12].Text;
                string str3 = e.Item.Cells[11].Text;
                string str4 = "";
                try
                {
                    DateTime time2 = Convert.ToDateTime(str3);
                    TimeSpan span = (TimeSpan) (SafeDateTime.LocalNow - time2);
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
                        break;

                    case "0":
                        str4 = "New";
                        break;

                    case "1":
                        str4 = "Approved";
                        break;

                    case "2":
                        str4 = "Completed";
                        break;

                    case "98":
                        str4 = "Deleted";
                        break;

                    case "99":
                        str4 = "Rejected";
                        break;

                    case "101":
                        str4 = "Expired";
                        break;

                    case "15":
                        str4 = "Pre-Approved";
                        break;

                    case "24":
                        str4 = "Collection";
                        break;
                }
                e.Item.Cells[11].Text = Convert.ToDateTime(str3).ToString("dd/MM/yyyy hh:mm:ss");
                e.Item.Cells[12].Text = str4;
                e.Item.Cells[0x12].Text = "<a href='../../Long/CustomInfo.aspx?sid=" + Cipher.DesEncrypt(text, "12345678") + "' target=_blank>Agreement</a>";
                try
                {
                    DataRowView dataItem = (DataRowView) e.Item.DataItem;
                    string str6 = string.Empty;
                    string str7 = string.Empty;
                    if (((dataItem.Row["Other1"] == null) || (dataItem.Row["Other1"] is DBNull)) || (dataItem.Row["Other1"].ToString() == string.Empty))
                    {
                        str6 = "Empty";
                        e.Item.Cells[15].Text = string.Format("<a href='LMemberLoadNotes.aspx?id={0}'>{1}</a>", text, str6);
                    }
                    else
                    {
                        str6 = "Attention";
                        e.Item.Cells[15].Text = string.Format("<a dealed='Attention' href='LMemberLoadNotes.aspx?id={0}'>{1}</a>", text, str6);
                    }
                    if (((dataItem.Row["Other2"] == null) || (dataItem.Row["Other2"] is DBNull)) || (dataItem.Row["Other2"].ToString() == string.Empty))
                    {
                        str7 = "Empty";
                        e.Item.Cells[0x10].Text = string.Format("<a href='LMemberLoadFollowUpHistory.aspx?id={0}'>{1}</a>", text, str7);
                    }
                    else
                    {
                        str7 = "Attention";
                        e.Item.Cells[0x10].Text = string.Format("<a dealed='Attention' href='LMemberLoadFollowUpHistory.aspx?id={0}'>{1}</a>", text, str7);
                    }
                }
                catch
                {
                }
            }
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

