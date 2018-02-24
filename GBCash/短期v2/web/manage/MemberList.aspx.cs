namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class MemberList : ManageBasePage
    {
        protected Button btnDelete;
        protected Button Button1;
        protected CheckBox CheckBox1;
        protected DataGridTable DataGridTable1;
        protected DropDownList DropDownList1;
        protected Label Label1;
        protected TextBox txCondition;
        protected TextBox txKey;
        protected TextBox txtParamstr;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string[] strArray = DataGridUtils.getID(this.DataGridTable1);
            if (strArray != null)
            {
                int num = 0;
                HuiyuanBN nbn = new HuiyuanBN(this.Page);
                for (int i = 0; i < strArray.Length; i++)
                {
                    int id = Convert.ToInt32(strArray[i]);
                    HuiyuanDT dt = nbn.Get(id);
                    dt.IsValid = 3;
                    if (nbn.Edit(dt))
                    {
                        num++;
                    }
                }
                this.Page.RegisterStartupScript("", "<script language=javascript>alert('" + num.ToString().Trim() + "items are deleted in total');window.location='MemberList.aspx';</script>");
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string str6;
            if (!(this.DropDownList1.SelectedValue != "0"))
            {
                return;
            }
            string str = "";
            string text = "";
            string str3 = "";
            string str4 = "";
            string str5 = "";
            switch (this.DropDownList1.SelectedValue)
            {
                case "1":
                    str = " Fname like '%" + this.txKey.Text + "%' ";
                    goto Label_0349;

                case "8":
                    str = " Lname like '%" + this.txKey.Text + "%' ";
                    goto Label_0349;

                case "2":
                    str = " id=" + this.txKey.Text + " ";
                    goto Label_0349;

                case "3":
                    text = this.txKey.Text;
                    str3 = text.Substring(0, 2);
                    str4 = text.Substring(3, 2);
                    str5 = text.Substring(6, 4);
                    str = " day(Regtime) =" + str3 + " and month(Regtime)=" + str4 + " and year(Regtime)=" + str5 + " ";
                    goto Label_0349;

                case "4":
                    str = " IsValid=1 ";
                    goto Label_0349;

                case "5":
                    str = " IsValid=0 ";
                    goto Label_0349;

                case "6":
                    str = " IsValid=8 ";
                    goto Label_0349;

                case "7":
                    str = " IsValid=9 ";
                    break;

                case "10":
                    text = this.txKey.Text;
                    str3 = text.Substring(0, 2);
                    str4 = text.Substring(3, 2);
                    str5 = text.Substring(6, 4);
                    str = " day(DBirth) =" + str3 + " and month(DBirth)=" + str4 + " and year(DBirth)=" + str5 + " ";
                    break;

                case "18":
                    str = "E.Employer like '%" + this.txKey.Text + "%'";
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
        Label_0349:
            this.txCondition.Text = str;
            this.DataGridTable1.DataBind();
        }

        private void DataGridTable1_DataBinding(object sender, EventArgs e)
        {
            HuiyuanBN nbn = new HuiyuanBN(this.Page);
            if (this.txCondition.Text == "")
            {
                nbn.QueryNotValid("9");
                nbn.QueryNotValid("3");
            }
            else
            {
                nbn.Filter = this.txCondition.Text;
                nbn.QueryNotValid("3");
                if (!this.IsChooseUnCompleted())
                {
                    nbn.QueryNotValid("9");
                }
            }
            DataTable dt = null;
            if ((this.ViewState["SearchJoinEmployment"] == null) || (this.ViewState["SearchJoinEmployment"].ToString() == string.Empty))
            {
                dt = nbn.GetList();
            }
            else
            {
                dt = nbn.GetListJoinEmployment();
            }
            CommonBasePage.SetPage(this.DataGridTable1, dt);
            base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
            this.txtParamstr.Text = base.PackPart(base.ParamValue);
        }

        private void DataGridTable1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex > -1)
            {
                string text = e.Item.Cells[12].Text;
                string str2 = "";
                switch (text)
                {
                    case "0":
                        str2 = "New";
                        break;

                    case "1":
                        str2 = "Active";
                        break;

                    case "2":
                        str2 = "Uncompleted";
                        break;

                    case "3":
                        str2 = "Deleted";
                        break;

                    case "5":
                        str2 = "Expired";
                        break;

                    case "6":
                        str2 = "Rejected & Deleted";
                        break;

                    case "8":
                        str2 = "Rejected";
                        break;

                    case "9":
                        str2 = "Uncompleted";
                        break;

                    case "18":
                        str2 = "PreApprove";
                        break;

                    case "21":
                        str2 = "ReudcedLimit";
                        break;

                    case "22":
                        str2 = "BlackList";
                        break;

                    case "23":
                        str2 = "PermantlyBlackList";
                        break;

                    case "24":
                        str2 = "Collection";
                        break;
                }
                e.Item.Cells[12].Text = str2;
                e.Item.Cells[11].Text = Convert.ToDateTime(e.Item.Cells[11].Text).ToString("dd/MM/yyyy hh:mm:ss");
                try
                {
                    DataRowView dataItem = (DataRowView) e.Item.DataItem;
                    string str3 = string.Empty;
                    if (((dataItem.Row["Param3"] == null) || (dataItem.Row["Param3"] is DBNull)) || (dataItem.Row["Param3"].ToString() == string.Empty))
                    {
                        str3 = "Empty";
                    }
                    else
                    {
                        str3 = Convert.ToString(dataItem.Row["Param3"]);
                    }
                    e.Item.Cells[13].Text = string.Format("<a href='MemberScore.aspx?id={0}'>{1}</a>", dataItem.Row["id"], str3);
                }
                catch
                {
                }
                try
                {
                    DataRowView view2 = (DataRowView) e.Item.DataItem;
                    string str4 = string.Empty;
                    string str5 = string.Empty;
                    if (((view2.Row["Note"] == null) || (view2.Row["Note"] is DBNull)) || (view2.Row["Note"].ToString() == string.Empty))
                    {
                        str4 = "Empty";
                        e.Item.Cells[0x10].Text = string.Format("<a href='MemberLoadNotes.aspx?id={0}'>{1}</a>", view2.Row["id"], str4);
                    }
                    else
                    {
                        str4 = "Attention";
                        e.Item.Cells[0x10].Text = string.Format("<a dealed='Attention' href='MemberLoadNotes.aspx?id={0}'>{1}</a>", view2.Row["id"], str4);
                    }
                    if (((view2.Row["followUpHistory"] == null) || (view2.Row["followUpHistory"] is DBNull)) || (view2.Row["followUpHistory"].ToString() == string.Empty))
                    {
                        str5 = "Empty";
                        e.Item.Cells[0x11].Text = string.Format("<a href='MemberLoadFollowUpHistory.aspx?id={0}'>{1}</a>", view2.Row["id"], str5);
                    }
                    else
                    {
                        str5 = "Attention";
                        e.Item.Cells[0x11].Text = string.Format("<a dealed='Attention' href='MemberLoadFollowUpHistory.aspx?id={0}'>{1}</a>", view2.Row["id"], str5);
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
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
            this.DataGridTable1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridTable1_PageIndexChanged);
            this.DataGridTable1.DataBinding += new EventHandler(this.DataGridTable1_DataBinding);
            this.DataGridTable1.ItemDataBound += new DataGridItemEventHandler(this.DataGridTable1_ItemDataBound);
            base.Load += new EventHandler(this.Page_Load);
        }

        private bool IsChooseUnCompleted()
        {
            return (this.DropDownList1.SelectedValue == "7");
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
                this.btnDelete.Text = "Delete";
                this.btnDelete.Attributes["onclick"] = "return deleteit(this.form)";
                this.txtParamstr.Text = base.PackPart(base.ParamValue);
                string str = base.GetValue("pageno");
                if (str != null)
                {
                    this.DataGridTable1.CurrentPageIndex = Convert.ToInt32(str) - 1;
                }
                this.DataGridTable1.DataBind();
                ListItem item = null;
                item = new ListItem("Active", "4");
                this.DropDownList1.Items.Add(item);
                item = new ListItem("New", "5");
                this.DropDownList1.Items.Add(item);
                item = new ListItem("Rejected", "6");
                this.DropDownList1.Items.Add(item);
                item = new ListItem("Uncompleted", "7");
                this.DropDownList1.Items.Add(item);
                item = new ListItem("WorkPlace", "18");
                this.DropDownList1.Items.Add(item);
                this.Label1.Text = "Please enter the date format as DD/MM/YYYY";
            }
            else
            {
                base.ParamValue = base.UnPackPart(this.txtParamstr.Text);
            }
        }
    }
}

