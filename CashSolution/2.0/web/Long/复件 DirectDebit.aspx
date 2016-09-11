<%@ Page language="c#" Codebehind="DirectDebit.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.DirectDebit" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<style type="text/css">
			.unnamed1 { FONT-SIZE: 10px; LINE-HEIGHT: 12px; TEXT-DECORATION: none }
			.unnamed2 { FONT-SIZE: 10px; LINE-HEIGHT: 12px; TEXT-DECORATION: none }
			.style2 { FONT-SIZE: 14pt }
			.style3 { FONT-WEIGHT: bold; FONT-SIZE: 13pt }
			.style5 { FONT-SIZE: 8pt }
			.style6 { FONT-WEIGHT: bold; FONT-SIZE: 12px }
			.style7 { FONT-WEIGHT: bold; FONT-SIZE: 9pt }
			.style9 { FONT-WEIGHT: bold; FONT-SIZE: 14pt }
			.word1 { FONT-SIZE: 9pt }
			.word2 { FONT-WEIGHT: bold; FONT-SIZE: 14pt }
			</style>
	</HEAD>
	<body LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table width="650" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td><table width="650" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="30%" valign="top"><div align="center">
										<table width="100%" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td><div align="center"><img src="images/ddr.gif" width="66" height="66">
													</div>
												</td>
											</tr>
											<tr>
												<td><div align="center"><span class="style5">Direct Debit Request</span></div>
												</td>
											</tr>
										</table>
									</div>
								</td>
								<td valign="top"><div align="center">
										<table width="100%" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td><div align="center"><strong><span class="style2">Golden Bridge Enterprises</span><br>
														</strong>
													</div>
												</td>
											</tr>
											<tr>
												<td><div align="center"><strong>Po Box 18323</strong></div>
												</td>
											</tr>
											<tr>
												<td><div align="center"><strong>Collins Street East, VIC 8003</strong></div>
												</td>
											</tr>
											<tr>
												<td><div align="center"><strong>Ph: 1300 137 906 Fax: 1300 138 916</strong></div>
												</td>
											</tr>
										</table>
									</div>
								</td>
								<td width="30%" valign="top"><div align="center">
										<table width="100%" border="0" cellspacing="0" cellpadding="0">
											<tr>
												<td><div align="center"><img src="images/eze.gif"></div>
												</td>
											</tr>
											<tr>
												<td><div align="center"><span class="style5">Get Paid On The Dot<br>
</span></div>
												</td>
											</tr>
											<tr>
												<td><div align="center"><span class="style5">ABN 67 096 902 813</span></div>
												</td>
											</tr>
											<tr>
												<td><div align="center"><span class="style5">New Customer Form</span></div>
												</td>
											</tr>
										</table>
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<tr>
					<td><table width="100%" border="0" cellspacing="0" cellpadding="0" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid">
							<tr>
								<td>Customer Reference: &nbsp;&nbsp;<strong><%=CustomerId%></strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;GBE 
									GEN 12748</td>
							</tr>
							<tr>
								<td>Surname:&nbsp;&nbsp;<%=stxsname%>&nbsp;&nbsp;&nbsp;&nbsp;Given 
									Name:&nbsp;&nbsp;<%=stxfname%></td>
							</tr>
							<tr>
								<td>Mobile Ph:&nbsp;&nbsp;<%=stxmobiletel%></td>
							</tr>
							<tr>
								<td>Email:&nbsp;&nbsp;<%=stxEmail%></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="5"></td>
				</tr>
				<tr>
					<td><table width="100%" border="0" cellspacing="0" cellpadding="0" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid">
							<tr>
								<td colspan="2"><span class="style3">Debit Arrangement/ Payment Details </span><span class="style5">&nbsp;&nbsp;And/Or the total amount billed for the specified period for this and any other subsequent agreements or amendments.</span></td>
							</tr>
							<tr>
								<td colspan="2"><div align="center">I authorise and request the debit user detailed 
										below to debit payments from my nominated account, as specified below, at 
										intervals and amounts as directed by Golden Bridge Enterprises Aust Pty Ltd as 
										per the Terms and Conditions of the Golden Bridge Enterprises Aust Pty Ltd 
										agreement and subsequent agreements.</div>
								</td>
							</tr>
							<tr>
								<td colspan="2">Fees/Charges</td>
							</tr>
							<tr>
								<td colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td width="11%"><div align="center"><strong>Administration Fee:</strong></div>
											</td>
											<td width="11%"><div align="center">Paid by Business</div>
											</td>
											<td width="11%"><div align="center"><strong>Transaction Fee:</strong></div>
											</td>
											<td width="11%"><div align="center">Paid by Business</div>
											</td>
											<td width="11%"><div align="center"><strong>Credit Card Fee:</strong></div>
											</td>
											<td width="11%"><div align="center">Visa/Mastercard Amex/Diners</div>
											</td>
											<td width="14%"><div align="center">Paid by Buiness N/A</div>
											</td>
											<td width="15%"><div align="center"><strong>SMS Payment Reminder:</strong></div>
											</td>
											<td width="5%"><div align="center">N/A</div>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="10"></td>
				</tr>
				<tr>
					<td><table width="100%" border="0" cellspacing="0" cellpadding="0" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid">
							<tr>
								<td colspan="2"><span class="style3">Debit from Bank, Building Society or Credit Union Account </span>&nbsp;&nbsp;<span class="style5">Direct Debit is not available on the full range of accounts
 - if in doubt please refer to your financial institution
                        </span></td>
							</tr>
							<tr>
								<td width="50%">&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>Financial Institution:<%=stxBank%></td>
								<td>Branch:<%=stxBranch%></td>
							</tr>
							<tr>
								<td><%=stxBsb%>: <input name="textfield24" type="text" size="4"> <input name="textfield242" type="text" size="4">
									<input name="textfield243" type="text" size="4">
									<span class="style9">                        -</span>
									<input name="textfield244" type="text" size="4"> <input name="textfield245" type="text" size="4">
									<input name="textfield246" type="text" size="4"></td>
								<td><%=stxAnumber%>: <input name="textfield2462" type="text" size="2"> <input name="textfield2463" type="text" size="2">
									<input name="textfield2464" type="text" size="2"> <input name="textfield2465" type="text" size="2">
									<input name="textfield2466" type="text" size="2"> <input name="textfield2467" type="text" size="2">
									<input name="textfield2468" type="text" size="2"> <input name="textfield2469" type="text" size="2">
									<input name="textfield24610" type="text" size="2"></td>
							</tr>
							<tr>
								<td colspan="2">Account Holder Name(s):<%=stxAname%></td>
							</tr>
							<tr>
								<td colspan="2">I/We authorise Ezi Debit Australia pty Ltd User ID 165969 to debit 
									my /our account at the Financial Institution identified above through the Bulk 
									Electronic Clearing System (BECS) in accordance to the Payment Details stated 
									above and as per the Service Agreement provided.</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="10"></td>
				</tr>
				<tr>
					<td><table width="100%" border="0" cellspacing="0" cellpadding="0" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid">
							<tr>
								<td><span class="style3">Debit from Credit Card</span></td>
							</tr>
							<tr>
								<td><div align="center" class="style6">
										<input type="checkbox" name="checkbox" value="checkbox"> VISA 
										&nbsp;&nbsp;&nbsp;&nbsp; <input type="checkbox" name="checkbox2" value="checkbox">
										MASTERCARD</div>
								</td>
							</tr>
							<tr>
								<td>Card Number:</td>
							</tr>
							<tr>
								<td>Expiry Date:</td>
							</tr>
							<tr>
								<td>Card Holder Name:</td>
							</tr>
							<tr>
								<td><div align="center">By signing this form, II We authorise Ezi Debit Australia Pty 
										Ltd, acting on behalf of the business to debit payments from my specified 
										credit card above, and II we acknowledge that Ezi Debit Australia will appear 
										as the business name on my credit card statement.</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="10"></td>
				</tr>
				<tr>
					<td><table width="100%" border="0" cellspacing="0" cellpadding="0" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid">
							<tr>
								<td colspan="2"><div align="center" class="style7">This Authorisation is to remain in 
										force in accordance with the Terms and Conditions on this page, the provided 
										Service Agreement, and I/we have read and understand the same.</div>
								</td>
							</tr>
							<tr>
								<td width="50%">Signature(s) of Nominated Account</td>
								<td>Date</td>
							</tr>
							<tr>
								<td><input type="text" name="textfield"></td>
								<td><input name="textfield2" type="text" size="6"> / <input name="textfield22" type="text" size="6">
									/ <input name="textfield23" type="text" size="12"> &nbsp;&nbsp;(DD/MM/YYYY)</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="10"></td>
				</tr>
				<tr>
					<td><table width="100%" border="0" cellspacing="0" cellpadding="0" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid">
							<tr>
								<td width="13%"><div align="center">Office Use<br>
										Only:</div>
								</td>
								<td width="13%"><div align="center"><strong>T1</strong></div>
								</td>
								<td width="13%"><div align="center">Received<br>
										Date:</div>
								</td>
								<td width="13%"><div align="center"></div>
								</td>
								<td width="13%"><div align="center">Reference<br>
										No:</div>
								</td>
								<td width="13%"><div align="center"></div>
								</td>
								<td width="22%"><div align="center">COMPLETE USING BLACK INK ONLY</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="30"><div align="center">
							<asp:TextBox id="txPerSid" runat="server" Width="1px" Visible="False"></asp:TextBox>
							<asp:LinkButton id="LinkButton1" runat="server" Visible="False">Next</asp:LinkButton></div>
					</td>
				</tr>
				<tr>
					<td>
						<table width="650" border="0" cellspacing="0" cellpadding="0" align="center">
							<tr>
								<td><div align="center">
										<img src="images/eze.gif"><br>
										<span class="style5">Get Paid On The Dot ABN: ABN: 67 096 902 813</span>
									</div>
								</td>
							</tr>
							<tr>
								<td height="30"><div align="center" class="word2">
										DDR Service Agreement
									</div>
								</td>
							</tr>
							<tr>
								<td style="line-height:120%"><span class="word1">l!We hereby authorize Ezi Debit Australia Pty Ltd (ACN: 096902813) Direct Debit 
						User ID number 165969 (herein referred to as Ezi Debit) to make periodic debits 
						on behalf of the "Business" as indicated on the front of this Direct Debit 
						Request (herein referred to as the Business)<br>
					  l!We acknowledge that Ezi Debit is acting as a Direct Debit Agent for the 
						Business and that Ezi Debit does not provide any goods or services and has no 
						express or implied liability in regards to the goods and services provided by 
						the Business or the terms and conditions of any agreement with the Business.<br>
					  l!We acknowledge that the debit amount will be debited from my/our account 
						according to the terms and conditions of the agreement with the Business.<br>
					  l!We acknowledge that bank account and credit card details have been verified 
						against a recent bank statement to ensure accuracy of the details provided. If 
						uncertain you should contact your financial institution.<br>
					  l!We acknowledge that is is my/our responsibility to ensure that there is 
						sufficient cleared funds in the nominated account by the due date to enable the 
						direct debit to be honoured on the debit date. Direct debits normally occur 
						overnight; however transactions can take up to three (3) business days 
						depending on your financial institution. l!We acknowledge and agree that 
						sufficient funds will remain in the nominated account until the direct debit 
						amount has been debited from the account and that if there are insufficient 
						funds available, l!We agree that Ezi Debit will not be held responsible for any 
						fees and charges that may be charged by your financial institution.<br>
					  l!We Acknowledge that there may be a delay in processing if:<br>
					  1) There is a public or bank holiday on the day, or any day after the debit 
						date<br>
					  2) A payment request is received by Ezi Debit on a day that is not a Banking 
						Business Day<br>
					  3) A Payment request is received after normal Ezi Debit cut off times, being 
						4pm QLD time Monday to Friday. Any payments that fall due on any of the above 
						will be processed on the next business day.<br>
					  l!We authorise the Business to vary the amount of the payments from time to 
						time as provided for within the Business agreement. l!We authorise Ezi Debit to 
						vary the amount of the payments upon instructions from the Business. l!We do 
						not require Ezi Debit to notify me/us of such variations to the debit amount.<br>
					  l!We acknowledge that the business is to provide 14 days notice if proposing to 
						vary the terms of the debit arrangements.<br>
					  l!We acknowledge that variations to the debit arrangement will be directed to 
						the Business.<br>
					  l!We acknowledge that any request to stop or cancel the debit arrangement will 
						be directed to the Business.<br>
					  l!We aCknowledge that any disputed debit payments will be directed to the 
						Business. If no resolution is forthcoming you are advised to contact your 
						financial institution.<br>
					  l!We acknowledge that if a debit is returned by my/our financial institution as 
						unpaid, l!We will be responsible for any fees and charges for each unsuccessful 
						debit in addition to any financial institution charges and collection fees, 
						including and not limited to any solicitor fees and collection agent fees 
						appointed by Ezi Debit.<br>
					  l!We authorise Ezi Debit to attempt to re-process any unsuccessful payments as 
						advised by the Business.<br>
					  l!We acknowledge that if specified by the Business, a setup. variation, SMS or 
						processing fees may apply as instructed by the Business.<br>
					  Credit Card Payments<br>
					  l!We acknowledge that "Ezi Debit Australia" will appear as the business name 
						for all payments from credit card. l!We acknowledge and agree that Ezi Debit 
						will not be held liable for any disputed transactions resulting in the non 
						supply of goods and/or services and that all disputes will be directed to the 
						business as Ezi Debit is acting as a 3rd party payment provider. l!We 
						Acknowledge and agree that in the event that a claim is made, Ezi Debit will 
						not be liable for the refund of any funds.<br>
					  Ezi Debit will keep your information about your nominated account at the 
						financial institution private and confidential unless this information is 
						required to investigate a claim made in it relating to an alleged incorrect or 
						wrongful debit, or otherwise required by law. Further information relating to 
						Ezi Debit's Privacy Policy can be found at www.ezidebit.com.au<br>
					  Credit Card Fees are a minimum of the transaction fee or the credit card fee 
						which ever is greater.<br>
					  l!We authorise:<br>
					  1) The Debit User to verify details of my/our account with my/our financial 
						institution<br>
					  2) The Financial Institution to release information allowing the Debit User to 
				  verify my/our account details.</span></td>
							</tr>
							<tr>
								<td height="10"></td>
							</tr>
							<tr>
								<td><div align="center">
										Po Box 1388 Milton, QLD 4064 Ph: (07) 3124
										<br>
										5500 Fax: (07) 3124 5555
									</div>
								</td>
							</tr>
							<tr>
								<td><div align="center"><A onclick="window.print();" href="#">Print</A> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<asp:LinkButton id="LinkButton2" runat="server">Next</asp:LinkButton>
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
