namespace YingNet.WeiXing.STRUCTURE
{
    using System;

    public class EnumsOP
    {
        public static HousePaymentCircles GetHousePaymentCircleByLiteral(string circleText)
        {
            circleText = circleText.ToLower();
            switch (circleText)
            {
                case "weekly":
                case "week":
                case "perweek":
                    return HousePaymentCircles.Weekly;

                case "fnight":
                case "f'night":
                    return HousePaymentCircles.FNight;

                case "month":
                case "monthly":
                    return HousePaymentCircles.Monthly;

                case "bimonth":
                case "bi-month":
                case "bimonthly":
                    return HousePaymentCircles.BiMonth;
            }
            return HousePaymentCircles.NonSet;
        }

        public static string GetHousePaymentCircleLiteral(object input)
        {
            string str = string.Empty;
            if (input == null)
            {
                return "UnSet";
            }
            try
            {
                str = ((HousePaymentCircles) input).ToString();
            }
            catch
            {
            }
            return str;
        }

        public static OtherLenderCircles GetOtherLenderCircleByLiteral(string circleText)
        {
            circleText = circleText.ToLower();
            switch (circleText)
            {
                case "weekly":
                case "week":
                case "perweek":
                    return OtherLenderCircles.Weekly;

                case "fnight":
                case "f'night":
                    return OtherLenderCircles.FNight;

                case "month":
                case "monthly":
                    return OtherLenderCircles.Monthly;

                case "bimonth":
                case "bi-month":
                case "bimonthly":
                    return OtherLenderCircles.BiMonth;
            }
            return OtherLenderCircles.NonSet;
        }

        public static string GetOtherLenderCircleLiteral(object input)
        {
            string str = string.Empty;
            if (input == null)
            {
                return "UnSet";
            }
            try
            {
                str = ((OtherLenderCircles) input).ToString();
            }
            catch
            {
            }
            return str;
        }
    }
}

