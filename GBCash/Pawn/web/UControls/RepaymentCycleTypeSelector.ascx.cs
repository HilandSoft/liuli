namespace YingNet.WeiXing.WebApp.UControls
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;
	using YingNet.WeiXing.STRUCTURE;

	/// <summary>
	///		RepaymentCycleTypeSelector ��ժҪ˵����
	/// </summary>
	public class RepaymentCycleTypeSelector : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.RadioButtonList rblPaymentCycleType;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// �ڴ˴������û������Գ�ʼ��ҳ��
		}

		/// <summary>
		/// ��ǰѡ����û��������ڵ�����
		/// </summary>
		public PaidPeriodTypes SelectedRepaymentCycleType
		{
			get
			{
				PaidPeriodTypes result= PaidPeriodTypes.Weekly;
				RadioButtonList radio= this.rblPaymentCycleType;
			
				switch(radio.SelectedValue.ToLower())
				{
					case "weekly":
						result= PaidPeriodTypes.Weekly;
						break;
					case "f'nightly":
						result= PaidPeriodTypes.Fnightly;
						break;
					case "monthly":
						result= PaidPeriodTypes.Monthly;
						break;
				}

				return result;
			}
			set
			{
				switch(value)
				{
					case PaidPeriodTypes.Weekly:
						this.rblPaymentCycleType.SelectedValue= "Weekly";
						break;
					case PaidPeriodTypes.Fnightly:
						this.rblPaymentCycleType.SelectedValue= "F'nightly";
						break;
					case PaidPeriodTypes.Monthly:
						this.rblPaymentCycleType.SelectedValue= "Monthly";
						break;
					default:
						break;
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
