namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class SystemInfo : ManageBasePage
    {
        protected TextBox datedifff;
        protected TextBox datediffm;
        protected TextBox datediffw;
        protected TextBox frequency;
        protected TextBox installment;
        protected TextBox interest;
        protected TextBox lowerlimit;
        protected TextBox lowerlimit2;
        protected TextBox percentage;
        protected TextBox poundage;
        protected RadioButtonList RadioButtonList1;
        protected HtmlInputButton Submit1;
        protected TextBox term;
        protected TextBox upperlimit;
        protected TextBox upperlimit2;
        protected TextBox yanqinum;

        private void InitializeComponent()
        {
            this.Submit1.ServerClick += new EventHandler(this.Submit1_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.IsPostBack)
            {
                SystemInfoDT odt = new SystemInfoBN(this.Page).Get(3);
                this.percentage.Text = odt.percentage.ToString();
                this.upperlimit.Text = odt.upperlimit.ToString();
                this.upperlimit2.Text = odt.upperlimit2.ToString();
                this.installment.Text = odt.installment.ToString();
                this.term.Text = odt.term.ToString();
                this.lowerlimit.Text = odt.lowerlimit.ToString();
                this.lowerlimit2.Text = odt.lowerlimit2.ToString();
                this.frequency.Text = odt.frequency.ToString();
                this.interest.Text = odt.interest.ToString();
                this.poundage.Text = odt.poundage.ToString();
                this.yanqinum.Text = odt.yanqinum.ToString();
                this.datediffw.Text = odt.datediffw.ToString();
                this.datedifff.Text = odt.datedifff.ToString();
                this.datediffm.Text = odt.datediffm.ToString();
            }
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            SystemInfoBN obn = new SystemInfoBN(this.Page);
            SystemInfoDT dt = obn.Get(3);
            dt.percentage = Convert.ToDouble(this.percentage.Text);
            dt.upperlimit = Convert.ToDouble(this.upperlimit.Text);
            dt.upperlimit2 = Convert.ToDouble(this.upperlimit2.Text);
            dt.installment = Convert.ToInt32(this.installment.Text);
            dt.term = Convert.ToInt32(this.term.Text);
            dt.lowerlimit = Convert.ToDouble(this.lowerlimit.Text);
            dt.lowerlimit2 = Convert.ToDouble(this.lowerlimit2.Text);
            dt.frequency = Convert.ToDouble(this.frequency.Text);
            dt.interest = Convert.ToDouble(this.interest.Text);
            dt.poundage = Convert.ToDouble(this.poundage.Text);
            dt.yanqinum = Convert.ToInt32(this.yanqinum.Text);
            dt.datediffw = Convert.ToInt32(this.datediffw.Text);
            dt.datedifff = Convert.ToInt32(this.datedifff.Text);
            dt.datediffm = Convert.ToInt32(this.datediffm.Text);
            obn.Edit(dt);
            base.Response.Write("<script>alert('Success!');window.location.href='SystemInfo.aspx';</script>");
        }
    }
}

