using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using YingNet.WeiXing.WebApp.UControls;
using YingNet.WeiXing.STRUCTURE;
using YingNet.Common;
using YingNet.WeiXing.Business.CommonLogic;
using YingNet.Common.Utils;

namespace YingNet.WeiXing.WebApp
{
	/// <summary>
	/// Calculate 的摘要说明。
	/// </summary>
	public class Calculator : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txRepayA;
		protected System.Web.UI.WebControls.TextBox txRepayF;
		protected System.Web.UI.WebControls.TextBox txNumber;
		protected System.Web.UI.WebControls.Label Label1;
		protected System.Web.UI.HtmlControls.HtmlInputText txLoan;
		protected System.Web.UI.HtmlControls.HtmlInputText txIncome;
		protected System.Web.UI.HtmlControls.HtmlInputText txDd1;
		protected System.Web.UI.HtmlControls.HtmlInputText txMm1;
		protected System.Web.UI.HtmlControls.HtmlInputText txYy1;
		protected System.Web.UI.HtmlControls.HtmlInputButton bnStar2;
		protected System.Web.UI.HtmlControls.HtmlInputButton bnCal2;
		protected RepaymentCycleTypeSelector RepaymentCycleTypeSelector1;
		protected System.Web.UI.WebControls.Literal litSchedule;
		protected RepaymentCountTypeSelector RepaymentCountTypeSelector1;

		protected int CurrentYear= SafeDateTime.LocalNow.Year;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.bnStar2.ServerClick += new System.EventHandler(this.bnStar2_ServerClick);
			this.bnCal2.ServerClick += new System.EventHandler(this.bnCal2_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void bnStar2_ServerClick(object sender, System.EventArgs e)
		{
			this.txDd1.Value="";
			this.txIncome.Value= "";
			this.txLoan.Value="";
			this.txMm1.Value="";
			this.litSchedule.Text= "";
			this.txYy1.Value= "";
		}

		private void bnCal2_ServerClick(object sender, System.EventArgs e)
		{
			this.CalcDateDue();
		}

		private void CalcDateDue()
		{
			DateTime timeFirstPay = new DateTime();
			DateTime timeSecondPay = new DateTime();
			DateTime timeThirdPay = new DateTime();
			DateTime timeAtOncePay = new DateTime();
			DateTime timeRecentlySalaryDate = new DateTime();

			try
			{
				timeRecentlySalaryDate = new DateTime(Convert.ToInt32(this.txYy1.Value), Convert.ToInt32(this.txMm1.Value), Convert.ToInt32(this.txDd1.Value));
			}
			catch{}

			string errorString = string.Empty;
			int numInstallmentCount= this.RepaymentCountTypeSelector1.SelectedRepaymentCountType;
			PaidPeriodTypes repaymentCycleType= this.RepaymentCycleTypeSelector1.SelectedRepaymentCycleType;
			int userSalaryType=0;

			bool isSuccessful= PayDaySchedule.CalculatePayDate(this.Page, numInstallmentCount, timeRecentlySalaryDate, userSalaryType,
				repaymentCycleType,ref timeFirstPay,ref timeSecondPay,ref timeThirdPay,
				ref timeAtOncePay, SafeDateTime.LocalNow, out errorString);

			if(isSuccessful == true)
			{
				float numIncomeOrBenefit= Convert.ToSingle(this.txIncome.Value);
				float numLoanAmount= Convert.ToSingle(this.txLoan.Value);
				isSuccessful = PayDaySchedule.CalculatePayLoan(this.Page, userSalaryType, numInstallmentCount, numIncomeOrBenefit,
					numLoanAmount,out errorString);
				if(isSuccessful==true)
				{
					string repaymentSchedule= string.Empty;
					string firstDate= string.Empty;
					string firstDue= string.Empty;

					string secondDate=string.Empty;
					string secondDue=string.Empty;

					string thirdDate=string.Empty;
					string thirdDue= string.Empty;
					
					
					switch(numInstallmentCount)
					{
						case 1:

							firstDate= timeFirstPay.ToString(Config.DateDisplayFormat);
							firstDue=  (Convert.ToSingle( this.Session["Repaydue1"])).ToString("0.00");
							repaymentSchedule = string.Format("[installment1]. {0} {1}",firstDate,firstDue);
							break;
						case 2:

							firstDate= timeFirstPay.ToString(Config.DateDisplayFormat);
							firstDue=  (Convert.ToSingle( this.Session["Repaydue1"])).ToString("0.00");

							secondDate= timeSecondPay.ToString(Config.DateDisplayFormat);
							secondDue=  (Convert.ToSingle( this.Session["Repaydue2"])).ToString("0.00");

							repaymentSchedule= string.Format("[installment1]. {0} {1}",firstDate,firstDue);
							repaymentSchedule+= "<br/>"+string.Format("[installment2]. {0} {1}",secondDate,secondDue);
							break;
						case 3:

							firstDate= timeFirstPay.ToString(Config.DateDisplayFormat);
							firstDue=  (Convert.ToSingle( this.Session["Repaydue1"])).ToString("0.00");

							secondDate= timeSecondPay.ToString(Config.DateDisplayFormat);
							secondDue=  (Convert.ToSingle( this.Session["Repaydue2"])).ToString("0.00");

							thirdDate= timeThirdPay.ToString(Config.DateDisplayFormat);
							thirdDue=  (Convert.ToSingle( this.Session["Repaydue3"])).ToString("0.00");

							repaymentSchedule= string.Format("[installment1]. {0} {1}",firstDate,firstDue);
							repaymentSchedule+="<br/>"+ string.Format("[installment2]. {0} {1}",secondDate,secondDue);
							repaymentSchedule+= "<br/>"+string.Format("[installment3]. {0} {1}",thirdDate,thirdDue);
							break;
						case 4:
							
							string atOnceDate= timeAtOncePay.ToString(Config.DateDisplayFormat);
							string atOnceDue = string.Empty;
							if (this.Session["XFirst2"] != null)
							{
								atOnceDue= Convert.ToString(this.Session["Repaydue4"]);
							}
							repaymentSchedule= string.Format("[installment1]. {0} {1}",atOnceDate,atOnceDue);
							break;
					}

					this.litSchedule.Text= repaymentSchedule;
				}
				else
				{
					this.Response.Write(errorString);
				}
			}
			else
			{
				this.Response.Write(errorString);
			}
		}
	}
}
