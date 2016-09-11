namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class loandel : ManageBasePage
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
            EmployedBN dbn = new EmployedBN(this.Page);
            int id = Convert.ToInt32(base.Request["id"]);
            EmployedDT dt = dbn.Get(id);
            if (dt.Param3 > 1)
            {
                dt.IsValid = 5;
            }
            else
            {
                dt.IsValid = 4;
            }
            dbn.Edit(dt);
            string commandText = "update Schedule set IsValid=4 where Param1='" + id.ToString() + "'";
            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);

			//此处应该按照贷款id(loadID)进行删除;但是暂时按照会员id(huiSid)进行处理
			commandText= "delete from cs_ProcessCenter where UserLoanType=0 and userid=(select huiSid from Employed where id=" + id + ")";
			SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);

            base.Response.Write("<script>alert('Success!');window.location.href='MemberList.aspx';</script>");
        }
    }
}

