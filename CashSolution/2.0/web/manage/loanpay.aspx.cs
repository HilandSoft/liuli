namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;
	using YingNet.Common.Utils;

    public class loanpay : ManageBasePage
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        public string Date1 = "";
        public string Date2 = "";
        public string Date3 = "";
        protected HtmlInputHidden Hidden1;
        public string Loan = "";
        public string Repay1 = "";
        public string Repay2 = "";
        public string Repay3 = "";
        public string RTime = "";
        protected TextBox txPaid1;
        protected TextBox txPaid2;
        protected TextBox txPaid3;
        protected TextBox txPenalty1;
        protected TextBox txPenalty2;
        protected TextBox txPenalty3;
        protected TextBox txPtime1;
        protected TextBox txPtime2;
        protected TextBox txPtime3;

        private void Button1_Click(object sender, EventArgs e)
        {
            string commandText = "";
            if (this.Session["Schedule1"] != null)
            {
                string str2 = "";
                str2 = ((Convert.ToSingle(this.Session["Repay1"]) - Convert.ToSingle(this.txPaid1.Text)) + Convert.ToSingle(this.txPenalty1.Text)).ToString("0.00");
                commandText = string.Concat(new object[] { "update Schedule set Paid=", this.txPaid1.Text, ",Penalty=", this.txPenalty1.Text, ",Balance=", str2, ",RepayTime='", this.txPtime1.Text, "',OperateTime='", SafeDateTime.LocalNow.ToString(), "' where id=", this.Session["Schedule1"], "" });
                SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                if (this.Session["Schedule2"] != null)
                {
                    commandText = string.Concat(new object[] { "update Schedule set Balance=Repaydue+", str2, " where id=", this.Session["Schedule2"], "" });
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                }
                base.Response.Write("<script>alert('Success!');window.location.href='loandetail.aspx?id=" + this.Session["employid"] + "';</script>");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string commandText = "";
            if (this.Session["Schedule2"] != null)
            {
                string str2 = "";
                str2 = (((Convert.ToSingle(this.Session["Repay2"]) - Convert.ToSingle(this.txPaid2.Text)) + Convert.ToSingle(this.txPenalty2.Text)) + Convert.ToSingle(this.Session["Balance1"])).ToString("0.00");
                commandText = string.Concat(new object[] { "update Schedule set Paid=", this.txPaid2.Text, ",Penalty=", this.txPenalty2.Text, ",Balance=", str2, ",RepayTime='", this.txPtime2.Text, "',OperateTime='", SafeDateTime.LocalNow.ToString(), "' where id=", this.Session["Schedule2"], "" });
                SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                if (this.Session["Schedule2"] != null)
                {
                    commandText = string.Concat(new object[] { "update Schedule set Balance=Repaydue+", str2, " where id=", this.Session["Schedule2"], "" });
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                }
                if (this.Session["Schedule3"] != null)
                {
                    commandText = string.Concat(new object[] { "update Schedule set Balance=Repaydue+Repaydue+", str2, " where id=", this.Session["Schedule3"], "" });
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                }
                base.Response.Write("<script>alert('Success!');window.location.href='loandetail.aspx?id=" + this.Session["employid"] + "';</script>");
            }
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string commandText = "";
            if (this.Session["Schedule3"] != null)
            {
                string str2 = "";
                str2 = (((Convert.ToSingle(this.Session["Repay3"]) - Convert.ToSingle(this.txPaid3.Text)) + Convert.ToSingle(this.txPenalty3.Text)) + Convert.ToSingle(this.Session["Balance2"])).ToString("0.00");
                commandText = string.Concat(new object[] { "update Schedule set Paid=", this.txPaid3.Text, ",Penalty=", this.txPenalty3.Text, ",Balance=", str2, ",RepayTime='", this.txPtime3.Text, "',OperateTime='", SafeDateTime.LocalNow.ToString(), "' where id=", this.Session["Schedule3"], "" });
                SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                base.Response.Write("<script>alert('Success!');window.location.href='loandetail.aspx?id=" + this.Session["employid"] + "';</script>");
            }
        }

        private void InitializeComponent()
        {
            this.Button1.Click += new EventHandler(this.Button1_Click);
            this.Button2.Click += new EventHandler(this.Button2_Click);
            this.Button3.Click += new EventHandler(this.Button3_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.Button1.Attributes.Add("onclick", "return Check1();");
            this.Button2.Attributes.Add("onclick", "return Check2();");
            this.Button3.Attributes.Add("onclick", "return Check3();");
            EmployedBN dbn = new EmployedBN(this.Page);
            int id = Convert.ToInt32(base.Request["id"]);
            this.Hidden1.Value = id.ToString();
            EmployedDT ddt = dbn.Get(id);
            if (!this.Page.IsPostBack)
            {
                if (ddt.IsValid != 2)
                {
                    base.Response.Write("<script>alert('Note: Only approved application can be processed for repayment!');window.location.href='MemberList.aspx';</script>");
                }
                else
                {
                    this.RTime = ddt.RTime.ToShortDateString();
                    this.Loan = ddt.Loan.ToString();
                    ScheduleBN ebn = new ScheduleBN(this.Page);
                    ebn.QueryParam1(id.ToString());
                    DataTable listByTime = ebn.GetListByTime();
                    switch (listByTime.Rows.Count)
                    {
                        case 1:
                            this.Date1 = Convert.ToDateTime(listByTime.Rows[0]["Datedue"]).ToShortDateString();
                            this.Repay1 = Convert.ToSingle(listByTime.Rows[0]["Repaydue"]).ToString("0.00");
                            this.Session["Schedule1"] = listByTime.Rows[0]["id"].ToString();
                            this.Session["Repay1"] = this.Repay1;
                            this.txPaid1.Text = listByTime.Rows[0]["Paid"].ToString();
                            this.txPenalty1.Text = listByTime.Rows[0]["Penalty"].ToString();
                            if (Convert.ToDateTime(listByTime.Rows[0]["RepayTime"]).ToShortDateString() != "2000-1-1")
                            {
                                this.txPtime1.Text = listByTime.Rows[0]["RepayTime"].ToString();
                            }
                            return;

                        case 2:
                            this.Date1 = Convert.ToDateTime(listByTime.Rows[0]["Datedue"]).ToShortDateString();
                            this.Repay1 = Convert.ToSingle(listByTime.Rows[0]["Repaydue"]).ToString("0.00");
                            this.Session["Schedule1"] = listByTime.Rows[0]["id"].ToString();
                            this.Session["Repay1"] = this.Repay1;
                            this.Session["Balance1"] = listByTime.Rows[0]["Balance"].ToString();
                            this.Date2 = Convert.ToDateTime(listByTime.Rows[1]["Datedue"]).ToShortDateString();
                            this.Repay2 = Convert.ToSingle(listByTime.Rows[1]["Repaydue"]).ToString("0.00");
                            this.Session["Schedule2"] = listByTime.Rows[1]["id"].ToString();
                            this.Session["Repay2"] = this.Repay2;
                            this.txPaid1.Text = listByTime.Rows[0]["Paid"].ToString();
                            this.txPenalty1.Text = listByTime.Rows[0]["Penalty"].ToString();
                            if (Convert.ToDateTime(listByTime.Rows[0]["RepayTime"]).ToShortDateString() != "2000-1-1")
                            {
                                this.txPtime1.Text = listByTime.Rows[0]["RepayTime"].ToString();
                            }
                            this.txPaid2.Text = listByTime.Rows[1]["Paid"].ToString();
                            this.txPenalty2.Text = listByTime.Rows[1]["Penalty"].ToString();
                            if (Convert.ToDateTime(listByTime.Rows[1]["RepayTime"]).ToShortDateString() != "2000-1-1")
                            {
                                this.txPtime2.Text = listByTime.Rows[1]["RepayTime"].ToString();
                            }
                            if (listByTime.Rows[0]["RepayTime"] != null)
                            {
                                this.Button2.Enabled = true;
                            }
                            return;

                        case 3:
                            this.Date1 = Convert.ToDateTime(listByTime.Rows[0]["Datedue"]).ToShortDateString();
                            this.Repay1 = Convert.ToSingle(listByTime.Rows[0]["Repaydue"]).ToString("0.00");
                            this.Session["Schedule1"] = listByTime.Rows[0]["id"].ToString();
                            this.Session["Repay1"] = this.Repay1;
                            this.Session["Balance1"] = listByTime.Rows[0]["Balance"].ToString();
                            this.Date2 = Convert.ToDateTime(listByTime.Rows[1]["Datedue"]).ToShortDateString();
                            this.Repay2 = Convert.ToSingle(listByTime.Rows[1]["Repaydue"]).ToString("0.00");
                            this.Session["Schedule2"] = listByTime.Rows[1]["id"].ToString();
                            this.Session["Repay2"] = this.Repay2;
                            this.Session["Balance2"] = listByTime.Rows[1]["Balance"].ToString();
                            this.Date3 = Convert.ToDateTime(listByTime.Rows[2]["Datedue"]).ToShortDateString();
                            this.Repay3 = Convert.ToSingle(listByTime.Rows[2]["Repaydue"]).ToString("0.00");
                            this.Session["Schedule3"] = listByTime.Rows[2]["id"].ToString();
                            this.Session["Repay3"] = this.Repay3;
                            this.txPaid1.Text = listByTime.Rows[0]["Paid"].ToString();
                            this.txPenalty1.Text = listByTime.Rows[0]["Penalty"].ToString();
                            if (Convert.ToDateTime(listByTime.Rows[0]["RepayTime"]).ToShortDateString() != "2000-1-1")
                            {
                                this.txPtime1.Text = listByTime.Rows[0]["RepayTime"].ToString();
                            }
                            this.txPaid2.Text = listByTime.Rows[1]["Paid"].ToString();
                            this.txPenalty2.Text = listByTime.Rows[1]["Penalty"].ToString();
                            if (Convert.ToDateTime(listByTime.Rows[1]["RepayTime"]).ToShortDateString() != "2000-1-1")
                            {
                                this.txPtime2.Text = listByTime.Rows[1]["RepayTime"].ToString();
                            }
                            this.txPaid3.Text = listByTime.Rows[2]["Paid"].ToString();
                            this.txPenalty3.Text = listByTime.Rows[2]["Penalty"].ToString();
                            if (Convert.ToDateTime(listByTime.Rows[2]["RepayTime"]).ToShortDateString() != "2000-1-1")
                            {
                                this.txPtime2.Text = listByTime.Rows[2]["RepayTime"].ToString();
                            }
                            return;
                    }
                }
            }
        }
    }
}

