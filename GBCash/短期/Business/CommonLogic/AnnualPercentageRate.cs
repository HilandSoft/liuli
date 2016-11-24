using System;
using YingNet.WeiXing.STRUCTURE;
using YingNet.Common.Utils;

namespace YingNet.WeiXing.Business.CommonLogic
{
	/// <summary>
	/// AnnualPercentageRate ��ժҪ˵����
	/// </summary>
	public class AnnualPercentageRate
	{
		private AnnualPercentageRate()
		{
			//
			// TODO: �ڴ˴���ӹ��캯���߼�
			//
		} 

		/// <summary>
		/// ���ݴ�������λ�ȡ����
		/// </summary>
		/// <param name="paidType">�������ͣ�ÿ�ܻ����ÿ�»���ȣ�</param>
		/// <param name="paidCount">�������������ֶ����ڻ��</param>
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
		/// ���ݴ�������λ�ȡ���ʰٷֱȣ��ַ�����
		/// </summary>
		/// <param name="paidType">�������ͣ�ÿ�ܻ����ÿ�»���ȣ�</param>
		/// <param name="paidCount">�������������ֶ����ڻ��</param>
		/// <returns></returns>
		public static string GetAnnualPercentageRatePercent(PaidPeriodTypes paidPeriodType,int paidCount)
		{
			decimal result= GetAnnualPercentageRate(paidPeriodType,paidCount)*100;
			string ret= result.ToString("0.00") + "%";
			return ret;
		}

		/// <summary>
		/// �������һ�λ����ʱ�䣬����������
		/// </summary>
		/// <param name="lastPayDate"></param>
		/// <returns></returns>
		public static decimal GetAnnualPercentageRate(DateTime lastPayDate)
		{
			int spanDays= ((TimeSpan)(lastPayDate- SafeDateTime.LocalNow)).Days;
			if(spanDays<=0){
				spanDays=1;
			}

			double interest= 0.24; 
			if(spanDays<=31)
			{
				interest= 0.24;
			}
			else
			{
				interest= 0.24; //0.28;
			}

			return (decimal)interest / spanDays * 365;
		}

		/// <summary>
		/// �������һ�λ����ʱ�䣬����������
		/// </summary>
		/// <param name="lastPayDate"></param>
		/// <returns></returns>
		public static string GetAnnualPercentageRatePercent(DateTime lastPayDate)
		{
			decimal result= GetAnnualPercentageRate(lastPayDate)*100;
			string ret= result.ToString("0.00") + "%";
			return ret; 
		}
	}
}
