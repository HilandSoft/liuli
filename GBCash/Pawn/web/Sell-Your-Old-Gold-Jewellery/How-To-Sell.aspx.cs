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
	/// How_To_Sell ��ժҪ˵����
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
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
