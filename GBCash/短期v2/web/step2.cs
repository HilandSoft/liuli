namespace YingNet.WeiXing.WebApp
{
    using System;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class step2 : Page
    {
        protected DropDownList dlTitle;
        protected HtmlSelect selState;
        protected HtmlInputButton Submit1;
        protected HtmlInputText txCity;
        protected HtmlInputText txConfirm;
        protected HtmlInputText txDated;
        protected HtmlInputText txDatem;
        protected HtmlInputText txDatey;
        protected HtmlInputText txDriver;
        protected HtmlInputText txEmail;
        protected HtmlInputText txFax;
        protected HtmlInputText txFname;
        protected HtmlInputText txIssue;
        protected HtmlInputText txLname;
        protected HtmlInputText txMname;
        protected HtmlInputText txMobile;
        protected HtmlSelect txMonth;
        protected HtmlInputText txPass;
        protected HtmlInputText txPost;
        protected HtmlInputText txResident;
        protected HtmlInputText txStreet;
        protected HtmlInputText txTel;
        protected HtmlInputText txUser;
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
            this.Submit1.Attributes.Add("onclick", "return CheckFeedback();");
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            try
            {
                HuiyuanBN nbn = new HuiyuanBN(this.Page);
                nbn.QueryUsername(this.txUser.Value);
                if (nbn.GetList().Rows.Count > 0)
                {
                    base.Response.Write("<script>alert('Please select a new Username, that name is already in use!');</script>");
                }
                else
                {
                    HuiyuanDT dt = new HuiyuanDT();
                    dt.Param2 = this.dlTitle.SelectedValue;
                    dt.Fname = this.txFname.Value;
                    dt.Lname = this.txLname.Value;
                    dt.Mname = this.txMname.Value;
                    dt.DBirth = Convert.ToDateTime(this.txDatey.Value + "-" + this.txDatem.Value + "-" + this.txDated.Value);
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
                    dt.Username = this.txUser.Value;
                    dt.Password = this.txPass.Value;
                    dt.IsValid = 9;
                    dt.Regtime = SafeDateTime.LocalNow;
                    int num = nbn.Add2(dt);
                    this.Session["username"] = this.txUser.Value;
                    this.Session["huiSid"] = num;
                    base.Response.Write("<script>window.top.location='newcu3.htm';</script>");
                }
            }
            catch (Exception exception)
            {
                base.Response.Write(exception.Message);
            }
        }
    }
}

