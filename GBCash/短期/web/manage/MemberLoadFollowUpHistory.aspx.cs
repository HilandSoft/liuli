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
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.WebApp.manage
{
	/// <summary>
	/// MemberLoadFollowUpHistory 的摘要说明。
	/// </summary>
	public class MemberLoadFollowUpHistory : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtFollowUpDisplay;
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
				MemberLoadNoteBN bn= new MemberLoadNoteBN(this.Page);
				MemberLoadNoteDT dt= bn.GetByMemberID(this.memberID);
				if(dt!=null)
				{
					this.txtFollowUpDisplay.Text= dt.NodeDesc;
				}
			}
		}


		private string GetReturnAdd()
		{
			string ret= string.Empty;
			switch(this.fromAdd)
			{
				case "sp":
					ret= "ProcessCenter/ProcessList.aspx";
					break;
				case "sf":
					ret="FollowupCenter/FollowupList.aspx";
					break;
				default:
					ret= "MemberList.aspx";
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
				MemberLoadNoteBN bn= new MemberLoadNoteBN(this.Page);
				MemberLoadNoteDT dt= bn.GetByMemberID(this.memberID);
				if(dt!=null)
				{
					dt.NodeDesc= this.txtFollowUpDisplay.Text;
					bn.Edit(dt);
				}
				else
				{
					dt= new MemberLoadNoteDT();
					dt.NoteContent= String.Empty;
					dt.NodeStatus= 1;
					dt.NodeOrder=0;
					dt.NodeDesc= this.txtFollowUpDisplay.Text;
					dt.MemberID= this.memberID;
					dt.ExtendedValues= null;
					dt.ExtendedNames= null;

					bn.Add(dt);
				}

				this.Page.Response.Write("<script>alert('Success!');window.location='" + this.GetReturnAdd() +"';</script>");
			}
		}
	}
}
