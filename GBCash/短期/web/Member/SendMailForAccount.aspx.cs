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
using System.Web.Mail;
using System.Configuration;
using YingNet.WeiXing.Business;
using System.Text;


namespace YingNet.WeiXing.WebApp
{
	/// <summary>
	/// SendMailForAccount 的摘要说明。
	/// </summary>
	public class SendMailForAccount : System.Web.UI.Page
	{
		protected System.Web.UI.HtmlControls.HtmlInputButton Submit1;
		protected System.Web.UI.HtmlControls.HtmlInputText txUsername;
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			// 在此处放置用户代码以初始化页面
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
			this.Submit1.ServerClick += new System.EventHandler(this.Submit1_ServerClick);
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion

		private void Submit1_ServerClick(object sender, System.EventArgs e)
		{
			try
			{
				string gotenUserName= string.Empty;
				string gotenUserAccount= string.Empty;
				string gotenUserPassword= string .Empty;

				if(this.txUsername.Value=="")
				{
					Response.Write("<script>alert('Username is not valid!');</script>");
					return;
				}
				HuiyuanBN bn=new HuiyuanBN(this.Page);
				bn.QueryUsername(this.txUsername.Value);
				bn.QueryNotValid("9");
				bn.QueryNotValid("3");
				bn.QueryNotValid("5");
				bn.QueryNotValid("6");
				DataTable dt=bn.GetList();
				if(dt.Rows.Count<=0)
				{
					Response.Write("<script>alert('Your username does not exist! Please re-enter your username. If you have forgotten your username please call 1300 137 906.');</script>");
					return;
				}
				else
				{
					gotenUserPassword= dt.Rows[0]["Password"].ToString();
					gotenUserAccount= dt.Rows[0]["EMail"].ToString();
					gotenUserName= this.txUsername.Value;
				}

				if(gotenUserPassword!=string.Empty&& gotenUserAccount!=string.Empty)
				{
					StringBuilder sbBody= new StringBuilder();
					sbBody.Append("Dear Sir/Madam,");
					sbBody.Append("<br/>");
					sbBody.Append("As requested, your login details appear as below:");
					sbBody.Append("<br/>");
					sbBody.AppendFormat("    Username:[{0}]",gotenUserName);
					sbBody.Append("<br/>");
					sbBody.AppendFormat("    Password:[{0}]",gotenUserPassword);
					sbBody.Append("<br/>");
					sbBody.Append("<br/>");
					sbBody.Append("Please do not reply to this email. If you need any further assistant, please do not hesitate to contact us at 1300 137 906 or email at <a href='mailto:info@gbcash.com.au'>info@gbcash.com.au</a>. You can also visit our web site at <a href='http://www.gbcash.com.au'>www.gbcash.com.au</a> for more information.");
					sbBody.Append("<br/>");
					sbBody.Append("<br/>");
					sbBody.Append("<br/>");
					sbBody.Append("Kind Regards,");
					sbBody.Append("<br/>");
					sbBody.Append("Golden Bridge Cash Solution");

					
					MailMessage mm= new MailMessage();
					mm.BodyFormat=System.Web.Mail.MailFormat.Html;
					mm.From=ConfigurationSettings.AppSettings["mailFrom"];
					mm.To= gotenUserAccount;
					mm.Subject="Password Retrieval";
					mm.Body=sbBody.ToString();
					mm.Fields["http://schemas.microsoft.com/cdo/configuration/sendusing"]= 2;
					mm.Fields["http://schemas.microsoft.com/cdo/configuration/smtpaccountname"] = ConfigurationSettings.AppSettings["mailAccount"];
					mm.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"] = ConfigurationSettings.AppSettings["mailAccount"];//验证账号：发送者邮箱账号
					mm.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"] = ConfigurationSettings.AppSettings["mailPassword"]; //验证密码：发送者邮箱密码
					mm.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 1; //验证级别0,1,2
					mm.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"]= ConfigurationSettings.AppSettings["mailPort"];
					mm.Fields["http://schemas.microsoft.com/cdo/configuration/smtpusessl"]= ConfigurationSettings.AppSettings["mailSSL"];
			
					System.Web.Mail.SmtpMail.SmtpServer=ConfigurationSettings.AppSettings["mailSMTP"];
					System.Web.Mail.SmtpMail.Send(mm);
					Response.Write("<script>alert('Your password has been sent to you via email!');parent.location='../index.htm';</script>");
				}
				else
				{
					Response.Write("<script>alert('Sorry your userName or your email is not correct,the mail cannot send to you.');parent.location='../index.htm';</script>");
				}
			}
			catch
			{}
		}
	}
}
