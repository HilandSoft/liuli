namespace YingNet.WeiXing.WebApp.manage.FollowupCenter
{
    using System;
    using System.Configuration;
    using System.Data;
    using System.Globalization;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class openwindow : ManageBasePage2
    {
        protected DataGridTable DataGridTable1;
        protected TextBox txtParamstr;

        private void DataGridTable1_DataBinding(object sender, EventArgs e)
        {
            CSFollowupCenterBN rbn = new CSFollowupCenterBN(this.Page);
            DataTable dt = null;
            rbn.CleanStatus();
            rbn.Filter = string.Format(" UserLoanType={0} ", 0);
            string str = string.Concat(new object[] { 10, ",", 50, ",", 90, ",", 80 });
            rbn.Filter = string.Format(" FollowupStatus in ({0}) ", str);
            rbn.Filter = string.Format(" RemindEnable=1 ", new object[0]);
            string name = ConfigurationSettings.AppSettings["CultureInfoFormat"];
            switch (name)
            {
                case null:
                case string.Empty:
                    name = "en-AU";
                    break;
            }
            string str3 = SafeDateTime.LocalToday.ToString(new CultureInfo(name));
            string str4 = new DateTime(0x6d9, 1, 2).ToString(new CultureInfo(name));
            rbn.Filter = string.Format(" ((RemindDate<='{0}' and RemindDate>'{1}') or (RemindDate2<='{0}' and RemindDate2>'{1}') or (RemindDate3<='{0}' and RemindDate3>'{1}')) ", str3, str4);
            dt = rbn.GetList();
            CommonBasePage.SetPage(this.DataGridTable1, dt);
            base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
            this.txtParamstr.Text = base.PackPart(base.ParamValue);
        }

        private void DataGridTable1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if ((e.Item.ItemIndex > -1) && (((e.Item.ItemType == ListItemType.Item) || (e.Item.ItemType == ListItemType.AlternatingItem)) || (e.Item.ItemType == ListItemType.SelectedItem)))
            {
                DataRowView dataItem = (DataRowView) e.Item.DataItem;
                CSFollowupCenterDT rdt = null;
                if (dataItem != null)
                {
                    rdt = new CSFollowupCenterBN(this.Page).Get(Convert.ToInt32(dataItem["FollowupID"]));
                    if (rdt != null)
                    {
                        Literal literal = e.Item.FindControl("litStatus") as Literal;
                        if (literal != null)
                        {
                            literal.Text = Convert.ToString(rdt.FollowupStatus);
                        }
                        Literal literal2 = e.Item.FindControl("LitActionDueDate") as Literal;
                        if ((literal2 != null) && (rdt.RemindDate > new DateTime(0x6d9, 1, 2)))
                        {
                            literal2.Text = rdt.RemindDate.ToString("dd-MM-yyyy");
                        }
                        if (rdt.UserID > 0)
                        {
                            HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(rdt.UserID);
                            if (ndt != null)
                            {
                                Literal literal3 = e.Item.FindControl("LitUserName") as Literal;
                                if (literal3 != null)
                                {
                                    literal3.Text = ndt.Username;
                                }
                                Literal literal4 = e.Item.FindControl("LitRegtime") as Literal;
                                if (literal4 != null)
                                {
                                    literal4.Text = ndt.Regtime.ToString("dd-MM-yyyy");
                                }
                            }
                        }
                    }
                }
            }
        }

        private void DataGridTable1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
        {
            this.DataGridTable1.CurrentPageIndex = e.NewPageIndex;
            this.DataGridTable1.DataBind();
        }

        private void InitializeComponent()
        {
            this.DataGridTable1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridTable1_PageIndexChanged);
            this.DataGridTable1.DataBinding += new EventHandler(this.DataGridTable1_DataBinding);
            this.DataGridTable1.ItemDataBound += new DataGridItemEventHandler(this.DataGridTable1_ItemDataBound);
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
                this.txtParamstr.Text = base.PackPart(base.ParamValue);
                string str = base.GetValue("pageno");
                if (str != null)
                {
                    this.DataGridTable1.CurrentPageIndex = Convert.ToInt32(str) - 1;
                }
                this.DataGridTable1.DataBind();
            }
            else
            {
                base.ParamValue = base.UnPackPart(this.txtParamstr.Text);
            }
        }

        protected override bool IsNeedValidate
        {
            get
            {
                return false;
            }
        }
    }
}

