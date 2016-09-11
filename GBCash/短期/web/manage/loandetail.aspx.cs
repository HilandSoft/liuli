namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Text;
    using YingNet.WeiXing.Business;
	using YingNet.Common.Utils;

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
                    string str4;
                    ScheduleBN ebn = new ScheduleBN(this.Page);
                    ebn.QueryParam1(list.Rows[i]["id"].ToString());
                    ebn.QueryNotValid("3");
                    DataTable listByTime = ebn.GetListByTime();
                    int num3 = listByTime.Rows.Count;
//					if(num3==0)
//					{
//						throw new Exception(ebn.Filter);
//					}

                    builder.Append("<table align='center' width='100%' border='0' cellspacing='1' cellpadding='1'>");
                    builder.Append("<tr><td colspan='2'><strong>My Loans </strong></td></tr>");
                    builder.Append("<tr><td>Application Date:</td><td>");
                    DateTime time = Convert.ToDateTime(list.Rows[i]["RTime"]);
                    builder.Append(time.Day.ToString() + "/" + time.Month.ToString() + "/" + time.Year.ToString() + "</td></tr>");
                    builder.Append("<tr><td>Loan Amount:</td><td>" + Convert.ToSingle(list.Rows[i]["Loan"]).ToString("0.00") + "</td></tr>");
                    string str2 = "";
                    switch (list.Rows[i]["IsValid"].ToString())
                    {
                        case "0":
                            str2 = "Rejected";
                            goto Label_028A;

                        case "1":
                            str2 = "Completed";
                            goto Label_028A;

                        case "2":
                            str2 = "Approved";
                            goto Label_028A;

                        case "3":
                            str2 = "Pending";
                            goto Label_028A;

                        case "4":
                            str2 = "Deleted";
                            break;

                        case "5":
                            str2 = "Deleted";
                            break;
						case "18":
							str2= "PreApprove";
							break;
						case "21":
							str2= "ReudcedLimit";
							break;
						case "22":
							str2= "BlackList";
							break;
						case "23":
							str2= "PermantlyBlackList";
							break;
						case "24":
							str2="Collection";
							break;
                    }
                Label_028A:
                    str4 = list.Rows[i]["id"].ToString();
                    builder.Append("<tr><td>Status:</td><td>" + str2 + "</td></tr>");
                    builder.Append("<tr><td>Full Name:</td><td>" + list.Rows[i]["Param4"].ToString() + "</td></tr>");
                    builder.Append("<tr><td>Operate:</td><td><a href=loanOperate.aspx?operate=18&id="+str4 +">PreApprove</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=loanapprove.aspx?id=" + str4 + ">Approve</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=loanreject.aspx?id=" + str4 + ">Reject</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=loancomplete.aspx?id=" + str4 + ">Complete</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=loandel.aspx?id=" + str4 + ">Delete</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=loanOperate.aspx?operate=22&id="+str4 +">BlackList</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=loanOperate.aspx?operate=24&id="+str4 +">Collection</a>&nbsp;&nbsp;&nbsp;&nbsp;<a href=loanpay2.aspx?id=" + str4 + ">Repay</a></td></tr>");
                    builder.Append("<tr><td colspan='2'>Payment Schedule:</td></tr>");
                    builder.Append("<tr><td colspan='2'><table width='100%' border='0' cellspacing='0' cellpadding='0'>");
                    builder.Append("<tr><td width='8%'></td><td width='9%'>Date due</td><td width='9%'>Repayment due</td><td width='6%'>Paid</td><td width='6%'>Penalty</td><td width='8%'>Balance</td><td width='8%'>RepayTime</td><td width='12%'>OperateTime</td><td width='4%'>Delete</td><td width='9%'>Full Name</td></tr>");
                    for (int j = 0; j < num3; j++)
                    {
                        builder.Append("<tr><td >Installment " + ((j + 1)).ToString()+ "<span style='display:none'>("+ listByTime.Rows[j]["id"].ToString() +")</span>" + "</td>");
						//builder.Append("<tr><td width='10%'>Installment " + ((j + 1)).ToString() + "</td>");
                        DateTime time2 = Convert.ToDateTime(listByTime.Rows[j]["Datedue"]);
                        builder.Append("<td>" + (time2.Day.ToString() + "/" + time2.Month.ToString() + "/" + time2.Year.ToString()) + "</td>");
                        builder.Append("<td>" + Convert.ToSingle(listByTime.Rows[j]["Repaydue"]).ToString("0.00") + "</td>");
                        builder.Append("<td>" + Convert.ToSingle(listByTime.Rows[j]["Paid"]).ToString("0.00") + "</td>");
                        builder.Append("<td>" + Convert.ToSingle(listByTime.Rows[j]["Penalty"]).ToString("0.00") + "</td>");
                        builder.Append("<td>" + Convert.ToSingle(listByTime.Rows[j]["Balance"]).ToString("0.00") + "</td>");
                        string str6 = "";
                        string str7 = "";
                        if (Convert.ToDateTime(listByTime.Rows[j]["RepayTime"]).ToShortDateString() != "1/1/2000")
                        {
                            DateTime time3 = Convert.ToDateTime(listByTime.Rows[j]["RepayTime"]);
                            str6 = time3.Day.ToString() + "/" + time3.Month.ToString() + "/" + time3.Year.ToString();
                        }
                        builder.Append("<td>" + str6 + "</td>");
                        if (Convert.ToDateTime(listByTime.Rows[j]["OperateTime"]).ToShortDateString() != "1/1/2000")
                        {
                            DateTime time4 = Convert.ToDateTime(listByTime.Rows[j]["OperateTime"]);
                            str7 = time4.Day.ToString() + "/" + time4.Month.ToString() + "/" + time4.Year.ToString() + " " + time4.ToShortTimeString();
                        }
                        builder.Append("<td>" + str7 + "</td>");
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

