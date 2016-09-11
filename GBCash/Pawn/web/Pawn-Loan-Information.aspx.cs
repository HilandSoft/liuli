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
using YingNet.WeiXing.Business;
using YingNet.WeiXing.DB.Data;
using YingNet.WeiXing.STRUCTURE;
using YingNet.WeiXing.Business.CommonLogic;
using YingNet.WeiXing.WebApp.Include;
using YingNet.Common.Utils;
using YingNet.Common;
using System.Configuration;

namespace YingNet.WeiXing.WebApp.Pawn_Loans
{
	/// <summary>
	/// Pawn_Loan_Information 的摘要说明。
	/// </summary>
	public class Pawn_Loan_Information : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputText txLoan;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden1;
		protected System.Web.UI.WebControls.DropDownList installmentCount;
		protected System.Web.UI.WebControls.TextBox d1F;
		protected System.Web.UI.WebControls.TextBox s1;
		protected System.Web.UI.WebControls.TextBox d2F;
		protected System.Web.UI.WebControls.TextBox s2;
		protected System.Web.UI.WebControls.TextBox d3F;
		protected System.Web.UI.WebControls.TextBox s3;
		protected System.Web.UI.WebControls.Label labAnnualRate;
		protected System.Web.UI.HtmlControls.HtmlInputText txBank;
		protected System.Web.UI.HtmlControls.HtmlInputText txBranch;
		protected System.Web.UI.HtmlControls.HtmlInputText txAname;
		protected System.Web.UI.HtmlControls.HtmlInputText txBsb;
		protected System.Web.UI.HtmlControls.HtmlInputText txAnumber;
		protected System.Web.UI.HtmlControls.HtmlInputText txCAnumber;
		protected System.Web.UI.WebControls.TextBox txFullname;
		protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
		protected System.Web.UI.WebControls.TextBox nextPaydayDD;
		protected System.Web.UI.WebControls.TextBox installmentDays;
		protected System.Web.UI.WebControls.TextBox nextPaydayMM;
		protected System.Web.UI.WebControls.TextBox nextPaydayYYYY;
		protected System.Web.UI.WebControls.RadioButtonList payCircleType;
		protected System.Web.UI.WebControls.CheckBox GoldPackBack;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton installment0;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton installment1;
		protected System.Web.UI.WebControls.Button btnCalculate;

		
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			
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
			this.btnCalculate.Click += new System.EventHandler(this.btnCalculate_Click);
			this.Submit1.ServerClick += new System.EventHandler(this.Submit1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void btnCalculate_Click(object sender, System.EventArgs e)
		{
			this.d1F.Text = this.d2F.Text = this.d3F.Text = this.s1.Text = this.s2.Text = this.s3.Text = "";
			bool result= true;
			result= this.CalDateDue();
			if(result==true)
			{
				result= this.CalLoan();
			}
			if(result==true)
			{
				this.DisplayAnnualRate();
			}
		}

		private void DisplayAnnualRate()
		{
			//DropDownList1表示用户选择的周期数
			int numInstallmentCount = Convert.ToInt32(this.installmentCount.SelectedValue);
			PaidPeriodTypes paidPeriodType= GetPaidPeridType();
			string rateDisplay= AnnualPercentageRate.GetAnnualPercentageRatePercent(paidPeriodType,numInstallmentCount);
			
			this.labAnnualRate.Text=rateDisplay;//"486.89%";
			
			/* //暂时不显示年利率部分
			this.annualRateRow.Attributes["style"]="Display:block";
			this.annualRateRow.Visible= true;
			*/
		}

		private PaidPeriodTypes GetPaidPeridType()
		{
			PaidPeriodTypes result= PaidPeriodTypes.Weekly;
			
			string payCircleTypeValue= this.Request.Params["payCircleType"].ToLower();
			switch(payCircleTypeValue)
			{
				case "weekly":
					result= PaidPeriodTypes.Weekly;
					break;
				case "fnightly":
					result= PaidPeriodTypes.Fnightly;
					break;
				case "monthly":
					result= PaidPeriodTypes.Monthly;
					break;
			}

			return result;
		}

//		private PaidPeriodTypes GetSelectedRepaymentCycleType(int userLoanType)
//		{
//			
//			PaidPeriodTypes result= PaidPeriodTypes.Weekly;
//			
//			string payCircleTypeValue= this.Request.Params["payCircleType"].ToLower();
//			switch(payCircleTypeValue)
//			{
//				case "weekly":
//					result= PaidPeriodTypes.Weekly;
//					break;
//				case "fnightly":
//					result= PaidPeriodTypes.Fnightly;
//					break;
//				case "monthly":
//					result= PaidPeriodTypes.Monthly;
//					break;
//			}
//
//			return result;
//			
//		}

		public bool CalDateDue()
		{
			bool result= true;

			TimeSpan span3;
			DateTime timeFirstPay = new DateTime();
			DateTime timeSecondPay = new DateTime();
			DateTime timeThirdPay = new DateTime();
			DateTime timeAtOncePay = new DateTime();
			DateTime timeRecentlySalaryDate = new DateTime();
            
			int nextPaydayDD= 0;
			try
			{
				nextPaydayDD= int.Parse(this.Request.Params["nextPaydayDD"]);
			}
			catch{}

			int nextPaydayMM= 0;
			try
			{
				nextPaydayMM= int.Parse(this.Request.Params["nextPaydayMM"]);
			}
			catch{}

			int nextPaydayYYYY=0;
			try
			{
				nextPaydayYYYY= int.Parse(this.Request.Params["nextPaydayYYYY"]);
			}
			catch{}

			//DropDownList1表示用户选择的周期数
			int numInstallmentCount = Convert.ToInt32(this.installmentCount.SelectedValue);
			string installmentTypeValue= this.Request.Params["installmentType"];
			if(installmentTypeValue=="customDays")
			{
				numInstallmentCount=4;
			}

			if(numInstallmentCount!=4 &&( nextPaydayDD==0|| nextPaydayMM==0 ||nextPaydayYYYY==0))
			{
				result= false;
				RequestHelper.Alert("please input \"Next payday\",thanks.");
			}
			else
			{
				//DropDownList1表示用户选择的周期数
				if(numInstallmentCount==4)
				{
					int intInstallmentDays=0;
					try
					{
						intInstallmentDays= Convert.ToInt32(installmentDays.Text);
					}
					catch{}

					timeRecentlySalaryDate= SafeDateTime.LocalToday.AddDays(intInstallmentDays);
				}
				else
				{
					timeRecentlySalaryDate= new DateTime(nextPaydayYYYY,nextPaydayMM,nextPaydayDD);
				}

				int userLoanType = 0; //0原来表示有工作的人士。
       	
				string errorString = string.Empty;
        	
				bool isSuccessful= PayDaySchedule.CalculatePayDate(this.Page, numInstallmentCount, timeRecentlySalaryDate, userLoanType,
					GetPaidPeridType(),ref timeFirstPay,ref timeSecondPay,ref timeThirdPay,
					ref timeAtOncePay, SafeDateTime.LocalNow, out errorString);
        	
				if(isSuccessful == true)
				{
					string str = "";
					string str2 = "";
					string str3 = "";
					string str4 = "";
					str = timeFirstPay.ToShortDateString();
					this.d1F.Text = timeFirstPay.Day.ToString() + "/" + timeFirstPay.Month.ToString() + "/" + timeFirstPay.Year.ToString();
					switch (numInstallmentCount)
					{
						case 2:
							str2 = timeSecondPay.ToShortDateString();
							this.d2F.Text = timeSecondPay.Day.ToString() + "/" + timeSecondPay.Month.ToString() + "/" + timeSecondPay.Year.ToString();
							break;

						case 3:
							str2 = timeSecondPay.ToShortDateString();
							str3 = timeThirdPay.ToShortDateString();
							this.d2F.Text = timeSecondPay.Day.ToString() + "/" + timeSecondPay.Month.ToString() + "/" + timeSecondPay.Year.ToString();
							this.d3F.Text = timeThirdPay.Day.ToString() + "/" + timeThirdPay.Month.ToString() + "/" + timeThirdPay.Year.ToString();
							break;
						case 4:
							str4 = timeAtOncePay.ToShortDateString();
							this.d1F.Text = timeAtOncePay.Day.ToString() + "/" + timeAtOncePay.Month.ToString() + "/" + timeAtOncePay.Year.ToString();
							break;
					}
        	
					/*
					this.Session["Datedue1"] = str;
					this.Session["Datedue2"] = str2;
					this.Session["Datedue3"] = str3;
					this.Session["Datedue4"] = str4;
					*/
				}
				else
				{
					result= false;
					this.Response.Write(errorString);
				}
			}

			return result;
		}

		public bool CalLoan()
		{
			bool result= true;

			int userLoanType = 0;
			float numLoanAmount =0;

			try
			{
				numLoanAmount = Convert.ToSingle(this.txLoan.Value);
			}
			catch{}

			float numIncomeOrBenefit=100000;//设置一个比较大的值，使其在计算时满足贷款的最小条件

			
			
			//DropDownList1表示用户选择的周期数
			int numInstallmentCount = Convert.ToInt32(this.installmentCount.SelectedValue);
			string installmentTypeValue= this.Request.Params["installmentType"];
			if(installmentTypeValue=="customDays")
			{
				numInstallmentCount=4;
			}
            
			string errorString = string.Empty;
			result = PayDaySchedule.CalculatePayLoan(this.Page, userLoanType, numInstallmentCount, numIncomeOrBenefit,
				numLoanAmount, out errorString);
			if(result==true)
			{
				switch (numInstallmentCount)
				{
					case 1:
						this.s1.Text =Convert.ToString(this.Session["Repaydue1"]);
						break;
					case 2:
						this.s1.Text= Convert.ToString(this.Session["Repaydue1"]);
						this.s2.Text= Convert.ToString(this.Session["Repaydue2"]);
						break;
					case 3:
						this.s1.Text= Convert.ToString(this.Session["Repaydue1"]);
						this.s2.Text= Convert.ToString(this.Session["Repaydue2"]);
						this.s3.Text= Convert.ToString(this.Session["Repaydue3"]);
						break;
					case 4:
						if (this.Session["XFirst2"] != null)
						{
							this.s1.Text= Convert.ToString(this.Session["Repaydue4"]);
						}
						else
						{
							this.s1.Text = "";
						}
						break;
				}
				this.Session["Repayduezs"]= this.txLoan.Value;
			}
			else
			{
				this.Response.Write(errorString);
			}

			return result;
		}

		public void getHuiyuan()
		{
			HuiyuanBN nbn = new HuiyuanBN(this.Page);
			HuiyuanDT dt = nbn.Get(Convert.ToInt32(this.Session["huiSid"]));
			dt.IsValid = 0;

			nbn.Edit(dt);
			InfoBN obn = new InfoBN(this.Page);
			InfoDT odt = new InfoDT();
			odt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
			odt.Username = dt.Username;
			odt.type = "3";
			odt.regtime = SafeDateTime.LocalNow;
			odt.isvalid = 1;
			obn.Add(odt);
		}

		public void getInfo()
		{
			EmployedBN dbn = new EmployedBN(this.Page);
			EmployedDT dt = new EmployedDT();
			float num = 0f;
			
//				dt.Employer = this.txEmployer.Value;
//				dt.EAddress = this.txAddress.Value;
//				dt.EPhone = this.txPhone.Value;
//				dt.TYears = Convert.ToInt32(this.txYear.Value);
//				dt.TMonths = Convert.ToInt32(this.txMonth.Value);
//				dt.MIncome = Convert.ToSingle(this.txIncome.Value);
				dt.Wpaid = this.payCircleType.SelectedValue;


			int nextPaydayDD= 0;
			try
			{
				nextPaydayDD= int.Parse(this.Request.Params["nextPaydayDD"]);
			}
			catch{}

			int nextPaydayMM= 0;
			try
			{
				nextPaydayMM= int.Parse(this.Request.Params["nextPaydayMM"]);
			}
			catch{}

			int nextPaydayYYYY=0;
			try
			{
				nextPaydayYYYY= int.Parse(this.Request.Params["nextPaydayYYYY"]);
			}
			catch{}
				dt.NDayMM = nextPaydayMM;
				dt.NDayDD = nextPaydayDD;
				dt.NDayYY = nextPaydayYYYY;
				dt.IsEmployed = 1;
				//dt.Param5 = this.txJob.Value;

			dt.Branch = this.txBranch.Value;
			dt.BankName = this.txBank.Value;
			dt.AName = this.txAname.Value;
			dt.Bsb = this.txBsb.Value;
			dt.ANumber = this.txAnumber.Value;
//			dt.MContact = this.RadioButtonList4.SelectedValue;
//			dt.Rname1 = this.txReName1.Value;
//			dt.Rship1 = this.selReShip1.Value;
//			dt.Rnum1 = this.txReNum1.Value;
//			dt.Rname2 = this.txReName2.Value;
//			dt.Rship2 = this.selReShip2.Value;
//			dt.Rnum2 = this.txReNum2.Value;
//			dt.Rname3 = this.txReName3.Value;
//			dt.Rship3 = this.selReShip3.Value;
//			dt.Rnum3 = this.txReNum3.Value;
			dt.Param4 = this.txFullname.Text;
			dt.IsValid = 3;
			dt.Loan = Convert.ToSingle(this.txLoan.Value);
			dt.NInstallment = Convert.ToInt32(this.installmentCount.SelectedValue);
			dt.RTime = SafeDateTime.LocalNow;
            
			//dt.LoanPurpose= this.txtLoanPurpose.Text;
//			dt.HousePaymentCircle= EnumsOP.GetHousePaymentCircleByLiteral(this.ddlHousePaymentCircle.SelectedValue);
//			dt.HousePaymentValue= Convert.ToSingle(this.txtHousePaymentValue.Value);
//			dt.OtherLenderCircle= EnumsOP.GetOtherLenderCircleByLiteral(this.ddlOtherLenderCircle.SelectedValue);
//			dt.OtherLenderValue= Convert.ToSingle(this.txtOtherLenderValue.Value);
			
			DataTable list = new SystemInfoBN(this.Page).GetList();
			if (list.Rows.Count <= 0)
			{
				goto Label_0485;
			}
			dt.Interest = Convert.ToSingle(list.Rows[0]["interest"].ToString());
			
			PaidPeriodTypes paidPeriodType= GetPaidPeridType();
				switch (paidPeriodType)
				{
					case PaidPeriodTypes.Weekly:
						dt.Frequency = 7.0;
						goto Label_0463;

					case PaidPeriodTypes.Fnightly:
						dt.Frequency = 14.0;
						goto Label_0463;

					case PaidPeriodTypes.Monthly:
						dt.Frequency = Convert.ToSingle(list.Rows[0]["frequency"].ToString());
						goto Label_0463;
				}
			
			
			Label_0463:
				num = Convert.ToSingle(list.Rows[0]["poundage"].ToString());
			Label_0485:
				if (this.installmentCount.SelectedValue.Equals("4"))
				{
					dt.XDay = Convert.ToInt32(this.Session["XFirst2"]);
				}
				else
				{
					dt.XDay = Convert.ToInt32(this.Session["XFirst"]);
				}
			dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
			if (this.s1.Text != "")
			{
				dt.Param1 = Convert.ToSingle(this.s1.Text);
			}
			if ((this.s1.Text != "") && (this.s2.Text != ""))
			{
				dt.Param1 = Convert.ToSingle(this.s1.Text) + Convert.ToSingle(this.s2.Text);
			}
			if (((this.s1.Text != "") && (this.s2.Text != "")) && (this.s3.Text != ""))
			{
				dt.Param1 = (Convert.ToSingle(this.s1.Text) + Convert.ToSingle(this.s2.Text)) + Convert.ToSingle(this.s3.Text);
			}
			dt.Param2 = num * dt.NInstallment;
			dt.Param3 = 1;

			//将原来保存在huiyuan中的Pawn信息复制到Employeed中
			HuiyuanBN nbn = new HuiyuanBN(this.Page);
			HuiyuanDT dtHuiyuan = nbn.Get(Convert.ToInt32(this.Session["huiSid"]));
			dt.ItemCondition= dtHuiyuan.ItemCondition;
			dt.ItemDescription= dtHuiyuan.ItemDescription;
			dt.ItemPhoto= dtHuiyuan.ItemPhoto;
			dt.ItemToPawn= dtHuiyuan.ItemToPawn;
			
			if(this.GoldPackBack.Checked==true)
			{
				dt.NeedGoldPack= 1;
			}
			else
			{
				dt.NeedGoldPack=0;
			}

			string installmentTypeValue= this.Request.Params["installmentType"];
			if(installmentTypeValue=="customDays")
			{
				int oncePaymentInDays=0;
				try
				{
					oncePaymentInDays= int.Parse(installmentDays.Text);
				}
				catch{}

				dt.OncePaymentInDays= oncePaymentInDays;
			}
			else
			{
				dt.OncePaymentInDays= 0;
			}

			this.Hidden1.Value = dbn.Add2(dt).ToString();
		}

		public void getSchedule()
		{
			ScheduleBN ebn = new ScheduleBN(this.Page);
			ScheduleDT dt = null;
			//this.DropDownList1表示分期还款的方式(分1,2,3期等)
			int numInstallmentCount = Convert.ToInt32(this.installmentCount.SelectedValue);
			string installmentTypeValue= this.Request.Params["installmentType"];
			if(installmentTypeValue=="customDays")
			{
				numInstallmentCount=4;
			}

			switch (numInstallmentCount)
			{
				case 1:
					dt = new ScheduleDT();
					dt.Datedue = Convert.ToDateTime(this.Session["Datedue1"]);
					dt.Repaydue = Convert.ToSingle(this.Session["Repaydue1"]);
					dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
					dt.Numberment = 1;
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
					dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
					dt.Numberment = 1;
					dt.Param1 = this.Hidden1.Value;
					dt.Param2 = "0";
					dt.Balance = Convert.ToSingle(this.Session["Repaydue1"]);
					dt.RepayTime = Convert.ToDateTime("2000-1-1");
					dt.OperateTime = Convert.ToDateTime("2000-1-1");
					ebn.Add(dt);
					dt = new ScheduleDT();
					dt.Datedue = Convert.ToDateTime(this.Session["Datedue2"]);
					dt.Repaydue = Convert.ToSingle(this.Session["Repaydue2"]);
					dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
					dt.Numberment = 1;
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
					dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
					dt.Numberment = 1;
					dt.Param1 = this.Hidden1.Value;
					dt.Param2 = "0";
					dt.Balance = Convert.ToSingle(this.Session["Repaydue1"]);
					dt.RepayTime = Convert.ToDateTime("2000-1-1");
					dt.OperateTime = Convert.ToDateTime("2000-1-1");
					ebn.Add(dt);
					dt = new ScheduleDT();
					dt.Datedue = Convert.ToDateTime(this.Session["Datedue2"]);
					dt.Repaydue = Convert.ToSingle(this.Session["Repaydue2"]);
					dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
					dt.Numberment = 1;
					dt.Param1 = this.Hidden1.Value;
					dt.Param2 = "0";
					dt.Balance = Convert.ToSingle(this.Session["Repaydue1"]) + Convert.ToSingle(this.Session["Repaydue2"]);
					dt.RepayTime = Convert.ToDateTime("2000-1-1");
					dt.OperateTime = Convert.ToDateTime("2000-1-1");
					ebn.Add(dt);
					dt = new ScheduleDT();
					dt.Datedue = Convert.ToDateTime(this.Session["Datedue3"]);
					dt.Repaydue = Convert.ToSingle(this.Session["Repaydue3"]);
					dt.huiSid = Convert.ToInt32(this.Session["huiSid"]);
					dt.Numberment = 1;
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
					dt.Numberment = 1;
					dt.Param1 = this.Hidden1.Value;
					dt.Param2 = "0";
					dt.Balance = Convert.ToSingle(this.Session["Repaydue4"]);
					dt.RepayTime = Convert.ToDateTime("2000-1-1");
					dt.OperateTime = Convert.ToDateTime("2000-1-1");
					ebn.Add(dt);
					break;
			}
		}

		private void Submit1_ServerClick(object sender, System.EventArgs e)
		{
			if ((this.d1F.Text == "") || (this.s1.Text == ""))
			{
				base.Response.Write("<script>alert(\"Please click 'Calculate' button for repayment schedule before you submit the application.\");</script>");
			}
			else if (this.txFullname.Text == "")
			{
				base.Response.Write("<script>alert('You need to sign by tying in your FULL name before submission.');</script>");
			}
			else if (this.Session["Repayduezs"]==null || this.Session["Repayduezs"].ToString() != this.txLoan.Value)
			{
				base.Response.Write("<script>alert(\"Please click 'Calculate' button for repayment schedule before you submit the application.\");</script>");
			}
			else
			{
				try
				{
					this.Session["NumberLoanI"] = this.installmentCount.SelectedValue;
					this.getInfo();
					this.getSchedule();
					this.getHuiyuan();

					//发送注册成功邮件
					YingNet.Common.SimpleMailSneder.SendMail(DateTime.Now.ToString()+ "New Pawn Register","please to check.",ConfigurationSettings.AppSettings["notificationMailTO"]);
					base.Response.Write("<script>window.top.location='Pawn-Loan-Result.aspx';</script>");
				}
				catch (Exception exception)
				{
					base.Response.Write(exception.Message);
				}
			}
		}
	}
}
