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

namespace PLCash
{
	/// <summary>
	/// StepWarning ��ժҪ˵����
	/// </summary>
	public class StepWarning : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
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
			this.Submit1.ServerClick += new System.EventHandler(this.Submit1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Submit1_ServerClick(object sender, System.EventArgs e)
		{
			base.Response.Write("<script>window.location='Step0.aspx';</script>");
		}
	}
}
