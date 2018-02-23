namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class MemberLoadNotes : Page
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
                MemberLoadNoteBN ebn = new MemberLoadNoteBN(this.Page);
                MemberLoadNoteDT byMemberID = ebn.GetByMemberID(this.memberID);
                if (byMemberID != null)
                {
                    byMemberID.NoteContent = this.txtNoteDisplay.Text;
                    ebn.Edit(byMemberID);
                }
                else
                {
                    byMemberID = new MemberLoadNoteDT();
                    byMemberID.NoteContent = this.txtNoteDisplay.Text;
                    byMemberID.NodeStatus = 1;
                    byMemberID.NodeOrder = 0;
                    byMemberID.NodeDesc = string.Empty;
                    byMemberID.MemberID = this.memberID;
                    byMemberID.ExtendedValues = null;
                    byMemberID.ExtendedNames = null;
                    ebn.Add(byMemberID);
                }
                this.Page.Response.Write("<script>alert('Success!');window.location='" + this.GetReturnAdd() + "';</script>");
            }
        }

        private void GetInfo()
        {
            if (this.memberID > 0)
            {
                MemberLoadNoteDT byMemberID = new MemberLoadNoteBN(this.Page).GetByMemberID(this.memberID);
                if (byMemberID != null)
                {
                    this.txtNoteDisplay.Text = byMemberID.NoteContent;
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

