namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;

    public class LongTerm : CommonBasePage
    {
        protected CheckBox CheckBox1;
        protected DataGridTable DataGridTable1;
        protected TextBox txtParamstr;

        private void DataGridTable1_DataBinding(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string commandText = "select * from longtp";
            dt = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
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
                        str2 = "无效";
                        break;

                    case "1":
                        str2 = "有效";
                        break;

                    case "2":
                        str2 = "未申请";
                        break;
                }
                e.Item.Cells[12].Text = str2;
            }
        }

        private void DataGridTable1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.DataGridTable1.CurrentPageIndex = e.NewPageIndex;
            this.DataGridTable1.DataBind();
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
    }
}

