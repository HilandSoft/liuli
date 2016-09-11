<%@ Register TagPrefix="cc1" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<%@ Page language="c#" Codebehind="openwindow.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.Long.openwindow" %>
<HTML>
	<HEAD>
		<title>openwindow</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
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
								<asp:BoundColumn DataField="Sid" HeaderText="Customer NO"></asp:BoundColumn>
								<asp:BoundColumn DataField="Fname" HeaderText="FirstName"></asp:BoundColumn>
								<asp:BoundColumn DataField="mname" HeaderText="MiddleName"></asp:BoundColumn>
								<asp:BoundColumn DataField="sname" HeaderText="LastName"></asp:BoundColumn>
								<asp:BoundColumn DataField="RegTime" HeaderText="Regtime" DataFormatString="{0:dd/MM/yyyy hh:mm:ss}"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="I have known" DataNavigateUrlField="sid" DataNavigateUrlFormatString="openoperate.aspx?sid={0}"
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
