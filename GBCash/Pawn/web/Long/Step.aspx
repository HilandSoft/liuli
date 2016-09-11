<%@ Page language="c#" Codebehind="Step.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Step" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<style type="text/css">
				.word1 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
				.word2 { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
				</style>
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
			<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td>
						<uc1:head id="Head1" runat="server"></uc1:head></td>
				</tr>
			</table>
			<table width="990" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td colspan="3" height="10"></td>
				</tr>
				<tr>
					<td width="5">&nbsp;</td>
					<td width="200" valign="top" align="left">
						<table width="190" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td>
									<img src="images/1_01.gif" width="190" height="18" alt=""></td>
							</tr>
							<tr>
								<td background="images/1_07.gif">
									<table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="20"><div align="center"><img src="images/1_04.gif" width="16" height="10"></div>
											</td>
											<td class="word1">Pre-qualification</td>
										</tr>
										<tr>
											<td width="17%" height="20"><div align="center"></div>
											</td>
											<td width="83%" class="word2">Apply Now
											</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Initial loan information</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">About yourself</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">About your work</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Your bank details</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Application summary</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Submit application</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<img src="images/1_09.gif" width="190" height="5" alt=""></td>
							</tr>
							<tr>
								<td align="center"><br>
									<img src="images/contact2.gif" width="160" height="106" alt=""></td>
							</tr>
						</table>
					</td>
					<td valign="top">
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<TR bgcolor="#cc3300">
								<TD height="30" colSpan="2"><img src="images/pre.jpg" width="400" height="30"></TD>
							</TR>
							<tr>
								<td height="25">&nbsp;</td>
							</tr>
							<tr>
								<td height="25" align="center">
									<asp:checkboxlist id="CheckBoxList1" runat="server" Width="500px">
										<asp:ListItem Value="0">Are you an Australian permanent resident and over 18 years old?</asp:ListItem>
										<asp:ListItem Value="1">Are you a wage or salary earner and take home at least $350 per week?</asp:ListItem>
										<asp:ListItem Value="2">Do you have a bank account in good standing verifying the income deposits?</asp:ListItem>
										<asp:ListItem Value="3">Have you been with your current employer for at least 6 months?</asp:ListItem>
										<asp:ListItem Value="4">Have you been on your current address for at the last 3 months?</asp:ListItem>
										<asp:ListItem Value="5">Have you read and understood Golden Bridge Cash Solution's <a href="../information2.htm" target="_blank">
												Information Statement</a>, <a target="_blank" href="../Information/Form3A.doc">Form 
												3A</a>, <a target="_blank" href="../Information/Credit-Guide.doc">Credit Guide</a>?</asp:ListItem>
									</asp:checkboxlist></td>
							</tr>
							<tr>
								<td height="10">&nbsp;</td>
							</tr>
							<tr>
								<td height="25" align="center"><INPUT id="bnSubmit" type="button" size="22" value="ApplyNow" name="Button1" runat="server">
									<FONT face="宋体">&nbsp; </FONT><INPUT style="WIDTH: 51px; HEIGHT: 24px" type="reset" value="Reset"></td>
							</tr>
							<tr>
								<td height="25">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="3">
						<uc1:bottom id="Bottom1" runat="server"></uc1:bottom></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
