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

    public class detail : generagepage
    {
        public string customno = "";
        protected CircleDropDownList ddlHousePaymentCircle;
        protected CircleDropDownList ddlOtherLenderCircle;
        protected DropDownList dlTitle;
        protected HtmlForm Form1;
        protected HtmlInputHidden Hidden1;
        protected HtmlInputHidden Hidden2;
        protected Panel Panel1;
        protected Panel Panel2;
        protected RadioButtonList RadioButtonList1;
        protected RadioButtonList RadioButtonList2;
        protected RadioButtonList RadioButtonList3;
        protected HtmlInputButton Save1;
        protected HtmlSelect Select1;
        protected HtmlSelect Select2;
        protected HtmlSelect selState;
        protected HtmlInputButton Submit1;
        protected HtmlInputText txAddress;
        protected HtmlInputText txBenefit;
        protected HtmlInputText txCity;
        protected HtmlInputText txContact;
        protected HtmlInputText txDate;
        protected HtmlInputText txDd1;
        protected HtmlInputText txDd4;
        protected HtmlInputText txDriver;
        protected HtmlInputText txEmail;
        protected HtmlInputText txEmployer;
        protected HtmlInputText txFax;
        protected HtmlInputText txFname;
        protected HtmlInputText txIncome;
        protected HtmlInputText txIssue;
        protected HtmlInputText txJob;
        protected HtmlInputText txLname;
        protected HtmlInputText txMm1;
        protected HtmlInputText txMm4;
        protected HtmlInputText txMname;
        protected HtmlInputText txMobile;
        protected HtmlSelect txMonth;
        protected HtmlSelect txMonth2;
        protected HtmlInputText txNo;
        protected HtmlInputText txOffice;
        protected HtmlInputText txPhone;
        protected HtmlInputText txPost;
        protected HtmlInputText txResident;
        protected HtmlInputText txStreet;
        protected HtmlInputText txTel;
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
                this.Select1.Value = list.Rows[0]["TYears"].ToString();
                this.Select2.Value = list.Rows[0]["TMonths"].ToString();
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
                this.txYear2.Value = list.Rows[0]["TYears"].ToString();
                this.txMonth2.Value = list.Rows[0]["TMonths"].ToString();
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
                ddt.TYears = Convert.ToInt32(this.Select1.Value);
                ddt.TMonths = Convert.ToInt32(this.Select2.Value);
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
        }

        private void InitializeComponent()
        {
            this.RadioButtonList1.SelectedIndexChanged += new EventHandler(this.RadioButtonList1_SelectedIndexChanged);
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
            if (!this.Page.IsPostBack)
            {
                HuiyuanBN nbn = new HuiyuanBN(this.Page);
                this.Hidden1.Value = base.HuiSid;
                nbn.QuerySid(this.Hidden1.Value);
                DataTable list = nbn.GetList();
                if ((list.Rows[0]["Param2"] != null) && (list.Rows[0]["Param2"].ToString() != ""))
                {
                    for (int i = 0; i < this.dlTitle.Items.Count; i++)
                    {
                        if (this.dlTitle.Items[i].Value == list.Rows[0]["Param2"].ToString())
                        {
                            this.dlTitle.SelectedValue = list.Rows[0]["Param2"].ToString();
                            break;
                        }
                    }
                }
                this.txFname.Value = list.Rows[0]["Fname"].ToString();
                this.txLname.Value = list.Rows[0]["Lname"].ToString();
                this.txMname.Value = list.Rows[0]["Mname"].ToString();
                this.txDate.Value = Convert.ToDateTime(list.Rows[0]["DBirth"]).Day.ToString() + "/" + Convert.ToDateTime(list.Rows[0]["DBirth"]).Month.ToString() + "/" + Convert.ToDateTime(list.Rows[0]["DBirth"]).Year.ToString();
                this.txEmail.Value = list.Rows[0]["Email"].ToString();
                this.txIssue.Value = list.Rows[0]["Issued"].ToString();
                this.txDriver.Value = list.Rows[0]["DNumber"].ToString();
                this.txResident.Value = list.Rows[0]["RAddress"].ToString();
                this.txStreet.Value = list.Rows[0]["SAddress"].ToString();
                this.txCity.Value = list.Rows[0]["City"].ToString();
                this.selState.Value = list.Rows[0]["State"].ToString();
                this.txPost.Value = list.Rows[0]["Postcode"].ToString();
                this.txYear.Value = list.Rows[0]["TYears"].ToString();
                this.txMonth.Value = list.Rows[0]["TMonths"].ToString();
                this.txTel.Value = list.Rows[0]["HTel"].ToString();
                this.txMobile.Value = list.Rows[0]["Mobile"].ToString();
                this.txFax.Value = list.Rows[0]["Param1"].ToString();
                this.txNo.Value = list.Rows[0]["id"].ToString();
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

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            HuiyuanBN nbn = new HuiyuanBN(this.Page);
            HuiyuanDT dt = nbn.Get(Convert.ToInt32(this.Hidden1.Value));
            HuibackupBN pbn = new HuibackupBN(this.Page);
            HuibackupDT pdt = new HuibackupDT();
            pdt.Param2 = this.dlTitle.SelectedValue;
            pdt.Username = dt.Username;
            pdt.Fname = dt.Fname;
            pdt.Lname = dt.Lname;
            pdt.Mname = dt.Mname;
            pdt.DBirth = dt.DBirth;
            pdt.Email = dt.Email;
            pdt.Issued = dt.Issued;
            pdt.DNumber = dt.DNumber;
            pdt.RAddress = dt.RAddress;
            pdt.SAddress = dt.SAddress;
            pdt.City = dt.City;
            pdt.State = dt.State;
            pdt.Postcode = dt.Postcode;
            pdt.TYears = dt.TYears;
            pdt.TMonths = dt.TMonths;
            pdt.HTel = dt.HTel;
            pdt.Mobile = dt.Mobile;
            pdt.Param1 = dt.Param1;
            pdt.Modtime = SafeDateTime.LocalNow;
            pbn.Add(pdt);
            InfoBN obn = new InfoBN(this.Page);
            InfoDT odt = new InfoDT();
            odt.huiSid = Convert.ToInt32(this.Hidden1.Value);
            odt.Username = dt.Username;
            odt.type = "1";
            odt.regtime = SafeDateTime.LocalNow;
            odt.isvalid = 1;
            obn.Add(odt);
            dt.Param2 = this.dlTitle.SelectedValue;
            dt.Fname = this.txFname.Value;
            dt.Lname = this.txLname.Value;
            dt.Mname = this.txMname.Value;
            dt.Email = this.txEmail.Value;
            dt.Issued = this.txIssue.Value;
            dt.DNumber = this.txDriver.Value;
            dt.RAddress = this.txResident.Value;
            dt.SAddress = this.txStreet.Value;
            dt.City = this.txCity.Value;
            dt.State = this.selState.Value;
            dt.Postcode = this.txPost.Value;
            dt.TYears = Convert.ToInt32(this.txYear.Value);
            dt.TMonths = Convert.ToInt32(this.txMonth.Value);
            dt.HTel = this.txTel.Value;
            dt.Mobile = this.txMobile.Value;
            dt.Param1 = this.txFax.Value;
            nbn.Edit(dt);
            this.getInfo();
            base.Response.Write("<script>window.alert('Register Success!');window.location='detail1.aspx';</script>");
        }
    }
}

