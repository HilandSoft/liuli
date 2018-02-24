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

    public class Step2 : LongParent
    {
        protected HtmlSelect dlexisting;
        protected HtmlSelect dlgender;
        protected HtmlSelect dlmastatus;
        protected DropDownList dlrestatus;
        protected HtmlSelect dltitle;
        protected DropDownList DropDownList1;
        protected HtmlInputText mobiletel;
        protected Panel Panel1;
        protected HtmlInputText selReShip1;
        protected HtmlInputText selReShip2;
        protected HtmlInputText selReShip3;
        protected HtmlInputButton Submit2;
        protected HtmlTable Table1;
        protected HtmlInputText txareatel;
        protected HtmlInputText txDated;
        protected HtmlInputText txDatem;
        protected HtmlInputText txDatey;
        protected HtmlInputText txEmail;
        protected HtmlInputText txfname;
        protected HtmlInputText txhometel;
        protected HtmlInputText txlandlord;
        protected HtmlInputText txlnumber;
        protected TextBox txLoanSid;
        protected HtmlInputText txlstate;
        protected HtmlInputText txmname;
        protected HtmlSelect txMonth;
        protected HtmlSelect txMonth1;
        protected HtmlInputText txPost;
        protected HtmlInputText txPost1;
        protected HtmlInputText txrefnumber;
        protected HtmlInputText txReName1;
        protected HtmlInputText txReName2;
        protected HtmlInputText txReName3;
        protected HtmlInputText txReNum1;
        protected HtmlInputText txReNum2;
        protected HtmlInputText txReNum3;
        protected HtmlInputText txsname;
        protected HtmlInputText txState;
        protected HtmlInputText txState1;
        protected HtmlInputText txStreet;
        protected HtmlInputText txStreet1;
        protected HtmlInputText txSuburb;
        protected HtmlInputText txSuburb1;
        protected HtmlInputText txunitno;
        protected HtmlInputText txUnitNo1;
        protected HtmlInputText txworktel;
        protected HtmlSelect txYear1;

        private void InitializeComponent()
        {
            this.Submit2.ServerClick += new EventHandler(this.Submit2_ServerClick);
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.Submit2.Attributes.Add("onclick", "return CheckFeedback2();");
            if (base.Request["sid"] != null)
            {
                this.txLoanSid.Text = base.Request["sid"].ToString();
            }
        }

        private void Submit2_ServerClick(object sender, EventArgs e)
        {
            if (base.CheckPay2(this.txLoanSid.Text))
            {
                base.Response.Write("<script>alert('信息已经保存,不能再修改!');window.location='Step.aspx';</script>");
            }
            else
            {
                LpersonBN nbn = new LpersonBN(this.Page);
                LpersonDT detail = new LpersonDT();
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
                detail.Other4 = -1;
                detail.Other5 = 0;
                detail.Other6 = 0;
                detail.Status = -1;
                detail.Username = "";
                detail.Pwd = "";
                int num = nbn.AddId(detail);
                nbn.Close();
                nbn.Dispose();
                if (num > 0)
                {
                    string str = Cipher.DesEncrypt(num.ToString(), "12345678");
                    string commandText = "update LIniLoan set Persid=" + num.ToString() + " where sid=" + this.txLoanSid.Text;
                    int num2 = SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
                    base.Response.Write("<script>window.location='Step2r.aspx?sid=" + str + "';</script>");
                }
            }
        }
    }
}

