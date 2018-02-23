<%@ Page language="c#" Codebehind="MainTop.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.AdminManage.MainTop" %>
<HTML>
	<HEAD>
		<title>
			<%=WebAppTitle%>
		</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
<style>a:link,A:visited { 
color: #333333; text-decoration: none 
}  
a:hover { 
color: #333333; text-decoration: none 
}  </style>
		<script language="javascript">

		function jumps(targetWindow){
				window.parent.frames["main"].location.href = targetWindow;
			}
		</script>
	</HEAD>
	<body style="BORDER-RIGHT:0px;BORDER-TOP:0px;MARGIN:0px;BORDER-LEFT:0px;BORDER-BOTTOM:0px">
		<table width="100%" height="109" border="0" cellpadding="0" cellspacing="0">
			<tr height="77">
				<td height="77" background="../images/titlebk.gif" width='28'>&nbsp;&nbsp;&nbsp;&nbsp;</td>
				<td width="277"><img src="../images/title1.gif" width="277" border="0"></td>
				<td background="../images/titlebk.gif">&nbsp;</td>
				<td background="../images/titlebk.gif" align="right"><img src="../images/title2.gif" width="321"></td>
			</tr>
			<tr height="32">
				<td background="../images/titlec1.gif">&nbsp;</td>
				<td colspan="2" background="../images/titlec1.gif"><script language="JavaScript">
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
					</script><asp:Literal ID="litLogUserAccount" Runat="server"></asp:Literal></td>
				<td colspan="2" background="../images/titlec1.gif" style="FONT-SIZE:14px" align="right"><table id="wnd_labels" border="0" cellpadding="0" cellspacing="0">
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
