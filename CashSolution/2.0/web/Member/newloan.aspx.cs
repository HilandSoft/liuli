﻿namespace YingNet.WeiXing.WebApp.Member
{
	using System;
	using System.Data;
	using System.Web.UI.HtmlControls;
	using System.Web.UI.WebControls;
	using YingNet.WeiXing.Business;
	using YingNet.WeiXing.DB.Data;
	using YingNet.WeiXing.Business.CommonLogic;
	using YingNet.WeiXing.STRUCTURE;
	using YingNet.WeiXing.WebApp.Include;
	using YingNet.Common.Utils;

	public class newloan : generagepage
	{
		public string AName = "";
		public string ANumber = "";
		public string BankName = "";
		public string Branch = "";
		public string Bsb = "";
		protected Button Button1;
		protected HtmlInputButton Button2;
		protected CheckBox CheckBox1;
		public string CustomerNum = "";
		protected DropDownList DropDownList1;
		public string EmploymentInfo = "";
		protected HtmlInputHidden Hidden1;
		protected HtmlInputHidden Hidden2;
		protected HtmlInputHidden Hidden3;
		public string huiName = "";
		public string IsEmployed = "";
		protected LinkButton LinkButton1;
		protected LinkButton LinkButton2;
		protected LinkButton LinkButton3;
		public string MContact = "";
		protected HtmlInputText nPayDd;
		protected HtmlInputText nPayMm;
		protected HtmlInputText nPayYy;
		public string paid = "";
		protected Panel Panel1;
		protected Panel Panel2;
		protected Panel Panel3;
		protected RadioButtonList RadioButtonList1;
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
		public string tip1 = "";
		public string tip2 = "";
		public string tip3 = "";
		public string tip4 = "";
		public string tip5 = "";
		public string tip6 = "";
		public string txAddress = "";
		public string txCity = "";
		protected TextBox txd1;
		protected TextBox txd2;
		protected TextBox txd3;
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
		protected TextBox txs1;
		protected TextBox txs2;
		protected TextBox txs3;
		protected CheckBox cbUnderStoodTerm;
		public string txStreet = "";
		public string txTel = "";
		public string txYear = "";
		public string txYearM = "";
		protected System.Web.UI.WebControls.TextBox Textbox1;
		protected Literal litAmountOfCredit;
		protected Literal litChargeForCredit;
		protected Literal litTotalPayable;
		protected Literal litRepaymentInDays;
		protected Literal litAnnualPercentageRate;
		protected System.Web.UI.WebControls.TextBox txtLoanPurpose;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHousePaymentValue;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOtherLenderValue;
		public string txYy1 = "";
		protected CircleDropDownList ddlHousePaymentCircle;
		protected System.Web.UI.WebControls.LinkButton Linkbutton4;
		protected System.Web.UI.WebControls.Panel PanelWarning;
		protected CircleDropDownList ddlOtherLenderCircle;
		protected System.Web.UI.WebControls.DropDownList ddlSmalCreditCount;
		protected System.Web.UI.WebControls.RadioButtonList rblHasOtherSamllCredit;
    	

		private void Button1_Click(object sender, EventArgs e)
		{
			this.txd1.Text = this.txd2.Text = this.txd3.Text = this.txs1.Text = this.txs2.Text = this.txs3.Text = "";
			DateTime time = new DateTime(Convert.ToInt32(this.nPayYy.Value), Convert.ToInt32(this.nPayMm.Value), Convert.ToInt32(this.nPayDd.Value));
			if (time <= SafeDateTime.LocalNow)
			{
				base.Response.Write("<script>alert(\"Field 'Next Payday' under 'Member Loan Application' is not valid!\");</script>");
			}
			else
			{
				this.CalDateDue();
				this.CalLoan();
			}
		}

		private void Button2_ServerClick(object sender, EventArgs e)
		{
			if(this.cbUnderStoodTerm.Checked==false)
			{
				base.Response.Write("<script>alert(\"Have you read and understood Golden Bridge Cash Solution's Information Statement? \");</script>");
				return;
			}
        	
			if ((this.txd1.Text == "") || (this.txs1.Text == ""))
			{
				base.Response.Write("<script>alert(\"Please click 'Calculate' button for repayment schedule before you submit the application.\");</script>");
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

		public void CalDateDue()
		{
			DateTime time = new DateTime();
			DateTime time2 = new DateTime();
			DateTime time3 = new DateTime();
			DateTime time4 = new DateTime();
			DateTime time5 = new DateTime(Convert.ToInt32(this.nPayYy.Value), Convert.ToInt32(this.nPayMm.Value), Convert.ToInt32(this.nPayDd.Value), 0x17, 0x3b, 0x3b);
			int num = 0;
			int num2 = 0;
			int num3 = 0;
			int num4 = 0;
			float num5 = 0f;
			DataTable list = new SystemInfoBN(this.Page).GetList();
			if (list.Rows.Count > 0)
			{
				num = Convert.ToInt32(list.Rows[0]["shortday"]);
				num5 = Convert.ToSingle(list.Rows[0]["frequency"]);
				num2 = Convert.ToInt32(list.Rows[0]["datediffw"]);
				num3 = Convert.ToInt32(list.Rows[0]["datedifff"]);
				num4 = Convert.ToInt32(list.Rows[0]["datediffm"]);
			}
			int num6 = Convert.ToInt32(this.DropDownList1.SelectedValue);
			TimeSpan span = new TimeSpan(0x3e8L);
			TimeSpan span2 = (TimeSpan) (time5 - SafeDateTime.LocalNow);
			switch (this.RadioButtonList1.SelectedIndex)
			{
				case 0:
					if (span2.Days <= num2)
					{
						this.Session["frequency"] = 7;
						span = new TimeSpan(7, 0, 0, 0);
						time = time5 + span;
						time2 = time + span;
						time3 = time2 + span;
						break;
					}
					base.Response.Write("<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>");
					return;

				case 1:
					if (span2.Days <= num3)
					{
						this.Session["frequency"] = 14;
						span = new TimeSpan(14, 0, 0, 0);
						time = time5 + span;
						time2 = time + span;
						time3 = time2 + span;
						break;
					}
					base.Response.Write("<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>");
					return;

				case 2:
					if ((num6 > 3) || (span2.Days <= num4))
					{
						this.Session["frequency"] = num5;
						int year = time5.Year;
						int month = time5.Month;
						int day = time5.Day;
						int num10 = time5.Month;
						time = time5.AddMonths(1);
						time2 = time5.AddMonths(2);
						time3 = time5.AddMonths(3);
						break;
					}
					base.Response.Write("<script>alert(\"The number of days to your next payday has exceeded 15 days. Please choose 'Repay on next payday' repayment option.\");</script>");
					return;
			}
			TimeSpan span3 = (TimeSpan) (time - SafeDateTime.LocalNow);
			this.Session["XFirst"] = span3.Days;
			string str = "";
			string str2 = "";
			string str3 = "";
			string str4 = "";
			str = time.ToShortDateString();
			this.txd1.Text = time.Day.ToString() + "/" + time.Month.ToString() + "/" + time.Year.ToString();
			switch (num6)
			{
				case 2:
					str2 = time2.ToShortDateString();
					this.txd2.Text = time2.Day.ToString() + "/" + time2.Month.ToString() + "/" + time2.Year.ToString();
					break;

				case 3:
					str2 = time2.ToShortDateString();
					str3 = time3.ToShortDateString();
					this.txd2.Text = time2.Day.ToString() + "/" + time2.Month.ToString() + "/" + time2.Year.ToString();
					this.txd3.Text = time3.Day.ToString() + "/" + time3.Month.ToString() + "/" + time3.Year.ToString();
					break;
			}
			if (num6 == 4)
			{
				time4 = time5;
				TimeSpan span4 = (TimeSpan) (time4 - SafeDateTime.LocalNow);
				if (span4.Days < 3)
				{
					base.Response.Write("<script>alert(\"There's less than 3 days to your next payday. Please choose another repayment option.\")</script>");
					this.txd1.Text = "";
					this.Session["XFirst2"] = null;
				}
				else
				{
					str4 = time4.ToShortDateString();
					this.txd1.Text = time4.Day.ToString() + "/" + time4.Month.ToString() + "/" + time4.Year.ToString();
					this.Session["XFirst2"] = span4.Days;
				}
			}
			this.Session["Datedue1"] = str;
			this.Session["Datedue2"] = str2;
			this.Session["Datedue3"] = str3;
			this.Session["Datedue4"] = str4;
		}

		public void CalLoan()
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
			float num = 0f;
			float num2 = 0f;
			float num3 = 0f;
			float num4 = 0f;
			float num5 = 0f;
			float num6 = 0f;
			float num7 = 0f;
			float num8 = Convert.ToSingle(this.txLoan.Value);
			float num9 = Convert.ToSingle(str);
			int num10 = Convert.ToInt32(this.DropDownList1.SelectedValue);
			int num11 = 0;
			int num12 = 0;
			int num13 = Convert.ToInt32(list.Rows[0]["IsEmployed"]);
			DataTable table2 = new SystemInfoBN(this.Page).GetList();
			if (table2.Rows.Count > 0)
			{
				num = Convert.ToSingle(table2.Rows[0]["interest"].ToString());
				num2 = Convert.ToSingle(table2.Rows[0]["frequency"].ToString());
				num3 = Convert.ToSingle(table2.Rows[0]["percentage"].ToString());
				num4 = Convert.ToInt32(table2.Rows[0]["upperlimit"].ToString());
				num5 = Convert.ToInt32(table2.Rows[0]["upperlimit2"].ToString());
				num11 = Convert.ToInt32(table2.Rows[0]["IsPercent"].ToString());
				num7 = Convert.ToSingle(table2.Rows[0]["lowerlimit"].ToString());
				num6 = Convert.ToSingle(table2.Rows[0]["poundage"].ToString());
				num12 = Convert.ToInt32(table2.Rows[0]["term"].ToString());
				num7 = Convert.ToSingle(table2.Rows[0]["lowerlimit"].ToString());
			}
			if (num8 > num5)
			{
				base.Response.Write("<script>alert(\"Maximum amount you can borrow for your fist loan is $" + num5.ToString() + ". Please modify and continue.\")</script>");
			}
			else if (num8 > ((num9 * num3) * num10))
			{
				base.Response.Write("<script>alert(\"The loan amount you requested will exceed your maximum borrowing capability. Please modify and continue.\")</script>");
			}
			else
			{
				DateTime time = new DateTime();
				switch (num10)
				{
					case 1:
						if ((this.Session["Datedue1"] != null) && !(this.Session["Datedue1"].ToString() == ""))
						{
							time = Convert.ToDateTime(this.Session["Datedue1"]);
							break;
						}
						return;

					case 2:
						if ((this.Session["Datedue2"] != null) && !(this.Session["Datedue2"].ToString() == ""))
						{
							time = Convert.ToDateTime(this.Session["Datedue2"]);
							break;
						}
						return;

					case 3:
						if ((this.Session["Datedue3"] != null) && !(this.Session["Datedue3"].ToString() == ""))
						{
							time = Convert.ToDateTime(this.Session["Datedue3"]);
							break;
						}
						return;
					case 4:
						if ((this.Session["Datedue4"] != null) && !(this.Session["Datedue4"].ToString() == ""))
						{
							time = Convert.ToDateTime(this.Session["Datedue4"]);
							break;
						}
						return;
				}
				TimeSpan span = (TimeSpan) (time - SafeDateTime.LocalNow);
				if (span.Days > num12)
				{
					base.Response.Write("<script>alert(\"The term of the loan is maximum 62 days or three pay periods whichever is the sooner. Please re-enter installment number.\")</script>");
				}
				else if (num8 < num7)
				{
					base.Response.Write("<script>alert(\"Minimum loan amount is $50. Please modify and continue.\")</script>");
				}
				else if (num13.Equals(0) && (num8 > 150f))
				{
					base.Response.Write("<script>alert(\"Maximum amount you can borrow is $150. Please modify and continue.\")</script>");
				}
				else
				{
					int num14 = Convert.ToInt32(this.Session["XFirst"]);
					double num15 = 0.0;
					this.Session["Repayduezs"] = this.txLoan.Value;
					double tempSinglePay = 0;
					double totalPayable = 0;
					string annualPercentageRate = string.Empty;
					PaidPeriodTypes paidPeriodType= PaidPeriodTypes.Weekly;
					switch (num10)
					{
						case 1:
							num15 = (num8 + ((num8 * Convert.ToSingle(this.Session["frequency"])) * num)) + num6;
							totalPayable = num15;
							this.txs1.Text = num15.ToString("0.00");
							this.Session["Repaydue1"] = this.txs1.Text;
							//annualPercentageRate = "486.89%";
							break;

						case 2:
						{
							tempSinglePay = (((((num8 * Convert.ToSingle(this.Session["frequency"])) * num) * 2f) + num8) + num6) * 0.5; 
							totalPayable = tempSinglePay * 2;
							this.txs2.Text = tempSinglePay.ToString("0.00");
							this.txs1.Text = this.txs2.Text;
							this.Session["Repaydue1"] = this.txs1.Text;
							this.Session["Repaydue2"] = this.txs1.Text;
							/*	
							switch(this.RadioButtonList1.SelectedIndex)
								{
									case 0:
										annualPercentageRate = "700.44%";
										break;
									case 1:
										annualPercentageRate = "677.85%";
										break;
									case 2:
										annualPercentageRate = "486.89%";
										break;
								}
								*/
						}
							break;

						case 3:
						{
							tempSinglePay = ((double) (((((num8 * Convert.ToSingle(this.Session["frequency"])) * num) * 3f) + num8) + num6)) / 3.0;
							totalPayable = tempSinglePay*3;
							this.txs3.Text = tempSinglePay.ToString("0.00");
							this.txs1.Text = this.txs2.Text = this.txs3.Text;
							this.Session["Repaydue1"] = this.txs1.Text;
							this.Session["Repaydue2"] = this.txs1.Text;
							this.Session["Repaydue3"] = this.txs1.Text;
							/*	
							switch(this.RadioButtonList1.SelectedIndex)
								{
									case 0:
										annualPercentageRate = "700.44%";
										break;
									case 1:
										annualPercentageRate = "677.85%";
										break;
									case 2:
										annualPercentageRate = "486.89%";
										break;
								}
								*/
						}
							break;
					}


					switch(this.RadioButtonList1.SelectedIndex)
					{
						case 0:
							paidPeriodType= PaidPeriodTypes.Weekly;
							break;
						case 1:
							paidPeriodType= PaidPeriodTypes.Fnightly;
							break;
						case 2:
							paidPeriodType= PaidPeriodTypes.Monthly;
							break;
					}
					

					annualPercentageRate= AnnualPercentageRate.GetAnnualPercentageRatePercent(paidPeriodType,num10);

					if (num10 == 4)
					{
						if (this.Session["XFirst2"] != null)
						{
							totalPayable = (double) (num8 + ((num8*Convert.ToInt32(this.Session["XFirst2"]))*num));
							this.txs1.Text = totalPayable.ToString("0.00");
							this.Session["Repaydue4"] = this.txs1.Text;
							annualPercentageRate = "486.89%";
						}
						else
						{
							this.txs1.Text = "";
						}
					}
                	
					this.litAmountOfCredit.Text = num8.ToString();
					this.litChargeForCredit.Text =(totalPayable- num8).ToString("0.00");
					this.litTotalPayable.Text = totalPayable.ToString("0.00");
					this.litRepaymentInDays.Text = (span.Days + 1).ToString()+ " day(s)";
					this.litAnnualPercentageRate.Text = annualPercentageRate;
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
			dt.NInstallment = Convert.ToInt32(this.DropDownList1.SelectedValue);
			dt.RTime = SafeDateTime.LocalNow;
			DataTable list = new SystemInfoBN(this.Page).GetList();
			if (list.Rows.Count > 0)
			{
				dt.Interest = Convert.ToSingle(list.Rows[0]["interest"].ToString());
				num = Convert.ToSingle(list.Rows[0]["poundage"].ToString());
			}
			dt.Frequency = Convert.ToInt32(this.Session["frequency"]);
			if (this.DropDownList1.SelectedValue.Equals("4"))
			{
				dt.XDay = Convert.ToInt32(this.Session["XFirst2"]);
			}
			else
			{
				dt.XDay = Convert.ToInt32(this.Session["XFirst"]);
			}
			dt.huiSid = Convert.ToInt32(this.Hidden3.Value);
			if (this.Session["Repaydue1"] != null)
			{
				dt.Param1 = Convert.ToSingle(this.Session["Repaydue1"]);
			}
			if ((this.Session["Repaydue1"] != null) && (this.Session["Repaydue2"] != null))
			{
				dt.Param1 = Convert.ToSingle(this.Session["Repaydue1"]) + Convert.ToSingle(this.Session["Repaydue2"]);
			}
			if (((this.Session["Repaydue1"] != null) && (this.Session["Repaydue2"] != null)) && (this.Session["Repaydue3"] != null))
			{
				dt.Param1 = (Convert.ToSingle(this.Session["Repaydue1"]) + Convert.ToSingle(this.Session["Repaydue2"])) + Convert.ToSingle(this.Session["Repaydue3"]);
			}
			dt.Param2 = num * dt.NInstallment;
			dt.Param3 = count + 1;
			//---------------------------------------------------------------------------
			dt.LoanPurpose= this.txtLoanPurpose.Text;
			dt.HousePaymentCircle= EnumsOP.GetHousePaymentCircleByLiteral(this.ddlHousePaymentCircle.SelectedValue);
			dt.HousePaymentValue= Convert.ToSingle(this.txtHousePaymentValue.Value);
			dt.OtherLenderCircle= EnumsOP.GetOtherLenderCircleByLiteral(this.ddlOtherLenderCircle.SelectedValue);
			dt.OtherLenderValue= Convert.ToSingle(this.txtOtherLenderValue.Value);

			dt.OtherSamllCreditHas= int.Parse(rblHasOtherSamllCredit.SelectedValue);
			dt.OtherSmallCreditCount= int.Parse(ddlSmalCreditCount.SelectedValue);
			//---------------------------------------------------------------------------
			//也应该把 还款周期方式 和 最后收入日 保存在 最后贷款信息里
			dt.Wpaid = RadioButtonList1.SelectedValue;
			try
			{
				dt.NDayDD = Convert.ToInt32(this.nPayDd.Value);
				dt.NDayMM = Convert.ToInt32(this.nPayMm.Value);
				dt.NDayYY = Convert.ToInt32(this.nPayYy.Value);
			}
			catch{}
        	
			this.Hidden1.Value = dbn.Add2(dt).ToString();
			this.Hidden2.Value = (count + 1).ToString();
		}

		public void SetSchedule()
		{
			ScheduleBN ebn = new ScheduleBN(this.Page);
			ScheduleDT dt = null;
			switch (Convert.ToInt32(this.DropDownList1.SelectedValue))
			{
				case 1:
					dt = new ScheduleDT();
					dt.Datedue = Convert.ToDateTime(this.Session["Datedue1"]);
					dt.Repaydue = Convert.ToSingle(this.Session["Repaydue1"]);
					dt.huiSid = Convert.ToInt32(this.Hidden3.Value);
					dt.Numberment = Convert.ToInt32(this.Hidden2.Value);
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
					dt.huiSid = Convert.ToInt32(this.Hidden3.Value);
					dt.Numberment = Convert.ToInt32(this.Hidden2.Value);
					dt.Param1 = this.Hidden1.Value;
					dt.Param2 = "0";
					dt.Balance = Convert.ToSingle(this.Session["Repaydue1"]);
					dt.RepayTime = Convert.ToDateTime("2000-1-1");
					dt.OperateTime = Convert.ToDateTime("2000-1-1");
					ebn.Add(dt);
					dt = new ScheduleDT();
					dt.Datedue = Convert.ToDateTime(this.Session["Datedue2"]);
					dt.Repaydue = Convert.ToSingle(this.Session["Repaydue2"]);
					dt.huiSid = Convert.ToInt32(this.Hidden3.Value);
					dt.Numberment = Convert.ToInt32(this.Hidden2.Value);
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
					dt.huiSid = Convert.ToInt32(this.Hidden3.Value);
					dt.Numberment = Convert.ToInt32(this.Hidden2.Value);
					dt.Param1 = this.Hidden1.Value;
					dt.Param2 = "0";
					dt.Balance = Convert.ToSingle(this.Session["Repaydue1"]);
					dt.RepayTime = Convert.ToDateTime("2000-1-1");
					dt.OperateTime = Convert.ToDateTime("2000-1-1");
					ebn.Add(dt);
					dt = new ScheduleDT();
					dt.Datedue = Convert.ToDateTime(this.Session["Datedue2"]);
					dt.Repaydue = Convert.ToSingle(this.Session["Repaydue2"]);
					dt.huiSid = Convert.ToInt32(this.Hidden3.Value);
					dt.Numberment = Convert.ToInt32(this.Hidden2.Value);
					dt.Param1 = this.Hidden1.Value;
					dt.Param2 = "0";
					dt.Balance = Convert.ToSingle(this.Session["Repaydue1"]) + Convert.ToSingle(this.Session["Repaydue2"]);
					dt.RepayTime = Convert.ToDateTime("2000-1-1");
					dt.OperateTime = Convert.ToDateTime("2000-1-1");
					ebn.Add(dt);
					dt = new ScheduleDT();
					dt.Datedue = Convert.ToDateTime(this.Session["Datedue3"]);
					dt.Repaydue = Convert.ToSingle(this.Session["Repaydue3"]);
					dt.huiSid = Convert.ToInt32(this.Hidden3.Value);
					dt.Numberment = Convert.ToInt32(this.Hidden2.Value);
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
					dt.Numberment = Convert.ToInt32(this.Hidden2.Value);
					dt.Param1 = this.Hidden1.Value;
					dt.Param2 = "0";
					dt.Balance = Convert.ToSingle(this.Session["Repaydue4"]);
					dt.RepayTime = Convert.ToDateTime("2000-1-1");
					dt.OperateTime = Convert.ToDateTime("2000-1-1");
					ebn.Add(dt);
					break;
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
    	
		public void SetProcessCenter()
		{
			HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(Convert.ToInt32(this.Hidden3.Value));
			CSProcessCenterBN processBN= new CSProcessCenterBN(this.Page);
			CSProcessCenterDT processDT= new CSProcessCenterDT();
			processDT.ConversationTrack = String.Empty;
			processDT.IsFirstLoan = false;
			//TODO:LoanID需要确定
			processDT.LoanID =0;
			processDT.PostDate = SafeDateTime.LocalNow;
			processDT.ProcessStatus = ProcessCenterStatusEnum.Pending;
			processDT.UserID = ndt.id;
			processDT.UserLoanType = UserLoanTypes.Short;
			processDT.LastOperateDate = SafeDateTime.LocalNow;
				
			processBN.Add(processDT);
		}

		private void InitializeComponent()
		{
			this.LinkButton1.Click += new System.EventHandler(this.LinkButton1_Click);
			this.LinkButton3.Click += new System.EventHandler(this.LinkButton3_Click);
			this.Linkbutton4.Click += new System.EventHandler(this.Linkbutton4_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.ServerClick += new System.EventHandler(this.Button2_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}

		private void LinkButton1_Click(object sender, EventArgs e)
		{
			this.Panel1.Visible = true;
			this.Panel2.Visible = false;
		}

		private void LinkButton2_Click(object sender, EventArgs e)
		{
			this.Panel1.Visible = false;
			this.Panel2.Visible = true;
		}

		private void LinkButton3_Click(object sender, EventArgs e)
		{
			if (this.CheckBox1.Checked)
			{
				this.Panel2.Visible = false;
				this.PanelWarning.Visible = true;
			}
			else
			{
				base.Response.Write("<script>alert('Please Select!');</script>");
			}
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			this.Button1.Attributes.Add("onclick", "return CheckLoan()");
			EmployedBN dbn = new EmployedBN(this.Page);
			this.Hidden3.Value = this.Session["huiSid"].ToString();
			//22表示进入BlackList的用户也不能审请
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
				HuiyuanBN nbn = new HuiyuanBN(this.Page);
				nbn.QuerySid(this.Hidden3.Value);
				DataTable table2 = nbn.GetList();
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

		private void Linkbutton4_Click(object sender, System.EventArgs e)
		{
			this.Panel3.Visible = true;
			this.PanelWarning.Visible =false	;
		}
	}
}

