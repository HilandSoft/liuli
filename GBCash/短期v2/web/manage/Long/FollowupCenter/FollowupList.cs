namespace YingNet.WeiXing.WebApp.manage.Long.FollowupCenter
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;
    using YingNet.WeiXing.STRUCTURE;

    public class FollowupList : ManageBasePage2
    {
        protected Button btnDelete;
        protected Button btnQuery;
        protected CheckBox CheckBox1;
        protected DataGridTable DataGridTable1;
        protected DropDownList ddlQuery;
        protected Label Label1;
        protected TextBox txCondition;
        protected TextBox txKey;
        protected TextBox txtParamstr;

        private void BindQueryInfo()
        {
            ListItem item = new ListItem("PleaseSelect", "PleaseSelect");
            this.ddlQuery.Items.Add(item);
            ListItem item2 = new ListItem("MemberID", "MemberID");
            this.ddlQuery.Items.Add(item2);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string[] strArray = DataGridUtils.getID(this.DataGridTable1);
            if (strArray != null)
            {
                int num = 0;
                CSFollowupCenterBN rbn = new CSFollowupCenterBN(this.Page);
                for (int i = 0; i < strArray.Length; i++)
                {
                    int id = Convert.ToInt32(strArray[i]);
                    if (rbn.Del(id))
                    {
                        num++;
                    }
                }
                this.Page.RegisterStartupScript("", "<script language=javascript>alert('" + num.ToString().Trim() + "items are deleted in total');window.location='ProcessList.aspx';</script>");
            }
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            string str = string.Empty;
            switch (this.ddlQuery.SelectedValue)
            {
                case "PleaseSelect":
                    str = string.Empty;
                    break;

                case "MemberID":
                    if (this.txKey.Text.Trim() == string.Empty)
                    {
                        str = string.Empty;
                    }
                    else
                    {
                        str = string.Format(" UserID={0} ", this.txKey.Text);
                    }
                    break;
            }
            this.txCondition.Text = str;
            this.DataGridTable1.DataBind();
        }

        private void DataGridTable1_DataBinding(object sender, EventArgs e)
        {
            CSFollowupCenterBN rbn = new CSFollowupCenterBN(this.Page);
            DataTable dt = null;
            rbn.CleanStatus();
            rbn.Filter = string.Format(" UserLoanType={0} ", 1);
            string str = base.Request.QueryString["status"];
            if ((str != null) && (str != string.Empty))
            {
                rbn.Filter = string.Format(" FollowupStatus={0} ", str);
            }
            if (this.txCondition.Text != string.Empty)
            {
                rbn.Filter = this.txCondition.Text;
            }
            dt = rbn.GetList();
            CommonBasePage.SetPage(this.DataGridTable1, dt);
            base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
            this.txtParamstr.Text = base.PackPart(base.ParamValue);
        }

        private void DataGridTable1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if ((e.Item.ItemIndex >= 0) && (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.SelectedItem)))
            {
                DataRowView dataItem = (DataRowView) e.Item.DataItem;
                CSFollowupCenterDT rdt = null;
                if (dataItem != null)
                {
                    rdt = new CSFollowupCenterBN(this.Page).Get(Convert.ToInt32(dataItem["FollowupID"]));
                    if (rdt != null)
                    {
                        Literal literal = e.Item.FindControl("LitCustomerNumber") as Literal;
                        if (literal != null)
                        {
                            literal.Text = string.Format("<a target='_blank' href='../LongDetail.aspx?sid={0}'>{0}</a>", rdt.UserID);
                        }
                        Literal literal2 = e.Item.FindControl("litStatus") as Literal;
                        if (literal2 != null)
                        {
                            literal2.Text = Convert.ToString(rdt.FollowupStatus);
                        }
                        Literal literal3 = e.Item.FindControl("LitPreStatus") as Literal;
                        if (literal3 != null)
                        {
                            literal3.Text = Convert.ToString(rdt.PreviewStatus);
                        }
                        Literal literal4 = e.Item.FindControl("litOperate") as Literal;
                        if (literal4 != null)
                        {
                            literal4.Text = string.Format("<a href='FollowupInfo.aspx?followupID={0}&status={1}'>Edit</a> <a href='FollowupDele.aspx?followupID={0}'>Delete</a>", dataItem["followupID"], base.Request.QueryString["status"]);
                        }
                        Literal literal5 = e.Item.FindControl("LitActionDueDate") as Literal;
                        if ((literal5 != null) && (rdt.RemindDate > new DateTime(0x6d9, 1, 2)))
                        {
                            literal5.Text = rdt.RemindDate.ToString("dd-MM-yyyy");
                        }
                        if (rdt.UserID > 0)
                        {
                            LpersonDT ndt = new LpersonBN(this.Page).Get(rdt.UserID);
                            if (ndt != null)
                            {
                                Literal literal6 = e.Item.FindControl("LitUserName") as Literal;
                                if (literal6 != null)
                                {
                                    literal6.Text = ndt.Username;
                                }
                                Literal literal7 = e.Item.FindControl("LitFirstName") as Literal;
                                if (literal7 != null)
                                {
                                    literal7.Text = ndt.Fname;
                                }
                                Literal literal8 = e.Item.FindControl("LitMiddleName") as Literal;
                                if (literal8 != null)
                                {
                                    literal8.Text = ndt.Mname;
                                }
                                Literal literal9 = e.Item.FindControl("LitLastName") as Literal;
                                if (literal9 != null)
                                {
                                    literal9.Text = ndt.Sname;
                                }
                                Literal literal10 = e.Item.FindControl("LitPassword") as Literal;
                                if (literal10 != null)
                                {
                                    literal10.Text = ndt.Pwd;
                                }
                                Literal literal11 = e.Item.FindControl("LitDateBirth") as Literal;
                                if (literal11 != null)
                                {
                                    literal11.Text = ndt.DBirth;
                                }
                                Literal literal12 = e.Item.FindControl("LitDriverNumber") as Literal;
                                if (literal12 != null)
                                {
                                    literal12.Text = ndt.LicNum;
                                }
                                Literal literal13 = e.Item.FindControl("LitNote") as Literal;
                                if (literal13 != null)
                                {
                                    string str = string.Empty;
                                    if ((ndt.Other1 == null) || (ndt.Other1 == string.Empty))
                                    {
                                        str = "Empty";
                                        str = string.Format("<a href='../LMemberLoadNotes.aspx?id={0}&from=lp'>{1}</a>", ndt.sid, str);
                                    }
                                    else
                                    {
                                        str = "Attention";
                                        str = string.Format("<a dealed='Attention' href='../LMemberLoadNotes.aspx?id={0}&from=lp'>{1}</a>", ndt.sid, str);
                                    }
                                    literal13.Text = str;
                                }
                                Literal literal14 = e.Item.FindControl("LitFollowUpHistory") as Literal;
                                if (literal14 != null)
                                {
                                    string str2 = string.Empty;
                                    if ((ndt.Other2 == null) || (ndt.Other2 == string.Empty))
                                    {
                                        str2 = "Empty";
                                        str2 = string.Format("<a href='../LMemberLoadFollowUpHistory.aspx?id={0}&from=lp'>{1}</a>", ndt.sid, str2);
                                    }
                                    else
                                    {
                                        str2 = "Attention";
                                        str2 = string.Format("<a dealed='Attention' href='../LMemberLoadFollowUpHistory.aspx?id={0}&from=lp'>{1}</a>", ndt.sid, str2);
                                    }
                                    literal14.Text = str2;
                                }
                                Literal literal15 = e.Item.FindControl("LitRegtime") as Literal;
                                if (literal15 != null)
                                {
                                    literal15.Text = ndt.RegTime.ToString("dd-mm-yyyy");
                                }
                            }
                        }
                    }
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
            this.btnQuery.Click += new EventHandler(this.btnQuery_Click);
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
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
                this.BindQueryInfo();
                this.btnDelete.Text = "Delete";
                this.btnDelete.Attributes["onclick"] = "return deleteit(this.form)";
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

        protected override CommonOperateEnum CommonOperate
        {
            get
            {
                return CommonOperateEnum.List;
            }
            set
            {
                base.CommonOperate = value;
            }
        }

        protected override FunnctionModuleEnum FunnctionModuleName
        {
            get
            {
                return FunnctionModuleEnum.LFollowupCenter;
            }
            set
            {
                base.FunnctionModuleName = value;
            }
        }
    }
}

