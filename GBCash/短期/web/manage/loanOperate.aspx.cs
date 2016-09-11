using System;
using System.Data;
using YingNet.Common;
using YingNet.WeiXing.Business;
using YingNet.WeiXing.DB.Data;
using YingNet.Common.Utils;

namespace YingNet.WeiXing.WebApp.manage
{
	/// <summary>
	/// loanOperate ��ժҪ˵����
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

			//�����pre-approve�����,��ô��ProcessCenter����,��״̬�ı�Ϊpre-approved
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
