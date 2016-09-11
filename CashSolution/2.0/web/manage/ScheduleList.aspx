<%@ Register TagPrefix="cc1" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<%@ Page language="c#" Codebehind="ScheduleList.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.ScheduleList" %>
<HTML>
	<HEAD>
		<title>ScheduleList</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" bgColor="#fefefe" border="0">
				<tr>
					<td style="HEIGHT: 54px">
						<table width="99%" cellpadding="0" cellspacing="0" border="0">
							<tr>
								<td valign="top"><FONT face="ËÎÌו">HuiSid&nbsp;&nbsp;&nbsp; </FONT>&nbsp;
									<asp:TextBox id="txKey" runat="server"></asp:TextBox><FONT face="ËÎÌו">&nbsp; </FONT>
									<asp:Button id="Button1" runat="server" Text="Query"></asp:Button>&nbsp;<FONT face="ËÎÌו">&nbsp;&nbsp;&nbsp;SQL 
										Command:&nbsp;
										<asp:TextBox id="txsql" runat="server" Width="392px"></asp:TextBox>&nbsp;
										<asp:Button id="Button2" runat="server" Text="Execute"></asp:Button>
										<asp:Button id="Button3" runat="server" Text="PrintOut"></asp:Button></FONT></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="top"><cc1:datagridtable id="DataGridTable1" runat="server" IsAllowPaging="True" CssClass="tableGrid" AllowPaging="True"
							EnableViewState="False" MaxRecord="0" IsShowFoot="True" PageCSS="scrollButton" Width="100%" BackColor="White"
							BorderColor="#3366CC" PageSize="12" CellPadding="4" BorderWidth="1px" BorderStyle="None">
							<PagerStyle Visible="False" HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" CssClass="gridPager"
								Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
							<EditItemStyle CssClass="gridEditItem"></EditItemStyle>
							<FooterStyle ForeColor="#003399" CssClass="gridFooter" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" CssClass="gridSelectedItem" BackColor="#009999"></SelectedItemStyle>
							<ItemStyle ForeColor="#003399" CssClass="gridItem" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" CssClass="gridHeader" BackColor="#99CCCC"></HeaderStyle>
						</cc1:datagridtable><asp:textbox id="txtParamstr" runat="server" Visible="False"></asp:textbox></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
