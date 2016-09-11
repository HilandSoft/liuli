<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<%@ Page language="c#" Codebehind="CompRate.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.CompRate" %>
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<script language="javascript" src="../jslib/commCheck.js" type="text/javascript"></script>
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
								<td>
									<img src="images/1_01.gif" width="190" height="18" alt=""></td>
							</tr>
							<tr>
								<td background="images/1_07.gif">
							      <table width="100%" border="0" cellspacing="0" cellpadding="0">
                                    <tr>
                                      <td width="17%" height="20"><div align="center"></div></td>
                                      <td width="83%" class="word2">Calculator</td>
                                    </tr>
                                    <tr>
                                      <td height="20"><div align="center"><img src="images/1_04.gif" width="16" height="10"></div></td>
                                      <td class="word2"><strong>Comparison Rate</strong></td>
                                    </tr>
                                    <tr>
                                      <td height="20">&nbsp;</td>
                                      <td class="word2">Contact Us</td>
                                    </tr>
                                    <tr>
                                      <td height="20"><div align="center"></div></td>
                                      <td class="word2">Cost &amp; Fees</td>
                                    </tr>
                                    <tr>
                                      <td height="20"><div align="center"></div></td>
                                      <td class="word2"> FAQs</td>
                                    </tr>
                                    <tr>
                                      <td height="20">&nbsp;
                                          <DIV></DIV></td>
                                      <td class="word2">Privacy and Security Policy</td>
                                    </tr>
                                  </table></td>
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
					<td vAlign="top">
						<table width="100%" border="0" cellSpacing="0" cellPadding="0">
							<tr>
								<td valign="top">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td bgColor="#cc3300"><img height="30" src="images/CompRate.gif" width="400">
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
								<td align="center"><div align="left">
										<p><strong>Comparison Rate Schedule</strong>
											<br>
											Cash loans provided by Golden Bridge Enterprises (Aust) Pty Ltd
											<br>
											Date of issue: 16/10/2006
										</p>
										<table width="550" border="1" cellpadding="0" cellspacing="0" bordercolor="#eeeeee">
											<tr>
												<td height="25">Loan Amount</td>
												<td>&nbsp;</td>
												<td>Loan term</td>
												<td>Comparison Rate p.a.
												</td>
												<td>Annual Percentage Rate
												</td>
											</tr>
											<tr>
												<td height="25">$1000.00</td>
												<td>(unsecured)
												</td>
												<td>6 months
												</td>
												<td>120.00%
												</td>
												<td>120.00%
												</td>
											</tr>
											<tr>
												<td height="25">$1500.00
												</td>
												<td>(unsecured)
												</td>
												<td>1 year
												</td>
												<td>112.80%
												</td>
												<td>112.80%
												</td>
											</tr>
										</table>
										<p><strong>WARNING</strong>: This Comparison Rate applies only to the example or 
											examples given. Different amounts and terms will result in different omparison 
											rates. Costs such as redraw fees or early repayment fees, and cost savings such 
											as fee waivers, are not included in the Comparison Rate but may influence the 
											cost of the loan.
										</p>
										<br>
										<br>
										<br>
									</div>
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
