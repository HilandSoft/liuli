namespace YingNet.WeiXing.WebApp.UControls
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.STRUCTURE;

    public class RepaymentCycleTypeSelector : UserControl
    {
        protected RadioButtonList rblPaymentCycleType;

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

        public PaidPeriodTypes SelectedRepaymentCycleType
        {
            get
            {
                PaidPeriodTypes weekly = PaidPeriodTypes.Weekly;
                RadioButtonList rblPaymentCycleType = this.rblPaymentCycleType;
                string str = rblPaymentCycleType.SelectedValue.ToLower();
                if (str == null)
                {
                    return weekly;
                }
                str = string.IsInterned(str);
                if (str == "weekly")
                {
                    return PaidPeriodTypes.Weekly;
                }
                if (str == "f'nightly")
                {
                    return PaidPeriodTypes.Fnightly;
                }
                if (str != "monthly")
                {
                    return weekly;
                }
                return PaidPeriodTypes.Monthly;
            }
            set
            {
                switch (value)
                {
                    case PaidPeriodTypes.Weekly:
                        this.rblPaymentCycleType.SelectedValue = "Weekly";
                        break;

                    case PaidPeriodTypes.Fnightly:
                        this.rblPaymentCycleType.SelectedValue = "F'nightly";
                        break;

                    case PaidPeriodTypes.Monthly:
                        this.rblPaymentCycleType.SelectedValue = "Monthly";
                        break;
                }
            }
        }
    }
}

