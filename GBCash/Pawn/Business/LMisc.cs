using System;
using YingNet.WeiXing.STRUCTURE;

namespace YingNet.WeiXing.Business
{
	/// <summary>
	/// LMisc 的摘要说明。
	/// </summary>
	public class LMisc
	{
		/// <summary>
		/// 根据还款的周期类型和还款的总月数计算年利率（百分比表示）
		/// </summary>
		/// <param name="paidPeriodType"></param>
		/// <param name="paidMonthCount"></param>
		/// <returns></returns>
		public static string GetAnnualRatePercent(PaidPeriodTypes paidPeriodType, int paidCount)
		{
			return GetAnnualRatePercent( paidPeriodType,paidCount, false);
		}

		/// <summary>
		/// 根据还款的周期类型和还款的总月数计算年利率（百分比表示）
		/// </summary>
		/// <param name="paidPeriodType"></param>
		/// <param name="paidMonthCount"></param>
		/// <returns></returns>
		public static string GetAnnualRatePercent(PaidPeriodTypes paidPeriodType, int paidCount,bool withPostFix)
		{
			decimal rate = GetAnnualRate(paidPeriodType, paidCount);
			string result= (rate * 100).ToString("0.00");
			if(withPostFix==true)
			{
				result+="%";
			}
			return  result ;
		}

		/// <summary>
		/// 根据还款的周期类型和还款的总月数计算年利率（小数表示）
		/// </summary>
		/// <returns></returns>
		public static decimal GetAnnualRate(PaidPeriodTypes paidPeriodType, int paidCount)
		{
			decimal result = 0.0000M;
			int paidMonthCount=GetPaidMonthCountByPaidCount(paidPeriodType,paidCount);
			switch (paidMonthCount)
			{
				case 3:
				{
					switch (paidPeriodType)
					{
						case PaidPeriodTypes.Weekly:
							result = 3.9182M;
							break;
						case PaidPeriodTypes.Fnightly:
							result = 3.7074M;
							break;
						case PaidPeriodTypes.Monthly:
							result = 3.3300M;
							break;
						case PaidPeriodTypes.BiMonthly:
							result = 3.6816M;
							break;
					}
					break;
				}

				case 4:
				{
					switch (paidPeriodType)
					{
						case PaidPeriodTypes.Weekly:
							result = 3.1574M;
							break;
						case PaidPeriodTypes.Fnightly:
							result = 3.0304M;
							break;
						case PaidPeriodTypes.Monthly:
							result = 2.7852M;
							break;
						case PaidPeriodTypes.BiMonthly:
							result = 3.0046M;
							break;
					}
					break;
				}


				case 5:
				{
					switch (paidPeriodType)
					{
						case PaidPeriodTypes.Weekly:
							result = 2.7577M;
							break;
						case PaidPeriodTypes.Fnightly:
							result = 2.6703M;
							break;
						case PaidPeriodTypes.Monthly:
							result = 2.4912M;
							break;
						case PaidPeriodTypes.BiMonthly:
							result = 2.6472M;
							break;
					}
					break;
				}


				case 6:
				{
					switch (paidPeriodType)
					{
						case PaidPeriodTypes.Weekly:
							result = 2.3695M;
							break;
						case PaidPeriodTypes.Fnightly:
							result = 2.3071M;
							break;
						case PaidPeriodTypes.Monthly:
							result = 2.1732M;
							break;
						case PaidPeriodTypes.BiMonthly:
							result = 2.2847M;
							break;
					}
					break;
				}


				case 7:
				{
					switch (paidPeriodType)
					{
						case PaidPeriodTypes.Weekly:
							result = 1.9884M;
							break;
						case PaidPeriodTypes.Fnightly:
							result = 1.9429M;
							break;
						case PaidPeriodTypes.Monthly:
							result = 1.8414M;
							break;
						case PaidPeriodTypes.BiMonthly:
							result = 1.9246M;
							break;
					}
					break;
				}


				case 8:
				{
					switch (paidPeriodType)
					{
						case PaidPeriodTypes.Weekly:
							result = 1.9470M;
							break;
						case PaidPeriodTypes.Fnightly:
							result = 1.9059M;
							break;
						case PaidPeriodTypes.Monthly:
							result = 1.8192M;
							break;
						case PaidPeriodTypes.BiMonthly:
							result = 1.8886M;
							break;
					}
					break;
				}


				case 9:
				{
					switch (paidPeriodType)
					{
						case PaidPeriodTypes.Weekly:
							result = 1.8993M;
							break;
						case PaidPeriodTypes.Fnightly:
							result = 1.8714M;
							break;
						case PaidPeriodTypes.Monthly:
							result = 1.7928M;
							break;
						case PaidPeriodTypes.BiMonthly:
							result = 1.8502M;
							break;
					}
					break;
				}


				case 10:
				{
					switch (paidPeriodType)
					{
						case PaidPeriodTypes.Weekly:
							result = 1.8617M;
							break;
						case PaidPeriodTypes.Fnightly:
							result = 1.8336M;
							break;
						case PaidPeriodTypes.Monthly:
							result = 1.7646M;
							break;
						case PaidPeriodTypes.BiMonthly:
							result = 1.8130M;
							break;
					}
					break;
				}


				case 11:
				{
					switch (paidPeriodType)
					{
						case PaidPeriodTypes.Weekly:
							result = 1.6828M;
							break;
						case PaidPeriodTypes.Fnightly:
							result = 1.8002M;
							break;
						case PaidPeriodTypes.Monthly:
							result = 1.7351M;
							break;
						case PaidPeriodTypes.BiMonthly:
							result = 1.7760M;
							break;
					}
					break;
				}

				case 12:
				{
					switch (paidPeriodType)
					{
						case PaidPeriodTypes.Weekly:
							result = 1.7878M;
							break;
						case PaidPeriodTypes.Fnightly:
							result = 1.7639M;
							break;
						case PaidPeriodTypes.Monthly:
							result = 1.7060M;
							break;
						case PaidPeriodTypes.BiMonthly:
							result = 1.7424M;
							break;
					}
					break;
				}

			}
			return result;
		}

		/// <summary>
		/// 根据还款的期数和还款周期的类型,推算总共还款的月数
		/// </summary>
		/// <param name="paidPeriodType"></param>
		/// <param name="paidCount"></param>
		/// <returns></returns>
		private static int GetPaidMonthCountByPaidCount(PaidPeriodTypes paidPeriodType, int paidCount)
		{
			int result= 0;
			switch(paidPeriodType)
			{
				case PaidPeriodTypes.Weekly:
					result= paidCount/4;
					break;
				case PaidPeriodTypes.Fnightly:
					result= paidCount/2;
					break;
				case PaidPeriodTypes.Monthly:
					result= paidCount;
					break;
				case PaidPeriodTypes.BiMonthly:
				default:
					result= paidCount*2;
					break;

			}

			return result;
		}
	}
}
