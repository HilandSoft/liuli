using System;
using System.Web.UI.WebControls;

namespace YingNet.WeiXing.WebApp.UserControls
{
	/// <summary>
	/// AustralianStateDropDownList 的摘要说明。
	/// </summary>
	public class AustralianStateDropDownList:DropDownList
	{
		public AustralianStateDropDownList()
		{
			this.AddItems();
		}

		private void AddItems()
		{
			this.Items.Clear();
			this.Items.Add("ACT");
			this.Items.Add("QLD");
			this.Items.Add("NSW");
			this.Items.Add("NT");
			this.Items.Add("SA");
			this.Items.Add("TAS");
			this.Items.Add("VIC");
		}
	}
}
