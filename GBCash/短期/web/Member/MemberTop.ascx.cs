namespace YingNet.WeiXing.WebApp.Member
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using YingNet.WeiXing.Business;
	using YingNet.WeiXing.DB.Data;
	using YingNet.Common;

	/// <summary>
	///		MemberTop 的摘要说明。
	/// </summary>
	public class MemberTop : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.Literal litUserNameDisplay;

		private void Page_Load(object sender, System.EventArgs e)
		{
			this.litUserNameDisplay.Text= string.Empty;
			if(this.HuiSid!="")
			{
				HuiyuanBN nbn = new HuiyuanBN(this.Page);
				HuiyuanDT huiyuanDT= nbn.Get(Convert.ToInt32(this.HuiSid));
				if(huiyuanDT!=null)
				{
					this.litUserNameDisplay.Text= huiyuanDT.Fname + " "+ huiyuanDT.Lname;
				}
			}
		}

		private string huisid= "";
		protected string HuiSid
		{
			get
			{
				if(this.huisid=="")
				{
					if(this.Session["huiSid"] != null)
					{
						huisid= this.Session["huiSid"].ToString();
					}
				}

				if(this.huisid=="")
				{
					string userIDInCookie= CookieHelper.GetCookie("huiSid");
					if(userIDInCookie!=null&& userIDInCookie!="")
					{
						huisid= CookieHelper.GetCookie("huiSid");
					}
				}

				return this.huisid;
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
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
