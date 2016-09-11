<%@ Register TagPrefix="uc1" TagName="top2" Src="top2.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top1" Src="top1.ascx" %>
<%@ Register TagPrefix="uc1" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Page language="c#" Codebehind="myloan2.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.myloan2" %>
<%@ Register TagPrefix="cc1" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<HTML>
	<HEAD>
		<title>myloan</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table width="750" border="0" align="center" cellpadding="0" cellspacing="0" height="100%">
				<tr>
					<td colspan="2" style="HEIGHT: 27px"><FONT face="??им?">
							<uc1:top2 id="Top21" runat="server"></uc1:top2></FONT>
					</td>
				</tr>
				<tr>
					<td valign="top" width="195" align="left" bgcolor="#e8e6df">
						<uc1:leftmenu id="Leftmenu1" runat="server"></uc1:leftmenu>
					</td>
					<td width="556" align="center" valign="top">
						<table width="100%" height="100%" cellpadding="0" cellspacing="0" border="0" align="center"
							bgColor="#fefefe">
							<tr>
								<td valign="top">
									<cc1:DataGridTable id="DataGridTable1" runat="server" PageCSS="scrollButton" StartPage="Head" PrevPage="Prev"
										IsShowFoot="True" MaxRecord="0" EnableViewState="False" AllowPaging="True" CssClass="tableGrid"
										AutoGenerateColumns="False" IsAllowPaging="True" NextPage="Next" EndPage="End" Width="98%" BorderStyle="None"
										BorderWidth="0px" ShowHeader="False" PageSize="3">
										<PagerStyle Visible="False" CssClass="gridPager"></PagerStyle>
										<AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
										<EditItemStyle CssClass="gridEditItem"></EditItemStyle>
										<FooterStyle CssClass="gridFooter"></FooterStyle>
										<SelectedItemStyle CssClass="gridSelectedItem"></SelectedItemStyle>
										<ItemStyle CssClass="gridItem"></ItemStyle>
										<HeaderStyle CssClass="gridHeader"></HeaderStyle>
										<Columns>
											<asp:BoundColumn DataField="id"></asp:BoundColumn>
										</Columns>
									</cc1:DataGridTable><asp:textbox id="txtParamstr" runat="server" Visible="False"></asp:textbox>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
