namespace YingNet.WeiXing.Business
{
    using System;
    using YingNet.WeiXing.STRUCTURE;

    public class LMisc
    {
        public static decimal GetAnnualRate(PaidPeriodTypes paidPeriodType, int paidCount)
        {
            decimal num = 0M;
            switch (GetPaidMonthCountByPaidCount(paidPeriodType, paidCount))
            {
                case 3:
                    switch (paidPeriodType)
                    {
                        case PaidPeriodTypes.Weekly:
                            return 3.9182M;

                        case PaidPeriodTypes.Fnightly:
                            return 3.7074M;

                        case PaidPeriodTypes.Monthly:
                            return 3.3300M;

                        case PaidPeriodTypes.Other:
                            return num;

                        case PaidPeriodTypes.BiMonthly:
                            return 3.6816M;
                    }
                    return num;

                case 4:
                    switch (paidPeriodType)
                    {
                        case PaidPeriodTypes.Weekly:
                            return 3.1574M;

                        case PaidPeriodTypes.Fnightly:
                            return 3.0304M;

                        case PaidPeriodTypes.Monthly:
                            return 2.7852M;

                        case PaidPeriodTypes.Other:
                            return num;

                        case PaidPeriodTypes.BiMonthly:
                            return 3.0046M;
                    }
                    return num;

                case 5:
                    switch (paidPeriodType)
                    {
                        case PaidPeriodTypes.Weekly:
                            return 2.7577M;

                        case PaidPeriodTypes.Fnightly:
                            return 2.6703M;

                        case PaidPeriodTypes.Monthly:
                            return 2.4912M;

                        case PaidPeriodTypes.Other:
                            return num;

                        case PaidPeriodTypes.BiMonthly:
                            return 2.6472M;
                    }
                    return num;

                case 6:
                    switch (paidPeriodType)
                    {
                        case PaidPeriodTypes.Weekly:
                            return 2.3695M;

                        case PaidPeriodTypes.Fnightly:
                            return 2.3071M;

                        case PaidPeriodTypes.Monthly:
                            return 2.1732M;

                        case PaidPeriodTypes.Other:
                            return num;

                        case PaidPeriodTypes.BiMonthly:
                            return 2.2847M;
                    }
                    return num;

                case 7:
                    switch (paidPeriodType)
                    {
                        case PaidPeriodTypes.Weekly:
                            return 1.9884M;

                        case PaidPeriodTypes.Fnightly:
                            return 1.9429M;

                        case PaidPeriodTypes.Monthly:
                            return 1.8414M;

                        case PaidPeriodTypes.Other:
                            return num;

                        case PaidPeriodTypes.BiMonthly:
                            return 1.9246M;
                    }
                    return num;

                case 8:
                    switch (paidPeriodType)
                    {
                        case PaidPeriodTypes.Weekly:
                            return 1.9470M;

                        case PaidPeriodTypes.Fnightly:
                            return 1.9059M;

                        case PaidPeriodTypes.Monthly:
                            return 1.8192M;

                        case PaidPeriodTypes.Other:
                            return num;

                        case PaidPeriodTypes.BiMonthly:
                            return 1.8886M;
                    }
                    return num;

                case 9:
                    switch (paidPeriodType)
                    {
                        case PaidPeriodTypes.Weekly:
                            return 1.8993M;

                        case PaidPeriodTypes.Fnightly:
                            return 1.8714M;

                        case PaidPeriodTypes.Monthly:
                            return 1.7928M;

                        case PaidPeriodTypes.Other:
                            return num;

                        case PaidPeriodTypes.BiMonthly:
                            return 1.8502M;
                    }
                    return num;

                case 10:
                    switch (paidPeriodType)
                    {
                        case PaidPeriodTypes.Weekly:
                            return 1.8617M;

                        case PaidPeriodTypes.Fnightly:
                            return 1.8336M;

                        case PaidPeriodTypes.Monthly:
                            return 1.7646M;

                        case PaidPeriodTypes.Other:
                            return num;

                        case PaidPeriodTypes.BiMonthly:
                            return 1.8130M;
                    }
                    return num;

                case 11:
                    switch (paidPeriodType)
                    {
                        case PaidPeriodTypes.Weekly:
                            return 1.6828M;

                        case PaidPeriodTypes.Fnightly:
                            return 1.8002M;

                        case PaidPeriodTypes.Monthly:
                            return 1.7351M;

                        case PaidPeriodTypes.Other:
                            return num;

                        case PaidPeriodTypes.BiMonthly:
                            return 1.7760M;
                    }
                    return num;

                case 12:
                    switch (paidPeriodType)
                    {
                        case PaidPeriodTypes.Weekly:
                            return 1.7878M;

                        case PaidPeriodTypes.Fnightly:
                            return 1.7639M;

                        case PaidPeriodTypes.Monthly:
                            return 1.7060M;

                        case PaidPeriodTypes.Other:
                            return num;

                        case PaidPeriodTypes.BiMonthly:
                            return 1.7424M;
                    }
                    return num;
            }
            return num;
        }

        public static string GetAnnualRatePercent(PaidPeriodTypes paidPeriodType, int paidCount)
        {
            return GetAnnualRatePercent(paidPeriodType, paidCount, false);
        }

        public static string GetAnnualRatePercent(PaidPeriodTypes paidPeriodType, int paidCount, bool withPostFix)
        {
            string str = (GetAnnualRate(paidPeriodType, paidCount) * 100M).ToString("0.00");
            if (withPostFix)
            {
                str = str + "%";
            }
            return str;
        }

        private static int GetPaidMonthCountByPaidCount(PaidPeriodTypes paidPeriodType, int paidCount)
        {
            switch (paidPeriodType)
            {
                case PaidPeriodTypes.Weekly:
                    return (paidCount / 4);

                case PaidPeriodTypes.Fnightly:
                    return (paidCount / 2);

                case PaidPeriodTypes.Monthly:
                    return paidCount;
            }
            return (paidCount * 2);
        }
    }
}

