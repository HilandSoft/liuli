<%@ Page language="c#" Codebehind="login.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.login" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>login</title>
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		
					<form id="Form1" method="post" runat="server">
						<table cellSpacing="0" cellPadding="0" width="300" border="0">
				<tr>
					<td width="100">Username:
					</td>
					<td width="200"><input id="txUsername" type="text" size="20" name="textfield" runat="server"></td>
				</tr>
				<tr>
					<td>Password:
					</td>
					<td><input id="txPassword" type="password" size="20" name="textfield2" runat="server"></td>
				</tr>
				<tr>
					<td colSpan="2">
						<div align="center"><input id="Button1" type="button" value="Submit" name="Submit" runat="server">
							<input type="reset" value="Reset" name="Submit2">
						</div>
					</td>
				</tr>
			</table>
					</form>
				
	</body>
</HTML>
