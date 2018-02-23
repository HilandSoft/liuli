namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.Business.CommonLogic;
    using YingNet.WeiXing.DB.Data;
    using YingNet.WeiXing.STRUCTURE;
    using YingNet.WeiXing.WebApp.Include;

    public class newloan : generagepage
    {
        public string AName = "";
        public string ANumber = "";
        public string BankName = "";
        public string Branch = "";
        public string Bsb = "";
        protected Button Button1;
        protected HtmlInputButton Button2;
        protected CheckBox cbUnderStoodTerm;
        protected CheckBox CheckBox1;
        public string CustomerNum = "";
        protected CircleDropDownList ddlHousePaymentCircle;
        protected CircleDropDownList ddlOtherLenderCircle;
        protected DropDownList ddlSmalCreditCount;
        public string EmploymentInfo = "";
        protected HtmlForm Form2;
        protected HtmlInputHidden Hidden1;
        protected HtmlInputHidden Hidden2;
        protected HtmlInputHidden Hidden3;
        public string huiName = "";
        public string IsEmployed = "";
        protected LinkButton LinkButton1;
        protected LinkButton LinkButton2;
        protected LinkButton LinkButton3;
        protected LinkButton Linkbutton4;
        protected LinkButton LinkbuttonAcknowledge;
        protected Literal litAmountOfCredit;
        protected Literal litAnnualPercentageRate;
        protected Literal litChargeForCredit;
        protected Literal litRepaymentInDays;
        protected Literal litTotalPayable;
        public string MContact = "";
        protected HtmlInputText nPayDd;
        protected HtmlInputText nPayMm;
        protected HtmlInputText nPayYy;
        public string paid = "";
        protected Panel Panel1;
        protected Panel Panel2;
        protected Panel Panel3;
        protected Panel Panel4;
        protected Panel PanelNoExtensionTip;
        protected Panel PanelWarning;
        protected double payAmountPerTime4Schedule;
        protected DateTime[] payDates4Schedule;
        protected RadioButtonList RadioButtonList1;
        protected RadioButtonList rblHasOtherSamllCredit;
        protected RadioButtonList rblIsGrossIncomeChange;
        protected RadioButtonList rblIsPayOtherCredit;
        public string Rname1 = "";
        public string Rname2 = "";
        public string Rname3 = "";
        public string Rnum1 = "";
        public string Rnum2 = "";
        public string Rnum3 = "";
        public string Rship1 = "";
        public string Rship2 = "";
        public string Rship3 = "";
        public string selState = "";
        protected TextBox tbxGrossIncomeChangeValue;
        protected TextBox tbxPayOtherCreditValue;
        protected TextBox Textbox1;
        public string tip1 = "";
        public string tip2 = "";
        public string tip3 = "";
        public string tip4 = "";
        public string tip5 = "";
        public string tip6 = "";
        public string txAddress = "";
        public string txCity = "";
        public string txDate = "";
        public string txDd1 = "";
        public string txDriver = "";
        public string txEmail = "";
        public string txEmployer = "";
        public string txFax = "";
        public string txFname = "";
        protected TextBox txFullname;
        public string txIncome = "";
        protected HtmlInputText txInstallment;
        public string txIssue = "";
        public string txLname = "";
        protected HtmlInputText txLoan;
        public string txMm1 = "";
        public string txMname = "";
        public string txMobile = "";
        public string txMonth = "";
        public string txMonthM = "";
        public string txPhone = "";
        public string txPost = "";
        public string txResident = "";
        public string txStreet = "";
        public string txTel = "";
        protected HtmlInputText txtHousePaymentValue;
        protected TextBox txtLoanPurpose;
        protected HtmlInputText txtOtherLenderValue;
        public string txYear = "";
        public string txYearM = "";
        public string txYy1 = "";

        private void Button1_Click(object sender, EventArgs e)
        {
            this.PanelWarning.Visible = false;
            DateTime time = new DateTime(Convert.ToInt32(this.nPayYy.Value), Convert.ToInt32(this.nPayMm.Value), Convert.ToInt32(this.nPayDd.Value));
            if (time <= SafeDateTime.LocalNow)
            {
                base.Response.Write("<script>alert(\"Field 'Next Payday' under 'Member Loan Application' is not valid!\");</script>");
            }
            else
            {
                bool flag = this.CalDateDue();
                if (flag)
                {
                    flag = this.CalLoan();
                }
                if (flag)
                {
                    this.Panel3.Visible = false;
                    this.Panel4.Visible = true;
                }
            }
        }

        private void Button2_ServerClick(object sender, EventArgs e)
        {
            this.PanelWarning.Visible = false;
            if (this.rblHasOtherSamllCredit.SelectedIndex < 0)
            {
                base.Response.Write("<script>alert(\"Please select if you have any default in payment under other small amount credit contract.\");</script>");
            }
            else if (!this.cbUnderStoodTerm.Checked)
            {
                base.Response.Write("<script>alert(\"Have you read and understood Golden Bridge Cash Solution's Information Statement? \");</script>");
            }
            else if (this.txFullname.Text == "")
            {
                base.Response.Write("<script>alert('You need to sign by tying in your FULL name before submission.');</script>");
            }
            else
            {
                DateTime time = new DateTime(Convert.ToInt32(this.nPayYy.Value), Convert.ToInt32(this.nPayMm.Value), Convert.ToInt32(this.nPayDd.Value));
                if (time <= SafeDateTime.LocalNow)
                {
                    base.Response.Write("<script>alert(\"Field 'Next Payday' under 'Member Loan Application' is not valid!\");</script>");
                }
                else if (this.Session["Repayduezs"].ToString() != this.txLoan.Value)
                {
                    base.Response.Write("<script>alert(\"Please click 'Calculate' button for repayment schedule before you submit the application.\");</script>");
                }
                else
                {
                    try
                    {
                        this.SetInfo();
                        this.SetSchedule();
                        this.SetTip();
                        this.SetProcessCenter();
                        base.Response.Write("<script>window.alert('Congratulations! Your loan application has been submitted successfully. You can check your application status by login members section.');window.location='detail1.aspx';</script>");
                    }
                    catch (Exception exception)
                    {
                        base.Response.Write(exception.Message);
                    }
                }
            }
        }

        public bool CalDateDue()
        {
            DateTime salaryDate = this.GetSalaryDate();
            string errorString = string.Empty;
            DateTime[] payDates = new DateTime[9];
            bool flag = PayDaySchedule.CalculatePayDate(this.Page, salaryDate, this.GetSelectedRepaymentCycleType(), SafeDateTime.LocalNow, ref payDates, out errorString);
            if (flag)
            {
                this.Session["payDates4Schedule"] = payDates;
                this.payDates4Schedule = payDates;
                this.Session["LastPayDate"] = payDates[payDates.Length - 1];
                return flag;
            }
            base.Response.Write(errorString);
            return flag;
        }

        public bool CalLoan()
        {
            string str = "";
            EmployedBN dbn = new EmployedBN(this.Page);
            dbn.QueryhuiSid(this.Hidden3.Value);
            dbn.QueryParam3("1");
            dbn.QueryIsValid("1");
            DataTable list = dbn.GetList();
            if (list.Rows.Count > 0)
            {
                str = list.Rows[0]["MIncome"].ToString();
            }
            float numLoanAmount = Convert.ToSingle(this.txLoan.Value);
            float numIncomeOrBenefit = Convert.ToSingle(str);
            DateTime salaryDate = this.GetSalaryDate();
            int num12 = Convert.ToInt32(list.Rows[0]["IsEmployed"]);
            int numInstallmentCount = PayDaySchedule.CalculateInstallmentCount(this.GetSelectedRepaymentCycleType(), salaryDate, SafeDateTime.LocalNow);
            string errorString = string.Empty;
            double payAmountPerTime = 0.0;
            bool flag = PayDaySchedule.CalculatePayLoan(this.Page, numIncomeOrBenefit, numLoanAmount, numInstallmentCount, false, ref payAmountPerTime, out errorString);
            double num15 = 0.0;
            if (flag)
            {
                this.payAmountPerTime4Schedule = payAmountPerTime;
                this.Session["numInstallmentCount4Schedule"] = numInstallmentCount;
                this.Session["payAmountPerTime4Schedule"] = payAmountPerTime;
                num15 = payAmountPerTime * numInstallmentCount;
                DateTime time2 = new DateTime(0x7d0, 1, 1);
                if (this.Session["LastPayDate"] != null)
                {
                    time2 = Convert.ToDateTime(this.Session["LastPayDate"]);
                }
                this.litAmountOfCredit.Text = numLoanAmount.ToString();
                this.litChargeForCredit.Text = (num15 - numLoanAmount).ToString("0.00");
                this.litTotalPayable.Text = num15.ToString("0.00");
                TimeSpan span = (TimeSpan) (time2 - SafeDateTime.LocalNow);
                int num16 = span.Days + 1;
                this.litRepaymentInDays.Text = num16.ToString() + " day(s)";
                this.litAnnualPercentageRate.Text = (((28.0 / ((double) num16)) * 365.0)).ToString("0.00") + "%";
                return flag;
            }
            base.Response.Write(errorString);
            return flag;
        }

        private DateTime GetSalaryDate()
        {
            return new DateTime(Convert.ToInt32(this.nPayYy.Value), Convert.ToInt32(this.nPayMm.Value), Convert.ToInt32(this.nPayDd.Value), 0x17, 0x3b, 0x3b);
        }

        private PaidPeriodTypes GetSelectedRepaymentCycleType()
        {
            PaidPeriodTypes weekly = PaidPeriodTypes.Weekly;
            string str = this.RadioButtonList1.SelectedValue.ToLower();
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
            this.LinkButton1.Click += new EventHandler(this.LinkButton1_Click);
            this.LinkButton3.Click += new EventHandler(this.LinkButton3_Click);
            this.Linkbutton4.Click += new EventHandler(this.Linkbutton4_Click);
            this.LinkbuttonAcknowledge.Click += new EventHandler(this.LinkbuttonAcknowledge_Click);
            this.LinkButton2.Click += new EventHandler(this.LinkButton2_Click);
            this.Button1.Click += new EventHandler(this.Button1_Click);
            this.Button2.ServerClick += new EventHandler(this.Button2_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LinkButton1_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = true;
            this.Panel2.Visible = false;
        }

        private void LinkButton2_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = false;
            this.Panel3.Visible = true;
        }

        private void LinkButton3_Click(object sender, EventArgs e)
        {
            if (this.CheckBox1.Checked)
            {
                this.Panel2.Visible = false;
                this.Panel3.Visible = true;
                this.PanelWarning.Visible = false;
            }
            else
            {
                base.Response.Write("<script>alert('Please Select!');</script>");
            }
        }

        private void Linkbutton4_Click(object sender, EventArgs e)
        {
            this.Panel2.Visible = true;
            this.PanelWarning.Visible = false;
        }

        private void LinkbuttonAcknowledge_Click(object sender, EventArgs e)
        {
            HuiyuanBN nbn = new HuiyuanBN(this.Page);
            HuiyuanDT dt = nbn.Get(Convert.ToInt32(base.HuiSid));
            if (dt != null)
            {
                dt.NoExtensionTiped = 1;
                nbn.Edit(dt);
            }
            this.PanelNoExtensionTip.Visible = false;
            this.PanelWarning.Visible = true;
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.Button1.Attributes.Add("onclick", "return CheckLoan()");
            HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(Convert.ToInt32(base.HuiSid));
            if ((ndt != null) && (ndt.NoExtensionTiped == 1))
            {
                this.PanelNoExtensionTip.Visible = false;
                this.PanelWarning.Visible = true;
            }
            else
            {
                this.PanelNoExtensionTip.Visible = true;
                this.PanelWarning.Visible = false;
            }
            EmployedBN dbn = new EmployedBN(this.Page);
            this.Hidden3.Value = base.HuiSid;
            dbn.Filter = " huiSid=" + this.Hidden3.Value + " and (IsValid=0 or IsValid=2 or IsValid=3 or IsValid=22) ";
            if (dbn.GetList().Rows.Count > 0)
            {
                base.Response.Write("<script>alert('To apply a new loan you must have already successfully applied and repaid your current loan in full.');window.location.href='detail1.aspx';</script>");
            }
            else
            {
                EmployedBN dbn2 = new EmployedBN(this.Page);
                dbn2.QueryParam3("1");
                dbn2.QueryhuiSid(this.Hidden3.Value);
                DataTable list = dbn2.GetList();
                HuiyuanBN nbn2 = new HuiyuanBN(this.Page);
                nbn2.QuerySid(this.Hidden3.Value);
                DataTable table2 = nbn2.GetList();
                this.CustomerNum = table2.Rows[0]["id"].ToString();
                this.txFname = table2.Rows[0]["Fname"].ToString();
                this.txLname = table2.Rows[0]["Lname"].ToString();
                this.txMname = table2.Rows[0]["Mname"].ToString();
                this.huiName = this.txFname + " " + this.txMname + " " + this.txLname;
                this.txDate = Convert.ToDateTime(table2.Rows[0]["DBirth"]).Day.ToString() + "/" + Convert.ToDateTime(table2.Rows[0]["DBirth"]).Month.ToString() + "/" + Convert.ToDateTime(table2.Rows[0]["DBirth"]).Year.ToString();
                this.txEmail = table2.Rows[0]["Email"].ToString();
                this.txIssue = table2.Rows[0]["Issued"].ToString();
                this.txDriver = table2.Rows[0]["DNumber"].ToString();
                this.txResident = table2.Rows[0]["RAddress"].ToString();
                this.txStreet = table2.Rows[0]["SAddress"].ToString();
                this.txCity = table2.Rows[0]["City"].ToString();
                this.selState = table2.Rows[0]["State"].ToString();
                this.txPost = table2.Rows[0]["Postcode"].ToString();
                this.txYearM = table2.Rows[0]["TYears"].ToString();
                this.txMonthM = table2.Rows[0]["TMonths"].ToString();
                this.txTel = table2.Rows[0]["HTel"].ToString();
                this.txMobile = table2.Rows[0]["Mobile"].ToString();
                this.txFax = table2.Rows[0]["Param1"].ToString();
                this.txEmployer = list.Rows[0]["Employer"].ToString();
                this.txAddress = list.Rows[0]["EAddress"].ToString();
                this.txPhone = list.Rows[0]["EPhone"].ToString();
                this.txYear = list.Rows[0]["TYears"].ToString();
                this.txMonth = list.Rows[0]["TMonths"].ToString();
                this.txIncome = Convert.ToSingle(list.Rows[0]["MIncome"]).ToString("0.00");
                this.paid = list.Rows[0]["Wpaid"].ToString();
                this.txMm1 = list.Rows[0]["NDayMM"].ToString();
                this.txDd1 = list.Rows[0]["NDayDD"].ToString();
                this.txYy1 = list.Rows[0]["NDayYY"].ToString();
                this.IsEmployed = list.Rows[0]["IsEmployed"].ToString();
                this.Branch = list.Rows[0]["Branch"].ToString();
                this.BankName = list.Rows[0]["BankName"].ToString();
                this.AName = list.Rows[0]["AName"].ToString();
                this.Bsb = list.Rows[0]["Bsb"].ToString();
                this.ANumber = list.Rows[0]["ANumber"].ToString();
                this.MContact = list.Rows[0]["MContact"].ToString();
                this.Rname1 = list.Rows[0]["Rname1"].ToString();
                this.Rname2 = list.Rows[0]["Rname2"].ToString();
                this.Rname3 = list.Rows[0]["Rname3"].ToString();
                this.Rship1 = list.Rows[0]["Rship1"].ToString();
                this.Rship2 = list.Rows[0]["Rship2"].ToString();
                this.Rship3 = list.Rows[0]["Rship3"].ToString();
                this.Rnum1 = list.Rows[0]["Rnum1"].ToString();
                this.Rnum2 = list.Rows[0]["Rnum2"].ToString();
                this.Rnum3 = list.Rows[0]["Rnum3"].ToString();
                if (this.IsEmployed.Equals("1"))
                {
                    this.tip1 = "Your Occupation:";
                    this.tip2 = "Employer:";
                    this.tip3 = "Employer’s Address:";
                    this.tip4 = "Employer Phone:";
                    this.tip5 = "Time Employed: ";
                    this.tip6 = "Take home pay after taxes: ";
                }
                else
                {
                    this.tip1 = "";
                    this.tip2 = "Type of benefit:";
                    this.tip3 = "Centreline Office:";
                    this.tip4 = "Contact Name:";
                    this.tip5 = "How long on this benefit: ";
                    this.tip6 = "Take Home Benefit:";
                }
            }
        }

        public void SetInfo()
        {
            EmployedBN dbn = new EmployedBN(this.Page);
            EmployedDT dt = new EmployedDT();
            float num = 0f;
            dbn.QueryhuiSid(this.Hidden3.Value);
            int count = dbn.GetList().Rows.Count;
            dt.Param4 = this.txFullname.Text;
            dt.IsValid = 3;
            dt.Loan = Convert.ToSingle(this.txLoan.Value);
            dt.NInstallment = Convert.ToInt32(this.Session["numInstallmentCount4Schedule"]);
            dt.RTime = SafeDateTime.LocalNow;
            DataTable list = new SystemInfoBN(this.Page).GetList();
            if (list.Rows.Count > 0)
            {
                dt.Interest = Convert.ToSingle(list.Rows[0]["interest"].ToString());
                num = Convert.ToSingle(list.Rows[0]["poundage"].ToString());
            }
            dt.Frequency = Convert.ToInt32(this.Session["frequency"]);
            dt.XDay = Convert.ToInt32(this.Session["XFirst"]);
            dt.huiSid = Convert.ToInt32(this.Hidden3.Value);
            dt.Param1 = dt.NInstallment * Convert.ToDouble(this.Session["payAmountPerTime4Schedule"]);
            dt.Param2 = num * dt.NInstallment;
            dt.Param3 = count + 1;
            dt.LoanPurpose = this.txtLoanPurpose.Text;
            dt.HousePaymentCircle = EnumsOP.GetHousePaymentCircleByLiteral(this.ddlHousePaymentCircle.SelectedValue);
            dt.HousePaymentValue = Convert.ToSingle(this.txtHousePaymentValue.Value);
            dt.OtherLenderCircle = EnumsOP.GetOtherLenderCircleByLiteral(this.ddlOtherLenderCircle.SelectedValue);
            dt.OtherLenderValue = Convert.ToSingle(this.txtOtherLenderValue.Value);
            dt.OtherSamllCreditHas = int.Parse(this.rblHasOtherSamllCredit.SelectedValue);
            dt.OtherSmallCreditCount = int.Parse(this.ddlSmalCreditCount.SelectedValue);
            dt.IsGrossIncomeChange = int.Parse(this.rblIsGrossIncomeChange.SelectedValue);
            dt.IsPayOtherCredit = int.Parse(this.rblIsPayOtherCredit.SelectedValue);
            dt.GrossIncomeChangeValue = this.tbxGrossIncomeChangeValue.Text;
            dt.PayOtherCreditValue = this.tbxPayOtherCreditValue.Text;
            dt.Wpaid = this.RadioButtonList1.SelectedValue;
            try
            {
                dt.NDayDD = Convert.ToInt32(this.nPayDd.Value);
                dt.NDayMM = Convert.ToInt32(this.nPayMm.Value);
                dt.NDayYY = Convert.ToInt32(this.nPayYy.Value);
            }
            catch
            {
            }
            this.Hidden1.Value = dbn.Add2(dt).ToString();
            this.Hidden2.Value = (count + 1).ToString();
        }

        public void SetProcessCenter()
        {
            HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(Convert.ToInt32(this.Hidden3.Value));
            CSProcessCenterBN rbn = new CSProcessCenterBN(this.Page);
            CSProcessCenterDT dt = new CSProcessCenterDT();
            dt.ConversationTrack = string.Empty;
            dt.IsFirstLoan = false;
            dt.LoanID = 0;
            dt.PostDate = SafeDateTime.LocalNow;
            dt.ProcessStatus = ProcessCenterStatusEnum.Pending;
            dt.UserID = ndt.id;
            dt.UserLoanType = UserLoanTypes.Short;
            dt.LastOperateDate = SafeDateTime.LocalNow;
            rbn.Add(dt);
        }

        public void SetSchedule()
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
                dt.Numberment = Convert.ToInt32(this.Hidden2.Value);
                dt.Param1 = this.Hidden1.Value;
                dt.Param2 = "0";
                dt.Balance = num * (i + 1);
                dt.RepayTime = Convert.ToDateTime("2000-1-1");
                dt.OperateTime = Convert.ToDateTime("2000-1-1");
                ebn.Add(dt);
            }
        }

        public void SetTip()
        {
            HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(Convert.ToInt32(this.Hidden3.Value));
            InfoBN obn = new InfoBN(this.Page);
            InfoDT dt = new InfoDT();
            dt.huiSid = Convert.ToInt32(this.Hidden3.Value);
            dt.Username = ndt.Username;
            dt.type = "4";
            dt.regtime = SafeDateTime.LocalNow;
            dt.isvalid = 1;
            obn.Add(dt);
        }
    }
}

