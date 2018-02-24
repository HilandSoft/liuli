namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business.CommonLogic;
    using YingNet.WeiXing.STRUCTURE;
    using YingNet.WeiXing.WebApp.UControls;

    public class Calculator : Page
    {
        protected HtmlInputButton bnCal2;
        protected HtmlInputButton bnStar2;
        protected int CurrentYear = SafeDateTime.LocalNow.Year;
        protected Label Label1;
        protected Literal litSchedule;
        protected RepaymentCycleTypeSelector RepaymentCycleTypeSelector1;
        protected HtmlInputText txDd1;
        protected HtmlInputText txIncome;
        protected HtmlInputText txLoan;
        protected HtmlInputText txMm1;
        protected TextBox txNumber;
        protected TextBox txRepayA;
        protected TextBox txRepayF;
        protected HtmlInputText txYy1;

        private void bnCal2_ServerClick(object sender, EventArgs e)
        {
            this.CalcDateDue();
        }

        private void bnStar2_ServerClick(object sender, EventArgs e)
        {
            this.txDd1.Value = "";
            this.txIncome.Value = "";
            this.txLoan.Value = "";
            this.txMm1.Value = "";
            this.litSchedule.Text = "";
            this.txYy1.Value = "";
        }

        private void CalcDateDue()
        {
            DateTime time = new DateTime();
            DateTime time2 = new DateTime();
            DateTime time3 = new DateTime();
            DateTime time4 = new DateTime();
            DateTime salaryDate = new DateTime();
            try
            {
                salaryDate = new DateTime(Convert.ToInt32(this.txYy1.Value), Convert.ToInt32(this.txMm1.Value), Convert.ToInt32(this.txDd1.Value));
            }
            catch
            {
            }
            PaidPeriodTypes selectedRepaymentCycleType = this.RepaymentCycleTypeSelector1.SelectedRepaymentCycleType;
            int numInstallmentCount = PayDaySchedule.CalculateInstallmentCount(selectedRepaymentCycleType, salaryDate, SafeDateTime.LocalNow);
            string errorString = string.Empty;
            DateTime[] payDates = new DateTime[9];
            if (PayDaySchedule.CalculatePayDate(this.Page, salaryDate, selectedRepaymentCycleType, SafeDateTime.LocalNow, ref payDates, out errorString))
            {
                float numIncomeOrBenefit = Convert.ToSingle(this.txIncome.Value);
                float numLoanAmount = Convert.ToSingle(this.txLoan.Value);
                double payAmountPerTime = 0.0;
                if (PayDaySchedule.CalculatePayLoan(this.Page, numIncomeOrBenefit, numLoanAmount, numInstallmentCount, false, ref payAmountPerTime, out errorString))
                {
                    string str2 = string.Empty;
                    for (int i = 0; i < payDates.Length; i++)
                    {
                        str2 = str2 + string.Format("[installment{0}]/.{1}/ ${2}<br/>", i + 1, payDates[i].ToString("dd/MM/yyyy"), payAmountPerTime.ToString("0.00"));
                    }
                    this.litSchedule.Text = str2;
                }
                else
                {
                    base.Response.Write(errorString);
                }
            }
            else
            {
                base.Response.Write(errorString);
            }
        }

        private void InitializeComponent()
        {
            this.bnStar2.ServerClick += new EventHandler(this.bnStar2_ServerClick);
            this.bnCal2.ServerClick += new EventHandler(this.bnCal2_ServerClick);
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

