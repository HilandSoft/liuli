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
using System.Data.SqlClient;
using System.Globalization;

using YingNet.WeiXing.Business;
using YingNet.WeiXing.DB;
using YingNet.WeiXing.STRUCTURE;
using YingNet.Common;
using YingNet.WeiXing.Business.CommonLogic;
using YingNet.WeiXing.WebApp.Include;

namespace YingNet.WeiXing.WebApp.manage.Long
{
	/// <summary>
	/// LongDetailEdit 的摘要说明。
	/// </summary>
	public class LongDetailEdit : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox Textbox29;
		protected System.Web.UI.WebControls.Button SaveButton;
		protected System.Web.UI.WebControls.TextBox txtpurpose;
		protected System.Web.UI.WebControls.TextBox txtborrow;
		protected System.Web.UI.WebControls.TextBox txtrefnumber;
		protected System.Web.UI.WebControls.TextBox txtfname;
		protected System.Web.UI.WebControls.TextBox txtmname;
		protected System.Web.UI.WebControls.TextBox txtsname;
		protected System.Web.UI.WebControls.TextBox txthometel;
		protected System.Web.UI.WebControls.TextBox txtworktel;
		protected System.Web.UI.WebControls.TextBox txtmobiletel;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.TextBox txtlnumber;
		protected System.Web.UI.WebControls.TextBox txtlstate;
		protected System.Web.UI.WebControls.TextBox txtReName1;
		protected System.Web.UI.WebControls.TextBox txtselReShip1;
		protected System.Web.UI.WebControls.TextBox txtReNum1;
		protected System.Web.UI.WebControls.TextBox txtReName2;
		protected System.Web.UI.WebControls.TextBox txtselReShip2;
		protected System.Web.UI.WebControls.TextBox txtReNum2;
		protected System.Web.UI.WebControls.TextBox txtReName3;
		protected System.Web.UI.WebControls.TextBox txtselReShip3;
		protected System.Web.UI.WebControls.TextBox txtReNum3;
		protected System.Web.UI.WebControls.TextBox txtunitno;
		protected System.Web.UI.WebControls.TextBox txtStreet;
		protected System.Web.UI.WebControls.TextBox txtSuburb;
		protected System.Web.UI.WebControls.TextBox txtPost;
		protected System.Web.UI.WebControls.TextBox txtlandlord;
		protected System.Web.UI.WebControls.TextBox txtareatel;
		protected System.Web.UI.WebControls.TextBox txtstxunitno1;
		protected System.Web.UI.WebControls.TextBox txtstxStreet1;
		protected System.Web.UI.WebControls.TextBox txtstxSuburb1;
		protected System.Web.UI.WebControls.TextBox txtstxPost1;
		protected System.Web.UI.WebControls.TextBox txtstimeaddress1Year;
		protected System.Web.UI.WebControls.TextBox txtstimeaddress1Month;
		protected System.Web.UI.WebControls.TextBox txtEmployer;
		protected System.Web.UI.WebControls.TextBox txtAddress;
		protected System.Web.UI.WebControls.TextBox txtPhone;
		protected System.Web.UI.WebControls.TextBox txtJob;
		protected System.Web.UI.WebControls.TextBox txtIncome;
		protected System.Web.UI.WebControls.TextBox txtBank;
		protected System.Web.UI.WebControls.TextBox txtBranch;
		protected System.Web.UI.WebControls.TextBox txtAname;
		protected System.Web.UI.WebControls.TextBox txtBsb;
		protected System.Web.UI.WebControls.TextBox txtAnumber;
		protected System.Web.UI.WebControls.TextBox txtdlterms;
		protected System.Web.UI.WebControls.TextBox txtdlexisting;
		protected System.Web.UI.WebControls.TextBox txtdltitle;
		protected System.Web.UI.WebControls.TextBox txtdlgender;
		protected System.Web.UI.WebControls.TextBox txtdlmastatus;
		protected System.Web.UI.WebControls.TextBox txtState;
		protected System.Web.UI.WebControls.TextBox txtstxState1;
		protected System.Web.UI.WebControls.TextBox txtdlestatus;
		protected System.Web.UI.WebControls.TextBox txtmethods;
		protected System.Web.UI.WebControls.TextBox txtdlrestatus;
		protected YingNet.Common.TrueFalseDropDownList ddlexisting;
		protected System.Web.UI.WebControls.TextBox txtbirthDD;
		protected System.Web.UI.WebControls.TextBox txtbirthMM;
		protected System.Web.UI.WebControls.TextBox txtbirthYYYY;
		protected System.Web.UI.WebControls.TextBox txttimeemployedYear;
		protected System.Web.UI.WebControls.TextBox txttimeemployedMonth;
		protected YingNet.Common.PerDropDownList ddlPer;
		protected System.Web.UI.WebControls.TextBox txtnpaydayDD;
		protected System.Web.UI.WebControls.TextBox txtnpaydayMM;
		protected System.Web.UI.WebControls.TextBox txtnpaydayYYYY;
		protected System.Web.UI.WebControls.TextBox txttimeaddressMonth;
		protected System.Web.UI.WebControls.TextBox txttimeaddressYear;
		protected System.Web.UI.WebControls.Button Calculate;
		protected System.Web.UI.HtmlControls.HtmlInputText txtHousePaymentValue;
		protected System.Web.UI.HtmlControls.HtmlInputText txtOtherLenderValue;
		protected System.Web.UI.HtmlControls.HtmlTable tbUnit;
		protected CircleDropDownList ddlHousePaymentCircle;
		protected CircleDropDownList ddlOtherLenderCircle;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(this.IsPostBack==false)
			{
				this.LoadInfo();
			}
		}

		private void LoadInfo()
		{
			if(Request["sid"]!=null)
			{
				this.TextBox1.Text=Request["sid"].ToString();
				int sid=Convert.ToInt32(this.TextBox1.Text);
				
				LiniloanBN bn1=new LiniloanBN(this.Page);
				bn1.QueryPersid(sid);
				DataTable dt1=bn1.GetList();
				if(dt1.Rows.Count>0)
				{
					this.ViewState["LIniLoan.SID"]= dt1.Rows[0]["sid"];
					this.txtpurpose.Text=dt1.Rows[0]["PrimaryPurpose"].ToString();
					this.txtborrow.Text=dt1.Rows[0]["Loan"].ToString();
					this.txtdlterms.Text=dt1.Rows[0]["Term"].ToString();;
				}

				#region
				LpersonBN bn2=new LpersonBN(this.Page);
				bn2.Querysid(sid);
				DataTable dt2=bn2.GetList();
				if(dt2.Rows.Count>0)
				{
				
					this.ViewState["LPerson.SID"]= sid;
					if(dt2.Rows[0]["IsExist"].Equals(1))
					{
						this.ddlexisting.SelectedValue= "1";
					}
					else
					{
						this.ddlexisting.SelectedValue= "0";
					}
					this.txtrefnumber.Text=dt2.Rows[0]["ReferenceNum"].ToString();
					this.txtdltitle.Text=dt2.Rows[0]["Title"].ToString();
					
					this.txtfname.Text=dt2.Rows[0]["Fname"].ToString();
					this.txtmname.Text=dt2.Rows[0]["Mname"].ToString();
					this.txtsname.Text=dt2.Rows[0]["Sname"].ToString();

					this.txtdlgender.Text=dt2.Rows[0]["Gender"].ToString();
					try
					{
						string tempBirthString= Convert.ToString(dt2.Rows[0]["DBirth"]);
						string[] birthStrings= tempBirthString.Split('/','-');
						this.txtbirthDD.Text=birthStrings[0].PadLeft(2,'0');
						this.txtbirthMM.Text= birthStrings[1].PadLeft(2,'0');
						this.txtbirthYYYY.Text= birthStrings[2].ToString();
					}
					catch
					{}
					this.txthometel.Text=dt2.Rows[0]["HTelnum"].ToString();
					this.txtworktel.Text=dt2.Rows[0]["WTelnum"].ToString();
					this.txtmobiletel.Text=dt2.Rows[0]["Mobile"].ToString();
					
					this.txtEmail.Text=dt2.Rows[0]["Email"].ToString();
					this.txtlnumber.Text=dt2.Rows[0]["LicNum"].ToString();
					this.txtlstate.Text=dt2.Rows[0]["LicState"].ToString();
					this.txtdlmastatus.Text=dt2.Rows[0]["MaritalStatus"].ToString();
						
					this.txtReName1.Text=dt2.Rows[0]["Rname1"].ToString();
					this.txtselReShip1.Text=dt2.Rows[0]["Rship1"].ToString();
					this.txtReNum1.Text=dt2.Rows[0]["Rnum1"].ToString();
					this.txtReName2.Text=dt2.Rows[0]["Rname2"].ToString();
					this.txtselReShip2.Text=dt2.Rows[0]["Rship2"].ToString();
					this.txtReNum2.Text=dt2.Rows[0]["Rnum2"].ToString();
					this.txtReName3.Text=dt2.Rows[0]["Rname3"].ToString();
					this.txtselReShip3.Text=dt2.Rows[0]["Rship3"].ToString();
					this.txtReNum3.Text=dt2.Rows[0]["Rnum3"].ToString();
				}

				LresidentBN bn3=new LresidentBN(this.Page);
				bn3.QueryLoanSid(sid);
				DataTable dt3=bn3.GetList();
				if(dt3.Rows.Count>0)
				{
					this.ViewState["LResident.SID"]= dt3.Rows[0]["sid"];
					this.txtdlrestatus.Text=dt3.Rows[0]["Status"].ToString();
					this.txtunitno.Text=dt3.Rows[0]["UnitNo"].ToString();

					this.txtStreet.Text=dt3.Rows[0]["StreetNum"].ToString();
					this.txtSuburb.Text=dt3.Rows[0]["Suburb"].ToString();
					this.txtState.Text=dt3.Rows[0]["State"].ToString();
					this.txtPost.Text=dt3.Rows[0]["Postcode"].ToString();
					this.txttimeaddressYear.Text=dt3.Rows[0]["TimeYears"].ToString();
					this.txttimeaddressMonth.Text=dt3.Rows[0]["TimeMonths"].ToString();
					this.txtlandlord.Text=dt3.Rows[0]["NameAgent"].ToString();
					this.txtareatel.Text=dt3.Rows[0]["TelArea"].ToString();

					this.txtstxunitno1.Text=dt3.Rows[0]["UnitNo1"].ToString();
					this.txtstxStreet1.Text=dt3.Rows[0]["StreetNum1"].ToString();
					this.txtstxSuburb1.Text=dt3.Rows[0]["Suburb1"].ToString();
					this.txtstxState1.Text=dt3.Rows[0]["State1"].ToString();
					this.txtstxPost1.Text=dt3.Rows[0]["Postcode1"].ToString();
					this.txtstimeaddress1Year.Text=dt3.Rows[0]["TimeYears1"].ToString();
					this.txtstimeaddress1Month.Text=dt3.Rows[0]["TimeMonths1"].ToString();
				}

				LemploymentBN bn4=new LemploymentBN(this.Page);
				bn4.QueryLoanSid(sid);
				DataTable dt4=bn4.GetList();
				if(dt4.Rows.Count>0)
				{
					this.ViewState["LEmployment.SID"]= dt4.Rows[0]["sid"];
					this.txtEmployer.Text=dt4.Rows[0]["EName"].ToString();
					this.txtAddress.Text=dt4.Rows[0]["EAddress"].ToString();
					this.txtPhone.Text=dt4.Rows[0]["ECode"].ToString();					
					this.txtdlestatus.Text=dt4.Rows[0]["EStatus"].ToString();

					this.txtJob.Text=dt4.Rows[0]["JobTitle"].ToString();
					this.txttimeemployedYear.Text =dt4.Rows[0]["TimeYears"].ToString();
					this.txttimeemployedMonth.Text= dt4.Rows[0]["TimeMonths"].ToString();
					this.txtIncome.Text=dt4.Rows[0]["TakePay"].ToString();
					try
					{
						this.ddlPer.SelectedValue= dt4.Rows[0]["Per"].ToString();
					}
					catch
					{}

					this.txtnpaydayDD.Text= Convert.ToString(dt4.Rows[0]["NextDay"]).PadLeft(2,'0');
					this.txtnpaydayMM.Text= Convert.ToString(dt4.Rows[0]["NextMonth"]).PadLeft(2,'0');
					this.txtnpaydayYYYY.Text= dt4.Rows[0]["NextYear"].ToString();

					//---------------------------------------------------------------------------------------------------------------
					this.txtHousePaymentValue.Value= dt4.Rows[0]["HousePaymentValue"].ToString();
					this.txtOtherLenderValue.Value= dt4.Rows[0]["OtherLenderValue"].ToString();
					this.ddlHousePaymentCircle.SelectedValue= EnumsOP.GetHousePaymentCircleLiteral(dt4.Rows[0]["HousePaymentCircle"]);
					this.ddlOtherLenderCircle.SelectedValue= EnumsOP.GetOtherLenderCircleLiteral(dt4.Rows[0]["OtherLenderCircle"]);
					//----------------------------------------------------------------------------------------------------------------
				}
				#endregion

				LbankBN bn5=new LbankBN(this.Page);
				bn5.QueryLoanSid(sid);
				DataTable dt5=bn5.GetList();
				if(dt5.Rows.Count>0)
				{
					this.ViewState["LBank.SID"]= dt5.Rows[0]["sid"];
					this.txtBank.Text=dt5.Rows[0]["BankName"].ToString();
					this.txtBranch.Text=dt5.Rows[0]["Branch"].ToString();
					this.txtAname.Text=dt5.Rows[0]["AccountName"].ToString();
					this.txtBsb.Text=dt5.Rows[0]["Bsb"].ToString();
					this.txtAnumber.Text=dt5.Rows[0]["AccountNum"].ToString();
					this.txtmethods.Text=dt5.Rows[0]["PContact"].ToString();
				}
			}
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
			this.Calculate.Click += new System.EventHandler(this.Calculate_Click);
			this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void SaveButton_Click(object sender, System.EventArgs e)
		{
			YingNet.Common.Database.DBOperate op= new YingNet.Common.Database.SqlDBOperate(Config.DataSource);
			
			try
			{
				LiniloanDT dt1= new LiniloanDT();
				LemploymentDT dt4= new LemploymentDT();
				LpersonDT dt2= new LpersonDT();
				
				if(op.baseConnection.State==ConnectionState.Closed)
				{
					op.Open();
				}
				op.BeginTran();


				if(this.ViewState["LIniLoan.SID"]!=null)
				{
					try
					{
						int tempSid= Convert.ToInt32(this.ViewState["LIniLoan.SID"]);
						LiniloanBN bn1=new LiniloanBN(this.Page,op);
						dt1= bn1.Get(tempSid);
						dt1.Loan= Convert.ToDouble(this.txtborrow.Text);
						dt1.PrimaryPurpose= this.txtpurpose.Text;
						dt1.Term= Convert.ToInt32(this.txtdlterms.Text);

						bn1.Edit(dt1);
					}
					catch
					{
					
					}
				}

				if(this.ViewState["LPerson.SID"]!=null)
				{
					try
					{
						int tempSid= Convert.ToInt32(this.ViewState["LPerson.SID"]);
						LpersonBN bn2 = new LpersonBN(this.Page,op);
						dt2 = bn2.Get(tempSid);
						try
						{
							dt2.IsExist= Convert.ToInt32(this.ddlexisting.SelectedValue);
						}
						catch
						{}

						dt2.ReferenceNum= this.txtrefnumber.Text;
						dt2.Title= this.txtdltitle.Text;
						dt2.Fname= this.txtfname.Text;
						dt2.Mname= this.txtmname.Text;
						dt2.Sname= this.txtsname.Text;
						dt2.Gender= this.txtdlgender.Text;
	

						try
						{
							int tempBirthDD= Convert.ToInt32(this.txtbirthDD.Text);
							int tempBirthMM= Convert.ToInt32(this.txtbirthMM.Text);
							int tempBirthYY= Convert.ToInt32(this.txtbirthYYYY.Text);
							dt2.DBirth= tempBirthDD.ToString("00")+ "/"+ tempBirthMM.ToString("00")+ "/"+ tempBirthYY.ToString("0000");
						}
						catch
						{}

						dt2.HTelnum= txthometel.Text;
						dt2.WTelcode= txtworktel.Text;
						dt2.Mobile= txtmobiletel.Text;
						dt2.Email= txtEmail.Text;
						dt2.LicNum= txtlnumber.Text;
						dt2.LicState= txtlstate.Text;
						dt2.MaritalStatus= txtdlmastatus.Text;
					
						dt2.Rname1= txtReName1.Text;
						dt2.Rship1= txtselReShip1.Text;
						dt2.Rnum1= txtReNum1.Text;
					
						dt2.Rname2= txtReName2.Text;
						dt2.Rship2= txtselReShip2.Text;
						dt2.Rnum2= txtReNum2.Text;
						dt2.Rname3= txtReName3.Text;
						dt2.Rship3= txtselReShip3.Text;
						dt2.Rnum3= txtReNum3.Text;

						bn2.Edit(dt2);
					}
					catch
					{}
				}

				if(this.ViewState["LResident.SID"]!=null)
				{
					try
					{
						int tempSid= Convert.ToInt32(this.ViewState["LResident.SID"]);
						LresidentBN bn3=new LresidentBN(this.Page,op);
						LresidentDT dt3= bn3.Get(tempSid);
					
						dt3.Status= txtdlrestatus.Text;
						dt3.UnitNo= txtunitno.Text;
						dt3.StreetNum= txtStreet.Text;
						dt3.Suburb= txtSuburb.Text;
						dt3.State= txtState.Text;
						dt3.Postcode= txtPost.Text;
						dt3.TimeYears= txttimeaddressYear.Text;
						dt3.TimeMonths= txttimeaddressMonth.Text;
						dt3.NameAgent= txtlandlord.Text;
						dt3.TelArea= txtareatel.Text;

						dt3.UnitNo1= txtstxunitno1.Text;
						dt3.StreetNum1= txtstxStreet1.Text;
						dt3.Suburb1= txtstxSuburb1.Text;
						dt3.State1= txtstxState1.Text;
						dt3.Postcode1= txtstxPost1.Text;
						dt3.TimeYears1= txtstimeaddress1Year.Text;
						dt3.TimeMonths1= txtstimeaddress1Month.Text;
					
						bn3.Edit(dt3);
					}
					catch
					{}
				
				}

				if(this.ViewState["LEmployment.SID"]!=null)
				{
					try
					{
						int tempSid= Convert.ToInt32(this.ViewState["LEmployment.SID"]);
						LemploymentBN bn4=new LemploymentBN(this.Page,op);
						dt4= bn4.Get(tempSid);

						dt4.EName= txtEmployer.Text;
						dt4.EAddress= txtAddress.Text;
						dt4.ECode= txtPhone.Text;
						dt4.EStatus= txtdlestatus.Text;
						dt4.JobTitle= txtJob.Text;
						try
						{
							dt4.TimeYears= Convert.ToInt32( txttimeemployedYear.Text);
							dt4.TimeMonths= Convert.ToInt32(txttimeemployedMonth.Text);
						}
						catch{}

						try
						{
							dt4.TakePay= Convert.ToDouble(txtIncome.Text);
						}
						catch{}

						try
						{
							dt4.Per= Convert.ToInt32(ddlPer.SelectedValue);
						}
						catch{}

						try
						{
							dt4.NextDay= Convert.ToInt32(txtnpaydayDD.Text);
							dt4.NextMonth= Convert.ToInt32(txtnpaydayMM.Text);
							dt4.NextYear= Convert.ToInt32(txtnpaydayYYYY.Text);
						}
						catch{}

						//-----------------------------------------------------------------------------------------------------------------
						dt4.HousePaymentCircle= EnumsOP.GetHousePaymentCircleByLiteral(this.ddlHousePaymentCircle.SelectedValue);
						dt4.OtherLenderCircle= EnumsOP.GetOtherLenderCircleByLiteral(this.ddlOtherLenderCircle.SelectedValue);
						try
						{
							dt4.HousePaymentValue= Convert.ToSingle(this.txtHousePaymentValue.Value);
							dt4.OtherLenderValue= Convert.ToSingle(this.txtOtherLenderValue.Value);
						}
						catch{}
						//------------------------------------------------------------------------------------------------------------------


						bn4.Edit(dt4);
					}
					catch
					{}
				}

				if(this.ViewState["LBank.SID"]!=null)
				{
					try
					{
						LbankBN bn5=new LbankBN(this.Page,op);
						LbankDT dt5= bn5.Get(Convert.ToInt32(this.ViewState["LBank.SID"]));
					
						dt5.BankName= txtBank.Text;
						dt5.Branch= txtBranch.Text;
						dt5.AccountName= txtAname.Text;
						dt5.Bsb= txtBsb.Text;
						dt5.AccountNum= txtAnumber.Text;
						dt5.PContact= txtmethods.Text;
					
						bn5.Edit(dt5);
					}
					catch{}
				}

				
				//先删除还款Schdule,再添加新的Schedule
				bool needChangeSchedule = false;
				if( this.ViewState["ChangeSchedule"]!=null)
				{
					try
					{
						needChangeSchedule = Convert.ToBoolean(this.ViewState["ChangeSchedule"]);
					}
					catch
					{
					}
				}
				
				if(needChangeSchedule== true && this.ViewState["LPerson.SID"]!=null)
				{
					try
					{
						int tempSid= Convert.ToInt32(this.ViewState["LPerson.SID"]);
						LongTermSchedule.DeleteSchedules(tempSid);
						
						DateTime payDate= new DateTime(dt4.NextYear,dt4.NextMonth,dt4.NextDay);
						DateTime loanHappenedDate = DateTime.MinValue;
						if(dt1.Other1!=null && dt1.Other1!=string.Empty)
						{
							try
							{
								loanHappenedDate = Convert.ToDateTime(dt1.Other1);
							}
							catch{}
						}
						else
						{
							loanHappenedDate = dt2.RegTime;
						}
						
						LongTermSchedule.AddSchedules(tempSid.ToString(),payDate,dt1.Term,dt4.Per.ToString(),(float)dt1.Loan,dt4.FollowDay,dt4.FollowMonth,dt4.FollowYear,loanHappenedDate);
					}
					catch
					{}
				}

				op.CommitTran();
			}
			catch
			{
				op.RollBackTran();
			}
			finally
			{
				op.Close();
				op.Dispose();
			}

			Response.Write("<script>alert('Success！');window.location='LongList.aspx';</script>");
		}

		private void Calculate_Click(object sender, System.EventArgs e)
		{
			this.ViewState["ChangeSchedule"] = true;
			Response.Write("<script>alert('Payment Schedule has changed,please click SAVE button to save the information！');</script>");
		}
	}
}
