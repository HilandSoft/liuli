<%@ Page language="c#" Codebehind="MainTop.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.Long.MainTop" %>
<HTML>
	<HEAD>
		<title></title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style> .wnd_label_normal { FONT-WEIGHT: bold; FONT-SIZE: 14px; CURSOR: hand; COLOR: #0066cc } .wnd_label_hover { FONT-WEIGHT: bold; FONT-SIZE: 14px; CURSOR: hand; COLOR: #ffffff } .wnd_label_active { FONT-WEIGHT: bold; FONT-SIZE: 14px; CURSOR: hand; COLOR: #336699 } NOBR { CURSOR: hand } </style>
		<script language="javascript">
		var current_window = null;
		/**
		* ��Ӧ�����봰�ڱ�ǩ��Ϣ
		*/
		function onOverWndLabel()
		{
			var src = event.srcElement;
			while ( src.tagName != "TABLE" )
			{
				if ( src.tagName == "TD" )
				{
					if ( src.className != "wnd_label_active" )
					{
						src.className = "wnd_label_hover";
					}
					break;
				}
				src = src.parentElement;
			}
		}

		/**
		* ��Ӧ����뿪���ڱ�ǩ��Ϣ
		*/
		function onOutWndLabel()
		{
			var src = event.srcElement;
			while ( src.tagName != "TABLE" )
			{
				if ( src.tagName == "TD" )
				{
					if ( src.className != "wnd_label_active" )
					{
						src.className = "wnd_label_normal";
					}
					break;
				}
				src = src.parentElement;
			}
		}

		/**
		* ��Ӧ��������ڱ�ǩ��Ϣ
		*/
		function onClickWndLabel()
		{
			var src = event.srcElement;
			while ( src.tagName != "TABLE" )
			{
				if ( src.tagName == "TD" )
				{
					if ( src.className != "wnd_label_active" )
					{
						var cells = wnd_labels.rows[ 0 ].cells, len = cells.length;
						for ( var i = 0; i < len; ++i )
						{
							if ( cells[ i ].id == src.id )
							{
								cells[ i ].className = "wnd_label_active";
							}
							else
							{
								cells[ i ].className = "wnd_label_normal";
							}
						}

						// �����ϴ���, ��ʾ�´���
						  
					
						current_window = src.id;
					}
					break;
				}
				src = src.parentElement;
			}
		
			switch ( src.id )
			{
		    
			case "a0":
				window.parent.window.document.all.main.src = "MainHome.aspx";
				break;

			case "a1":
				//window.parent.window.document.all.main.src = "InfoFrameSet.aspx";
				window.parent.window.document.all.main.src = "InfoFrame.htm";
				break;
			
			case "a5":
				window.parent.window.document.all.main.src = "VideoList.aspx";
				break;
			
			case "a2":
				window.parent.window.document.all.main.src = "ProductFrame.htm";
				break;
			
			case "a4":
				window.parent.window.document.all.main.src = "Gbe.aspx";
				break;
				
			case "a3":
				window.parent.window.document.all.main.src = "agreeinput.aspx";
				break;
			case "a6":
				window.parent.window.document.all.main.src = "UserManage.Aspx";
				break;
				
			case "a7":
				window.parent.window.document.all.main.src = "MemberList.aspx";
				break;
				
			case "a8":
				window.parent.window.document.all.main.src = "SystemInfo.aspx";
				break;
				
			case "a9":
				window.parent.window.document.all.main.src = "MemberHistory.aspx";
				break;
			
			
			case "a10":
				window.parent.window.document.all.main.src = "renew.aspx";
				break;
			case "a11":
				window.parent.window.document.all.main.src = "LongList.aspx";
				break;
			case "a12":
				window.parent.window.document.all.main.src = "ParamsSet.aspx";
				break;
			case "b2":
				window.parent.window.document.all.main.src = "LProcessList.aspx";
				break;
			case "b3":
				window.parent.window.document.all.main.src = "LFollowupList.aspx";
				break;
			}
		}
		</script>
	</HEAD>
	<body style="BORDER-RIGHT:0px;BORDER-TOP:0px;MARGIN:0px;BORDER-LEFT:0px;BORDER-BOTTOM:0px">
		<table width="100%" height="109" border="0" cellpadding="0" cellspacing="0">
			<tr height="77">
				<td height="77" background="images/titlebk.gif" width='28'>&nbsp;&nbsp;&nbsp;&nbsp;</td>
				<td width="277"><img src="images/title1.gif" width="277" border="0"></td>
				<td background="images/titlebk.gif">&nbsp;</td>
				<td background="images/titlebk.gif" align="right"><img src="images/title2.gif" width="321"></td>
			</tr>
			<tr height="32">
				<td background="images/titlec1.gif">&nbsp;</td>
				<td colspan="2" background="images/titlec1.gif"><script language="JavaScript">
										var enable=0; today=new Date();
										var day; var date;
										var time_start = new Date();
										var clock_start = time_start.getTime();
										if(today.getDay()==0)  day="Sunday"
										if(today.getDay()==1)  day="Monday"
										if(today.getDay()==2)  day="Tuesday"
										if(today.getDay()==3)  day="Wednesday"
										if(today.getDay()==4)  day="Thursday"
										if(today.getDay()==5)  day="Friday"
										if(today.getDay()==6)  day="Saturday"
										date=(today.getYear())+"-"+(today.getMonth()+1)+"-"+today.getDate()+"  ";
										
										document.write("<span style='font-size: 9pt;color:#000080;'>"+date);
										document.write(day+"&nbsp;&nbsp;</font></span>");
					</script>
					<asp:Literal id="litLogUserAccount" Runat="server"></asp:Literal></td>
				<td colspan="2" background="images/titlec1.gif" style="FONT-SIZE:14px" align="right"><table id="wnd_labels" border="0" cellpadding="0" cellspacing="0">
						<tr>
							<asp:Literal ID="litMenu" Runat="server"></asp:Literal>
							<td width="15">&nbsp;</td>
						</tr>
					</table>
				</td>
			</tr>
		</table>
	</body>
</HTML>
