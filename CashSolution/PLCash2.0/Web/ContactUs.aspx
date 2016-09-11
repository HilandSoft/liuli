<%@ Page language="c#" Codebehind="ContactUs.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.ContactUs" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="Root/CSS/css.css" type="text/css" rel="stylesheet">
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<script language="javascript" src="root/jslib/commCheck.js" type="text/javascript"></script>
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
						<uc1:head id="Head1" runat="server"></uc1:head>
					</td>
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
                            <td height="150">&nbsp;</td>
                          </tr>
                          <tr>
                            <td><div align="center"><img src="images/contact%20us.jpg" width="150" height="100"></div></td>
                          </tr>
                        </table></td>
					<td vAlign="top">
						<table width="100%" border="0" cellSpacing="0" cellPadding="0">
							<tr>
								<td valign="top">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td bgColor="#cc3300"><img height="30" src="Member/images/contactus.gif" width="400">
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
								<td align="center"><table width="100%" border="0" cellspacing="0" cellpadding="0">
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
												Monday - Friday: 9:00 a.m. ~ 5:30 p.m. EST<br>
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
												PO Box 347 <br>
												Collins Street West, VIC 8007</td>
										</tr>
										<tr>
											<td><p><strong><br>
														Email address </strong>:
												</p>
											</td>
										</tr>
										<tr>
											<td>
												Loans  requests: <a href="mailto:apply@pl.cashsolution.com.au">apply@pl.cashsolution.com.au
												</a>
											</td>
										</tr>
										<tr>
											<td>
												Payments on loans: <a href="mailto:payment@pl.cashsolution.com.au">payment@pl.cashsolution.com.au
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
					<td colspan="3"><uc1:bottom id="Bottom1" runat="server"></uc1:bottom></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
