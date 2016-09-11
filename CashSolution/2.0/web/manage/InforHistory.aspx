<%@ Register TagPrefix="cc1" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<%@ Page language="c#" Codebehind="InforHistory.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.InforHistory" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InforHistory</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" bgColor="#fefefe" border="0">
				<tr>
					<td vAlign="top"><cc1:datagridtable id="DataGridTable1" runat="server" BorderStyle="None" BorderWidth="1px" CellPadding="4"
							PageSize="12" BorderColor="#3366CC" BackColor="White" Width="100%" PageCSS="scrollButton" IsShowFoot="True"
							MaxRecord="0" EnableViewState="False" AllowPaging="True" CssClass="tableGrid" AutoGenerateColumns="False" IsAllowPaging="True">
							<PagerStyle Visible="False" HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" CssClass="gridPager"
								Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
							<EditItemStyle CssClass="gridEditItem"></EditItemStyle>
							<FooterStyle ForeColor="#003399" CssClass="gridFooter" BackColor="#66CCFF"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" CssClass="gridSelectedItem" BackColor="#009999"></SelectedItemStyle>
							<ItemStyle ForeColor="#003399" CssClass="gridItem" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" CssClass="gridHeader" BackColor="#00FF33"></HeaderStyle>
							<Columns>
								<asp:BoundColumn DataField="huiSid" HeaderText="Number"></asp:BoundColumn>
								<asp:BoundColumn DataField="huiName" HeaderText="Username"></asp:BoundColumn>
								<asp:BoundColumn DataField="Employer" HeaderText="Employer/Benefit"></asp:BoundColumn>
								<asp:BoundColumn DataField="EAddress" HeaderText="Address/Office"></asp:BoundColumn>
								<asp:BoundColumn DataField="EPhone" HeaderText="Phone/Contact"></asp:BoundColumn>
								<asp:BoundColumn DataField="Modtime" HeaderText="ModifyTime"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="Detail" DataNavigateUrlField="id" DataNavigateUrlFormatString="InforDetail.aspx?id={0}"
									HeaderText="Detail"></asp:HyperLinkColumn>
							</Columns>
						</cc1:datagridtable><asp:textbox id="txtParamstr" runat="server" Visible="False"></asp:textbox><INPUT id="Hidden1" style="WIDTH: 104px; HEIGHT: 19px" type="hidden" size="12" name="Hidden1"
							runat="server">
						<br>
						<div align="center"><A href="MemberList.aspx">Return</A>
						</div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
