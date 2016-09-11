using YingNet.WeiXing.Business.CommonLogic;

namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;
	using YingNet.WeiXing.STRUCTURE;
	using YingNet.WeiXing.Business.CommonLogic;
	using YingNet.WeiXing.WebApp.Include;
	using YingNet.Common.Utils;
	

    public class step3 : Page
    {
        protected Button Button1;
        protected TextBox d1F;
        protected TextBox d2F;
        protected TextBox d3F;
        protected DropDownList DropDownList1;
        protected HtmlInputHidden Hidden1;
        protected LinkButton Linkbutton3;
        protected Panel Panel1;
        protected Panel Panel2;
        protected Panel Panel3;
        protected Panel Panel4;
        protected Panel Panel5;
        protected RadioButtonList RadioButtonList1;
        protected RadioButtonList RadioButtonList2;
        protected RadioButtonList RadioButtonList3;
        protected RadioButtonList RadioButtonList4;
        protected TextBox s1;
        protected TextBox s2;
        protected TextBox s3;
        protected HtmlInputText selReShip1;
        protected HtmlInputText selReShip2;
        protected HtmlInputText selReShip3;
        protected HtmlInputButton Submit1;
        protected HtmlTextArea TEXTAREA1;
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
        protected HtmlInputText txReName1;
        protected HtmlInputText txReName2;
        protected HtmlInputText txReName3;
        protected HtmlInputText txReNum1;
        protected HtmlInputText txReNum2;
        protected HtmlInputText txReNum3;
        protected HtmlInputText txType;
        protected HtmlSelect txYear;
        protected HtmlSelect txYear2;
        protected HtmlInputText txYy1;
        protected HtmlInputText txYy4;
        protected HtmlInputText txYy5;
		protected System.Web.UI.WebControls.Label labAnnualRate;
        protected HtmlInputText txYy6;
		protected System.Web.UI.WebControls.TextBox txtLoanPurpose;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHousePaymentValue;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOtherLenderValue;
		protected HtmlTableRow annualRateRow;
		protected CircleDropDownList ddlHousePaymentCircle;
		protected CircleDropDownList ddlOtherLenderCircle;

        private void Button1_Click(object sender, EventArgs e)
        {
            this.d1F.Text = this.d2F.Text = this.d3F.Text = this.s1.Text = this.s2.Text = this.s3.Text = "";
            this.CalDateDue();
            this.CalLoan();
			this.DisplayAnnualRate();
        }

		private void DisplayAnnualRate()
		{
			//DropDownList1表示用户选择的周期数
			int numInstallmentCount = Convert.ToInt32(this.DropDownList1.SelectedValue);
			PaidPeriodTypes paidPeriodType= GetPaidPeridType();
			string rateDisplay= AnnualPercentageRate.GetAnnualPercentageRatePercent(paidPeriodType,numInstallmentCount);
			
			this.labAnnualRate.Text=rateDisplay;//"486.89%";
			
			/* //暂时不显示年利率部分
			this.annualRateRow.Attributes["style"]="Display:block";
			this.annualRateRow.Visible= true;
			*/
		}

		private PaidPeriodTypes GetPaidPeridType()
		{
			PaidPeriodTypes result= PaidPeriodTypes.Weekly;
			RadioButtonList radio= this.RadioButtonList2;
			if(this.RadioButtonList1.SelectedIndex==0)
			{
				radio= this.RadioButtonList2;
				
			}
			else
			{
				radio= this.RadioButtonList3;
			}
			
			switch(radio.SelectedValue.ToLower())
			{
				case "weekly":
					result= PaidPeriodTypes.Weekly;
					break;
				case "f'nightly":
					result= PaidPeriodTypes.Fnightly;
					break;
				case "monthly":
					result= PaidPeriodTypes.Monthly;
					break;
			}

			return result;
		}

		private PaidPeriodTypes GetSelectedRepaymentCycleType(int userLoanType)
		{
			
			PaidPeriodTypes result= PaidPeriodTypes.Weekly;

			RadioButtonList radio= null;
			if(userLoanType==0)
			{
				//有工作人士选择的 按周期的还款方式
				radio=this.RadioButtonList2;
			}
			else
			{
				//受支助人士选择的 按周期的还款方式
				radio=this.RadioButtonList3;
			}

			
			switch(radio.SelectedValue.ToLower())
			{
				case "weekly":
					result= PaidPeriodTypes.Weekly;
					break;
				case "f'nightly":
					result= PaidPeriodTypes.Fnightly;
					break;
				case "monthly":
					result= PaidPeriodTypes.Monthly;
					break;
			}

			return result;
			
		}

        public void CalDateDue()
        {
            TimeSpan span3;
            DateTime timeFirstPay = new DateTime();
            DateTime timeSecondPay = new DateTime();
            DateTime timeThirdPay = new DateTime();
            DateTime timeAtOncePay = new DateTime();
            DateTime timeRecentlySalaryDate = new DateTime();
            
        	//RadioButtonList1表示工作/受支助
        	if (this.RadioButtonList1.SelectedIndex == 0)
            {
                timeRecentlySalaryDate = new DateTime(Convert.ToInt32(this.txYy1.Value), Convert.ToInt32(this.txMm1.Value), Convert.ToInt32(this.txDd1.Value), 0x17, 0x3b, 0x3b);
            }
            else
            {
                timeRecentlySalaryDate = new DateTime(Convert.ToInt32(this.txYy4.Value), Convert.ToInt32(this.txMm4.Value), Convert.ToInt32(this.txDd4.Value), 0x17, 0x3b, 0x3b);
            }
        	
        	//~~以下为修改内容~~~
			//DropDownList1表示用户选择的周期数
			int numInstallmentCount = Convert.ToInt32(this.DropDownList1.SelectedValue);
        	int userLoanType = this.RadioButtonList1.SelectedIndex;
        	
       	
        	string errorString = string.Empty;
        	
        	bool isSuccessful= PayDaySchedule.CalculatePayDate(this.Page, numInstallmentCount, timeRecentlySalaryDate, userLoanType,
        	                                GetSelectedRepaymentCycleType(userLoanType),ref timeFirstPay,ref timeSecondPay,ref timeThirdPay,
        	                                ref timeAtOncePay, SafeDateTime.LocalNow, out errorString);
        	
			//计算出的最后一个还款日期
			DateTime lastDueDate= DateTime.MinValue;

			if(isSuccessful == true)
			{
				string str = "";
				string str2 = "";
				string str3 = "";
				string str4 = "";
				str = timeFirstPay.ToShortDateString();
				this.d1F.Text = timeFirstPay.Day.ToString() + "/" + timeFirstPay.Month.ToString() + "/" + timeFirstPay.Year.ToString();
				lastDueDate= timeFirstPay;

				switch (numInstallmentCount)
				{
					case 2:
						str2 = timeSecondPay.ToShortDateString();
						this.d2F.Text = timeSecondPay.Day.ToString() + "/" + timeSecondPay.Month.ToString() + "/" + timeSecondPay.Year.ToString();
						lastDueDate= timeSecondPay;
						break;

					case 3:
						str2 = timeSecondPay.ToShortDateString();
						str3 = timeThirdPay.ToShortDateString();
						this.d2F.Text = timeSecondPay.Day.ToString() + "/" + timeSecondPay.Month.ToString() + "/" + timeSecondPay.Year.ToString();
						this.d3F.Text = timeThirdPay.Day.ToString() + "/" + timeThirdPay.Month.ToString() + "/" + timeThirdPay.Year.ToString();
						lastDueDate= timeThirdPay;
						break;
					case 4:
						str4 = timeAtOncePay.ToShortDateString();
						this.d1F.Text = timeAtOncePay.Day.ToString() + "/" + timeAtOncePay.Month.ToString() + "/" + timeAtOncePay.Year.ToString();
						lastDueDate= timeAtOncePay;
						break;
				}

				this.Session["LastDueDate"]= lastDueDate;
        	
				/*
				this.Session["Datedue1"] = str;
				this.Session["Datedue2"] = str2;
				this.Session["Datedue3"] = str3;
				this.Session["Datedue4"] = str4;
				*/
			}
			else
			{
				this.Response.Write(errorString);
			}
        }

        public void CalLoan()
        {
            float numIncomeOrBenefit;
        	int userLoanType = 0;
            float numLoanAmount = Convert.ToSingle(this.txLoan.Value);

			
			
        	//DropDownList1表示用户选择的周期数
			int numInstallmentCount = Convert.ToInt32(this.DropDownList1.SelectedValue);
            if (this.RadioButtonList1.SelectedIndex == 0)
            {
                numIncomeOrBenefit = Convert.ToSingle(this.txIncome.Value);
            	userLoanType = 0;
            }
            else
            {
                numIncomeOrBenefit = Convert.ToSingle(this.txBenefit.Value);
            	userLoanType = 1;
            }
            
            string errorString = string.Empty;
        	bool isSuccessful = PayDaySchedule.CalculatePayLoan(this.Page, userLoanType, numInstallmentCount, numIncomeOrBenefit,
        		                                numLoanAmount, out errorString);
        	if(isSuccessful==true)
        	{
				switch (numInstallmentCount)
				{
					case 1:
						this.s1.Text =Convert.ToString(this.Session["Repaydue1"]);
						break;
					case 2:
						this.s1.Text= Convert.ToString(this.Session["Repaydue1"]);
						this.s2.Text= Convert.ToString(this.Session["Repaydue2"]);
						break;
					case 3:
						this.s1.Text= Convert.ToString(this.Session["Repaydue1"]);
						this.s2.Text= Convert.ToString(this.Session["Repaydue2"]);
						this.s3.Text= Convert.ToString(this.Session["Repaydue3"]);
						break;
					case 4:
						if (this.Session["XFirst2"] != null)
						{
							this.s1.Text= Convert.ToString(this.Session["Repaydue4"]);
						}
						else
						{
							this.s1.Text = "";
						}
						break;
				}
        	}
        	else
        	{
        		this.Response.Write(errorString);
        	}
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
            dt.Rname1 = this.txReName1.Value;
            dt.Rship1 = this.selReShip1.Value;
            dt.Rnum1 = this.txReNum1.Value;
            dt.Rname2 = this.txReName2.Value;
            dt.Rship2 = this.selReShip2.Value;
            dt.Rnum2 = this.txReNum2.Value;
            dt.Rname3 = this.txReName3.Value;
            dt.Rship3 = this.selReShip3.Value;
            dt.Rnum3 = this.txReNum3.Value;
            dt.Param4 = this.txFullname.Text;
            dt.IsValid = 3;
            dt.Loan = Convert.ToSingle(this.txLoan.Value);
            dt.NInstallment = Convert.ToInt32(this.DropDownList1.SelectedValue);
            dt.RTime = SafeDateTime.LocalNow;
            
			dt.LoanPurpose= this.txtLoanPurpose.Text;
			dt.HousePaymentCircle= EnumsOP.GetHousePaymentCircleByLiteral(this.ddlHousePaymentCircle.SelectedValue);
			dt.HousePaymentValue= Convert.ToSingle(this.txtHousePaymentValue.Value);
			dt.OtherLenderCircle= EnumsOP.GetOtherLenderCircleByLiteral(this.ddlOtherLenderCircle.SelectedValue);
			dt.OtherLenderValue= Convert.ToSingle(this.txtOtherLenderValue.Value);
			
			DataTable list = new SystemInfoBN(this.Page).GetList();
            if (list.Rows.Count <= 0)
            {
                goto Label_0485;
            }
            dt.Interest = Convert.ToSingle(list.Rows[0]["interest"].ToString());
            if (this.RadioButtonList1.SelectedIndex == 0)
            {
                switch (this.RadioButtonList2.SelectedIndex)
                {
                    case 0:
                        dt.Frequency = 7.0;
                        goto Label_0463;

                    case 1:
                        dt.Frequency = 14.0;
                        goto Label_0463;

                    case 2:
                        dt.Frequency = Convert.ToSingle(list.Rows[0]["frequency"].ToString());
                        goto Label_0463;
                }
            }
            else
            {
                switch (this.RadioButtonList3.SelectedIndex)
                {
                    case 0:
                        dt.Frequency = 7.0;
                        goto Label_0463;

                    case 1:
                        dt.Frequency = 14.0;
                        goto Label_0463;

                    case 2:
                        dt.Frequency = Convert.ToSingle(list.Rows[0]["frequency"].ToString());
                        goto Label_0463;
                }
            }
        Label_0463:
            num = Convert.ToSingle(list.Rows[0]["poundage"].ToString());
        Label_0485:
            if (this.DropDownList1.SelectedValue.Equals("4"))
            {
                dt.XDay = Convert.ToInt32(this.Session["XFirst2"]);
            }
            else
            {
                dt.XDay = Convert.ToInt32(this.Session["XFirst"]);
            }
            dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
            if (this.s1.Text != "")
            {
                dt.Param1 = Convert.ToSingle(this.s1.Text);
            }
            if ((this.s1.Text != "") && (this.s2.Text != ""))
            {
                dt.Param1 = Convert.ToSingle(this.s1.Text) + Convert.ToSingle(this.s2.Text);
            }
            if (((this.s1.Text != "") && (this.s2.Text != "")) && (this.s3.Text != ""))
            {
                dt.Param1 = (Convert.ToSingle(this.s1.Text) + Convert.ToSingle(this.s2.Text)) + Convert.ToSingle(this.s3.Text);
            }
            dt.Param2 = num * dt.NInstallment;
            dt.Param3 = 1;
            this.Hidden1.Value = dbn.Add2(dt).ToString();
        }

        public void getSchedule()
        {
            ScheduleBN ebn = new ScheduleBN(this.Page);
            ScheduleDT dt = null;
        	//this.DropDownList1表示分期还款的方式(分1,2,3期等)
        	switch (Convert.ToInt32(this.DropDownList1.SelectedValue))
            {
                case 1:
                    dt = new ScheduleDT();
                    dt.Datedue = Convert.ToDateTime(this.Session["Datedue1"]);
                    dt.Repaydue = Convert.ToSingle(this.Session["Repaydue1"]);
                    dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
                    dt.Numberment = 1;
                    dt.Param1 = this.Hidden1.Value;
                    dt.Param2 = "0";
                    dt.Balance = Convert.ToSingle(this.Session["Repaydue1"]);
                    dt.RepayTime = Convert.ToDateTime("2000-1-1");
                    dt.OperateTime = Convert.ToDateTime("2000-1-1");
                    ebn.Add(dt);
                    break;

                case 2:
                    dt = new ScheduleDT();
                    dt.Datedue = Convert.ToDateTime(this.Session["Datedue1"]);
                    dt.Repaydue = Convert.ToSingle(this.Session["Repaydue1"]);
                    dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
                    dt.Numberment = 1;
                    dt.Param1 = this.Hidden1.Value;
                    dt.Param2 = "0";
                    dt.Balance = Convert.ToSingle(this.Session["Repaydue1"]);
                    dt.RepayTime = Convert.ToDateTime("2000-1-1");
                    dt.OperateTime = Convert.ToDateTime("2000-1-1");
                    ebn.Add(dt);
                    dt = new ScheduleDT();
                    dt.Datedue = Convert.ToDateTime(this.Session["Datedue2"]);
                    dt.Repaydue = Convert.ToSingle(this.Session["Repaydue2"]);
                    dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
                    dt.Numberment = 1;
                    dt.Param1 = this.Hidden1.Value;
                    dt.Param2 = "0";
                    dt.Balance = Convert.ToSingle(this.Session["Repaydue1"]) + Convert.ToSingle(this.Session["Repaydue2"]);
                    dt.RepayTime = Convert.ToDateTime("2000-1-1");
                    dt.OperateTime = Convert.ToDateTime("2000-1-1");
                    ebn.Add(dt);
                    break;

                case 3:
                    dt = new ScheduleDT();
                    dt.Datedue = Convert.ToDateTime(this.Session["Datedue1"]);
                    dt.Repaydue = Convert.ToSingle(this.Session["Repaydue1"]);
                    dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
                    dt.Numberment = 1;
                    dt.Param1 = this.Hidden1.Value;
                    dt.Param2 = "0";
                    dt.Balance = Convert.ToSingle(this.Session["Repaydue1"]);
                    dt.RepayTime = Convert.ToDateTime("2000-1-1");
                    dt.OperateTime = Convert.ToDateTime("2000-1-1");
                    ebn.Add(dt);
                    dt = new ScheduleDT();
                    dt.Datedue = Convert.ToDateTime(this.Session["Datedue2"]);
                    dt.Repaydue = Convert.ToSingle(this.Session["Repaydue2"]);
                    dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
                    dt.Numberment = 1;
                    dt.Param1 = this.Hidden1.Value;
                    dt.Param2 = "0";
                    dt.Balance = Convert.ToSingle(this.Session["Repaydue1"]) + Convert.ToSingle(this.Session["Repaydue2"]);
                    dt.RepayTime = Convert.ToDateTime("2000-1-1");
                    dt.OperateTime = Convert.ToDateTime("2000-1-1");
                    ebn.Add(dt);
                    dt = new ScheduleDT();
                    dt.Datedue = Convert.ToDateTime(this.Session["Datedue3"]);
                    dt.Repaydue = Convert.ToSingle(this.Session["Repaydue3"]);
                    dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
                    dt.Numberment = 1;
                    dt.Param1 = this.Hidden1.Value;
                    dt.Param2 = "0";
                    dt.Balance = (Convert.ToSingle(this.Session["Repaydue1"]) + Convert.ToSingle(this.Session["Repaydue2"])) + Convert.ToSingle(this.Session["Repaydue3"]);
                    dt.RepayTime = Convert.ToDateTime("2000-1-1");
                    dt.OperateTime = Convert.ToDateTime("2000-1-1");
                    ebn.Add(dt);
                    break;

                case 4:
                    dt = new ScheduleDT();
                    dt.Datedue = Convert.ToDateTime(this.Session["Datedue4"]);
                    dt.Repaydue = Convert.ToSingle(this.Session["Repaydue4"]);
                    dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
                    dt.Numberment = 1;
                    dt.Param1 = this.Hidden1.Value;
                    dt.Param2 = "0";
                    dt.Balance = Convert.ToSingle(this.Session["Repaydue4"]);
                    dt.RepayTime = Convert.ToDateTime("2000-1-1");
                    dt.OperateTime = Convert.ToDateTime("2000-1-1");
                    ebn.Add(dt);
                    break;
            }
        }

        private void InitializeComponent()
        {
			this.RadioButtonList1.SelectedIndexChanged += new System.EventHandler(this.RadioButtonList1_SelectedIndexChanged);
			this.Linkbutton3.Click += new System.EventHandler(this.Linkbutton3_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Submit1.ServerClick += new System.EventHandler(this.Submit1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

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

			if(this.IsPostBack==false)
			{
				this.annualRateRow.Visible= false;
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
            if ((this.d1F.Text == "") || (this.s1.Text == ""))
            {
                base.Response.Write("<script>alert(\"Please click 'Calculate' button for repayment schedule before you submit the application.\");</script>");
            }
            else if (this.txFullname.Text == "")
            {
                base.Response.Write("<script>alert('You need to sign by tying in your FULL name before submission.');</script>");
            }
            else if (this.Session["Repayduezs"].ToString() != this.txLoan.Value)
            {
                base.Response.Write("<script>alert(\"Please click 'Calculate' button for repayment schedule before you submit the application.\");</script>");
            }
            else
            {
                try
                {
                    this.Session["NumberLoanI"] = this.DropDownList1.SelectedValue;
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

