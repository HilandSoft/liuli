namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Data;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class myloandel : generagepage
    {
        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(base.Request["id"]);
            EmployedBN dbn = new EmployedBN(this.Page);
            EmployedDT dt = dbn.Get(id);
            if (dt.IsValid == 1)
            {
                dt.IsValid = 4;
                dbn.Edit(dt);
                string commandText = "update Schedule set IsValid=4 where Param1='" + id + "'";
                SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText);
                base.Response.Write("<script>alert('Success!');window.location.href='myloan.aspx';</script>");
            }
            else
            {
                base.Response.Write("<script>alert('Error!');window.location.href='myloan.aspx';</script>");
            }
        }
    }
}

