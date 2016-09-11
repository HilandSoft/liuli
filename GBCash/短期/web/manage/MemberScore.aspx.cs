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
	/// MemberScore ��ժҪ˵����
	/// </summary>
	public class MemberScore : System.Web.UI.Page
	{
		protected System.Web.UI.WebControls.TextBox txtScoreDisplay;
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
				HuiyuanBN memberBN= new HuiyuanBN(this.Page);
				HuiyuanDT memberDT= memberBN.Get(this.memberID);
				if(memberDT!=null)
				{
					this.txtScoreDisplay.Text= memberDT.Param3;
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
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
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
				HuiyuanBN memberBN= new HuiyuanBN(this.Page);
				HuiyuanDT memberDT= memberBN.Get(this.memberID);
				if(memberDT!=null)
				{
					memberDT.Param3= this.txtScoreDisplay.Text;
					memberBN.Edit(memberDT);
				}

				this.Page.Response.Write("<script>alert('Success!');window.location='"+ this.GetReturnAdd() +"';</script>");
			}
		}
	}
}
