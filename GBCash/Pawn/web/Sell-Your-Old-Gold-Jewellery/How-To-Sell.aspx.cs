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

namespace YingNet.WeiXing.WebApp.Sell_Your_Old_Gold_Jewellery
{
	/// <summary>
	/// How_To_Sell 的摘要说明。
	/// </summary>
	public class How_To_Sell : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox firstname;
		protected System.Web.UI.WebControls.TextBox lastname;
		protected System.Web.UI.WebControls.TextBox Address;
		protected System.Web.UI.WebControls.TextBox City;
		protected System.Web.UI.WebControls.DropDownList drpStates;
		protected System.Web.UI.WebControls.TextBox postalcode;
		protected System.Web.UI.WebControls.TextBox txtPhoneNumber;
		protected System.Web.UI.WebControls.TextBox txtEmail;
		protected System.Web.UI.WebControls.CheckBox chkInsurance;
		protected System.Web.UI.WebControls.CheckBox chkNews;
		protected System.Web.UI.WebControls.Button btnSubmit;
	
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
