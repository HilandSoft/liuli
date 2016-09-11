<%@ Page language="c#" Codebehind="SystemInfo.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.SystemInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>SystemInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table width="600" border="0" cellspacing="2" cellpadding="2" align="center">
				<tr>
					<td style="WIDTH: 309px">&nbsp;</td>
				</tr>
				<tr>
					<td width="309" style="WIDTH: 309px" valign="middle"><img src="../images/infoimage/1.GIF" width="131" height="23"></td>
					<td width="450">&nbsp;
						<asp:TextBox id="percentage" runat="server" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 309px"><img src="../images/infoimage/2.GIF" width="113" height="22"></td>
					<td>&nbsp;
						<asp:TextBox id="upperlimit" runat="server" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 309px"><img src="../images/infoimage/3.GIF" width="111" height="22"></td>
					<td>&nbsp;
						<asp:TextBox id="upperlimit2" runat="server" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 309px"><img src="../images/infoimage/4.GIF" width="106" height="23"></td>
					<td>&nbsp;
						<asp:TextBox id="installment" runat="server" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 309px"><img src="../images/infoimage/5.GIF" width="104" height="21"></td>
					<td>&nbsp;
						<asp:TextBox id="term" runat="server" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 309px"><img src="../images/infoimage/6.GIF" width="98" height="21"></td>
					<td>&nbsp;
						<asp:TextBox id="lowerlimit" runat="server" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 309px"><img src="../images/infoimage/7.GIF" width="117" height="22"></td>
					<td>&nbsp;
						<asp:TextBox id="lowerlimit2" runat="server" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 309px"><img src="../images/infoimage/8.GIF" width="116" height="22"></td>
					<td>&nbsp;
						<asp:TextBox id="frequency" runat="server" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 309px"><img src="../images/infoimage/9.GIF" width="120" height="21"></td>
					<td>&nbsp;
						<asp:TextBox id="interest" runat="server" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 309px"><img src="../images/infoimage/10.GIF" width="114" height="23"></td>
					<td>&nbsp;
						<asp:TextBox id="poundage" runat="server" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 309px"><img src="../images/infoimage/11.GIF" width="186" height="23"></td>
					<td>&nbsp;
						<asp:TextBox id="yanqinum" runat="server" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 309px"><img src="../images/infoimage/12.GIF" width="214" height="21"></td>
					<td>&nbsp;
						<asp:TextBox id="datediffw" runat="server" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 309px"><img src="../images/infoimage/13.GIF" width="216" height="21"></td>
					<td>&nbsp;
						<asp:TextBox id="datedifff" runat="server" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 309px"><img src="../images/infoimage/14.GIF" width="210" height="21"></td>
					<td>&nbsp;
						<asp:TextBox id="datediffm" runat="server" Width="152px"></asp:TextBox></td>
				</tr>
				<tr>
					<td style="WIDTH: 309px">&nbsp;</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td colspan="2"><div align="center">
							<input type="submit" name="Submit" value="Submit" id="Submit1" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
							&nbsp; <input type="reset" name="Submit2" value="Reset">
						</div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
