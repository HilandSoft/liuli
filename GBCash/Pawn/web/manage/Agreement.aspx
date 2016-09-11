<%@ Page language="c#" Codebehind="Agreement.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.Agreement" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Agreement</title>
		<LINK href="../css/css1.css" type="text/css" rel="stylesheet">
			<style type="text/css">			
			.unnamed1 { FONT-SIZE: 10px; LINE-HEIGHT: 12px; TEXT-DECORATION: none }			
			.style2 { FONT-SIZE: 14pt }			
			.unnamed2 { FONT-SIZE: 10px; LINE-HEIGHT: 12px; TEXT-DECORATION: none }			
			.unnamed3 { FONT-SIZE: 11px; TEXT-DECORATION: none }			
			</style>
	</HEAD>
	<body bgColor="#ffffff" leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="650" align="center" border="0">
				<tr>
					<td><IMG src="../images/1.gif"></td>
				</tr>
				<tr>
					<td align="center">
						<strong>
							<span class="style2">Pawn Agreement & Disclosure</span>
						</strong>
					</td>
				</tr>
				<tr>
					<td align="center">Lender¡¯s address: Level 1, 446 Collins Street Melbourne VIC 3000</td>
				</tr>
				<tr>
					<td align="center">
						<strong>Please READ, SIGN, and FAX back to: 1300 138 916</strong>
					</td>
				</tr>
				<tr>
					<td align="center" height="10">
						<span class="unnamed2">
								 If you have any questions contact our Customer Service E-mail Address at <strong><a href="mailto:info@gbcash.com.au">info@gbcash.com.au </a></strong>
								or call at 1300 137 906
								
					  </span>
					</td>
				</tr>
				<tr>
					<td>
						<hr>
					</td>
				<tr>
					<td valign="top">
						<table cellSpacing="0" cellPadding="0" width="650" border="0">
							<tr>
								<td colSpan="4" align="right">
									<strong>Customer No:
										<%=CustomerId%>
									</strong>
								</td>
							</tr>
							<tr>
								<td><strong>Name of Lender: </strong>
								</td>
								<td><strong>&nbsp;Golden Bridge Finance Pty Ltd (ABN: 72 134 151 830)</strong> <INPUT id="Hidden1" type="hidden" size="2" name="Hidden1" runat="server"></td>
							</tr>
							<tr>
								<td width="123"><strong>Name of Borrower:</strong></td>
								<td width="527">&nbsp; <INPUT id="BorrowerName" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
										readOnly type="text" name="textfield" runat="server" size="40">
								</td>
							</tr>
							<tr>
								<td><strong>Home Address:</strong></td>
							  <td>&nbsp; <INPUT id="HomeAddress1" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
										readOnly type="text" name="textfield" runat="server" size="40"></STRONG>
										&nbsp; <input id="HomeAddress2" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
										readonly type="text" name="textfield" runat="server" size="40"></td>
							</tr>
							<tr style="display:none;">
								<td><strong>Contact Tel:</strong>
								</td>
								<td><strong> &nbsp; (W) <INPUT id="ContactW" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
											readOnly type="text" name="textfield2" runat="server" size="18"> </A>(H) <INPUT id="ContactH" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
											readOnly type="text" name="textfield3" runat="server" size="18"> </A>(C) <INPUT id="ContactC" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
											readOnly type="text" name="textfield4" runat="server" size="18"> </strong>
								</td>
							</tr>
							
							<tr>
								<td><strong>Pawn Ticket Number:</strong></td>
								<td>PT<asp:Literal Runat="server" ID="pawnTicketNumber"></asp:Literal></td>
							</tr>
							<tr>
								<td><strong>Photo No:</strong></td>
								<td><asp:Literal Runat="server" ID="photoNo"></asp:Literal></td>
							</tr>
							<tr>
								<td><strong>Description of Goods:</strong></td>
								<td><asp:Literal Runat="server" ID="ItemDescription"></asp:Literal></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<div align="right"><strong>
								Date of Loan: <%=fDay%>
								/<%=fMonth%>
								/<%=fYear%></strong></div>
						<table cellSpacing="0" cellPadding="0" border="1" bordercolor="#000000">
							<tr class="unnamed2">
								<td width="127" vAlign="top" class="unnamed1"><strong>Loan Amount</strong>
									<br>
									(The dollar amount of credit provided to you )<br>
									<BR>
									$<%=LoanAccount%>
								</td>
								<td width="155" vAlign="top" class="unnamed1"><strong>Total Payable</strong><br>
									(The dollar amount you will have paid after you have made all scheduled 
									payments) $<%=TotalRepayable%>
								</td>
								<td vAlign="top" width="200">
									<p class="unnamed1"><strong>Repayment Schedule</strong>:<br>
										1st Installment &nbsp;<%=Datedue1%>&nbsp;&nbsp;$<%=Repaydue1%><BR>
										2nd Installment &nbsp;<%=Datedue2%>&nbsp;&nbsp;$<%=Repaydue2%><BR>
										3rd Installment &nbsp;<%=Datedue3%>&nbsp;&nbsp;$<%=Repaydue3%><BR>
										<%=Wpaid%>
										<BR>
										Repayment period in days:
										<%=Period%>
									</p>
								</td>
								<td width="162" vAlign="top" class="unnamed1">
									<strong>Finance Cost </strong>
									<br>
									The dollar amount this loan will cost you over the repayment period )
									<br>
									<br>
									$<%=Tcoc2%>
								</td>
							</tr>
							<tr class="unnamed2">
							  <td vAlign="top" colSpan="4"><span class="unnamed1">Finance cost is $1.333 per day per $100 advanced over the repayment period of time.</span></td>
						  </tr>
							<tr class="unnamed2">
								<td vAlign="top" colSpan="4">
									<p class="unnamed1">$50 late fee applies in the event any installment is not paid in full within five (5) days following its scheduled Due Date.</p>
							  </td>
							</tr>
							<tr class="unnamed2">
								<td colSpan="4" vAlign="top" class="unnamed1">Collection fee of 25% of the amount of unpaid debt may become 
									payable under this notice in the event of a breach.</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<p align="center"><strong><br>
								<a href="#">Declaration and Acceptance of Terms and Conditions</a> </strong>
						</p>
					</td>
				</tr>
				<tr>
					<td class="unnamed1">
						The pledge will remain in the possession of Golden Bridge Finance Pty Ltd ((Hereafter referred to as "Golden Bridge") until this loan is determined. In the event the customer has not paid in full the Total of Payments indicated above by the due date, or this loan has not been renewed within such period of time as provided for below, the pledge described herein may be forfeited and sold without notice to you. 
						<br>
						<br>
						<strong>DOCUMENTATION</strong> I agree that electronic mail, electronic forms, records, photocopies, and / or facsimile copies of the documents I submit are valid and enforceable as the original. For subsequent applications by internet, or any future electronic loans or extension submissions made by me via the Fax Machine or by the Electronic Form on the Golden Bridge Website, I agree that by my binding electronic signature, it is acknowledged and understood that it constitutes an acceptance of all terms and conditions of the master loan agreement and is valid and enforceable. My consent applies to all documents, notices and disclosures relating to this loan transaction and any subsequent loan transactions with Golden Bridge, including this loan and all agreements to extend the due date of a loan or to apply a new loan.

						<br><br>
						<strong>PREPAYMENT OF LOAN</strong> Customer may prepay without penalty the unpaid balance of this loan. On prepayment in full, customer will be entitled to a refund of the unearned Finance Charge.
						<br><br>
						<strong>TRANSACTIONS</strong> These transactions shall be made in the State of Victoria in Australia, and Victoria State Law shall govern all aspects thereof.

						<br><br>
						<strong>BY SIGNING BELOW</strong> I declare that the details listed above are true and correct; and 
I am the owner of the above described goods and the goods are NOT subject to any encumbrance or third party claim of any kind; and 
I have received a Notice of Rights and Responsibilities and I have read the terms and conditions of this Pawn Ticket and I understand the rights, terms and conditions stated and I agree with the terms and conditions; and
I declare that I am not under the influence of alcohol or any drug.

					</td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td colSpan="2">&nbsp;</td>
							</tr>
							<tr>
								<td width="40%">Customer's Signature:__________________</td>
								<td width="60%">Date of Signature:__________________</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colspan="2"  class="unnamed2">Golden Bridge is not liable for any loss of goods due to burglary, fire, theft or any other circumstance not reasonable within its control. You should separately insure the goods for these risks.
</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colspan="2" align="center" height="24"><p align="center" class="unnamed1">
										Golden Bridge Enterprises (Aust) Pty Ltd (ABN: 92 112 483 226)  PO Box 347, Collins Street West, VIC 8007<br>
										Tel: 1300 137 906&nbsp; &nbsp;Fax: 1300 138 916&nbsp; 
										&nbsp;&nbsp;www.cashsolution.com.au 
									</p>
								</td>
							</tr>
							<tr>
								<td align="center" colSpan="4" height="20">
									<A onclick="window.print();" href="#">Print</A> &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									<asp:LinkButton id="LinkButton1" runat="server">Next</asp:LinkButton>
								</td>
							</tr>
							<tr>
								<td colSpan="4">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
