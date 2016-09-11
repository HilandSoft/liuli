namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class ScheduleDel : ManageBasePage
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
            ScheduleBN ebn = new ScheduleBN(this.Page);
            int id = Convert.ToInt32(base.Request["id"]);
            ScheduleDT dt = ebn.Get(id);
            string str = dt.Param1;
            float num2 = Convert.ToSingle(dt.Repaydue);
            float num3 = Convert.ToSingle(dt.Paid);
            float num4 = Convert.ToSingle(dt.Penalty);
            float num5 = Convert.ToSingle(dt.Balance);
            DateTime datedue = dt.Datedue;
            //需要将日期格式 由 dd/MM/yyyy转换成 yyyy/MM/dd
			//string str2 = datedue.Day.ToString() + "/" + datedue.Month.ToString() + "/" + datedue.Year.ToString();
			string dateConverted= string.Empty;
			dateConverted= datedue.ToString(Config.DateRecordFormat);
			//---------------------------------------------
            dt.IsValid = 3;
            ebn.Edit(dt);
            ScheduleBN ebn2 = new ScheduleBN(this.Page);
            ebn2.QueryParam1(str);
            DataTable list = ebn2.GetList();
            int count = list.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                ScheduleDT edt2 = new ScheduleBN(this.Page).Get(Convert.ToInt32(list.Rows[i]["id"]));
                string commandText = string.Concat(new object[] { "update Schedule set Balance=Balance-", num2.ToString(), " where id=", edt2.id, " and Balance>0 and Datedue>'", dateConverted, "'" });
                SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
            }
            base.Response.Write("<script>alert('Success!');window.location.href='MemberList.aspx';</script>");
        }
    }
}

