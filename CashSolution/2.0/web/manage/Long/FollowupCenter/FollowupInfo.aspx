<%@ Page language="c#" Codebehind="FollowupInfo.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.Long.FollowupCenter.FollowupInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LongList</title>
		<LINK href="../csslib/yingnet.css" type="text/css" rel="stylesheet">
			<script language="javascript" src="jslib/cal_layers.js"></script>
			<script language="javascript" src="jslib/cal_menu.js"></script>
			<script language="javascript" src="jslib/cal_pop.js"></script>
			<script language="javascript" src="../../jslib/jquery-1.2.6.min.js"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="1" width="70%" align="center" border="0">
				<tr>
					<td colSpan="2" height="25">&nbsp;
						<asp:textbox id="txSid" runat="server" Width="40px" Visible="False"></asp:textbox><asp:textbox id="txPerSid" runat="server" Width="40px" Visible="False"></asp:textbox></td>
				</tr>
				<tr>
					<td colSpan="2">
						<div align="left"></div>
						<div align="left">Document check list(Checked/Incomplete)</div>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<div align="left">
							<table cellSpacing="0" cellPadding="1" width="90%" border="1">
								<tr>
									<td align="right" width="45%">ChooseFollowupStatus:</td>
									<td align="left">
										<asp:DropDownList id="ddlChooseFollowupStatus" runat="server"></asp:DropDownList></td>
								</tr>
								<tr>
									<td align="right">RemindEnable</td>
									<td align="left"><asp:checkbox id="cbRemindEnable" Runat="server"></asp:checkbox></td>
								</tr>
								<tr>
									<td align="right">RemindDate(dd/mm/yyyy)</td>
									<td align="left">
										<asp:TextBox id="tbDay" name="tbDay" runat="server" Width="32px"></asp:TextBox>/<asp:TextBox id="tbMonth" name="tbMonth" runat="server" Width="32px"></asp:TextBox>/<asp:TextBox id="tbYear" name="tbYear" runat="server" Width="56px"></asp:TextBox></td>
								</tr>
							</table>
						</div>
						<div style="HEIGHT: 3px"></div>
						<div align="center">&nbsp;<asp:button id="btnSave" runat="server" Text="save"></asp:button>
							<A href="FollowupList.aspx?status=<%=status%>">Return</A></div>
					</td>
				</tr>
				<tr>
					<td height="25"></td>
					<td>&nbsp;
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
