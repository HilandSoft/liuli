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
	/// FollowupDele ��ժҪ˵����
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
