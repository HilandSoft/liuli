namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Text;
    using System.Web.Mail;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using YingNet.WeiXing.Business;

    public class SendMailForAccount : Page
    {
        protected HtmlInputButton Submit1;
        protected HtmlInputText txUsername;

        private void InitializeComponent()
        {
            this.Submit1.ServerClick += new EventHandler(this.Submit1_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            try
            {
                string str = string.Empty;
                string str2 = string.Empty;
                string str3 = string.Empty;
                if (this.txUsername.Value == "")
                {
                    base.Response.Write("<script>alert('Username is not valid!');</script>");
                }
                else
                {
                    HuiyuanBN nbn = new HuiyuanBN(this.Page);
                    nbn.QueryUsername(this.txUsername.Value);
                    nbn.QueryNotValid("9");
                    nbn.QueryNotValid("3");
                    nbn.QueryNotValid("5");
                    nbn.QueryNotValid("6");
                    DataTable list = nbn.GetList();
                    if (list.Rows.Count <= 0)
                    {
                        base.Response.Write("<script>alert('Your username does not exist! Please re-enter your username. If you have forgotten your username please call 1300 137 906.');</script>");
                    }
                    else
                    {
                        str3 = list.Rows[0]["Password"].ToString();
                        str2 = list.Rows[0]["EMail"].ToString();
                        str = this.txUsername.Value;
                        if ((str3 != string.Empty) && (str2 != string.Empty))
                        {
                            StringBuilder builder = new StringBuilder();
                            builder.Append("Dear Sir/Madam,");
                            builder.Append("<br/>");
                            builder.Append("As requested, your login details appear as below:");
                            builder.Append("<br/>");
                            builder.AppendFormat("    Username:[{0}]", str);
                            builder.Append("<br/>");
                            builder.AppendFormat("    Password:[{0}]", str3);
                            builder.Append("<br/>");
                            builder.Append("<br/>");
                            builder.Append("Please do not reply to this email. If you need any further assistant, please do not hesitate to contact us at 1300 137 906 or email at <a href='mailto:info@gbcash.com.au'>info@gbcash.com.au</a>. You can also visit our web site at <a href='http://www.gbcash.com.au'>www.gbcash.com.au</a> for more information.");
                            builder.Append("<br/>");
                            builder.Append("<br/>");
                            builder.Append("<br/>");
                            builder.Append("Kind Regards,");
                            builder.Append("<br/>");
                            builder.Append("Golden Bridge Cash Solution");
                            MailMessage message = new MailMessage();
                            message.BodyFormat = MailFormat.Html;
                            message.From = ConfigurationSettings.AppSettings["mailFrom"];
                            message.To = str2;
                            message.Subject = "Password Retrieval";
                            message.Body = builder.ToString();
                            message.Fields["http://schemas.microsoft.com/cdo/configuration/sendusing"] = 2;
                            message.Fields["http://schemas.microsoft.com/cdo/configuration/smtpaccountname"] = ConfigurationSettings.AppSettings["mailAccount"];
                            message.Fields["http://schemas.microsoft.com/cdo/configuration/sendusername"] = ConfigurationSettings.AppSettings["mailAccount"];
                            message.Fields["http://schemas.microsoft.com/cdo/configuration/sendpassword"] = ConfigurationSettings.AppSettings["mailPassword"];
                            message.Fields["http://schemas.microsoft.com/cdo/configuration/smtpauthenticate"] = 1;
                            message.Fields["http://schemas.microsoft.com/cdo/configuration/smtpserverport"] = ConfigurationSettings.AppSettings["mailPort"];
                            message.Fields["http://schemas.microsoft.com/cdo/configuration/smtpusessl"] = ConfigurationSettings.AppSettings["mailSSL"];
                            SmtpMail.SmtpServer = ConfigurationSettings.AppSettings["mailSMTP"];
                            SmtpMail.Send(message);
                            base.Response.Write("<script>alert('Your password has been sent to you via email!');parent.location='../index.htm';</script>");
                        }
                        else
                        {
                            base.Response.Write("<script>alert('Sorry your userName or your email is not correct,the mail cannot send to you.');parent.location='../index.htm';</script>");
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}

