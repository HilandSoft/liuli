namespace YingNet.WeiXing.WebApp.Manage
{
    using System;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;

    public class UserManage : ManageBasePage
    {
        protected Button ButAdd;
        protected DataGridTable DataGridTable1;
        protected TextBox txtParamstr;

        private void ButAdd_Click(object sender, EventArgs e)
        {
            base.Response.Redirect("UserAdd.aspx?" + base.PackFull(this.txtParamstr.Text));
        }

        private void DataGridTable1_DataBinding(object sender, EventArgs e)
        {
            CommonBasePage.SetPage(this.DataGridTable1, new YingSystemUserBN(this.Page).GetList());
            base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
            this.txtParamstr.Text = base.PackPart(base.ParamValue);
        }

        private void DataGridTable1_ItemCommand(object source, DataGridCommandEventArgs e)
        {
            switch (e.CommandName)
            {
                case "edit":
                    base.Response.Redirect("UserEdit.aspx?id=" + e.Item.Cells[0].Text + "&" + base.PackFull(this.txtParamstr.Text));
                    break;

                case "delete":
                    base.Response.Redirect("UserDel.aspx?id=" + e.Item.Cells[0].Text + "&" + base.PackFull(this.txtParamstr.Text));
                    break;
            }
        }

        private void DataGridTable1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            ListItemType itemType = e.Item.ItemType;
            DataGridItem item = e.Item;
            if ((itemType.Equals(ListItemType.AlternatingItem) || itemType.Equals(ListItemType.EditItem)) || (itemType.Equals(ListItemType.Item) || itemType.Equals(ListItemType.SelectedItem)))
            {
                int num = Convert.ToInt32(base.GetValue("pageno"));
                if (num > 1)
                {
                    item.Cells[1].Text = (((this.DataGridTable1.PageSize * (num - 1)) + e.Item.ItemIndex) + 1).ToString();
                }
                else
                {
                    item.Cells[1].Text = (e.Item.ItemIndex + 1).ToString();
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
            this.ButAdd.Click += new EventHandler(this.ButAdd_Click);
            this.DataGridTable1.ItemCommand += new DataGridCommandEventHandler(this.DataGridTable1_ItemCommand);
            this.DataGridTable1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridTable1_PageIndexChanged);
            this.DataGridTable1.DataBinding += new EventHandler(this.DataGridTable1_DataBinding);
            this.DataGridTable1.ItemDataBound += new DataGridItemEventHandler(this.DataGridTable1_ItemDataBound);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            base.Code = "001001";
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                base.ParamValue = base.UnPack();
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

