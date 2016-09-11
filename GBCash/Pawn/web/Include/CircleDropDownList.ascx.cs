namespace YingNet.WeiXing.WebApp.Include
{
	using System;
	using System.Data;
	using System.Drawing;
	using System.Web;
	using System.Web.UI.WebControls;
	using System.Web.UI.HtmlControls;

	/// <summary>
	///		CircleDropDownList 的摘要说明。
	/// </summary>
	public class CircleDropDownList : System.Web.UI.UserControl
	{
		protected System.Web.UI.WebControls.DropDownList DropDownList1;

		private void Page_Load(object sender, System.EventArgs e)
		{
			
		}

		private void BindInfo()
		{
			ListItem itemWeekly= new ListItem("Weekly","Weekly");
			ListItem itemFNight= new ListItem("F'Night","FNight");
			ListItem itemBiMonth= new ListItem("Bi-Month","BiMonth");
			ListItem itemMonth= new ListItem("Monthly","Monthly");
			this.DropDownList1.Items.Add(itemWeekly);
			this.DropDownList1.Items.Add(itemFNight);
			this.DropDownList1.Items.Add(itemBiMonth);
			this.DropDownList1.Items.Add(itemMonth);
		}

		public string SelectedValue
		{
			get
			{
				return this.DropDownList1.SelectedValue;
			}
			set
			{
				for(int i=0;i<this.DropDownList1.Items.Count;i++)
				{
					if(this.DropDownList1.Items[i].Value== value)
					{
						this.DropDownList1.Items[i].Selected= true;
						break;
					}
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

			if(this.IsPostBack==false)
			{
				this.BindInfo();
			}
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
