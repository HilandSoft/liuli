<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Page language="c#" Codebehind="Finish.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Finish" %>
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
											<td width="17%" height="20"><div align="center"></div>
											</td>
											<td width="83%" class="word2">Apply Now
											</td>
										</tr>
										<tr>
											<td height="20"><div align="center"></div>
											</td>
											<td class="word2">Initial loan information</td>
										</tr>
										<tr>
											<td height="20"><div align="center"></div>
											</td>
											<td class="word2">About yourself</td>
										</tr>
										<tr>
											<td height="20"><div align="center"></div>
											</td>
											<td class="word2">About your work</td>
										</tr>
										<tr>
											<td height="20"><div align="center"></div>
											</td>
											<td class="word2">Your bank details</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Application summary</td>
										</tr>
										<tr>
											<td height="20"><div align="center"><img src="images/1_04.gif" width="16" height="10"></div>
											</td>
											<td class="word1">Submit application</td>
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
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD colSpan="2" height="30" bgcolor="#cc3300"><img src="images/step6.gif" width="400" height="30">&nbsp;</TD>
							</TR>
							<tr>
								<td colspan="2" height="15"></td>
							</tr>
							<TR>
								<TD colSpan="2">
								Thank you for your application! Please fax us the signed documents along with:<br>
								-- Two latest pay slips.<br>
								-- 3 months bank account statement received in the last 30 days . <br>
								-- Your Identification card (usually Driver's Licence or Passport).<br>
								-- A utility bill or mortgage documents or lease agreement. Each document to include current address and be current one month before you submit the loan application. </TD>
							</TR>
							<TR>
								<TD colSpan="2">If we do not receive the above information with your application, your loan will not be processed.</TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">
									<DIV align="center"></DIV>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">
									<DIV align="center">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<INPUT id="Submit1" type="submit" value="Finish" name="Submit" runat="server">
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD width="55%">&nbsp;</TD>
								<TD width="45%" height="20">&nbsp;</TD>
							</TR>
						</TABLE>
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
