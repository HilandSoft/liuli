namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.Business.CommonLogic;
    using YingNet.WeiXing.DB.Data;
    using YingNet.WeiXing.STRUCTURE;
    using YingNet.WeiXing.WebApp.Include;

    public class MemberDetailEdit : ManageBasePage
    {
        public string AName = "";
        public string ANumber = "";
        public string BankName = "";
        public string Branch = "";
        public string Bsb = "";
        protected Button btnCalculate;
        public string d1 = "";
        protected TextBox d1F;
        public string d2 = "";
        protected TextBox d2F;
        public string d3 = "";
        protected TextBox d3F;
        protected CircleDropDownList ddlHousePaymentCircle;
        protected CircleDropDownList ddlOtherLenderCircle;
        protected DropDownList ddlSmalCreditCount;
        protected DropDownList ddlState;
        public string dlTitle = "";
        public string EmploymentInfo = "";
        protected HtmlInputHidden Hidden1;
        public string IsEmployed = "";
        public string MContact = "";
        public string paid = "";
        protected double payAmountPerTime4Schedule;
        protected DateTime[] payDates4Schedule;
        protected PerRadioButtonList PerRadioButtonList1;
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
        public string s1 = "";
        protected TextBox s1F;
        public string s2 = "";
        protected TextBox s2F;
        public string s3 = "";
        protected TextBox s3F;
        protected HtmlInputButton SaveButton;
        public string selState = "";
        protected TextBox tbxGrossIncomeChangeValue;
        protected TextBox tbxPayOtherCreditValue;
        protected TextBox TextBox15;
        protected TextBox TextBox28;
        public string tip1 = "";
        public string tip2 = "";
        public string tip3 = "";
        public string tip4 = "";
        public string tip5 = "";
        public string tip6 = "";
        public string tip7 = "";
        public string txAddress = "";
        public string txCity = "";
        public string txDate = "";
        public string txDd1 = "";
        public string txDriver = "";
        public string txEmail = "";
        public string txEmployer = "";
        public string txFax = "";
        public string txFname = "";
        public string txIncome = "";
        public string txIssue = "";
        public string txJob = "";
        public string txLname = "";
        public string txMm1 = "";
        public string txMname = "";
        public string txMobile = "";
        public string txMonth = "";
        public string txMonthd = "";
        public string txPhone = "";
        public string txPost = "";
        public string txResident = "";
        public string txStreet = "";
        protected TextBox txtAddress;
        protected TextBox txtAName;
        protected TextBox txtANumber;
        protected TextBox txtBankName;
        protected TextBox txtBranch;
        protected TextBox txtBsb;
        protected TextBox txtCity;
        protected TextBox txtDate;
        protected TextBox txtDd1;
        protected TextBox txtDriver;
        public string txTel = "";
        protected TextBox txtEmail;
        protected TextBox txtEmployer;
        protected TextBox txtFax;
        protected TextBox txtFname;
        protected HtmlInputText txtHousePaymentValue;
        protected TextBox txtIncome;
        protected TextBox txtIssue;
        protected TextBox txtJob;
        protected TextBox txtLname;
        protected HtmlInputText txtLoan;
        protected TextBox txtLoanPurpose;
        protected TextBox txtMContact;
        protected TextBox txtMm1;
        protected TextBox txtMname;
        protected TextBox txtMobile;
        protected TextBox txtMonth;
        protected TextBox txtMonthd;
        protected HtmlInputText txtOtherLenderValue;
        protected TextBox txtPhone;
        protected TextBox txtPost;
        protected TextBox txtResident;
        protected TextBox txtRname1;
        protected TextBox txtRname2;
        protected TextBox txtRname3;
        protected TextBox txtRnum;
        protected TextBox txtRnum1;
        protected TextBox txtRnum2;
        protected TextBox txtRnum3;
        protected TextBox txtRship1;
        protected TextBox txtRship2;
        protected TextBox txtRship3;
        protected TextBox txtStreet;
        protected TextBox txtTel;
        protected TextBox txtTitle;
        protected TextBox txtYear;
        protected TextBox txtYeard;
        protected TextBox txtYy1;
        public string txYear = "";
        public string txYeard = "";
        public string txYy1 = "";

        private void BindState()
        {
            this.ddlState.Items.Add("ACT");
            this.ddlState.Items.Add("QLD");
            this.ddlState.Items.Add("NSW");
            this.ddlState.Items.Add("NT");
            this.ddlState.Items.Add("SA");
            this.ddlState.Items.Add("TAS");
            this.ddlState.Items.Add("VIC");
            this.ddlState.Items.Add("WA");
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            int num = 0;
            if (this.ViewState["IsEmployed"] != null)
            {
                try
                {
                    num = Convert.ToInt32(this.ViewState["IsEmployed"]);
                }
                catch
                {
                }
            }
            DateTime localNow = SafeDateTime.LocalNow;
            if (this.ViewState["RegTime"] != null)
            {
                try
                {
                    localNow = Convert.ToDateTime(this.ViewState["RegTime"]);
                }
                catch
                {
                }
            }
            bool flag = this.CalcDate();
            this.ViewState["CalcResult"] = "false";
            if (flag && this.CalcLoan())
            {
                this.ViewState["CalcResult"] = "true";
            }
        }

        private bool CalcDate()
        {
            DateTime timeRecentlySalaryDate = new DateTime(Convert.ToInt32(this.txtYy1.Text), Convert.ToInt32(this.txtMm1.Text), Convert.ToInt32(this.txtDd1.Text));
            string errorString = string.Empty;
            DateTime[] payDates = new DateTime[9];
            bool flag = PayDaySchedule.CalculatePayDate(this.Page, timeRecentlySalaryDate, this.SelectedRepaymentCycleType, SafeDateTime.LocalNow, ref payDates, out errorString);
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

        private bool CalcLoan()
        {
            float numLoanAmount = Convert.ToSingle(this.txtLoan.Value);
            float numIncomeOrBenefit = Convert.ToSingle(this.txtIncome.Text);
            DateTime salaryDate = new DateTime(Convert.ToInt32(this.txtYy1.Text), Convert.ToInt32(this.txtMm1.Text), Convert.ToInt32(this.txtDd1.Text));
            int numInstallmentCount = PayDaySchedule.CalculateInstallmentCount(this.SelectedRepaymentCycleType, salaryDate, SafeDateTime.LocalNow);
            string errorString = string.Empty;
            double payAmountPerTime = 0.0;
            bool flag = PayDaySchedule.CalculatePayLoan(this.Page, numIncomeOrBenefit, numLoanAmount, numInstallmentCount, false, ref payAmountPerTime, out errorString);
            if (flag)
            {
                this.payAmountPerTime4Schedule = payAmountPerTime;
                this.Session["numInstallmentCount4Schedule"] = numInstallmentCount;
                this.Session["payAmountPerTime4Schedule"] = payAmountPerTime;
                return flag;
            }
            base.Response.Write(errorString);
            return flag;
        }

        private void InitializeComponent()
        {
            this.btnCalculate.Click += new EventHandler(this.btnCalculate_Click);
            this.SaveButton.ServerClick += new EventHandler(this.SaveButton_ServerClick);
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
                this.BindState();
                int num = Convert.ToInt32(base.Request["id"]);
                this.Hidden1.Value = num.ToString();
                HuiyuanBN nbn = new HuiyuanBN(this.Page);
                nbn.QuerySid(num.ToString());
                DataTable list = nbn.GetList();
                if (list.Rows.Count > 0)
                {
                    DataRow row = list.Rows[0];
                    if (row != null)
                    {
                        this.txtTitle.Text = row["Param2"].ToString();
                        this.txtFname.Text = row["Fname"].ToString();
                        this.txtLname.Text = row["Lname"].ToString();
                        this.txtMname.Text = row["Mname"].ToString();
                        this.txtDate.Text = Convert.ToDateTime(row["DBirth"]).ToString("dd/MM/yyyy");
                        this.txtEmail.Text = row["Email"].ToString();
                        this.txtIssue.Text = list.Rows[0]["Issued"].ToString();
                        this.txtDriver.Text = list.Rows[0]["DNumber"].ToString();
                        this.txtResident.Text = list.Rows[0]["RAddress"].ToString();
                        this.txtStreet.Text = list.Rows[0]["SAddress"].ToString();
                        this.txtCity.Text = list.Rows[0]["City"].ToString();
                        ListItem item = new ListItem(list.Rows[0]["State"].ToString());
                        if (this.ddlState.Items.Contains(item))
                        {
                            this.ddlState.SelectedValue = item.Value;
                        }
                        this.txtPost.Text = list.Rows[0]["Postcode"].ToString();
                        this.txtYeard.Text = list.Rows[0]["TYears"].ToString();
                        this.txtMonthd.Text = list.Rows[0]["TMonths"].ToString();
                        this.txtTel.Text = list.Rows[0]["HTel"].ToString();
                        this.txtMobile.Text = list.Rows[0]["Mobile"].ToString();
                        this.txtFax.Text = list.Rows[0]["Param1"].ToString();
                    }
                }
                EmployedBN dbn = new EmployedBN(this.Page);
                dbn.QueryhuiSid(this.Hidden1.Value);
                dbn.Order = "id";
                DataTable table2 = dbn.GetList();
                if (table2.Rows.Count > 0)
                {
                    this.ViewState["Employed.ID"] = table2.Rows[0]["id"].ToString();
                    this.txtEmployer.Text = table2.Rows[0]["Employer"].ToString();
                    this.txtAddress.Text = table2.Rows[0]["EAddress"].ToString();
                    this.txtPhone.Text = table2.Rows[0]["EPhone"].ToString();
                    this.txtYear.Text = table2.Rows[0]["TYears"].ToString();
                    this.txtMonth.Text = table2.Rows[0]["TMonths"].ToString();
                    this.txtIncome.Text = Convert.ToSingle(table2.Rows[0]["MIncome"]).ToString("0.00");
                    this.IsEmployed = table2.Rows[0]["IsEmployed"].ToString();
                    this.txtBranch.Text = table2.Rows[0]["Branch"].ToString();
                    this.txtBankName.Text = table2.Rows[0]["BankName"].ToString();
                    this.txtAName.Text = table2.Rows[0]["AName"].ToString();
                    this.txtBsb.Text = table2.Rows[0]["Bsb"].ToString();
                    this.txtANumber.Text = table2.Rows[0]["ANumber"].ToString();
                    this.txtMContact.Text = table2.Rows[0]["MContact"].ToString();
                    this.txtRname1.Text = table2.Rows[0]["Rname1"].ToString();
                    this.txtRname2.Text = table2.Rows[0]["Rname2"].ToString();
                    this.txtRname3.Text = table2.Rows[0]["Rname3"].ToString();
                    this.txtRship1.Text = table2.Rows[0]["Rship1"].ToString();
                    this.txtRship2.Text = table2.Rows[0]["Rship2"].ToString();
                    this.txtRship3.Text = table2.Rows[0]["Rship3"].ToString();
                    this.txtRnum1.Text = table2.Rows[0]["Rnum1"].ToString();
                    this.txtRnum2.Text = table2.Rows[0]["Rnum2"].ToString();
                    this.txtRnum3.Text = table2.Rows[0]["Rnum3"].ToString();
                    this.txtJob.Text = table2.Rows[0]["Param5"].ToString();
                    int num2 = table2.Rows.Count - 1;
                    this.ViewState["Employed.ID.ModifyLoan"] = table2.Rows[num2]["id"].ToString();
                    this.txtLoan.Value = Convert.ToString(table2.Rows[num2]["Loan"]);
                    DataRow row2 = null;
                    if ((table2.Rows[num2]["Wpaid"] == DBNull.Value) || (table2.Rows[num2]["Wpaid"].ToString() == string.Empty))
                    {
                        row2 = table2.Rows[0];
                    }
                    else
                    {
                        row2 = table2.Rows[num2];
                    }
                    string text = row2["Wpaid"].ToString();
                    ListItem item2 = new ListItem(text, text);
                    if (this.PerRadioButtonList1.Items.Contains(item2))
                    {
                        this.PerRadioButtonList1.SelectedValue = item2.Value;
                    }
                    this.txtMm1.Text = row2["NDayMM"].ToString();
                    this.txtDd1.Text = row2["NDayDD"].ToString();
                    this.txtYy1.Text = row2["NDayYY"].ToString();
                    this.ViewState["RegTime"] = row2["Rtime"].ToString();
                    this.txtLoanPurpose.Text = row2["LoanPurpose"].ToString();
                    this.txtHousePaymentValue.Value = row2["HousePaymentValue"].ToString();
                    this.txtOtherLenderValue.Value = row2["OtherLenderValue"].ToString();
                    this.ddlHousePaymentCircle.SelectedValue = EnumsOP.GetHousePaymentCircleLiteral(row2["HousePaymentCircle"]);
                    this.ddlOtherLenderCircle.SelectedValue = EnumsOP.GetOtherLenderCircleLiteral(row2["OtherLenderCircle"]);
                    try
                    {
                        if (row2["OtherSamllCreditHas"] != null)
                        {
                            this.rblHasOtherSamllCredit.SelectedValue = row2["OtherSamllCreditHas"].ToString();
                        }
                        if (row2["OtherSmallCreditCount"] != null)
                        {
                            this.ddlSmalCreditCount.SelectedValue = row2["OtherSmallCreditCount"].ToString();
                        }
                    }
                    catch
                    {
                    }
                    try
                    {
                        if (row2["IsGrossIncomeChange"] != null)
                        {
                            this.rblIsGrossIncomeChange.SelectedValue = row2["IsGrossIncomeChange"].ToString();
                        }
                        if (row2["IsPayOtherCredit"] != null)
                        {
                            this.rblIsPayOtherCredit.SelectedValue = row2["IsPayOtherCredit"].ToString();
                        }
                        if (row2["GrossIncomeChangeValue"] != null)
                        {
                            this.tbxGrossIncomeChangeValue.Text = row2["GrossIncomeChangeValue"].ToString();
                        }
                        if (row2["PayOtherCreditValue"] != null)
                        {
                            this.tbxPayOtherCreditValue.Text = row2["PayOtherCreditValue"].ToString();
                        }
                    }
                    catch
                    {
                    }
                    if (this.IsEmployed.Equals("1"))
                    {
                        this.tip1 = "Your Occupation:";
                        this.tip2 = "Employer:";
                        this.tip3 = "Employer’s Address:";
                        this.tip4 = "Employer Phone:";
                        this.tip5 = "Time Employed: ";
                        this.tip6 = "Net Income: ";
                        this.tip7 = "JobTitle: ";
                        this.ViewState["userLoanType"] = "0";
                    }
                    else
                    {
                        this.tip1 = "";
                        this.tip2 = "Type of benefit:";
                        this.tip3 = "Centreline Office:";
                        this.tip4 = "Contact Name:";
                        this.tip5 = "How long on this benefit: ";
                        this.tip6 = "Benefit:";
                        this.ViewState["userLoanType"] = "1";
                    }
                }
            }
        }

        private void SaveButton_ServerClick(object sender, EventArgs e)
        {
            if ((this.ViewState["CalcResult"] != null) && !Convert.ToBoolean(this.ViewState["CalcResult"]))
            {
                base.Response.Write("<script>alert(\"There is a mistake in Calc step. Please modify and continue.\")</script>");
            }
            else
            {
                int id = Convert.ToInt32(this.Hidden1.Value);
                HuiyuanBN nbn = new HuiyuanBN(this.Page);
                EmployedBN dbn = new EmployedBN(this.Page);
                HuiyuanDT dt = new HuiyuanDT();
                dt = nbn.Get(id);
                EmployedDT ddt = new EmployedDT();
                EmployedDT ddt2 = new EmployedDT();
                dt.City = this.txtCity.Text;
                try
                {
                    string[] strArray = this.txtDate.Text.Split(new char[] { '-', '/' });
                    int year = Convert.ToInt32(strArray[2]);
                    int month = Convert.ToInt32(strArray[1]);
                    int day = Convert.ToInt32(strArray[0]);
                    dt.DBirth = new DateTime(year, month, day);
                }
                catch
                {
                }
                dt.DNumber = this.txtDriver.Text;
                dt.Email = this.txtEmail.Text;
                dt.Fname = this.txtFname.Text;
                dt.HTel = this.txtTel.Text;
                dt.Issued = this.txtIssue.Text;
                dt.Lname = this.txtLname.Text;
                dt.Mname = this.txtMname.Text;
                dt.Mobile = this.txtMobile.Text;
                dt.Postcode = this.txtPost.Text;
                dt.RAddress = this.txtResident.Text;
                dt.SAddress = this.txtStreet.Text;
                dt.State = this.ddlState.SelectedValue;
                try
                {
                    dt.TMonths = Convert.ToInt32(this.txtMonthd.Text);
                    dt.TYears = Convert.ToInt32(this.txtYeard.Text);
                }
                catch
                {
                }
                dt.Param1 = this.txtFax.Text;
                dt.Param2 = this.txtTitle.Text;
                nbn.Edit(dt);
                if (this.ViewState["Employed.ID"] != null)
                {
                    ddt = dbn.Get(Convert.ToInt32(this.ViewState["Employed.ID"]));
                }
                else
                {
                    ddt = new EmployedDT();
                }
                if (this.ViewState["Employed.ID.ModifyLoan"] != null)
                {
                    ddt2 = dbn.Get(Convert.ToInt32(this.ViewState["Employed.ID.ModifyLoan"]));
                }
                else
                {
                    ddt2 = new EmployedDT();
                }
                if (ddt.id == ddt2.id)
                {
                    ddt2 = ddt;
                }
                ddt.AName = this.txtAName.Text;
                ddt.ANumber = this.txtANumber.Text;
                ddt.BankName = this.txtBankName.Text;
                ddt.Branch = this.txtBranch.Text;
                ddt.Bsb = this.txtBsb.Text;
                ddt.EAddress = this.txtAddress.Text;
                ddt.Employer = this.txtEmployer.Text;
                ddt.EPhone = this.txtPhone.Text;
                ddt.MContact = this.txtMContact.Text;
                try
                {
                    ddt.MIncome = Convert.ToSingle(this.txtIncome.Text);
                }
                catch
                {
                }
                ddt.Param5 = this.txtJob.Text;
                ddt.Rname1 = this.txtRname1.Text;
                ddt.Rname2 = this.txtRname2.Text;
                ddt.Rname3 = this.txtRname3.Text;
                ddt.Rnum1 = this.txtRnum1.Text;
                ddt.Rnum2 = this.txtRnum2.Text;
                ddt.Rnum3 = this.txtRnum3.Text;
                ddt.Rship1 = this.txtRship1.Text;
                ddt.Rship2 = this.txtRship2.Text;
                ddt.Rship3 = this.txtRship3.Text;
                try
                {
                    ddt.TMonths = Convert.ToInt32(this.txtMonth.Text);
                    ddt.TYears = Convert.ToInt32(this.txtYear.Text);
                }
                catch
                {
                }
                if ((this.ViewState["CalcResult"] != null) && Convert.ToBoolean(this.ViewState["CalcResult"]))
                {
                    try
                    {
                        ddt2.NDayDD = Convert.ToInt32(this.txtDd1.Text);
                        ddt2.NDayMM = Convert.ToInt32(this.txtMm1.Text);
                        ddt2.NDayYY = Convert.ToInt32(this.txtYy1.Text);
                    }
                    catch
                    {
                    }
                    ddt2.Wpaid = this.PerRadioButtonList1.SelectedValue;
                    int num5 = Convert.ToInt32(this.Session["numInstallmentCount4Schedule"]);
                    ddt2.NInstallment = num5;
                    try
                    {
                        ddt2.Loan = Convert.ToSingle(this.txtLoan.Value);
                    }
                    catch
                    {
                    }
                    ddt2.Param1 = Convert.ToSingle(this.Session["payAmountPerTime4Schedule"]) * ddt2.NInstallment;
                    DataTable list = new SystemInfoBN(this.Page).GetList();
                    if (list.Rows.Count > 0)
                    {
                        ddt2.Param2 = Convert.ToSingle(list.Rows[0]["poundage"].ToString()) * num5;
                    }
                    ddt2.RTime = SafeDateTime.LocalNow;
                }
                if (this.ViewState["Employed.ID"] != null)
                {
                    dbn.Edit(ddt);
                }
                if (this.ViewState["Employed.ID.ModifyLoan"] != null)
                {
                    try
                    {
                        ddt2.OtherSamllCreditHas = int.Parse(this.rblHasOtherSamllCredit.SelectedValue);
                        ddt2.OtherSmallCreditCount = int.Parse(this.ddlSmalCreditCount.SelectedValue);
                    }
                    catch
                    {
                    }
                    ddt2.LoanPurpose = this.txtLoanPurpose.Text;
                    ddt2.HousePaymentCircle = EnumsOP.GetHousePaymentCircleByLiteral(this.ddlHousePaymentCircle.SelectedValue);
                    try
                    {
                        ddt2.HousePaymentValue = Convert.ToSingle(this.txtHousePaymentValue.Value);
                    }
                    catch
                    {
                    }
                    ddt2.OtherLenderCircle = EnumsOP.GetOtherLenderCircleByLiteral(this.ddlOtherLenderCircle.SelectedValue);
                    try
                    {
                        ddt2.OtherLenderValue = Convert.ToSingle(this.txtOtherLenderValue.Value);
                    }
                    catch
                    {
                    }
                    try
                    {
                        ddt2.IsGrossIncomeChange = int.Parse(this.rblIsGrossIncomeChange.SelectedValue);
                        ddt2.IsPayOtherCredit = int.Parse(this.rblIsPayOtherCredit.SelectedValue);
                        ddt2.GrossIncomeChangeValue = this.tbxGrossIncomeChangeValue.Text;
                        ddt2.PayOtherCreditValue = this.tbxPayOtherCreditValue.Text;
                    }
                    catch
                    {
                    }
                    dbn.Edit(ddt2);
                }
                if ((this.ViewState["CalcResult"] != null) && Convert.ToBoolean(this.ViewState["CalcResult"]))
                {
                    ScheduleBN ebn = new ScheduleBN(this.Page);
                    if (this.ViewState["Employed.ID.ModifyLoan"] != null)
                    {
                        ebn.DelByEmployedID(Convert.ToInt32(this.ViewState["Employed.ID.ModifyLoan"]));
                    }
                    if (this.ViewState["Employed.ID.ModifyLoan"] != null)
                    {
                        int num6 = Convert.ToInt32(this.ViewState["Employed.ID.ModifyLoan"]);
                        ScheduleDT edt = null;
                        double num7 = Convert.ToDouble(this.Session["payAmountPerTime4Schedule"]);
                        DateTime[] timeArray = (DateTime[]) this.Session["payDates4Schedule"];
                        int num8 = Convert.ToInt32(this.Session["numInstallmentCount4Schedule"]);
                        for (int i = 0; i < num8; i++)
                        {
                            edt = new ScheduleDT();
                            edt.Datedue = timeArray[i];
                            edt.Repaydue = num7;
                            edt.huiSid = id;
                            edt.Numberment = 1;
                            edt.Param1 = num6.ToString();
                            edt.Param2 = "0";
                            edt.Balance = num7 * (i + 1);
                            edt.RepayTime = Convert.ToDateTime("2000-1-1");
                            edt.OperateTime = Convert.ToDateTime("2000-1-1");
                            ebn.Add(edt);
                        }
                    }
                }
                base.Response.Write("<script>alert('Success！');window.location='MemberList.aspx';</script>");
            }
        }

        private PaidPeriodTypes SelectedRepaymentCycleType
        {
            get
            {
                PaidPeriodTypes weekly = PaidPeriodTypes.Weekly;
                RadioButtonList list = this.PerRadioButtonList1;
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
        }
    }
}

