using System;

namespace YingNet.WeiXing.STRUCTURE
{
	/// <summary>
	/// LemploymentDT的摘要说明。
	/// </summary>
	public class LemploymentDT
	{
		public LemploymentDT()
		{
		}

		/// <summary>
		/// 
		/// </summary>
		public int sid;

		/// <summary>
		/// 
		/// </summary>
		public string EName;

		/// <summary>
		/// 
		/// </summary>
		public string EAddress;

		/// <summary>
		/// 
		/// </summary>
		public string ECode;

		/// <summary>
		/// 
		/// </summary>
		public string ENum;

		/// <summary>
		/// 
		/// </summary>
		public string EStatus;

		/// <summary>
		/// 
		/// </summary>
		public string JobTitle;

		/// <summary>
		/// 
		/// </summary>
		public int TimeYears;

		/// <summary>
		/// 
		/// </summary>
		public int TimeMonths;

		/// <summary>
		/// 
		/// </summary>
		public double TakePay;

		/// <summary>
		/// 
		/// </summary>
		public int Per;

		/// <summary>
		/// 
		/// </summary>
		public int NextDay;

		/// <summary>
		/// 
		/// </summary>
		public int NextMonth;

		/// <summary>
		/// 
		/// </summary>
		public int NextYear;

		/// <summary>
		/// 
		/// </summary>
		public int LoanSid;

		/// <summary>
		/// 
		/// </summary>
		public string Other1;

		/// <summary>
		/// 
		/// </summary>
		public string Other2;

		/// <summary>
		/// 
		/// </summary>
		public string Other3;

		/// <summary>
		/// 
		/// </summary>
		public int Other4;

		/// <summary>
		/// 
		/// </summary>
		public int Other5;

		/// <summary>
		/// 
		/// </summary>
		public int Other6;

		/// <summary>
		/// 
		/// </summary>
		public int FollowDay;

		/// <summary>
		/// 
		/// </summary>
		public int FollowMonth;

		/// <summary>
		/// 
		/// </summary>
		public int FollowYear;

		private float housePaymentValue=0F;
		/// <summary>		/// 住房费用		/// </summary>
		public float HousePaymentValue
		{
			get{return this.housePaymentValue;}
			set{this.housePaymentValue=value;}
		}


		private HousePaymentCircles housePaymentCircle= HousePaymentCircles.NonSet;
		/// <summary>		/// 住房费用还款周期		/// </summary>
		public HousePaymentCircles HousePaymentCircle
		{
			get{return this.housePaymentCircle;}
			set{this.housePaymentCircle=value;}
		}


		private float otherLenderValue=0F;
		/// <summary>		/// 其他的贷款费用		/// </summary>
		public float OtherLenderValue
		{
			get{return this.otherLenderValue;}
			set{this.otherLenderValue=value;}
		}


		private OtherLenderCircles otherLenderCircle= OtherLenderCircles.NonSet;
		/// <summary>		/// 其他的贷款还款周期		/// </summary>
		public OtherLenderCircles OtherLenderCircle
		{
			get{return this.otherLenderCircle;}
			set{this.otherLenderCircle=value;}
		}

		/// <summary>
		/// 全部字段。
		/// </summary>
		public string allFields= "sid,EName,EAddress,ECode,ENum,EStatus,JobTitle,TimeYears,TimeMonths,TakePay,Per,NextDay,NextMonth,NextYear,LoanSid,Other1,Other2,Other3,Other4,Other5,Other6,FollowDay,FollowMonth,FollowYear,HousePaymentValue,HousePaymentCircle,OtherLenderValue,OtherLenderCircle";
	}
}
