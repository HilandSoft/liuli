using YingNet.WeiXing.Business.CommonLogic;
using System;
using System.Data;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using YingNet.Common;
using YingNet.WeiXing.Business;
using YingNet.Common.Utils;

namespace YingNet.WeiXing.WebApp.Long
{
    public class Step6 : LongParent
    {
        protected CheckBox CheckBox1;
        protected HtmlInputButton Submit1;
        protected TextBox txPerSid;

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            this.Submit1.Disabled = !this.CheckBox1.Checked;
        }

        private void InitializeComponent()
        {
            this.Submit1.ServerClick += new EventHandler(this.Submit1_ServerClick);
            this.CheckBox1.CheckedChanged += new EventHandler(this.CheckBox1_CheckedChanged);
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
                this.txPerSid.Text = Cipher.DesDecrypt(base.Request["sid"].ToString(), "12345678");
                this.Submit1.Disabled = true;
            }
        }

        private void Submit1_ServerClick(object sender, EventArgs e)
        {
            if (base.CheckPay(this.txPerSid.Text))
            {
                base.Response.Write("<script>alert('信息已经保存,不能再修改!');window.location='Step.aspx';</script>");
            }
            else
            {
                string commandText = "";
                float numLoanAmount = 0f;

                string perTypeUserChoosen = "";
                int numTermCount = 0;
                int day = 0;
                int month = 0;
                int year = 0;
                int persid = 0;

                DataTable listLoan = new DataTable();
            	
                persid = Convert.ToInt32(this.txPerSid.Text);
                LiniloanBN nbn = new LiniloanBN(this.Page);
                nbn.QueryPersid(persid);
                listLoan = nbn.GetList();
                nbn.Close();
                nbn.Dispose();
                if (listLoan.Rows.Count > 0)
                {
                    numLoanAmount = Convert.ToSingle(listLoan.Rows[0]["Loan"]);
                    numTermCount = Convert.ToInt32(listLoan.Rows[0]["Term"]);
                    LemploymentBN tbn = new LemploymentBN(this.Page);
                    tbn.QueryLoanSid(persid);
                    DataTable tableEmployment = tbn.GetList();
                    tbn.Close();
                    tbn.Dispose();
                    if (tableEmployment.Rows.Count > 0)
                    {
                        string sTakePay = tableEmployment.Rows[0]["TakePay"].ToString();
                        string sPer = tableEmployment.Rows[0]["Per"].ToString();
                        double num15 = LongTermSchedule.IsLimit(numTermCount.ToString(), sPer, sTakePay) + 1.0;
                        if (Convert.ToDouble(numLoanAmount) > num15)
                        {
                            base.Response.Write("<script>alert('Sorry, the loan amount has exceeded your borrowing limit, please use the link of \"Calculator\" to check your borrowing limit!');</script>");
                        }
                        else
                        {
                            perTypeUserChoosen = tableEmployment.Rows[0]["Per"].ToString();
                            day = Convert.ToInt32(tableEmployment.Rows[0]["NextDay"]);
                            month = Convert.ToInt32(tableEmployment.Rows[0]["NextMonth"]);
                            year = Convert.ToInt32(tableEmployment.Rows[0]["NextYear"]);
                            DateTime date = new DateTime(year, month, day, 0x17, 0x3b, 0x3b);
                            //--保存还款Schedule
							int num10 = Convert.ToInt32(tableEmployment.Rows[0]["FollowDay"]);
							int num11 = Convert.ToInt32(tableEmployment.Rows[0]["FollowMonth"]);
							int num12 = Convert.ToInt32(tableEmployment.Rows[0]["FollowYear"]);
                        	LongTermSchedule.AddSchedules(this.txPerSid.Text,date,numTermCount,perTypeUserChoosen,numLoanAmount,num10,num11,num12,SafeDateTime.LocalToday);
                            
                        	commandText = "update LPerson set Status=0,Other4=0 where Sid=" + this.txPerSid.Text;
                            if (SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null).Equals(1))
                            {
                                base.Response.Write("<script>alert('Registered!');window.location='CustomInfo.aspx?sid=" + Cipher.DesEncrypt(this.txPerSid.Text, "12345678") + "';</script>");
                            }
                        }
                    }
                }
            }
        }
    }
}

