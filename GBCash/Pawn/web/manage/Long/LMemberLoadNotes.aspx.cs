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
using YingNet.WeiXing.Business;
using YingNet.WeiXing.STRUCTURE;

namespace YingNet.WeiXing.WebApp.manage.Long
{
	/// <summary>
	/// LMemberLoadNotes 的摘要说明。
	/// </summary>
	public class LMemberLoadNotes : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtNoteDisplay;
		protected System.Web.UI.WebControls.LinkButton EditButton;
		protected System.Web.UI.WebControls.HyperLink returnButton;
		
		private int memberID=0;
		private string fromAdd= string.Empty;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			this.memberID= Convert.ToInt32(this.Request.QueryString["id"]);
			this.fromAdd= this.Request.QueryString["from"];

			if(this.IsPostBack==false)
			{
				this.GetInfo();
			}

			this.returnButton.NavigateUrl= this.GetReturnAdd();
		}
		
		private void GetInfo()
		{
			if(this.memberID>0)
			{
				LpersonBN bn= new LpersonBN(this.Page);
				LpersonDT dt= bn.Get(this.memberID);
				if(dt!=null)
				{
					this.txtNoteDisplay.Text= dt.Other1;
				}
			}
		}

		private string GetReturnAdd()
		{
			string ret= string.Empty;
			switch(this.fromAdd)
			{
				case "lp":
					ret= "ProcessCenter/ProcessList.aspx";
					break;
				case "lf":
					ret= "FollowupCenter/FollowupList.aspx";
					break;
				default:
					ret= "LongList.aspx";
					break;
			}

			return ret;
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
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void EditButton_Click(object sender, System.EventArgs e)
		{
			if(this.memberID>0)
			{
				LpersonBN bn= new LpersonBN(this.Page);
				LpersonDT dt= bn.Get(this.memberID);
				if(dt!=null)
				{
					dt.Other1= this.txtNoteDisplay.Text;
					bn.Edit(dt);
				}

				this.Page.Response.Write("<script>alert('Success!');window.location='"+ this.GetReturnAdd() +"';</script>");
			}
		}
	}
}
