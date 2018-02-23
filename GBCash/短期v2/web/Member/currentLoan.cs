namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Data;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.WeiXing.Business;

    public class currentLoan : generagepage
    {
        protected HtmlForm Form2;
        public DataTable listByTime = new DataTable();
        protected Literal litApplicationDate;
        protected Literal litLoanAmount;
        protected Literal litStatus;
        protected Panel PanelHasCurrent;
        protected Panel PanelNoCurrent;

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
            if (!base.IsPostBack)
            {
                EmployedBN dbn = new EmployedBN(this.Page);
                dbn.QueryhuiSid(base.HuiSid);
                dbn.Order = "id desc";
                DataTable list = dbn.GetList();
                if ((list == null) || (list.Rows.Count == 0))
                {
                    this.PanelNoCurrent.Visible = true;
                    this.PanelHasCurrent.Visible = false;
                }
                else
                {
                    DataRow row = list.Rows[0];
                    if ((row["IsValid"].ToString() == "2") || (row["IsValid"].ToString() == "3"))
                    {
                        this.PanelNoCurrent.Visible = false;
                        this.PanelHasCurrent.Visible = true;
                        this.litApplicationDate.Text = ((DateTime) row["RTime"]).ToString("dd/MM/yyyy");
                        this.litLoanAmount.Text = ((decimal) row["Loan"]).ToString("0.00");
                        string str = string.Empty;
                        switch (row["IsValid"].ToString())
                        {
                            case "2":
                                str = "Approved";
                                break;

                            case "3":
                                str = "Pending";
                                break;
                        }
                        this.litStatus.Text = str;
                        ScheduleBN ebn = new ScheduleBN(this.Page);
                        ebn.QueryParam1(row["id"].ToString());
                        ebn.QueryNotValid("3");
                        this.listByTime = ebn.GetListByTime();
                        int count = this.listByTime.Rows.Count;
                    }
                    else
                    {
                        this.PanelNoCurrent.Visible = true;
                        this.PanelHasCurrent.Visible = false;
                    }
                }
            }
        }
    }
}

