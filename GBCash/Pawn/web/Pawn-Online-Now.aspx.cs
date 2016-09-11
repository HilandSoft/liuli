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
using System.IO;
using YingNet.WeiXing.Business;
using YingNet.WeiXing.DB.Data;
using YingNet.Common.Utils;

namespace YingNet.WeiXing.WebApp.Pawn_Loans
{
	/// <summary>
	/// Pawn_Online_Now 的摘要说明。
	/// </summary>
	public class Pawn_Online_Now : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputText txFname;
		protected System.Web.UI.HtmlControls.HtmlInputText txLname;
		protected System.Web.UI.HtmlControls.HtmlInputText txEmail;
		protected System.Web.UI.HtmlControls.HtmlInputText txDriver;
		protected System.Web.UI.HtmlControls.HtmlInputText txIssue;
		protected System.Web.UI.HtmlControls.HtmlInputText txCity;
		protected System.Web.UI.HtmlControls.HtmlSelect selState;
		protected System.Web.UI.HtmlControls.HtmlInputText txPost;
		protected System.Web.UI.HtmlControls.HtmlInputText txTel;
		protected System.Web.UI.HtmlControls.HtmlInputText txUser;
		protected System.Web.UI.HtmlControls.HtmlInputText txPass;
		protected System.Web.UI.HtmlControls.HtmlInputText txConfirm;
		protected System.Web.UI.HtmlControls.HtmlInputText txAddress;
		protected System.Web.UI.WebControls.DropDownList drpItems;
		protected System.Web.UI.WebControls.TextBox txItemDesc;
		protected System.Web.UI.WebControls.TextBox txItemDescription;
		protected System.Web.UI.WebControls.DropDownList drpItemCondition;
		protected System.Web.UI.HtmlControls.HtmlInputFile ItemPhoto;
		protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
		protected HtmlInputText txDated;
		protected HtmlInputText txDatem;
		protected HtmlInputText txDatey;
	
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
			this.Submit1.ServerClick += new System.EventHandler(this.Submit1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Submit1_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				HuiyuanBN nbn = new HuiyuanBN(this.Page);
				nbn.QueryUsername(this.txUser.Value);
				if (nbn.GetList().Rows.Count > 0)
				{
					base.Response.Write("<script>alert('Please select a new Username, that name is already in use!');</script>");
				}
				else
				{
					HuiyuanDT dt = new HuiyuanDT();
					dt.Fname = this.txFname.Value;
					dt.Lname = this.txLname.Value;
					dt.Email = this.txEmail.Value;
					dt.Issued = this.txIssue.Value;
					dt.DNumber = this.txDriver.Value;
					//dt.RAddress = this.txResident.Value;
					//dt.SAddress = this.txStreet.Value;
					dt.City = this.txCity.Value;
					dt.State = this.selState.Value;
					dt.Postcode = this.txPost.Value;
					//dt.TYears = Convert.ToInt32(this.txYear.Value);
					//dt.TMonths = Convert.ToInt32(this.txMonth.Value);
					dt.HTel = this.txTel.Value;
					//dt.Mobile = this.txMobile.Value;
					//dt.Param1 = this.txFax.Value;
					dt.Username = this.txUser.Value;
					dt.Password = this.txPass.Value;
					dt.IsValid = 9;
					dt.Regtime = SafeDateTime.LocalNow;

					dt.SAddress= this.txAddress.Value;
					dt.ItemCondition= this.drpItemCondition.SelectedValue;
					dt.ItemDescription= this.txItemDescription.Text;
					dt.ItemToPawn= this.drpItems.SelectedValue;
					dt.DBirth= new DateTime(1753,1,1);
					dt.NeedGoldPack=0;

					try
					{
						dt.DBirth = Convert.ToDateTime(this.txDatey.Value + "-" + this.txDatem.Value + "-" + this.txDated.Value);
					}
					catch{}

					HttpPostedFile itemPhotoFile= this.ItemPhoto.PostedFile;
					if(itemPhotoFile!=null && itemPhotoFile.ContentLength>0 && itemPhotoFile.FileName!="")
					{
						string relativePath= System.Configuration.ConfigurationSettings.AppSettings["PawnUploadPath"];
						if(relativePath==null || relativePath=="")
						{
							relativePath= "~/UploadFiles/PawnImages/";
						}
						
						int extionNamePos= itemPhotoFile.FileName.LastIndexOf(".");
						string fileExtionName= string.Empty;
						
						if(extionNamePos>=0)
						{
							fileExtionName= itemPhotoFile.FileName.Substring( extionNamePos);
						}
						else
						{
							fileExtionName= "";
						}

						
						string newFileFullName= Server.MapPath(relativePath);
						if(newFileFullName.EndsWith("\\")==false)
						{
							newFileFullName= newFileFullName+ "\\";
						}

						string newFileName= Guid.NewGuid()+ fileExtionName;
						newFileFullName= newFileFullName+ newFileName;
						
						dt.ItemPhoto= newFileName;
						itemPhotoFile.SaveAs(newFileFullName);
					}
					
					int num = nbn.Add2(dt);
					this.Session["username"] = this.txUser.Value;
					this.Session["huiSid"] = num;
					base.Response.Write("<script>window.top.location='Pawn-Loan-Information.aspx';</script>");

				}
			}
			catch (Exception exception)
			{
				base.Response.Write(exception.Message);
			}
		}
	}
}
