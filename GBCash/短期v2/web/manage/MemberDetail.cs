﻿namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;
    using YingNet.WeiXing.STRUCTURE;

    public class MemberDetail : ManageBasePage
    {
        public string AName = "";
        public string ANumber = "";
        public string BankName = "";
        public string Branch = "";
        public string Bsb = "";
        public string d1 = "";
        public string d2 = "";
        public string d3 = "";
        public string dlTitle = "";
        public string EmploymentInfo = "";
        public string GrossIncomeChangeValue = string.Empty;
        protected HtmlInputHidden Hidden1;
        public string houseInfo = string.Empty;
        protected HyperLink HyperLinkEdit;
        public string IsEmployed = "";
        public string IsGrossIncomeChange = string.Empty;
        public string IsPayOtherCredit = string.Empty;
        public string loanPurpose = string.Empty;
        public string MContact = "";
        public string otherLenderInfo = string.Empty;
        public string otherSmallCreditCount = string.Empty;
        public string otherSmallCreditHas = string.Empty;
        public string paid = "";
        public string PayOtherCreditValue = string.Empty;
        public string Rname1 = "";
        public string Rname2 = "";
        public string Rname3 = "";
        public string Rnum1 = "";
        public string Rnum2 = "";
        public string Rnum3 = "";
        public string Rship1 = "";
        public string Rship2 = "";
        public string Rship3 = "";
        public string s1 = "";
        public string s2 = "";
        public string s3 = "";
        public string selState = "";
        protected HtmlInputButton Submit1;
        protected HtmlInputButton Submit2;
        protected HtmlInputButton Submit3;
        public string tip1 = "";
        public string tip2 = "";
        public string tip3 = "";
        public string tip4 = "";
        public string tip5 = "";
        public string tip6 = "";
        public string tip7 = "";
        public string txAddress = "";
        public string txCity = "";
        public string txDate = "";
        public string txDd1 = "";
        public string txDriver = "";
        public string txEmail = "";
        public string txEmployer = "";
        public string txFax = "";
        public string txFname = "";
        public string txIncome = "";
        public string txIssue = "";
        public string txJob = "";
        public string txLname = "";
        public string txMm1 = "";
        public string txMname = "";
        public string txMobile = "";
        public string txMonth = "";
        public string txMonthd = "";
        public string txPhone = "";
        public string txPost = "";
        public string txResident = "";
        public string txStreet = "";
        public string txTel = "";
        public string txYear = "";
        public string txYeard = "";
        public string txYy1 = "";

        private void InitializeComponent()
        {
            this.Submit1.ServerClick += new EventHandler(this.Submit1_ServerClick);
            this.Submit2.ServerClick += new EventHandler(this.Submit2_ServerClick);
            this.Submit3.ServerClick += new EventHandler(this.Submit3_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            int num = Convert.ToInt32(base.Request["id"]);
            this.HyperLinkEdit.NavigateUrl = "MemberDetailEdit.aspx?id=" + num;
            if (this.Page.IsPostBack)
            {
                return;
            }
            this.Hidden1.Value = num.ToString();
            HuiyuanBN nbn = new HuiyuanBN(this.Page);
            nbn.QuerySid(num.ToString());
            DataTable list = nbn.GetList();
            if (list.Rows.Count > 0)
            {
                this.dlTitle = list.Rows[0]["Param2"].ToString();
                this.txFname = list.Rows[0]["Fname"].ToString();
                this.txLname = list.Rows[0]["Lname"].ToString();
                this.txMname = list.Rows[0]["Mname"].ToString();
                this.txDate = Convert.ToDateTime(list.Rows[0]["DBirth"]).ToString("dd/MM/yyyy");
                this.txEmail = list.Rows[0]["Email"].ToString();
                this.txIssue = list.Rows[0]["Issued"].ToString();
                this.txDriver = list.Rows[0]["DNumber"].ToString();
                this.txResident = list.Rows[0]["RAddress"].ToString();
                this.txStreet = list.Rows[0]["SAddress"].ToString();
                this.txCity = list.Rows[0]["City"].ToString();
                this.selState = list.Rows[0]["State"].ToString();
                this.txPost = list.Rows[0]["Postcode"].ToString();
                this.txYeard = list.Rows[0]["TYears"].ToString();
                this.txMonthd = list.Rows[0]["TMonths"].ToString();
                this.txTel = list.Rows[0]["HTel"].ToString();
                this.txMobile = list.Rows[0]["Mobile"].ToString();
                this.txFax = list.Rows[0]["Param1"].ToString();
            }
            EmployedBN dbn = new EmployedBN(this.Page);
            dbn.QueryhuiSid(this.Hidden1.Value);
            DataTable table2 = dbn.GetList();
            if (table2.Rows.Count <= 0)
            {
                return;
            }
            this.txEmployer = table2.Rows[0]["Employer"].ToString();
            this.txAddress = table2.Rows[0]["EAddress"].ToString();
            this.txPhone = table2.Rows[0]["EPhone"].ToString();
            this.txYear = table2.Rows[0]["TYears"].ToString();
            this.txMonth = table2.Rows[0]["TMonths"].ToString();
            this.txIncome = Convert.ToSingle(table2.Rows[0]["MIncome"]).ToString("0.00");
            this.IsEmployed = table2.Rows[0]["IsEmployed"].ToString();
            this.Branch = table2.Rows[0]["Branch"].ToString();
            this.BankName = table2.Rows[0]["BankName"].ToString();
            this.AName = table2.Rows[0]["AName"].ToString();
            this.Bsb = table2.Rows[0]["Bsb"].ToString();
            this.ANumber = table2.Rows[0]["ANumber"].ToString();
            this.MContact = table2.Rows[0]["MContact"].ToString();
            this.Rname1 = table2.Rows[0]["Rname1"].ToString();
            this.Rname2 = table2.Rows[0]["Rname2"].ToString();
            this.Rname3 = table2.Rows[0]["Rname3"].ToString();
            this.Rship1 = table2.Rows[0]["Rship1"].ToString();
            this.Rship2 = table2.Rows[0]["Rship2"].ToString();
            this.Rship3 = table2.Rows[0]["Rship3"].ToString();
            this.Rnum1 = table2.Rows[0]["Rnum1"].ToString();
            this.Rnum2 = table2.Rows[0]["Rnum2"].ToString();
            this.Rnum3 = table2.Rows[0]["Rnum3"].ToString();
            this.txJob = table2.Rows[0]["Param5"].ToString();
            int num2 = table2.Rows.Count - 1;
            DataRow row = table2.Rows[num2];
            this.paid = row["Wpaid"].ToString();
            this.txMm1 = row["NDayMM"].ToString();
            this.txDd1 = row["NDayDD"].ToString();
            this.txYy1 = row["NDayYY"].ToString();
            this.loanPurpose = row["LoanPurpose"].ToString();
            this.houseInfo = string.Format("{0} {1}", row["HousePaymentValue"].ToString(), EnumsOP.GetHousePaymentCircleLiteral(row["HousePaymentCircle"]));
            this.otherLenderInfo = string.Format("{0} {1}", row["OtherLenderValue"].ToString(), EnumsOP.GetOtherLenderCircleLiteral(row["OtherLenderCircle"]));
            if (row["OtherSamllCreditHas"] != null)
            {
                try
                {
                    if (int.Parse(row["OtherSamllCreditHas"].ToString()) == 1)
                    {
                        this.otherSmallCreditHas = "Y";
                    }
                    else
                    {
                        this.otherSmallCreditHas = "N";
                    }
                }
                catch
                {
                }
            }
            if (row["OtherSmallCreditCount"] != null)
            {
                try
                {
                    switch (int.Parse(row["OtherSmallCreditCount"].ToString()))
                    {
                        case 0:
                            this.otherSmallCreditCount = "0";
                            goto Label_07FB;

                        case 1:
                            this.otherSmallCreditCount = "1";
                            goto Label_07FB;

                        case 2:
                            this.otherSmallCreditCount = "2";
                            goto Label_07FB;

                        case 3:
                            this.otherSmallCreditCount = "3";
                            goto Label_07FB;
                    }
                    this.otherSmallCreditCount = "more than 3";
                }
                catch
                {
                }
            }
        Label_07FB:
            if (row["IsGrossIncomeChange"] != null)
            {
                try
                {
                    if (int.Parse(row["IsGrossIncomeChange"].ToString()) == 1)
                    {
                        this.IsGrossIncomeChange = "Y";
                    }
                    else
                    {
                        this.IsGrossIncomeChange = "N";
                    }
                }
                catch
                {
                }
            }
            if (row["IsPayOtherCredit"] != null)
            {
                try
                {
                    if (int.Parse(row["IsPayOtherCredit"].ToString()) == 1)
                    {
                        this.IsPayOtherCredit = "Y";
                    }
                    else
                    {
                        this.IsPayOtherCredit = "N";
                    }
                }
                catch
                {
                }
            }
            if (row["GrossIncomeChangeValue"] != null)
            {
                this.GrossIncomeChangeValue = row["GrossIncomeChangeValue"].ToString();
            }
            if (row["PayOtherCreditValue"] != null)
            {
                this.PayOtherCreditValue = row["PayOtherCreditValue"].ToString();
            }
            if (this.IsEmployed.Equals("1"))
            {
                this.tip1 = "Your Occupation:";
                this.tip2 = "Employer:";
                this.tip3 = "Employer’s Address:";
                this.tip4 = "Employer Phone:";
                this.tip5 = "Time Employed: ";
                this.tip6 = "Net Income: ";
                this.tip7 = "JobTitle: ";
            }
            else
            {
                this.tip1 = "";
                this.tip2 = "Type of benefit:";
                this.tip3 = "Centreline Office:";
                this.tip4 = "Contact Name:";
                this.tip5 = "How long on this benefit: ";
                this.tip6 = "Benefit:";
            }
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            HuiyuanBN nbn = new HuiyuanBN(this.Page);
            HuiyuanDT dt = nbn.Get(Convert.ToInt32(this.Hidden1.Value));
            dt.IsValid = 1;
            nbn.Edit(dt);
            base.Response.Write("<script>alert('Success!');window.location='MemberList.aspx';</script>");
        }

        private void Submit2_ServerClick(object sender, EventArgs e)
        {
            HuiyuanBN nbn = new HuiyuanBN(this.Page);
            HuiyuanDT dt = nbn.Get(Convert.ToInt32(this.Hidden1.Value));
            dt.IsValid = 0;
            nbn.Edit(dt);
            base.Response.Write("<script>alert('Success!');window.location='MemberList.aspx';</script>");
        }

        private void Submit3_ServerClick(object sender, EventArgs e)
        {
            HuiyuanBN nbn = new HuiyuanBN(this.Page);
            HuiyuanDT dt = nbn.Get(Convert.ToInt32(this.Hidden1.Value));
            dt.IsValid = 2;
            nbn.Edit(dt);
            base.Response.Write("<script>alert('Success!');window.location='MemberList.aspx';</script>");
        }
    }
}

