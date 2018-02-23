using System;
using System.Web.UI.WebControls;

namespace YingNet.Common
{
	/// <summary>
	/// RepaymentCycleRadioButtonList 的摘要说明。
	/// </summary>
	public class PerRadioButtonList:RadioButtonList
	{
		public PerRadioButtonList()
		{
			this.AddItems();
		}
		
		private void AddItems()
		{
			this.Items.Clear();
			ListItem itemWeekly= new ListItem("Weekly","Weekly");
			ListItem itemFnightly= new ListItem("F'nightly","F'nightly");
			ListItem itemMonthly= new ListItem("Monthly","Monthly");
			this.Items.Add(itemWeekly);
			this.Items.Add(itemFnightly);
			this.Items.Add(itemMonthly);
		}
	}
}
