using System;

namespace YingNet.WeiXing.STRUCTURE
{
	/// <summary>
	/// EnumsOP 的摘要说明。
	/// </summary>
	public class EnumsOP
	{
		/// <summary>		/// 通过文本获取房屋还款周期		/// </summary>		/// <param name="circleText"></param>		/// <returns></returns>
		public static HousePaymentCircles GetHousePaymentCircleByLiteral(string circleText)
		{
			HousePaymentCircles result= HousePaymentCircles.NonSet;
			circleText= circleText.ToLower();
			switch(circleText)
			{
				case "weekly":
				case "week":
				case "perweek":
					result= HousePaymentCircles.Weekly;
					break;
				case "fnight":
				case "f'night":
					result= HousePaymentCircles.FNight;
					break;
				case "month":
				case "monthly":
					result= HousePaymentCircles.Monthly;
					break;
				case "bimonth":
				case "bi-month":
				case "bimonthly":
					result= HousePaymentCircles.BiMonth;
					break;
				default:
					result= HousePaymentCircles.NonSet;
					break;
			}

			return result;
		}


		/// <summary>		/// 通过文本获取其他贷款还款周期		/// </summary>		/// <param name="circleText"></param>		/// <returns></returns>
		public static OtherLenderCircles GetOtherLenderCircleByLiteral(string circleText)
		{
			OtherLenderCircles result= OtherLenderCircles.NonSet;
			circleText= circleText.ToLower();
			switch(circleText)
			{
				case "weekly":
				case "week":
				case "perweek":
					result= OtherLenderCircles.Weekly;
					break;
				case "fnight":
				case "f'night":
					result= OtherLenderCircles.FNight;
					break;
				case "month":
				case "monthly":
					result= OtherLenderCircles.Monthly;
					break;
				case "bimonth":
				case "bi-month":
				case "bimonthly":
					result= OtherLenderCircles.BiMonth;
					break;
				default:
					result= OtherLenderCircles.NonSet;
					break;
			}

			return result;
		}

		/// <summary>		/// 根据枚举数（int值或者null）获取房屋付款周期字符串		/// </summary>		/// <param name="input"></param>		/// <returns></returns>
		public static string GetHousePaymentCircleLiteral(object input)		{			string result= string.Empty;
			if(input==null)			{				result= "UnSet";			}			else			{				try				{					result= ((HousePaymentCircles)input).ToString();				}				catch{}			}			return result;		}

		/// <summary>		/// 根据枚举数（int值或者null）其他贷款付款周期字符串		/// </summary>		/// <param name="input"></param>		/// <returns></returns>		public static string GetOtherLenderCircleLiteral(object input)		{			string result= string.Empty;			if(input==null)			{				result= "UnSet";			}			else			{				try				{					result= ((OtherLenderCircles)input).ToString();				}				catch{}			}
			return result;		}
	}
}
