namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business.CommonLogic;

    public class Calculator : LongParent
    {
        protected HtmlInputButton bnCal1;
        protected HtmlInputButton bnCal2;
        protected HtmlInputButton bnStar1;
        protected HtmlInputButton bnStar2;
        protected HtmlSelect dlterms;
        protected HtmlSelect dlterms2;
        protected Label Label1;
        protected Panel Panel1;
        protected RadioButtonList RadioButtonList1;
        protected RadioButtonList RadioButtonList2;
        protected RadioButtonList rbPer;
        public string sBorrow = "";
        protected HtmlTable Table1;
        protected HtmlTable Table2;
        protected HtmlInputText txBorrow;
        protected HtmlInputText txDd1;
        protected HtmlInputText txDd2;
        protected TextBox txEnd;
        protected HtmlInputText txIncome;
        protected HtmlInputText txIncome2;
        protected HtmlInputText txLoan;
        protected HtmlInputText txMm1;
        protected HtmlInputText txMm2;
        protected TextBox txNumber;
        protected TextBox txRepayA;
        protected TextBox txRepayF;
        protected TextBox txStart;
        protected HtmlInputText txYy1;
        protected HtmlInputText txYy2;

        private void bnCal1_ServerClick(object sender, EventArgs e)
        {
            this.txBorrow.Value = "";
            if (this.txIncome.Value != "")
            {
                try
                {
                    double num = Convert.ToSingle(this.txIncome.Value);
                    string commandText = "select * from LParams where Sid=" + this.dlterms.Value;
                    DataTable table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
                    if (table.Rows.Count > 0)
                    {
                        double num2 = 0.0;
                        int num3 = 0;
                        int num4 = Convert.ToInt32(this.dlterms.Value);
                        switch (this.rbPer.SelectedValue)
                        {
                            case "0":
                                num2 = Convert.ToSingle(table.Rows[0]["NrW"]);
                                num3 = num4 * 4;
                                break;

                            case "1":
                                num2 = Convert.ToSingle(table.Rows[0]["NrF"]);
                                num3 = num4 * 2;
                                break;

                            case "2":
                                num2 = Convert.ToSingle(table.Rows[0]["NrB"]);
                                num3 = num4 * 2;
                                break;

                            case "3":
                                num2 = Convert.ToSingle(table.Rows[0]["NrM"]);
                                num3 = num4;
                                break;
                        }
                        num2 *= 0.01;
                        double num5 = (num2 * num3) + 1.0;
                        double num6 = ((0.25 * num) * num3) / num5;
                        if (num6 > 5000.0)
                        {
                            num6 = 5000.0;
                        }
                        this.txBorrow.Value = num6.ToString("0");
                    }
                }
                catch (Exception exception)
                {
                    this.Label1.Text = exception.Message;
                }
            }
        }

        private void bnCal2_ServerClick(object sender, EventArgs e)
        {
            this.txRepayA.Text = "";
            this.txRepayF.Text = "";
            this.txNumber.Text = "";
            this.txStart.Text = "";
            this.txEnd.Text = "";
            if ((this.txIncome2.Value != "") && (this.txLoan.Value != ""))
            {
                string commandText = "select * from LParams where Sid=" + this.dlterms2.Value;
                DataTable table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
                if (table.Rows.Count > 0)
                {
                    double num = 0.0;
                    double num2 = 0.0;
                    double num3 = 0.0;
                    int addMonths = 0;
                    int num5 = Convert.ToInt32(this.dlterms2.Value);
                    num3 = Convert.ToDouble(this.txLoan.Value);
                    double num6 = Convert.ToDouble(this.txIncome2.Value);
                    string selectedValue = this.RadioButtonList2.SelectedValue;
                    try
                    {
                        switch (selectedValue)
                        {
                            case "0":
                                num = Convert.ToDouble(table.Rows[0]["NrW"]) * 0.01;
                                addMonths = num5 * 4;
                                break;

                            case "1":
                                num = Convert.ToDouble(table.Rows[0]["NrF"]) * 0.01;
                                addMonths = num5 * 2;
                                break;

                            case "2":
                                num = Convert.ToDouble(table.Rows[0]["NrB"]) * 0.01;
                                addMonths = num5 * 2;
                                break;

                            case "3":
                                num = Convert.ToDouble(table.Rows[0]["NrM"]) * 0.01;
                                addMonths = num5;
                                break;
                        }
                        double num7 = (((0.25 * num6) * addMonths) / ((num * addMonths) + 1.0)) + 1.0;
                        if (num3 <= num7)
                        {
                            DateTime date = new DateTime(Convert.ToInt32(this.txYy1.Value), Convert.ToInt32(this.txMm1.Value), Convert.ToInt32(this.txDd1.Value), 0x17, 0x3b, 0x3b);
                            if (date > SafeDateTime.LocalNow)
                            {
                                DateTime nextPayDate = date;
                                TimeSpan span = (TimeSpan) (date - SafeDateTime.LocalNow);
                                if (date <= SafeDateTime.LocalNow)
                                {
                                    base.Response.Write("<script>alert('Please note that the next payday entered must be future date.');</script>");
                                }
                                else
                                {
                                    DateTime followNextPayDate = new DateTime(0x7d6, 1, 1, 0x17, 0x3b, 0x3b);
                                    DateTime nextMonth = new DateTime(0x7d6, 1, 1, 0x17, 0x3b, 0x3b);
                                    string str = selectedValue;
                                    if (str != null)
                                    {
                                        str = string.IsInterned(str);
                                        if (str == "0")
                                        {
                                            if (span.Days > 7)
                                            {
                                                base.Response.Write("<script>alert('Please note that the days to your next payday exceeded your pay interval, please adjust and continue.');</script>");
                                                return;
                                            }
                                            num2 = (((num3 * num) * addMonths) + num3) / ((double) addMonths);
                                            this.txRepayF.Text = "Weekly";
                                            if (span.Days < 15)
                                            {
                                                followNextPayDate = date.AddDays(7.0);
                                                nextMonth = date.AddDays((double) (7 * addMonths));
                                            }
                                            else
                                            {
                                                followNextPayDate = date;
                                                nextMonth = date.AddDays((double) (7 * (addMonths - 1)));
                                            }
                                        }
                                        else if (str == "1")
                                        {
                                            if (span.Days > 14)
                                            {
                                                base.Response.Write("<script>alert('Please note that the days to your next payday exceeded your pay interval, please adjust and continue.');</script>");
                                                return;
                                            }
                                            num2 = (((num3 * num) * addMonths) + num3) / ((double) addMonths);
                                            this.txRepayF.Text = "F'nightly";
                                            if (span.Days < 15)
                                            {
                                                followNextPayDate = date.AddDays(14.0);
                                                nextMonth = date.AddDays((double) (14 * addMonths));
                                            }
                                            else
                                            {
                                                followNextPayDate = date;
                                                nextMonth = date.AddDays((double) (14 * (addMonths - 1)));
                                            }
                                        }
                                        else if (str == "2")
                                        {
                                            if (span.Days > 0x10)
                                            {
                                                base.Response.Write("<script>alert('Please note that the days to your next payday exceeded your pay interval, please adjust and continue.');</script>");
                                                return;
                                            }
                                            num2 = (((num3 * num) * addMonths) + num3) / ((double) addMonths);
                                            this.txRepayF.Text = "Bi-Monthly";
                                            if (span.Days < 15)
                                            {
                                                followNextPayDate = new DateTime(Convert.ToInt32(this.txYy2.Value), Convert.ToInt32(this.txMm2.Value), Convert.ToInt32(this.txDd2.Value), 0x17, 0x3b, 0x3b);
                                                nextMonth = LongTermSchedule.GetNextBiMonth(nextPayDate, followNextPayDate, num5);
                                            }
                                            else
                                            {
                                                followNextPayDate = date;
                                                nextMonth = LongTermSchedule.GetNextBiMonth(nextPayDate, followNextPayDate, num5);
                                            }
                                        }
                                        else if (str == "3")
                                        {
                                            if (span.Days > 0x1f)
                                            {
                                                base.Response.Write("<script>alert('Please note that the days to your next payday exceeded your pay interval, please adjust and continue.');</script>");
                                                return;
                                            }
                                            num2 = (((num3 * num) * addMonths) + num3) / ((double) addMonths);
                                            this.txRepayF.Text = "Monthly";
                                            if (span.Days < 15)
                                            {
                                                followNextPayDate = LongTermSchedule.GetNextMonth(date, 1);
                                                nextMonth = LongTermSchedule.GetNextMonth(date, addMonths);
                                            }
                                            else
                                            {
                                                followNextPayDate = date;
                                                nextMonth = LongTermSchedule.GetNextMonth(date, addMonths - 1);
                                            }
                                        }
                                    }
                                    num *= 0.01;
                                    double num8 = Convert.ToDouble(this.txLoan.Value);
                                    double num9 = (((num8 * num) * addMonths) + num8) / ((double) addMonths);
                                    this.txRepayA.Text = num2.ToString("0.00");
                                    this.txNumber.Text = addMonths.ToString();
                                    this.txStart.Text = followNextPayDate.ToString("dd/MM/yyyy");
                                    this.txEnd.Text = nextMonth.ToString("dd/MM/yyyy");
                                }
                            }
                            else
                            {
                                base.Response.Write("<script>alert('Please note that the next payday entered must be future date.');</script>");
                            }
                        }
                        else
                        {
                            base.Response.Write("<script>alert('Sorry, the loan amount has exceeded your borrowing limit, please use the link of \"Calculator\" to check your borrowing limit!');</script>");
                        }
                    }
                    catch (Exception exception)
                    {
                        this.Label1.Text = exception.Message;
                    }
                }
            }
        }

        private void bnStar1_ServerClick(object sender, EventArgs e)
        {
            this.txIncome.Value = "";
            this.txBorrow.Value = "";
            this.dlterms.SelectedIndex = 0;
        }

        private void bnStar2_ServerClick(object sender, EventArgs e)
        {
            this.txLoan.Value = this.txIncome2.Value = this.txDd1.Value = this.txMm1.Value = this.txYy1.Value = "";
            this.txRepayA.Text = this.txRepayF.Text = this.txNumber.Text = this.txStart.Text = this.txEnd.Text = "";
            this.dlterms2.SelectedIndex = 0;
        }

        private void InitializeComponent()
        {
            this.RadioButtonList1.SelectedIndexChanged += new EventHandler(this.RadioButtonList1_SelectedIndexChanged);
            this.RadioButtonList2.SelectedIndexChanged += new EventHandler(this.RadioButtonList2_SelectedIndexChanged);
            this.bnStar1.ServerClick += new EventHandler(this.bnStar1_ServerClick);
            this.bnCal1.ServerClick += new EventHandler(this.bnCal1_ServerClick);
            this.bnStar2.ServerClick += new EventHandler(this.bnStar2_ServerClick);
            this.bnCal2.ServerClick += new EventHandler(this.bnCal2_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.bnCal1.Attributes.Add("onclick", "return Check1()");
            this.bnCal2.Attributes.Add("onclick", "return Check2()");
            if (!this.Page.IsPostBack)
            {
                this.Table2.Visible = false;
            }
        }

        private void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RadioButtonList1.SelectedValue.Equals("1"))
            {
                this.Table1.Visible = true;
                this.Table2.Visible = false;
            }
            else
            {
                this.Table1.Visible = false;
                this.Table2.Visible = true;
            }
        }

        private void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RadioButtonList2.SelectedValue.Equals("2"))
            {
                this.Panel1.Visible = true;
            }
            else
            {
                this.Panel1.Visible = false;
            }
        }
    }
}

