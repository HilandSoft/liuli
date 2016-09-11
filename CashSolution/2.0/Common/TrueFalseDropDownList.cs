using System;
using System.Web.UI.WebControls;

namespace YingNet.Common
{
	/// <summary>
	/// TrueFalseDropDownList ��ժҪ˵����
	/// </summary>
	public class TrueFalseDropDownList:DropDownList
	{
		public TrueFalseDropDownList()
		{
			this.AddItems();
		}

		private void AddItems()
		{
			this.Items.Clear();
			ListItem itemTrue= new ListItem("True","1");
			ListItem itemFalse= new ListItem("False","0");
			this.Items.Add(itemTrue);
			this.Items.Add(itemFalse);
		}
	}
}
