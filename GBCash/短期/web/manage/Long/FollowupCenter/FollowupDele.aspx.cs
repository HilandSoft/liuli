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

namespace YingNet.WeiXing.WebApp.manage.Long.FollowupCenter
{
	/// <summary>
	/// FollowupDele 的摘要说明。
	/// </summary>
	public class FollowupDele : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			string tempFollowupID= this.Request.QueryString["followupID"];
			if(tempFollowupID!=null&& tempFollowupID!=string.Empty)
			{
				try
				{
					CSFollowupCenterBN followupBN= new CSFollowupCenterBN(this.Page);
					followupBN.Del(Convert.ToInt32(tempFollowupID));
				}
				catch
				{}
				finally
				{
					base.Response.Write("<script>window.location='FollowupList.aspx';</script>");
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
