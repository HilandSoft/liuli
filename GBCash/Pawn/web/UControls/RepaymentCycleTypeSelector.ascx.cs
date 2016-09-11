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
	///		RepaymentCycleTypeSelector 的摘要说明。
	/// </summary>
	public class RepaymentCycleTypeSelector : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.RadioButtonList rblPaymentCycleType;

		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
		}

		/// <summary>
		/// 当前选择的用户还款周期的类型
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
		///		设计器支持所需的方法 - 不要使用代码编辑器
		///		修改此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
