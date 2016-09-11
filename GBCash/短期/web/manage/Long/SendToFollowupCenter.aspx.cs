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
	/// SendToFollowupCenter ��ժҪ˵����
	/// </summary>
	public class SendToFollowupCenter : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox TextBox1;
		protected System.Web.UI.WebControls.TextBox txtParamstr;
		protected System.Web.UI.WebControls.Label LabMsg;
		protected System.Web.UI.HtmlControls.HtmlInputButton returnmain;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if (!base.IsPostBack && (base.Request["id"] != null))
			{
				this.TextBox1.Text = base.Request["id"];
				this.LabMsg.Text = "This item will be sent to FollowupCenter. Do you want to continue?";
			}
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.returnmain.ServerClick += new System.EventHandler(this.returnmain_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void returnmain_ServerClick(object sender, System.EventArgs e)
		{
			int id = Convert.ToInt32(this.TextBox1.Text);
			CSFollowupCenterBN business= new CSFollowupCenterBN(this.Page);
			CSFollowupCenterDT entity= new CSFollowupCenterDT();
			entity.FollowupStatus = FollowupCenterStatusEnum.FollowupEveryday;
			entity.LastOperateDate =SafeDateTime.LocalNow;
			entity.PostDate = SafeDateTime.LocalNow;
			entity.RemindEnable = true;
			entity.UserID = id;
			entity.UserLoanType = UserLoanTypes.Long;
			entity.TaskInformation = string.Empty;
			entity.RemindDate= new DateTime(1753,1,2);
			entity.RemindDate2= new DateTime(1753,1,2);
			entity.RemindDate3= new DateTime(1753,1,2);
				
			business.Add(entity);
		
			base.Response.Write("<script>alert('Success!');window.location.href='LongList.aspx';</script>");
		}
	}
}
