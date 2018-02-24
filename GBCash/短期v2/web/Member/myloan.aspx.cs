namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Data;
    using System.Text;
    using YingNet.WeiXing.Business;

    public class myloan : generagepage
    {
        public string content = "";

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
            if (!this.Page.IsPostBack)
            {
                EmployedBN dbn = new EmployedBN(this.Page);
                dbn.QueryhuiSid(base.HuiSid);
                dbn.Filter = " (IsValid!=4 and IsValid!=5) ";
                DataTable list = dbn.GetList();
                int count = list.Rows.Count;
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < count; i++)
                {
                    ScheduleBN ebn = new ScheduleBN(this.Page);
                    ebn.QueryParam1(list.Rows[i]["id"].ToString());
                    ebn.Filter = " IsValid!=3 ";
                    DataTable listByTime = ebn.GetListByTime();
                    int num3 = listByTime.Rows.Count;
                    builder.Append("<table bordercolor='#e8e6df' align='center' width='98%' border='1' cellspacing='0' cellpadding='0'>");
                    builder.Append("<tr><td bgcolor='#e8eedf'>Application Date:</td><td bgcolor='#e8eedf'>" + Convert.ToDateTime(list.Rows[i]["RTime"]).Day.ToString() + "/" + Convert.ToDateTime(list.Rows[i]["RTime"]).Month.ToString() + "/" + Convert.ToDateTime(list.Rows[i]["RTime"]).Year.ToString() + "</td></tr>");
                    builder.Append("<tr><td>Loan Amount:</td><td>" + Convert.ToSingle(list.Rows[i]["Loan"]).ToString("0.00") + "</td></tr>");
                    string str2 = "";
                    switch (list.Rows[i]["IsValid"].ToString())
                    {
                        case "0":
                            str2 = "Rejected";
                            break;

                        case "1":
                            str2 = "Completed";
                            break;

                        case "2":
                            str2 = "Approved";
                            break;

                        case "3":
                            str2 = "Pending";
                            break;

                        case "4":
                            str2 = "Deleted";
                            break;

                        case "5":
                            str2 = "Deleted";
                            break;
                    }
                    string str = list.Rows[i]["id"].ToString();
                    builder.Append("<tr><td>Status:</td><td>" + str2 + "</td></tr>");
                    builder.Append("<tr><td colspan='2'>Payment Schedule:</td></tr>");
                    builder.Append("<tr><td colspan='2'><table bordercolor='#e8e6df' width='100%' border='1' cellspacing='0' cellpadding='0'>");
                    builder.Append("<tr><td width='11%'></td><td width='8%'>Date Due</td><td width='12%'>Repayment Due</td><td width='10%'>Amount Paid</td><td width='10%'>Date Paid</td><td width='5%'>Penalty</td><td width='6%'>Balance</td></tr>");
                    for (int j = 0; j < num3; j++)
                    {
                        builder.Append("<tr><td width='11%'>Installment " + ((j + 1)).ToString() + "</td>");
                        builder.Append("<td width=\"8%\">" + Convert.ToDateTime(listByTime.Rows[j]["Datedue"]).Day.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[j]["Datedue"]).Month.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[j]["Datedue"]).Year.ToString() + "</td>");
                        builder.Append("<td width=\"12%\">" + Convert.ToSingle(listByTime.Rows[j]["Repaydue"]).ToString("0.00") + "</td>");
                        builder.Append("<td width=\"10%\">" + Convert.ToSingle(listByTime.Rows[j]["Paid"]).ToString("0.00") + "</td>");
                        string str3 = "";
                        string str4 = "";
                        if (Convert.ToDateTime(listByTime.Rows[j]["RepayTime"]).ToShortDateString() != "1/1/2000")
                        {
                            str3 = Convert.ToDateTime(listByTime.Rows[j]["RepayTime"]).Day.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[j]["RepayTime"]).Month.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[j]["RepayTime"]).Year.ToString();
                        }
                        if (Convert.ToDateTime(listByTime.Rows[j]["OperateTime"]).ToShortDateString() != "1/1/2000")
                        {
                            str4 = Convert.ToDateTime(listByTime.Rows[j]["OperateTime"]).Day.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[j]["OperateTime"]).Month.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[j]["OperateTime"]).Year.ToString();
                        }
                        builder.Append("<td width=\"10%\">" + str3 + "</td>");
                        builder.Append("<td width=\"5%\">" + Convert.ToSingle(listByTime.Rows[j]["Penalty"]).ToString("0.00") + "</td>");
                        builder.Append("<td width=\"6%\">" + Convert.ToSingle(listByTime.Rows[j]["Balance"]).ToString("0.00") + "</td>");
                    }
                    builder.Append("</table></td></tr>");
                }
                this.content = builder.ToString();
            }
        }
    }
}

