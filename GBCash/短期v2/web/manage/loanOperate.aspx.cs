namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI;
    using YingNet.Common;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class loanOperate : Page
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
            int num2 = Convert.ToInt32(base.Request["operate"]);
            EmployedBN dbn = new EmployedBN(this.Page);
            EmployedDT dt = dbn.Get(id);
            dt.IsValid = num2;
            dbn.Edit(dt);
            string commandText = string.Empty;
            commandText = string.Concat(new object[] { "update Huiyuan set IsValid=", num2, " where id = (select huiSid from Employed where id=", id, ")" });
            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
            if (num2 == 0x12)
            {
                CSProcessCenterBN rbn = new CSProcessCenterBN(this.Page);
                rbn.Filter = string.Format("UserLoanType=0 and userid=(select huiSid from Employed where id={0} )", id);
                DataTable list = rbn.GetList();
                if ((list != null) && (list.Rows.Count > 0))
                {
                    for (int i = 0; i < list.Rows.Count; i++)
                    {
                        int num4 = Convert.ToInt32(list.Rows[i]["ProcessID"]);
                        CSProcessCenterDT rdt = rbn.Get(num4);
                        if (rdt != null)
                        {
                            rdt.ProcessStatus = ProcessCenterStatusEnum.PreApproved;
                            rdt.ProcessStatusDisplay = "PreApproved";
                            rdt.LastOperateDate = SafeDateTime.LocalNow;
                            rbn.Edit(rdt);
                        }
                    }
                }
            }
            base.Response.Write("<script>alert('Success!');window.location.href='MemberList.aspx';</script>");
        }
    }
}

