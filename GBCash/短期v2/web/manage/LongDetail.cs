namespace YingNet.WeiXing.WebApp.manage
{
    using System;
    using System.Data;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using YingNet.Common;

    public class LongDetail : Page
    {
        public string birth = "";
        public string dlestatus = "";
        public string dlexisting = "";
        public string dlgender = "";
        public string dlmastatus = "";
        public string dlrestatus = "";
        public string dlterms = "";
        public string dltitle = "";
        public string methods = "";
        public string npayday = "";
        public string Per = "";
        public string selReShip1 = "";
        public string selReShip2 = "";
        public string selReShip3 = "";
        protected TextBox TextBox1;
        public string timeaddress = "";
        public string timeemployed = "";
        public string txAddress = "";
        public string txAname = "";
        public string txAnumber = "";
        public string txareatel = "";
        public string txBank = "";
        public string txborrow = "";
        public string txBranch = "";
        public string txBsb = "";
        public string txEmail = "";
        public string txEmployer = "";
        public string txfname = "";
        public string txhometel = "";
        public string txIncome = "";
        public string txJob = "";
        public string txlandlord = "";
        public string txlnumber = "";
        public string txlstate = "";
        public string txmname = "";
        public string txmobiletel = "";
        public string txPhone = "";
        public string txPost = "";
        public string txpurpose = "";
        public string txrefnumber = "";
        public string txReName1 = "";
        public string txReName2 = "";
        public string txReName3 = "";
        public string txReNum1 = "";
        public string txReNum2 = "";
        public string txReNum3 = "";
        public string txsname = "";
        public string txState = "";
        public string txStreet = "";
        public string txSuburb = "";
        public string txunitno = "";
        public string txworktel = "";

        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            if (base.Request["sid"] != null)
            {
                this.TextBox1.Text = base.Request["sid"].ToString();
                DataTable table = new DataTable();
                string commandText = "select * from longtp where sid=" + this.TextBox1.Text + "";
                table = SqlHelper.ExecuteDataset(Config.DataSource, 1, commandText).Tables[0];
                if (table.Rows.Count > 0)
                {
                    string str2 = table.Rows[0]["sid"].ToString();
                    this.txpurpose = table.Rows[0]["purpose"].ToString();
                    this.txborrow = table.Rows[0]["borrow"].ToString();
                    this.dlterms = table.Rows[0]["terms"].ToString();
                    this.dlexisting = table.Rows[0]["existing"].ToString();
                    this.txrefnumber = table.Rows[0]["refnumber"].ToString();
                    this.dltitle = table.Rows[0]["title"].ToString();
                    this.txfname = table.Rows[0]["fname"].ToString();
                    this.txmname = table.Rows[0]["mname"].ToString();
                    this.txsname = table.Rows[0]["sname"].ToString();
                    this.dlgender = table.Rows[0]["gender"].ToString();
                    this.birth = table.Rows[0]["birth"].ToString();
                    this.txhometel = table.Rows[0]["hometel"].ToString();
                    this.txworktel = table.Rows[0]["worktel"].ToString();
                    this.txmobiletel = table.Rows[0]["mobiletel"].ToString();
                    this.txEmail = table.Rows[0]["Email"].ToString();
                    this.txlnumber = table.Rows[0]["lnumber"].ToString();
                    this.txlstate = table.Rows[0]["lstate"].ToString();
                    this.dlmastatus = table.Rows[0]["mastatus"].ToString();
                    this.dlrestatus = table.Rows[0]["restatus"].ToString();
                    this.txunitno = table.Rows[0]["unitno"].ToString();
                    this.txStreet = table.Rows[0]["Street"].ToString();
                    this.txSuburb = table.Rows[0]["Suburb"].ToString();
                    this.txState = table.Rows[0]["State"].ToString();
                    this.txPost = table.Rows[0]["postcode"].ToString();
                    this.timeaddress = table.Rows[0]["timeaddress"].ToString();
                    this.txlandlord = table.Rows[0]["landlord"].ToString();
                    this.txareatel = table.Rows[0]["areatel"].ToString();
                    string str3 = "select * from longte where personsid=" + str2;
                    DataTable table2 = new DataTable();
                    table2 = SqlHelper.ExecuteDataset(Config.DataSource, 1, str3).Tables[0];
                    if (table2.Rows.Count > 0)
                    {
                        this.txEmployer = table2.Rows[0]["ename"].ToString();
                        this.txAddress = table2.Rows[0]["eaddress"].ToString();
                        this.txPhone = table2.Rows[0]["etel"].ToString();
                        this.dlestatus = table2.Rows[0]["estatus"].ToString();
                        this.txJob = table2.Rows[0]["jobtitle"].ToString();
                        this.timeemployed = table2.Rows[0]["timeemployed"].ToString();
                        this.txIncome = table2.Rows[0]["thome"].ToString();
                        this.Per = table2.Rows[0]["tper"].ToString();
                        this.npayday = table2.Rows[0]["npayday"].ToString();
                        this.txBank = table2.Rows[0]["bankname"].ToString();
                        this.txBranch = table2.Rows[0]["branch"].ToString();
                        this.txAname = table2.Rows[0]["acname"].ToString();
                        this.txBsb = table2.Rows[0]["bsb"].ToString();
                        this.txAnumber = table2.Rows[0]["acnumber"].ToString();
                        this.methods = table2.Rows[0]["premethods"].ToString();
                        this.txReName1 = table2.Rows[0]["Rname1"].ToString();
                        this.selReShip1 = table2.Rows[0]["Rship1"].ToString();
                        this.txReNum1 = table2.Rows[0]["Rnum1"].ToString();
                        this.txReName2 = table2.Rows[0]["Rname2"].ToString();
                        this.selReShip2 = table2.Rows[0]["Rship2"].ToString();
                        this.txReNum2 = table2.Rows[0]["Rnum2"].ToString();
                        this.txReName3 = table2.Rows[0]["Rname3"].ToString();
                        this.selReShip3 = table2.Rows[0]["Rship3"].ToString();
                        this.txReNum3 = table2.Rows[0]["Rnum3"].ToString();
                    }
                }
            }
        }
    }
}

