namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class detailnew : generagepage
    {
        protected HtmlInputHidden Hidden1;
        protected HtmlSelect selState;
        protected HtmlInputButton Submit1;
        protected HtmlInputText txCity;
        protected HtmlInputText txDate;
        protected HtmlInputText txDriver;
        protected HtmlInputText txEmail;
        protected HtmlInputText txFax;
        protected HtmlInputText txFname;
        protected HtmlInputText txIssue;
        protected HtmlInputText txLname;
        protected HtmlInputText txMname;
        protected HtmlInputText txMobile;
        protected HtmlSelect txMonth;
        protected HtmlInputText txPost;
        protected HtmlInputText txResident;
        protected HtmlInputText txStreet;
        protected HtmlInputText txTel;
        protected HtmlSelect txYear;

        private void InitializeComponent()
        {
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
            }
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            HuiyuanBN nbn = new HuiyuanBN(this.Page);
            HuiyuanDT dt = nbn.Get(Convert.ToInt32(this.Hidden1.Value));
            HuibackupBN pbn = new HuibackupBN(this.Page);
            HuibackupDT pdt = new HuibackupDT();
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
            dt.Fname = this.txFname.Value;
            dt.Lname = this.txLname.Value;
            dt.Mname = this.txMname.Value;
            dt.DBirth = Convert.ToDateTime(this.txDate.Value);
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
            if (nbn.Edit(dt))
            {
                base.Response.Write("<script>window.alert('Success!');window.location='newloan.aspx';</script>");
            }
            else
            {
                base.Response.Write("<script>window.alert('Error!');</script>");
            }
        }
    }
}

