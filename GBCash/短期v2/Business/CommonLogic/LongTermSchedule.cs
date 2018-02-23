namespace YingNet.WeiXing.Business.CommonLogic
{
    using System;
    using System.Collections;
    using System.Data;
    using YingNet.Common;

    public class LongTermSchedule
    {
        public static void AddSchedules(string personID, DateTime payDate, int numTermCount, string perTypeUserChoosen, float numLoanAmount, int followDay, int followMonth, int followYear, DateTime loanHappenedDate)
        {
            int day = 0;
            int month = 0;
            int year = 0;
            int num4 = 0;
            int num5 = 0;
            double num6 = 0.0;
            double num7 = 0.0;
            double num8 = 0.0;
            string commandText = "";
            DateTime nextPayDate = payDate;
            TimeSpan span = (TimeSpan) (payDate - loanHappenedDate);
            commandText = "select * from LParams where Sid=" + numTermCount.ToString();
            DataTable table = new DataTable();
            table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
            string str2 = "";
            switch (perTypeUserChoosen)
            {
                case "0":
                    num6 = Convert.ToDouble(table.Rows[0]["NrW"]) * 0.01;
                    num4 = numTermCount * 4;
                    num7 = (((numLoanAmount * num6) * num4) + numLoanAmount) / ((double) num4);
                    if (span.Days < 15)
                    {
                        payDate = payDate.AddDays(7.0);
                    }
                    num5 = 0;
                    while (num5 < num4)
                    {
                        num8 = num7 * (num5 + 1);
                        str2 = payDate.Day.ToString() + "/" + payDate.Month.ToString() + "/" + payDate.Year.ToString();
                        commandText = "insert into LPay(Datedue,Repaydue,Balance,PerSid,Interest) values ('" + str2 + "'," + num7.ToString("0.00") + "," + num8.ToString("0.00") + "," + personID + "," + table.Rows[0]["NrW"].ToString() + ")";
                        payDate = payDate.AddDays(7.0);
                        SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText);
                        num5++;
                    }
                    break;

                case "1":
                    num6 = Convert.ToSingle(table.Rows[0]["NrF"]) * 0.01;
                    num4 = numTermCount * 2;
                    num7 = (((numLoanAmount * num6) * num4) + numLoanAmount) / ((double) num4);
                    if (span.Days < 15)
                    {
                        payDate = payDate.AddDays(14.0);
                    }
                    for (num5 = 0; num5 < num4; num5++)
                    {
                        num8 = num7 * (num5 + 1);
                        str2 = payDate.Day.ToString() + "/" + payDate.Month.ToString() + "/" + payDate.Year.ToString();
                        commandText = "insert into LPay(Datedue,Repaydue,Balance,PerSid,Interest) values ('" + str2 + "'," + num7.ToString("0.00") + "," + num8.ToString("0.00") + "," + personID + "," + table.Rows[0]["NrF"].ToString() + ")";
                        payDate = payDate.AddDays(14.0);
                        SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText);
                    }
                    break;

                case "2":
                {
                    num6 = Convert.ToSingle(table.Rows[0]["NrB"]) * 0.01;
                    day = followDay;
                    month = followMonth;
                    year = followYear;
                    DateTime time2 = new DateTime(year, month, day);
                    num4 = numTermCount * 2;
                    num7 = (((numLoanAmount * num6) * num4) + numLoanAmount) / ((double) num4);
                    if (span.Days < 15)
                    {
                        payDate = time2;
                    }
                    for (num5 = 0; num5 < num4; num5++)
                    {
                        num8 = num7 * (num5 + 1);
                        str2 = payDate.Day.ToString() + "/" + payDate.Month.ToString() + "/" + payDate.Year.ToString();
                        commandText = "insert into LPay(Datedue,Repaydue,Balance,PerSid,Interest) values ('" + str2 + "'," + num7.ToString("0.00") + "," + num8.ToString("0.00") + "," + personID + "," + table.Rows[0]["NrB"].ToString() + ")";
                        payDate = GetNextBiMonth(nextPayDate, payDate, 1);
                        SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText);
                    }
                    break;
                }
                case "3":
                    num6 = Convert.ToSingle(table.Rows[0]["NrM"]) * 0.01;
                    num4 = numTermCount;
                    num7 = (((numLoanAmount * num6) * num4) + numLoanAmount) / ((double) num4);
                    if (span.Days < 15)
                    {
                        payDate = GetNextMonth(payDate, 1);
                    }
                    for (num5 = 0; num5 < num4; num5++)
                    {
                        num8 = num7 * (num5 + 1);
                        str2 = payDate.Day.ToString() + "/" + payDate.Month.ToString() + "/" + payDate.Year.ToString();
                        commandText = "insert into LPay(Datedue,Repaydue,Balance,PerSid,Interest) values ('" + str2 + "'," + num7.ToString("0.00") + "," + num8.ToString("0.00") + "," + personID + "," + table.Rows[0]["NrM"].ToString() + ")";
                        payDate = GetNextMonth(payDate, 1);
                        SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText);
                    }
                    break;
            }
        }

        public static void DeleteSchedules(int personID)
        {
            string commandText = "DELETE FROM [LPay] WHERE [PerSid]= " + personID;
            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText);
        }

        public static DateTime GetNextBiMonth(DateTime nextPayDate, DateTime followNextPayDate, int addMonths)
        {
            int year = followNextPayDate.Year;
            int month = followNextPayDate.Month;
            int day = followNextPayDate.Day;
            int num4 = year;
            int num5 = month;
            int num6 = day;
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, 0x1f);
            hashtable.Add(2, 0x1c);
            hashtable.Add(3, 0x1f);
            hashtable.Add(4, 30);
            hashtable.Add(5, 0x1f);
            hashtable.Add(6, 30);
            hashtable.Add(7, 0x1f);
            hashtable.Add(8, 0x1f);
            hashtable.Add(9, 30);
            hashtable.Add(10, 0x1f);
            hashtable.Add(11, 30);
            hashtable.Add(12, 0x1f);
            switch (day)
            {
                case 0x1c:
                    if (((month + addMonths) - 1) >= 12)
                    {
                        num4 = year + 1;
                        num5 = (month + addMonths) - 12;
                        break;
                    }
                    num4 = year;
                    num5 = month + addMonths;
                    break;

                case 0x1d:
                    goto Label_028B;

                case 30:
                    if (((month + addMonths) - 1) < 12)
                    {
                        num4 = year;
                        num5 = month + addMonths;
                    }
                    else
                    {
                        num4 = year + 1;
                        num5 = (month + addMonths) - 12;
                    }
                    num6 = 15;
                    goto Label_028B;

                case 0x1f:
                    if (((month + addMonths) - 1) >= 12)
                    {
                        num4 = year + 1;
                        num5 = (month + addMonths) - 12;
                    }
                    else
                    {
                        num4 = year;
                        num5 = month + addMonths;
                    }
                    num6 = 15;
                    goto Label_028B;

                case 15:
                    if (!nextPayDate.Day.Equals(1))
                    {
                        if (((month + addMonths) - 2) >= 12)
                        {
                            num4 = year + 1;
                            num5 = ((month + addMonths) - 12) - 1;
                        }
                        else
                        {
                            num4 = year;
                            num5 = (month + addMonths) - 1;
                        }
                        num6 = Convert.ToInt32(hashtable[month]);
                    }
                    else
                    {
                        if (((month + addMonths) - 1) >= 12)
                        {
                            num4 = year + 1;
                            num5 = (month + addMonths) - 12;
                        }
                        else
                        {
                            num4 = year;
                            num5 = month + addMonths;
                        }
                        num6 = 1;
                    }
                    goto Label_028B;

                case 1:
                    if (((month + addMonths) - 2) >= 12)
                    {
                        num4 = year + 1;
                        num5 = ((month + addMonths) - 12) - 1;
                    }
                    else
                    {
                        num4 = year;
                        num5 = (month + addMonths) - 1;
                    }
                    num6 = 15;
                    goto Label_028B;

                default:
                {
                    DateTime time = followNextPayDate.AddMonths(addMonths);
                    num4 = time.Year;
                    num5 = time.Month;
                    num6 = time.Day;
                    goto Label_028B;
                }
            }
            num6 = 15;
        Label_028B:
            return new DateTime(num4, num5, num6, 0x17, 0x3b, 0x3b);
        }

        public static DateTime GetNextMonth(DateTime date, int addMonths)
        {
            int year = date.Year;
            int month = date.Month;
            DateTime time = date.AddMonths(addMonths);
            year = time.Year;
            month = time.Month;
            int day = date.Day;
            Hashtable hashtable = new Hashtable();
            hashtable.Add(1, 0x1f);
            hashtable.Add(2, 0x1c);
            hashtable.Add(3, 0x1f);
            hashtable.Add(4, 30);
            hashtable.Add(5, 0x1f);
            hashtable.Add(6, 30);
            hashtable.Add(7, 0x1f);
            hashtable.Add(8, 0x1f);
            hashtable.Add(9, 30);
            hashtable.Add(10, 0x1f);
            hashtable.Add(11, 30);
            hashtable.Add(12, 0x1f);
            if (month > 12)
            {
                year++;
                month = 1;
            }
            if ((day.Equals(0x1d) || day.Equals(30)) && month.Equals(2))
            {
                day = 0x1c;
            }
            if (day.Equals(0x1f))
            {
                day = Convert.ToInt32(hashtable[month]);
            }
            return new DateTime(year, month, day);
        }

        public static double IsLimit(string term, string sPer, string sTakePay)
        {
            string commandText = "select * from LParams where Sid=" + term;
            DataTable table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
            if (table.Rows.Count <= 0)
            {
                return 0.0;
            }
            int num = 0;
            double num2 = 0.0;
            int num3 = Convert.ToInt32(term);
            switch (sPer)
            {
                case "0":
                    num2 = Convert.ToDouble(table.Rows[0]["NrW"]) * 0.01;
                    num = num3 * 4;
                    break;

                case "1":
                    num2 = Convert.ToDouble(table.Rows[0]["NrF"]) * 0.01;
                    num = num3 * 2;
                    break;

                case "2":
                    num2 = Convert.ToDouble(table.Rows[0]["NrB"]) * 0.01;
                    num = num3 * 2;
                    break;

                case "3":
                    num2 = Convert.ToDouble(table.Rows[0]["NrM"]) * 0.01;
                    num = num3;
                    break;
            }
            return (((0.25 * Convert.ToDouble(sTakePay)) * num) / ((num * num2) + 1.0));
        }
    }
}

