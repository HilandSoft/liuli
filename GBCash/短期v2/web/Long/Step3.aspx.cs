namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.Business.CommonLogic;
    using YingNet.WeiXing.STRUCTURE;
    using YingNet.WeiXing.WebApp.Include;

    public class Step3 : LongParent
    {
        protected Button bnView;
        protected CircleDropDownList ddlHousePaymentCircle;
        protected CircleDropDownList ddlOtherLenderCircle;
        protected HtmlSelect dlestatus;
        protected Label Label1;
        protected Panel Panel1;
        protected RadioButtonList RadioButtonList1;
        protected RadioButtonList RadioButtonList2;
        protected HtmlInputText selReShip1;
        protected HtmlInputText selReShip2;
        protected HtmlInputText selReShip3;
        protected HtmlInputButton Submit1;
        protected HtmlTable Table1;
        protected HtmlInputText txAddress;
        protected HtmlInputText txAname;
        protected HtmlInputText txAnumber;
        protected HtmlInputText txBank;
        protected HtmlInputText txBranch;
        protected HtmlInputText txBsb;
        protected HtmlInputText txCAnumber;
        protected HtmlInputText txDd1;
        protected HtmlInputText txDd2;
        protected HtmlInputText txEmployer;
        protected TextBox txEnd;
        protected HtmlInputText txIncome;
        protected HtmlInputText txJob;
        protected TextBox txLoan;
        protected TextBox txLoanSid;
        protected HtmlInputText txMm1;
        protected HtmlInputText txMm2;
        protected HtmlSelect txMonth;
        protected TextBox txNumber;
        protected HtmlInputText txPhone;
        protected HtmlInputText txReName1;
        protected HtmlInputText txReName2;
        protected HtmlInputText txReName3;
        protected HtmlInputText txReNum1;
        protected HtmlInputText txReNum2;
        protected HtmlInputText txReNum3;
        protected TextBox txRepayA;
        protected TextBox txRepayF;
        protected TextBox txStart;
        protected HtmlInputText txtHousePaymentValue;
        protected HtmlInputText txtOtherLenderValue;
        protected HtmlSelect txYear;
        protected HtmlInputText txYy1;
        protected HtmlInputText txYy2;

        private void bnView_Click(object sender, EventArgs e)
        {
            this.Panel1.Visible = true;
            this.txRepayA.Text = "";
            this.txRepayF.Text = "";
            this.txNumber.Text = "";
            this.txStart.Text = "";
            this.txEnd.Text = "";
            string commandText = "";
            double num = 0.0;
            double num2 = 0.0;
            double num3 = 0.0;
            int addMonths = 0;
            int num5 = 0;
            commandText = "select * from LIniLoan where Persid=" + this.txLoanSid.Text;
            DataTable table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
            if (table.Rows.Count > 0)
            {
                num3 = Convert.ToDouble(table.Rows[0]["Loan"]);
                addMonths = Convert.ToInt32(table.Rows[0]["Term"]);
            }
            if (this.txIncome.Value != "")
            {
                commandText = "select * from LParams where Sid=" + addMonths.ToString();
                DataTable table2 = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
                if (table2.Rows.Count > 0)
                {
                    double num6 = Convert.ToDouble(this.txIncome.Value);
                    string selectedValue = this.RadioButtonList2.SelectedValue;
                    try
                    {
                        switch (selectedValue)
                        {
                            case "0":
                                num = Convert.ToDouble(table2.Rows[0]["NrW"]) * 0.01;
                                num5 = addMonths * 4;
                                break;

                            case "1":
                                num = Convert.ToDouble(table2.Rows[0]["NrF"]) * 0.01;
                                num5 = addMonths * 2;
                                break;

                            case "2":
                                num = Convert.ToDouble(table2.Rows[0]["NrB"]) * 0.01;
                                num5 = addMonths * 2;
                                break;

                            case "3":
                                num = Convert.ToDouble(table2.Rows[0]["NrM"]) * 0.01;
                                num5 = addMonths;
                                break;
                        }
                        double num7 = (((0.25 * num6) * num5) / ((num * num5) + 1.0)) + 1.0;
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
                                            num2 = (((num3 * num) * num5) + num3) / ((double) num5);
                                            this.txRepayF.Text = "Weekly";
                                            if (span.Days < 15)
                                            {
                                                followNextPayDate = date.AddDays(7.0);
                                                nextMonth = date.AddDays((double) (7 * num5));
                                            }
                                            else
                                            {
                                                followNextPayDate = date;
                                                nextMonth = date.AddDays((double) (7 * (num5 - 1)));
                                            }
                                        }
                                        else if (str == "1")
                                        {
                                            if (span.Days > 14)
                                            {
                                                base.Response.Write("<script>alert('Please note that the days to your next payday exceeded your pay interval, please adjust and continue.');</script>");
                                                return;
                                            }
                                            num2 = (((num3 * num) * num5) + num3) / ((double) num5);
                                            this.txRepayF.Text = "F'nightly";
                                            if (span.Days < 15)
                                            {
                                                followNextPayDate = date.AddDays(14.0);
                                                nextMonth = date.AddDays((double) (14 * num5));
                                            }
                                            else
                                            {
                                                followNextPayDate = date;
                                                nextMonth = date.AddDays((double) (14 * (num5 - 1)));
                                            }
                                        }
                                        else if (str == "2")
                                        {
                                            if (span.Days > 0x10)
                                            {
                                                base.Response.Write("<script>alert('Please note that the days to your next payday exceeded your pay interval, please adjust and continue.');</script>");
                                                return;
                                            }
                                            num2 = (((num3 * num) * num5) + num3) / ((double) num5);
                                            this.txRepayF.Text = "Bi-Monthly";
                                            if (span.Days < 15)
                                            {
                                                followNextPayDate = new DateTime(Convert.ToInt32(this.txYy2.Value), Convert.ToInt32(this.txMm2.Value), Convert.ToInt32(this.txDd2.Value), 0x17, 0x3b, 0x3b);
                                                nextMonth = LongTermSchedule.GetNextBiMonth(nextPayDate, followNextPayDate, addMonths);
                                            }
                                            else
                                            {
                                                followNextPayDate = date;
                                                nextMonth = LongTermSchedule.GetNextBiMonth(nextPayDate, followNextPayDate, addMonths);
                                            }
                                        }
                                        else if (str == "3")
                                        {
                                            if (span.Days > 0x1f)
                                            {
                                                base.Response.Write("<script>alert('Please note that the days to your next payday exceeded your pay interval, please adjust and continue.');</script>");
                                                return;
                                            }
                                            num2 = (((num3 * num) * num5) + num3) / ((double) num5);
                                            this.txRepayF.Text = "Monthly";
                                            if (span.Days < 15)
                                            {
                                                followNextPayDate = LongTermSchedule.GetNextMonth(date, 1);
                                                nextMonth = LongTermSchedule.GetNextMonth(date, num5);
                                            }
                                            else
                                            {
                                                followNextPayDate = date;
                                                nextMonth = LongTermSchedule.GetNextMonth(date, num5 - 1);
                                            }
                                        }
                                    }
                                    num *= 0.01;
                                    double num8 = num3;
                                    double num9 = (((num8 * num) * num5) + num8) / ((double) num5);
                                    this.txRepayA.Text = num2.ToString("0.00");
                                    this.txNumber.Text = num5.ToString();
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

        public void GetLoanInfor()
        {
            string commandText = "";
            commandText = "select * from LIniLoan where Persid=" + this.txLoanSid.Text;
            DataTable table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
            if (table.Rows.Count > 0)
            {
                this.txLoan.Text = table.Rows[0]["Loan"].ToString();
            }
        }

        private void InitializeComponent()
        {
            this.RadioButtonList2.SelectedIndexChanged += new EventHandler(this.RadioButtonList2_SelectedIndexChanged);
            this.bnView.Click += new EventHandler(this.bnView_Click);
            this.Submit1.ServerClick += new EventHandler(this.Submit1_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.Submit1.Attributes.Add("onclick", "return CheckFeedback();");
            if (base.Request["sid"] != null)
            {
                this.txLoanSid.Text = Cipher.DesDecrypt(base.Request["sid"].ToString(), "12345678");
            }
            if (!this.Page.IsPostBack)
            {
                this.Table1.Visible = false;
            }
        }

        private void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RadioButtonList2.SelectedValue.Equals("2"))
            {
                this.Table1.Visible = true;
            }
            else
            {
                this.Table1.Visible = false;
            }
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            if (base.CheckPay(this.txLoanSid.Text))
            {
                base.Response.Write("<script>alert('信息已经保存,不能再修改!');window.location='Step.aspx';</script>");
            }
            else
            {
                try
                {
                    string selectedValue = this.RadioButtonList2.SelectedValue;
                    DateTime time = new DateTime(Convert.ToInt32(this.txYy1.Value), Convert.ToInt32(this.txMm1.Value), Convert.ToInt32(this.txDd1.Value), 0x17, 0x3b, 0x3b);
                    TimeSpan span = (TimeSpan) (time - SafeDateTime.LocalNow);
                    if (time <= SafeDateTime.LocalNow)
                    {
                        base.Response.Write("<script>alert('Please note that the next payday entered must be future date.');</script>");
                    }
                    else
                    {
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
                            }
                            else if (str == "1")
                            {
                                if (span.Days > 14)
                                {
                                    base.Response.Write("<script>alert('Please note that the days to your next payday exceeded your pay interval, please adjust and continue.');</script>");
                                    return;
                                }
                            }
                            else if (str == "2")
                            {
                                if (span.Days > 0x10)
                                {
                                    base.Response.Write("<script>alert('Please note that the days to your next payday exceeded your pay interval, please adjust and continue.');</script>");
                                    return;
                                }
                            }
                            else if ((str == "3") && (span.Days > 0x1f))
                            {
                                base.Response.Write("<script>alert('Please note that the days to your next payday exceeded your pay interval, please adjust and continue.');</script>");
                                return;
                            }
                        }
                        LemploymentBN tbn = new LemploymentBN(this.Page);
                        LemploymentDT detail = new LemploymentDT();
                        detail.EName = this.txEmployer.Value;
                        detail.EAddress = this.txAddress.Value;
                        detail.ECode = this.txPhone.Value;
                        detail.ENum = "";
                        detail.EStatus = this.dlestatus.Value;
                        detail.JobTitle = this.txJob.Value;
                        detail.TimeMonths = Convert.ToInt32(this.txMonth.Value);
                        detail.TimeYears = Convert.ToInt32(this.txYear.Value);
                        detail.TakePay = Convert.ToDouble(this.txIncome.Value);
                        detail.Per = Convert.ToInt32(this.RadioButtonList2.SelectedValue);
                        detail.NextDay = Convert.ToInt32(this.txDd1.Value);
                        detail.NextMonth = Convert.ToInt32(this.txMm1.Value);
                        detail.NextYear = Convert.ToInt32(this.txYy1.Value);
                        detail.LoanSid = Convert.ToInt32(this.txLoanSid.Text);
                        detail.Other1 = "";
                        detail.Other2 = "";
                        detail.Other3 = "";
                        detail.Other4 = 0;
                        detail.Other5 = 0;
                        detail.Other6 = 0;
                        try
                        {
                            detail.HousePaymentValue = Convert.ToSingle(this.txtHousePaymentValue.Value);
                            detail.OtherLenderValue = Convert.ToSingle(this.txtOtherLenderValue.Value);
                        }
                        catch
                        {
                        }
                        detail.HousePaymentCircle = EnumsOP.GetHousePaymentCircleByLiteral(this.ddlHousePaymentCircle.SelectedValue);
                        detail.OtherLenderCircle = EnumsOP.GetOtherLenderCircleByLiteral(this.ddlOtherLenderCircle.SelectedValue);
                        if (this.RadioButtonList2.SelectedValue.Equals("2"))
                        {
                            detail.FollowDay = Convert.ToInt32(this.txDd2.Value);
                            detail.FollowMonth = Convert.ToInt32(this.txMm2.Value);
                            detail.FollowYear = Convert.ToInt32(this.txYy2.Value);
                        }
                        else
                        {
                            detail.FollowDay = detail.FollowMonth = detail.FollowYear = 0;
                        }
                        if (tbn.Add(detail))
                        {
                            tbn.Close();
                            tbn.Dispose();
                            base.Response.Write("<script>window.location='Step4.aspx?sid=" + Cipher.DesEncrypt(this.txLoanSid.Text, "12345678") + "';</script>");
                        }
                    }
                }
                catch (Exception exception)
                {
                    this.Label1.Text = exception.Message;
                }
            }
        }
    }
}

