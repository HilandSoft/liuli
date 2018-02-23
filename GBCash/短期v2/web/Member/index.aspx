<%@ Page language="c#" Codebehind="index.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.index" %>
<%@ Register TagPrefix="uc1" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top" Src="top.ascx" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>index</title> 
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table width="750" border="0" align="center" cellpadding="0" cellspacing="0" height="100%">
				<tr>
					<td colspan="2" style="HEIGHT: 27px">
						<uc1:top id="Top1" runat="server"></uc1:top>
					</td>
				</tr>
				<tr>
					<td valign="top" width="195" align="left" bgcolor="#e8e6df">
						<uc1:leftmenu id="Leftmenu1" runat="server"></uc1:leftmenu>
					</td>
					<td width="556">
						<iframe id="right" name="right" runat="server" frameborder="0" width="100%" height="100%"
							scrolling="auto" src="info.aspx"></iframe>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
