namespace YingNet.WeiXing.WebApp.UControls
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class RepaymentCountTypeSelector : UserControl
    {
        protected DropDownList DropDownList1;

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

        public int SelectedRepaymentCountType
        {
            get
            {
                return Convert.ToInt32(this.DropDownList1.SelectedValue);
            }
            set
            {
                this.DropDownList1.SelectedValue = value.ToString();
            }
        }
    }
}

