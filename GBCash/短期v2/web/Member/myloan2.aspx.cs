namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.STRUCTURE;

    public class myloan2 : generagepage
    {
        protected DataGridTable DataGridTable1;
        protected HtmlForm Form2;
        protected TextBox txtParamstr;

        private void DataGridTable1_DataBinding(object sender, EventArgs e)
        {
            EmployedBN dbn = new EmployedBN(this.Page);
            dbn.QueryhuiSid(base.HuiSid);
            dbn.Filter = " (IsValid!=4 and IsValid!=5) ";
            dbn.Order = "id desc";
            DataTable list = dbn.GetList();
            CommonBasePage.SetPage(this.DataGridTable1, list);
            base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
            this.txtParamstr.Text = base.PackPart(base.ParamValue);
        }

        private void DataGridTable1_ItemDataBound(object sender, DataGridItemEventArgs e)
        {
            if (e.Item.ItemIndex > -1)
            {
                string text = e.Item.Cells[0].Text;
                EmployedBN dbn = new EmployedBN(this.Page);
                dbn.Filter = " id=" + text;
                DataTable list = dbn.GetList();
                if (list.Rows.Count > 0)
                {
                    StringBuilder builder = new StringBuilder();
                    builder.Append("<table bordercolor='#e8e6df' align='center' width='98%' border='1' cellspacing='0' cellpadding='0'>");
                    builder.Append("<tr><td bgcolor='#e8eedf'>Application Date:</td><td bgcolor='#e8eedf'>" + Convert.ToDateTime(list.Rows[0]["RTime"]).Day.ToString() + "/" + Convert.ToDateTime(list.Rows[0]["RTime"]).Month.ToString() + "/" + Convert.ToDateTime(list.Rows[0]["RTime"]).Year.ToString() + "</td></tr>");
                    builder.Append("<tr><td>Loan Amount:</td><td>" + Convert.ToSingle(list.Rows[0]["Loan"]).ToString("0.00") + "</td></tr>");
                    builder.AppendFormat("<tr><td>Loan Purpose:</td><td>{0}</td></tr>", list.Rows[0]["LoanPurpose"].ToString());
                    builder.AppendFormat("<tr><td>rent/mortgage payment:</td><td>{0} {1}</td></tr>", Convert.ToSingle(list.Rows[0]["HousePaymentValue"]).ToString("0.00"), EnumsOP.GetHousePaymentCircleLiteral(list.Rows[0]["HousePaymentCircle"]));
                    builder.AppendFormat("<tr><td> other lenders:</td><td>{0} {1}</td></tr>", Convert.ToSingle(list.Rows[0]["OtherLenderValue"]).ToString("0.00"), EnumsOP.GetOtherLenderCircleLiteral(list.Rows[0]["OtherLenderCircle"]));
                    string str3 = "";
                    switch (list.Rows[0]["IsValid"].ToString())
                    {
                        case "0":
                            str3 = "Rejected";
                            break;

                        case "1":
                            str3 = "Completed";
                            break;

                        case "2":
                            str3 = "Approved";
                            break;

                        case "3":
                            str3 = "Pending";
                            break;

                        case "4":
                            str3 = "Deleted";
                            break;

                        case "5":
                            str3 = "Deleted";
                            break;
                    }
                    string str = list.Rows[0]["id"].ToString();
                    builder.Append("<tr><td>Status:</td><td>" + str3 + "</td></tr>");
                    builder.Append("<tr><td colspan='2'>Payment Schedule:</td></tr>");
                    builder.Append("<tr><td colspan='2'><table bordercolor='#e8e6df' width='100%' border='1' cellspacing='0' cellpadding='0'>");
                    builder.Append("<tr><td width='11%'></td><td width='8%'>Date Due</td><td width='12%'>Repayment Due</td><td width='10%'>Amount Paid</td><td width='10%'>Date Paid</td><td width='5%'>Penalty</td><td width='6%'>Balance</td></tr>");
                    ScheduleBN ebn = new ScheduleBN(this.Page);
                    ebn.QueryParam1(list.Rows[0]["id"].ToString());
                    ebn.Filter = " IsValid!=3 ";
                    DataTable listByTime = ebn.GetListByTime();
                    int count = listByTime.Rows.Count;
                    float num4 = 0f;
                    for (int i = 0; i < count; i++)
                    {
                        builder.Append("<tr><td width='11%'>Installment " + ((i + 1)).ToString() + "</td>");
                        builder.Append("<td width=\"8%\">" + Convert.ToDateTime(listByTime.Rows[i]["Datedue"]).Day.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[i]["Datedue"]).Month.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[i]["Datedue"]).Year.ToString() + "</td>");
                        float num6 = Convert.ToSingle(listByTime.Rows[i]["Repaydue"]);
                        num4 += num6;
                        builder.Append("<td width=\"12%\">" + num6.ToString("0.00") + "</td>");
                        float num7 = Convert.ToSingle(listByTime.Rows[i]["Paid"]);
                        num4 -= num7;
                        builder.Append("<td width=\"10%\">" + num7.ToString("0.00") + "</td>");
                        string str4 = "";
                        string str5 = "";
                        if (Convert.ToDateTime(listByTime.Rows[i]["RepayTime"]) > new DateTime(0x7d0, 1, 1))
                        {
                            str4 = Convert.ToDateTime(listByTime.Rows[i]["RepayTime"]).Day.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[i]["RepayTime"]).Month.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[i]["RepayTime"]).Year.ToString();
                        }
                        if (Convert.ToDateTime(listByTime.Rows[i]["OperateTime"]) > new DateTime(0x7d0, 1, 1))
                        {
                            str5 = Convert.ToDateTime(listByTime.Rows[i]["OperateTime"]).Day.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[i]["OperateTime"]).Month.ToString() + "/" + Convert.ToDateTime(listByTime.Rows[i]["OperateTime"]).Year.ToString();
                        }
                        builder.Append("<td width=\"10%\">" + str4 + "</td>");
                        float num8 = Convert.ToSingle(listByTime.Rows[i]["Penalty"]);
                        num4 += num8;
                        builder.Append("<td width=\"5%\">" + num8.ToString("0.00") + "</td>");
                        builder.Append("<td width=\"6%\">" + num4.ToString("0.00") + "</td>");
                        builder.Append("</tr>");
                    }
                    builder.Append("</table></td></tr></table>");
                    e.Item.Cells[0].Text = builder.ToString();
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
    }
}

