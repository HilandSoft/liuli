namespace YingNet.WeiXing.WebApp.UControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		RepaymentCountTypeSelector ��ժҪ˵����
	/// </summary>
	public class RepaymentCountTypeSelector : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
		}

		/// <summary>
		/// ��ǰѡ����û���������
		/// </summary>
		public int SelectedRepaymentCountType
		{
			get
			{
				return Convert.ToInt32(this.DropDownList1.SelectedValue);
			}
			set
			{
				this.DropDownList1.SelectedValue= value.ToString();
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
		///		�����֧������ķ��� - ��Ҫʹ�ô���༭��
		///		�޸Ĵ˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
