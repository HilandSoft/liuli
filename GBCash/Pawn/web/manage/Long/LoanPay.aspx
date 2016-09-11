<%@ Page language="c#" Codebehind="LoanPay.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.Long.LoanPay" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LongList</title>
		<LINK href="../csslib/yingnet.css" type="text/css" rel="stylesheet">
			<script language="javascript" src="jslib/cal_layers.js"></script>
			<script language="javascript" src="jslib/cal_menu.js"></script>
			<script language="javascript" src="jslib/cal_pop.js"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="1" cellPadding="1" width="70%" align="center" border="0">
				<tr>
					<td colSpan="2" height="25">&nbsp;
						<asp:textbox id="txSid" runat="server" Visible="False" Width="40px"></asp:textbox><asp:textbox id="txPerSid" runat="server" Visible="False" Width="40px"></asp:textbox></td>
				</tr>
				<tr>
					<td width="28%" height="25">
						<div align="right">Datedue:</div>
					</td>
					<td width="72%">&nbsp;
						<asp:textbox id="txDatedue" runat="server" Width="208px"></asp:textbox></td>
				</tr>
				<tr>
					<td height="25">
						<div align="right">Repaydue:</div>
					</td>
					<td>&nbsp;
						<asp:textbox id="txRepaydue" runat="server" Width="208px">0</asp:textbox></td>
				</tr>
				<tr>
					<td height="25">
						<div align="right">Paid:</div>
					</td>
					<td>&nbsp;
						<asp:textbox id="txPaid" runat="server" Width="208px">0</asp:textbox></td>
				</tr>
				<tr>
					<td height="25">
						<div align="right">Penalty:</div>
					</td>
					<td>&nbsp;
						<asp:textbox id="txPenalty" runat="server" Width="208px">0</asp:textbox></td>
				</tr>
				<tr>
					<td height="25">
						<div align="right">Late Interest Charge:</div>
					</td>
					<td>&nbsp;
						<asp:textbox id="txLateCharge" runat="server" Width="208px">0</asp:textbox></td>
				</tr>
				<tr>
					<td height="25">
						<div align="right">RepayTime:</div>
					</td>
					<td>&nbsp;
						<asp:textbox id="txRepayTime" onclick="popUpCalendar(this, this, 'dd/mm/yyyy');" runat="server"
							Width="208px"></asp:textbox></td>
				</tr>
				<tr>
					<td height="25">
						<div align="right"></div>
					</td>
					<td><asp:button id="bnSave" runat="server" Text=" Save "></asp:button><FONT face="ËÎÌו">&nbsp;&nbsp;&nbsp;
							<asp:button id="bnReturn" runat="server" Text="Return"></asp:button></FONT></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
