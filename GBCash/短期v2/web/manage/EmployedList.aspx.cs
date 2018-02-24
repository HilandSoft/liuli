namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;

    public class EmployedList : CommonBasePage
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        protected DataGridTable DataGridTable1;
        protected TextBox txKey;
        protected TextBox txsql;
        protected TextBox txtParamstr;

        private void Button1_Click(object sender, EventArgs e)
        {
            this.DataGridTable1.DataBind();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DBAccess access = new DBAccess();
            access.RunSqlStringNoReturn(this.txsql.Text);
            access.Close();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            base.Response.Write(this.txsql.Text);
        }

        private void DataGridTable1_DataBinding(object sender, EventArgs e)
        {
            EmployedBN dbn = new EmployedBN(this.Page);
            if (this.txKey.Text != "")
            {
                dbn.QueryhuiSid(this.txKey.Text);
            }
            DataTable list = dbn.GetList();
            CommonBasePage.SetPage(this.DataGridTable1, list);
            base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
            this.txtParamstr.Text = base.PackPart(base.ParamValue);
        }

        private void DataGridTable1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
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
            this.Button1.Click += new EventHandler(this.Button1_Click);
            this.Button2.Click += new EventHandler(this.Button2_Click);
            this.Button3.Click += new EventHandler(this.Button3_Click);
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

