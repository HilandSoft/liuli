namespace YingNet.WeiXing.Business.CommonLogic
{
    using System;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.STRUCTURE;

    public class AnnualPercentageRate
    {
        private AnnualPercentageRate()
        {
        }

        public static decimal GetAnnualPercentageRate(DateTime lastPayDate)
        {
            TimeSpan span = (TimeSpan) (lastPayDate - SafeDateTime.LocalNow);
            int days = span.Days;
            if (days <= 0)
            {
                days = 1;
            }
            double num2 = 0.24;
            if (days <= 0x1f)
            {
                num2 = 0.24;
            }
            else
            {
                num2 = 0.24;
            }
            return ((((decimal) num2) / days) * 365M);
        }

        public static decimal GetAnnualPercentageRate(PaidPeriodTypes paidPeriodType, int paidCount)
        {
            switch (paidPeriodType)
            {
                case PaidPeriodTypes.Weekly:
                    switch (paidCount)
                    {
                        case 1:
                            return 4.8689M;

                        case 2:
                            return 6.3660M;

                        case 3:
                            return 7.0130M;
                    }
                    return 4.8689M;

                case PaidPeriodTypes.Fnightly:
                    switch (paidCount)
                    {
                        case 1:
                            return 4.8689M;

                        case 2:
                            return 6.2616M;

                        case 3:
                            return 6.7834M;
                    }
                    return 4.8689M;

                case PaidPeriodTypes.Monthly:
                    switch (paidCount)
                    {
                        case 1:
                            return 4.8689M;

                        case 2:
                            return 4.8689M;

                        case 3:
                            return 4.8689M;
                    }
                    return 4.8689M;
            }
            return 4.8689M;
        }

        public static string GetAnnualPercentageRatePercent(DateTime lastPayDate)
        {
            decimal num = GetAnnualPercentageRate(lastPayDate) * 100M;
            return (num.ToString("0.00") + "%");
        }

        public static string GetAnnualPercentageRatePercent(PaidPeriodTypes paidPeriodType, int paidCount)
        {
            decimal num = GetAnnualPercentageRate(paidPeriodType, paidCount) * 100M;
            return (num.ToString("0.00") + "%");
        }
    }
}

