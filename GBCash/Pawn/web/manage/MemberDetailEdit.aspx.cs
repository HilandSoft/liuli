using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YingNet.WeiXing.Business;
using YingNet.WeiXing.DB.Data;
using YingNet.WeiXing.Business.CommonLogic;
using YingNet.WeiXing.WebApp.Include;
using YingNet.WeiXing.STRUCTURE;
using YingNet.Common.Utils;

namespace YingNet.WeiXing.WebApp.manage
{
	/// <summary>
	/// MemberDetailEdit_aspx 的摘要说明。
	/// </summary>
	public class MemberDetailEdit :  ManageBasePage
	{
		protected TextBox TextBox15;
		protected TextBox TextBox28;
		protected HtmlInputButton SaveButton;

		public string dlTitle="",txFname="",txLname="", txMname="", txDate="", txEmail="", txIssue="",txDriver="",txResident="";
		public string txStreet="",txCity="",selState="",txPost="",txYeard="",txMonthd="",txTel="",txMobile="",txFax="";
		public string txEmployer="",txAddress="",txPhone="",txYear="",txMonth="",txIncome="",paid="",txMm1="",txDd1="",txYy1="",IsEmployed="",txJob="";
		public string EmploymentInfo="",tip1="",tip2="",tip3="",tip4="",tip5="",tip6="",tip7="";
		public string Branch="",BankName="",AName="",Bsb="",ANumber="";
		public string d1="",s1="",d2="",s2="",d3="",s3="";
		public string MContact="",Rname1="",Rname2="",Rname3="",Rship1="",Rship2="",Rship3="",Rnum1="",Rnum2="",Rnum3="";
		protected TextBox txtTitle;
		protected TextBox txtFname;
		protected TextBox txtLname;
		protected TextBox txtEmail;
		protected TextBox txtDriver;
		protected TextBox txtResident;
		protected TextBox txtIssue;
		protected TextBox txtCity;
		protected TextBox txtBankName;
		protected TextBox txtBranch;
		protected TextBox txtAName;
		protected TextBox txtBsb;
		protected TextBox txtANumber;
		protected TextBox txtMContact;
		protected TextBox txtRname1;
		protected TextBox txtRship1;
		protected TextBox txtRship2;
		protected TextBox txtRnum1;
		protected TextBox txtRnum2;
		protected TextBox txtRnum3;
		protected TextBox txtRname2;
		protected TextBox txtRname3;
		protected TextBox txtRship3;
		protected TextBox txtRnum;
		protected TextBox txtPost;
		protected TextBox txtMm1;
		protected TextBox txtDd1;
		protected TextBox txtTelphone;
		protected DropDownList ddlState;
		protected TextBox txtYy1;
		protected Button btnCalculate;
		protected System.Web.UI.WebControls.TextBox d1F;
		protected System.Web.UI.WebControls.TextBox s1F;
		protected System.Web.UI.WebControls.TextBox d2F;
		protected System.Web.UI.WebControls.TextBox s2F;
		protected System.Web.UI.WebControls.TextBox d3F;
		protected System.Web.UI.WebControls.TextBox s3F;
		protected System.Web.UI.WebControls.TextBox txtDate;
		protected YingNet.Common.PerRadioButtonList PerRadioButtonList1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtLoan;
		protected System.Web.UI.WebControls.TextBox installmentDays;
		protected System.Web.UI.WebControls.DropDownList installmentCount;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton installment0;
		protected System.Web.UI.HtmlControls.HtmlInputRadioButton installment1;
		protected HtmlInputHidden Hidden1;

		protected System.Web.UI.WebControls.DropDownList drpItems;
		protected System.Web.UI.WebControls.TextBox txtPhotoNumber;
		protected System.Web.UI.WebControls.TextBox txItemDescription;
		protected System.Web.UI.WebControls.DropDownList drpItemCondition;
	
		private void Page_Load(object sender, EventArgs e)
		{
			if(!Page.IsPostBack) 
			{
				this.BindState();

				int id=Convert.ToInt32(Request["id"]);
				this.Hidden1.Value=id.ToString();
				HuiyuanBN bn=new HuiyuanBN(this.Page);
				bn.QuerySid(id.ToString());
				DataTable dt=bn.GetList();
				if(dt.Rows.Count>0)
				{
					DataRow row= dt.Rows[0];
					if(row!=null)
					{
						//this.txtTitle.Text= row["Param2"].ToString();
						this.txtFname.Text= row["Fname"].ToString();
						this.txtLname.Text= row["Lname"].ToString();
//						this.txtMname.Text= row["Mname"].ToString();
						this.txtDate.Text= Convert.ToDateTime(row["DBirth"]).ToString("dd/MM/yyyy");
						this.txtEmail.Text= row["Email"].ToString();

						this.txtIssue.Text=dt.Rows[0]["Issued"].ToString();
						this.txtDriver.Text=dt.Rows[0]["DNumber"].ToString();
						this.txtResident.Text=dt.Rows[0]["SAddress"].ToString();
						this.txtCity.Text=dt.Rows[0]["City"].ToString();
						
						ListItem stateItem= new ListItem(dt.Rows[0]["State"].ToString());
						if(this.ddlState.Items.Contains(stateItem))
						{
							this.ddlState.SelectedValue= stateItem.Value;
						}

						this.txtPost.Text=dt.Rows[0]["Postcode"].ToString();


//						this.txtYeard.Text=dt.Rows[0]["TYears"].ToString();
//						this.txtMonthd.Text=dt.Rows[0]["TMonths"].ToString();
						this.txtTelphone.Text=dt.Rows[0]["HTel"].ToString();
//						this.txtMobile.Text=dt.Rows[0]["Mobile"].ToString();
//						this.txtFax.Text=dt.Rows[0]["Param1"].ToString();
						
						//现在这个日期 取用 最后一次贷款的日期
						//this.ViewState["RegTime"] = dt.Rows[0]["Regtime"].ToString();
					}
				}

				EmployedBN  bn2=new EmployedBN(this.Page);
				bn2.QueryhuiSid(this.Hidden1.Value);
				bn2.Order = "id";
				//bn2.QueryParam3("1");  //第一次贷款
				DataTable dt2=bn2.GetList();

				if(dt2.Rows.Count>0)
				{
					//1.首先把这行的ID写入ViewState中供 保存信息使用
					this.ViewState["Employed.ID"]= dt2.Rows[0]["id"].ToString();


//					this.txtEmployer.Text=dt2.Rows[0]["Employer"].ToString();
//					this.txtAddress.Text=dt2.Rows[0]["EAddress"].ToString();
//					this.txtPhone.Text=dt2.Rows[0]["EPhone"].ToString();
//					this.txtYear.Text=dt2.Rows[0]["TYears"].ToString();
//					this.txtMonth.Text=dt2.Rows[0]["TMonths"].ToString();
//					this.txtIncome.Text=Convert.ToSingle(dt2.Rows[0]["MIncome"]).ToString("0.00");
					
					
					this.IsEmployed=dt2.Rows[0]["IsEmployed"].ToString();

					this.txtBranch.Text=dt2.Rows[0]["Branch"].ToString();
					this.txtBankName.Text=dt2.Rows[0]["BankName"].ToString();
					this.txtAName.Text=dt2.Rows[0]["AName"].ToString();
					this.txtBsb.Text=dt2.Rows[0]["Bsb"].ToString();
					this.txtANumber.Text=dt2.Rows[0]["ANumber"].ToString();


					this.txtMContact.Text=dt2.Rows[0]["MContact"].ToString();
//					this.txtRname1.Text=dt2.Rows[0]["Rname1"].ToString();
//					this.txtRname2.Text=dt2.Rows[0]["Rname2"].ToString();
//					this.txtRname3.Text=dt2.Rows[0]["Rname3"].ToString();
//					this.txtRship1.Text=dt2.Rows[0]["Rship1"].ToString();
//					this.txtRship2.Text=dt2.Rows[0]["Rship2"].ToString();
//					this.txtRship3.Text=dt2.Rows[0]["Rship3"].ToString();
//					this.txtRnum1.Text=dt2.Rows[0]["Rnum1"].ToString();
//					this.txtRnum2.Text=dt2.Rows[0]["Rnum2"].ToString();
//					this.txtRnum3.Text=dt2.Rows[0]["Rnum3"].ToString();

//					this.txtJob.Text =dt2.Rows[0]["Param5"].ToString();
					
					//2.贷款数额和还款期数要从最后一次贷款中去取,同时这行的ID保存起来供后面Schedule的修改使用
					//TODO:Calc也需要修改
					int lastLoanIndex = dt2.Rows.Count - 1;
					this.ViewState["Employed.ID.ModifyLoan"]= dt2.Rows[lastLoanIndex]["id"].ToString();
					this.txtLoan.Value = Convert.ToString(dt2.Rows[lastLoanIndex]["Loan"]);
					
					if(dt2.Rows[lastLoanIndex]["OncePaymentInDays"]!=null && (int)dt2.Rows[lastLoanIndex]["OncePaymentInDays"]!=0)
					{
						installment0.Checked= true;																									  
						installment1.Checked= false;

						installmentDays.Text= dt2.Rows[lastLoanIndex]["OncePaymentInDays"].ToString();
					}
					else
					{
						installment0.Checked= false;																										  
						installment1.Checked= true;

						if(dt2.Rows[lastLoanIndex]["NInstallment"]!=null)
						{
							installmentCount.SelectedValue= dt2.Rows[lastLoanIndex]["NInstallment"].ToString();
						}
					}
					
					//为了兼容原来的数据,先取最后一次贷款的信息,取不到时,再取第一条的信息.
					DataRow displayLoanRow= null;
					if(dt2.Rows[lastLoanIndex]["Wpaid"] == DBNull.Value ||dt2.Rows[lastLoanIndex]["Wpaid"].ToString()==string.Empty)
					{
						displayLoanRow= dt2.Rows[0];
					}
					else
					{
						displayLoanRow= dt2.Rows[lastLoanIndex];
					}

					string tempWPaid= displayLoanRow["Wpaid"].ToString();
					ListItem tempItem= new ListItem(tempWPaid,tempWPaid);
					if(this.PerRadioButtonList1.Items.Contains(tempItem))
					{
						this.PerRadioButtonList1.SelectedValue = tempItem.Value;
					}
					
					this.txtMm1.Text=displayLoanRow["NDayMM"].ToString();
					this.txtDd1.Text=displayLoanRow["NDayDD"].ToString();
					this.txtYy1.Text=displayLoanRow["NDayYY"].ToString();
						
					this.ViewState["RegTime"] = displayLoanRow["Rtime"].ToString();


					this.drpItems.SelectedValue= displayLoanRow["ItemToPawn"].ToString();
					this.drpItemCondition.SelectedValue= displayLoanRow["ItemCondition"].ToString();
					this.txItemDescription.Text= displayLoanRow["ItemDescription"].ToString();
					this.txtPhotoNumber.Text= displayLoanRow["ItemPhotoNumber"].ToString();


//					this.txtLoanPurpose.Text= displayLoanRow["LoanPurpose"].ToString();
//					this.txtHousePaymentValue.Value= displayLoanRow["HousePaymentValue"].ToString();
//					this.txtOtherLenderValue.Value= displayLoanRow["OtherLenderValue"].ToString();
//					this.ddlHousePaymentCircle.SelectedValue= EnumsOP.GetHousePaymentCircleLiteral(displayLoanRow["HousePaymentCircle"]);
//					this.ddlOtherLenderCircle.SelectedValue= EnumsOP.GetOtherLenderCircleLiteral(displayLoanRow["OtherLenderCircle"]);
					//-------------------------------------------------------------------------------------------------------

			
					if(this.IsEmployed.Equals("1")) //被雇佣
					{
						this.tip1="Your Occupation:";
						this.tip2="Employer:";
						this.tip3="Employer’s Address:";
						this.tip4="Employer Phone:";
						this.tip5="Time Employed: ";
						this.tip6="Net Income: ";
						this.tip7="JobTitle: ";
						
						this.ViewState["userLoanType"] = "0";
					}
					else
					{
						this.tip1="";
						this.tip2="Type of benefit:";
						this.tip3="Centreline Office:";
						this.tip4="Contact Name:";
						this.tip5="How long on this benefit: ";
						this.tip6="Benefit:";
						
						this.ViewState["userLoanType"] = "1";
					}
				}
			}
		}


		private void BindState()
		{
			this.ddlState.Items.Add("ACT");
			this.ddlState.Items.Add("QLD");
			this.ddlState.Items.Add("NSW");
			this.ddlState.Items.Add("NT");
			this.ddlState.Items.Add("SA");
			this.ddlState.Items.Add("TAS");
			this.ddlState.Items.Add("VIC");
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
			this.SaveButton.ServerClick += new System.EventHandler(this.SaveButton_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion


		/// <summary>
		/// 当前选择的用户还款周期的类型
		/// </summary>
		private PaidPeriodTypes SelectedRepaymentCycleType
		{
			get
			{
				PaidPeriodTypes result= PaidPeriodTypes.Weekly;
				RadioButtonList radio= this.PerRadioButtonList1;
			
				switch(radio.SelectedValue.ToLower())
				{
					case "weekly":
						result= PaidPeriodTypes.Weekly;
						break;
					case "f'nightly":
						result= PaidPeriodTypes.Fnightly;
						break;
					case "monthly":
						result= PaidPeriodTypes.Monthly;
						break;
				}

				return result;
			}
		}

		private void btnCalculate_Click(object sender, EventArgs e)
		{
			int userLoanType= 0;
			if(this.ViewState["IsEmployed"]!=null)
			{
				try
				{
					userLoanType = Convert.ToInt32(this.ViewState["IsEmployed"]);
				}
				catch
				{
				}
			}
			
			DateTime userRegTime = SafeDateTime.LocalNow;
			
			/* //when we edit the repayment schedule (re-calculate from management site), the date of loan should change to the current date
			if(this.ViewState["RegTime"]!=null)
			{
				try
				{
					userRegTime = Convert.ToDateTime(this.ViewState["RegTime"]);
				}
				catch
				{
				}
			}*/
			
			DateTime timeFirstPay = new DateTime();
			DateTime timeSecondPay = new DateTime();
			DateTime timeThirdPay = new DateTime();
			DateTime timeAtOncePay = new DateTime();
			DateTime timeRecentlySalaryDate = new DateTime();

			int nextPaydayDD= 0;
			try
			{
				nextPaydayDD= int.Parse(txtDd1.Text);
			}
			catch{}

			int nextPaydayMM= 0;
			try
			{
				nextPaydayMM= int.Parse(txtMm1.Text);
			}
			catch{}

			int nextPaydayYYYY=0;
			try
			{
				nextPaydayYYYY= int.Parse(txtYy1.Text);
			}
			catch{}


			int numInstallmentCount = Convert.ToInt32(this.installmentCount.SelectedValue);
			string installmentTypeValue= this.Request.Params["installmentType"];
			if(installmentTypeValue=="customDays")
			{
				numInstallmentCount=4;
			}

			if(numInstallmentCount!=4 &&( nextPaydayDD==0|| nextPaydayMM==0 ||nextPaydayYYYY==0))
			{
				this.Response.Write("please input \"Next payday\",thanks.");
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

				string errorString = string.Empty;
				bool calcSuccessful= PayDaySchedule.CalculatePayDate(this.Page, numInstallmentCount,timeRecentlySalaryDate,userLoanType,
					SelectedRepaymentCycleType,ref timeFirstPay,ref timeSecondPay,ref timeThirdPay,ref timeAtOncePay,userRegTime ,out errorString);
			
				if(calcSuccessful==true)
				{
					//HACK:xieran20130204 为了计算出的可以贷款的额度能够满足需求，此处暂定人员收入为100000元
					float incomeSalary= 100000;
					calcSuccessful =
						PayDaySchedule.CalculatePayLoan(this.Page, userLoanType, numInstallmentCount,
						incomeSalary,Convert.ToSingle(this.txtLoan.Value),out errorString);
					if(calcSuccessful==true)
					{
						this.d1F.Text = string.Empty;
						this.s1F.Text = string.Empty;
						this.d2F.Text = string.Empty;
						this.s2F.Text = string.Empty;
						this.d3F.Text = string.Empty;
						this.s3F.Text = string.Empty;
					
						switch(numInstallmentCount)
						{
							case 1:
								this.d1F.Text = this.Session["Datedue1"].ToString(); 
								this.s1F.Text = this.Session["Repaydue1"].ToString();
								break;
							case 2:
								this.d1F.Text = this.Session["Datedue1"].ToString(); 
								this.s1F.Text = this.Session["Repaydue1"].ToString();
							
								this.d2F.Text = this.Session["Datedue2"].ToString(); 
								this.s2F.Text = this.Session["Repaydue2"].ToString();
								break;
							case 3:
								this.d1F.Text = this.Session["Datedue1"].ToString(); 
								this.s1F.Text = this.Session["Repaydue1"].ToString();
								this.d2F.Text = this.Session["Datedue2"].ToString(); 
								this.s2F.Text = this.Session["Repaydue2"].ToString();
								this.d3F.Text = this.Session["Datedue3"].ToString(); 
								this.s3F.Text = this.Session["Repaydue3"].ToString();
								break;
							case 4:
								this.d1F.Text = this.Session["Datedue4"].ToString(); 
								this.s1F.Text = this.Session["Repaydue4"].ToString();
								break;
						}
					
						this.ViewState["CalcResult"] = "true";
					}
					else
					{
						this.Response.Write(errorString);
						this.ViewState["CalcResult"] = "false";
					}
				}
				else
				{
					this.Response.Write(errorString);
					this.ViewState["CalcResult"] = "false";
				}
			}
		}
		
		private void SaveButton_ServerClick(object sender, EventArgs e)
		{
			if(this.ViewState["CalcResult"]!=null)
			{
				bool tempBool = Convert.ToBoolean(this.ViewState["CalcResult"]);
				if(tempBool==false)
				{
					this.Response.Write("<script>alert(\"There is a mistake in Calc step. Please modify and continue.\")</script>");
					return;
				}
			}
			
			int memberID= Convert.ToInt32(this.Hidden1.Value);
			HuiyuanBN memberBN= new HuiyuanBN(this.Page);
			EmployedBN empBN= new EmployedBN(this.Page);

			HuiyuanDT memberDT= new HuiyuanDT();
			memberDT= memberBN.Get(memberID);

			EmployedDT empProfileDT= new EmployedDT();
			EmployedDT empLoanDT= new EmployedDT();
			
			memberDT.City= this.txtCity.Text;
			
			//1.更新Huiyuan信息
			try
			{
				string[] tempInts=this.txtDate.Text.Split('-','/');
				int tempYear= Convert.ToInt32(tempInts[2]);
				int tempMonth= Convert.ToInt32(tempInts[1]);
				int tempDay= Convert.ToInt32(tempInts[0]);
				memberDT.DBirth= new DateTime(tempYear,tempMonth,tempDay);
			}
			catch
			{}

			memberDT.DNumber= txtDriver.Text;
			memberDT.Email= txtEmail.Text;
			memberDT.Fname= txtFname.Text;
			memberDT.HTel= txtTelphone.Text;
			memberDT.Issued= txtIssue.Text;
			memberDT.Lname= txtLname.Text;
//			memberDT.Mname= txtMname.Text;
//			memberDT.Mobile= txtMobile.Text;
			memberDT.Postcode= txtPost.Text;
			//memberDT.RAddress= txtResident.Text;
			memberDT.SAddress= txtResident.Text;
			memberDT.State= ddlState.SelectedValue;
//			try
//			{
//				memberDT.TMonths= Convert.ToInt32( txtMonthd.Text);
//				memberDT.TYears= Convert.ToInt32(txtYeard.Text);
//			}
//			catch
//			{}

//			memberDT.Param1= txtFax.Text;
//			memberDT.Param2= txtTitle.Text;

			memberBN.Edit(memberDT);

			//2.更新Employee信息
			if(this.ViewState["Employed.ID"]!=null)
			{
				empProfileDT= empBN.Get(Convert.ToInt32(this.ViewState["Employed.ID"]));
			}
			else
			{
				empProfileDT= new EmployedDT();
			}
			
			if(this.ViewState["Employed.ID.ModifyLoan"]!=null)
			{
				empLoanDT = empBN.Get(Convert.ToInt32(this.ViewState["Employed.ID.ModifyLoan"]));
			}
			else
			{
				empLoanDT= new EmployedDT();
			}

			if(empProfileDT.id== empLoanDT.id)
			{
				empLoanDT= empProfileDT;
			}
			
			
			empProfileDT.AName= txtAName.Text;
			empProfileDT.ANumber= txtANumber.Text;
			empProfileDT.BankName= txtBankName.Text;
			empProfileDT.Branch= txtBranch.Text;
			empProfileDT.Bsb= txtBsb.Text;
//			empProfileDT.EAddress= txtAddress.Text;
//			empProfileDT.Employer= txtEmployer.Text;
//			empProfileDT.EPhone= txtPhone.Text;
			empProfileDT.MContact= txtMContact.Text;
//			try
//			{
//				empProfileDT.MIncome=Convert.ToSingle( txtIncome.Text);
//			}
//			catch
//			{}	
//				
//			empProfileDT.Param5= txtJob.Text;

//			empProfileDT.Rname1= txtRname1.Text;
//			empProfileDT.Rname2= txtRname2.Text;
//			empProfileDT.Rname3= txtRname3.Text;
//			empProfileDT.Rnum1= txtRnum1.Text;
//			empProfileDT.Rnum2= txtRnum2.Text;
//			empProfileDT.Rnum3= txtRnum3.Text;
//			empProfileDT.Rship1= txtRship1.Text;
//			empProfileDT.Rship2= txtRship2.Text;
//			empProfileDT.Rship3= txtRship3.Text;

//			try
//			{
//				empProfileDT.TMonths= Convert.ToInt32( txtMonth.Text);
//				empProfileDT.TYears= Convert.ToInt32( txtYear.Text);
//			}
//			catch
//			{}

			empLoanDT.ItemCondition= this.drpItemCondition.SelectedValue;
			empLoanDT.ItemDescription= this.txItemDescription.Text;
			empLoanDT.ItemToPawn= this.drpItems.SelectedValue;
			empLoanDT.ItemPhotoNumber= this.txtPhotoNumber.Text;

			
			try
			{
				empLoanDT.NDayDD= Convert.ToInt32( txtDd1.Text);
				empLoanDT.NDayMM= Convert.ToInt32( txtMm1.Text);
				empLoanDT.NDayYY= Convert.ToInt32( txtYy1.Text);
			}
			catch
			{}
			
			empLoanDT.Wpaid= this.PerRadioButtonList1.SelectedValue;
			if(installment0.Checked==true)
			{
				empLoanDT.NInstallment= 0;
				int oncePaymentInDays=0;
				try
				{
					oncePaymentInDays= int.Parse(this.installmentDays.Text);
				}
				catch{}

				empLoanDT.OncePaymentInDays=  oncePaymentInDays;
			}
			else
			{
				empLoanDT.OncePaymentInDays=0;
				empLoanDT.NInstallment = Convert.ToInt32(this.installmentCount.SelectedValue);
			}


			try
			{
				empLoanDT.Loan = Convert.ToSingle(this.txtLoan.Value);
			}
			catch
			{
			}
			
			if(this.ViewState["CalcResult"]!=null)
			{
				bool tempBool = Convert.ToBoolean(this.ViewState["CalcResult"]);
				if(tempBool==true)
				{
					int numInstallmentCount = Convert.ToInt32(this.installmentCount.SelectedValue);
					string installmentTypeValue= this.Request.Params["installmentType"];
					if(installmentTypeValue=="customDays")
					{
						numInstallmentCount=4;
					}
					switch(numInstallmentCount)
					{
						case 1:
							empLoanDT.Param1 = Convert.ToSingle(this.Session["Repaydue1"]);
							break;
						case 2:
							empLoanDT.Param1=Convert.ToSingle(this.Session["Repaydue1"])+ Convert.ToSingle(this.Session["Repaydue2"]);
							break;
						case 3:
							empLoanDT.Param1= Convert.ToSingle(this.Session["Repaydue1"])+ Convert.ToSingle(this.Session["Repaydue2"])+ Convert.ToSingle(this.Session["Repaydue3"]);
							break;
						case 4:
							empLoanDT.Param1= Convert.ToSingle(this.Session["Repaydue4"]);
							break;
					}
					DataTable list = new SystemInfoBN(this.Page).GetList();
					if(list.Rows.Count>0)
					{
						empLoanDT.Param2= Convert.ToSingle(list.Rows[0]["poundage"].ToString()) * empLoanDT.NInstallment;
					}
					
					//要把会员的注册日期,改成修改日期.
					empLoanDT.RTime = SafeDateTime.LocalNow;
				}
			}

			if(this.ViewState["Employed.ID"]!=null)
			{
				empBN.Edit(empProfileDT);
			}
			else
			{
				//TODO:未完成的雇员信息,暂时不去处理. qqbbs20080814
				//empBN.Add(empProfileDT);
			}
			
			if(this.ViewState["Employed.ID.ModifyLoan"]!=null)
			{
				empBN.Edit(empLoanDT);
			}
			else
			{
				//TODO:未完成的雇员信息,暂时不去处理. qqbbs20080814
				//empBN.Add(empLoanDT);
			}

			//empLoanDT.LoanPurpose= this.txtLoanPurpose.Text;
			
//			empLoanDT.HousePaymentCircle= EnumsOP.GetHousePaymentCircleByLiteral(this.ddlHousePaymentCircle.SelectedValue);
//			try
//			{
//				empLoanDT.HousePaymentValue= Convert.ToSingle(this.txtHousePaymentValue.Value);
//			}
//			catch{}
//
//			empLoanDT.OtherLenderCircle= EnumsOP.GetOtherLenderCircleByLiteral(this.ddlOtherLenderCircle.SelectedValue);
//			try
//			{
//				empLoanDT.OtherLenderValue= Convert.ToSingle(this.txtOtherLenderValue.Value);
//			}
//			catch{}
			
			
			//3.更新Schedule信息
			if(this.ViewState["CalcResult"]!=null)
			{
				bool tempBool = Convert.ToBoolean(this.ViewState["CalcResult"]);
				if(tempBool==true)
				{
					ScheduleBN scheduleBN = new ScheduleBN(this.Page);
					//1.首先删除旧的Schedule信息
					if(this.ViewState["Employed.ID.ModifyLoan"]!=null)
					{
						scheduleBN.DelByEmployedID(Convert.ToInt32(this.ViewState["Employed.ID.ModifyLoan"]));
					}
					
					//2.添加新的Schedule信息
					ScheduleDT dt = null;
					int empID = 0;
					if(this.ViewState["Employed.ID.ModifyLoan"]!=null)
					{
						empID= Convert.ToInt32(this.ViewState["Employed.ID.ModifyLoan"]);
					}


					int numInstallmentCount = Convert.ToInt32(this.installmentCount.SelectedValue);
					string installmentTypeValue= this.Request.Params["installmentType"];
					if(installmentTypeValue=="customDays")
					{
						numInstallmentCount=4;
					}

					switch(numInstallmentCount)
					{
						case 1:
							dt = new ScheduleDT();
							dt.Datedue = Convert.ToDateTime(this.Session["Datedue1"]);
							dt.Repaydue = Convert.ToSingle(this.Session["Repaydue1"]);
							dt.huiSid = memberID;
							dt.Numberment = 1;
							dt.Param1 = empID.ToString();
							dt.Param2 = "0";
							dt.Balance = Convert.ToSingle(this.Session["Repaydue1"]);
							dt.RepayTime = Convert.ToDateTime("2000-1-1");
							dt.OperateTime = Convert.ToDateTime("2000-1-1");
							scheduleBN.Add(dt);
							break;
						case 2:
							dt = new ScheduleDT();
							dt.Datedue = Convert.ToDateTime(this.Session["Datedue1"]);
							dt.Repaydue = Convert.ToSingle(this.Session["Repaydue1"]);
							dt.huiSid = memberID;
							dt.Numberment = 1;
							dt.Param1 = empID.ToString();
							dt.Param2 = "0";
							dt.Balance = Convert.ToSingle(this.Session["Repaydue1"]);
							dt.RepayTime = Convert.ToDateTime("2000-1-1");
							dt.OperateTime = Convert.ToDateTime("2000-1-1");
							scheduleBN.Add(dt);
							
							dt = new ScheduleDT();
							dt.Datedue = Convert.ToDateTime(this.Session["Datedue2"]);
							dt.Repaydue = Convert.ToSingle(this.Session["Repaydue2"]);
							dt.huiSid = memberID;
							dt.Numberment = 1;
							dt.Param1 = empID.ToString();
							dt.Param2 = "0";
							dt.Balance = Convert.ToSingle(this.Session["Repaydue1"])+ Convert.ToSingle(this.Session["Repaydue2"]);
							dt.RepayTime = Convert.ToDateTime("2000-1-1");
							dt.OperateTime = Convert.ToDateTime("2000-1-1");
							scheduleBN.Add(dt);
							break;
						case 3:
							dt = new ScheduleDT();
							dt.Datedue = Convert.ToDateTime(this.Session["Datedue1"]);
							dt.Repaydue = Convert.ToSingle(this.Session["Repaydue1"]);
							dt.huiSid = memberID;
							dt.Numberment = 1;
							dt.Param1 = empID.ToString();
							dt.Param2 = "0";
							dt.Balance = Convert.ToSingle(this.Session["Repaydue1"]);
							dt.RepayTime = Convert.ToDateTime("2000-1-1");
							dt.OperateTime = Convert.ToDateTime("2000-1-1");
							scheduleBN.Add(dt);
							
							dt = new ScheduleDT();
							dt.Datedue = Convert.ToDateTime(this.Session["Datedue2"]);
							dt.Repaydue = Convert.ToSingle(this.Session["Repaydue2"]);
							dt.huiSid = memberID;
							dt.Numberment = 1;
							dt.Param1 = empID.ToString();
							dt.Param2 = "0";
							dt.Balance = Convert.ToSingle(this.Session["Repaydue1"])+ Convert.ToSingle(this.Session["Repaydue2"]);
							dt.RepayTime = Convert.ToDateTime("2000-1-1");
							dt.OperateTime = Convert.ToDateTime("2000-1-1");
							scheduleBN.Add(dt);
							
							dt = new ScheduleDT();
							dt.Datedue = Convert.ToDateTime(this.Session["Datedue3"]);
							dt.Repaydue = Convert.ToSingle(this.Session["Repaydue3"]);
							dt.huiSid = memberID;
							dt.Numberment = 1;
							dt.Param1 = empID.ToString();
							dt.Param2 = "0";
							dt.Balance = Convert.ToSingle(this.Session["Repaydue1"])+ Convert.ToSingle(this.Session["Repaydue2"])+ Convert.ToSingle(this.Session["Repaydue3"]);
							dt.RepayTime = Convert.ToDateTime("2000-1-1");
							dt.OperateTime = Convert.ToDateTime("2000-1-1");
							scheduleBN.Add(dt);
							break;
						case 4:
							dt = new ScheduleDT();
							dt.Datedue = Convert.ToDateTime(this.Session["Datedue4"]);
							dt.Repaydue = Convert.ToSingle(this.Session["Repaydue4"]);
							dt.huiSid = memberID;
							dt.Numberment = 1;
							dt.Param1 = empID.ToString();
							dt.Param2 = "0";
							dt.Balance = Convert.ToSingle(this.Session["Repaydue4"]);
							dt.RepayTime = Convert.ToDateTime("2000-1-1");
							dt.OperateTime = Convert.ToDateTime("2000-1-1");
							scheduleBN.Add(dt);
							break;
					}
				}
			}

			Response.Write("<script>alert('Success！');window.location='MemberList.aspx';</script>");
		}
	}
}
