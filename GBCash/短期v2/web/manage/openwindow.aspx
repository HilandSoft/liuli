<%@ Page language="c#" Codebehind="openwindow.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.openwindow" %>
<%@ Register TagPrefix="cc1" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<HTML>
	<HEAD>
		<title>openwindow</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" bgColor="#fefefe" border="0" align="center">
				<tr>
					<td vAlign="top" align="center"><cc1:datagridtable id="DataGridTable1" runat="server" IsAllowPaging="True" AutoGenerateColumns="False"
							CssClass="tableGrid" AllowPaging="True" EnableViewState="False" MaxRecord="0" IsShowFoot="True" PageCSS="scrollButton" Width="98%"
							BackColor="White" BorderColor="#3366CC" PageSize="12" CellPadding="4" BorderWidth="1px" BorderStyle="None">
							<PagerStyle Visible="False" HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" CssClass="gridPager"
								Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
							<EditItemStyle CssClass="gridEditItem"></EditItemStyle>
							<FooterStyle ForeColor="#003399" CssClass="gridFooter" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" CssClass="gridSelectedItem" BackColor="#009999"></SelectedItemStyle>
							<ItemStyle ForeColor="#003399" CssClass="gridItem" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" CssClass="gridHeader" BackColor="#99CCCC"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="huiSid" HeaderText="MemberID"></asp:BoundColumn>
								<asp:BoundColumn DataField="Username" HeaderText="Username"></asp:BoundColumn>
								<asp:BoundColumn DataField="type" HeaderText="Type"></asp:BoundColumn>
								<asp:BoundColumn DataField="regtime" HeaderText="Time"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="I have known" DataNavigateUrlField="id" DataNavigateUrlFormatString="openoperate.aspx?id={0}"
									HeaderText="Operate"></asp:HyperLinkColumn>
							</Columns>
						</cc1:datagridtable><asp:textbox id="txtParamstr" runat="server" Visible="False"></asp:textbox></td>
				</tr>
				<tr>
					<td align="center"><a href="#" onclick="window.close();">Close</a></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
