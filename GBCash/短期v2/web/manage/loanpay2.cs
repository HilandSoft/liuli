namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using System.IO;
    using System.Text;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class loanpay2 : ManageBasePage
    {
        protected Button Button1;
        protected Button Button2;
        protected Button Button3;
        public string content = "";
        protected HtmlInputHidden Hidden1;
        protected ImageButton ImageButton1;
        public string Loan = "";
        public string RTime = "";

        private void Button1_Click(object sender, EventArgs e)
        {
            if (base.Request["text1"] != null)
            {
                if (!this.chkData(base.Request["text1"].ToString()))
                {
                    base.Response.Write("<script>alert(\"The format typed in 'Paid' field is incorrect!\");</script>");
                }
                else if (!this.chkData(base.Request["text2"].ToString()))
                {
                    base.Response.Write("<script>alert(\"The format typed in 'Penalty' field is incorrect!\");</script>");
                }
                else
                {
                    string[] strArray = base.Request["text1"].Split(new char[] { ',' });
                    string[] strArray2 = base.Request["text2"].Split(new char[] { ',' });
                    string[] strArray3 = base.Request["text3"].Split(new char[] { ',' });
                    string[] strArray4 = base.Request["text4"].Split(new char[] { ',' });
                    string[] strArray5 = base.Request["text5"].Split(new char[] { ',' });
                    int num = Convert.ToInt32(this.Hidden1.Value);
                    for (int i = 0; i < num; i++)
                    {
                        if (strArray3[i].Equals(""))
                        {
                            strArray3[i] = "1/1/2000";
                        }
                    }
                    string commandText = "";
                    for (int j = 0; j < num; j++)
                    {
                        if ((strArray3[j].ToString().Trim() != "") && (strArray3[j].ToString().Trim() != "1/1/2000"))
                        {
                            string str2 = strArray3[j];
                            string[] strArray6 = str2.Split(new char[] { '/', '-' });
                            if (strArray6.Length == 3)
                            {
                                str2 = string.Format("{0}/{1}/{2}", strArray6[1], strArray6[0], strArray6[2]);
                            }
                            else
                            {
                                str2 = SafeDateTime.LocalNow.ToShortDateString();
                            }
                            float num4 = (Convert.ToSingle(strArray5[j]) - Convert.ToSingle(strArray[j])) + Convert.ToSingle(strArray2[j]);
                            string str3 = SafeDateTime.LocalNow.Month.ToString() + "/" + SafeDateTime.LocalNow.Day.ToString() + "/" + SafeDateTime.LocalNow.Year.ToString() + " " + SafeDateTime.LocalNow.Hour.ToString() + ":" + SafeDateTime.LocalNow.Minute.ToString() + ":" + SafeDateTime.LocalNow.Second.ToString();
                            ScheduleBN ebn = new ScheduleBN(this.Page);
                            if (ebn.Get(Convert.ToInt32(strArray4[j])).OperateTime.ToShortDateString().IndexOf("2000") > 0)
                            {
                                commandText = "update Schedule set Paid=" + strArray[j].ToString() + ",Penalty=" + strArray2[j].ToString() + ",Balance=" + num4.ToString() + ",RepayTime='" + str2 + "',OperateTime='" + str3 + "' where id=" + strArray4[j].ToString() + "";
                            }
                            else
                            {
                                commandText = "update Schedule set Paid=" + strArray[j].ToString() + ",Penalty=" + strArray2[j].ToString() + ",Balance=" + num4.ToString() + ",RepayTime='" + str2 + "' where id=" + strArray4[j].ToString() + "";
                            }
                            try
                            {
                                SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                            }
                            catch (Exception)
                            {
                                throw new Exception(commandText);
                            }
                        }
                    }
                    for (int k = 0; k < (num - 1); k++)
                    {
                        ScheduleBN ebn2 = new ScheduleBN(this.Page);
                        float num6 = Convert.ToSingle(ebn2.Get(Convert.ToInt32(strArray4[k])).Balance);
                        commandText = "update Schedule set Balance=Repaydue-Paid+Penalty+" + num6.ToString() + " where id=" + strArray4[k + 1] + "";
                        SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    }
                    base.Response.Write("<script>alert('Success!');window.location.href='loandetail.aspx?id=" + this.Session["employid"] + "';</script>");
                }
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            string[] strArray = base.Request["text4"].Split(new char[] { ',' });
            string[] strArray2 = base.Request["dtext"].Split(new char[] { ',' });
            int num = Convert.ToInt32(this.Hidden1.Value);
            string commandText = "";
            for (int i = 0; i < num; i++)
            {
                string str2 = strArray2[i].ToString();
                string[] strArray3 = str2.Split(new char[] { '-', '/' });
                if (strArray3.Length == 3)
                {
                    str2 = string.Format("{0}/{1}/{2}", strArray3[1], strArray3[0], strArray3[2]);
                }
                ScheduleDT edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[i]));
                commandText = "update Schedule set Datedue='" + str2 + "' where id=" + strArray[i].ToString() + "";
                SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
            }
            base.Response.Write("<script>alert('Success!');window.location.href='loandetail.aspx?id=" + this.Session["employid"] + "';</script>");
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            string[] strArray = base.Request["text4"].Split(new char[] { ',' });
            string[] strArray2 = base.Request["text5"].Split(new char[] { ',' });
            int num = Convert.ToInt32(this.Hidden1.Value);
            string commandText = "";
            double num2 = 0.0;
            double num3 = 0.0;
            double num4 = 0.0;
            double num5 = 0.0;
            double num6 = 0.0;
            ScheduleBN ebn = new ScheduleBN(this.Page);
            ScheduleDT edt = new ScheduleDT();
            switch (num)
            {
                case 1:
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[0]));
                    commandText = "update Schedule set Repaydue=" + strArray2[0].ToString() + ",Balance=" + strArray2[0].ToString() + " where id=" + strArray[0].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    break;

                case 2:
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[0]));
                    commandText = "update Schedule set Repaydue=" + strArray2[0].ToString() + ",Balance=" + strArray2[0].ToString() + " where id=" + strArray[0].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[1]));
                    num2 = Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[1].ToString() + ",Balance=" + num2.ToString() + " where id=" + strArray[1].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    break;

                case 3:
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[0]));
                    commandText = "update Schedule set Repaydue=" + strArray2[0].ToString() + ",Balance=" + strArray2[0].ToString() + " where id=" + strArray[0].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[1]));
                    num2 = Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[1].ToString() + ",Balance=" + num2.ToString() + " where id=" + strArray[1].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[2]));
                    num3 = (Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString())) + Convert.ToSingle(strArray2[2].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[2].ToString() + ",Balance=" + num3.ToString() + " where id=" + strArray[2].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    break;

                case 4:
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[0]));
                    commandText = "update Schedule set Repaydue=" + strArray2[0].ToString() + ",Balance=" + strArray2[0].ToString() + " where id=" + strArray[0].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[1]));
                    num2 = Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[1].ToString() + ",Balance=" + num2.ToString() + " where id=" + strArray[1].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[2]));
                    num3 = (Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString())) + Convert.ToSingle(strArray2[2].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[2].ToString() + ",Balance=" + num3.ToString() + " where id=" + strArray[2].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[3]));
                    num4 = ((Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString())) + Convert.ToSingle(strArray2[2].ToString())) + Convert.ToSingle(strArray2[3].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[3].ToString() + ",Balance=" + num4.ToString() + " where id=" + strArray[3].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    break;

                case 5:
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[0]));
                    commandText = "update Schedule set Repaydue=" + strArray2[0].ToString() + ",Balance=" + strArray2[0].ToString() + " where id=" + strArray[0].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[1]));
                    num2 = Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[1].ToString() + ",Balance=" + num2.ToString() + " where id=" + strArray[1].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[2]));
                    num3 = (Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString())) + Convert.ToSingle(strArray2[2].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[2].ToString() + ",Balance=" + num3.ToString() + " where id=" + strArray[2].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[3]));
                    num4 = ((Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString())) + Convert.ToSingle(strArray2[2].ToString())) + Convert.ToSingle(strArray2[3].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[3].ToString() + ",Balance=" + num4.ToString() + " where id=" + strArray[3].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[4]));
                    num5 = (((Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString())) + Convert.ToSingle(strArray2[2].ToString())) + Convert.ToSingle(strArray2[3].ToString())) + Convert.ToSingle(strArray2[4].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[4].ToString() + ",Balance=" + num5.ToString() + " where id=" + strArray[4].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    break;

                case 6:
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[0]));
                    commandText = "update Schedule set Repaydue=" + strArray2[0].ToString() + ",Balance=" + strArray2[0].ToString() + " where id=" + strArray[0].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[1]));
                    num2 = Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[1].ToString() + ",Balance=" + num2.ToString() + " where id=" + strArray[1].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[2]));
                    num3 = (Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString())) + Convert.ToSingle(strArray2[2].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[2].ToString() + ",Balance=" + num3.ToString() + " where id=" + strArray[2].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[3]));
                    num4 = ((Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString())) + Convert.ToSingle(strArray2[2].ToString())) + Convert.ToSingle(strArray2[3].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[3].ToString() + ",Balance=" + num4.ToString() + " where id=" + strArray[3].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[4]));
                    num5 = (((Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString())) + Convert.ToSingle(strArray2[2].ToString())) + Convert.ToSingle(strArray2[3].ToString())) + Convert.ToSingle(strArray2[4].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[4].ToString() + ",Balance=" + num5.ToString() + " where id=" + strArray[4].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    edt = new ScheduleBN(this.Page).Get(Convert.ToInt32(strArray[5]));
                    num6 = ((((Convert.ToSingle(strArray2[0].ToString()) + Convert.ToSingle(strArray2[1].ToString())) + Convert.ToSingle(strArray2[2].ToString())) + Convert.ToSingle(strArray2[3].ToString())) + Convert.ToSingle(strArray2[4].ToString())) + Convert.ToSingle(strArray2[5].ToString());
                    commandText = "update Schedule set Repaydue=" + strArray2[5].ToString() + ",Balance=" + num6.ToString() + " where id=" + strArray[5].ToString() + "";
                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    break;
            }
            base.Response.Write("<script>alert('Success!');window.location.href='loandetail.aspx?id=" + this.Session["employid"] + "';</script>");
        }

        public bool chkData(string str)
        {
            string str2 = ",.0123456789.";
            for (int i = 0; i < str.Length; i++)
            {
                if (str2.IndexOf(str.Substring(i, 1)) == -1)
                {
                    return false;
                }
            }
            return true;
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
            EmployedBN dbn = new EmployedBN(this.Page);
            int id = Convert.ToInt32(base.Request["id"]);
            EmployedDT ddt = dbn.Get(id);
            if (ddt.IsValid != 2)
            {
                base.Response.Write("<script>alert('Note: Only approved application can be processed for repayment!');</script>");
            }
            else
            {
                DateTime rTime = ddt.RTime;
                this.RTime = rTime.Day.ToString() + "/" + rTime.Month.ToString() + "/" + rTime.Year.ToString();
                this.Loan = ddt.Loan.ToString();
            }
            ScheduleBN ebn = new ScheduleBN(this.Page);
            ebn.QueryParam1(id.ToString());
            ebn.Filter = " IsValid!=3 ";
            DataTable listByTime = ebn.GetListByTime();
            StringBuilder builder = new StringBuilder();
            builder.Append("<table width=\"1000\" border=\"0\" cellspacing=\"0\" cellpadding=\"0\">");
            builder.Append("<tr><td width=\"15%\">&nbsp;</td><td width=\"15%\">Date due</td><td width=\"15%\">Repayment due</td>");
            builder.Append("<td width=\"15%\">Paid</td><td width=\"15%\">Penalty");
            builder.Append("</td><td width=\"15%\">Repay Time</td><td width=\"15%\"></td><td width=\"10%\"></td></tr>");
            this.Hidden1.Value = listByTime.Rows.Count.ToString();
            for (int i = 0; i < listByTime.Rows.Count; i++)
            {
                string str = listByTime.Rows[i]["id"].ToString();
                string str2 = "Installment" + ((i + 1)).ToString();
                DateTime time2 = Convert.ToDateTime(listByTime.Rows[i]["Datedue"]);
                string str3 = time2.Day.ToString() + "/" + time2.Month.ToString() + "/" + time2.Year.ToString();
                string str4 = Convert.ToSingle(listByTime.Rows[i]["Repaydue"]).ToString("0.00");
                builder.Append("<tr><td width=\"15%\">" + str2 + "</td>");
                builder.Append("<td width=\"15%\"><INPUT id=\"dtext\" value=" + str3 + " type=\"text\" size=\"15\" name=\"dtext\"></td>");
                string str5 = "<INPUT id=\"text5\" value=" + str4 + " type=\"text\" size=\"15\" name=\"text5\">";
                builder.Append("<td width=\"15%\">" + str5 + "</td>");
                string str6 = listByTime.Rows[i]["Paid"].ToString();
                string str7 = listByTime.Rows[i]["Penalty"].ToString();
                DateTime time3 = Convert.ToDateTime(listByTime.Rows[i]["RepayTime"]);
                string str8 = time3.Day.ToString() + "/" + time3.Month.ToString() + "/" + time3.Year.ToString();
                if (str8.Equals("1/1/2000"))
                {
                    str8 = "";
                }
                str5 = "<INPUT id=\"text1\" value=" + str6 + " type=\"text\" size=\"15\" name=\"text1\">";
                builder.Append("<td width=\"15%\">" + str5 + "</td>");
                str5 = "<INPUT id=\"text2\" value=" + str7 + " type=\"text\" size=\"15\" name=\"text2\">";
                builder.Append("<td width=\"15%\">" + str5 + "</td>");
                builder.Append("<td width=\"15%\">" + ("<INPUT id=\"text3\" value='" + str8 + "'  onclick=\"popUpCalendar(this, this, 'dd/mm/yyyy');\" type=\"text\" size=\"15\" name=\"text3\">") + "</td>");
                builder.Append("<td width=\"10%\"><INPUT id=\"text4\" value=" + str + " type=\"hidden\" size=\"15\" name=\"text4\"></td></tr>");
            }
            builder.Append("</table>");
            this.content = builder.ToString();
        }

        private void SaveExcuteInfoIntoDatabase(string info)
        {
            using (SqlConnection connection = new SqlConnection(Config.DataSource))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand())
                {
                    info = info.Replace('\'', '$');
                    command.Connection = connection;
                    command.CommandText = string.Concat(new object[] { "INSERT INTO TaskExcuteInfo ([TaskName],[ExcuteTime],[memo]) VALUES ('SimpleTask','", SafeDateTime.LocalNow, "','", info, "')" });
                    command.ExecuteNonQuery();
                }
            }
        }

        private void SaveExcuteInfoIntoFile(string input)
        {
            using (FileStream stream = File.Open(AppDomain.CurrentDomain.BaseDirectory + Path.DirectorySeparatorChar + "taskLog.txt", FileMode.OpenOrCreate))
            {
                using (StreamWriter writer = new StreamWriter(stream))
                {
                    writer.WriteLine(input);
                    writer.Close();
                }
                stream.Close();
            }
        }
    }
}

