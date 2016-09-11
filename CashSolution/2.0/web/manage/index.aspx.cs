using System.Data;
using YingNet.WeiXing.Business.CommonLogic;

namespace YingNet.WeiXing.WebApp.manage
{
	using System;
	using System.Web;
	using System.Web.UI;
	using System.Web.UI.HtmlControls;
	using System.Web.UI.WebControls;
	using YingNet.Common;
	using YingNet.WeiXing.Business;
	using YingNet.WeiXing.DB.Data;
	using YingNet.Common.Utils;

	public class index : Page
	{
		protected System.Web.UI.WebControls.TextBox loginname;
		protected System.Web.UI.WebControls.TextBox password;
		protected RadioButtonList RadioButtonList1;
		protected DropDownList ddlManagerChoose;

		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			if (base.IsPostBack && (base.Request["loginname"] != null))
			{
				
				CSUserBN userBN= new CSUserBN(this.Page);
				userBN.Filter = string.Format("userName='{0}' and password='{1}' and enable=1 ",StringUtils.ToSQL(this.loginname.Text), Cipher.EncryptMD5(this.password.Text));
				DataTable userTable = userBN.GetList();
				if(userTable.Rows.Count>0)
				{
					DataRow userRow= userTable.Rows[0];

					//1.将登录信息保存在cookie中
					HttpCookie cookieUserID = new HttpCookie("SystemUserID"); 
					cookieUserID.Name= "SystemUserID";
					cookieUserID.Value= Convert.ToString(userRow["userID"]);

					HttpCookie cookieUserAccount = new HttpCookie("SystemUserAccount"); 
					cookieUserAccount.Name= "SystemUserAccount";
					cookieUserAccount.Value= Convert.ToString(userRow["userName"]);

					HttpCookie cookieUserName = new HttpCookie("SystemUserName"); 
					cookieUserName.Name= "SystemUserName";
					cookieUserName.Value= Convert.ToString(userRow["NickName"]);

					HttpContext.Current.Response.Cookies.Add(cookieUserID); 
					HttpContext.Current.Response.Cookies.Add(cookieUserAccount); 
					HttpContext.Current.Response.Cookies.Add(cookieUserName); 
					/*
					SystemCookies systemCookies= new SystemCookies();
					systemCookies.SystemRole= SystemRoles.Manage.ToString();
					systemCookies.SystemUserAccount=  Convert.ToString(userRow["userName"]);
					systemCookies.SystemUserName= Convert.ToString(userRow["NickName"]);
					systemCookies.SystemUserID= Convert.ToInt32(userRow["userID"]);
					systemCookies.Save();
					*/
					
					//2.为了兼容原来的模式，同时也保持在session中一份
					this.Session.Add("user.uid", userRow["userID"]);
					this.Session.Add("user.account", userRow["userName"]);
					this.Session.Add("user.name", userRow["NickName"]);
					this.loginname.Text = "";
					this.password.Text = "";
						
					//更新用户最后登陆时间
					CSUserDT userDT = userBN.Get(Convert.ToInt32(userRow["userID"]));
					userDT.LastLoginDate = SafeDateTime.LocalNow;
					userBN.Edit(userDT);
						
					switch(ddlManagerChoose.SelectedValue)
					{
						case "ShortMember":
							base.Response.Write("<script>window.open('MainFrameSet.aspx','','height='+(window.screen.height-50)+',width='+window.screen.width+',left=0,top=0,status=yes,toolbar=no,menubar=no,location=no, resizable=yes');</script>");
							break;
						case "LongMember":
							base.Response.Write("<script>window.open('Long/MainFrameSet.aspx','','height='+(window.screen.height-50)+',width='+window.screen.width+',left=0,top=0,status=yes,toolbar=no,menubar=no,location=no, resizable=yes');</script>");
							break;
						case "ShortProcessCenter":
							base.Response.Write("<script>window.open('ProcessCenter/MainFrameSet.aspx','','height='+(window.screen.height-50)+',width='+window.screen.width+',left=0,top=0,status=yes,toolbar=no,menubar=no,location=no, resizable=yes');</script>");
							break;
						case "LongProcessCenter":
							base.Response.Write("<script>window.open('Long/ProcessCenter/MainFrameSet.aspx','','height='+(window.screen.height-50)+',width='+window.screen.width+',left=0,top=0,status=yes,toolbar=no,menubar=no,location=no, resizable=yes');</script>");
							break;
						case "ShortFollowupCenter":
							base.Response.Write("<script>window.open('FollowupCenter/MainFrameSet.aspx','','height='+(window.screen.height-50)+',width='+window.screen.width+',left=0,top=0,status=yes,toolbar=no,menubar=no,location=no, resizable=yes');</script>");
							break;
						case "LongFollowupCenter":
							base.Response.Write("<script>window.open('Long/FollowupCenter/MainFrameSet.aspx','','height='+(window.screen.height-50)+',width='+window.screen.width+',left=0,top=0,status=yes,toolbar=no,menubar=no,location=no, resizable=yes');</script>");
							break;
						case "SystemManagement":
							base.Response.Write("<script>window.open('AdminManage/MainFrameSet.aspx','','height='+(window.screen.height-50)+',width='+window.screen.width+',left=0,top=0,status=yes,toolbar=no,menubar=no,location=no, resizable=yes');</script>");
							break;
						default:
							break;
					}
				}
				else
				{
					this.loginname.Text = "";
					this.password.Text = "";
					base.Response.Write("<script>alert('Failure,try again please!');window.location='index.aspx';</script>");
				}
			}
		}
	}
}