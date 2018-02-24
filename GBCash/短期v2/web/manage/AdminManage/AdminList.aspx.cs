namespace YingNet.WeiXing.WebApp.manage.AdminManage
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;

    public class AdminList : ManageBasePage2
    {
        protected Button btnDelete;
        protected CheckBox CheckBox1;
        protected CheckBox chkID;
        protected DataGridTable DataGridTable1;
        protected HyperLink hyCreate;
        protected Label Label1;
        protected TextBox txCondition;
        protected TextBox txtParamstr;

        private void btnDelete_Click(object sender, EventArgs e)
        {
            string[] strArray = DataGridUtils.getID(this.DataGridTable1);
            if (strArray != null)
            {
                int num = 0;
                CSUserBN rbn = new CSUserBN(this.Page);
                for (int i = 0; i < strArray.Length; i++)
                {
                    int id = Convert.ToInt32(strArray[i]);
                    if (rbn.Del(id))
                    {
                        num++;
                    }
                }
                this.Page.RegisterStartupScript("", "<script language=javascript>alert('" + num.ToString().Trim() + "items are deleted in total');window.location='AdminList.aspx';</script>");
            }
        }

        private void DataGridTable1_DataBinding(object sender, EventArgs e)
        {
            CSUserBN rbn = new CSUserBN(this.Page);
            DataTable dt = null;
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
                if (dataItem != null)
                {
                    Literal literal = e.Item.FindControl("litEnable") as Literal;
                    if (literal != null)
                    {
                        int num = 1;
                        try
                        {
                            num = Convert.ToInt32(dataItem["Enable"]);
                        }
                        catch
                        {
                        }
                        if (num == 1)
                        {
                            literal.Text = "True";
                        }
                        else
                        {
                            literal.Text = "False";
                        }
                    }
                    Literal literal2 = e.Item.FindControl("litLastLoginDate") as Literal;
                    if (literal2 != null)
                    {
                        DateTime time = new DateTime(0x6d9, 1, 2);
                        try
                        {
                            time = Convert.ToDateTime(dataItem["LastLoginDate"]);
                        }
                        catch
                        {
                        }
                        if (time < new DateTime(0x6d9, 1, 3))
                        {
                            literal2.Text = "Never Logined";
                        }
                        else
                        {
                            literal2.Text = time.ToString("dd-MM-yyyy hh:mm");
                        }
                    }
                    Literal literal3 = e.Item.FindControl("litOperate") as Literal;
                    if (literal3 != null)
                    {
                        literal3.Text = string.Format("<a href='AdminInfo.aspx?userID={0}'>Edit</a>", dataItem["userID"]);
                        literal3.Text = literal3.Text + string.Format(" <a href='PermissionInfo.aspx?userID={0}'>Permission</a>", dataItem["userID"]);
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
                return FunnctionModuleEnum.ManagerInfo;
            }
            set
            {
                base.FunnctionModuleName = value;
            }
        }
    }
}

