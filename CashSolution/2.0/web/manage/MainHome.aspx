<%@ Page language="c#" Codebehind="MainHome.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.MainHome" %>
<HTML>
	<HEAD>
		<title>
			<%=WebAppTitle%>
		</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="../csslib/text.css" rel="stylesheet" type="text/css">
	</HEAD>
	<body style="BORDER-RIGHT:0px;BORDER-TOP:0px;MARGIN:0px;BORDER-LEFT:0px;BORDER-BOTTOM:0px">
		<form id="MyFrom" method="post" runat="server">
			<table width="100%" border="0" cellpadding="0" cellspacing="0" height="100%" ID="Table1"
				style="BORDER-RIGHT:#336699 1px solid; BORDER-TOP:#336699 1px solid; BORDER-LEFT:#336699 1px solid; BORDER-BOTTOM:#336699 1px solid">
				<tr>
					<td width="250" valign="top"><table width="100%" height="100%" cellpadding="8" style="BORDER-RIGHT:#336699 1px solid; BORDER-TOP:0px; FONT-SIZE:14px; BORDER-LEFT:0px; BORDER-BOTTOM:0px"
							border="0" cellspacing="0" ID="Table2">
							<tr height="26">
								<td colspan="2" height="25" background="images/left_top_title_bk.gif" align="center">Welcome!</td>
							</tr>
							<tr height="10">
								<td></td>
								<td></td>
							</tr>
							<tr>
								<td></td>
								<td><FONT face="宋体"></FONT></td>
							</tr>
						</table>
					</td>
					<td height="100%" bgcolor="#ffffff" valign="top">
						<br>
						<nobr>&nbsp;&nbsp;<img src="images/setup_1.gif" border="0"></nobr>
						<br>
						<br>
						<TABLE width="635" align="center" style="WIDTH: 635px; HEIGHT: 138px">
							<TBODY>
								<TR>
									<TD style="WIDTH: 233px" height="32"><FONT face="宋体">Old Password</FONT></TD>
									<TD colSpan="8" height="32"><FONT face="宋体"><asp:TextBox id="txtOldPass" runat="server" TextMode="Password" Width="100px" EnableViewState="False"></asp:TextBox></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 233px; HEIGHT: 32px"><FONT face="宋体"><FONT face="宋体">New Password</FONT></FONT></TD>
									<TD style="HEIGHT: 32px" colSpan="8"><FONT face="宋体"><asp:TextBox id="txtNewPass" runat="server" TextMode="Password" Width="100px" EnableViewState="False"></asp:TextBox></FONT></TD>
								</TR>
								<TR>
									<TD style="WIDTH: 233px; HEIGHT: 32px"><FONT face="宋体"><FONT face="宋体">Confirm Password</FONT></FONT></TD>
									<TD style="HEIGHT: 32px" colSpan="8"><asp:TextBox id="txtNewCpass" runat="server" TextMode="Password" Width="100px" EnableViewState="False"></asp:TextBox></TD>
								</TR>
								<TR>
									<TD align="center" colSpan="9"><asp:Button id="btnSave" runat="server" Text=" Modify " CssClass="toolbar"></asp:Button>
									</TD>
								</TR>
							</TBODY>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td colspan="2" height="30" background="images/web005.jpg" align="right" style="FONT-SIZE:14px">WebSite 
						MISv1.0&nbsp;&nbsp;&nbsp;&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
