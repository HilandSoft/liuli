using System;
using System.Data;
using YingNet.Common;
using YingNet.WeiXing.Business;
using YingNet.WeiXing.DB.Data;
using YingNet.Common.Utils;

namespace YingNet.WeiXing.WebApp.manage
{
	/// <summary>
	/// loanOperate 的摘要说明。
	/// </summary>
	public class loanOperate : System.Web.UI.Page
	{
		private void Page_Load(object sender, System.EventArgs e)
		{
			int id = Convert.ToInt32(base.Request["id"]);
			int operatorNumber= Convert.ToInt32(base.Request["operate"]);
			EmployedBN dbn = new EmployedBN(this.Page);
			
			EmployedDT dt = dbn.Get(id);
			dt.IsValid = operatorNumber;
			dbn.Edit(dt);
			
			string commandText= string.Empty;
			/*
			commandText = "update Schedule set IsValid=2 where Param1='" + id.ToString() + "'";
			SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);
			*/
			commandText = "update Huiyuan set IsValid="+ operatorNumber +" where id = (select huiSid from Employed where id=" + id + ")";
			SqlHelper.ExecuteNonQuery(Config.DataSource, CommandType.Text, commandText, null);

			//如果是pre-approve被点击,那么在ProcessCenter里面,其状态改变为pre-approved
			if(operatorNumber==18)
			{
				CSProcessCenterBN processBN= new CSProcessCenterBN(this.Page);
				processBN.Filter= string.Format("UserLoanType=0 and userid=(select huiSid from Employed where id={0} )",id);
				DataTable dataTable= processBN.GetList();
				if(dataTable!=null&& dataTable.Rows.Count>0)
				{
					for(int i=0;i<dataTable.Rows.Count;i++)
					{
						int processID= Convert.ToInt32( dataTable.Rows[i]["ProcessID"]);
						CSProcessCenterDT processDT= processBN.Get(processID);
						if(processDT!=null)
						{
							processDT.ProcessStatus = ProcessCenterStatusEnum.PreApproved;
							processDT.ProcessStatusDisplay= "PreApproved";
							processDT.LastOperateDate= SafeDateTime.LocalNow;
							processBN.Edit(processDT);
						}
					}
				}
			}

			base.Response.Write("<script>alert('Success!');window.location.href='MemberList.aspx';</script>");
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
