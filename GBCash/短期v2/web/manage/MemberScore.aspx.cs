namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class MemberScore : Page
    {
        protected LinkButton EditButton;
        private string fromAdd = string.Empty;
        private int memberID = 0;
        protected HyperLink returnButton;
        protected TextBox txtScoreDisplay;

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (this.memberID > 0)
            {
                HuiyuanBN nbn = new HuiyuanBN(this.Page);
                HuiyuanDT dt = nbn.Get(this.memberID);
                if (dt != null)
                {
                    dt.Param3 = this.txtScoreDisplay.Text;
                    nbn.Edit(dt);
                }
                this.Page.Response.Write("<script>alert('Success!');window.location='" + this.GetReturnAdd() + "';</script>");
            }
        }

        private void GetInfo()
        {
            if (this.memberID > 0)
            {
                HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(this.memberID);
                if (ndt != null)
                {
                    this.txtScoreDisplay.Text = ndt.Param3;
                }
            }
        }

        private string GetReturnAdd()
        {
            switch (this.fromAdd)
            {
                case "sp":
                    return "ProcessCenter/ProcessList.aspx";

                case "sf":
                    return "FollowupCenter/FollowupList.aspx";
            }
            return "MemberList.aspx";
        }

        private void InitializeComponent()
        {
            this.EditButton.Click += new EventHandler(this.EditButton_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.memberID = Convert.ToInt32(base.Request.QueryString["id"]);
            this.fromAdd = base.Request.QueryString["from"];
            if (!base.IsPostBack)
            {
                this.GetInfo();
            }
            this.returnButton.NavigateUrl = this.GetReturnAdd();
        }
    }
}

