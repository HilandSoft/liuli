namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.STRUCTURE;

    public class LMemberLoadNotes : Page
    {
        protected LinkButton EditButton;
        private string fromAdd = string.Empty;
        private int memberID = 0;
        protected HyperLink returnButton;
        protected TextBox txtNoteDisplay;

        private void EditButton_Click(object sender, EventArgs e)
        {
            if (this.memberID > 0)
            {
                LpersonBN nbn = new LpersonBN(this.Page);
                LpersonDT detail = nbn.Get(this.memberID);
                if (detail != null)
                {
                    detail.Other1 = this.txtNoteDisplay.Text;
                    nbn.Edit(detail);
                }
                this.Page.Response.Write("<script>alert('Success!');window.location='" + this.GetReturnAdd() + "';</script>");
            }
        }

        private void GetInfo()
        {
            if (this.memberID > 0)
            {
                LpersonDT ndt = new LpersonBN(this.Page).Get(this.memberID);
                if (ndt != null)
                {
                    this.txtNoteDisplay.Text = ndt.Other1;
                }
            }
        }

        private string GetReturnAdd()
        {
            switch (this.fromAdd)
            {
                case "lp":
                    return "ProcessCenter/ProcessList.aspx";

                case "lf":
                    return "FollowupCenter/FollowupList.aspx";
            }
            return "LongList.aspx";
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

