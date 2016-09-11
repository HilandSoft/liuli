<%@ Page language="c#" Codebehind="Index2.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Index2" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<script language="javascript">
		function f1(url) {
		var fleft,ftop,width2,height2;
		width2=520;
		height2=350;
		fleft=(window.screen.width-width2)/2;
		ftop=(window.screen.height-height2)/2;
		window.open(url,"","height="+height2+",width="+width2+",top="+ftop+", left="+fleft+",toolbar=0, menubar=0, scrollbars=0, resizable=0,location=0, status=0");
		}
			</script>
	</HEAD>
	<body LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<TABLE BORDER="0" CELLPADDING="0" CELLSPACING="0">
				<TR>
					<TD COLSPAN="5"><uc1:head id="Head1" runat="server"></uc1:head>
					</TD>
					<TD>
						<IMG SRC="images/分隔符.gif" WIDTH="1" HEIGHT="26" ALT=""></TD>
				</TR>
				<TR>
					<TD COLSPAN="5">
						<IMG SRC="images/index_4.gif" WIDTH="1000" HEIGHT="94" ALT=""></TD>
					<TD>
						<IMG SRC="images/分隔符.gif" WIDTH="1" HEIGHT="94" ALT=""></TD>
				</TR>
				<TR>
					<TD ROWSPAN="6">&nbsp;
					</TD>
					<TD COLSPAN="2">
						<IMG SRC="images/index_6.gif" WIDTH="387" HEIGHT="111" ALT=""></TD>
					<TD ROWSPAN="6">&nbsp;
					</TD>
					<TD ROWSPAN="2">
						<IMG SRC="images/index_8.gif" WIDTH="468" HEIGHT="136" ALT=""></TD>
					<TD>
						<IMG SRC="images/分隔符.gif" WIDTH="1" HEIGHT="111" ALT=""></TD>
				</TR>
				<TR>
					<TD COLSPAN="2" ROWSPAN="3" bgcolor="#ffeded" valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td height="25">&nbsp;</td>
							</tr>
							<tr>
								<td height="25">
									<asp:checkboxlist id="CheckBoxList1" runat="server" Width="380px">
										<asp:ListItem Value="0">Are you an Australian permanent resident and over 18 years old?</asp:ListItem>
										<asp:ListItem Value="1">Are you a wage or salary earner and take home at least $350 per week?</asp:ListItem>
										<asp:ListItem Value="2">Do you have a bank account in good standing verifying the income deposits?</asp:ListItem>
										<asp:ListItem Value="3">Have you been with your current employer for at least 6 months?</asp:ListItem>
										<asp:ListItem Value="4">Have you been on your current address for at the last 3 months?</asp:ListItem>
										<asp:ListItem Value="5">Have you read and understood Golden Bridge Cash Solution's <a href="information2.htm" target="_blank">
												Information Statement</a>?</asp:ListItem>
									</asp:checkboxlist></td>
							</tr>
							<tr>
								<td height="25" align="center"><INPUT id="bnSubmit" type="button" size="22" value="ApplyNow" name="Button1" runat="server">
									<FONT face="宋体">&nbsp; </FONT><INPUT style="WIDTH: 51px; HEIGHT: 24px" type="reset" value="Reset"></td>
							</tr>
							<tr>
								<td height="25">&nbsp;</td>
							</tr>
						</table>
					</TD>
					<TD>
						<IMG SRC="images/分隔符.gif" WIDTH="1" HEIGHT="25" ALT=""></TD>
				</TR>
				<TR>
					<TD>
						<IMG SRC="images/index_10.gif" WIDTH="468" HEIGHT="68" ALT=""></TD>
					<TD>
						<IMG SRC="images/分隔符.gif" WIDTH="1" HEIGHT="68" ALT=""></TD>
				</TR>
				<TR>
					<TD ROWSPAN="3">
						<IMG SRC="images/index_11.gif" WIDTH="468" HEIGHT="267" ALT=""></TD>
					<TD>
						<IMG SRC="images/分隔符.gif" WIDTH="1" HEIGHT="194" ALT=""></TD>
				</TR>
				<TR>
					<TD COLSPAN="2">&nbsp;
					</TD>
					<TD>
						<IMG SRC="images/分隔符.gif" WIDTH="1" HEIGHT="34" ALT=""></TD>
				</TR>
				<TR>
					<TD COLSPAN="2" valign="top">
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td>* Terms and conditions are available on application.</td>
							</tr>
							<tr>
								<td>* Subject to verification and final credit assessment.</td>
							</tr>
						</table>
					</TD>
					<TD>
						<IMG SRC="images/分隔符.gif" WIDTH="1" HEIGHT="39" ALT=""></TD>
				</TR>
				<TR>
					<TD COLSPAN="5">
						<uc1:bottom id="Bottom1" runat="server"></uc1:bottom></TD>
					<TD>
					</TD>
				</TR>
				<TR>
					<TD>
						<IMG SRC="images/分隔符.gif" WIDTH="134" HEIGHT="1" ALT=""></TD>
					<TD>
						<IMG SRC="images/分隔符.gif" WIDTH="76" HEIGHT="1" ALT=""></TD>
					<TD>
						<IMG SRC="images/分隔符.gif" WIDTH="311" HEIGHT="1" ALT=""></TD>
					<TD>
						<IMG SRC="images/分隔符.gif" WIDTH="11" HEIGHT="1" ALT=""></TD>
					<TD>
						<IMG SRC="images/分隔符.gif" WIDTH="468" HEIGHT="1" ALT=""></TD>
					<TD></TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
