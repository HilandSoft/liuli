<%@ Page language="c#" Codebehind="loandetail.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.loandetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>loandetail</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="1000" height="100%" cellpadding="0" cellspacing="0" border="0" align="center"
				bgColor="#fefefe">
				<tr>
					<td valign="top">
											<%=content%>
					</td>
				</tr>
				<tr>
				<td align=center><br>
				<a href=MemberList.aspx>Return</a>
				</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
