using System;
using YingNet.WeiXing.STRUCTURE;

namespace YingNet.WeiXing.Business.CommonLogic
{
	/// <summary>
	/// AnnualPercentageRate 的摘要说明。
	/// </summary>
	public class AnnualPercentageRate
	{
		private AnnualPercentageRate()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		} 

		/// <summary>
		/// 根据贷款的情形获取利率
		/// </summary>
		/// <param name="paidType">还款类型（每周还款还是每月还款等）</param>
		/// <param name="paidCount">还款期数（即分多少期还款）</param>
		/// <returns></returns>
		public static decimal GetAnnualPercentageRate(PaidPeriodTypes paidPeriodType,int paidCount)
		{
			decimal ret=0M;
			switch(paidPeriodType)
			{
				case PaidPeriodTypes.Weekly:
				{
					switch(paidCount)
					{
						case 1:
							ret= 4.8689M;
							break;
						case 2:
							ret= 6.3660M;
							break;
						case 3:
							ret= 7.0130M;
							break;
						default:
							ret= 4.8689M;
							break;
					}
				}
					break;
				case PaidPeriodTypes.Fnightly:
				{
					switch(paidCount)
					{
						case 1:
							ret= 4.8689M;
							break;
						case 2:
							ret= 6.2616M;
							break;
						case 3:
							ret= 6.7834M;
							break;
						default:
							ret= 4.8689M;
							break;
					}
				}
					break;
				case PaidPeriodTypes.Monthly:
				{
					switch(paidCount)
					{
						case 1:
							ret= 4.8689M;
							break;
						case 2:
							ret= 4.8689M;
							break;
						case 3:
							ret= 4.8689M;
							break;
						default:
							ret= 4.8689M;
							break;
					}
				}
					break;
				default:
					ret= 4.8689M;
					break;
			}
			return ret;
		}

		/// <summary>
		/// 根据贷款的情形获取利率百分比（字符串）
		/// </summary>
		/// <param name="paidType">还款类型（每周还款还是每月还款等）</param>
		/// <param name="paidCount">还款期数（即分多少期还款）</param>
		/// <returns></returns>
		public static string GetAnnualPercentageRatePercent(PaidPeriodTypes paidPeriodType,int paidCount)
		{
			decimal result= GetAnnualPercentageRate(paidPeriodType,paidCount)*100;
			string ret= result.ToString("0.00") + "%";
			return ret;
		}
	}
}
