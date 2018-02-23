namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Text;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;

    public class loandetail : ManageBasePage
    {
        public string content = "";
        public string strqqTime = "";

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
            this.strqqTime = SafeDateTime.LocalNow.ToString();
            if (!this.Page.IsPostBack)
            {
                string str = base.Request["id"].ToString();
                this.Session["employid"] = str;
                EmployedBN dbn = new EmployedBN(this.Page);
                dbn.QueryhuiSid(str);
                DataTable list = dbn.GetList();
                int count = list.Rows.Count;
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < count; i++)
                {
                    ScheduleBN ebn = new ScheduleBN(this.Page);
                    ebn.QueryParam1(list.Rows[i]["id"].ToString());
                    ebn.QueryNotValid("3");
                    DataTable listByTime = ebn.GetListByTime();
                    int num3 = listByTime.Rows.Count;
                    builder.Append("<table align='center' width='100%' border='0' cellspacing='1' cellpadding='1'>");
                    builder.Append("<tr><td colspan='2'><strong>My Loans </strong></td></tr>");
                    builder.Append("<tr><td>Application Date:</td><td>");
                    DateTime time = Convert.ToDateTime(list.Rows[i]["RTime"]);
                    builder.Append(time.Day.ToString() + "/" + time.Month.ToString() + "/" + time.Year.ToString() + "</td></tr>");
                    builder.Append("<tr><td>Loan Amount:</td><td>" + Convert.ToSingle(list.Rows[i]["Loan"]).ToString("0.00") + "</td></tr>");
                    string str3 = "";
                    switch (list.Rows[i]["IsValid"].ToString())
                    {
                        case "0":
                            str3 = "Rejected";
                            break;

                        case "1":
                            str3 = "Completed";
                            break;

                        case "2":
                            str3 = "Approved";
                            break;

                        case "3":
                            str3 = "Pending";
                            break;

                        case "4":
                            str3 = "Deleted";
                            break;

                        case "5":
                            str3 = "Deleted";
                            break;

                        case "18":
                            str3 = "PreApprove";
                            break;

                        case "21":
                            str3 = "ReudcedLimit";
                            break;

                        case "22":
                            str3 = "BlackList";
                            break;

                        case "23":
                            str3 = "PermantlyBlackList";
                            break;

                        case "24":
                            str3 = "Collection";
                            break;
                    }
                    string str2 = list.Rows[i]["id"].ToString();
                    builder.Append("<tr><td>Status:</td><td>" + str3 + "</td></tr>");
                    builder.Append("<tr><td>Full Name:</td><td>" + list.Rows[i]["Param4"].ToString() + "</td></tr>");
                    builder.Append("<tr><td>Operate:</td><td><a href=loanOperate.aspx?operate=18&id=" + str2 + ">PreApprove</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=loanapprove.aspx?id=" + str2 + ">Approve</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=loanreject.aspx?id=" + str2 + ">Reject</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=loancomplete.aspx?id=" + str2 + ">Complete</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=loandel.aspx?id=" + str2 + ">Delete</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=loanOperate.aspx?operate=22&id=" + str2 + ">BlackList</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=loanOperate.aspx?operate=24&id=" + str2 + ">Collection</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=loanpay2.aspx?id=" + str2 + ">Repay</a></td></tr>");
                    builder.Append("<tr><td colspan='2'>Payment Schedule:</td></tr>");
                    builder.Append("<tr><td colspan='2'><table width='100%' border='0' cellspacing='0' cellpadding='0'>");
                    builder.Append("<tr><td width='8%'></td><td width='9%'>Date due</td><td width='9%'>Repayment due</td><td width='6%'>Paid</td><td width='6%'>Penalty</td><td width='8%'>Balance</td><td width='8%'>RepayTime</td><td width='12%'>OperateTime</td><td width='4%'>Delete</td><td width='9%'>Full Name</td></tr>");
                    float num4 = 0f;
                    for (int j = 0; j < num3; j++)
                    {
                        string[] strArray3 = new string[] { "<tr><td >Installment ", (j + 1).ToString(), "<span style='display:none'>(", listByTime.Rows[j]["id"].ToString(), ")</span></td>" };
                        builder.Append(string.Concat(strArray3));
                        DateTime time2 = Convert.ToDateTime(listByTime.Rows[j]["Datedue"]);
                        builder.Append("<td>" + time2.Day.ToString() + "/" + time2.Month.ToString() + "/" + time2.Year.ToString() + "</td>");
                        float num6 = Convert.ToSingle(listByTime.Rows[j]["Repaydue"]);
                        num4 += num6;
                        builder.Append("<td>" + num6.ToString("0.00") + "</td>");
                        float num7 = Convert.ToSingle(listByTime.Rows[j]["Paid"]);
                        num4 -= num7;
                        builder.Append("<td>" + num7.ToString("0.00") + "</td>");
                        float num8 = Convert.ToSingle(listByTime.Rows[j]["Penalty"]);
                        num4 += num8;
                        builder.Append("<td>" + num8.ToString("0.00") + "</td>");
                        builder.Append("<td>" + num4.ToString("0.00") + "</td>");
                        string str4 = "";
                        string str5 = "";
                        if (Convert.ToDateTime(listByTime.Rows[j]["RepayTime"]) > new DateTime(0x7d0, 1, 1))
                        {
                            DateTime time3 = Convert.ToDateTime(listByTime.Rows[j]["RepayTime"]);
                            str4 = time3.Day.ToString() + "/" + time3.Month.ToString() + "/" + time3.Year.ToString();
                        }
                        builder.Append("<td>" + str4 + "</td>");
                        if (Convert.ToDateTime(listByTime.Rows[j]["OperateTime"]) > new DateTime(0x7d0, 1, 1))
                        {
                            DateTime time4 = Convert.ToDateTime(listByTime.Rows[j]["OperateTime"]);
                            str5 = time4.Day.ToString() + "/" + time4.Month.ToString() + "/" + time4.Year.ToString() + " " + time4.ToShortTimeString();
                        }
                        builder.Append("<td>" + str5 + "</td>");
                        if (listByTime.Rows[j]["Param2"].ToString() == "1")
                        {
                            builder.Append("<td><a href=ScheduleDel.aspx?id=" + listByTime.Rows[j]["id"].ToString() + ">Delete</a></td>");
                        }
                        if (listByTime.Rows[j]["Param3"] != null)
                        {
                            builder.Append("<td>" + listByTime.Rows[j]["Param3"].ToString() + "</td></tr>");
                        }
                        else
                        {
                            builder.Append("<td></td></tr>");
                        }
                    }
                    builder.Append("</table></td></tr>");
                }
                this.content = builder.ToString();
            }
        }
    }
}

