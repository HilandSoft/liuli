namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;
    using YingNet.WeiXing.STRUCTURE;

    public class LProcessList : ManageBasePage2
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
            ListItem item3 = new ListItem(ProcessCenterStatusEnum.Pending.ToString(), "Pending");
            this.ddlQuery.Items.Add(item3);
            ListItem item4 = new ListItem(ProcessCenterStatusEnum.DetailVerified.ToString(), "DetailVerified");
            this.ddlQuery.Items.Add(item4);
            ListItem item5 = new ListItem(ProcessCenterStatusEnum.PreApproval.ToString(), "PreApproval");
            this.ddlQuery.Items.Add(item5);
            ListItem item6 = new ListItem(ProcessCenterStatusEnum.PreApproved.ToString(), "PreApproved");
            this.ddlQuery.Items.Add(item6);
            ListItem item7 = new ListItem(ProcessCenterStatusEnum.FinalApproval.ToString(), "FinalApproval");
            this.ddlQuery.Items.Add(item7);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string[] strArray = DataGridUtils.getID(this.DataGridTable1);
            if (strArray != null)
            {
                int num = 0;
                CSProcessCenterBN rbn = new CSProcessCenterBN(this.Page);
                for (int i = 0; i < strArray.Length; i++)
                {
                    int id = Convert.ToInt32(strArray[i]);
                    if (rbn.Del(id))
                    {
                        num++;
                    }
                }
                this.Page.RegisterStartupScript("", "<script language=javascript>alert('" + num.ToString().Trim() + "items are deleted in total');window.location='LProcessList.aspx';</script>");
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
                    str = string.Format(" UserID={0} ", this.txKey.Text);
                    break;

                case "Pending":
                    str = string.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.Pending));
                    break;

                case "DetailVerified":
                    str = string.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.DetailVerified));
                    break;

                case "PreApproval":
                    str = string.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.PreApproval));
                    break;

                case "PreApproved":
                    str = string.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.PreApproved));
                    break;

                case "FinalApproval":
                    str = string.Format(" ProcessStatus={0} ", Convert.ToInt32(ProcessCenterStatusEnum.FinalApproval));
                    break;
            }
            this.txCondition.Text = str;
            this.DataGridTable1.DataBind();
        }

        private void DataGridTable1_DataBinding(object sender, EventArgs e)
        {
            CSProcessCenterBN rbn = new CSProcessCenterBN(this.Page);
            DataTable dt = null;
            rbn.CleanStatus();
            rbn.Filter = string.Format(" UserLoanType={0} ", 1);
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
                CSProcessCenterDT rdt = null;
                if (dataItem != null)
                {
                    rdt = new CSProcessCenterBN(this.Page).Get(Convert.ToInt32(dataItem["ProcessID"]));
                    if (rdt != null)
                    {
                        Literal literal = e.Item.FindControl("litDocumentCheckList") as Literal;
                        if (literal != null)
                        {
                            literal.Text = Convert.ToString(rdt.DocumentCheckListStatus);
                        }
                        Literal literal2 = e.Item.FindControl("litDetailVerification") as Literal;
                        if (literal2 != null)
                        {
                            literal2.Text = Convert.ToString(rdt.DetailsVerificationStatus);
                        }
                        Literal literal3 = e.Item.FindControl("litStatus") as Literal;
                        if (literal3 != null)
                        {
                            literal3.Text = Convert.ToString(rdt.ProcessStatus);
                        }
                        Literal literal4 = e.Item.FindControl("litOperate") as Literal;
                        if (literal4 != null)
                        {
                            literal4.Text = string.Format("<a href='LProcessInfo.aspx?ProcessID={0}'>Edit</a>", dataItem["ProcessID"]);
                        }
                        Literal literal5 = e.Item.FindControl("LitUserName") as Literal;
                        if ((literal5 != null) && (rdt.UserID > 0))
                        {
                            LpersonDT ndt = new LpersonBN(this.Page).Get(rdt.UserID);
                            if (ndt != null)
                            {
                                literal5.Text = string.Format("{0} {1}", ndt.Sname, ndt.Fname);
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
                return FunnctionModuleEnum.LProcessCenter;
            }
            set
            {
                base.FunnctionModuleName = value;
            }
        }
    }
}

