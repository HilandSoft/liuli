using System;
using System.Data;
using System.Web.UI;
using YingNet.WeiXing.Business;
using YingNet.WeiXing.STRUCTURE;
using YingNet.Common.Utils;

namespace YingNet.WeiXing.Business.CommonLogic
{
	/// <summary>
	/// PayDaySchedule 的摘要说明。
	/// </summary>
	public class PayDaySchedule
	{
		public PayDaySchedule()
		{
			
		}
		
		/// <summary>
		/// 计算还款日期
		/// </summary>
		/// <param name="userLoanType">借款人类型 0表示工作人士 1表示受政府支助人士</param>
		/// <param name="repaymentType">还款周期在类型(按照周,月等)</param>
		/// <param name="timeLoanRegistered">贷款的注册日期</param>
		public static bool CalculatePayDate(Page currentPage, int numInstallmentCount,DateTime timeRecentlySalaryDate,int userLoanType,PaidPeriodTypes repaymentType,
			ref DateTime timeFirstPay,ref DateTime timeSecondPay,ref DateTime timeThirdPay,ref DateTime timeAtOncePay,DateTime timeLoanRegistered,out string errorString)
		{
			if(timeRecentlySalaryDate<SafeDateTime.LocalToday)
			{
				errorString="<script>alert('The date of next payday must beyond today. Please re-enter your next payday.');</script>";
				return false;
			}

			/*timeLoanRegistered仅仅取日期部分*/
			timeLoanRegistered= timeLoanRegistered.Date;

			TimeSpan span3;
			
			int numShortDay = 0;
			int numDiffW = 0;
			int numDiffF = 0;
			int numDiffM = 0;
			int numTerm = 0;
			float numFrequency = 0f;
			DataTable listSystemInfo = new SystemInfoBN(currentPage).GetList();
			if (listSystemInfo.Rows.Count > 0)
			{
				numShortDay = Convert.ToInt32(listSystemInfo.Rows[0]["shortday"]);
				numFrequency = Convert.ToSingle(listSystemInfo.Rows[0]["frequency"]);
				numDiffW = Convert.ToInt32(listSystemInfo.Rows[0]["datediffw"]);
				numDiffF = Convert.ToInt32(listSystemInfo.Rows[0]["datedifff"]);
				numDiffM = Convert.ToInt32(listSystemInfo.Rows[0]["datediffm"]);
				numTerm = Convert.ToInt32(listSystemInfo.Rows[0]["term"]);
			}
			
			TimeSpan span = new TimeSpan(0x3e8L);
			TimeSpan spanRecentlyPayDateToToday = (TimeSpan) (timeRecentlySalaryDate - SafeDateTime.LocalNow);
            
			if (userLoanType != 0) //受支助人士
			{
				//受支助人士选择的 按周期的还款方式
				switch (repaymentType)
				{
					case PaidPeriodTypes.Weekly:
						if (spanRecentlyPayDateToToday.Days <= numDiffW)
						{
							currentPage.Session["frequency"] = 7;
							span = new TimeSpan(7, 0, 0, 0);
							timeFirstPay = timeRecentlySalaryDate + span;
							timeSecondPay = timeFirstPay + span;
							timeThirdPay = timeSecondPay + span;
							goto Label_04AF;
						}
						
						errorString = "<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>";
						//currentPage.Response.Write("<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>");
						return false;

					case PaidPeriodTypes.Fnightly:
						if (spanRecentlyPayDateToToday.Days <= numDiffF)
						{
							currentPage.Session["frequency"] = 14;
							span = new TimeSpan(14, 0, 0, 0);
							timeFirstPay = timeRecentlySalaryDate + span;
							timeSecondPay = timeFirstPay + span;
							timeThirdPay = timeSecondPay + span;
							goto Label_04AF;
						}
						
						errorString = "<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>";
						//currentPage.Response.Write("<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>");
						return false;

					case PaidPeriodTypes.Monthly:
						if ((numInstallmentCount > 3) || (spanRecentlyPayDateToToday.Days <= numDiffM))
						{
							currentPage.Session["frequency"] = numFrequency;
							/*
							int year = timeRecentlyPayDate.Year;
							int month = timeRecentlyPayDate.Month;
							int day = timeRecentlyPayDate.Day;
							int num15 = timeRecentlyPayDate.Month;
							*/
							timeFirstPay = timeRecentlySalaryDate.AddMonths(1);
							timeSecondPay = timeRecentlySalaryDate.AddMonths(2);
							timeThirdPay = timeRecentlySalaryDate.AddMonths(3);
							goto Label_04AF;
						}
						
						errorString = "<script>alert(\"The number of days to your next payday has exceeded 15 days. Please choose 'Repay on next payday' repayment option.\"');</script>";
						//currentPage.Response.Write("<script>alert(\"The number of days to your next payday has exceeded 15 days. Please choose 'Repay on next payday' repayment option.\"');</script>");
						return false;
				}
			}
			else //有工作人士
			{
				//有工作人士选择的 按周期的还款方式
				switch (repaymentType)
				{
					case PaidPeriodTypes.Weekly:
						if (spanRecentlyPayDateToToday.Days <= numDiffW)
						{
							currentPage.Session["frequency"] = 7;
							span = new TimeSpan(7, 0, 0, 0);
							timeFirstPay = timeRecentlySalaryDate + span;
							timeSecondPay = timeFirstPay + span;
							timeThirdPay = timeSecondPay + span;
							goto Label_04AF;
						}
						
						errorString = "<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>";
						//currentPage.Response.Write("<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>");
						return false;

					case PaidPeriodTypes.Fnightly:
						if (spanRecentlyPayDateToToday.Days <= numDiffF)
						{
							currentPage.Session["frequency"] = 14;
							span = new TimeSpan(14, 0, 0, 0);
							timeFirstPay = timeRecentlySalaryDate + span;
							timeSecondPay = timeFirstPay + span;
							timeThirdPay = timeSecondPay + span;
							goto Label_04AF;
						}
						
						errorString = "<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>";
						//currentPage.Response.Write("<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>");
						return false;

					case PaidPeriodTypes.Monthly:
						if ((numInstallmentCount > 3) || (spanRecentlyPayDateToToday.Days <= numDiffM))
						{
							currentPage.Session["frequency"] = numFrequency;
							//int num8 = timeRecentlySalaryDate.Year;
							//int num9 = timeRecentlySalaryDate.Month;
							//int num10 = timeRecentlySalaryDate.Day;
							//int num11 = timeRecentlySalaryDate.Month;
							timeFirstPay = timeRecentlySalaryDate.AddMonths(1);
							timeSecondPay = timeRecentlySalaryDate.AddMonths(2);
							timeThirdPay = timeRecentlySalaryDate.AddMonths(3);
							goto Label_04AF;
						}
						
						errorString = "<script>alert(\"The number of days to your next payday has exceeded 15 days. Please choose 'Repay on next payday' repayment option.\");</script>";
						//currentPage.Response.Write("<script>alert(\"The number of days to your next payday has exceeded 15 days. Please choose 'Repay on next payday' repayment option.\");</script>");
						return false;
				}
			}
			Label_04AF:
				span3 = (TimeSpan) (timeFirstPay - timeLoanRegistered);
			currentPage.Session["XFirst"] = span3.Days;

			if (numInstallmentCount == 4)
			{
				timeAtOncePay = timeRecentlySalaryDate;
				TimeSpan span4 = (TimeSpan) (timeAtOncePay - timeLoanRegistered);
				if (span4.Days < 3)
				{
					errorString = "<script>alert(\"There's less than 3 days to your next payday. Please choose another repayment option.\")</script>";
					//currentPage.Response.Write("<script>alert(\"There's less than 3 days to your next payday. Please choose another repayment option.\")</script>");
					currentPage.Session["XFirst2"] = null;
					return false;
				}
				else
				{
					currentPage.Session["XFirst2"] = span4.Days;
				}
			}
			
			currentPage.Session["Datedue1"] = timeFirstPay;
			currentPage.Session["Datedue2"] = timeSecondPay;
			currentPage.Session["Datedue3"] = timeThirdPay;
			currentPage.Session["Datedue4"] = timeAtOncePay;
			
			errorString = string.Empty;
			return true;
		}
		
		/// <summary>
		/// 计算还款数目
		/// </summary>
		/// <param name="userLoanType">借款人类型 0表示工作人士 1表示受政府支助人士</param>
		public static bool CalculatePayLoan(Page currentPage,int userLoanType,int numInstallmentCount,float numIncomeOrBenefit,float numLoanAmount,out string errorString)
		{
				
			float numInterest = 0f;
			float numFrequency = 0f;
			float numPercentage = 0f;
			float numUpperlimit = 0f;
			float numUpperlimit2 = 0f;
			float numPoundage = 0f;
			float numLowerlimit = 0f;
			float numLowerlimit2 = 0f;
			
			int numIsPercent = 0;
			int numTerm = 0;
			
			DataTable listSystemInfo = new SystemInfoBN(currentPage).GetList();
			if (listSystemInfo.Rows.Count > 0)
			{
				numInterest = Convert.ToSingle(listSystemInfo.Rows[0]["interest"].ToString());
				numFrequency = Convert.ToSingle(listSystemInfo.Rows[0]["frequency"].ToString());
				numPercentage = Convert.ToSingle(listSystemInfo.Rows[0]["percentage"].ToString());
				numUpperlimit = Convert.ToInt32(listSystemInfo.Rows[0]["upperlimit"].ToString());
				numUpperlimit2 = Convert.ToInt32(listSystemInfo.Rows[0]["upperlimit2"].ToString());
				numIsPercent = Convert.ToInt32(listSystemInfo.Rows[0]["IsPercent"].ToString());
				numLowerlimit = Convert.ToSingle(listSystemInfo.Rows[0]["lowerlimit"].ToString());
				numLowerlimit2 = Convert.ToSingle(listSystemInfo.Rows[0]["lowerlimit2"].ToString());
				numPoundage = Convert.ToSingle(listSystemInfo.Rows[0]["poundage"].ToString());
				numTerm = Convert.ToInt32(listSystemInfo.Rows[0]["term"].ToString());
			}
			if (numLoanAmount > numUpperlimit)
			{
				errorString = "<script>alert(\"Maximum amount you can borrow for your fist loan is $" + numUpperlimit.ToString() + ". Please modify and continue.\")</script>";
				return false;
				//base.Response.Write("<script>alert(\"Maximum amount you can borrow for your fist loan is $" + numUpperlimit.ToString() + ". Please modify and continue.\")</script>");
			}
			else if (numLoanAmount > ((numIncomeOrBenefit * numPercentage) * numInstallmentCount))
			{
				errorString = "<script>alert(\"The loan amount you requested will exceed your maximum borrowing capability. Please modify and continue.\")</script>";
				return false;
				//base.Response.Write("<script>alert(\"The loan amount you requested will exceed your maximum borrowing capability. Please modify and continue.\")</script>");
			}
			else
			{
				DateTime time = new DateTime();
				switch (numInstallmentCount)
				{
					case 1:
						if ((currentPage.Session["Datedue1"] != null) && !(currentPage.Session["Datedue1"].ToString() == ""))
						{
							time = Convert.ToDateTime(currentPage.Session["Datedue1"]);
							
						}
						break;
					case 2:
						if ((currentPage.Session["Datedue2"] != null) && !(currentPage.Session["Datedue2"].ToString() == ""))
						{
							time = Convert.ToDateTime(currentPage.Session["Datedue2"]);
							
						}
						break;
					case 3:
						if ((currentPage.Session["Datedue3"] != null) && !(currentPage.Session["Datedue3"].ToString() == ""))
						{
							time = Convert.ToDateTime(currentPage.Session["Datedue3"]);
							
						}
						break;
				}
				TimeSpan span = (TimeSpan) (time - SafeDateTime.LocalNow);
				if (span.Days > numTerm)
				{
					errorString = "<script>alert(\"The term of the loan is maximum " + numTerm.ToString() + " days or three pay periods whichever is the sooner. Please reselect the number of installment and continue.\")</script>";
					return false;
					//base.Response.Write("<script>alert(\"The term of the loan is maximum " + numTerm.ToString() + " days or three pay periods whichever is the sooner. Please reselect the number of installment and continue.\")</script>");
				}
				else if (numLoanAmount < numLowerlimit)
				{
					errorString = "<script>alert(\"Loan less than $" + numLowerlimit.ToString() + ". Please adjust and continue.\")</script>";
					return false;
					//base.Response.Write("<script>alert(\"Loan less than $" + numLowerlimit.ToString() + ". Please adjust and continue.\")</script>");
				}
				else if ((numLoanAmount < numLowerlimit2) && (numInstallmentCount > 1))
				{
					errorString = "<script>alert(\"For loan less than $" + numLowerlimit2.ToString() + ",ONE installment ONLY. Please adjust and continue.\")</script>";
					return false;
					//base.Response.Write("<script>alert(\"For loan less than $" + numLowerlimit2.ToString() + ",ONE installment ONLY. Please adjust and continue.\")</script>");
				}
				else if ((userLoanType == 1) && (numLoanAmount > 150f))
				{
					errorString = "<script>alert(\"Maximum amount you can borrow is $150. Please modify and continue.\")</script>";
					return false;
					
					//base.Response.Write("<script>alert(\"Maximum amount you can borrow is $150. Please modify and continue.\")</script>");
				}
				else
				{
					int num14 = Convert.ToInt32(currentPage.Session["XFirst"]);
					double num15 = 0.0;
					double num16 = 0.0;
					string temp = string.Empty;
					currentPage.Session["Repayduezs"] = numLoanAmount.ToString();
					switch (numInstallmentCount)
					{
						case 1:
							num15 = (numLoanAmount + ((numLoanAmount * Convert.ToSingle(currentPage.Session["frequency"])) * numInterest)) + numPoundage;
							temp = num15.ToString("0.00");
							currentPage.Session["Repaydue1"] = temp;
							break;

						case 2:
							num15 = ((numLoanAmount * num14) * numInterest) + numPoundage;
							temp = num15.ToString("0.00");
							num16 = (((((numLoanAmount * Convert.ToSingle(currentPage.Session["frequency"])) * numInterest) * 2f) + numLoanAmount) + numPoundage) * 0.5;
							temp = num16.ToString("0.00");
							//this.s1.Text = this.s2.Text;
							currentPage.Session["Repaydue1"] = temp;
							currentPage.Session["Repaydue2"] = temp;
							break;

						case 3:
							num15 = ((numLoanAmount * num14) * numInterest) + numPoundage;
							temp= num15.ToString("0.00");
							temp= ((double) ((((numLoanAmount * Convert.ToSingle(currentPage.Session["frequency"])) * numInterest) + (numLoanAmount / 2f)) + numPoundage)).ToString("0.00");
							temp= (((double) (((((numLoanAmount * Convert.ToSingle(currentPage.Session["frequency"])) * numInterest) * 3f) + numLoanAmount) + numPoundage)) / 3.0).ToString("0.00");
							
							/*
							this.s1.Text = num15.ToString("0.00");
							this.s2.Text = ((double) ((((numLoanAmount * Convert.ToSingle(currentPage.Session["frequency"])) * numInterest) + (numLoanAmount / 2f)) + numPoundage)).ToString("0.00");
							this.s3.Text = (((double) (((((numLoanAmount * Convert.ToSingle(currentPage.Session["frequency"])) * numInterest) * 3f) + numLoanAmount) + numPoundage)) / 3.0).ToString("0.00");
							this.s1.Text = this.s2.Text = this.s3.Text;
							*/
							currentPage.Session["Repaydue1"] = temp;
							currentPage.Session["Repaydue2"] = temp;
							currentPage.Session["Repaydue3"] = temp;
							break;
					}
					if (numInstallmentCount == 4)
					{
						if (currentPage.Session["XFirst2"] != null)
						{
							temp = ((double) (numLoanAmount + ((numLoanAmount * Convert.ToInt32(currentPage.Session["XFirst2"])) * numInterest))).ToString("0.00");
							currentPage.Session["Repaydue4"] = temp;
						}
						else
						{
							//this.s1.Text = "";
						}
					}
					
					errorString = string.Empty;
					return true;
				}
			}
		}
	}
}
