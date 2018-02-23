<%@ Page language="c#" Codebehind="loanpay2.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.loanpay2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>loanpay2</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="jslib/commCheck.js" type="text/javascript"></script>
		<script language="javascript" src="jslib/cal_layers.js"></script>
		<script language="javascript" src="jslib/cal_menu.js"></script>
		<script language="javascript" src="jslib/cal_pop.js"></script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="800" border="0">
				<tr>
					<td colSpan="2"><strong>Pay and Penalty&nbsp;</strong></td>
				</tr>
				<tr>
					<td width="151">Application Date: <INPUT id="Hidden1" style="WIDTH: 16px; HEIGHT: 19px" type="hidden" size="1" name="Hidden1"
							runat="server">
					</td>
					<td width="649"><%=RTime%></td>
				</tr>
				<tr>
					<td>Loan Amount:
					</td>
					<td><%=Loan%></td>
				</tr>
				<tr>
					<td align="center" colSpan="2">
						<%=content%>
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><br>
						<table width="100%" cellpadding="0" cellspacing="0" border="0">
							<tr>
								<td width="30%" align="center"><asp:button id="Button1" runat="server" Text="Submit"></asp:button></td>
								<td width="30%" align="center">
									<asp:Button id="Button2" runat="server" Text="Update Datedue"></asp:Button></td>
								<td width="30%" align="center">
									<asp:Button id="Button3" runat="server" Text="Update Repaydue"></asp:Button></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
