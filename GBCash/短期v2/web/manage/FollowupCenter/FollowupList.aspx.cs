namespace YingNet.WeiXing.WebApp.manage.FollowupCenter
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

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
            rbn.Filter = string.Format(" UserLoanType={0} ", 0);
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
                            literal.Text = string.Format("<a target='_blank' href='../MemberDetail.aspx?id={0}'>{0}</a>", rdt.UserID);
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
                        MemberLoadNoteDT byMemberID = new MemberLoadNoteBN(this.Page).GetByMemberID(rdt.UserID);
                        if (byMemberID != null)
                        {
                            Literal literal4 = e.Item.FindControl("LitNote") as Literal;
                            if (literal4 != null)
                            {
                                string str = string.Empty;
                                if ((byMemberID.NoteContent != null) && (byMemberID.NoteContent != string.Empty))
                                {
                                    str = "Attention";
                                    str = string.Format("<a dealed='Attention' href='../MemberLoadNotes.aspx?id={0}&from=sf'>{1}</a>", rdt.UserID, str);
                                }
                                else
                                {
                                    str = "Empty";
                                    str = string.Format("<a href='../MemberLoadNotes.aspx?id={0}&from=sf'>{1}</a>", rdt.UserID, str);
                                }
                                literal4.Text = str;
                            }
                            Literal literal5 = e.Item.FindControl("LitFollowUpHistory") as Literal;
                            if (literal5 != null)
                            {
                                string str2 = string.Empty;
                                if ((byMemberID.NodeDesc != null) && (byMemberID.NodeDesc != string.Empty))
                                {
                                    str2 = "Attention";
                                    str2 = string.Format("<a dealed='Attention' href='../MemberLoadFollowUpHistory.aspx?id={0}&from=sf'>{1}</a>", rdt.UserID, str2);
                                }
                                else
                                {
                                    str2 = "Empty";
                                    str2 = string.Format("<a href='../MemberLoadFollowUpHistory.aspx?id={0}&from=sf'>{1}</a>", rdt.UserID, str2);
                                }
                                literal5.Text = str2;
                            }
                        }
                        else
                        {
                            Literal literal6 = e.Item.FindControl("LitNote") as Literal;
                            if (literal6 != null)
                            {
                                literal6.Text = string.Format("<a href='../MemberLoadNotes.aspx?id={0}&from=sf'>{1}</a>", rdt.UserID, "Empty");
                            }
                            Literal literal7 = e.Item.FindControl("LitFollowUpHistory") as Literal;
                            if (literal7 != null)
                            {
                                literal7.Text = string.Format("<a href='../MemberLoadFollowUpHistory.aspx?id={0}&from=sf'>{1}</a>", rdt.UserID, "Empty");
                            }
                        }
                        Literal literal8 = e.Item.FindControl("litOperate") as Literal;
                        if (literal8 != null)
                        {
                            literal8.Text = string.Format("<a href='FollowupInfo.aspx?followupID={0}&status={1}'>Edit</a> <a href='FollowupDele.aspx?followupID={0}'>Delete</a>", dataItem["followupID"], base.Request.QueryString["status"]);
                        }
                        Literal literal9 = e.Item.FindControl("LitActionDueDate") as Literal;
                        if ((literal9 != null) && (rdt.RemindDate > new DateTime(0x6d9, 1, 2)))
                        {
                            literal9.Text = rdt.RemindDate.ToString("dd-MM-yyyy");
                        }
                        if (rdt.UserID > 0)
                        {
                            HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(rdt.UserID);
                            if (ndt != null)
                            {
                                Literal literal10 = e.Item.FindControl("LitScore") as Literal;
                                if (literal10 != null)
                                {
                                    string str3 = string.Empty;
                                    if ((ndt.Param3 == null) || (ndt.Param3 == string.Empty))
                                    {
                                        str3 = "Empty";
                                    }
                                    else
                                    {
                                        str3 = ndt.Param3;
                                    }
                                    literal10.Text = string.Format("<a href='../MemberScore.aspx?id={0}&from=sf'>{1}</a>", rdt.UserID, str3);
                                }
                                Literal literal11 = e.Item.FindControl("LitUserName") as Literal;
                                if (literal11 != null)
                                {
                                    literal11.Text = ndt.Username;
                                }
                                Literal literal12 = e.Item.FindControl("LitFirstName") as Literal;
                                if (literal12 != null)
                                {
                                    literal12.Text = ndt.Fname;
                                }
                                Literal literal13 = e.Item.FindControl("LitMiddleName") as Literal;
                                if (literal13 != null)
                                {
                                    literal13.Text = ndt.Mname;
                                }
                                Literal literal14 = e.Item.FindControl("LitLastName") as Literal;
                                if (literal14 != null)
                                {
                                    literal14.Text = ndt.Lname;
                                }
                                Literal literal15 = e.Item.FindControl("LitPassword") as Literal;
                                if (literal15 != null)
                                {
                                    literal15.Text = ndt.Password;
                                }
                                Literal literal16 = e.Item.FindControl("LitDateBirth") as Literal;
                                if (literal16 != null)
                                {
                                    literal16.Text = ndt.DBirth.ToString("dd-MM-yyyy");
                                }
                                Literal literal17 = e.Item.FindControl("LitDriverNumber") as Literal;
                                if (literal17 != null)
                                {
                                    literal17.Text = ndt.DNumber;
                                }
                                Literal literal18 = e.Item.FindControl("LitRegtime") as Literal;
                                if (literal18 != null)
                                {
                                    literal18.Text = ndt.Regtime.ToString("dd-MM-yyyy");
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
                return FunnctionModuleEnum.FollowupCenter;
            }
            set
            {
                base.FunnctionModuleName = value;
            }
        }
    }
}

