namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.Common;

    public class ExeTable : Page
    {
        protected Button Button1;
        protected DataGrid DataGrid1;
        protected TextBox TextBox1;

        private void Button1_Click(object sender, EventArgs e)
        {
            DataTable table = new DataTable();
            table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, this.TextBox1.Text).Tables[0];
            this.DataGrid1.DataSource = table;
            this.DataGrid1.DataBind();
        }

        private void InitializeComponent()
        {
            this.Button1.Click += new EventHandler(this.Button1_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
        }
    }
}

