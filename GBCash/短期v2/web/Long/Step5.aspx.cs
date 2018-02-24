namespace YingNet.WeiXing.WebApp.Long
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.STRUCTURE;
    using YingNet.WeiXing.WebApp.Include;

    public class Step5 : LongParent
    {
        protected Button bnApption;
        protected HtmlInputButton bnBank;
        protected HtmlInputButton bnEdit1;
        protected HtmlInputButton bnEdit2;
        protected HtmlInputButton bnEdit3;
        protected HtmlInputButton bnEdit4;
        protected HtmlInputButton bnEmploy;
        protected HtmlInputButton bnInit;
        protected CircleDropDownList ddlHousePaymentCircle;
        protected CircleDropDownList ddlOtherLenderCircle;
        protected HtmlSelect dlestatus;
        protected HtmlSelect dlexisting;
        protected HtmlSelect dlgender;
        protected HtmlSelect dlmastatus;
        protected DropDownList dlrestatus;
        protected HtmlSelect dlterms;
        protected HtmlSelect dltitle;
        protected DropDownList DropDownList1;
        protected HtmlInputHidden Hidden1;
        protected HtmlInputHidden Hidden2;
        protected HtmlInputHidden Hidden3;
        protected Label Label1;
        protected HtmlInputText mobiletel;
        protected Panel Panel1;
        protected Panel Panel2;
        protected Panel Panel3;
        protected Panel Panel4;
        protected Panel Panel5;
        protected Panel Panel6;
        protected Panel Panel7;
        protected Panel Panel8;
        protected Panel Panel9;
        protected RadioButtonList RadioButtonList1;
        protected RadioButtonList RadioButtonList2;
        public string sbirth = "";
        public string sdlestatus = "";
        public string sdlexisting = "";
        public string sdlgender = "";
        public string sdlmastatus = "";
        public string sdlrestatus = "";
        public string sdlterms = "";
        public string sdltitle = "";
        protected HtmlInputText selReShip1;
        protected HtmlInputText selReShip2;
        protected HtmlInputText selReShip3;
        public string sHousePaymentInfo = string.Empty;
        public string smethods = "";
        public string snpayday = "";
        public string sOtherLenderInfo = string.Empty;
        public string sPer = "";
        public string sPer2 = "";
        public string sselReShip1 = "";
        public string sselReShip2 = "";
        public string sselReShip3 = "";
        public string stimeaddress = "";
        public string stimeaddress1 = "";
        public string stimeemployed = "";
        public string stxAddress = "";
        public string stxAname = "";
        public string stxAnumber = "";
        public string stxareatel = "";
        public string stxBank = "";
        public string stxborrow = "";
        public string stxBranch = "";
        public string stxBsb = "";
        public string stxEmail = "";
        public string stxEmployer = "";
        public string stxfname = "";
        public string stxhometel = "";
        public string stxIncome = "";
        public string stxJob = "";
        public string stxlandlord = "";
        public string stxlnumber = "";
        public string stxlstate = "";
        public string stxmname = "";
        public string stxmobiletel = "";
        public string stxPhone = "";
        public string stxPost = "";
        public string stxPost1 = "";
        public string stxpurpose = "";
        public string stxrefnumber = "";
        public string stxReName1 = "";
        public string stxReName2 = "";
        public string stxReName3 = "";
        public string stxReNum1 = "";
        public string stxReNum2 = "";
        public string stxReNum3 = "";
        public string stxsname = "";
        public string stxState = "";
        public string stxState1 = "";
        public string stxStreet = "";
        public string stxStreet1 = "";
        public string stxSuburb = "";
        public string stxSuburb1 = "";
        public string stxunitno = "";
        public string stxunitno1 = "";
        public string stxworktel = "";
        protected HtmlInputButton Submit2;
        protected HtmlTable Table1;
        protected HtmlTable Table2;
        protected HtmlTable Table3;
        protected HtmlTable tbUnit;
        protected HtmlInputText txAddress;
        protected HtmlInputText txAname;
        protected HtmlInputText txAnumber;
        protected HtmlInputText txareatel;
        protected HtmlInputText txBank;
        protected TextBox txBankSid;
        protected HtmlInputText txborrow;
        protected HtmlInputText txBranch;
        protected HtmlInputText txBsb;
        protected HtmlInputText txCAnumber;
        protected HtmlInputText txDated;
        protected HtmlInputText txDatem;
        protected HtmlInputText txDatey;
        protected HtmlInputText txDd1;
        protected HtmlInputText txDd2;
        protected HtmlInputText txEmail;
        protected HtmlInputText txEmployer;
        protected TextBox txEmpSid;
        protected HtmlInputText txfname;
        protected HtmlInputText txhometel;
        protected HtmlInputText txIncome;
        protected HtmlInputText txJob;
        protected HtmlInputText txlandlord;
        protected HtmlInputText txlnumber;
        protected TextBox txLoanSid;
        protected HtmlInputText txlstate;
        protected HtmlInputText txMm1;
        protected HtmlInputText txMm2;
        protected HtmlInputText txmname;
        protected HtmlSelect txMonth;
        protected HtmlSelect txMonth1;
        protected HtmlSelect txMonthr;
        protected TextBox txPerSid;
        protected HtmlInputText txPhone;
        protected HtmlInputText txPost;
        protected HtmlInputText txPost1;
        protected HtmlTextArea txpurpose;
        protected HtmlInputText txrefnumber;
        protected HtmlInputText txReName1;
        protected HtmlInputText txReName2;
        protected HtmlInputText txReName3;
        protected HtmlInputText txReNum1;
        protected HtmlInputText txReNum2;
        protected HtmlInputText txReNum3;
        protected TextBox txReSid;
        protected HtmlInputText txsname;
        protected HtmlInputText txState;
        protected HtmlInputText txState1;
        protected HtmlInputText txStreet;
        protected HtmlInputText txStreet1;
        protected HtmlInputText txSuburb;
        protected HtmlInputText txSuburb1;
        protected HtmlInputText txtHousePaymentValue;
        protected HtmlInputText txtOtherLenderValue;
        protected HtmlInputText txunitno;
        protected HtmlInputText txUnitNo1;
        protected HtmlInputText txworktel;
        protected HtmlSelect txYear;
        protected HtmlSelect txYear1;
        protected HtmlInputText txYy1;
        protected HtmlInputText txYy2;

        private void bnApption_Click(object sender, EventArgs e)
        {
            double num = this.IsLimit() + 1.0;
            if (Convert.ToDouble(this.Hidden3.Value) > num)
            {
                base.Response.Write("<script>alert('Sorry, the loan amount has exceeded your borrowing limit, please use the link of \"Calculator\" to check your borrowing limit!');</script>");
            }
            else
            {
                base.Response.Write("<script>window.location='Step6.aspx?sid=" + Cipher.DesEncrypt(this.txPerSid.Text, "12345678") + "';</script>");
            }
        }

        private void bnBank_ServerClick(object sender, EventArgs e)
        {
            LbankBN kbn = new LbankBN(this.Page);
            LbankDT detail = kbn.Get(Convert.ToInt32(this.txBankSid.Text));
            detail.BankName = this.txBank.Value;
            detail.Branch = this.txBranch.Value;
            detail.AccountName = this.txAname.Value;
            detail.AccountNum = this.txAnumber.Value;
            detail.Bsb = this.txBsb.Value;
            detail.PContact = this.RadioButtonList1.SelectedValue;
            detail.LoanSid = Convert.ToInt32(this.txPerSid.Text);
            detail.Rname1 = "";
            detail.Rnum1 = "";
            detail.Rship1 = "";
            detail.Rname2 = "";
            detail.Rnum2 = "";
            detail.Rship2 = "";
            detail.Rname3 = "";
            detail.Rnum3 = "";
            detail.Rship3 = "";
            detail.Other1 = "";
            detail.Other2 = "";
            detail.Other3 = "";
            detail.Other4 = 0;
            detail.Other5 = 0;
            detail.Other6 = 0;
            if (kbn.Edit(detail))
            {
                base.Response.Write("<script>window.location='Step5.aspx?sid=" + Cipher.DesEncrypt(this.txPerSid.Text, "12345678") + "';</script>");
            }
            kbn.Close();
            kbn.Dispose();
        }

        private void bnEdit1_ServerClick(object sender, EventArgs e)
        {
            this.Panel1.Visible = this.Panel3.Visible = this.Panel4.Visible = this.Panel5.Visible = this.Panel6.Visible = this.Panel7.Visible = this.Panel8.Visible = false;
            this.Panel2.Visible = true;
        }

        private void bnEdit2_ServerClick(object sender, EventArgs e)
        {
            this.Panel1.Visible = this.Panel2.Visible = this.Panel3.Visible = this.Panel5.Visible = this.Panel6.Visible = this.Panel7.Visible = this.Panel8.Visible = false;
            this.Panel4.Visible = true;
            if (Convert.ToInt32(this.DropDownList1.SelectedValue) < 5)
            {
                this.Panel9.Visible = true;
            }
            else
            {
                this.Panel9.Visible = false;
            }
        }

        private void bnEdit3_ServerClick(object sender, EventArgs e)
        {
            this.Panel1.Visible = this.Panel2.Visible = this.Panel3.Visible = this.Panel4.Visible = this.Panel5.Visible = this.Panel7.Visible = this.Panel8.Visible = false;
            this.Panel6.Visible = true;
        }

        private void bnEdit4_ServerClick(object sender, EventArgs e)
        {
            this.Panel1.Visible = this.Panel2.Visible = this.Panel3.Visible = this.Panel4.Visible = this.Panel5.Visible = this.Panel6.Visible = this.Panel7.Visible = false;
            this.Panel8.Visible = true;
        }

        private void bnEmploy_ServerClick(object sender, EventArgs e)
        {
            LemploymentBN tbn = new LemploymentBN(this.Page);
            try
            {
                string selectedValue = this.RadioButtonList2.SelectedValue;
                DateTime time = new DateTime(Convert.ToInt32(this.txYy1.Value), Convert.ToInt32(this.txMm1.Value), Convert.ToInt32(this.txDd1.Value), 0x17, 0x3b, 0x3b);
                TimeSpan span = (TimeSpan) (time - SafeDateTime.LocalNow);
                if (time <= SafeDateTime.LocalNow)
                {
                    base.Response.Write("<script>alert('Please note that the next payday entered must be future date.');</script>");
                    this.Panel1.Visible = this.Panel2.Visible = this.Panel3.Visible = this.Panel4.Visible = this.Panel5.Visible = this.Panel7.Visible = this.Panel8.Visible = false;
                    this.Panel6.Visible = true;
                }
                else
                {
                    string str = selectedValue;
                    if (str != null)
                    {
                        str = string.IsInterned(str);
                        if (str == "0")
                        {
                            if (span.Days > 7)
                            {
                                base.Response.Write("<script>alert('Please note that the days to your next payday exceeded your pay interval, please adjust and continue.');</script>");
                                this.Panel1.Visible = this.Panel2.Visible = this.Panel3.Visible = this.Panel4.Visible = this.Panel5.Visible = this.Panel7.Visible = this.Panel8.Visible = false;
                                this.Panel6.Visible = true;
                                return;
                            }
                        }
                        else if (str == "1")
                        {
                            if (span.Days > 14)
                            {
                                base.Response.Write("<script>alert('Please note that the days to your next payday exceeded your pay interval, please adjust and continue.');</script>");
                                this.Panel1.Visible = this.Panel2.Visible = this.Panel3.Visible = this.Panel4.Visible = this.Panel5.Visible = this.Panel7.Visible = this.Panel8.Visible = false;
                                this.Panel6.Visible = true;
                                return;
                            }
                        }
                        else if (str == "2")
                        {
                            if (span.Days > 0x10)
                            {
                                base.Response.Write("<script>alert('Please note that the days to your next payday exceeded your pay interval, please adjust and continue.');</script>");
                                this.Panel1.Visible = this.Panel2.Visible = this.Panel3.Visible = this.Panel4.Visible = this.Panel5.Visible = this.Panel7.Visible = this.Panel8.Visible = false;
                                this.Panel6.Visible = true;
                                return;
                            }
                        }
                        else if ((str == "3") && (span.Days > 0x1f))
                        {
                            base.Response.Write("<script>alert('Please note that the days to your next payday exceeded your pay interval, please adjust and continue.');</script>");
                            this.Panel1.Visible = this.Panel2.Visible = this.Panel3.Visible = this.Panel4.Visible = this.Panel5.Visible = this.Panel7.Visible = this.Panel8.Visible = false;
                            this.Panel6.Visible = true;
                            return;
                        }
                    }
                    LemploymentDT detail = tbn.Get(Convert.ToInt32(this.txEmpSid.Text));
                    detail.EName = this.txEmployer.Value;
                    detail.EAddress = this.txAddress.Value;
                    detail.ECode = this.txPhone.Value;
                    detail.ENum = "";
                    detail.EStatus = this.dlestatus.Value;
                    detail.JobTitle = this.txJob.Value;
                    detail.TimeMonths = Convert.ToInt32(this.txMonth.Value);
                    detail.TimeYears = Convert.ToInt32(this.txYear.Value);
                    detail.TakePay = Convert.ToDouble(this.txIncome.Value);
                    detail.Per = Convert.ToInt32(this.RadioButtonList2.SelectedValue);
                    detail.NextDay = Convert.ToInt32(this.txDd1.Value);
                    detail.NextMonth = Convert.ToInt32(this.txMm1.Value);
                    detail.NextYear = Convert.ToInt32(this.txYy1.Value);
                    detail.LoanSid = Convert.ToInt32(this.txPerSid.Text);
                    detail.Other1 = "";
                    detail.Other2 = "";
                    detail.Other3 = "";
                    detail.Other4 = 0;
                    detail.Other5 = 0;
                    detail.Other6 = 0;
                    detail.HousePaymentCircle = EnumsOP.GetHousePaymentCircleByLiteral(this.ddlHousePaymentCircle.SelectedValue);
                    detail.OtherLenderCircle = EnumsOP.GetOtherLenderCircleByLiteral(this.ddlOtherLenderCircle.SelectedValue);
                    try
                    {
                        detail.HousePaymentValue = Convert.ToSingle(this.txtHousePaymentValue.Value);
                        detail.OtherLenderValue = Convert.ToSingle(this.txtOtherLenderValue.Value);
                    }
                    catch
                    {
                    }
                    if (this.RadioButtonList2.SelectedValue.Equals("2"))
                    {
                        detail.FollowDay = Convert.ToInt32(this.txDd2.Value);
                        detail.FollowMonth = Convert.ToInt32(this.txMm2.Value);
                        detail.FollowYear = Convert.ToInt32(this.txYy2.Value);
                    }
                    else
                    {
                        detail.FollowDay = detail.FollowMonth = detail.FollowYear = 0;
                    }
                    if (tbn.Edit(detail))
                    {
                        base.Response.Write("<script>window.location='Step5.aspx?sid=" + Cipher.DesEncrypt(this.txPerSid.Text, "12345678") + "';</script>");
                    }
                }
            }
            catch (Exception exception)
            {
                this.Label1.Text = exception.Message;
                this.Panel1.Visible = this.Panel2.Visible = this.Panel3.Visible = this.Panel4.Visible = this.Panel5.Visible = this.Panel7.Visible = this.Panel8.Visible = false;
                this.Panel6.Visible = true;
            }
            finally
            {
                tbn.Close();
                tbn.Dispose();
            }
        }

        private void bnInit_ServerClick(object sender, EventArgs e)
        {
            LiniloanBN nbn = new LiniloanBN(this.Page);
            try
            {
                LiniloanDT detail = new LiniloanDT();
                detail.sid = Convert.ToInt32(this.txLoanSid.Text);
                detail.PrimaryPurpose = this.txpurpose.Value;
                detail.Loan = Convert.ToDouble(this.txborrow.Value);
                detail.Term = Convert.ToInt32(this.dlterms.Value);
                if (nbn.Edit(detail))
                {
                    base.Response.Write("<script>window.location='Step5.aspx?sid=" + Cipher.DesEncrypt(this.txPerSid.Text, "12345678") + "';</script>");
                }
            }
            catch (Exception exception)
            {
                this.Label1.Text = exception.Message;
                this.Panel1.Visible = this.Panel3.Visible = this.Panel4.Visible = this.Panel5.Visible = this.Panel6.Visible = this.Panel7.Visible = this.Panel8.Visible = false;
                this.Panel2.Visible = true;
            }
            finally
            {
                nbn.Close();
                nbn.Dispose();
            }
        }

        private void dlrestatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Panel1.Visible = this.Panel2.Visible = this.Panel3.Visible = this.Panel5.Visible = this.Panel6.Visible = this.Panel7.Visible = this.Panel8.Visible = false;
            this.Panel4.Visible = true;
            if (Convert.ToInt32(this.DropDownList1.SelectedValue) < 5)
            {
                this.Panel9.Visible = true;
            }
            else
            {
                this.Panel9.Visible = false;
            }
            if (this.dlrestatus.SelectedValue.Equals("Renting"))
            {
                this.Table1.Visible = true;
            }
            else
            {
                this.Table1.Visible = false;
            }
        }

        private void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Panel1.Visible = this.Panel2.Visible = this.Panel3.Visible = this.Panel5.Visible = this.Panel6.Visible = this.Panel7.Visible = this.Panel8.Visible = false;
            this.Panel4.Visible = true;
            if (Convert.ToInt32(this.DropDownList1.SelectedValue) < 5)
            {
                this.Panel9.Visible = true;
            }
            else
            {
                this.Panel9.Visible = false;
            }
        }

        public void GetBank(string sid)
        {
            LbankBN kbn = new LbankBN(this.Page);
            kbn.QueryLoanSid(Convert.ToInt32(sid));
            DataTable list = kbn.GetList();
            kbn.Close();
            kbn.Dispose();
            if (list.Rows.Count > 0)
            {
                this.txBankSid.Text = list.Rows[0]["sid"].ToString();
                this.txBank.Value = list.Rows[0]["BankName"].ToString();
                this.txBranch.Value = list.Rows[0]["Branch"].ToString();
                this.txAname.Value = list.Rows[0]["AccountName"].ToString();
                this.txAnumber.Value = list.Rows[0]["AccountNum"].ToString();
                this.txCAnumber.Value = list.Rows[0]["AccountNum"].ToString();
                this.txBsb.Value = list.Rows[0]["Bsb"].ToString();
                this.RadioButtonList1.SelectedValue = list.Rows[0]["PContact"].ToString();
            }
        }

        public void GetEmployment(string sid)
        {
            LemploymentBN tbn = new LemploymentBN(this.Page);
            tbn.QueryLoanSid(Convert.ToInt32(sid));
            DataTable list = tbn.GetList();
            tbn.Close();
            tbn.Dispose();
            if (list.Rows.Count > 0)
            {
                this.txEmpSid.Text = list.Rows[0]["sid"].ToString();
                this.txEmployer.Value = list.Rows[0]["EName"].ToString();
                this.txAddress.Value = list.Rows[0]["EAddress"].ToString();
                this.txPhone.Value = list.Rows[0]["ECode"].ToString();
                this.dlestatus.Value = list.Rows[0]["EStatus"].ToString();
                this.txJob.Value = list.Rows[0]["JobTitle"].ToString();
                this.txMonth.Value = list.Rows[0]["TimeMonths"].ToString();
                this.txYear.Value = list.Rows[0]["TimeYears"].ToString();
                this.txIncome.Value = list.Rows[0]["TakePay"].ToString();
                this.RadioButtonList2.SelectedValue = list.Rows[0]["Per"].ToString();
                this.txDd1.Value = list.Rows[0]["NextDay"].ToString();
                this.txMm1.Value = list.Rows[0]["NextMonth"].ToString();
                this.txYy1.Value = list.Rows[0]["NextYear"].ToString();
                this.txDd2.Value = list.Rows[0]["FollowDay"].ToString();
                this.txMm2.Value = list.Rows[0]["FollowMonth"].ToString();
                this.txYy2.Value = list.Rows[0]["FollowYear"].ToString();
                this.txtHousePaymentValue.Value = list.Rows[0]["HousePaymentValue"].ToString();
                this.txtOtherLenderValue.Value = list.Rows[0]["OtherLenderValue"].ToString();
                this.ddlHousePaymentCircle.SelectedValue = EnumsOP.GetHousePaymentCircleLiteral(list.Rows[0]["HousePaymentCircle"]);
                this.ddlOtherLenderCircle.SelectedValue = EnumsOP.GetOtherLenderCircleLiteral(list.Rows[0]["OtherLenderCircle"]);
            }
        }

        public void GetInitLoan(string sid)
        {
            LiniloanBN nbn = new LiniloanBN(this.Page);
            nbn.QueryPersid(Convert.ToInt32(sid));
            DataTable list = nbn.GetList();
            nbn.Close();
            nbn.Dispose();
            if (list.Rows.Count > 0)
            {
                this.txpurpose.Value = list.Rows[0]["PrimaryPurpose"].ToString();
                this.txborrow.Value = list.Rows[0]["Loan"].ToString();
                this.dlterms.Value = list.Rows[0]["Term"].ToString();
                this.txLoanSid.Text = list.Rows[0]["sid"].ToString();
            }
        }

        public void GetPerson(string sid)
        {
            LpersonBN nbn = new LpersonBN(this.Page);
            nbn.Querysid(Convert.ToInt32(sid));
            DataTable list = nbn.GetList();
            nbn.Close();
            nbn.Dispose();
            if (list.Rows.Count > 0)
            {
                this.txPerSid.Text = list.Rows[0]["sid"].ToString();
                this.dlexisting.Value = list.Rows[0]["IsExist"].ToString();
                this.txrefnumber.Value = list.Rows[0]["ReferenceNum"].ToString();
                this.dltitle.Value = list.Rows[0]["Title"].ToString();
                this.txfname.Value = list.Rows[0]["Fname"].ToString();
                this.txmname.Value = list.Rows[0]["Mname"].ToString();
                this.txsname.Value = list.Rows[0]["Sname"].ToString();
                this.dlgender.Value = list.Rows[0]["Gender"].ToString();
                string str = list.Rows[0]["DBirth"].ToString();
                int index = str.IndexOf("/");
                this.txDated.Value = str.Substring(0, index);
                str = str.Substring(index + 1);
                int length = str.IndexOf("/");
                this.txDatem.Value = str.Substring(0, length);
                this.txDatey.Value = str.Substring(length + 1);
                this.txhometel.Value = list.Rows[0]["HTelnum"].ToString();
                this.txworktel.Value = list.Rows[0]["WTelnum"].ToString();
                this.mobiletel.Value = list.Rows[0]["Mobile"].ToString();
                this.txEmail.Value = list.Rows[0]["Email"].ToString();
                this.txlnumber.Value = list.Rows[0]["LicNum"].ToString();
                this.txlstate.Value = list.Rows[0]["LicState"].ToString();
                this.dlmastatus.Value = list.Rows[0]["MaritalStatus"].ToString();
                this.txReName1.Value = list.Rows[0]["Rname1"].ToString();
                this.txReNum1.Value = list.Rows[0]["Rnum1"].ToString();
                this.selReShip1.Value = list.Rows[0]["Rship1"].ToString();
                this.txReName2.Value = list.Rows[0]["Rname2"].ToString();
                this.txReNum2.Value = list.Rows[0]["Rnum2"].ToString();
                this.selReShip2.Value = list.Rows[0]["Rship2"].ToString();
                this.txReName3.Value = list.Rows[0]["Rname3"].ToString();
                this.txReNum3.Value = list.Rows[0]["Rnum3"].ToString();
                this.selReShip3.Value = list.Rows[0]["Rship3"].ToString();
            }
        }

        public void GetResident(string sid)
        {
            LresidentBN tbn = new LresidentBN(this.Page);
            tbn.QueryLoanSid(Convert.ToInt32(sid));
            DataTable list = tbn.GetList();
            tbn.Close();
            tbn.Dispose();
            if (list.Rows.Count > 0)
            {
                this.txReSid.Text = list.Rows[0]["sid"].ToString();
                this.dlrestatus.SelectedValue = list.Rows[0]["Status"].ToString();
                this.txunitno.Value = list.Rows[0]["UnitNo"].ToString();
                this.txStreet.Value = list.Rows[0]["StreetNum"].ToString();
                this.txSuburb.Value = list.Rows[0]["Suburb"].ToString();
                this.txState.Value = list.Rows[0]["State"].ToString();
                this.txPost.Value = list.Rows[0]["Postcode"].ToString();
                this.txMonthr.Value = list.Rows[0]["TimeMonths"].ToString();
                this.DropDownList1.SelectedValue = list.Rows[0]["TimeYears"].ToString();
                this.txlandlord.Value = list.Rows[0]["NameAgent"].ToString();
                this.txareatel.Value = list.Rows[0]["TelArea"].ToString();
                if (this.dlrestatus.SelectedValue.Trim().Equals("Renting"))
                {
                    this.Table1.Visible = true;
                }
                else
                {
                    this.Table1.Visible = false;
                }
                this.txUnitNo1.Value = list.Rows[0]["UnitNo1"].ToString();
                this.txStreet1.Value = list.Rows[0]["StreetNum1"].ToString();
                this.txSuburb1.Value = list.Rows[0]["Suburb1"].ToString();
                this.txState1.Value = list.Rows[0]["State1"].ToString();
                this.txPost1.Value = list.Rows[0]["Postcode1"].ToString();
                this.txMonth1.Value = list.Rows[0]["TimeMonths1"].ToString();
                this.txYear1.Value = list.Rows[0]["TimeYears1"].ToString();
            }
        }

        private void InitializeComponent()
        {
            this.dlrestatus.SelectedIndexChanged += new EventHandler(this.dlrestatus_SelectedIndexChanged);
            this.DropDownList1.SelectedIndexChanged += new EventHandler(this.DropDownList1_SelectedIndexChanged);
            this.RadioButtonList2.SelectedIndexChanged += new EventHandler(this.RadioButtonList2_SelectedIndexChanged);
            this.bnApption.Click += new EventHandler(this.bnApption_Click);
            this.bnEdit1.ServerClick += new EventHandler(this.bnEdit1_ServerClick);
            this.bnInit.ServerClick += new EventHandler(this.bnInit_ServerClick);
            this.bnEdit2.ServerClick += new EventHandler(this.bnEdit2_ServerClick);
            this.Submit2.ServerClick += new EventHandler(this.Submit2_ServerClick);
            this.bnEdit3.ServerClick += new EventHandler(this.bnEdit3_ServerClick);
            this.bnEmploy.ServerClick += new EventHandler(this.bnEmploy_ServerClick);
            this.bnEdit4.ServerClick += new EventHandler(this.bnEdit4_ServerClick);
            this.bnBank.ServerClick += new EventHandler(this.bnBank_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        public double IsLimit()
        {
            string commandText = "select * from LParams where Sid=" + this.Hidden1.Value;
            DataTable table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
            if (table.Rows.Count <= 0)
            {
                return 0.0;
            }
            int num = 0;
            double num2 = 0.0;
            int num3 = Convert.ToInt32(this.Hidden1.Value);
            switch (this.sPer2)
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
            return (((0.25 * Convert.ToDouble(this.Hidden2.Value)) * num) / ((num * num2) + 1.0));
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.bnInit.Attributes.Add("onclick", "return CheckFeedback1();");
            this.Submit2.Attributes.Add("onclick", "return CheckFeedback2();");
            this.bnEmploy.Attributes.Add("onclick", "return CheckFeedback3();");
            this.bnBank.Attributes.Add("onclick", "return CheckFeedback4();");
            if (base.Request["sid"] != null)
            {
                this.txPerSid.Text = Cipher.DesDecrypt(base.Request["sid"].ToString(), "12345678");
                if (base.CheckPay(this.txPerSid.Text))
                {
                    base.Response.Write("<script>alert('信息已经保存,不能再修改!');window.location='Step.aspx';</script>");
                }
                else
                {
                    int persid = Convert.ToInt32(this.txPerSid.Text);
                    LiniloanBN nbn = new LiniloanBN(this.Page);
                    nbn.QueryPersid(persid);
                    DataTable list = nbn.GetList();
                    nbn.Close();
                    nbn.Dispose();
                    if (list.Rows.Count > 0)
                    {
                        this.txLoanSid.Text = list.Rows[0]["Sid"].ToString();
                        this.stxpurpose = StringUtils.ToHtml(list.Rows[0]["PrimaryPurpose"].ToString());
                        this.Hidden3.Value = this.stxborrow = list.Rows[0]["Loan"].ToString();
                        this.sdlterms = list.Rows[0]["Term"].ToString() + " Months";
                        this.Hidden1.Value = list.Rows[0]["Term"].ToString();
                    }
                    LpersonBN nbn2 = new LpersonBN(this.Page);
                    nbn2.Querysid(persid);
                    DataTable table2 = nbn2.GetList();
                    nbn2.Close();
                    nbn2.Dispose();
                    if (table2.Rows.Count > 0)
                    {
                        if (table2.Rows[0]["IsExist"].Equals(1))
                        {
                            this.sdlexisting = "True";
                        }
                        else
                        {
                            this.sdlexisting = "False";
                        }
                        this.stxrefnumber = table2.Rows[0]["ReferenceNum"].ToString();
                        this.sdltitle = table2.Rows[0]["Title"].ToString();
                        this.stxfname = table2.Rows[0]["Fname"].ToString();
                        this.stxmname = table2.Rows[0]["Mname"].ToString();
                        this.stxsname = table2.Rows[0]["Sname"].ToString();
                        this.sdlgender = table2.Rows[0]["Gender"].ToString();
                        this.sbirth = table2.Rows[0]["DBirth"].ToString();
                        this.stxhometel = table2.Rows[0]["HTelnum"].ToString();
                        this.stxworktel = table2.Rows[0]["WTelnum"].ToString();
                        this.stxmobiletel = table2.Rows[0]["Mobile"].ToString();
                        this.stxEmail = table2.Rows[0]["Email"].ToString();
                        this.stxlnumber = table2.Rows[0]["LicNum"].ToString();
                        this.stxlstate = table2.Rows[0]["LicState"].ToString();
                        this.sdlmastatus = table2.Rows[0]["MaritalStatus"].ToString();
                        this.stxReName1 = table2.Rows[0]["Rname1"].ToString();
                        this.sselReShip1 = table2.Rows[0]["Rship1"].ToString();
                        this.stxReNum1 = table2.Rows[0]["Rnum1"].ToString();
                        this.stxReName2 = table2.Rows[0]["Rname2"].ToString();
                        this.sselReShip2 = table2.Rows[0]["Rship2"].ToString();
                        this.stxReNum2 = table2.Rows[0]["Rnum2"].ToString();
                        this.stxReName3 = table2.Rows[0]["Rname3"].ToString();
                        this.sselReShip3 = table2.Rows[0]["Rship3"].ToString();
                        this.stxReNum3 = table2.Rows[0]["Rnum3"].ToString();
                    }
                    LresidentBN tbn = new LresidentBN(this.Page);
                    tbn.QueryLoanSid(persid);
                    DataTable table3 = tbn.GetList();
                    tbn.Close();
                    tbn.Dispose();
                    if (table3.Rows.Count > 0)
                    {
                        this.txReSid.Text = table3.Rows[0]["Sid"].ToString();
                        this.sdlrestatus = table3.Rows[0]["Status"].ToString();
                        this.stxunitno = table3.Rows[0]["UnitNo"].ToString();
                        this.stxStreet = table3.Rows[0]["StreetNum"].ToString();
                        this.stxSuburb = table3.Rows[0]["Suburb"].ToString();
                        this.stxState = table3.Rows[0]["State"].ToString();
                        this.stxPost = table3.Rows[0]["Postcode"].ToString();
                        this.stimeaddress = table3.Rows[0]["TimeYears"].ToString() + "Years " + table3.Rows[0]["TimeMonths"].ToString() + "Months";
                        if (table3.Rows[0]["StreetNum1"].ToString() != "")
                        {
                            this.tbUnit.Visible = true;
                            this.stxunitno1 = table3.Rows[0]["UnitNo1"].ToString();
                            this.stxStreet1 = table3.Rows[0]["StreetNum1"].ToString();
                            this.stxSuburb1 = table3.Rows[0]["Suburb1"].ToString();
                            this.stxState1 = table3.Rows[0]["State1"].ToString();
                            this.stxPost1 = table3.Rows[0]["Postcode1"].ToString();
                            this.stimeaddress1 = table3.Rows[0]["TimeYears1"].ToString() + "Years " + table3.Rows[0]["TimeMonths1"].ToString() + "Months";
                        }
                        else
                        {
                            this.tbUnit.Visible = false;
                            this.stxunitno1 = table3.Rows[0]["UnitNo1"].ToString();
                            this.stxStreet1 = table3.Rows[0]["StreetNum1"].ToString();
                            this.stxSuburb1 = table3.Rows[0]["Suburb1"].ToString();
                            this.stxState1 = table3.Rows[0]["State1"].ToString();
                            this.stxPost1 = table3.Rows[0]["Postcode1"].ToString();
                            this.stimeaddress1 = table3.Rows[0]["TimeYears1"].ToString() + "Years " + table3.Rows[0]["TimeMonths1"].ToString() + "Months";
                        }
                        if (table3.Rows[0]["Status"].ToString().Trim().Equals("Renting"))
                        {
                            this.Table3.Visible = true;
                        }
                        else
                        {
                            this.Table3.Visible = false;
                        }
                        this.stxlandlord = table3.Rows[0]["NameAgent"].ToString();
                        this.stxareatel = table3.Rows[0]["TelArea"].ToString();
                    }
                    LemploymentBN tbn2 = new LemploymentBN(this.Page);
                    tbn2.QueryLoanSid(persid);
                    DataTable table4 = tbn2.GetList();
                    tbn2.Close();
                    tbn2.Dispose();
                    if (table4.Rows.Count > 0)
                    {
                        this.txEmpSid.Text = table4.Rows[0]["Sid"].ToString();
                        this.stxEmployer = table4.Rows[0]["EName"].ToString();
                        this.stxAddress = table4.Rows[0]["EAddress"].ToString();
                        this.stxPhone = table4.Rows[0]["ECode"].ToString();
                        this.sdlestatus = table4.Rows[0]["EStatus"].ToString();
                        this.stxJob = table4.Rows[0]["JobTitle"].ToString();
                        this.stimeemployed = table4.Rows[0]["TimeYears"].ToString() + "Years " + table4.Rows[0]["TimeMonths"].ToString() + "Months";
                        this.Hidden2.Value = this.stxIncome = table4.Rows[0]["TakePay"].ToString();
                        string str = table4.Rows[0]["Per"].ToString();
                        this.sPer2 = table4.Rows[0]["Per"].ToString();
                        switch (str)
                        {
                            case "0":
                                this.sPer = "Weekly";
                                break;

                            case "1":
                                this.sPer = "F'nightly";
                                break;

                            case "2":
                                this.sPer = "Bi-Monthly";
                                break;

                            case "3":
                                this.sPer = "Monthly";
                                break;
                        }
                        this.snpayday = table4.Rows[0]["NextDay"].ToString() + "/" + table4.Rows[0]["NextMonth"].ToString() + "/" + table4.Rows[0]["NextYear"].ToString();
                        this.sHousePaymentInfo = string.Format("{0} {1}", table4.Rows[0]["HousePaymentValue"].ToString(), EnumsOP.GetHousePaymentCircleLiteral(table4.Rows[0]["HousePaymentCircle"]));
                        this.sOtherLenderInfo = string.Format("{0} {1}", table4.Rows[0]["OtherLenderValue"].ToString(), EnumsOP.GetOtherLenderCircleLiteral(table4.Rows[0]["OtherLenderCircle"]));
                    }
                    LbankBN kbn = new LbankBN(this.Page);
                    kbn.QueryLoanSid(persid);
                    DataTable table5 = kbn.GetList();
                    kbn.Close();
                    kbn.Dispose();
                    if (table5.Rows.Count > 0)
                    {
                        this.txBankSid.Text = table5.Rows[0]["Sid"].ToString();
                        this.stxBank = table5.Rows[0]["BankName"].ToString();
                        this.stxBranch = table5.Rows[0]["Branch"].ToString();
                        this.stxAname = table5.Rows[0]["AccountName"].ToString();
                        this.stxBsb = table5.Rows[0]["Bsb"].ToString();
                        this.stxAnumber = table5.Rows[0]["AccountNum"].ToString();
                        this.smethods = table5.Rows[0]["PContact"].ToString();
                    }
                    if (!this.Page.IsPostBack)
                    {
                        this.GetInitLoan(this.txPerSid.Text);
                        this.GetPerson(this.txPerSid.Text);
                        this.GetResident(this.txPerSid.Text);
                        this.GetEmployment(this.txPerSid.Text);
                        this.GetBank(this.txPerSid.Text);
                    }
                }
            }
            this.Table2.Visible = false;
            this.Panel2.Visible = this.Panel4.Visible = this.Panel6.Visible = this.Panel8.Visible = false;
        }

        private void RadioButtonList2_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.Panel1.Visible = this.Panel2.Visible = this.Panel3.Visible = this.Panel4.Visible = this.Panel5.Visible = this.Panel7.Visible = this.Panel8.Visible = false;
            this.Panel6.Visible = true;
            if (this.RadioButtonList2.SelectedValue.Equals("2"))
            {
                this.Table2.Visible = true;
            }
            else
            {
                this.Table2.Visible = false;
            }
        }

        private void Submit2_ServerClick(object sender, EventArgs e)
        {
            LpersonBN nbn = new LpersonBN(this.Page);
            LpersonDT detail = nbn.Get(Convert.ToInt32(this.txPerSid.Text));
            detail.IsExist = Convert.ToInt32(this.dlexisting.Value);
            detail.ReferenceNum = this.txrefnumber.Value;
            detail.Title = this.dltitle.Value;
            detail.Fname = this.txfname.Value;
            detail.Mname = this.txmname.Value;
            detail.Sname = this.txsname.Value;
            detail.Gender = this.dlgender.Value;
            detail.DBirth = this.txDated.Value + "/" + this.txDatem.Value + "/" + this.txDatey.Value;
            detail.HTelnum = this.txhometel.Value;
            detail.WTelnum = this.txworktel.Value;
            detail.HTelcode = "";
            detail.WTelcode = "";
            detail.Mobile = this.mobiletel.Value;
            detail.Email = this.txEmail.Value;
            detail.LicNum = this.txlnumber.Value;
            detail.LicState = this.txlstate.Value;
            detail.MaritalStatus = this.dlmastatus.Value;
            detail.RegTime = SafeDateTime.LocalNow;
            detail.LoanSid = 0;
            detail.Rname1 = this.txReName1.Value;
            detail.Rnum1 = this.txReNum1.Value;
            detail.Rship1 = this.selReShip1.Value;
            detail.Rname2 = this.txReName2.Value;
            detail.Rnum2 = this.txReNum2.Value;
            detail.Rship2 = this.selReShip2.Value;
            detail.Rname3 = this.txReName3.Value;
            detail.Rnum3 = this.txReNum3.Value;
            detail.Rship3 = this.selReShip3.Value;
            detail.Other1 = "";
            detail.Other2 = "";
            detail.Other3 = "";
            detail.Other4 = 0;
            detail.Other5 = 0;
            detail.Other6 = 0;
            detail.Status = 0;
            if (nbn.Edit(detail))
            {
                LresidentBN tbn = new LresidentBN(this.Page);
                LresidentDT tdt = tbn.Get(Convert.ToInt32(this.txReSid.Text));
                tdt.Status = this.dlrestatus.SelectedValue;
                tdt.UnitNo = this.txunitno.Value;
                tdt.StreetNum = this.txStreet.Value;
                tdt.Suburb = this.txSuburb.Value;
                tdt.State = this.txState.Value;
                tdt.Postcode = this.txPost.Value;
                tdt.TimeMonths = this.txMonthr.Value;
                tdt.TimeYears = this.DropDownList1.SelectedValue;
                tdt.NameAgent = this.txlandlord.Value;
                tdt.TelArea = this.txareatel.Value;
                tdt.LoanSid = Convert.ToInt32(this.txPerSid.Text);
                tdt.Other1 = "";
                tdt.Other2 = "";
                tdt.Other3 = "";
                tdt.Other4 = 0;
                tdt.Other5 = 0;
                tdt.Other6 = 0;
                if (Convert.ToInt32(this.DropDownList1.SelectedValue) < 5)
                {
                    tdt.UnitNo1 = this.txUnitNo1.Value;
                    tdt.StreetNum1 = this.txStreet1.Value;
                    tdt.Suburb1 = this.txSuburb1.Value;
                    tdt.State1 = this.txState1.Value;
                    tdt.Postcode1 = this.txPost1.Value;
                    tdt.TimeMonths1 = this.txMonth1.Value;
                    tdt.TimeYears1 = this.txYear1.Value;
                }
                else
                {
                    tdt.UnitNo1 = tdt.StreetNum1 = tdt.Suburb1 = tdt.State1 = tdt.Postcode1 = tdt.TimeYears1 = tdt.TimeMonths1 = "";
                }
                if (tbn.Edit(tdt))
                {
                    base.Response.Write("<script>window.location='Step5.aspx?sid=" + Cipher.DesEncrypt(this.txPerSid.Text, "12345678") + "';</script>");
                }
                tbn.Close();
                tbn.Dispose();
            }
            nbn.Close();
            nbn.Dispose();
        }
    }
}

