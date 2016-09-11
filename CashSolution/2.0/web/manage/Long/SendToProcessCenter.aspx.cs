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
using YingNet.WeiXing.DB.Data;
using YingNet.Common.Utils;

namespace YingNet.WeiXing.WebApp.manage.Long
{
	/// <summary>
	/// SendToProcessCenter 的摘要说明。
	/// </summary>
	public class SendToProcessCenter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox txtParamstr;
		protected System.Web.UI.WebControls.Label LabMsg;
		protected System.Web.UI.HtmlControls.HtmlInputButton returnmain;
	
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
			this.returnmain.ServerClick += new EventHandler(this.returnmain_ServerClick);
			base.Load += new EventHandler(this.Page_Load);
		}
		#endregion
		
		private void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack && (base.Request["id"] != null))
			{
				this.TextBox1.Text = base.Request["id"];
				this.LabMsg.Text = "This item will be sent to ProcessCenter. Do you want to continue?";
			}
		}

		private void returnmain_ServerClick(object sender, EventArgs e)
		{
			int id = Convert.ToInt32(this.TextBox1.Text);
			CSProcessCenterBN processBN= new CSProcessCenterBN(this.Page);
			CSProcessCenterDT processDT= new CSProcessCenterDT();
			processDT.ConversationTrack = String.Empty;
			processDT.IsFirstLoan = true;
			//TODO:LoanID需要确定
			processDT.LoanID =0;
			processDT.PostDate = SafeDateTime.LocalNow;
			processDT.ProcessStatus = ProcessCenterStatusEnum.Pending;
			processDT.UserID = id;
			processDT.UserLoanType = UserLoanTypes.Long;
			processDT.LastOperateDate = SafeDateTime.LocalNow;
				
			processBN.Add(processDT);
		
			base.Response.Write("<script>alert('Success!');window.location.href='LongList.aspx';</script>");
		}
	}
}
