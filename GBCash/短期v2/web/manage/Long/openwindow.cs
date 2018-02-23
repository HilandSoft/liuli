namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;

    public class openwindow : CommonBasePage
    {
        protected DataGridTable DataGridTable1;
        protected TextBox txtParamstr;

        private void DataGridTable1_DataBinding(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            string commandText = "";
            commandText = "select * from LPerson where Other4=0 order by Regtime desc";
            dt = SqlHelper.ExecuteDataset(Config.DataSource, 1, commandText).Tables[0];
            CommonBasePage.SetPage(this.DataGridTable1, dt);
            base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
            this.txtParamstr.Text = base.PackPart(base.ParamValue);
        }

        private void DataGridTable1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.DataGridTable1.CurrentPageIndex = e.NewPageIndex;
            this.DataGridTable1.DataBind();
        }

        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
            this.DataGridTable1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridTable1_PageIndexChanged);
            this.DataGridTable1.DataBinding += new EventHandler(this.DataGridTable1_DataBinding);
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

