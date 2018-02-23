<%@ Page language="c#" Codebehind="ExeTable.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.ExeTable" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ExeTable</title>
		<LINK href="../css/css1.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<FONT face="ËÎÌו">
				<asp:TextBox id="TextBox1" runat="server" Width="800px" Height="100px" TextMode="MultiLine"></asp:TextBox><BR>
			</FONT>
			<asp:DataGrid id="DataGrid1" runat="server" Width="95%"></asp:DataGrid>
			<br>
			<asp:Button id="Button1" runat="server" Text="Button"></asp:Button>
		</form>
	</body>
</HTML>
