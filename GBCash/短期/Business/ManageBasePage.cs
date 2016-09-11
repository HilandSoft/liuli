using System;
using System.Web;
using YingNet.Common;
using System.Collections;
using YingNet.WeiXing.DB.Data;

namespace YingNet.WeiXing.Business
{

	public class ManageBasePage:CommonBasePage
	{
		public ManageBasePage():base(){}
		
		public string WebAppTitle 
		{
			get
			{
				return "CashSolution Manage Console";
			}

		}
		private SystemRoles systemRole= SystemRoles.Manage;
		/// <summary>
		/// ��¼�û��Ľ�ɫ
		/// </summary>
		public SystemRoles SystemRole
		{
			get{return this.systemRole;}
			set{this.systemRole= value;}
		}
		
		private int systemUserID = 0;
		/// <summary>
		/// ��¼�û���ID
		/// </summary>
		public int SystemUserID
		{
			get{return this.systemUserID;}
			set{this.systemUserID= value;}
		}

		private string systemUserName= string.Empty;
		/// <summary>
		/// ��¼�û�������
		/// </summary>
		/// <remarks>����Ϊ�û���ʵ�����ǳƵ�</remarks>
		public string SystemUserName
		{
			get{return this.systemUserName;}
			set{this.systemUserName= value;}
		}

		private string systemUserAccount= string.Empty;
		/// <summary>
		/// ��¼�û����˻�
		/// </summary>
		public string SystemUserAccount
		{
			get{return this.systemUserAccount;}
			set{this.systemUserAccount= value;}
		}
	
//		/// <summary>
//		/// �û�id
//		/// </summary>
//		private int m_sessionUID;
//		public int SessionUID
//		{
//			get { return m_sessionUID; }
//		}
//
//		/// <summary>
//		/// �û��˺�
//		/// </summary>
//		private string m_sessionAccount;
//		public string SessionAccount 
//		{
//			get { return m_sessionAccount; }
//		}
//
//		/// <summary>
//		/// �û�����
//		/// </summary>
//		private string m_sessionName;
//		public string SessionName 
//		{
//			get { return m_sessionName; }
//		}

//		/// <summary>
//		/// Ȩ��
//		/// </summary>
//		private Hashtable m_sessionPermit;
//		public Hashtable SessionPermit
//		{
//			get { return m_sessionPermit; }
//		}

		/// <summary>
		/// ����ҳ�����ְ��Ȩ��,ְ��Ȩ�޿���','�ָ�
		/// </summary>
		private string m_code = "";//AdminModuleBN.NOPERM;
		public string Code 
		{
			get { return m_code; }
			set { m_code = value; }
		}

		/// <summary>
		/// ���ǻ���
		/// </summary>
		/// <param name="e"></param>
		protected override void OnInit(EventArgs e)
		{
			this.Response.Expires = 0;
			base.OnInit(e);
			CheckLogin();
			CheckPerm();
		}

		/// <summary>
		/// �ж��Ƿ��¼
		/// </summary>
		protected void CheckLogin () 
		{
			string userIDString= HttpContext.Current.Request.Cookies["SystemUserID"].Value ;
			int userID=0;
			if(userIDString!=null && userIDString!= string.Empty)
			{
				userID= Convert.ToInt32(userIDString);
			}
			//SystemCookies systemCookies=new SystemCookies();
			//systemCookies.Load();

			if(userID<=0)
			{
				Response.Redirect("NotLogin.aspx");
			}
			else
			{
				this.SystemUserAccount= HttpContext.Current.Request.Cookies["SystemUserAccount"].Value;//systemCookies.SystemUserAccount;
				this.SystemUserID= userID;// systemCookies.SystemUserID;
				this.SystemUserName=  HttpContext.Current.Request.Cookies["SystemUserName"].Value;//systemCookies.SystemUserName;
				//this.SystemRole=(SystemRoles) Enum.Parse(typeof( SystemRoles), systemCookies.SystemRole);
			}

			/*
			//û�е�¼
			if (Session[BaseLib.SESSION_USER_UID] == null) 
			{
				Response.Redirect( "NotLogin.aspx" );
			} 
			else 
			{
				m_sessionUID    = Convert.ToInt32( Session[BaseLib.SESSION_USER_UID] );
				m_sessionName   = Session[BaseLib.SESSION_USER_NAME].ToString();
				m_sessionAccount= Session[BaseLib.SESSION_USER_ACCOUNT].ToString();
				//m_sessionPermit = (Hashtable)Session[BaseLib.SESSION_USER_PERMIT];
			}
			*/
		}
		/// <summary>
		/// �ж��û�Ȩ��
		/// </summary>
		protected void CheckPerm () 
		{
			//TODO:��Ҫ���Ȩ���ж�
			
			
			//������ԭ����Ȩ���ж���ϵ,��ʱ����ʹ��
			/*
			if ( SessionAccount != "admin" )
			{
				if ( !Code.Equals("") ) 
				{
					if( !m_sessionPermit.ContainsKey(Code) )
					{
						Response.Redirect("/NotPermit.aspx");
						//Response.Write("<script>alert('�Բ�������Ȩ�޲��㣡')</script>");
					}
				}
			}
			*/
		}

		#region		���´���

		protected void ShowDialog (string url, string height, string width) 
		{
			Response.Write("<script language='javascript'>");
			Response.Write("window.showModalDialog('" + url + "','','height: "+height+"; width: "+width+"; edge: Raised; center: Yes; help: No; resizable: No; status: No;');");
			Response.Write("</script>");
		}
		protected void ShowDialog (string url, string location, string height, string width) 
		{
			Response.Write("<script language='javascript'>");
			Response.Write("window.showModalDialog('" + url + "','','height: "+height+"; width: "+width+"; edge: Raised; center: Yes; help: No; resizable: No; status: No;');");
			Response.Write("window.location = '"+location+"';");
			Response.Write("</script>");
		}
		/// <summary>
		/// �����´���
		/// </summary>
		/// <param name="url"></param>
		protected void ShowWindow (string url, string height, string width) 
		{
			Response.Write("<script language='javascript'>");
			Response.Write("window.open('" + url + "',null,'"+
				"height=" + height + ",width=" + width +
				",left=((window.screen.width-"+width+")/2)"+
				",channelmode=no,directories=no,fullscreen=no,location=no,menubar=no,resizable=no,scrollbars=no,status=no,titlebar=no,toolbar=no');");
			Response.Write("</script>");
		}
		/// <summary>
		/// �����´���
		/// </summary>
		/// <param name="url"></param>
		protected void ShowWindow (string url, string location, string height, string width) 
		{
			if (location == "")
			{
				ShowWindow(url, height, width);
				return;
			}
			Response.Write("<script language='javascript'>");
			Response.Write("window.open('" + url + "',null,'"+
				"height=" + height + ",width=" + width +
				",left=((window.screen.width-"+width+")/2)"+
				",channelmode=no,directories=no,fullscreen=no,location=no,menubar=no,resizable=no,scrollbars=no,status=no,titlebar=no,toolbar=no');");
			Response.Write("window.location = '"+location+"';");
			Response.Write("</script>");
		}

		#endregion
	}

}
