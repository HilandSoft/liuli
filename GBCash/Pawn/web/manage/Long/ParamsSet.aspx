<%@ Page language="c#" Codebehind="ParamsSet.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.Long.ParamsSet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MemberDetail</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<LINK href="../csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体">
			</FONT><FONT face="宋体"></FONT>
			<br>
			<table width="100%" border="0" align="center" cellPadding="1" cellSpacing="1" bgcolor="#66ff00">
				<tr bgColor="#33ffff">
					<td height="25">Months</td>
					<td>NR-Weekly</td>
					<td width="63">NR-F'nighly</td>
					<td>NR-Bi-montyly</td>
					<td>NR-montyly</td>
					<td>PS-Weekly</td>
					<td>PS-F'nighly</td>
					<td>PS-Bi-montyly</td>
					<td>PS-montyly</td>
					<td>RD-Weekly</td>
					<td>RD-F'nighly</td>
					<td>RD-Bi-montyly</td>
					<td>RD-montyly</td>
				</tr>
				<tr bgcolor="#ffffff">
					<td height="25">
						<asp:DropDownList id="DropDownList1" runat="server" AutoPostBack="True">
							<asp:ListItem Value="3">3 Months</asp:ListItem>
							<asp:ListItem Value="4">4 Months</asp:ListItem>
							<asp:ListItem Value="5">5 Months</asp:ListItem>
							<asp:ListItem Value="6">6 Months</asp:ListItem>
							<asp:ListItem Value="7">7 Months</asp:ListItem>
							<asp:ListItem Value="8">8 Months</asp:ListItem>
							<asp:ListItem Value="9">9 Months</asp:ListItem>
							<asp:ListItem Value="10">10 Months</asp:ListItem>
							<asp:ListItem Value="11">11 Months</asp:ListItem>
							<asp:ListItem Value="12">12 Months</asp:ListItem>
						</asp:DropDownList></td>
					<td>
						<asp:textbox id="txNrW" runat="server" Width="55px"></asp:textbox></td>
					<td width="63">
						<asp:textbox id="txNrF" runat="server" Width="55px"></asp:textbox></td>
					<td>
						<asp:textbox id="txNrB" runat="server" Width="55px"></asp:textbox></td>
					<td>
						<asp:textbox id="txNrM" runat="server" Width="55px"></asp:textbox></td>
					<td>
						<asp:textbox id="txPsW" runat="server" Width="55px"></asp:textbox></td>
					<td>
						<asp:textbox id="txPsF" runat="server" Width="55px"></asp:textbox></td>
					<td>
						<asp:textbox id="txPsB" runat="server" Width="55px"></asp:textbox></td>
					<td>
						<asp:textbox id="txPsM" runat="server" Width="55px"></asp:textbox></td>
					<td>
						<asp:textbox id="txRdW" runat="server" Width="55px"></asp:textbox></td>
					<td>
						<asp:textbox id="txRdF" runat="server" Width="55px"></asp:textbox></td>
					<td>
						<asp:textbox id="txRdB" runat="server" Width="55px"></asp:textbox></td>
					<td>
						<asp:textbox id="txRdM" runat="server" Width="55px"></asp:textbox></td>
				</tr>
				<tr bgcolor="#ffffff">
					<td height="25" colSpan="13">
						<div align="center">
							<asp:button id="bnSave" runat="server" Text="Save"></asp:button></div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
