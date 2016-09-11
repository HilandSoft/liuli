using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using YingNet.WeiXing.Business;

namespace YingNet.WeiXing.WebApp.Member
{
	/// <summary>
	/// currentLoan 的摘要说明。
	/// </summary>
	public class currentLoan : generagepage
	{
		protected System.Web.UI.HtmlControls.HtmlForm Form2;
		protected System.Web.UI.WebControls.Panel PanelHasCurrent;
		protected System.Web.UI.WebControls.Panel PanelNoCurrent;
		protected System.Web.UI.WebControls.Literal litApplicationDate;
		protected System.Web.UI.WebControls.Literal litStatus;
		protected System.Web.UI.WebControls.Literal litLoanAmount;

		public DataTable listByTime =new DataTable();
	
		private void Page_Load(object sender, System.EventArgs e)
		{
			if(this.IsPostBack==false)
			{
				EmployedBN dbn = new EmployedBN(this.Page);
				dbn.QueryhuiSid(this.HuiSid);
				//dbn.Filter = " (IsValid!=4 and IsValid!=5) ";
				dbn.Order="id desc";
				DataTable list = dbn.GetList();

				if(list==null || list.Rows.Count==0)
				{
					this.PanelNoCurrent.Visible= true;
					this.PanelHasCurrent.Visible= false;
				}
				else
				{
					DataRow firstRow= list.Rows[0];
					if(firstRow["IsValid"].ToString()=="2" ||firstRow["IsValid"].ToString()=="3")
					{
						this.PanelNoCurrent.Visible= false;
						this.PanelHasCurrent.Visible= true;

						this.litApplicationDate.Text= ((DateTime)firstRow["RTime"]).ToString("MM/dd/yyyy");
						this.litLoanAmount.Text= ((decimal)firstRow["Loan"]).ToString("0.00");
						string loanStatus= string.Empty;
						switch(firstRow["IsValid"].ToString())
						{
							case "2":
								loanStatus= "Approved";
								break;
							case "3":
								loanStatus= "Pending";
								break;
							default:
								break;
						}
						
						this.litStatus.Text= loanStatus;

						ScheduleBN ebn = new ScheduleBN(this.Page);
						ebn.QueryParam1(firstRow["id"].ToString());
						ebn.QueryNotValid("3");
						listByTime = ebn.GetListByTime();
						int num3 = listByTime.Rows.Count;

//						for (int j = 0; j < num3; j++)
//						{
//							builder.Append("<tr><td >Installment " + ((j + 1)).ToString()+ "<span style='display:none'>("+ listByTime.Rows[j]["id"].ToString() +")</span>" + "</td>");
//							//builder.Append("<tr><td width='10%'>Installment " + ((j + 1)).ToString() + "</td>");
//							DateTime time2 = Convert.ToDateTime(listByTime.Rows[j]["Datedue"]);
//							builder.Append("<td>" + (time2.Day.ToString() + "/" + time2.Month.ToString() + "/" + time2.Year.ToString()) + "</td>");
//							builder.Append("<td>" + Convert.ToSingle(listByTime.Rows[j]["Repaydue"]).ToString("0.00") + "</td>");
//							builder.Append("<td>" + Convert.ToSingle(listByTime.Rows[j]["Paid"]).ToString("0.00") + "</td>");
//							builder.Append("<td>" + Convert.ToSingle(listByTime.Rows[j]["Penalty"]).ToString("0.00") + "</td>");
//							builder.Append("<td>" + Convert.ToSingle(listByTime.Rows[j]["Balance"]).ToString("0.00") + "</td>");
//							string str6 = "";
//							string str7 = "";
//							if (Convert.ToDateTime(listByTime.Rows[j]["RepayTime"]).ToShortDateString() != "1/1/2000")
//							{
//								DateTime time3 = Convert.ToDateTime(listByTime.Rows[j]["RepayTime"]);
//								str6 = time3.Day.ToString() + "/" + time3.Month.ToString() + "/" + time3.Year.ToString();
//							}
//							builder.Append("<td>" + str6 + "</td>");
//							if (Convert.ToDateTime(listByTime.Rows[j]["OperateTime"]).ToShortDateString() != "1/1/2000")
//							{
//								DateTime time4 = Convert.ToDateTime(listByTime.Rows[j]["OperateTime"]);
//								str7 = time4.Day.ToString() + "/" + time4.Month.ToString() + "/" + time4.Year.ToString() + " " + time4.ToShortTimeString();
//							}
//							builder.Append("<td>" + str7 + "</td>");
//							if (listByTime.Rows[j]["Param2"].ToString() == "1")
//							{
//								builder.Append("<td><a href=ScheduleDel.aspx?id=" + listByTime.Rows[j]["id"].ToString() + ">Delete</a></td>");
//							}
//							if (listByTime.Rows[j]["Param3"] != null)
//							{
//								builder.Append("<td>" + listByTime.Rows[j]["Param3"].ToString() + "</td></tr>");
//							}
//							else
//							{
//								builder.Append("<td></td></tr>");
//							}
//						}
					}
					else
					{
						this.PanelNoCurrent.Visible= true;
						this.PanelHasCurrent.Visible= false;
					}
				}
			}
		}

		#region Web 窗体设计器生成的代码
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: 该调用是 ASP.NET Web 窗体设计器所必需的。
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// 设计器支持所需的方法 - 不要使用代码编辑器修改
		/// 此方法的内容。
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);

		}
		#endregion
	}
}
