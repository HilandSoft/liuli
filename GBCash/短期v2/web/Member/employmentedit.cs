namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;
    using YingNet.WeiXing.STRUCTURE;
    using YingNet.WeiXing.WebApp.Include;

    public class employmentedit : generagepage
    {
        protected CircleDropDownList ddlHousePaymentCircle;
        protected CircleDropDownList ddlOtherLenderCircle;
        protected HtmlInputHidden Hidden1;
        protected Panel Panel1;
        protected Panel Panel2;
        protected Panel Panel3;
        protected RadioButtonList RadioButtonList1;
        protected RadioButtonList RadioButtonList2;
        protected RadioButtonList RadioButtonList3;
        protected HtmlInputButton Save1;
        protected HtmlInputButton Save2;
        protected HtmlInputText txAddress;
        protected HtmlInputText txBenefit;
        protected HtmlInputText txContact;
        protected HtmlInputText txDd1;
        protected HtmlInputText txDd4;
        protected HtmlInputText txEmployer;
        protected HtmlInputText txIncome;
        protected HtmlInputText txJob;
        protected HtmlInputText txMm1;
        protected HtmlInputText txMm4;
        protected HtmlSelect txMonth;
        protected HtmlSelect txMonth2;
        protected HtmlInputText txOffice;
        protected HtmlInputText txPhone;
        protected HtmlInputText txtHousePaymentValue;
        protected TextBox txtLoanPurpose;
        protected HtmlInputText txtOtherLenderValue;
        protected HtmlInputText txType;
        protected HtmlSelect txYear;
        protected HtmlSelect txYear2;
        protected HtmlInputText txYy1;
        protected HtmlInputText txYy4;

        public void FillInfo()
        {
            EmployedBN dbn = new EmployedBN(this.Page);
            this.Hidden1.Value = base.HuiSid;
            dbn.QueryhuiSid(this.Hidden1.Value);
            DataTable list = dbn.GetList();
            if (list.Rows[0]["IsEmployed"].ToString().Equals("1"))
            {
                this.RadioButtonList1.SelectedIndex = 0;
                this.Panel1.Visible = true;
                this.Panel2.Visible = false;
                this.txEmployer.Value = list.Rows[0]["Employer"].ToString();
                this.txAddress.Value = list.Rows[0]["EAddress"].ToString();
                this.txPhone.Value = list.Rows[0]["EPhone"].ToString();
                this.txJob.Value = list.Rows[0]["Param5"].ToString();
                this.txYear.Value = list.Rows[0]["TYears"].ToString();
                this.txMonth.Value = list.Rows[0]["TMonths"].ToString();
                this.txIncome.Value = Convert.ToSingle(list.Rows[0]["MIncome"]).ToString("0.00");
                int num = list.Rows.Count - 1;
                DataRow row = list.Rows[num];
                this.txMm1.Value = row["NDayMM"].ToString();
                this.txDd1.Value = row["NDayDD"].ToString();
                this.txYy1.Value = row["NDayYY"].ToString();
                this.txtLoanPurpose.Text = row["LoanPurpose"].ToString();
                this.txtHousePaymentValue.Value = row["HousePaymentValue"].ToString();
                this.txtOtherLenderValue.Value = row["OtherLenderValue"].ToString();
                this.ddlHousePaymentCircle.SelectedValue = EnumsOP.GetHousePaymentCircleLiteral(row["HousePaymentCircle"]);
                this.ddlOtherLenderCircle.SelectedValue = EnumsOP.GetOtherLenderCircleLiteral(row["OtherLenderCircle"]);
                switch (list.Rows[0]["Wpaid"].ToString())
                {
                    case "Weekly":
                        this.RadioButtonList2.SelectedIndex = 0;
                        break;

                    case "F'nightly":
                        this.RadioButtonList2.SelectedIndex = 1;
                        break;

                    case "Monthly":
                        this.RadioButtonList2.SelectedIndex = 2;
                        break;
                }
            }
            else
            {
                this.RadioButtonList1.SelectedIndex = 1;
                this.Panel1.Visible = false;
                this.Panel2.Visible = true;
                this.txType.Value = list.Rows[0]["Employer"].ToString();
                this.txOffice.Value = list.Rows[0]["EAddress"].ToString();
                this.txContact.Value = list.Rows[0]["EPhone"].ToString();
                this.txYear.Value = list.Rows[0]["TYears"].ToString();
                this.txMonth.Value = list.Rows[0]["TMonths"].ToString();
                this.txBenefit.Value = Convert.ToSingle(list.Rows[0]["MIncome"]).ToString("0.00");
                int num2 = list.Rows.Count - 1;
                DataRow row2 = list.Rows[num2];
                this.txMm4.Value = row2["NDayMM"].ToString();
                this.txDd4.Value = row2["NDayDD"].ToString();
                this.txYy4.Value = row2["NDayYY"].ToString();
                this.txtLoanPurpose.Text = row2["LoanPurpose"].ToString();
                this.txtHousePaymentValue.Value = row2["HousePaymentValue"].ToString();
                this.txtOtherLenderValue.Value = row2["OtherLenderValue"].ToString();
                this.ddlHousePaymentCircle.SelectedValue = EnumsOP.GetHousePaymentCircleLiteral(row2["HousePaymentCircle"]);
                this.ddlOtherLenderCircle.SelectedValue = EnumsOP.GetOtherLenderCircleLiteral(row2["OtherLenderCircle"]);
                switch (list.Rows[0]["Wpaid"].ToString())
                {
                    case "Weekly":
                        this.RadioButtonList3.SelectedIndex = 0;
                        break;

                    case "F'nightly":
                        this.RadioButtonList3.SelectedIndex = 1;
                        break;

                    case "Monthly":
                        this.RadioButtonList3.SelectedIndex = 2;
                        break;
                }
            }
        }

        public void getInfo()
        {
            DataTable list = new SystemInfoBN(this.Page).GetList();
            EmploybackupBN pbn = new EmploybackupBN(this.Page);
            EmploybackupDT dt = new EmploybackupDT();
            HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(Convert.ToInt32(this.Hidden1.Value));
            string username = ndt.Username;
            EmployedBN dbn = new EmployedBN(this.Page);
            dbn.QueryhuiSid(this.Hidden1.Value);
            DataTable table2 = dbn.GetList();
            int id = Convert.ToInt32(table2.Rows[0]["id"]);
            int num2 = Convert.ToInt32(table2.Rows[table2.Rows.Count - 1]["id"]);
            EmployedDT ddt = dbn.Get(id);
            EmployedDT ddt2 = dbn.Get(num2);
            InfoBN obn = new InfoBN(this.Page);
            InfoDT odt = new InfoDT();
            odt.huiSid = Convert.ToInt32(this.Hidden1.Value);
            odt.Username = ndt.Username;
            odt.type = "2";
            odt.regtime = SafeDateTime.LocalNow;
            odt.isvalid = 1;
            obn.Add(odt);
            dt.Employer = ddt.Employer;
            dt.EAddress = ddt.EAddress;
            dt.EPhone = ddt.EPhone;
            dt.TYears = ddt.TYears;
            dt.TMonths = ddt.TMonths;
            dt.MIncome = ddt.MIncome;
            dt.Wpaid = ddt.Wpaid;
            dt.NDayDD = ddt.NDayDD;
            dt.NDayMM = ddt.NDayMM;
            dt.NDayYY = ddt.NDayYY;
            dt.IsEmployed = ddt.IsEmployed;
            dt.Frequency = ddt.Frequency;
            dt.huiSid = ddt.huiSid;
            dt.ModTime = SafeDateTime.LocalNow;
            dt.huiName = username;
            if (this.RadioButtonList1.SelectedIndex == 0)
            {
                ddt.Employer = this.txEmployer.Value;
                ddt.EAddress = this.txAddress.Value;
                ddt.EPhone = this.txPhone.Value;
                ddt.TYears = Convert.ToInt32(this.txYear.Value);
                ddt.TMonths = Convert.ToInt32(this.txMonth.Value);
                ddt.MIncome = Convert.ToSingle(this.txIncome.Value);
                ddt.IsEmployed = 1;
                ddt.Param5 = this.txJob.Value;
                ddt2.Wpaid = this.RadioButtonList2.SelectedValue;
                ddt2.NDayMM = Convert.ToInt32(this.txMm1.Value);
                ddt2.NDayDD = Convert.ToInt32(this.txDd1.Value);
                ddt2.NDayYY = Convert.ToInt32(this.txYy1.Value);
                ddt2.LoanPurpose = this.txtLoanPurpose.Text;
                ddt2.HousePaymentCircle = EnumsOP.GetHousePaymentCircleByLiteral(this.ddlHousePaymentCircle.SelectedValue);
                ddt2.OtherLenderCircle = EnumsOP.GetOtherLenderCircleByLiteral(this.ddlOtherLenderCircle.SelectedValue);
                try
                {
                    ddt2.HousePaymentValue = Convert.ToSingle(this.txtHousePaymentValue.Value);
                    ddt2.OtherLenderValue = Convert.ToSingle(this.txtOtherLenderValue.Value);
                }
                catch
                {
                }
                switch (this.RadioButtonList2.SelectedIndex)
                {
                    case 0:
                        ddt2.Frequency = 7.0;
                        break;

                    case 1:
                        ddt2.Frequency = 14.0;
                        break;

                    case 2:
                        ddt2.Frequency = Convert.ToSingle(list.Rows[0]["frequency"].ToString());
                        break;
                }
            }
            else
            {
                ddt.Employer = this.txType.Value;
                ddt.EAddress = this.txOffice.Value;
                ddt.EPhone = this.txContact.Value;
                ddt.TYears = Convert.ToInt32(this.txYear2.Value);
                ddt.TMonths = Convert.ToInt32(this.txMonth2.Value);
                ddt.MIncome = Convert.ToSingle(this.txBenefit.Value);
                ddt.IsEmployed = 0;
                ddt.Wpaid = this.RadioButtonList3.SelectedValue;
                ddt.NDayMM = Convert.ToInt32(this.txMm4.Value);
                ddt.NDayDD = Convert.ToInt32(this.txDd4.Value);
                ddt.NDayYY = Convert.ToInt32(this.txYy4.Value);
                switch (this.RadioButtonList3.SelectedIndex)
                {
                    case 0:
                        ddt.Frequency = 7.0;
                        break;

                    case 1:
                        ddt.Frequency = 14.0;
                        break;

                    case 2:
                        ddt.Frequency = Convert.ToSingle(list.Rows[0]["frequency"].ToString());
                        break;
                }
            }
            dbn.Edit(ddt2);
            dbn.Edit(ddt);
            pbn.Add(dt);
            if (base.Request["Type"].ToString().Equals("1"))
            {
                base.Response.Write("<script>window.alert('Success!');window.location='newloan.aspx';</script>");
            }
            else
            {
                base.Response.Write("<script>window.alert('Success!');window.location='EmployDetail.aspx';</script>");
            }
        }

        private void InitializeComponent()
        {
            this.RadioButtonList1.SelectedIndexChanged += new EventHandler(this.RadioButtonList1_SelectedIndexChanged);
            this.Save1.ServerClick += new EventHandler(this.Save1_ServerClick);
            this.Save2.ServerClick += new EventHandler(this.Save2_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.Save1.Attributes.Add("onclick", "return CheckFeedback1()");
            this.Save2.Attributes.Add("onclick", "return CheckFeedback2()");
            if (!this.Page.IsPostBack)
            {
                this.FillInfo();
            }
        }

        private void RadioButtonList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.RadioButtonList1.SelectedIndex == 0)
            {
                this.Panel1.Visible = true;
                this.Panel2.Visible = false;
            }
            else
            {
                this.Panel1.Visible = false;
                this.Panel2.Visible = true;
            }
        }

        private void Save1_ServerClick(object sender, EventArgs e)
        {
            this.getInfo();
        }

        private void Save2_ServerClick(object sender, EventArgs e)
        {
            this.getInfo();
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            this.getInfo();
        }
    }
}

