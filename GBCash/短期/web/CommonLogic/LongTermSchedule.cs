//using System;
//using System.Collections;
//using System.Data;
//using System.Web.UI.HtmlControls;
//using System.Web.UI.WebControls;
//using System.Web.UI;
//using YingNet.Common;
//using YingNet.WeiXing.Business;
//
//namespace YingNet.WeiXing.WebApp.CommonLogic
//{
//	/// <summary>
//	/// LongTermSchedule 的摘要说明。
//	/// </summary>
//	public class LongTermSchedule
//	{
//		public LongTermSchedule()
//		{
//			//
//			// TODO: 在此处添加构造函数逻辑
//			//
//		}
//		
//		public static DateTime GetNextBiMonth(DateTime nextDate, DateTime date, int addMonths)
//		{
//			int year = date.Year;
//			int month = date.Month;
//			int day = date.Day;
//			int num4 = 0;
//			int num5 = 0;
//			int num6 = 0;
//			Hashtable hashtable = new Hashtable();
//			hashtable.Add(1, 0x1f);
//			hashtable.Add(2, 0x1c);
//			hashtable.Add(3, 0x1f);
//			hashtable.Add(4, 30);
//			hashtable.Add(5, 0x1f);
//			hashtable.Add(6, 30);
//			hashtable.Add(7, 0x1f);
//			hashtable.Add(8, 0x1f);
//			hashtable.Add(9, 30);
//			hashtable.Add(10, 0x1f);
//			hashtable.Add(11, 30);
//			hashtable.Add(12, 0x1f);
//			int num7 = day;
//			if (num7 != 1)
//			{
//				switch (num7)
//				{
//					case 0x1c:
//						if (((month + addMonths) - 1) < 12)
//						{
//							num4 = year;
//							num5 = month + addMonths;
//						}
//						else
//						{
//							num4 = year + 1;
//							num5 = (month + addMonths) - 12;
//						}
//						num6 = 15;
//						goto Label_0252;
//
//					case 0x1d:
//						goto Label_0252;
//
//					case 30:
//						if (((month + addMonths) - 1) < 12)
//						{
//							num4 = year;
//							num5 = month + addMonths;
//						}
//						else
//						{
//							num4 = year + 1;
//							num5 = (month + addMonths) - 12;
//						}
//						num6 = 15;
//						goto Label_0252;
//
//					case 0x1f:
//						if (((month + addMonths) - 1) < 12)
//						{
//							num4 = year;
//							num5 = month + addMonths;
//						}
//						else
//						{
//							num4 = year + 1;
//							num5 = (month + addMonths) - 12;
//						}
//						num6 = 15;
//						goto Label_0252;
//
//					case 15:
//						if (nextDate.Day.Equals(1))
//						{
//							if (((month + addMonths) - 1) >= 12)
//							{
//								num4 = year + 1;
//								num5 = (month + addMonths) - 12;
//							}
//							else
//							{
//								num4 = year;
//								num5 = month + addMonths;
//							}
//							num6 = 1;
//						}
//						else
//						{
//							if (((month + addMonths) - 2) >= 12)
//							{
//								num4 = year + 1;
//								num5 = ((month + addMonths) - 12) - 1;
//							}
//							else
//							{
//								num4 = year;
//								num5 = (month + addMonths) - 1;
//							}
//							num6 = Convert.ToInt32(hashtable[month]);
//						}
//						goto Label_0252;
//				}
//			}
//			else
//			{
//				if (((month + addMonths) - 2) >= 12)
//				{
//					num4 = year + 1;
//					num5 = ((month + addMonths) - 12) - 1;
//				}
//				else
//				{
//					num4 = year;
//					num5 = (month + addMonths) - 1;
//				}
//				num6 = 15;
//			}
//			Label_0252:
//				return new DateTime(num4, num5, num6, 0x17, 0x3b, 0x3b);
//		}
//
//		public static DateTime GetNextMonth(DateTime date, int addMonths)
//		{
//			int year = date.Year;
//			int month = date.Month;
//			DateTime time = date.AddMonths(addMonths);
//			year = time.Year;
//			month = time.Month;
//			int day = date.Day;
//			Hashtable hashtable = new Hashtable();
//			hashtable.Add(1, 0x1f);
//			hashtable.Add(2, 0x1c);
//			hashtable.Add(3, 0x1f);
//			hashtable.Add(4, 30);
//			hashtable.Add(5, 0x1f);
//			hashtable.Add(6, 30);
//			hashtable.Add(7, 0x1f);
//			hashtable.Add(8, 0x1f);
//			hashtable.Add(9, 30);
//			hashtable.Add(10, 0x1f);
//			hashtable.Add(11, 30);
//			hashtable.Add(12, 0x1f);
//			if (month > 12)
//			{
//				year++;
//				month = 1;
//			}
//			if ((day.Equals(0x1d) || day.Equals(30)) && month.Equals(2))
//			{
//				day = 0x1c;
//			}
//			if (day.Equals(0x1f))
//			{
//				day = Convert.ToInt32(hashtable[month]);
//			}
//			return new DateTime(year, month, day);
//		}
//
//		
//		/// <summary>
//		/// 获取可以贷款的最大额度
//		/// </summary>
//		/// <param name="term">贷款周期数</param>
//		/// <param name="sPer">还款方式(每周?每月等)</param>
//		/// <param name="sTakePay">月收入</param>
//		/// <returns></returns>
//		public static double IsLimit(string term, string sPer, string sTakePay)
//		{
//			string commandText = "select * from LParams where Sid=" + term;
//			DataTable table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
//			if (table.Rows.Count <= 0)
//			{
//				return 0.0;
//			}
//			int num = 0;
//			double num2 = 0.0;
//			int num3 = Convert.ToInt32(term);
//			switch (sPer)
//			{
//				case "0":
//					num2 = Convert.ToDouble(table.Rows[0]["NrW"]) * 0.01;
//					num = num3 * 4;
//					goto Label_0152;
//
//				case "1":
//					num2 = Convert.ToDouble(table.Rows[0]["NrF"]) * 0.01;
//					num = num3 * 2;
//					goto Label_0152;
//
//				case "2":
//					num2 = Convert.ToDouble(table.Rows[0]["NrB"]) * 0.01;
//					num = num3 * 2;
//					break;
//
//				case "3":
//					num2 = Convert.ToDouble(table.Rows[0]["NrM"]) * 0.01;
//					num = num3;
//					break;
//			}
//			Label_0152:
//				return (((0.25 * Convert.ToDouble(sTakePay)) * num) / ((num * num2) + 1.0));
//		} 
//
//
//		
//		/// <summary>
//		/// 保存还款Schedule
//		/// </summary>
//		/// <param name="persionID"></param>
//		/// <param name="payDate"></param>
//		/// <param name="numTermCount"></param>
//		/// <param name="perTypeUserChoosen"></param>
//		/// <param name="numLoanAmount"></param>
//		/// <param name="tableEmployment"></param>
//		public static void AddSchedules(string personID,DateTime payDate,int numTermCount,string perTypeUserChoosen,float numLoanAmount,int followDay,int followMonth,int followYear,DateTime loanHappenedDate)
//		{
//			int num10 = 0;
//			int num11 = 0;
//			int num12 = 0;
//			int num13 = 0;
//			int num14 = 0;
//			
//			double num2 = 0.0;
//			double num3 = 0.0;
//			double num4 = 0.0;
//			string commandText = "";
//			
//			DateTime nextDate = payDate;
//			TimeSpan span = (TimeSpan) (payDate - loanHappenedDate);
//			commandText = "select * from LParams where Sid=" + numTermCount.ToString();
//			DataTable listParam= new DataTable();
//			listParam = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
//			string str5 = "";
//			switch (perTypeUserChoosen)
//			{
//				case "0":
//					num2 = Convert.ToDouble(listParam.Rows[0]["NrW"]) * 0.01;
//					num13 = numTermCount * 4;
//					num3 = (((numLoanAmount * num2) * num13) + numLoanAmount) / ((double) num13);
//					if (span.Days < 15)
//					{
//						payDate = payDate.AddDays(7.0);
//					}
//					num14 = 0;
//					while (num14 < num13)
//					{
//						num4 = num3 * (num14 + 1);
//						str5 = payDate.Day.ToString() + "/" + payDate.Month.ToString() + "/" + payDate.Year.ToString();
//						commandText = "insert into LPay(Datedue,Repaydue,Balance,PerSid,Interest) values ('" + str5 + "'," + num3.ToString("0.00") + "," + num4.ToString("0.00") + "," + personID + "," + listParam.Rows[0]["NrW"].ToString() + ")";
//						payDate = payDate.AddDays(7.0);
//						SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText);
//						num14++;
//					}
//					break;
//
//				case "1":
//					num2 = Convert.ToSingle(listParam.Rows[0]["NrF"]) * 0.01;
//					num13 = numTermCount * 2;
//					num3 = (((numLoanAmount * num2) * num13) + numLoanAmount) / ((double) num13);
//					if (span.Days < 15)
//					{
//						payDate = payDate.AddDays(14.0);
//					}
//					for (num14 = 0; num14 < num13; num14++)
//					{
//						num4 = num3 * (num14 + 1);
//						str5 = payDate.Day.ToString() + "/" + payDate.Month.ToString() + "/" + payDate.Year.ToString();
//						commandText = "insert into LPay(Datedue,Repaydue,Balance,PerSid,Interest) values ('" + str5 + "'," + num3.ToString("0.00") + "," + num4.ToString("0.00") + "," + personID + "," + listParam.Rows[0]["NrF"].ToString() + ")";
//						payDate = payDate.AddDays(14.0);
//						SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText);
//					}
//					break;
//
//				case "2":
//				{
//					num2 = Convert.ToSingle(listParam.Rows[0]["NrB"]) * 0.01;
//					num10 = followDay; //Convert.ToInt32(tableEmployment.Rows[0]["FollowDay"]);
//					num11 = followMonth;//Convert.ToInt32(tableEmployment.Rows[0]["FollowMonth"]);
//					num12 = followYear;//Convert.ToInt32(tableEmployment.Rows[0]["FollowYear"]);
//					DateTime time3 = new DateTime(num12, num11, num10);
//					num13 = numTermCount * 2;
//					num3 = (((numLoanAmount * num2) * num13) + numLoanAmount) / ((double) num13);
//					if (span.Days < 15)
//					{
//						payDate = time3;
//					}
//					for (num14 = 0; num14 < num13; num14++)
//					{
//						num4 = num3 * (num14 + 1);
//						str5 = payDate.Day.ToString() + "/" + payDate.Month.ToString() + "/" + payDate.Year.ToString();
//						commandText = "insert into LPay(Datedue,Repaydue,Balance,PerSid,Interest) values ('" + str5 + "'," + num3.ToString("0.00") + "," + num4.ToString("0.00") + "," + personID + "," + listParam.Rows[0]["NrB"].ToString() + ")";
//						payDate = LongTermSchedule.GetNextBiMonth(nextDate, payDate, 1);
//						SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText);
//					}
//					break;
//				}
//				case "3":
//					num2 = Convert.ToSingle(listParam.Rows[0]["NrM"]) * 0.01;
//					num13 = numTermCount;
//					num3 = (((numLoanAmount * num2) * num13) + numLoanAmount) / ((double) num13);
//					if (span.Days < 15)
//					{
//						payDate = LongTermSchedule.GetNextMonth(payDate, 1);
//					}
//					for (num14 = 0; num14 < num13; num14++)
//					{
//						num4 = num3 * (num14 + 1);
//						str5 = payDate.Day.ToString() + "/" + payDate.Month.ToString() + "/" + payDate.Year.ToString();
//						commandText = "insert into LPay(Datedue,Repaydue,Balance,PerSid,Interest) values ('" + str5 + "'," + num3.ToString("0.00") + "," + num4.ToString("0.00") + "," + personID + "," + listParam.Rows[0]["NrM"].ToString() + ")";
//						payDate = LongTermSchedule.GetNextMonth(payDate, 1);
//						SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText);
//					}
//					break;
//
//				default:
//					//base.Response.Write("<script>alert('信息已经保存,不能再修改!');window.location='Step.aspx';</script>");
//					break;
//			}
//		}
//		
//		
//		/// <summary>
//		/// 删除还款Schedule
//		/// </summary>
//		/// <param name="personID"></param>
//		public static void DeleteSchedules(int personID)
//		{
//			string commandText = "DELETE FROM [LPay] WHERE [PerSid]= "+ personID  ;
//			SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText);
//		}
//		
//	}
//}
