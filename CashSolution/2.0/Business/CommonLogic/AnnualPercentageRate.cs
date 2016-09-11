using System;
using YingNet.WeiXing.STRUCTURE;

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
	}
}
