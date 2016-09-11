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
	/// openoperate ��ժҪ˵����
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
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
