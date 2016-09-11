<%@ Page language="c#" Codebehind="MemberLogin.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.MemberLogin" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MemberLogin</title> 
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<LINK href="css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="390" height="136" border="0" cellpadding="0" cellspacing="0" style="WIDTH: 390px; HEIGHT: 136px">
				<tr>
					<td colspan="2">Please enter your username and password. If you have forgotten your 
						username or password please click here.</td>
				</tr>
				<tr>
					<td style="WIDTH: 72px">Username:</td>
					<td><input name="textfield23" type="text" size="10"></td>
				</tr>
				<tr>
					<td>Password:</td>
					<td><input name="textfield24" type="password" size="10"></td>
				</tr>
				<tr>
				<td colspan="2" align="center"> <input type="submit" name="Submit" value="Submit">
				   ¡¡¡¡ 
				   <input type="reset" name="Submit2" value="Reset"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
