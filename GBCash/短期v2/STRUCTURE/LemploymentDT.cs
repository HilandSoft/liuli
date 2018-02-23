namespace YingNet.WeiXing.STRUCTURE
{
    using System;

    public class LemploymentDT
    {
        public string allFields = "sid,EName,EAddress,ECode,ENum,EStatus,JobTitle,TimeYears,TimeMonths,TakePay,Per,NextDay,NextMonth,NextYear,LoanSid,Other1,Other2,Other3,Other4,Other5,Other6,FollowDay,FollowMonth,FollowYear,HousePaymentValue,HousePaymentCircle,OtherLenderValue,OtherLenderCircle";
        public string EAddress;
        public string ECode;
        public string EName;
        public string ENum;
        public string EStatus;
        public int FollowDay;
        public int FollowMonth;
        public int FollowYear;
        private HousePaymentCircles housePaymentCircle = HousePaymentCircles.NonSet;
        private float housePaymentValue = 0f;
        public string JobTitle;
        public int LoanSid;
        public int NextDay;
        public int NextMonth;
        public int NextYear;
        public string Other1;
        public string Other2;
        public string Other3;
        public int Other4;
        public int Other5;
        public int Other6;
        private OtherLenderCircles otherLenderCircle = OtherLenderCircles.NonSet;
        private float otherLenderValue = 0f;
        public int Per;
        public int sid;
        public double TakePay;
        public int TimeMonths;
        public int TimeYears;

        public HousePaymentCircles HousePaymentCircle
        {
            get
            {
                return this.housePaymentCircle;
            }
            set
            {
                this.housePaymentCircle = value;
            }
        }

        public float HousePaymentValue
        {
            get
            {
                return this.housePaymentValue;
            }
            set
            {
                this.housePaymentValue = value;
            }
        }

        public OtherLenderCircles OtherLenderCircle
        {
            get
            {
                return this.otherLenderCircle;
            }
            set
            {
                this.otherLenderCircle = value;
            }
        }

        public float OtherLenderValue
        {
            get
            {
                return this.otherLenderValue;
            }
            set
            {
                this.otherLenderValue = value;
            }
        }
    }
}

