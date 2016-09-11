namespace YingNet.WeiXing.WebApp.Member
{
	using System;
	using System.Data;
	using System.Web.UI.HtmlControls;
	using System.Web.UI.WebControls;
	using YingNet.WeiXing.Business;
	using YingNet.WeiXing.DB.Data;
	using YingNet.Common.Utils;
	using YingNet.WeiXing.WebApp.Include;
	using YingNet.WeiXing.STRUCTURE;

	public class detail : generagepage
	{
		public string customno = "";
		protected DropDownList dlTitle;
		protected HtmlInputHidden Hidden1;
		protected HtmlSelect selState;
		protected HtmlInputButton Submit1;
		protected HtmlInputText txCity;
		protected HtmlInputText txDate;
		protected HtmlInputText txDriver;
		protected HtmlInputText txEmail;
		protected HtmlInputText txFax;
		protected HtmlInputText txFname;
		protected HtmlInputText txIssue;
		protected HtmlInputText txLname;
		protected HtmlInputText txMname;
		protected HtmlInputText txMobile;
		protected HtmlSelect txMonth;
		protected HtmlInputText txNo;
		protected HtmlInputText txPost;
		protected HtmlInputText txResident;
		protected HtmlInputText txStreet;
		protected HtmlInputText txTel;
		protected System.Web.UI.HtmlControls.HtmlForm Form1;
		protected System.Web.UI.WebControls.RadioButtonList RadioButtonList1;
		protected System.Web.UI.WebControls.RadioButtonList RadioButtonList2;
		protected System.Web.UI.WebControls.TextBox txtLoanPurpose;
		protected System.Web.UI.WebControls.Panel Panel1;
		protected System.Web.UI.WebControls.RadioButtonList RadioButtonList3;
		protected System.Web.UI.WebControls.Panel Panel2;
		protected System.Web.UI.HtmlControls.HtmlInputHidden Hidden2;
		protected System.Web.UI.HtmlControls.HtmlInputText txEmployer;
		protected System.Web.UI.HtmlControls.HtmlInputText txAddress;
		protected System.Web.UI.HtmlControls.HtmlInputText txPhone;
		protected System.Web.UI.HtmlControls.HtmlInputText txJob;
		protected System.Web.UI.HtmlControls.HtmlSelect Select1;
		protected System.Web.UI.HtmlControls.HtmlSelect Select2;
		protected System.Web.UI.HtmlControls.HtmlInputText txIncome;
		protected System.Web.UI.HtmlControls.HtmlInputText txDd1;
		protected System.Web.UI.HtmlControls.HtmlInputText txMm1;
		protected System.Web.UI.HtmlControls.HtmlInputText txYy1;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHousePaymentValue;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOtherLenderValue;
		protected System.Web.UI.HtmlControls.HtmlInputButton Save1;
		protected System.Web.UI.HtmlControls.HtmlInputText txType;
		protected System.Web.UI.HtmlControls.HtmlInputText txOffice;
		protected System.Web.UI.HtmlControls.HtmlInputText txContact;
		protected System.Web.UI.HtmlControls.HtmlSelect txYear2;
		protected System.Web.UI.HtmlControls.HtmlSelect txMonth2;
		protected System.Web.UI.HtmlControls.HtmlInputText txBenefit;
		protected System.Web.UI.HtmlControls.HtmlInputText txDd4;
		protected System.Web.UI.HtmlControls.HtmlInputText txMm4;
		protected System.Web.UI.HtmlControls.HtmlInputText txYy4;
		protected HtmlSelect txYear;

		
		protected CircleDropDownList ddlHousePaymentCircle;
		protected CircleDropDownList ddlOtherLenderCircle;

		private void InitializeComponent()
		{
			this.RadioButtonList1.SelectedIndexChanged += new System.EventHandler(this.RadioButtonList1_SelectedIndexChanged);
//			this.Save1.ServerClick += new System.EventHandler(this.Save1_ServerClick);
//			this.Save2.ServerClick += new System.EventHandler(this.Save2_ServerClick);
			this.Submit1.ServerClick += new System.EventHandler(this.Submit1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		public void FillInfo()
		{
			EmployedBN dbn = new EmployedBN(this.Page);
			this.Hidden1.Value = this.HuiSid;
			dbn.QueryhuiSid(this.Hidden1.Value);
			DataTable list = dbn.GetList();
			if (list.Rows[0]["IsEmployed"].ToString().Equals("1"))
			{
				this.RadioButtonList1.SelectedIndex = 0;
				this.Panel1.Visible = true;
				this.Panel2.Visible = false;
				this.txEmployer.Value = list.Rows[0]["Employer"].ToString();
				this.txAddress.Value = list.Rows[0]["EAddress"].ToString();
				this.txPhone.Value = list.Rows[0]["EPhone"].ToString();
				this.txJob.Value = list.Rows[0]["Param5"].ToString();
				this.Select1.Value = list.Rows[0]["TYears"].ToString();
				this.Select2.Value = list.Rows[0]["TMonths"].ToString();
				this.txIncome.Value = Convert.ToSingle(list.Rows[0]["MIncome"]).ToString("0.00");
				
				int lastIndex= list.Rows.Count-1;
				DataRow lastRow= list.Rows[lastIndex];
				
				this.txMm1.Value = lastRow["NDayMM"].ToString();
				this.txDd1.Value = lastRow["NDayDD"].ToString();
				this.txYy1.Value =lastRow["NDayYY"].ToString();
				this.txtLoanPurpose.Text= lastRow["LoanPurpose"].ToString();
				this.txtHousePaymentValue.Value= lastRow["HousePaymentValue"].ToString();
				this.txtOtherLenderValue.Value= lastRow["OtherLenderValue"].ToString();
				this.ddlHousePaymentCircle.SelectedValue= EnumsOP.GetHousePaymentCircleLiteral( lastRow["HousePaymentCircle"]);
				this.ddlOtherLenderCircle.SelectedValue= EnumsOP.GetOtherLenderCircleLiteral( lastRow["OtherLenderCircle"]);
				switch (list.Rows[0]["Wpaid"].ToString())
				{
					case "Weekly":
						this.RadioButtonList2.SelectedIndex = 0;
						return;

					case "F'nightly":
						this.RadioButtonList2.SelectedIndex = 1;
						break;

					case "Monthly":
						this.RadioButtonList2.SelectedIndex = 2;
						break;
				}
			}
			else
			{
				this.RadioButtonList1.SelectedIndex = 1;
				this.Panel1.Visible = false;
				this.Panel2.Visible = true;
				this.txType.Value = list.Rows[0]["Employer"].ToString();
				this.txOffice.Value = list.Rows[0]["EAddress"].ToString();
				this.txContact.Value = list.Rows[0]["EPhone"].ToString();
				this.txYear2.Value = list.Rows[0]["TYears"].ToString();
				this.txMonth2.Value = list.Rows[0]["TMonths"].ToString();
				this.txBenefit.Value = Convert.ToSingle(list.Rows[0]["MIncome"]).ToString("0.00");
                
				int lastIndex= list.Rows.Count-1;
				DataRow lastRow= list.Rows[lastIndex];

				this.txMm4.Value = lastRow["NDayMM"].ToString();
				this.txDd4.Value = lastRow["NDayDD"].ToString();
				this.txYy4.Value = lastRow["NDayYY"].ToString();
				this.txtLoanPurpose.Text= lastRow["LoanPurpose"].ToString();
				this.txtHousePaymentValue.Value= lastRow["HousePaymentValue"].ToString();
				this.txtOtherLenderValue.Value= lastRow["OtherLenderValue"].ToString();
				this.ddlHousePaymentCircle.SelectedValue= EnumsOP.GetHousePaymentCircleLiteral( lastRow["HousePaymentCircle"]);
				this.ddlOtherLenderCircle.SelectedValue= EnumsOP.GetOtherLenderCircleLiteral( lastRow["OtherLenderCircle"]);

				switch (list.Rows[0]["Wpaid"].ToString())
				{
					case "Weekly":
						this.RadioButtonList3.SelectedIndex = 0;
						return;

					case "F'nightly":
						this.RadioButtonList3.SelectedIndex = 1;
						break;

					case "Monthly":
						this.RadioButtonList3.SelectedIndex = 2;
						break;
				}
			}
		}

		public void getInfo()
		{
			DataTable list = new SystemInfoBN(this.Page).GetList();
			EmploybackupBN empBackupBN = new EmploybackupBN(this.Page);
			EmploybackupDT empBackupDT = new EmploybackupDT();
			HuiyuanDT huiyuanDT = new HuiyuanBN(this.Page).Get(Convert.ToInt32(this.Hidden1.Value));
			string username = huiyuanDT.Username;
			EmployedBN empBN = new EmployedBN(this.Page);
			empBN.QueryhuiSid(this.Hidden1.Value);
			DataTable empList= empBN.GetList();
			int empIDFirst = Convert.ToInt32(empList.Rows[0]["id"]);
			int empIDLast= Convert.ToInt32(empList.Rows[empList.Rows.Count-1]["id"]);
			EmployedDT empProfileDT = empBN.Get(empIDFirst);
			EmployedDT empLoadDT= empBN.Get(empIDLast);
			InfoBN obn2 = new InfoBN(this.Page);
			InfoDT odt = new InfoDT();
			odt.huiSid = Convert.ToInt32(this.Hidden1.Value);
			odt.Username = huiyuanDT.Username;
			odt.type = "2";
			odt.regtime = SafeDateTime.LocalNow;
			odt.isvalid = 1;
			obn2.Add(odt);
			empBackupDT.Employer = empProfileDT.Employer;
			empBackupDT.EAddress = empProfileDT.EAddress;
			empBackupDT.EPhone = empProfileDT.EPhone;
			empBackupDT.TYears = empProfileDT.TYears;
			empBackupDT.TMonths = empProfileDT.TMonths;
			empBackupDT.MIncome = empProfileDT.MIncome;
			empBackupDT.Wpaid = empProfileDT.Wpaid;
			empBackupDT.NDayDD = empProfileDT.NDayDD;
			empBackupDT.NDayMM = empProfileDT.NDayMM;
			empBackupDT.NDayYY = empProfileDT.NDayYY;
			empBackupDT.IsEmployed = empProfileDT.IsEmployed;
			empBackupDT.Frequency = empProfileDT.Frequency;
			empBackupDT.huiSid = empProfileDT.huiSid;
			empBackupDT.ModTime = SafeDateTime.LocalNow;
			empBackupDT.huiName = username;
			if (this.RadioButtonList1.SelectedIndex == 0)
			{
				empProfileDT.Employer = this.txEmployer.Value;
				empProfileDT.EAddress = this.txAddress.Value;
				empProfileDT.EPhone = this.txPhone.Value;
				empProfileDT.TYears = Convert.ToInt32(this.Select1.Value);
				empProfileDT.TMonths = Convert.ToInt32(this.Select2.Value);
				empProfileDT.MIncome = Convert.ToSingle(this.txIncome.Value);
                
                
				empProfileDT.IsEmployed = 1;
				empProfileDT.Param5 = this.txJob.Value;
                
				empLoadDT.Wpaid = this.RadioButtonList2.SelectedValue;
				empLoadDT.NDayMM = Convert.ToInt32(this.txMm1.Value);
				empLoadDT.NDayDD = Convert.ToInt32(this.txDd1.Value);
				empLoadDT.NDayYY = Convert.ToInt32(this.txYy1.Value);
				empLoadDT.LoanPurpose= this.txtLoanPurpose.Text;
				empLoadDT.HousePaymentCircle= EnumsOP.GetHousePaymentCircleByLiteral(this.ddlHousePaymentCircle.SelectedValue);
				empLoadDT.OtherLenderCircle= EnumsOP.GetOtherLenderCircleByLiteral(this.ddlOtherLenderCircle.SelectedValue);
				try
				{
					empLoadDT.HousePaymentValue= Convert.ToSingle(this.txtHousePaymentValue.Value);
					empLoadDT.OtherLenderValue= Convert.ToSingle(this.txtOtherLenderValue.Value);
				}
				catch{}
				switch (this.RadioButtonList2.SelectedIndex)
				{
					case 0:
						empLoadDT.Frequency = 7.0;
						goto Label_047F;

					case 1:
						empLoadDT.Frequency = 14.0;
						goto Label_047F;

					case 2:
						empLoadDT.Frequency = Convert.ToSingle(list.Rows[0]["frequency"].ToString());
						goto Label_047F;
				}
			}
			else
			{
				empProfileDT.Employer = this.txType.Value;
				empProfileDT.EAddress = this.txOffice.Value;
				empProfileDT.EPhone = this.txContact.Value;
				empProfileDT.TYears = Convert.ToInt32(this.txYear2.Value);
				empProfileDT.TMonths = Convert.ToInt32(this.txMonth2.Value);
				empProfileDT.MIncome = Convert.ToSingle(this.txBenefit.Value);
                
				empProfileDT.IsEmployed = 0;
                
				empProfileDT.Wpaid = this.RadioButtonList3.SelectedValue;
				empProfileDT.NDayMM = Convert.ToInt32(this.txMm4.Value);
				empProfileDT.NDayDD = Convert.ToInt32(this.txDd4.Value);
				empProfileDT.NDayYY = Convert.ToInt32(this.txYy4.Value);
				switch (this.RadioButtonList3.SelectedIndex)
				{
					case 0:
						empProfileDT.Frequency = 7.0;
						goto Label_047F;

					case 1:
						empProfileDT.Frequency = 14.0;
						goto Label_047F;

					case 2:
						empProfileDT.Frequency = Convert.ToSingle(list.Rows[0]["frequency"].ToString());
						goto Label_047F;
				}
			}
			Label_047F:
				empBN.Edit(empLoadDT);
			empBN.Edit(empProfileDT);
			empBackupBN.Add(empBackupDT);
//			if (base.Request["Type"].ToString().Equals("1"))
//			{
//				base.Response.Write("<script>window.alert('Success!');window.location='newloan.aspx';</script>");
//			}
//			else
//			{
//				base.Response.Write("<script>window.alert('Success!');window.location='EmployDetail.aspx';</script>");
//			}
		}


		private void Page_Load(object sender, EventArgs e)
		{
			if (!this.Page.IsPostBack)
			{
				HuiyuanBN nbn = new HuiyuanBN(this.Page);
				this.Hidden1.Value = this.HuiSid;
				nbn.QuerySid(this.Hidden1.Value);
				DataTable list = nbn.GetList();
				if ((list.Rows[0]["Param2"] != null) && (list.Rows[0]["Param2"].ToString() != ""))
				{
					for(int i=0;i<this.dlTitle.Items.Count;i++)
					{
						if(this.dlTitle.Items[i].Value==list.Rows[0]["Param2"].ToString())
						{
							this.dlTitle.SelectedValue = list.Rows[0]["Param2"].ToString();
							break;
						}
					}
				}
				this.txFname.Value = list.Rows[0]["Fname"].ToString();
				this.txLname.Value = list.Rows[0]["Lname"].ToString();
				this.txMname.Value = list.Rows[0]["Mname"].ToString();
				this.txDate.Value = Convert.ToDateTime(list.Rows[0]["DBirth"]).Day.ToString() + "/" + Convert.ToDateTime(list.Rows[0]["DBirth"]).Month.ToString() + "/" + Convert.ToDateTime(list.Rows[0]["DBirth"]).Year.ToString();
				this.txEmail.Value = list.Rows[0]["Email"].ToString();
				this.txIssue.Value = list.Rows[0]["Issued"].ToString();
				this.txDriver.Value = list.Rows[0]["DNumber"].ToString();
				this.txResident.Value = list.Rows[0]["RAddress"].ToString();
				this.txStreet.Value = list.Rows[0]["SAddress"].ToString();
				this.txCity.Value = list.Rows[0]["City"].ToString();
				this.selState.Value = list.Rows[0]["State"].ToString();
				this.txPost.Value = list.Rows[0]["Postcode"].ToString();
				this.txYear.Value = list.Rows[0]["TYears"].ToString();
				this.txMonth.Value = list.Rows[0]["TMonths"].ToString();
				this.txTel.Value = list.Rows[0]["HTel"].ToString();
				this.txMobile.Value = list.Rows[0]["Mobile"].ToString();
				this.txFax.Value = list.Rows[0]["Param1"].ToString();
				this.txNo.Value = list.Rows[0]["id"].ToString();

				this.FillInfo();
			}
		}

		private void Submit1_ServerClick(object sender, EventArgs e)
		{
			HuiyuanBN nbn = new HuiyuanBN(this.Page);
			HuiyuanDT dt = nbn.Get(Convert.ToInt32(this.Hidden1.Value));
			HuibackupBN pbn = new HuibackupBN(this.Page);
			HuibackupDT pdt = new HuibackupDT();
			pdt.Param2 = this.dlTitle.SelectedValue;
			pdt.Username = dt.Username;
			pdt.Fname = dt.Fname;
			pdt.Lname = dt.Lname;
			pdt.Mname = dt.Mname;
			pdt.DBirth = dt.DBirth;
			pdt.Email = dt.Email;
			pdt.Issued = dt.Issued;
			pdt.DNumber = dt.DNumber;
			pdt.RAddress = dt.RAddress;
			pdt.SAddress = dt.SAddress;
			pdt.City = dt.City;
			pdt.State = dt.State;
			pdt.Postcode = dt.Postcode;
			pdt.TYears = dt.TYears;
			pdt.TMonths = dt.TMonths;
			pdt.HTel = dt.HTel;
			pdt.Mobile = dt.Mobile;
			pdt.Param1 = dt.Param1;
			pdt.Modtime = SafeDateTime.LocalNow;
			pbn.Add(pdt);
			InfoBN obn = new InfoBN(this.Page);
			InfoDT odt = new InfoDT();
			odt.huiSid = Convert.ToInt32(this.Hidden1.Value);
			odt.Username = dt.Username;
			odt.type = "1";
			odt.regtime = SafeDateTime.LocalNow;
			odt.isvalid = 1;
			obn.Add(odt);
			dt.Param2 = this.dlTitle.SelectedValue;
			dt.Fname = this.txFname.Value;
			dt.Lname = this.txLname.Value;
			dt.Mname = this.txMname.Value;
			dt.Email = this.txEmail.Value;
			dt.Issued = this.txIssue.Value;
			dt.DNumber = this.txDriver.Value;
			dt.RAddress = this.txResident.Value;
			dt.SAddress = this.txStreet.Value;
			dt.City = this.txCity.Value;
			dt.State = this.selState.Value;
			dt.Postcode = this.txPost.Value;
			dt.TYears = Convert.ToInt32(this.txYear.Value);
			dt.TMonths = Convert.ToInt32(this.txMonth.Value);
			dt.HTel = this.txTel.Value;
			dt.Mobile = this.txMobile.Value;
			dt.Param1 = this.txFax.Value;
			nbn.Edit(dt);

			this.getInfo();
			base.Response.Write("<script>window.alert('Register Success!');window.location='detail1.aspx';</script>");
		}

		private void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (this.RadioButtonList1.SelectedIndex == 0)
			{
				this.Panel1.Visible = true;
				this.Panel2.Visible = false;
			}
			else
			{
				this.Panel1.Visible = false;
				this.Panel2.Visible = true;
			}
		}
	}
}

