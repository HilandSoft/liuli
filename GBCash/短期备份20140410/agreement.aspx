<%@ Page language="c#" Codebehind="agreement.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.agreement" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Loan Agreement</title>
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<LINK href="css/css1.css" type="text/css" rel="stylesheet">
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
					<td><IMG src="images/1.gif"></td>
				</tr>
				<tr>
					<td align="center">
						<strong>
							<span class="style2">Master Loan Agreement </span>
						</strong>
					</td>
				</tr>
				<tr>
					<td align="center">(COMBINATION PROMISSARY NOTE, AGREEMENT AND TRUTH IN LENDING 
						STATEMENT)</td>
				</tr>
				<tr>
					<td align="center">
						<strong>Please READ, SIGN, and FAX back to: 1300 138 916 or email to</strong> <a href="mailto:apply@cashsolution.com.au"><strong>apply@cashsolution.com.au</strong></a>
					</td>
				</tr>
				<tr>
					<td align="center" height="10">
						<span class="unnamed2">
								 If you have any questions, please contact our Customer Service E-mail Address 
								at <strong><a href="mailto:info@cashsolution.com.au">info@cashsolution.com.au </a></strong>
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
								<td><strong>&nbsp;Golden Bridge Enterprises (Aust) Pty Ltd</strong> <INPUT id="Hidden1" type="hidden" size="2" name="Hidden1" runat="server"></td>
							</tr>
							<tr>
								<td width="123"><strong>Name of Borrower:</strong></td>
								<td width="527">&nbsp; <INPUT id="BorrowerName" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
										readOnly type="text" name="textfield" runat="server" size="40">
								</td>
							</tr>
							<tr>
								<td><strong>Driver's License:</strong></td>
								<td>
									&nbsp; <INPUT id="DriverLicense" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
										readOnly type="text" name="textfield" runat="server" size="40">
								</td>
							</tr>
							<tr>
								<td><strong>Home Address:</strong></td>
								<td>&nbsp; <INPUT id="HomeAddress1" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
										readOnly type="text" name="textfield" runat="server" size="30">
										&nbsp; <INPUT id="HomeAddress2" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
										readOnly type="text" name="textfield" runat="server" size="30">
										</STRONG></td>
							</tr>
							<tr>
								<td><strong>Contact Tel:</strong>
								</td>
								<td><strong> &nbsp; (W) <INPUT id="ContactW" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
											readOnly type="text" name="textfield2" runat="server" size="18"> </A>(H) <INPUT id="ContactH" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
											readOnly type="text" name="textfield3" runat="server" size="18"> </A>(C) <INPUT id="ContactC" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
											readOnly type="text" name="textfield4" runat="server" size="18"> </strong>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<div align="right"><strong>
								<%=fDay%>
								/<%=fMonth%>
								/<%=fYear%></strong></div>
						<table cellSpacing="0" cellPadding="0" border="1" bordercolor="#000000">
							<tr class="unnamed2">
								<td width="97" vAlign="top" class="unnamed1"><strong>Loan Amount</strong>
									<br>
									(The dollar amount of credit provided to you )<br>
									<BR>
									$<%=LoanAccount%>
								</td>
								<td width="115" vAlign="top" class="unnamed1"><strong>Total Payable</strong><br>
									(The dollar amount you will have paid after you have made all scheduled 
									payments) $<%=TotalRepayable%>
								</td>
								<td vAlign="top" width="180">
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
								<td width="134" vAlign="top" class="unnamed1">
									<strong>Annual Percentage Rate</strong> (The cost of this loan as a yearly 
									rate)<br>
									<br>
									<br>
									<%=Tcoc1%>
								</td>
								<td width="112" vAlign="top" class="unnamed1">
									<strong>Finance Cost </strong>
									<br>
									The dollar amount this loan will cost you over the repayment period )
									<br>
									<br>
									$<%=Tcoc2%>
								</td>
							</tr>
							<tr class="unnamed2">
							  <td colSpan="5" vAlign="top" class="unnamed1">Finance cost is $1.333 per day per $100 advanced over the repayment period of time. </td>
						  </tr>
							<tr class="unnamed2">
							  <td colSpan="5" vAlign="top" class="unnamed1">A late fee of $50 may apply if any installment is not paid in full within five (5) days following its scheduled due date. </td>
						  </tr>
							<tr class="unnamed2">
								<td colSpan="5" vAlign="top" class="unnamed1">Collection fee of 25% of the amount of unpaid debt may become payable under this notice in the event of a breach.</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<p align="center"><strong><br>
								<a href="#">PROMISSORY NOTE NEGOTIABLE PAPER</a> </strong>
						</p>
					</td>
				</tr>
				<tr>
					<td class="unnamed1">
						<strong>PROMISE TO PAY</strong> For value received, I promise to pay to Bridge 
						Enterprises (Aust) Pty Ltd (Hereafter referred to as &quot;Golden Bridge&quot;) or to 
						their order the Total Payable shown above until the full amount of this note 
						shall be paid. The amounts set forth in this note are not in dispute and that I 
						have full capacity to consent to the payment of such amount.
						<br>
						<strong>PAYMENT</strong> By signing this agreement I authorize Golden Bridge to 
						effect ACH debit and credit entries without any further notice to me, for the 
						amounts submitted with this note or any future electronic loans or extension 
						submissions made by me via the Fax Machine or by the Electronic Form on the 
						Golden Bridge Website. The unpaid amounts will be debited from my nominated 
						account until fully paid.
						<br>
						I promise to keep open and maintain an adequate balance in my account to ensure 
						all payments are made to Golden Bridge in a timely manner on and up to five (5) 
						days after the scheduled due date(s), until this note is paid in full.
						<br>
						<strong>DOCUMENTATION</strong> I agree that electronic mail, electronic forms, 
						records, photocopies, and / or facsimile copies of the documents I submit are 
						valid and enforceable as the original. For subsequent applications by internet, 
						I agree that by my binding electronic signature, it is acknowledged and 
						understood that it constitutes an acceptance of all terms and conditions of the 
						master loan agreement and is valid and enforceable. My consent applies to all 
						documents, notices and disclosures relating to this loan transaction and any 
						subsequent loan transactions with Golden Bridge, including this notice and all 
						agreements to extend the due date of a loan or to apply a new loan.
						<br>
						<strong>LATE FEE AND PENALTY INTEREST</strong> In the event that any 
						installment under this note is not paid in full within five (5) days following 
						its scheduled Due Date, I agree to pay a Late Fee of $50. I will pay an 
						interest of 0.065% per day (or default interest of 24% per annum) of the 
						outstanding debt after 62 days following the date of the advance. This will be 
						added to my outstanding account.
						<br>
						<strong>RETURNED OR REJECTED PAYMENTS</strong> In the event my electronic 
						payment of any amount due under this agreement, and on presentation to the 
						named financial institution, is returned due to insufficient funds or credit, 
						stopped payment, or closed account, or any other reason, I agree to pay a $25 
						Returned Item Fee.
						<br>
						<strong>DISPUTE RESOLUTION</strong> I agree to pay reasonable fees of any 
						solicitor at law debt collection agency who may be employed to recover the 
						amount of this note, or any part hereof, in principal, cost and interest, or to 
						protect the interest of Golden Bridge or to compromise or take any other action 
						with required thereto, which fees are hereby fixed at twenty-five (25%) percent 
						of the amount of the unpaid debt. Upon the occurrence of one or more of the 
						following events of default (1) failure to make any  payments when due: 
						(2) Failure to perform any obligation under any Security Agreement securing 
						this note: (3) I default under any other credit extension with Golden Bridge; 
						(4) Should I die, become insolvent or apply for bankruptcy or other relief from 
						creditors. I agree Golden Bridge may, at its option, declare the entire unpaid 
						balance of this Note to be due immediately and payable without notice or 
						demand.
						<br>
						<strong>CESSION</strong> I hereto severally consent and agree that any and all 
						collateral securing this note may be exchanged or surrendered or otherwise 
						dealt with from time to time without notice to or from me and without in any 
						manner releasing or altering my obligations under this Note. No delay on the 
						part of Golden Bridge in exercising any power or right hereunder shall operate 
						as a waiver of any such power of right nor shall any single or partial exercise 
						of any power or right hereunder preclude other or future exercise thereof or 
						the exercise of any other power of right hereunder.<br>
						<strong>TRANSACTIONS</strong> These transactions shall be made in the State of 
						Victoria in Australia, and Victoria State Law shall govern all aspects thereof.
						<br>
						<strong>BY SIGNING BELOW</strong> By signing below, I acknowledge that I fully 
						understand the Golden Bridge Cash Solution<sup>TM</sup> program and procedures 
						and further acknowledge receipt of a completed copy of this Truth-in-Lending 
						Disclosure Statement Promissory Note.
					</td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="650" border="0">
							<tr>
								<td colSpan="2">&nbsp;</td>
							</tr>
							<tr>
								<td width="170">Applicant's signature</td>
								<td width="523">__________________</td>
							</tr>
							<tr>
								<td>Print applicant's name</td>
								<td>__________________</td>
							</tr>
							<tr>
								<td>Date</td>
								<td>__________________</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td colspan="2" align="center" height="24"><p align="center" class="unnamed1">
										Golden Bridge Enterprises (Aust) Pty Ltd (ABN: 92 112 483 226) PO Box 347 , Collins Street West, VIC 8007<br>
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
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
