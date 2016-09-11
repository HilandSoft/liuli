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

namespace YingNet.WeiXing.WebApp.manage.Long.FollowupCenter
{
	/// <summary>
	/// openoperate 的摘要说明。
	/// </summary>
	public class openoperate : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (base.Request["id"] != null)
			{
				int processID = Convert.ToInt32(base.Request["id"]);

				CSFollowupCenterBN business= new CSFollowupCenterBN(this.Page);
				
				CSFollowupCenterDT entity= business.Get(processID);
				entity.RemindEnable= false;
				business.Edit(entity);

				base.Response.Write("<script>alert('delete item successfully!');window.location.href='openwindow.aspx';</script>");
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
