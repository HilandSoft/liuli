namespace YingNet.WeiXing.WebApp.manage.Long.ProcessCenter
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class openwindow : ManageBasePage2
    {
        protected DataGridTable DataGridTable1;
        protected TextBox txtParamstr;

        private void DataGridTable1_DataBinding(object sender, EventArgs e)
        {
            CSProcessCenterBN rbn = new CSProcessCenterBN(this.Page);
            DataTable dt = null;
            rbn.CleanStatus();
            rbn.Filter = string.Format(" UserLoanType={0} ", 1);
            rbn.Filter = string.Format(" processOther1={0} ", 0);
            string alertStateWithPermission = this.GetAlertStateWithPermission();
            if (alertStateWithPermission != string.Empty)
            {
                rbn.Filter = string.Format(" ProcessStatus in ({0}) ", alertStateWithPermission);
            }
            rbn.Order = " LastOperateDate desc";
            dt = rbn.GetList();
            CommonBasePage.SetPage(this.DataGridTable1, dt);
            base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
            this.txtParamstr.Text = base.PackPart(base.ParamValue);
        }

        private void DataGridTable1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if ((e.Item.ItemIndex > -1) && (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.SelectedItem)))
            {
                DataRowView dataItem = (DataRowView) e.Item.DataItem;
                CSProcessCenterDT rdt = null;
                if (dataItem != null)
                {
                    rdt = new CSProcessCenterBN(this.Page).Get(Convert.ToInt32(dataItem["ProcessID"]));
                    if (rdt != null)
                    {
                        Literal literal = e.Item.FindControl("litStatus") as Literal;
                        if (literal != null)
                        {
                            literal.Text = Convert.ToString(rdt.ProcessStatus);
                        }
                        if (rdt.UserID > 0)
                        {
                            HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(rdt.UserID);
                            if (ndt != null)
                            {
                                Literal literal2 = e.Item.FindControl("LitUserName") as Literal;
                                if (literal2 != null)
                                {
                                    literal2.Text = ndt.Username;
                                }
                                Literal literal3 = e.Item.FindControl("LitRegtime") as Literal;
                                if (literal3 != null)
                                {
                                    literal3.Text = ndt.Regtime.ToString("dd-MM-yyyy");
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

        private string GetAlertStateWithPermission()
        {
            string str = string.Empty;
            if (base.UserPermission == null)
            {
                if (base.SystemUserAccount.ToLower() == "superlily")
                {
                    return string.Empty;
                }
                return "101";
            }
            if (this.ValitadePermissionOperate((CommonOperateEnum) base.UserPermission.PermissionProcessCenter, CommonOperateEnum.DetailsVerification))
            {
                str = str + 20.ToString() + ",";
            }
            if (this.ValitadePermissionOperate((CommonOperateEnum) base.UserPermission.PermissionProcessCenter, CommonOperateEnum.DocumentCheckList))
            {
                str = str + 0.ToString() + ",";
            }
            if (this.ValitadePermissionOperate((CommonOperateEnum) base.UserPermission.PermissionProcessCenter, CommonOperateEnum.PreApproval))
            {
                str = str + 10.ToString() + ",";
            }
            if (this.ValitadePermissionOperate((CommonOperateEnum) base.UserPermission.PermissionProcessCenter, CommonOperateEnum.FinalApproval))
            {
                str = (str + 30.ToString() + ",") + 40.ToString() + ",";
            }
            if (str.EndsWith(","))
            {
                str = str.Substring(0, str.Length - 1);
            }
            return str;
        }

        private void InitializeComponent()
        {
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
                return FunnctionModuleEnum.ProcessCenter;
            }
            set
            {
                base.FunnctionModuleName = value;
            }
        }

        protected override bool IsNeedValidate
        {
            get
            {
                return false;
            }
        }
    }
}

