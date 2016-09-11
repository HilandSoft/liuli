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
using YingNet.Common;
using YingNet.Common.Utils;

namespace YingNet.WeiXing.WebApp.manage.Long
{
	/// <summary>
	/// LoanInfoForPrint ��ժҪ˵����
	/// </summary>
	public class LoanInfoForPrint : System.Web.UI.Page
	{
		public DataTable dtPay = new DataTable();
		public string sLoan = "";
		public string sNumber = "";
		public string sRegTime = "";
		protected TextBox txPerSid;

		//TODO:���¼���ֵ��Ҫȷ�Ͼ���ĺ���
		public string userFullName= string.Empty;
		public string userAddressDetail= string.Empty;
		
		public string statementIssuedDate= SafeDateTime.LocalNow.ToString("dd-MM-yyyy");
		public string amountOutstanding= string.Empty;

		private void Page_Load(object sender, System.EventArgs e)
		{
			if (base.Request["sid"] != null)
			{
				this.txPerSid.Text = base.Request["sid"].ToString();
				this.sNumber = base.Request["sid"].ToString();
				string commandText = "";
				commandText = "select * from LPay where PerSid=" + this.txPerSid.Text;
				this.dtPay = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
				commandText = "select Loan from LIniLoan where PerSid=" + this.sNumber;
				DataTable table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
				if (table.Rows.Count > 0)
				{
					this.sLoan = table.Rows[0]["Loan"].ToString();
				}
				commandText = "select * from LPerson where Sid=" + this.sNumber;
				table = SqlHelper.ExecuteDataset(Config.DataSource, CommandType.Text, commandText).Tables[0];
				if (table.Rows.Count > 0)
				{
					DataRow row= table.Rows[0];
					this.sRegTime = Convert.ToDateTime(row["RegTime"]).ToString("dd/MM/yyyy hh:mm:ss");
					this.userFullName= Convert.ToString(row["Title"])+ " "+ Convert.ToString(row["Fname"])+" "+ Convert.ToString(row["Sname"]);
					//this.userAddressDetail= Convert.ToString(row[""]);
				}
				
				for(int i=0;i<dtPay.Rows.Count;i++)
				{
					DateTime datDueDate= SafeDateTime.LocalToday;
					try
					{
						string strDueDate = Convert.ToString(dtPay.Rows[i]["Datedue"]);
						string[] tempArray = strDueDate.Split('/', '-');
						
						if(tempArray.Length==3)
						{
							datDueDate= new DateTime(Convert.ToInt32(tempArray[2]),Convert.ToInt32(tempArray[1]),Convert.ToInt32(tempArray[0]));
						}
					}
					catch{}
					
					if(dtPay.Rows[i]["Balance"].ToString()!="" && datDueDate<= SafeDateTime.LocalNow)
					{
						//ȡ���һ����ֵ��Balance
						amountOutstanding ="$"+ Convert.ToDouble(dtPay.Rows[i]["Balance"]).ToString("0.00");
					}
				}

				if(amountOutstanding==string.Empty)
				{
					amountOutstanding = "$0";
				}
				//TODO:�ͻ��ĵ�ַ����Ϣ��Ҫ���»�ȡ.
			}
		}

		#region Web ������������ɵĴ���
		override protected void OnInit(EventArgs e)
		{
			//
			// CODEGEN: �õ����� ASP.NET Web ���������������ġ�
			//
			InitializeComponent();
			base.OnInit(e);
		}
		
		/// <summary>
		/// �����֧������ķ��� - ��Ҫʹ�ô���༭���޸�
		/// �˷��������ݡ�
		/// </summary>
		private void InitializeComponent()
		{    
			this.Load += new System.EventHandler(this.Page_Load);
		}
		#endregion
	}
}
