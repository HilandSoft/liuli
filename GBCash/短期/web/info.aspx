<%@ Page ValidateRequest="false" language="c#" Codebehind="info.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.info" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>info</title> 
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<LINK href="css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftmargin="0" rightmargin="0" topmargin="0" bottommargin="0" bgColor="#fbf2f2">
		<form id="Form1" method="post" runat="server">
			<table align="center" width="350" cellpadding="0" cellspacing="0" border="0">
				<tr>
					<td valign="middle">
						<strong><%=Info%></strong>
					</td>
				</tr>
				<tr>
				<td align=center><a href=# onclick="window.close();">Close</a></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
