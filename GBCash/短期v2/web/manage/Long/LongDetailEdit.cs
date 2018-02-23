namespace YingNet.WeiXing.WebApp.manage.Long
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Database;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.Business.CommonLogic;
    using YingNet.WeiXing.STRUCTURE;
    using YingNet.WeiXing.WebApp.Include;

    public class LongDetailEdit : Page
    {
        protected Button Calculate;
        protected TrueFalseDropDownList ddlexisting;
        protected CircleDropDownList ddlHousePaymentCircle;
        protected CircleDropDownList ddlOtherLenderCircle;
        protected PerDropDownList ddlPer;
        protected Button SaveButton;
        protected HtmlTable tbUnit;
        protected TextBox TextBox1;
        protected TextBox Textbox29;
        protected TextBox txtAddress;
        protected TextBox txtAname;
        protected TextBox txtAnumber;
        protected TextBox txtareatel;
        protected TextBox txtBank;
        protected TextBox txtbirthDD;
        protected TextBox txtbirthMM;
        protected TextBox txtbirthYYYY;
        protected TextBox txtborrow;
        protected TextBox txtBranch;
        protected TextBox txtBsb;
        protected TextBox txtdlestatus;
        protected TextBox txtdlexisting;
        protected TextBox txtdlgender;
        protected TextBox txtdlmastatus;
        protected TextBox txtdlrestatus;
        protected TextBox txtdlterms;
        protected TextBox txtdltitle;
        protected TextBox txtEmail;
        protected TextBox txtEmployer;
        protected TextBox txtfname;
        protected TextBox txthometel;
        protected HtmlInputText txtHousePaymentValue;
        protected TextBox txtIncome;
        protected TextBox txtJob;
        protected TextBox txtlandlord;
        protected TextBox txtlnumber;
        protected TextBox txtlstate;
        protected TextBox txtmethods;
        protected TextBox txtmname;
        protected TextBox txtmobiletel;
        protected TextBox txtnpaydayDD;
        protected TextBox txtnpaydayMM;
        protected TextBox txtnpaydayYYYY;
        protected HtmlInputText txtOtherLenderValue;
        protected TextBox txtPhone;
        protected TextBox txtPost;
        protected TextBox txtpurpose;
        protected TextBox txtrefnumber;
        protected TextBox txtReName1;
        protected TextBox txtReName2;
        protected TextBox txtReName3;
        protected TextBox txtReNum1;
        protected TextBox txtReNum2;
        protected TextBox txtReNum3;
        protected TextBox txtselReShip1;
        protected TextBox txtselReShip2;
        protected TextBox txtselReShip3;
        protected TextBox txtsname;
        protected TextBox txtState;
        protected TextBox txtstimeaddress1Month;
        protected TextBox txtstimeaddress1Year;
        protected TextBox txtStreet;
        protected TextBox txtstxPost1;
        protected TextBox txtstxState1;
        protected TextBox txtstxStreet1;
        protected TextBox txtstxSuburb1;
        protected TextBox txtstxunitno1;
        protected TextBox txtSuburb;
        protected TextBox txttimeaddressMonth;
        protected TextBox txttimeaddressYear;
        protected TextBox txttimeemployedMonth;
        protected TextBox txttimeemployedYear;
        protected TextBox txtunitno;
        protected TextBox txtworktel;

        private void Calculate_Click(object sender, EventArgs e)
        {
            this.ViewState["ChangeSchedule"] = true;
            base.Response.Write("<script>alert('Payment Schedule has changed,please click SAVE button to save the information！');</script>");
        }

        private void InitializeComponent()
        {
            this.Calculate.Click += new EventHandler(this.Calculate_Click);
            this.SaveButton.Click += new EventHandler(this.SaveButton_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LoadInfo()
        {
            if (base.Request["sid"] != null)
            {
                this.TextBox1.Text = base.Request["sid"].ToString();
                int persid = Convert.ToInt32(this.TextBox1.Text);
                LiniloanBN nbn = new LiniloanBN(this.Page);
                nbn.QueryPersid(persid);
                DataTable list = nbn.GetList();
                if (list.Rows.Count > 0)
                {
                    this.ViewState["LIniLoan.SID"] = list.Rows[0]["sid"];
                    this.txtpurpose.Text = list.Rows[0]["PrimaryPurpose"].ToString();
                    this.txtborrow.Text = list.Rows[0]["Loan"].ToString();
                    this.txtdlterms.Text = list.Rows[0]["Term"].ToString();
                }
                LpersonBN nbn2 = new LpersonBN(this.Page);
                nbn2.Querysid(persid);
                DataTable table2 = nbn2.GetList();
                if (table2.Rows.Count > 0)
                {
                    this.ViewState["LPerson.SID"] = persid;
                    if (table2.Rows[0]["IsExist"].Equals(1))
                    {
                        this.ddlexisting.SelectedValue = "1";
                    }
                    else
                    {
                        this.ddlexisting.SelectedValue = "0";
                    }
                    this.txtrefnumber.Text = table2.Rows[0]["ReferenceNum"].ToString();
                    this.txtdltitle.Text = table2.Rows[0]["Title"].ToString();
                    this.txtfname.Text = table2.Rows[0]["Fname"].ToString();
                    this.txtmname.Text = table2.Rows[0]["Mname"].ToString();
                    this.txtsname.Text = table2.Rows[0]["Sname"].ToString();
                    this.txtdlgender.Text = table2.Rows[0]["Gender"].ToString();
                    try
                    {
                        string[] strArray = Convert.ToString(table2.Rows[0]["DBirth"]).Split(new char[] { '/', '-' });
                        this.txtbirthDD.Text = strArray[0].PadLeft(2, '0');
                        this.txtbirthMM.Text = strArray[1].PadLeft(2, '0');
                        this.txtbirthYYYY.Text = strArray[2].ToString();
                    }
                    catch
                    {
                    }
                    this.txthometel.Text = table2.Rows[0]["HTelnum"].ToString();
                    this.txtworktel.Text = table2.Rows[0]["WTelnum"].ToString();
                    this.txtmobiletel.Text = table2.Rows[0]["Mobile"].ToString();
                    this.txtEmail.Text = table2.Rows[0]["Email"].ToString();
                    this.txtlnumber.Text = table2.Rows[0]["LicNum"].ToString();
                    this.txtlstate.Text = table2.Rows[0]["LicState"].ToString();
                    this.txtdlmastatus.Text = table2.Rows[0]["MaritalStatus"].ToString();
                    this.txtReName1.Text = table2.Rows[0]["Rname1"].ToString();
                    this.txtselReShip1.Text = table2.Rows[0]["Rship1"].ToString();
                    this.txtReNum1.Text = table2.Rows[0]["Rnum1"].ToString();
                    this.txtReName2.Text = table2.Rows[0]["Rname2"].ToString();
                    this.txtselReShip2.Text = table2.Rows[0]["Rship2"].ToString();
                    this.txtReNum2.Text = table2.Rows[0]["Rnum2"].ToString();
                    this.txtReName3.Text = table2.Rows[0]["Rname3"].ToString();
                    this.txtselReShip3.Text = table2.Rows[0]["Rship3"].ToString();
                    this.txtReNum3.Text = table2.Rows[0]["Rnum3"].ToString();
                }
                LresidentBN tbn = new LresidentBN(this.Page);
                tbn.QueryLoanSid(persid);
                DataTable table3 = tbn.GetList();
                if (table3.Rows.Count > 0)
                {
                    this.ViewState["LResident.SID"] = table3.Rows[0]["sid"];
                    this.txtdlrestatus.Text = table3.Rows[0]["Status"].ToString();
                    this.txtunitno.Text = table3.Rows[0]["UnitNo"].ToString();
                    this.txtStreet.Text = table3.Rows[0]["StreetNum"].ToString();
                    this.txtSuburb.Text = table3.Rows[0]["Suburb"].ToString();
                    this.txtState.Text = table3.Rows[0]["State"].ToString();
                    this.txtPost.Text = table3.Rows[0]["Postcode"].ToString();
                    this.txttimeaddressYear.Text = table3.Rows[0]["TimeYears"].ToString();
                    this.txttimeaddressMonth.Text = table3.Rows[0]["TimeMonths"].ToString();
                    this.txtlandlord.Text = table3.Rows[0]["NameAgent"].ToString();
                    this.txtareatel.Text = table3.Rows[0]["TelArea"].ToString();
                    this.txtstxunitno1.Text = table3.Rows[0]["UnitNo1"].ToString();
                    this.txtstxStreet1.Text = table3.Rows[0]["StreetNum1"].ToString();
                    this.txtstxSuburb1.Text = table3.Rows[0]["Suburb1"].ToString();
                    this.txtstxState1.Text = table3.Rows[0]["State1"].ToString();
                    this.txtstxPost1.Text = table3.Rows[0]["Postcode1"].ToString();
                    this.txtstimeaddress1Year.Text = table3.Rows[0]["TimeYears1"].ToString();
                    this.txtstimeaddress1Month.Text = table3.Rows[0]["TimeMonths1"].ToString();
                }
                LemploymentBN tbn2 = new LemploymentBN(this.Page);
                tbn2.QueryLoanSid(persid);
                DataTable table4 = tbn2.GetList();
                if (table4.Rows.Count > 0)
                {
                    this.ViewState["LEmployment.SID"] = table4.Rows[0]["sid"];
                    this.txtEmployer.Text = table4.Rows[0]["EName"].ToString();
                    this.txtAddress.Text = table4.Rows[0]["EAddress"].ToString();
                    this.txtPhone.Text = table4.Rows[0]["ECode"].ToString();
                    this.txtdlestatus.Text = table4.Rows[0]["EStatus"].ToString();
                    this.txtJob.Text = table4.Rows[0]["JobTitle"].ToString();
                    this.txttimeemployedYear.Text = table4.Rows[0]["TimeYears"].ToString();
                    this.txttimeemployedMonth.Text = table4.Rows[0]["TimeMonths"].ToString();
                    this.txtIncome.Text = table4.Rows[0]["TakePay"].ToString();
                    try
                    {
                        this.ddlPer.SelectedValue = table4.Rows[0]["Per"].ToString();
                    }
                    catch
                    {
                    }
                    this.txtnpaydayDD.Text = Convert.ToString(table4.Rows[0]["NextDay"]).PadLeft(2, '0');
                    this.txtnpaydayMM.Text = Convert.ToString(table4.Rows[0]["NextMonth"]).PadLeft(2, '0');
                    this.txtnpaydayYYYY.Text = table4.Rows[0]["NextYear"].ToString();
                    this.txtHousePaymentValue.Value = table4.Rows[0]["HousePaymentValue"].ToString();
                    this.txtOtherLenderValue.Value = table4.Rows[0]["OtherLenderValue"].ToString();
                    this.ddlHousePaymentCircle.SelectedValue = EnumsOP.GetHousePaymentCircleLiteral(table4.Rows[0]["HousePaymentCircle"]);
                    this.ddlOtherLenderCircle.SelectedValue = EnumsOP.GetOtherLenderCircleLiteral(table4.Rows[0]["OtherLenderCircle"]);
                }
                LbankBN kbn = new LbankBN(this.Page);
                kbn.QueryLoanSid(persid);
                DataTable table5 = kbn.GetList();
                if (table5.Rows.Count > 0)
                {
                    this.ViewState["LBank.SID"] = table5.Rows[0]["sid"];
                    this.txtBank.Text = table5.Rows[0]["BankName"].ToString();
                    this.txtBranch.Text = table5.Rows[0]["Branch"].ToString();
                    this.txtAname.Text = table5.Rows[0]["AccountName"].ToString();
                    this.txtBsb.Text = table5.Rows[0]["Bsb"].ToString();
                    this.txtAnumber.Text = table5.Rows[0]["AccountNum"].ToString();
                    this.txtmethods.Text = table5.Rows[0]["PContact"].ToString();
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (!base.IsPostBack)
            {
                this.LoadInfo();
            }
        }

        private void SaveButton_Click(object sender, EventArgs e)
        {
            DBOperate oper = new SqlDBOperate(Config.DataSource);
            try
            {
                LiniloanDT detail = new LiniloanDT();
                LemploymentDT tdt = new LemploymentDT();
                LpersonDT ndt2 = new LpersonDT();
                if (oper.baseConnection.State == ConnectionState.Closed)
                {
                    oper.Open();
                }
                oper.BeginTran();
                if (this.ViewState["LIniLoan.SID"] != null)
                {
                    try
                    {
                        int sid = Convert.ToInt32(this.ViewState["LIniLoan.SID"]);
                        LiniloanBN nbn = new LiniloanBN(this.Page, oper);
                        detail = nbn.Get(sid);
                        detail.Loan = Convert.ToDouble(this.txtborrow.Text);
                        detail.PrimaryPurpose = this.txtpurpose.Text;
                        detail.Term = Convert.ToInt32(this.txtdlterms.Text);
                        nbn.Edit(detail);
                    }
                    catch
                    {
                    }
                }
                if (this.ViewState["LPerson.SID"] != null)
                {
                    try
                    {
                        int num2 = Convert.ToInt32(this.ViewState["LPerson.SID"]);
                        LpersonBN nbn2 = new LpersonBN(this.Page, oper);
                        ndt2 = nbn2.Get(num2);
                        try
                        {
                            ndt2.IsExist = Convert.ToInt32(this.ddlexisting.SelectedValue);
                        }
                        catch
                        {
                        }
                        ndt2.ReferenceNum = this.txtrefnumber.Text;
                        ndt2.Title = this.txtdltitle.Text;
                        ndt2.Fname = this.txtfname.Text;
                        ndt2.Mname = this.txtmname.Text;
                        ndt2.Sname = this.txtsname.Text;
                        ndt2.Gender = this.txtdlgender.Text;
                        try
                        {
                            int num3 = Convert.ToInt32(this.txtbirthDD.Text);
                            int num4 = Convert.ToInt32(this.txtbirthMM.Text);
                            int num5 = Convert.ToInt32(this.txtbirthYYYY.Text);
                            ndt2.DBirth = num3.ToString("00") + "/" + num4.ToString("00") + "/" + num5.ToString("0000");
                        }
                        catch
                        {
                        }
                        ndt2.HTelnum = this.txthometel.Text;
                        ndt2.WTelcode = this.txtworktel.Text;
                        ndt2.Mobile = this.txtmobiletel.Text;
                        ndt2.Email = this.txtEmail.Text;
                        ndt2.LicNum = this.txtlnumber.Text;
                        ndt2.LicState = this.txtlstate.Text;
                        ndt2.MaritalStatus = this.txtdlmastatus.Text;
                        ndt2.Rname1 = this.txtReName1.Text;
                        ndt2.Rship1 = this.txtselReShip1.Text;
                        ndt2.Rnum1 = this.txtReNum1.Text;
                        ndt2.Rname2 = this.txtReName2.Text;
                        ndt2.Rship2 = this.txtselReShip2.Text;
                        ndt2.Rnum2 = this.txtReNum2.Text;
                        ndt2.Rname3 = this.txtReName3.Text;
                        ndt2.Rship3 = this.txtselReShip3.Text;
                        ndt2.Rnum3 = this.txtReNum3.Text;
                        nbn2.Edit(ndt2);
                    }
                    catch
                    {
                    }
                }
                if (this.ViewState["LResident.SID"] != null)
                {
                    try
                    {
                        int num6 = Convert.ToInt32(this.ViewState["LResident.SID"]);
                        LresidentBN tbn = new LresidentBN(this.Page, oper);
                        LresidentDT tdt2 = tbn.Get(num6);
                        tdt2.Status = this.txtdlrestatus.Text;
                        tdt2.UnitNo = this.txtunitno.Text;
                        tdt2.StreetNum = this.txtStreet.Text;
                        tdt2.Suburb = this.txtSuburb.Text;
                        tdt2.State = this.txtState.Text;
                        tdt2.Postcode = this.txtPost.Text;
                        tdt2.TimeYears = this.txttimeaddressYear.Text;
                        tdt2.TimeMonths = this.txttimeaddressMonth.Text;
                        tdt2.NameAgent = this.txtlandlord.Text;
                        tdt2.TelArea = this.txtareatel.Text;
                        tdt2.UnitNo1 = this.txtstxunitno1.Text;
                        tdt2.StreetNum1 = this.txtstxStreet1.Text;
                        tdt2.Suburb1 = this.txtstxSuburb1.Text;
                        tdt2.State1 = this.txtstxState1.Text;
                        tdt2.Postcode1 = this.txtstxPost1.Text;
                        tdt2.TimeYears1 = this.txtstimeaddress1Year.Text;
                        tdt2.TimeMonths1 = this.txtstimeaddress1Month.Text;
                        tbn.Edit(tdt2);
                    }
                    catch
                    {
                    }
                }
                if (this.ViewState["LEmployment.SID"] != null)
                {
                    try
                    {
                        int num7 = Convert.ToInt32(this.ViewState["LEmployment.SID"]);
                        LemploymentBN tbn2 = new LemploymentBN(this.Page, oper);
                        tdt = tbn2.Get(num7);
                        tdt.EName = this.txtEmployer.Text;
                        tdt.EAddress = this.txtAddress.Text;
                        tdt.ECode = this.txtPhone.Text;
                        tdt.EStatus = this.txtdlestatus.Text;
                        tdt.JobTitle = this.txtJob.Text;
                        try
                        {
                            tdt.TimeYears = Convert.ToInt32(this.txttimeemployedYear.Text);
                            tdt.TimeMonths = Convert.ToInt32(this.txttimeemployedMonth.Text);
                        }
                        catch
                        {
                        }
                        try
                        {
                            tdt.TakePay = Convert.ToDouble(this.txtIncome.Text);
                        }
                        catch
                        {
                        }
                        try
                        {
                            tdt.Per = Convert.ToInt32(this.ddlPer.SelectedValue);
                        }
                        catch
                        {
                        }
                        try
                        {
                            tdt.NextDay = Convert.ToInt32(this.txtnpaydayDD.Text);
                            tdt.NextMonth = Convert.ToInt32(this.txtnpaydayMM.Text);
                            tdt.NextYear = Convert.ToInt32(this.txtnpaydayYYYY.Text);
                        }
                        catch
                        {
                        }
                        tdt.HousePaymentCircle = EnumsOP.GetHousePaymentCircleByLiteral(this.ddlHousePaymentCircle.SelectedValue);
                        tdt.OtherLenderCircle = EnumsOP.GetOtherLenderCircleByLiteral(this.ddlOtherLenderCircle.SelectedValue);
                        try
                        {
                            tdt.HousePaymentValue = Convert.ToSingle(this.txtHousePaymentValue.Value);
                            tdt.OtherLenderValue = Convert.ToSingle(this.txtOtherLenderValue.Value);
                        }
                        catch
                        {
                        }
                        tbn2.Edit(tdt);
                    }
                    catch
                    {
                    }
                }
                if (this.ViewState["LBank.SID"] != null)
                {
                    try
                    {
                        LbankBN kbn = new LbankBN(this.Page, oper);
                        LbankDT kdt = kbn.Get(Convert.ToInt32(this.ViewState["LBank.SID"]));
                        kdt.BankName = this.txtBank.Text;
                        kdt.Branch = this.txtBranch.Text;
                        kdt.AccountName = this.txtAname.Text;
                        kdt.Bsb = this.txtBsb.Text;
                        kdt.AccountNum = this.txtAnumber.Text;
                        kdt.PContact = this.txtmethods.Text;
                        kbn.Edit(kdt);
                    }
                    catch
                    {
                    }
                }
                bool flag = false;
                if (this.ViewState["ChangeSchedule"] != null)
                {
                    try
                    {
                        flag = Convert.ToBoolean(this.ViewState["ChangeSchedule"]);
                    }
                    catch
                    {
                    }
                }
                if (flag && (this.ViewState["LPerson.SID"] != null))
                {
                    try
                    {
                        int personID = Convert.ToInt32(this.ViewState["LPerson.SID"]);
                        LongTermSchedule.DeleteSchedules(personID);
                        DateTime payDate = new DateTime(tdt.NextYear, tdt.NextMonth, tdt.NextDay);
                        DateTime minValue = DateTime.MinValue;
                        if ((detail.Other1 != null) && (detail.Other1 != string.Empty))
                        {
                            try
                            {
                                minValue = Convert.ToDateTime(detail.Other1);
                            }
                            catch
                            {
                            }
                        }
                        else
                        {
                            minValue = ndt2.RegTime;
                        }
                        LongTermSchedule.AddSchedules(personID.ToString(), payDate, detail.Term, tdt.Per.ToString(), (float) detail.Loan, tdt.FollowDay, tdt.FollowMonth, tdt.FollowYear, minValue);
                    }
                    catch
                    {
                    }
                }
                oper.CommitTran();
            }
            catch
            {
                oper.RollBackTran();
            }
            finally
            {
                oper.Close();
                oper.Dispose();
            }
            base.Response.Write("<script>alert('Success！');window.location='LongList.aspx';</script>");
        }
    }
}

