namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.Business.CommonLogic;
    using YingNet.WeiXing.DB.Data;
    using YingNet.WeiXing.STRUCTURE;
    using YingNet.WeiXing.WebApp.Include;

    public class step3 : Page
    {
        protected HtmlTableRow annualRateRow;
        protected Button Button1;
        protected CircleDropDownList ddlHousePaymentCircle;
        protected CircleDropDownList ddlOtherLenderCircle;
        protected DropDownList ddlSmalCreditCount;
        protected DropDownList DropDownList1;
        protected HtmlInputHidden Hidden1;
        protected LinkButton Linkbutton3;
        protected Panel Panel1;
        protected Panel Panel2;
        protected Panel Panel3;
        protected Panel Panel4;
        protected Panel Panel5;
        protected double payAmountPerTime4Schedule;
        protected DateTime[] payDates4Schedule;
        protected RadioButtonList RadioButtonList1;
        protected RadioButtonList RadioButtonList2;
        protected RadioButtonList RadioButtonList3;
        protected RadioButtonList RadioButtonList4;
        protected RadioButtonList rblHasOtherSamllCredit;
        protected HtmlInputButton Submit1;
        protected HtmlInputText txAddress;
        protected HtmlInputText txAname;
        protected HtmlInputText txAnumber;
        protected HtmlInputText txBank;
        protected HtmlInputText txBenefit;
        protected HtmlInputText txBranch;
        protected HtmlInputText txBsb;
        protected HtmlInputText txCAnumber;
        protected HtmlInputText txContact;
        protected HtmlInputText txDd1;
        protected HtmlInputText txDd4;
        protected HtmlInputText txDd5;
        protected HtmlInputText txDd6;
        protected HtmlInputText txEmployer;
        protected TextBox txFullname;
        protected TextBox txhuiSid;
        protected HtmlInputText txIncome;
        protected HtmlInputText txInstallment;
        protected HtmlInputText txJob;
        protected HtmlInputText txLoan;
        protected HtmlInputText txMm1;
        protected HtmlInputText txMm4;
        protected HtmlInputText txMm5;
        protected HtmlInputText txMm6;
        protected HtmlSelect txMonth;
        protected HtmlSelect txMonth2;
        protected HtmlInputText txOffice;
        protected HtmlInputText txPhone;
        protected HtmlInputText txtHousePaymentValue;
        protected TextBox txtLoanPurpose;
        protected HtmlInputText txtOtherLenderValue;
        protected HtmlInputText txType;
        protected HtmlSelect txYear;
        protected HtmlSelect txYear2;
        protected HtmlInputText txYy1;
        protected HtmlInputText txYy4;
        protected HtmlInputText txYy5;
        protected HtmlInputText txYy6;

        private void Button1_Click(object sender, EventArgs e)
        {
            this.CalDateDue();
            this.CalLoan();
        }

        public void CalDateDue()
        {
            DateTime timeRecentlySalaryDate = this.getSalaryDate();
            int selectedIndex = this.RadioButtonList1.SelectedIndex;
            string errorString = string.Empty;
            DateTime[] payDates = new DateTime[9];
            if (PayDaySchedule.CalculatePayDate(this.Page, timeRecentlySalaryDate, this.GetSelectedRepaymentCycleType(selectedIndex), SafeDateTime.LocalNow, ref payDates, out errorString))
            {
                this.Session["payDates4Schedule"] = payDates;
                this.payDates4Schedule = payDates;
            }
            else
            {
                base.Response.Write(errorString);
            }
        }

        public void CalLoan()
        {
            float num;
            int userLoanType = 0;
            float numLoanAmount = Convert.ToSingle(this.txLoan.Value);
            if (this.RadioButtonList1.SelectedIndex == 0)
            {
                num = Convert.ToSingle(this.txIncome.Value);
                userLoanType = 0;
            }
            else
            {
                num = Convert.ToSingle(this.txBenefit.Value);
                userLoanType = 1;
            }
            DateTime salaryDate = this.getSalaryDate();
            int numInstallmentCount = PayDaySchedule.CalculateInstallmentCount(this.GetSelectedRepaymentCycleType(userLoanType), salaryDate, SafeDateTime.LocalNow);
            string errorString = string.Empty;
            double payAmountPerTime = 0.0;
            if (PayDaySchedule.CalculatePayLoan(this.Page, num, numLoanAmount, numInstallmentCount, true, ref payAmountPerTime, out errorString))
            {
                this.payAmountPerTime4Schedule = payAmountPerTime;
                this.Session["numInstallmentCount4Schedule"] = numInstallmentCount;
                this.Session["payAmountPerTime4Schedule"] = payAmountPerTime;
            }
            else
            {
                base.Response.Write(errorString);
            }
        }

        private void DisplayAnnualRate()
        {
            this.annualRateRow.Attributes["style"] = "Display:block";
            this.annualRateRow.Visible = true;
        }

        public void getHuiyuan()
        {
            HuiyuanBN nbn = new HuiyuanBN(this.Page);
            HuiyuanDT dt = nbn.Get(Convert.ToInt32(this.Session["huiSid"]));
            dt.IsValid = 0;
            nbn.Edit(dt);
            InfoBN obn = new InfoBN(this.Page);
            InfoDT odt = new InfoDT();
            odt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
            odt.Username = dt.Username;
            odt.type = "3";
            odt.regtime = SafeDateTime.LocalNow;
            odt.isvalid = 1;
            obn.Add(odt);
        }

        public void getInfo()
        {
            EmployedBN dbn = new EmployedBN(this.Page);
            EmployedDT dt = new EmployedDT();
            float num = 0f;
            if (this.RadioButtonList1.SelectedIndex == 0)
            {
                dt.Employer = this.txEmployer.Value;
                dt.EAddress = this.txAddress.Value;
                dt.EPhone = this.txPhone.Value;
                dt.TYears = Convert.ToInt32(this.txYear.Value);
                dt.TMonths = Convert.ToInt32(this.txMonth.Value);
                dt.MIncome = Convert.ToSingle(this.txIncome.Value);
                dt.Wpaid = this.RadioButtonList2.SelectedValue;
                dt.NDayMM = Convert.ToInt32(this.txMm1.Value);
                dt.NDayDD = Convert.ToInt32(this.txDd1.Value);
                dt.NDayYY = Convert.ToInt32(this.txYy1.Value);
                dt.IsEmployed = 1;
                dt.Param5 = this.txJob.Value;
            }
            else
            {
                dt.Employer = this.txType.Value;
                dt.EAddress = this.txOffice.Value;
                dt.EPhone = this.txContact.Value;
                dt.TYears = Convert.ToInt32(this.txYear2.Value);
                dt.TMonths = Convert.ToInt32(this.txMonth2.Value);
                dt.MIncome = Convert.ToSingle(this.txBenefit.Value);
                dt.Wpaid = this.RadioButtonList3.SelectedValue;
                dt.NDayMM = Convert.ToInt32(this.txMm4.Value);
                dt.NDayDD = Convert.ToInt32(this.txDd4.Value);
                dt.NDayYY = Convert.ToInt32(this.txYy4.Value);
                dt.IsEmployed = 0;
            }
            dt.Branch = this.txBranch.Value;
            dt.BankName = this.txBank.Value;
            dt.AName = this.txAname.Value;
            dt.Bsb = this.txBsb.Value;
            dt.ANumber = this.txAnumber.Value;
            dt.MContact = this.RadioButtonList4.SelectedValue;
            dt.Param4 = this.txFullname.Text;
            dt.IsValid = 3;
            dt.Loan = Convert.ToSingle(this.txLoan.Value);
            dt.NInstallment = Convert.ToInt32(this.Session["numInstallmentCount4Schedule"]);
            dt.RTime = SafeDateTime.LocalNow;
            dt.LoanPurpose = this.txtLoanPurpose.Text;
            dt.HousePaymentCircle = EnumsOP.GetHousePaymentCircleByLiteral(this.ddlHousePaymentCircle.SelectedValue);
            dt.HousePaymentValue = Convert.ToSingle(this.txtHousePaymentValue.Value);
            dt.OtherLenderCircle = EnumsOP.GetOtherLenderCircleByLiteral(this.ddlOtherLenderCircle.SelectedValue);
            dt.OtherLenderValue = Convert.ToSingle(this.txtOtherLenderValue.Value);
            dt.OtherSamllCreditHas = int.Parse(this.rblHasOtherSamllCredit.SelectedValue);
            dt.OtherSmallCreditCount = int.Parse(this.ddlSmalCreditCount.SelectedValue);
            DataTable list = new SystemInfoBN(this.Page).GetList();
            if (list.Rows.Count > 0)
            {
                dt.Interest = Convert.ToSingle(list.Rows[0]["interest"].ToString());
                if (this.RadioButtonList1.SelectedIndex == 0)
                {
                    switch (this.RadioButtonList2.SelectedIndex)
                    {
                        case 0:
                            dt.Frequency = 7.0;
                            break;

                        case 1:
                            dt.Frequency = 14.0;
                            break;

                        case 2:
                            dt.Frequency = Convert.ToSingle(list.Rows[0]["frequency"].ToString());
                            break;
                    }
                }
                else
                {
                    switch (this.RadioButtonList3.SelectedIndex)
                    {
                        case 0:
                            dt.Frequency = 7.0;
                            break;

                        case 1:
                            dt.Frequency = 14.0;
                            break;

                        case 2:
                            dt.Frequency = Convert.ToSingle(list.Rows[0]["frequency"].ToString());
                            break;
                    }
                }
                num = Convert.ToSingle(list.Rows[0]["poundage"].ToString());
            }
            if (this.DropDownList1.SelectedValue.Equals("4"))
            {
                dt.XDay = Convert.ToInt32(this.Session["XFirst2"]);
            }
            else
            {
                dt.XDay = Convert.ToInt32(this.Session["XFirst"]);
            }
            dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
            dt.Param1 = dt.NInstallment * Convert.ToDouble(this.Session["payAmountPerTime4Schedule"]);
            dt.Param2 = num * dt.NInstallment;
            dt.Param3 = 1;
            this.Hidden1.Value = dbn.Add2(dt).ToString();
        }

        private PaidPeriodTypes GetPaidPeridType()
        {
            PaidPeriodTypes weekly = PaidPeriodTypes.Weekly;
            RadioButtonList list = this.RadioButtonList2;
            if (this.RadioButtonList1.SelectedIndex == 0)
            {
                list = this.RadioButtonList2;
            }
            else
            {
                list = this.RadioButtonList3;
            }
            string str = list.SelectedValue.ToLower();
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

        private DateTime getSalaryDate()
        {
            DateTime time = new DateTime();
            if (this.RadioButtonList1.SelectedIndex == 0)
            {
                return new DateTime(Convert.ToInt32(this.txYy1.Value), Convert.ToInt32(this.txMm1.Value), Convert.ToInt32(this.txDd1.Value), 0x17, 0x3b, 0x3b);
            }
            return new DateTime(Convert.ToInt32(this.txYy4.Value), Convert.ToInt32(this.txMm4.Value), Convert.ToInt32(this.txDd4.Value), 0x17, 0x3b, 0x3b);
        }

        public void getSchedule()
        {
            ScheduleBN ebn = new ScheduleBN(this.Page);
            ScheduleDT dt = null;
            double num = Convert.ToDouble(this.Session["payAmountPerTime4Schedule"]);
            DateTime[] timeArray = (DateTime[]) this.Session["payDates4Schedule"];
            int num2 = Convert.ToInt32(this.Session["numInstallmentCount4Schedule"]);
            for (int i = 0; i < num2; i++)
            {
                dt = new ScheduleDT();
                dt.Datedue = timeArray[i];
                dt.Repaydue = num;
                dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
                dt.Numberment = 1;
                dt.Param1 = this.Hidden1.Value;
                dt.Param2 = "0";
                dt.Balance = num * (i + 1);
                dt.RepayTime = Convert.ToDateTime("2000-1-1");
                dt.OperateTime = Convert.ToDateTime("2000-1-1");
                ebn.Add(dt);
            }
        }

        private PaidPeriodTypes GetSelectedRepaymentCycleType(int userLoanType)
        {
            PaidPeriodTypes weekly = PaidPeriodTypes.Weekly;
            RadioButtonList list = null;
            if (userLoanType == 0)
            {
                list = this.RadioButtonList2;
            }
            else
            {
                list = this.RadioButtonList3;
            }
            string str = list.SelectedValue.ToLower();
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

        private void InitializeComponent()
        {
            this.RadioButtonList1.SelectedIndexChanged += new EventHandler(this.RadioButtonList1_SelectedIndexChanged);
            this.Linkbutton3.Click += new EventHandler(this.Linkbutton3_Click);
            this.Button1.Click += new EventHandler(this.Button1_Click);
            this.Submit1.ServerClick += new EventHandler(this.Submit1_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void Linkbutton3_Click(object sender, EventArgs e)
        {
            if (this.RadioButtonList1.SelectedValue.Equals("0"))
            {
                DateTime time = new DateTime(Convert.ToInt32(this.txYy1.Value), Convert.ToInt32(this.txMm1.Value), Convert.ToInt32(this.txDd1.Value));
                if (time <= SafeDateTime.LocalNow)
                {
                    base.Response.Write("<script>alert(\"Field 'Next Payday' under 'Member Loan Application' is not valid!\");</script>");
                    return;
                }
            }
            else
            {
                DateTime time2 = new DateTime(Convert.ToInt32(this.txYy4.Value), Convert.ToInt32(this.txMm4.Value), Convert.ToInt32(this.txDd4.Value));
                if (time2 <= SafeDateTime.LocalNow)
                {
                    base.Response.Write("<script>alert(\"Field 'Next benefit due' under 'Member Loan Application' is not valid!\");</script>");
                    return;
                }
            }
            this.Panel1.Visible = false;
            this.Panel2.Visible = false;
            this.Panel5.Visible = false;
            this.Panel3.Visible = false;
            this.Panel4.Visible = true;
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (this.Session["huiSid"] == null)
            {
                base.Response.Write("<script>window.top.location.href='newcu2.htm';</script>");
            }
            else
            {
                this.txhuiSid.Text = this.Session["huiSid"].ToString();
                this.Button1.Attributes.Add("onclick", "return CheckLoan()");
                if (this.RadioButtonList1.SelectedIndex == 0)
                {
                    if (this.Linkbutton3.Attributes.Count > 0)
                    {
                        this.Linkbutton3.Attributes.Remove("onclick");
                    }
                    this.Linkbutton3.Attributes.Add("onclick", "return CheckFeedback4();");
                }
                else
                {
                    if (this.Linkbutton3.Attributes.Count > 0)
                    {
                        this.Linkbutton3.Attributes.Remove("onclick");
                    }
                    this.Linkbutton3.Attributes.Add("onclick", "return CheckFeedback5();");
                }
            }
            if (!base.IsPostBack)
            {
                this.annualRateRow.Visible = false;
            }
        }

        private void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RadioButtonList1.SelectedIndex == 0)
            {
                this.Panel1.Visible = true;
                this.Panel2.Visible = false;
            }
            else
            {
                this.Panel1.Visible = false;
                this.Panel2.Visible = true;
            }
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            if (this.txFullname.Text == "")
            {
                base.Response.Write("<script>alert('You need to sign by tying in your FULL name before submission.');</script>");
            }
            else if (this.Session["Repayduezs"] == null)
            {
                base.Response.Write("<script>alert(\"Please click 'Calculate' button for repayment schedule before you submit the application.\");</script>");
            }
            else if (this.Session["Repayduezs"].ToString() != this.txLoan.Value)
            {
                base.Response.Write("<script>alert(\"Please click 'Calculate' button for repayment schedule before you submit the application.\");</script>");
            }
            else
            {
                try
                {
                    this.Session["NumberLoanI"] = this.Session["numInstallmentCount4Schedule"];
                    this.getInfo();
                    this.getSchedule();
                    this.getHuiyuan();
                    base.Response.Write("<script>window.top.location='newcu4.htm';</script>");
                }
                catch (Exception exception)
                {
                    base.Response.Write(exception.Message);
                }
            }
        }
    }
}

