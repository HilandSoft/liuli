<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<%@ Page language="c#" Codebehind="ContactUs.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Member.ContactUs" %>
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<script language="javascript" src="../../jslib/commCheck.js" type="text/javascript"></script>
			<style type="text/css">.word1 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	.word2 { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	A.word3:link { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	A.word3:hover { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	A.word3:visited { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	A.word3:active { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	</style>
	</HEAD>
	<body leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td><uc1:head id="Head1" runat="server"></uc1:head></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="990" align="center" border="0">
				<tr>
					<td colspan="3" height="10"></td>
				</tr>
				<tr>
					<td width="5">&nbsp;</td>
					<td width="200" valign="top" align="left">
						<table cellSpacing="0" cellPadding="0" width="190" border="0">
							<tr>
								<td><IMG height="18" alt="" src="images/1_01.gif" width="190"></td>
							</tr>
							<tr>
								<td background="images/1_07.gif">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td width="17%" height="20">
												<div align="center"></div>
											</td>
											<td width="83%">
												<a href="Index.aspx" class="word3">Customer Details</a>
											</td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"></div>
											</td>
											<td>
												<a href="MyLoan.aspx" class="word3">My Loans</a></td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"></div>
											</td>
											<td>
												<a href="ChangePwd.aspx" class="word3">Change Password</a></td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"><IMG height="10" src="images/1_04.gif" width="16"></div>
											</td>
											<td>
												<a href="ContactUs.aspx" class="word3">Contact Us</a></td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"></div>
											</td>
											<td class="word2">
												<a href="Logout.aspx" class="word3">Logout</a></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><IMG height="5" alt="" src="images/1_09.gif" width="190"></td>
							</tr>
							<tr>
								<td align="center"><br>
									<img src="../images/contact2.gif" width="160" height="106" alt=""></td>
							</tr>
						</table>
					</td>
					<td vAlign="top">
						<table width="100%" border="0" cellSpacing="0" cellPadding="0">
							<tr>
								<td valign="top">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td bgColor="#cc3300"><img height="30" src="images/contactus.gif" width="400">
												<asp:textbox id="txLoanSid" runat="server" Width="79px" Visible="False"></asp:textbox></td>
										</tr>
										<tr>
											<td>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td align="center"><table width="98%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td><p>&nbsp;</p>
											</td>
										</tr>
										<tr>
											<td><p>We are dedicated to making sure your Golden Bridge Cash Solution<sup>TM</sup> experience 
													is enjoyable. If there are any questions, comments or concerns please contact 
													us.
												</p>
											</td>
										</tr>
										<tr>
											<td><p><strong><br>
														Telephone : </strong>
												</p>
											</td>
										</tr>
										<tr>
											<td>
												1300 137 906
											</td>
										</tr>
										<tr>
											<td>
												<strong>
													<br>
													Facsimile </strong>:
											</td>
										</tr>
										<tr>
											<td>1300 138 916</td>
										</tr>
										<tr>
											<td>
												<strong>
													<br>
													Our customer service hours are </strong>:
											</td>
										</tr>
										<tr>
											<td>
												Monday - Friday: 8:30 a.m. ~ 5:30 p.m. EST<br>
												Exclude weekends &amp; public holidays in Victoria.</td>
										</tr>
										<tr>
											<td>
												<strong>
													<br>
													Postal address: </strong>
											</td>
										</tr>
										<tr>
											<td>
												P.O. Box 7036
												<br>
												St Kilda Rd. , VIC 8004
											</td>
										</tr>
										<tr>
											<td><p><strong><br>
														Email address </strong>:
												</p>
											</td>
										</tr>
										<tr>
											<td>
												Loan  requests: <a href="mailto:apply@pl.cashsolution.com.au">apply@pl.cashsolution.com.au
												</a>
											</td>
										</tr>
										<tr>
											<td>
												Payments: <a href="mailto:payment@pl.cashsolution.com.au">payment@pl.cashsolution.com.au
												</a>
											</td>
										</tr>
										<tr>
											<td>
												General requests or concerns: <a href="mailto:info@pl.cashsolution.com.au">info@pl.cashsolution.com.au
												</a>
											</td>
										</tr>
										<tr>
											<td><p>&nbsp;</p>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colSpan="2" height="40">&nbsp;</td>
				</tr>
				<tr>
					<td colSpan="3"><uc1:bottom id="Bottom1" runat="server"></uc1:bottom></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
