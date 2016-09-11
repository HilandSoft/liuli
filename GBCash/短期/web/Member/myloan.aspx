<%@ Page language="c#" Codebehind="myloan.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.myloan" %>
<%@ Register TagPrefix="uc1" TagName="top2" Src="top2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top1" Src="top1.ascx" %>
<%@ Register TagPrefix="uc1" TagName="leftmenu" Src="leftmenu.ascx" %>
<HTML>
	<HEAD>
		<title>myloan</title> 
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table width="750" border="0" align="center" cellpadding="0" cellspacing="0" height="100%">
				<tr>
					<td colspan="2" style="HEIGHT: 27px"><FONT face="ËÎÌå">
							<uc1:top2 id="Top21" runat="server"></uc1:top2></FONT>
					</td>
				</tr>
				<tr>
					<td valign="top" width="195" align="left" bgcolor="#e8e6df">
						<uc1:leftmenu id="Leftmenu1" runat="server"></uc1:leftmenu>
					</td>
					<td width="556" align="center">
						<table width="100%" height="100%" cellpadding="0" cellspacing="0" border="0" align="center"
							bgColor="#fefefe">
							<tr>
								<td valign="top">
									<%=content%>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
