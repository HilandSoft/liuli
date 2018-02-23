namespace YingNet.WeiXing.DB.Data
{
    using System;

    public enum FollowupCenterStatusEnum
    {
        BlackList = 100,
        Collection = 60,
        DefaultLetter = 40,
        FinalNotice = 50,
        FollowupByDate = 10,
        FollowupEveryday = 0,
        NoStatus = -1,
        OnHold = 70,
        Part9AwaitingDividends = 90,
        Part9AwaitingResult = 80,
        ReDDed = 30,
        ScheduledPayment = 20
    }
}

