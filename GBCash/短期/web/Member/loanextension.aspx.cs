namespace YingNet.WeiXing.WebApp.Member
{
    using System;
    using System.Data;
    using System.Text;
    using System.Web.UI;
    using System.Web.UI.HtmlControls;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;
	using YingNet.Common.Utils;

    public class loanextension : generagepage
    {
        protected Button Button1;
        protected Button Button2;
        public string Content1 = "";
        public string Content2 = "";
		public string ContentNewSchedule= "";
        public string CustomerNum = "";
        protected HtmlInputHidden Hidden1;
        protected HtmlInputHidden Hidden2;
        public string LoanAmount = "";
        public string Name = "";
        protected TextBox TextBox1;
//        protected TextBox txd1;
//        protected TextBox txd2;
//        protected TextBox txd3;
//protected TextBox txDuedate;
        protected TextBox txFullname;
//        protected TextBox txs1;
//        protected TextBox txs2;
//        protected TextBox txs3;
		protected System.Web.UI.HtmlControls.HtmlForm Form2;
		protected System.Web.UI.WebControls.Label LabWarning;
		protected System.Web.UI.HtmlControls.HtmlInputHidden HiddenCalced;
        //protected TextBox txYanQi;

		/************************************************************************/
		/* 用schedule彪中的Param4来区分是否为原始的还款日程还是客户要求延期的还款日程 
		 * 2016年11月23日于即墨                                                 */
		/************************************************************************/

        private void Button1_Click(object sender, EventArgs e)
        {
            HuiyuanBN nbn;
            if ((this.HiddenCalced.Value== ""))
            {
                base.Response.Write("<script>alert(\"Please click 'Calculate' button for repayment schedule before you submit the application.\");</script>");
                return;
            }
            if (this.txFullname.Text == "")
            {
                base.Response.Write("<script>alert('You need to sign by tying in your FULL name before submission.');</script>");
                return;
            }
            ScheduleBN ebn = new ScheduleBN(this.Page);

			ebn.QueryParam1(this.Session["currentLoanID"].ToString());
			ebn.QueryNotValid("3");
            int count = ebn.GetList().Rows.Count;
            string commandText = "";

//			this.Session["delayCurrentPay"]= repaydueDelay;
//			this.Session["delayCurrentScheduleID"]= scheduleId;
//
//			this.Session["delayAfterDate"]= addedRow["Repaydue"];
//			this.Session["delayAfterPay"]= addedRow["Datedue"];

			float delayCurrentPay= Convert.ToSingle(this.Session["delayCurrentPay"]);
			int delayCurrentScheduleID= Convert.ToInt32( this.Session["delayCurrentScheduleID"]);

			float delayAfterPay= Convert.ToSingle(this.Session["delayAfterPay"]);
			DateTime delayAfterDate= Convert.ToDateTime(this.Session["delayAfterDate"]);


            //float num2 = (Convert.ToSingle(this.txYanQi.Text) + Convert.ToSingle(this.Session["Balance"])) - Convert.ToSingle(this.Session["Repaydue"]);

			commandText = string.Concat(new object[] { "update Schedule set Param4=1, Repaydue='", delayCurrentPay, "' where id=", delayCurrentScheduleID, "" });
			SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);

            
			commandText = string.Concat(new object[] { "insert into Schedule(Datedue,Repaydue,huiSid,IsValid,Numberment,Param1,Param2,Param3,Balance,RepayTime,OperateTime) values('", delayAfterDate, "',", delayAfterPay, ",", this.Hidden2.Value, ",2,", 0, ",'", this.Session["currentLoanID"], "','1','", this.txFullname.Text, "',", 0, ",'1/1/2000','1/1/2000')" });
            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);


			//------------------------------
			// IMPORTENT： 各个Balance没有修改，页面显示的时候，使用累积计算的方式进行。（20160925）
			


//            switch (Convert.ToInt32(this.Session["NInstallment"]))
//            {
//                case 1:
//                    commandText = string.Concat(new object[] { "update Schedule set Datedue='", this.Session["dTime2"], "',Balance=Balance+", this.txYanQi.Text, "  where id=", this.Session["Schedule1"].ToString(), "" });
//                    SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
//                    goto Label_09CF;
//
//                case 2:
//                    switch (Convert.ToInt32(this.Session["iNum"]))
//                    {
//                        case 1:
//                            commandText = string.Concat(new object[] { "update Schedule set Datedue='", this.Session["dTime2"], "',Balance=Balance+", this.txYanQi.Text, "  where id=", this.Session["Schedule1"].ToString(), "" });
//                            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
//                            commandText = string.Concat(new object[] { "update Schedule set Datedue='", this.Session["dTime3"], "',Balance=Balance+", this.txYanQi.Text, "  where id=", this.Session["Schedule2"].ToString(), "" });
//                            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
//                            goto Label_09CF;
//
//                        case 2:
//                            commandText = string.Concat(new object[] { "update Schedule set Datedue='", this.Session["dTime2"], "',Balance=Balance+", this.txYanQi.Text, "  where id=", this.Session["Schedule2"].ToString(), "" });
//                            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
//                            goto Label_09CF;
//                    }
//                    goto Label_09CF;
//
//                case 3:
//                    switch (Convert.ToInt32(this.Session["iNum"]))
//                    {
//                        case 1:
//                            commandText = string.Concat(new object[] { "update Schedule set Datedue='", this.Session["dTime2"], "',Balance=Balance+", this.txYanQi.Text, "  where id=", this.Session["Schedule1"].ToString(), "" });
//                            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
//                            commandText = string.Concat(new object[] { "update Schedule set Datedue='", this.Session["dTime3"], "',Balance=Balance+", this.txYanQi.Text, "  where id=", this.Session["Schedule2"].ToString(), "" });
//                            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
//                            commandText = string.Concat(new object[] { "update Schedule set Datedue='", this.Session["dTime4"], "',Balance=Balance+", this.txYanQi.Text, "  where id=", this.Session["Schedule3"].ToString(), "" });
//                            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
//                            goto Label_09CF;
//
//                        case 2:
//                            commandText = string.Concat(new object[] { "update Schedule set Datedue='", this.Session["dTime2"], "',Balance=Balance+", this.txYanQi.Text, "  where id=", this.Session["Schedule2"].ToString(), "" });
//                            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
//                            commandText = string.Concat(new object[] { "update Schedule set Datedue='", this.Session["dTime3"], "',Balance=Balance+", this.txYanQi.Text, "  where id=", this.Session["Schedule3"].ToString(), "" });
//                            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
//                            goto Label_09CF;
//
//                        case 3:
//                            commandText = string.Concat(new object[] { "update Schedule set Datedue='", this.Session["dTime2"], "',Balance=Balance+", this.txYanQi.Text, "  where id=", this.Session["Schedule3"].ToString(), "" });
//                            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
//                            goto Label_09CF;
//                    }
//                    goto Label_09CF;
//
//                case 4:
//                    if (!count.Equals(0))
//                    {
//                        commandText = string.Concat(new object[] { "update Schedule set Datedue='", this.Session["dTime2"], "',Repaydue=", this.txs1.Text, " , Balance=Balance+", this.txYanQi.Text, "  where id=", this.Session["Schedule1"].ToString(), "" });
//                        break;
//                    }
//                    commandText = string.Concat(new object[] { "update Schedule set Datedue='", this.Session["dTime2"], "',Repaydue=", this.txs1.Text, " , Balance=", this.txs1.Text, "+", this.txYanQi.Text, "  where id=", this.Session["Schedule1"].ToString(), "" });
//                    break;
//
//                default:
//                    goto Label_09CF;
//            }
//            SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
        Label_09CF:
            nbn = new HuiyuanBN(this.Page);
            HuiyuanDT ndt = nbn.Get(Convert.ToInt32(this.Hidden2.Value));
            InfoBN obn = new InfoBN(this.Page);
            InfoDT dt = new InfoDT();
            dt.huiSid = Convert.ToInt32(this.Hidden2.Value);
            dt.Username = ndt.Username;
            dt.type = "5";
            dt.regtime = SafeDateTime.LocalNow;
            dt.isvalid = 1;
            obn.Add(dt);
            base.Response.Write("<script>alert('Congratulation! Your loan extension application has been sent successfully.');window.location.href='detail1.aspx';</script>");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.CalLoan();			
        }

        public void CalLoan()
        {
            if ((base.Request["Radio0"] == null) || (base.Request["Radio0"].ToString() == ""))
            {
                return;
            }
            ScheduleBN ebn = new ScheduleBN(this.Page);
//            ebn.QueryhuiSid(this.Hidden2.Value);
//            ebn.QueryIsValid("2");
//            ebn.QueryParam2("1");

			ebn.QueryParam1(this.Session["currentLoanID"].ToString());
			ebn.QueryNotValid("3");
			//listByTime = ebn.GetListByTime();
			DataTable scheduleList= ebn.GetListByTime();
            int count = scheduleList.Rows.Count;
//            SystemInfoBN obn = new SystemInfoBN(this.Page);
//            int yanqinum = obn.Get(3).yanqinum;
            string str = base.Request["Radio0"];
            string str2 = str.Substring(0, str.IndexOf("&"));
			int scheduleId = Convert.ToInt32(str2);
            int scheduleNumber = Convert.ToInt32(str.Substring(str.IndexOf("&") + 1, 1));
            this.Session["iNum"] = scheduleNumber;
            float num4 = 0f;
            float num5 = 0f;
            float num6 = 0f;
            float num8 = 0f;
            float num9 = 0f;
            string str3 = "";
            int num10 = 0;
            int num11 = 0;
            
            ScheduleDT edt = ebn.Get(scheduleId);
            DateTime datedue = edt.Datedue;
			if (edt.Datedue.AddDays(-3) < SafeDateTime.LocalToday)
			{
				this.LabWarning.Text= "WARNING:duedate must go beyond 2 days today!";
				this.LabWarning.Visible= true;
				return;
			}
			else{
				this.LabWarning.Visible= false;
			}


            num8 = Convert.ToSingle(edt.Repaydue);
            num9 = Convert.ToInt32(edt.Numberment);
            str3 = edt.Param1;
            this.Session["oldRepay"] = num8;
            this.Session["Numberment"] = num9;
            this.Session["Param1"] = str3;
            this.Session["Balance"] = edt.Balance;
            this.Session["Repaydue"] = edt.Repaydue;
            EmployedBN dbn = new EmployedBN(this.Page);
            dbn.QueryhuiSid(this.Hidden2.Value);
            //dbn.QueryParam3(this.Hidden1.Value);
			EmployedDT loanDT =dbn.Get(Convert.ToInt32(this.Session["currentLoanID"]));
            //DataTable list = dbn.GetList();
            num4 = Convert.ToSingle(loanDT.Loan);
            num10 = Convert.ToInt32(loanDT.NInstallment);
            //num5 = Convert.ToSingle(list.Rows[0]["Interest"]);
            num6 = Convert.ToSingle(loanDT.Frequency);


			DataRow row=null;
			//row= scheduleList.Rows[scheduleNumber-1];
			int rowCount= scheduleList.Rows.Count;
			for(int i=0;i<rowCount;i++){
				if(Convert.ToInt32( scheduleList.Rows[i]["id"])== scheduleId){
					row= scheduleList.Rows[i];
				}
			}

			DataRow addedRow= scheduleList.NewRow();
			addedRow["Repaydue"]= row["Repaydue"];
			this.Session["delayAfterPay"]= addedRow["Repaydue"];
			addedRow["Datedue"]= Convert.ToDateTime( scheduleList.Rows[count-1]["Datedue"]).AddDays(num6);
			this.Session["delayAfterDate"]= addedRow["Datedue"];
			scheduleList.Rows.Add(addedRow);


			float repaydueOldValue= Convert.ToSingle(row["Repaydue"]);
			float principleBalance= num4 - num4/num10 * (scheduleNumber-1);
			float interrest= 0.04F;
			float repaydueDelay= Convert.ToSingle(50 + interrest * principleBalance / 30.4167 * num6);
			row["Repaydue"]= repaydueDelay;
			this.Session["delayCurrentPay"]= repaydueDelay;
			this.Session["delayCurrentScheduleID"]= scheduleId;

            StringBuilder builder= new StringBuilder();

			for (int i = 0; i < scheduleList.Rows.Count; i++)
			{
				string str6 = Convert.ToDateTime(scheduleList.Rows[i]["Datedue"]).Day.ToString() + "/" + Convert.ToDateTime(scheduleList.Rows[i]["Datedue"]).Month.ToString() + "/" + Convert.ToDateTime(scheduleList.Rows[i]["Datedue"]).Year.ToString();
				string[] strArray2 = new string[] { "<tr><td>", (i + 1).ToString(), "</td><td>", str6, "</td><td>", Convert.ToSingle(scheduleList.Rows[i]["Repaydue"]).ToString("0.00"), "</td></tr>" };
				builder.Append(string.Concat(strArray2));
			}
			this.Content2= builder.ToString();
			this.HiddenCalced.Value= "yes";
			


//            //num11 = Convert.ToInt32(list.Rows[0]["XDay"]);
//            float num13 = Convert.ToSingle(Convert.ToSingle(list.Rows[0]["Param2"])) / Convert.ToSingle(num10);
//            this.Session["NInstallment"] = num10;
//            
//			TimeSpan span = new TimeSpan(Convert.ToInt32(num6), 0, 0, 0, 0);
//            DateTime time2 = datedue + span;
//            DateTime time3 = time2 + span;
//            DateTime time4 = time3 + span;
//            TimeSpan span2 = (TimeSpan) (datedue - SafeDateTime.LocalNow);
//            if (span2.Days < 1)
//            {
//                base.Response.Write("<script>alert('Loan extension application must be no later than two business days before payment due ');</script>");
//                return;
//            }
//            double num14 = 0.0;
//            DateTime time5 = Convert.ToDateTime(this.Session["Datedue1"]);
//            switch (num10)
//            {
//                case 1:
//                    num14 = ((num4 * num6) * num5) + num13;
//                    this.txDuedate.Text = datedue.Day.ToString() + "/" + datedue.Month.ToString() + "/" + datedue.Year.ToString();
//                    this.txYanQi.Text = num14.ToString("0.00");
//                    this.txd1.Text = time2.Day.ToString() + "/" + time2.Month.ToString() + "/" + time2.Year.ToString();
//                    this.txs1.Text = Convert.ToSingle(this.Session["Repaydue1"]).ToString("0.00");
//                    goto Label_1125;
//
//                case 2:
//                    switch (num3)
//                    {
//                        case 1:
//                            num14 = ((num4 * num6) * num5) + num13;
//                            this.txDuedate.Text = datedue.Day.ToString() + "/" + datedue.Month.ToString() + "/" + datedue.Year.ToString();
//                            this.txYanQi.Text = num14.ToString("0.00");
//                            this.txd1.Text = time2.Day.ToString() + "/" + time2.Month.ToString() + "/" + time2.Year.ToString();
//                            this.txd2.Text = time3.Day.ToString() + "/" + time3.Month.ToString() + "/" + time3.Year.ToString();
//                            this.txs1.Text = Convert.ToSingle(this.Session["Repaydue1"]).ToString("0.00");
//                            this.txs2.Text = Convert.ToSingle(this.Session["Repaydue2"]).ToString("0.00");
//                            goto Label_1125;
//
//                        case 2:
//                            num14 = (((num4 * num6) * num5) + num13) * 0.5;
//                            this.txDuedate.Text = datedue.Day.ToString() + "/" + datedue.Month.ToString() + "/" + datedue.Year.ToString();
//                            this.txYanQi.Text = num14.ToString("0.00");
//                            this.txd1.Text = time5.Day.ToString() + "/" + time5.Month.ToString() + "/" + time5.Year.ToString();
//                            this.txd2.Text = time2.Day.ToString() + "/" + time2.Month.ToString() + "/" + time2.Year.ToString();
//                            this.txs1.Text = Convert.ToSingle(this.Session["Repaydue1"]).ToString("0.00");
//                            this.txs2.Text = Convert.ToSingle(this.Session["Repaydue2"]).ToString("0.00");
//                            goto Label_1125;
//                    }
//                    goto Label_1125;
//
//                case 3:
//                    switch (num3)
//                    {
//                        case 1:
//                            num14 = ((num4 * num6) * num5) + num13;
//                            this.txDuedate.Text = datedue.Day.ToString() + "/" + datedue.Month.ToString() + "/" + datedue.Year.ToString();
//                            this.txYanQi.Text = num14.ToString("0.00");
//                            this.txd1.Text = time2.Day.ToString() + "/" + time2.Month.ToString() + "/" + time2.Year.ToString();
//                            this.txd2.Text = time3.Day.ToString() + "/" + time3.Month.ToString() + "/" + time3.Year.ToString();
//                            this.txd3.Text = time4.Day.ToString() + "/" + time4.Month.ToString() + "/" + time4.Year.ToString();
//                            this.txs1.Text = Convert.ToSingle(this.Session["Repaydue1"]).ToString("0.00");
//                            this.txs2.Text = Convert.ToSingle(this.Session["Repaydue2"]).ToString("0.00");
//                            this.txs3.Text = Convert.ToSingle(this.Session["Repaydue3"]).ToString("0.00");
//                            goto Label_1125;
//
//                        case 2:
//                            num14 = ((((num4 * num6) * num5) + num13) * 2.0) / 3.0;
//                            this.txDuedate.Text = datedue.Day.ToString() + "/" + datedue.Month.ToString() + "/" + datedue.Year.ToString();
//                            this.txYanQi.Text = num14.ToString("0.00");
//                            this.txd1.Text = time5.Day.ToString() + "/" + time5.Month.ToString() + "/" + time5.Year.ToString();
//                            this.txd2.Text = time2.Day.ToString() + "/" + time2.Month.ToString() + "/" + time2.Year.ToString();
//                            this.txd3.Text = time3.Day.ToString() + "/" + time3.Month.ToString() + "/" + time3.Year.ToString();
//                            this.txs1.Text = Convert.ToSingle(this.Session["Repaydue1"]).ToString("0.00");
//                            this.txs2.Text = Convert.ToSingle(this.Session["Repaydue2"]).ToString("0.00");
//                            this.txs3.Text = Convert.ToSingle(this.Session["Repaydue3"]).ToString("0.00");
//                            goto Label_1125;
//
//                        case 3:
//                        {
//                            num14 = ((double) (((num4 * num6) * num5) + num13)) / 3.0;
//                            this.txDuedate.Text = datedue.Day.ToString() + "/" + datedue.Month.ToString() + "/" + datedue.Year.ToString();
//                            this.txYanQi.Text = num14.ToString("0.00");
//                            DateTime time6 = Convert.ToDateTime(this.Session["Datedue2"]);
//                            this.txd1.Text = time5.Day.ToString() + "/" + time5.Month.ToString() + "/" + time5.Year.ToString();
//                            this.txd2.Text = time6.Day.ToString() + "/" + time6.Month.ToString() + "/" + time6.Year.ToString();
//                            this.txd3.Text = time2.Day.ToString() + "/" + time2.Month.ToString() + "/" + time2.Year.ToString();
//                            this.txs1.Text = Convert.ToSingle(this.Session["Repaydue1"]).ToString("0.00");
//                            this.txs2.Text = Convert.ToSingle(this.Session["Repaydue2"]).ToString("0.00");
//                            this.txs3.Text = Convert.ToSingle(this.Session["Repaydue3"]).ToString("0.00");
//                            goto Label_1125;
//                        }
//                    }
//                    goto Label_1125;
//
//                case 4:
//                    if (!count.Equals(0))
//                    {
//                        num14 = (num4 * num6) * num5;
//                        break;
//                    }
//                    num14 = (num4 * num11) * num5;
//                    break;
//
//                default:
//                    goto Label_1125;
//            }
//            this.txDuedate.Text = datedue.Day.ToString() + "/" + datedue.Month.ToString() + "/" + datedue.Year.ToString();
//            this.txYanQi.Text = num14.ToString("0.00");
//            this.txd1.Text = time2.Day.ToString() + "/" + time2.Month.ToString() + "/" + time2.Year.ToString();
//            this.txs1.Text = ((double) (((num4 * num5) * num6) + num4)).ToString("0.00");
//        Label_1125:;
//			string dateRecordFormat= Config.DateRecordFormat;
//			this.Session["yDatedue"] = datedue.ToString(dateRecordFormat);
//			this.Session["dTime2"] = time2.ToString(dateRecordFormat);
//			this.Session["dTime3"] = time3.ToString(dateRecordFormat);
//			this.Session["dTime4"] = time4.ToString(dateRecordFormat);
			//			  this.Session["yDatedue"] = datedue.Day.ToString() + "/" + datedue.Month.ToString() + "/" + datedue.Year.ToString();
			//            this.Session["dTime2"] = time2.Day.ToString() + "/" + time2.Month.ToString() + "/" + time2.Year.ToString();
			//            this.Session["dTime3"] = time3.Day.ToString() + "/" + time3.Month.ToString() + "/" + time3.Year.ToString();
			//            this.Session["dTime4"] = time4.Day.ToString() + "/" + time4.Month.ToString() + "/" + time4.Year.ToString();
        }

        public string getInfo()
        {
            StringBuilder builder = new StringBuilder();
            ScheduleBN ebn = new ScheduleBN(this.Page);
            //ebn.QueryhuiSid(this.Hidden2.Value);
//            ebn.QueryIsValid("2");
//            ebn.QueryParam2("0");

			string currentLoanID= Convert.ToString(this.Session["currentLoanID"]);
			ebn.QueryParam1(currentLoanID);
			ebn.QueryNotValid("3");
			
            DataTable list = ebn.GetListByTime();
			
			//this.Hidden1.Value = list.Rows[0]["Numberment"].ToString();
			
            int originalScheduleNumber=0;
            for (int i = 0; i < list.Rows.Count; i++)
            {
                string str = "Repaydue" + ((i + 1)).ToString();
                this.Session[str] = Convert.ToSingle(list.Rows[i]["Repaydue"]).ToString("0.00");
                string str2 = "Datedue" + ((i + 1)).ToString();
                this.Session[str2] = Convert.ToDateTime(list.Rows[i]["Datedue"]);
                string str3 = "Schedule" + ((i + 1)).ToString();
                this.Session[str3] = list.Rows[i]["id"].ToString();
				
				string str4 = "";
				string delayString= "";
				if( list.Rows[i]["Param4"]== System.DBNull.Value|| list.Rows[i]["Param4"].ToString()=="0"){
					string str5 = "";
					str5 = list.Rows[i]["id"].ToString() + "&" + ((++originalScheduleNumber)).ToString();
					str4 = "<INPUT id='Radio0'  type='radio' value='" + str5 + "' name='Radio0' >";
					delayString= "Extend to Next payday";
				}				
                
                DateTime time = Convert.ToDateTime(list.Rows[i]["Datedue"]);
                string str6 = Convert.ToDateTime(list.Rows[i]["Datedue"]).Day.ToString() + "/" + Convert.ToDateTime(list.Rows[i]["Datedue"]).Month.ToString() + "/" + Convert.ToDateTime(list.Rows[i]["Datedue"]).Year.ToString();
                string[] strArray2 = new string[] { "<tr><td>", (i + 1).ToString(), "</td><td>", str6, "</td><td>", Convert.ToSingle(list.Rows[i]["Repaydue"]).ToString("0.00"), "</td><td>", str4, "</td><td>",delayString,"</td>" };
                builder.Append(string.Concat(strArray2));
            }
            return builder.ToString();
        }

        private void InitializeComponent()
        {
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Load += new System.EventHandler(this.Page_Load);

		}

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            EmployedBN dbn = new EmployedBN(this.Page);
            this.Hidden2.Value = this.HuiSid;
            dbn.QueryhuiSid(this.Hidden2.Value);
            //dbn.QueryIsValid("2");
			dbn.Order="id desc";

            DataTable list = dbn.GetList();
            if (list.Rows.Count <= 0)
            {
                base.Response.Write("<script>alert('This is no information available at this time. Please check again after your loan is approved.');window.location.href='detail1.aspx';</script>");
            }
            else
            {
                this.Session["Employedid"] = list.Rows[0]["id"].ToString();
                HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(Convert.ToInt32(this.Hidden2.Value));
                this.Name = ndt.Fname + " " + ndt.Mname + " " + ndt.Lname;
                this.CustomerNum = this.Hidden2.Value;
                this.LoanAmount = Convert.ToSingle(list.Rows[0]["Loan"]).ToString("0.00");
				this.Session["currentLoanID"]= list.Rows[0]["id"];
                this.Content1 = this.getInfo();

//				DateTime regTime= Convert.ToDateTime( list.Rows[0]["RTime"]);
//				if(regTime>=new DateTime(2013,7,1))
//				{
//					this.Button1.Enabled= false;
//					this.Button1.Visible= false;
//					this.Button1.Text= "Can't Extension";
//					this.Button2.Enabled= false;
//					this.Button2.Visible= false;
//					this.Button2.Text= "Can't Extension";
//
//					base.Response.Write("<script>alert('Please note extensions are not permitted for applications after 30/06/13.');</script>");
//				}
            }
        }
    }
}

