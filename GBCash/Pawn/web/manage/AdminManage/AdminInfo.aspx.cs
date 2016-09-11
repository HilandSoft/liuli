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
using YingNet.Common;
using YingNet.WeiXing.Business;
using YingNet.WeiXing.DB.Data;
using YingNet.Common.Utils;

namespace YingNet.WeiXing.WebApp.manage.AdminManage
{
	/// <summary>
	/// AdminInfo 的摘要说明。
	/// </summary>
	public class AdminInfo : ManageBasePage2
	{
		protected System.Web.UI.WebControls.TextBox txtUserName;
		protected System.Web.UI.WebControls.TextBox txtPassword;
		protected System.Web.UI.WebControls.TextBox txtPassword2;
		protected System.Web.UI.WebControls.CheckBox chbEnable;
		protected System.Web.UI.HtmlControls.HtmlInputButton Add;
		protected System.Web.UI.WebControls.CompareValidator CompareValidator1;
		
		private int currentUserID;
	
		/// <summary>
		/// 功能模块名称
		/// </summary>
		protected override FunnctionModuleEnum FunnctionModuleName
		{
			get
			{
				return FunnctionModuleEnum.ManagerInfo;
			}
			set
			{
				base.FunnctionModuleName = value;
			}
		}
		
		/// <summary>
		/// 功能操作
		/// </summary>
		protected override CommonOperateEnum CommonOperate
		{
			get
			{
				return CommonOperateEnum.CreateEdit;
			}
			set
			{
				base.CommonOperate = value;
			}
		}
		
		private void Page_Load(object sender, System.EventArgs e)
		{
			try
			{
				currentUserID = int.Parse(this.Request.QueryString["userID"]);
			}
			catch
			{
			}
			
			this.LoadUserInfo();
		}
		
		private void LoadUserInfo()
		{
			if(currentUserID>0 && this.IsPostBack==false)
			{
				CSUserBN userBN= new CSUserBN(this.Page);
				CSUserDT userDT = userBN.Get(currentUserID);
				if(userDT!=null)
				{
					this.txtUserName.Text = userDT.UserName;
					this.txtUserName.ReadOnly = true;
					if(userDT.Enable==1)
					{
						this.chbEnable.Checked = true;
					}
					else
					{
						this.chbEnable.Checked = false;
					}
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
			this.Add.ServerClick += new System.EventHandler(this.Add_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Add_ServerClick(object sender, System.EventArgs e)
		{
			bool isSuccessful = true;
			CSUserDT userDT = null;
			CSUserBN userBN = new CSUserBN(this.Page);
			if(this.currentUserID>0)
			{
				userDT= userBN.Get(this.currentUserID);
				if(userDT!=null)
				{
					if(this.chbEnable.Checked==true)
					{
						userDT.Enable = 1;
					}
					else
					{
						userDT.Enable = 0;
					}
					
					if(this.txtPassword.Text!=string.Empty)
					{
						userDT.Password = Cipher.EncryptMD5(this.txtPassword.Text);
					}
					
					userDT.UserName = this.txtUserName.Text;
					
					userBN.Edit(userDT);
				}
			}
			else
			{
				userDT= new CSUserDT();
				
				//1.先判断此用户账号是否已经被使用
				userBN.Filter = string.Format("userName = '{0}'",this.txtUserName.Text);
				DataTable dt= userBN.GetList();
				if(dt.Rows.Count>0)
				{
					isSuccessful = false;
					this.Response.Write("<script>alert('There was same UserName already.Try another userName again please!');</script>");
				}
				else
				{
					userDT.DateCreated = SafeDateTime.LocalNow;
					userDT.Email = string.Empty;
					if(this.chbEnable.Checked==true)
					{
						userDT.Enable = 1;
					}
					else
					{
						userDT.Enable = 0;
					}
				
					userDT.Nickname = string.Empty;
					userDT.Password = Cipher.EncryptMD5(this.txtPassword.Text);
					userDT.PasswordFormat = 0;
					userDT.PasswordSalt = string.Empty;
					userDT.UserClass = string.Empty;
					userDT.UserName = this.txtUserName.Text;
					userDT.UserRank = 0;
					userDT.UserType = 0;
					userDT.LastLoginDate = new DateTime(1753,1,2);
				
					userBN.Add(userDT);
				}
			}
			
			if(isSuccessful==true)
			{
				this.Response.Redirect("AdminList.aspx");
			}
		}
	}
}
