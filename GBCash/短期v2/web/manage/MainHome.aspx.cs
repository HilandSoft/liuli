namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.Business.CommonLogic;
    using YingNet.WeiXing.DB.Data;

    public class MainHome : ManageBasePage
    {
        protected Button btnSave;
        protected TextBox txtNewCpass;
        protected TextBox txtNewPass;
        protected TextBox txtOldPass;

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (CommonInformation.CurrentVersion > 2)
            {
                CSUserBN rbn = new CSUserBN(this.Page);
                CSUserDT dt = rbn.Get(base.SystemUserID);
                if (dt.Password == Cipher.EncryptMD5(this.txtOldPass.Text.Trim()))
                {
                    dt.Password = Cipher.EncryptMD5(this.txtNewPass.Text);
                    if (rbn.Edit(dt))
                    {
                        base.Response.Write("<script>alert('Congradulations,Your password has been changed!');</script>");
                    }
                    else
                    {
                        base.Response.Write("<script>alert('Sorry,Your password has not been Changed!');</script>");
                    }
                }
                else
                {
                    base.Response.Write("<script>alert(''Sorry,Can you confirm the old password?');</script>");
                }
            }
            else
            {
                YingSystemUserBN rbn2 = new YingSystemUserBN(this.Page);
                YingSystemUserDT rdt2 = rbn2.Get(base.SystemUserID);
                if (rdt2.password.Trim() == Cipher.EncryptMD5(this.txtOldPass.Text.Trim()))
                {
                    rdt2.password = Cipher.EncryptMD5(this.txtNewPass.Text);
                    if (rbn2.Edit(rdt2))
                    {
                        base.Response.Write("<script>alert('修改密码成功');</script>");
                    }
                    else
                    {
                        base.Response.Write("<script>alert('修改密码失败！');</script>");
                    }
                }
                else
                {
                    base.Response.Write("<script>alert('原密码错误');</script>");
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
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            DataTable list = new HuiyuanBN(this.Page).GetList();
            for (int i = 0; i < list.Rows.Count; i++)
            {
                DateTime time = Convert.ToDateTime(list.Rows[i]["Regtime"]);
                int num2 = Convert.ToInt32(list.Rows[i]["IsValid"]);
                string commandText = "";
                TimeSpan span = (TimeSpan) (SafeDateTime.LocalNow - time);
                switch (num2)
                {
                    case 0:
                        if (span.Days >= 15)
                        {
                            commandText = "update Huiyuan set IsValid=5 where id =" + list.Rows[i]["id"].ToString();
                            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                        }
                        break;

                    case 8:
                        if (span.Days >= 3)
                        {
                            commandText = "update Huiyuan set IsValid=6 where id =" + list.Rows[i]["id"].ToString();
                            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                        }
                        break;
                }
            }
        }
    }
}

