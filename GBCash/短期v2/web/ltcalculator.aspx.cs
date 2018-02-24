namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;

    public class ltcalculator : Page
    {
        protected HtmlSelect dlterms;
        protected RadioButtonList RadioButtonList2;
        protected RadioButtonList RadioButtonList3;
        protected HtmlSelect select;
        protected HtmlInputText textfield29242;
        protected HtmlInputText textfield292422;
        protected HtmlInputText textfield29243;
        protected HtmlInputText textfield292432;
        protected HtmlInputText textfield292433;
        protected HtmlInputText txDd1;
        protected HtmlInputText txIncome;
        protected HtmlInputText txMm1;
        protected HtmlInputText txYy1;

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

