namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class longts4 : Page
    {
        protected Panel Panel1;
        protected HtmlInputButton Submit1;
        protected HtmlInputText txDated;
        protected HtmlInputText txDatem;
        protected HtmlInputText txDatey;
        protected HtmlSelect txMonth;
        protected HtmlSelect txYear;

        private void InitializeComponent()
        {
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

