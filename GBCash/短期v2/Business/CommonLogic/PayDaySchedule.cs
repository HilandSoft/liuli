namespace YingNet.WeiXing.Business.CommonLogic
{
    using System;
    using System.Data;
    using System.Runtime.InteropServices;
    using System.Web.UI;
    using YingNet.Common;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.STRUCTURE;

    public class PayDaySchedule
    {
        public static int CalculateInstallmentCount(PaidPeriodTypes repaymentType, DateTime salaryDate, DateTime currentDate)
        {
            TimeSpan span = (TimeSpan) (salaryDate - currentDate);
            switch (repaymentType)
            {
                case PaidPeriodTypes.Weekly:
                    return 9;

                case PaidPeriodTypes.Fnightly:
                    return 4;

                case PaidPeriodTypes.Monthly:
                    if (span.Days >= 15)
                    {
                        return 3;
                    }
                    return 2;
            }
            return 0;
        }

        public static bool CalculatePayDate(Page currentPage, DateTime timeRecentlySalaryDate, PaidPeriodTypes repaymentType, DateTime timeLoanRegistered, ref DateTime[] payDates, out string errorString)
        {
            if (timeRecentlySalaryDate < SafeDateTime.LocalToday)
            {
                errorString = "<script>alert('The date of next payday must beyond today. Please re-enter your next payday.');</script>";
                return false;
            }
            timeLoanRegistered = timeLoanRegistered.Date;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            float num6 = 0f;
            DataTable list = new SystemInfoBN(currentPage).GetList();
            if (list.Rows.Count > 0)
            {
                num = Convert.ToInt32(list.Rows[0]["shortday"]);
                num6 = Convert.ToSingle(list.Rows[0]["frequency"]);
                num2 = Convert.ToInt32(list.Rows[0]["datediffw"]);
                num3 = Convert.ToInt32(list.Rows[0]["datedifff"]);
                num4 = Convert.ToInt32(list.Rows[0]["datediffm"]);
                num5 = Convert.ToInt32(list.Rows[0]["term"]);
            }
            TimeSpan span = new TimeSpan(0x3e8L);
            TimeSpan span2 = (TimeSpan) (timeRecentlySalaryDate - SafeDateTime.LocalNow);
            switch (repaymentType)
            {
                case PaidPeriodTypes.Weekly:
                    if (span2.Days > num2)
                    {
                        errorString = "<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>";
                        return false;
                    }
                    currentPage.Session["frequency"] = 7;
                    span = new TimeSpan(7, 0, 0, 0);
                    payDates = new DateTime[9];
                    for (int i = 0; i < 9; i++)
                    {
                        if (i == 0)
                        {
                            payDates[i] = timeRecentlySalaryDate + span;
                        }
                        else
                        {
                            payDates[i] = payDates[i - 1] + span;
                        }
                    }
                    break;

                case PaidPeriodTypes.Fnightly:
                    if (span2.Days > num3)
                    {
                        errorString = "<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>";
                        return false;
                    }
                    currentPage.Session["frequency"] = 14;
                    span = new TimeSpan(14, 0, 0, 0);
                    payDates = new DateTime[4];
                    for (int j = 0; j < 4; j++)
                    {
                        if (j == 0)
                        {
                            payDates[j] = timeRecentlySalaryDate + span;
                        }
                        else
                        {
                            payDates[j] = payDates[j - 1] + span;
                        }
                    }
                    break;

                case PaidPeriodTypes.Monthly:
                {
                    if (span2.Days >= 15)
                    {
                        currentPage.Session["frequency"] = num6;
                        DateTime[] timeArray2 = new DateTime[] { timeRecentlySalaryDate, timeRecentlySalaryDate.AddMonths(1), timeRecentlySalaryDate.AddMonths(2) };
                        payDates = timeArray2;
                        break;
                    }
                    currentPage.Session["frequency"] = num6;
                    DateTime[] timeArray = new DateTime[] { timeRecentlySalaryDate.AddMonths(1), timeRecentlySalaryDate.AddMonths(2) };
                    payDates = timeArray;
                    break;
                }
            }
            TimeSpan span3 = (TimeSpan) (payDates[0] - timeLoanRegistered);
            currentPage.Session["XFirst"] = span3.Days;
            errorString = string.Empty;
            return true;
        }

        public static bool CalculatePayDate(Page currentPage, int numInstallmentCount, DateTime timeRecentlySalaryDate, int userLoanType, PaidPeriodTypes repaymentType, ref DateTime timeFirstPay, ref DateTime timeSecondPay, ref DateTime timeThirdPay, ref DateTime timeAtOncePay, DateTime timeLoanRegistered, out string errorString)
        {
            if (timeRecentlySalaryDate < SafeDateTime.LocalToday)
            {
                errorString = "<script>alert('The date of next payday must beyond today. Please re-enter your next payday.');</script>";
                return false;
            }
            timeLoanRegistered = timeLoanRegistered.Date;
            int num = 0;
            int num2 = 0;
            int num3 = 0;
            int num4 = 0;
            int num5 = 0;
            float num6 = 0f;
            DataTable list = new SystemInfoBN(currentPage).GetList();
            if (list.Rows.Count > 0)
            {
                num = Convert.ToInt32(list.Rows[0]["shortday"]);
                num6 = Convert.ToSingle(list.Rows[0]["frequency"]);
                num2 = Convert.ToInt32(list.Rows[0]["datediffw"]);
                num3 = Convert.ToInt32(list.Rows[0]["datedifff"]);
                num4 = Convert.ToInt32(list.Rows[0]["datediffm"]);
                num5 = Convert.ToInt32(list.Rows[0]["term"]);
            }
            TimeSpan span2 = new TimeSpan(0x3e8L);
            TimeSpan span3 = (TimeSpan) (timeRecentlySalaryDate - SafeDateTime.LocalNow);
            if (userLoanType == 0)
            {
                switch (repaymentType)
                {
                    case PaidPeriodTypes.Weekly:
                        if (span3.Days > num2)
                        {
                            errorString = "<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>";
                            return false;
                        }
                        currentPage.Session["frequency"] = 7;
                        span2 = new TimeSpan(7, 0, 0, 0);
                        timeFirstPay = timeRecentlySalaryDate + span2;
                        timeSecondPay = timeFirstPay + span2;
                        timeThirdPay = timeSecondPay + span2;
                        break;

                    case PaidPeriodTypes.Fnightly:
                        if (span3.Days > num3)
                        {
                            errorString = "<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>";
                            return false;
                        }
                        currentPage.Session["frequency"] = 14;
                        span2 = new TimeSpan(14, 0, 0, 0);
                        timeFirstPay = timeRecentlySalaryDate + span2;
                        timeSecondPay = timeFirstPay + span2;
                        timeThirdPay = timeSecondPay + span2;
                        break;

                    case PaidPeriodTypes.Monthly:
                        if ((numInstallmentCount <= 3) && (span3.Days > num4))
                        {
                            errorString = "<script>alert(\"The number of days to your next payday has exceeded 15 days. Please choose 'Repay on next payday' repayment option.\");</script>";
                            return false;
                        }
                        currentPage.Session["frequency"] = num6;
                        timeFirstPay = timeRecentlySalaryDate.AddMonths(1);
                        timeSecondPay = timeRecentlySalaryDate.AddMonths(2);
                        timeThirdPay = timeRecentlySalaryDate.AddMonths(3);
                        break;
                }
            }
            else
            {
                switch (repaymentType)
                {
                    case PaidPeriodTypes.Weekly:
                        if (span3.Days > num2)
                        {
                            errorString = "<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>";
                            return false;
                        }
                        currentPage.Session["frequency"] = 7;
                        span2 = new TimeSpan(7, 0, 0, 0);
                        timeFirstPay = timeRecentlySalaryDate + span2;
                        timeSecondPay = timeFirstPay + span2;
                        timeThirdPay = timeSecondPay + span2;
                        break;

                    case PaidPeriodTypes.Fnightly:
                        if (span3.Days > num3)
                        {
                            errorString = "<script>alert('The number of days to your next payday has exceeded one pay interval. Please re-enter your next payday.');</script>";
                            return false;
                        }
                        currentPage.Session["frequency"] = 14;
                        span2 = new TimeSpan(14, 0, 0, 0);
                        timeFirstPay = timeRecentlySalaryDate + span2;
                        timeSecondPay = timeFirstPay + span2;
                        timeThirdPay = timeSecondPay + span2;
                        break;

                    case PaidPeriodTypes.Monthly:
                        if ((numInstallmentCount <= 3) && (span3.Days > num4))
                        {
                            errorString = "<script>alert(\"The number of days to your next payday has exceeded 15 days. Please choose 'Repay on next payday' repayment option.\"');</script>";
                            return false;
                        }
                        currentPage.Session["frequency"] = num6;
                        timeFirstPay = timeRecentlySalaryDate.AddMonths(1);
                        timeSecondPay = timeRecentlySalaryDate.AddMonths(2);
                        timeThirdPay = timeRecentlySalaryDate.AddMonths(3);
                        break;
                }
            }
            TimeSpan span = (TimeSpan) (timeFirstPay - timeLoanRegistered);
            currentPage.Session["XFirst"] = span.Days;
            if (numInstallmentCount == 4)
            {
                timeAtOncePay = timeRecentlySalaryDate;
                TimeSpan span4 = (TimeSpan) (timeAtOncePay - timeLoanRegistered);
                if (span4.Days < 3)
                {
                    errorString = "<script>alert(\"There's less than 3 days to your next payday. Please choose another repayment option.\")</script>";
                    currentPage.Session["XFirst2"] = null;
                    return false;
                }
                currentPage.Session["XFirst2"] = span4.Days;
            }
            currentPage.Session["Datedue1"] = (DateTime) timeFirstPay;
            currentPage.Session["Datedue2"] = (DateTime) timeSecondPay;
            currentPage.Session["Datedue3"] = (DateTime) timeThirdPay;
            currentPage.Session["Datedue4"] = (DateTime) timeAtOncePay;
            errorString = string.Empty;
            return true;
        }

        public static bool CalculatePayLoan(Page currentPage, int userLoanType, int numInstallmentCount, float numIncomeOrBenefit, float numLoanAmount, out string errorString)
        {
            return CalculatePayLoan(currentPage, userLoanType, numInstallmentCount, numIncomeOrBenefit, numLoanAmount, true, out errorString);
        }

        public static bool CalculatePayLoan(Page currentPage, int userLoanType, int numInstallmentCount, float numIncomeOrBenefit, float numLoanAmount, bool isFirstLoan, out string errorString)
        {
            float num = 0f;
            float num2 = 0f;
            float num3 = 0f;
            float num4 = 0f;
            float num5 = 0f;
            float num6 = 0f;
            float num7 = 0f;
            float num8 = 0f;
            int num9 = 0;
            int num10 = 0;
            DataTable list = new SystemInfoBN(currentPage).GetList();
            if (list.Rows.Count > 0)
            {
                num = Convert.ToSingle(list.Rows[0]["interest"].ToString());
                num2 = Convert.ToSingle(list.Rows[0]["frequency"].ToString());
                num3 = Convert.ToSingle(list.Rows[0]["percentage"].ToString());
                num4 = Convert.ToInt32(list.Rows[0]["upperlimit"].ToString());
                num5 = Convert.ToInt32(list.Rows[0]["upperlimit2"].ToString());
                num9 = Convert.ToInt32(list.Rows[0]["IsPercent"].ToString());
                num7 = Convert.ToSingle(list.Rows[0]["lowerlimit"].ToString());
                num8 = Convert.ToSingle(list.Rows[0]["lowerlimit2"].ToString());
                num6 = Convert.ToSingle(list.Rows[0]["poundage"].ToString());
                num10 = Convert.ToInt32(list.Rows[0]["term"].ToString());
            }
            if (isFirstLoan)
            {
                if (numLoanAmount > num4)
                {
                    errorString = "<script>alert(\"Maximum amount you can borrow for your fist loan is $" + num4.ToString() + ". Please modify and continue.\")</script>";
                    return false;
                }
            }
            else if (numLoanAmount > num5)
            {
                errorString = "<script>alert(\"Maximum amount you can borrow for your fist loan is $" + num4.ToString() + ". Please modify and continue.\")</script>";
                return false;
            }
            if (numLoanAmount > ((numIncomeOrBenefit * num3) * numInstallmentCount))
            {
                errorString = "<script>alert(\"The loan amount you requested will exceed your maximum borrowing capability. Please modify and continue.\")</script>";
                return false;
            }
            string s = Config.AppSetting("minTerm");
            int num11 = 0x10;
            if ((s != null) && (s != ""))
            {
                try
                {
                    num11 = int.Parse(s);
                }
                catch
                {
                }
            }
            string str2 = Config.AppSetting("maxTerm");
            int num12 = 0x10;
            if ((str2 != null) && (str2 != ""))
            {
                try
                {
                    num12 = int.Parse(str2);
                }
                catch
                {
                }
            }
            int days = 0;
            int num14 = 0;
            if ((currentPage.Session["Datedue1"] != null) && !(currentPage.Session["Datedue1"].ToString() == ""))
            {
                TimeSpan span = (TimeSpan) (Convert.ToDateTime(currentPage.Session["Datedue1"]) - SafeDateTime.LocalNow);
                days = span.Days;
            }
            switch (numInstallmentCount)
            {
                case 1:
                    if ((currentPage.Session["Datedue1"] != null) && !(currentPage.Session["Datedue1"].ToString() == ""))
                    {
                        TimeSpan span2 = (TimeSpan) (Convert.ToDateTime(currentPage.Session["Datedue1"]) - SafeDateTime.LocalToday);
                        num14 = span2.Days;
                    }
                    break;

                case 2:
                    if ((currentPage.Session["Datedue2"] != null) && !(currentPage.Session["Datedue2"].ToString() == ""))
                    {
                        TimeSpan span3 = (TimeSpan) (Convert.ToDateTime(currentPage.Session["Datedue2"]) - SafeDateTime.LocalToday);
                        num14 = span3.Days;
                    }
                    break;

                case 3:
                    if ((currentPage.Session["Datedue3"] != null) && !(currentPage.Session["Datedue3"].ToString() == ""))
                    {
                        TimeSpan span4 = (TimeSpan) (Convert.ToDateTime(currentPage.Session["Datedue3"]) - SafeDateTime.LocalToday);
                        num14 = span4.Days;
                    }
                    break;

                case 4:
                    if (currentPage.Session["XFirst2"] != null)
                    {
                        days = num14 = Convert.ToInt32(currentPage.Session["XFirst2"]);
                    }
                    break;
            }
            if ((num14 < num11) || (num14 > num12))
            {
                errorString = "<script>alert(\"Loan term is must more than " + num11.ToString() + " and less than " + num12.ToString() + " .Please adjust and continue.\")</script>";
                return false;
            }
            if (numLoanAmount < num7)
            {
                errorString = "<script>alert(\"Loan less than $" + num7.ToString() + ". Please adjust and continue.\")</script>";
                return false;
            }
            if ((numLoanAmount < num8) && (numInstallmentCount > 1))
            {
                errorString = "<script>alert(\"For loan less than $" + num8.ToString() + ",ONE installment ONLY. Please adjust and continue.\")</script>";
                return false;
            }
            int num15 = Convert.ToInt32(currentPage.Session["XFirst"]);
            currentPage.Session["Repayduezs"] = numLoanAmount.ToString();
            double num18 = 0.0;
            if (num14 <= 0x1f)
            {
                num18 = 0.24;
            }
            else
            {
                num18 = 0.24;
            }
            double num19 = numLoanAmount * (1.0 + num18);
            switch (numInstallmentCount)
            {
                case 1:
                    currentPage.Session["Repaydue1"] = num19.ToString("0.00");
                    break;

                case 2:
                    currentPage.Session["Repaydue1"] = (num19 / 2.0).ToString("0.00");
                    currentPage.Session["Repaydue2"] = (num19 / 2.0).ToString("0.00");
                    break;

                case 3:
                    currentPage.Session["Repaydue1"] = (num19 / 3.0).ToString("0.00");
                    currentPage.Session["Repaydue2"] = (num19 / 3.0).ToString("0.00");
                    currentPage.Session["Repaydue3"] = (num19 / 3.0).ToString("0.00");
                    break;

                case 4:
                    if (currentPage.Session["XFirst2"] != null)
                    {
                        currentPage.Session["Repaydue4"] = num19.ToString("0.00");
                    }
                    break;
            }
            errorString = string.Empty;
            return true;
        }

        public static bool CalculatePayLoan(Page currentPage, float numIncomeOrBenefit, float numLoanAmount, int numInstallmentCount, bool isFirstLoan, ref double PayAmountPerTime, out string errorString)
        {
            float num = 0f;
            float num2 = 0f;
            float num3 = 0f;
            float num4 = 0f;
            float num5 = 0f;
            float num6 = 0f;
            float num7 = 0f;
            float num8 = 0f;
            int num9 = 0;
            int num10 = 0;
            DataTable list = new SystemInfoBN(currentPage).GetList();
            if (list.Rows.Count > 0)
            {
                num = Convert.ToSingle(list.Rows[0]["interest"].ToString());
                num2 = Convert.ToSingle(list.Rows[0]["frequency"].ToString());
                num3 = Convert.ToSingle(list.Rows[0]["percentage"].ToString());
                num4 = Convert.ToInt32(list.Rows[0]["upperlimit"].ToString());
                num5 = Convert.ToInt32(list.Rows[0]["upperlimit2"].ToString());
                num9 = Convert.ToInt32(list.Rows[0]["IsPercent"].ToString());
                num7 = Convert.ToSingle(list.Rows[0]["lowerlimit"].ToString());
                num8 = Convert.ToSingle(list.Rows[0]["lowerlimit2"].ToString());
                num6 = Convert.ToSingle(list.Rows[0]["poundage"].ToString());
                num10 = Convert.ToInt32(list.Rows[0]["term"].ToString());
            }
            if (isFirstLoan)
            {
                if (numLoanAmount > num4)
                {
                    errorString = "<script>alert(\"Maximum amount you can borrow for your fist loan is $" + num4.ToString() + ". Please modify and continue.\")</script>";
                    return false;
                }
            }
            else if (numLoanAmount > num5)
            {
                errorString = "<script>alert(\"Maximum amount you can borrow for your fist loan is $" + num4.ToString() + ". Please modify and continue.\")</script>";
                return false;
            }
            if (numLoanAmount > ((numIncomeOrBenefit * num3) * numInstallmentCount))
            {
                errorString = "<script>alert(\"The loan amount you requested will exceed your maximum borrowing capability. Please modify and continue.\")</script>";
                return false;
            }
            if (numLoanAmount < num7)
            {
                errorString = "<script>alert(\"Loan less than $" + num7.ToString() + ". Please adjust and continue.\")</script>";
                return false;
            }
            if ((numLoanAmount < num8) && (numInstallmentCount > 1))
            {
                errorString = "<script>alert(\"For loan less than $" + num8.ToString() + ",ONE installment ONLY. Please adjust and continue.\")</script>";
                return false;
            }
            currentPage.Session["Repayduezs"] = numLoanAmount.ToString();
            double num11 = 0.28;
            double num12 = numLoanAmount * (1.0 + num11);
            PayAmountPerTime = num12 / ((double) numInstallmentCount);
            errorString = string.Empty;
            return true;
        }
    }
}

