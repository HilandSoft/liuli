<%@ Page language="c#" Codebehind="MemberLoadNotes.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.MemberLoadNotes" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MemberLoadNotes</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="70%" align="center" bgColor="#fefefe" border="0">
				<tr>
					<td><STRONG>Member Loan Notes: </STRONG>
					</td>
				</tr>
				<tr>
					<td>
						<asp:TextBox id="txtNoteDisplay" runat="server" TextMode="MultiLine" Width="616px" Height="352px"></asp:TextBox>
					</td>
				</tr>
				<tr>
					<td>
						<div align="center">
							<asp:LinkButton id="EditButton" runat="server">Save</asp:LinkButton>&nbsp; 
							&nbsp;&nbsp; &nbsp;
							<asp:HyperLink ID="returnButton" runat="server">Return</asp:HyperLink></div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
