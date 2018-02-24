namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class loanextension : generagepage
    {
        protected Button Button1;
        protected Button Button2;
        public string Content1 = "";
        public string Content2 = "";
        public string ContentNewSchedule = "";
        public string CustomerNum = "";
        protected HtmlForm Form2;
        protected HtmlInputHidden Hidden1;
        protected HtmlInputHidden Hidden2;
        protected HtmlInputHidden HiddenCalced;
        protected Label LabWarning;
        public string LoanAmount = "";
        public string Name = "";
        protected TextBox TextBox1;
        protected TextBox txFullname;

        private void Button1_Click(object sender, EventArgs e)
        {
            if (this.HiddenCalced.Value == "")
            {
                base.Response.Write("<script>alert(\"Please click 'Calculate' button for repayment schedule before you submit the application.\");</script>");
            }
            else if (this.txFullname.Text == "")
            {
                base.Response.Write("<script>alert('You need to sign by tying in your FULL name before submission.');</script>");
            }
            else
            {
                ScheduleBN ebn = new ScheduleBN(this.Page);
                ebn.QueryParam1(this.Session["currentLoanID"].ToString());
                ebn.QueryNotValid("3");
                int count = ebn.GetList().Rows.Count;
                string commandText = "";
                float num2 = Convert.ToSingle(this.Session["delayCurrentPay"]);
                int num3 = Convert.ToInt32(this.Session["delayCurrentScheduleID"]);
                float num4 = Convert.ToSingle(this.Session["delayAfterPay"]);
                DateTime time = Convert.ToDateTime(this.Session["delayAfterDate"]);
                commandText = string.Concat(new object[] { "update Schedule set Param4=1, Repaydue='", num2, "' where id=", num3, "" });
                SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                commandText = string.Concat(new object[] { "insert into Schedule(Datedue,Repaydue,huiSid,IsValid,Numberment,Param1,Param2,Param3,Balance,RepayTime,OperateTime) values('", time, "',", num4, ",", this.Hidden2.Value, ",2,", 0, ",'", this.Session["currentLoanID"], "','1','", this.txFullname.Text, "',", 0, ",'1/1/2000','1/1/2000')" });
                SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(Convert.ToInt32(this.Hidden2.Value));
                InfoBN obn = new InfoBN(this.Page);
                InfoDT dt = new InfoDT();
                dt.huiSid = Convert.ToInt32(this.Hidden2.Value);
                dt.Username = ndt.Username;
                dt.type = "5";
                dt.regtime = SafeDateTime.LocalNow;
                dt.isvalid = 1;
                obn.Add(dt);
                base.Response.Write("<script>alert('Congratulation! Your loan extension application has been sent successfully.');window.location.href='detail1.aspx';</script>");
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.CalLoan();
        }

        public void CalLoan()
        {
            if ((base.Request["Radio0"] != null) && (base.Request["Radio0"].ToString() != ""))
            {
                ScheduleBN ebn = new ScheduleBN(this.Page);
                ebn.QueryParam1(this.Session["currentLoanID"].ToString());
                ebn.QueryNotValid("3");
                DataTable listByTime = ebn.GetListByTime();
                int count = listByTime.Rows.Count;
                string str = base.Request["Radio0"];
                int id = Convert.ToInt32(str.Substring(0, str.IndexOf("&")));
                int num3 = Convert.ToInt32(str.Substring(str.IndexOf("&") + 1, 1));
                this.Session["iNum"] = num3;
                float num4 = 0f;
                float num6 = 0f;
                float num7 = 0f;
                float num8 = 0f;
                string str3 = "";
                int num9 = 0;
                ScheduleDT edt = ebn.Get(id);
                DateTime datedue = edt.Datedue;
                if (edt.Datedue.AddDays(-3.0) < SafeDateTime.LocalToday)
                {
                    this.LabWarning.Text = "WARNING:duedate must go beyond 2 days today!";
                    this.LabWarning.Visible = true;
                }
                else
                {
                    this.LabWarning.Visible = false;
                    num7 = Convert.ToSingle(edt.Repaydue);
                    num8 = Convert.ToInt32(edt.Numberment);
                    str3 = edt.Param1;
                    this.Session["oldRepay"] = num7;
                    this.Session["Numberment"] = num8;
                    this.Session["Param1"] = str3;
                    this.Session["Balance"] = edt.Balance;
                    this.Session["Repaydue"] = edt.Repaydue;
                    EmployedBN dbn = new EmployedBN(this.Page);
                    dbn.QueryhuiSid(this.Hidden2.Value);
                    EmployedDT ddt = dbn.Get(Convert.ToInt32(this.Session["currentLoanID"]));
                    num4 = Convert.ToSingle(ddt.Loan);
                    num9 = Convert.ToInt32(ddt.NInstallment);
                    num6 = Convert.ToSingle(ddt.Frequency);
                    DataRow row = null;
                    int num11 = listByTime.Rows.Count;
                    for (int i = 0; i < num11; i++)
                    {
                        if (Convert.ToInt32(listByTime.Rows[i]["id"]) == id)
                        {
                            row = listByTime.Rows[i];
                        }
                    }
                    DataRow row2 = listByTime.NewRow();
                    row2["Repaydue"] = row["Repaydue"];
                    this.Session["delayAfterPay"] = row2["Repaydue"];
                    row2["Datedue"] = Convert.ToDateTime(listByTime.Rows[count - 1]["Datedue"]).AddDays((double) num6);
                    this.Session["delayAfterDate"] = row2["Datedue"];
                    listByTime.Rows.Add(row2);
                    float num13 = Convert.ToSingle(row["Repaydue"]);
                    float num14 = num4 - ((num4 / ((float) num9)) * (num3 - 1));
                    float num15 = 0.04f;
                    float num16 = Convert.ToSingle((double) (50.0 + ((((double) (num15 * num14)) / 30.4167) * num6)));
                    row["Repaydue"] = num16;
                    this.Session["delayCurrentPay"] = num16;
                    this.Session["delayCurrentScheduleID"] = id;
                    StringBuilder builder = new StringBuilder();
                    for (int j = 0; j < listByTime.Rows.Count; j++)
                    {
                        string str4 = Convert.ToDateTime(listByTime.Rows[j]["Datedue"]).Day.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[j]["Datedue"]).Month.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[j]["Datedue"]).Year.ToString();
                        string[] strArray3 = new string[] { "<tr><td>", (j + 1).ToString(), "</td><td>", str4, "</td><td>", Convert.ToSingle(listByTime.Rows[j]["Repaydue"]).ToString("0.00"), "</td></tr>" };
                        builder.Append(string.Concat(strArray3));
                    }
                    this.Content2 = builder.ToString();
                    this.HiddenCalced.Value = "yes";
                }
            }
        }

        public string getInfo()
        {
            StringBuilder builder = new StringBuilder();
            ScheduleBN ebn = new ScheduleBN(this.Page);
            string str = Convert.ToString(this.Session["currentLoanID"]);
            ebn.QueryParam1(str);
            ebn.QueryNotValid("3");
            DataTable listByTime = ebn.GetListByTime();
            int num = 0;
            for (int i = 0; i < listByTime.Rows.Count; i++)
            {
                string str2 = "Repaydue" + ((i + 1)).ToString();
                this.Session[str2] = Convert.ToSingle(listByTime.Rows[i]["Repaydue"]).ToString("0.00");
                string str3 = "Datedue" + ((i + 1)).ToString();
                this.Session[str3] = Convert.ToDateTime(listByTime.Rows[i]["Datedue"]);
                string str4 = "Schedule" + ((i + 1)).ToString();
                this.Session[str4] = listByTime.Rows[i]["id"].ToString();
                string str5 = "";
                string str6 = "";
                if ((listByTime.Rows[i]["Param4"] == DBNull.Value) || (listByTime.Rows[i]["Param4"].ToString() == "0"))
                {
                    string str7 = "";
                    str7 = listByTime.Rows[i]["id"].ToString() + "&" + (++num).ToString();
                    str5 = "<INPUT id='Radio0'  type='radio' value='" + str7 + "' name='Radio0' >";
                    str6 = "Extend to Next payday";
                }
                DateTime time = Convert.ToDateTime(listByTime.Rows[i]["Datedue"]);
                string str8 = Convert.ToDateTime(listByTime.Rows[i]["Datedue"]).Day.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[i]["Datedue"]).Month.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[i]["Datedue"]).Year.ToString();
                string[] strArray3 = new string[] { "<tr><td>", (i + 1).ToString(), "</td><td>", str8, "</td><td>", Convert.ToSingle(listByTime.Rows[i]["Repaydue"]).ToString("0.00"), "</td><td>", str5, "</td><td>", str6, "</td>" };
                builder.Append(string.Concat(strArray3));
            }
            return builder.ToString();
        }

        private void InitializeComponent()
        {
            this.Button2.Click += new EventHandler(this.Button2_Click);
            this.Button1.Click += new EventHandler(this.Button1_Click);
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
            this.Hidden2.Value = base.HuiSid;
            dbn.QueryhuiSid(this.Hidden2.Value);
            dbn.Order = "id desc";
            DataTable list = dbn.GetList();
            if (list.Rows.Count <= 0)
            {
                base.Response.Write("<script>alert('This is no information available at this time. Please check again after your loan is approved.');window.location.href='detail1.aspx';</script>");
            }
            else
            {
                this.Session["Employedid"] = list.Rows[0]["id"].ToString();
                HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(Convert.ToInt32(this.Hidden2.Value));
                this.Name = ndt.Fname + " " + ndt.Mname + " " + ndt.Lname;
                this.CustomerNum = this.Hidden2.Value;
                this.LoanAmount = Convert.ToSingle(list.Rows[0]["Loan"]).ToString("0.00");
                this.Session["currentLoanID"] = list.Rows[0]["id"];
                this.Content1 = this.getInfo();
            }
        }
    }
}

