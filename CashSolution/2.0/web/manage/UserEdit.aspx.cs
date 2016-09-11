namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Collections;
    using System.Data;
    using System.Text;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class UserEdit : ManageBasePage
    {
        protected HtmlInputButton Button1;
        protected Button Button2;
        protected Label Lab_name;
        protected Label lab_user;
        protected Label Label1;
        protected TextBox Tex_Name;
        protected TextBox Tex_User;
        protected TextBox TexSaveID;
        protected TextBox txtParamstr;

        private void Button1_ServerClick(object sender, EventArgs e)
        {
            base.Response.Redirect("UserManage.Aspx?" + base.PackFull(this.txtParamstr.Text));
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            YingSystemUserBN rbn = new YingSystemUserBN(this.Page);
            if (this.TexSaveID.Text != null)
            {
                YingSystemUserDT dt = rbn.Get(Convert.ToInt32(this.TexSaveID.Text));
                if (dt != null)
                {
                    dt.name = this.Tex_Name.Text;
                    dt.deptpermit = "";
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
                    if (rbn.Edit(dt))
                    {
                        base.Response.Redirect("UserManage.Aspx?" + base.PackFull(this.txtParamstr.Text));
                    }
                    else
                    {
                        base.Response.Write("<script>alert('修改用户失败!!');</script>");
                    }
                }
            }
        }

        private void InitializeComponent()
        {
            this.Button2.Click += new EventHandler(this.Button2_Click);
            this.Button1.ServerClick += new EventHandler(this.Button1_ServerClick);
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
                Hashtable permit = null;
                YingSystemUserBN rbn = new YingSystemUserBN(this.Page);
                if (base.Request["id"] != null)
                {
                    this.TexSaveID.Text = base.Request["id"];
                    YingSystemUserDT rdt = rbn.Get(Convert.ToInt32(base.Request["id"]));
                    if (rdt != null)
                    {
                        this.Tex_User.Text = rdt.account;
                        this.Tex_Name.Text = rdt.name;
                        permit = rdt.permit;
                    }
                }
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
                    if (permit.ContainsKey(row[0].ToString().Trim()))
                    {
                        builder.Append(" checked ");
                    }
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

