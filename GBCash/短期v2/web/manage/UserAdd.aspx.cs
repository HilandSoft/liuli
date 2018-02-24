namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Text;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class UserAdd : ManageBasePage
    {
        protected HtmlInputButton Button1;
        protected Button Button2;
        protected HtmlInputButton Button3;
        protected Label Lab_name;
        protected Label lab_password;
        protected Label lab_user;
        protected Label Label1;
        protected TextBox Tex_Name;
        protected TextBox Tex_Password;
        protected TextBox Tex_User;
        protected TextBox txtParamstr;

        private void Button1_ServerClick(object sender, EventArgs e)
        {
            base.Response.Redirect("UserManage.Aspx?" + base.PackFull(this.txtParamstr.Text));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            YingSystemUserBN rbn = new YingSystemUserBN(this.Page);
            if (!rbn.isAccount(this.Tex_User.Text.Trim()))
            {
                YingSystemUserDT dt = new YingSystemUserDT();
                dt.id = 1;
                dt.account = this.Tex_User.Text;
                dt.name = this.Tex_Name.Text;
                dt.password = Cipher.EncryptMD5(this.Tex_Password.Text);
                dt.isactive = true;
                dt.deptpermit = "1";
                Hashtable hashtable = new Hashtable();
                if (base.Request["Checkbox1"] != null)
                {
                    foreach (string str in base.Request["Checkbox1"].Split(new char[] { ',' }))
                    {
                        hashtable.Add(str.Trim(), str.Trim());
                    }
                }
                dt.permit = hashtable;
                hashtable = null;
                if (rbn.Add(dt))
                {
                    base.Response.Redirect("UserManage.Aspx?" + base.PackFull(this.txtParamstr.Text));
                }
                else
                {
                    base.Response.Write("<script>alert('添加用户失败!!');</script>");
                }
            }
            else
            {
                base.Response.Write("<script>alert('此用户已被使用,请换一个用户再试一次!');</script>");
            }
        }

        private void Button3_ServerClick(object sender, EventArgs e)
        {
            this.Tex_Name.Text = "";
            this.Tex_User.Text = "";
            this.Tex_Password.Text = "";
        }

        private void InitializeComponent()
        {
            this.Button2.Click += new EventHandler(this.Button2_Click);
            this.Button1.ServerClick += new EventHandler(this.Button1_ServerClick);
            this.Button3.ServerClick += new EventHandler(this.Button3_ServerClick);
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
            if (!base.IsPostBack)
            {
                base.ParamValue = base.UnPack();
                this.txtParamstr.Text = base.PackPart(base.ParamValue);
                YingSystemModuleBN ebn = new YingSystemModuleBN(this.Page);
                DataRow[] rowArray = ebn.GetList().Select();
                string str = null;
                StringBuilder builder = new StringBuilder();
                builder.Append("<table align=center border='1' cellpadding='2' cellspacing='2' width='75%' style='font-size:14px'><tr height='26'>");
                foreach (DataRow row in rowArray)
                {
                    if ((str != row[1].ToString()) && (str != null))
                    {
                        builder.Append("</td></tr><tr height='26'><td><nobr>");
                        builder.Append(row[1].ToString());
                        builder.Append("</nobr></td><td><nobr>");
                    }
                    if (str == null)
                    {
                        builder.Append("<td><nobr>");
                        builder.Append(row[1].ToString());
                        builder.Append("</nobr></td><td><nobr>");
                    }
                    builder.Append("<INPUT id='Checkbox1' value='");
                    builder.Append(row[0].ToString());
                    builder.Append("' type='checkbox' ");
                    builder.Append(" name='Checkbox1'>&nbsp;&nbsp;");
                    builder.Append(row[2].ToString());
                    str = row[1].ToString();
                }
                builder.Append("</nobr></td></tr></table>");
                this.Label1.Text = builder.ToString();
            }
            else
            {
                base.ParamValue = base.UnPackPart(this.txtParamstr.Text);
            }
        }
    }
}

