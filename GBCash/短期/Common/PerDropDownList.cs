using System;
using System.Web.UI.WebControls;

namespace YingNet.Common
{
	/// <summary>
	/// PerDropDownList 的摘要说明。
	/// </summary>
	public class PerDropDownList:DropDownList
	{
		public PerDropDownList()
		{
			this.AddItems();
		}

		private void AddItems()
		{
			this.Items.Clear();
			ListItem itemWeekly= new ListItem("Weekly","0");
			ListItem itemFnightly= new ListItem("F'nightly","1");
			ListItem itemBiMonthly= new ListItem("Bi-Monthly","2");
			ListItem itemMonthly= new ListItem("Monthly","3");
			this.Items.Add(itemWeekly);
			this.Items.Add(itemFnightly);
			this.Items.Add(itemBiMonthly);
			this.Items.Add(itemMonthly);
		}
	}
}
