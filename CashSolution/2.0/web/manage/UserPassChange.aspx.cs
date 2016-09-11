namespace YingNet.WeiXing.WebApp
{
	using System;
	using System.Web.UI.WebControls;
	using YingNet.Common;
	using YingNet.WeiXing.Business;
	using YingNet.WeiXing.DB.Data;

	public class UserPassChange : ManageBasePage
	{
		protected Button btnSave;
		protected TextBox txtNewCpass;
		protected TextBox txtNewPass;
		protected TextBox txtOldPass;
		protected TextBox txtParamstr;

		private void btnSave_Click(object sender, EventArgs e)
		{
			int sessionUID = base.SystemUserID;
			using (YingSystemUserBN rbn = new YingSystemUserBN(this.Page))
			{
				YingSystemUserDT dt = new YingSystemUserDT();
				dt = rbn.GetModel(sessionUID);
				if (dt.password == Cipher.EncryptMD5(this.txtOldPass.Text))
				{
					dt.password = Cipher.EncryptMD5(this.txtNewPass.Text);
					if (rbn.Edit(dt))
					{
						base.Response.Write("<script>alert('–ﬁ∏ƒ√‹¬Î≥…π¶');</script>");
					}
					else
					{
						base.Response.Write("<script>alert('–ﬁ∏ƒ√‹¬Î ß∞‹£°');</script>");
					}
				}
				else
				{
					base.Response.Write("<script>alert('‘≠√‹¬Î¥ÌŒÛ');</script>");
				}
			}
		}

		private void InitializeComponent()
		{
			this.btnSave.Click += new EventHandler(this.btnSave_Click);
			base.Load += new EventHandler(this.Page_Load);
		}

		protected override void OnInit(EventArgs e)
		{
			base.Code = "001001";
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			if (!this.Page.IsPostBack)
			{
			}
		}
	}
}

