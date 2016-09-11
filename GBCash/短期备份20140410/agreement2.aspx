<%@ Page language="c#" Codebehind="agreement2.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.agreement2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>agreement2</title>
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<LINK href="css/css.css" type="text/css" rel="stylesheet">
		<style type="text/css"> <!-- .style1 {font-size: 12pt}
	-->
		</style>
		<!--media=print 这个属性可以在打印时有效-->
		<style media="print"> 
.Noprint { DISPLAY: none } 
.PageNext { PAGE-BREAK-AFTER: always } 
</style>
		<style> 
.tdp { BORDER-RIGHT: #ffffff 0px solid; BORDER-TOP: #ffffff 0px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid } 
.tabp { BORDER-RIGHT: #000000 2px solid; BORDER-TOP: #000000 2px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid } 
.NOPRINT { FONT-SIZE: 9pt; FONT-FAMILY: "宋体" } 
</style>
	</HEAD>
	<body bgColor="#ffffff" leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<BLOCKQUOTE dir="ltr" style="MARGIN-RIGHT: 0px"> <BLOCKQUOTE>
					<table cellSpacing="0" cellPadding="0" width="750" align="center" border="0">
						<tr>
							<td><IMG height="103" src="images/1.JPG" width="327"></td>
						</tr>
						<tr>
							<td align="center"><strong><span class="style1">Master Loan Agreement </span>
									<br>
								</strong>(COMBINATION PROMISSARY NOTE, AGREEMENT AND TRUTH IN LENDING 
								STATEMENT)
								<br>
								<strong>Please READ, SIGN, and FAX back to: XXXXX
									<br>
								</strong>If you have any questions contact our Customer Service E-mail Address 
								at <A href="mailto:lily110810@yahoo.com">lily110810@yahoo.com </A>or call at 
								XXXXX<strong> </strong>
								<hr>
							</td>
						</tr>
						<tr>
							<td>
								<p align="right"><strong></strong></p>
								<table cellSpacing="0" cellPadding="0" width="750" border="0">
									<tr>
										<td colSpan="4">
											<div align="right"><strong>Customer No:
													<%=CustomerId%>
												</strong>
											</div>
										</td>
									</tr>
									<tr>
										<td colSpan="4"><strong>Name of Lender: Golden Bridge Enterprises (Aust) Pty Ltd </strong>
										</td>
									</tr>
									<tr>
										<td colSpan="4"><strong>Name of Borrower:<%=BorrowerName%>
												I.D. Number:<%=DriverLicense%>
											</strong>
										</td>
									</tr>
									<tr>
										<td width="104"><strong>Home Address:&nbsp;</strong></td>
										<td width="217"><strong><%=HomeAddress1%></strong></td>
										<td width="108"><strong>Mailing Address:</strong></td>
										<td width="321"><strong></strong>_______________________________</td>
									</tr>
									<tr>
										<td>&nbsp;</td>
										<td><strong><%=HomeAddress2%></strong></td>
										<td>&nbsp;</td>
										<td><strong>_______________________________</strong></td>
									</tr>
									<tr>
										<td colSpan="4"><strong>Contact Tel: (W)
												<%=ContactW%>
												(H)
												<%=ContactH%>
												(C)
												<%=ContactC%>
											</strong>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td>
								<div align="right"><strong><BR>
										DD/MM/YYY</strong></div>
								<table cellSpacing="0" cellPadding="0">
									<tr>
										<td vAlign="top" width="106">LOAN AMOUNT
											<BR>
											The dollar amount of credit provided to you :
											<BR>
											$<%=LoanAccount%>
										</td>
										<td vAlign="top" width="115">TOTAL REPAYABLE (The dollar amount you will have paid 
											after you have made all scheduled payments):<BR>
											$<%=TotalRepayable%>
										</td>
										<td vAlign="top" width="312">
											<p>Repayment Schedule:
												<br>
												1st Installment :<%=Datedue1%>&nbsp;&nbsp;<%=Repaydue1%><BR>
												2nd Installment :<%=Datedue2%>&nbsp;&nbsp;<%=Repaydue2%><BR>
												3rd Installment :<%=Datedue3%>&nbsp;&nbsp;<%=Repaydue3%><BR>
												Number of installment:
												<%=Installments%>
												<BR>
												<%=Wpaid%>
												<BR>
												Repayment period in days:
												<%=Period%>
											</p>
										</td>
										<td vAlign="top" width="173">
											NOMINAL ANNUAL RATE FOR THE TOTAL CHARGE OF CREDIT (TCOC )
											<BR>
											(The cost of this loan as a yearly) rate :
											<br>
											<%=Tcoc1%>
										</td>
										<td vAlign="top" width="115">
											DOLLAR VALUE OF THE TOTAL CHARGE OF CREDIT (TCOC) (The dollar amount this loan 
											will cost you over the repayment period ):
											<br>
											<%=Tcoc2%>
										</td>
									</tr>
									<tr>
										<td vAlign="top" width="756" colSpan="5">
											<p>Other&nbsp; charges = <strong>$<%=OtherCharges%>
												</strong>
											</p>
										</td>
									</tr>
									<tr>
										<td vAlign="top" width="756" colSpan="5">Enforcement expenses may become payable 
											under this notice in the event of a breach.
										</td>
									</tr>
									<tr>
										<td vAlign="top" width="756" colSpan="5">Additional interest being penalty interest 
											will be charged on all overdue amounts at the rate of _________ % per year
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td>
								<p align="center"><strong><br>
										PROMISSORY NOTE NEGOTIABLE PAPER
										<br>
										<br>
									</strong>
								</p>
							</td>
						</tr>
						<tr>
							<td>
								<p><strong>PROMISE TO PAY </strong>For value received, the undersigned (whether one 
									or more) jointly, severally solidarity, promise to pay to the order the Lender 
									stated above the Total of payments shown above until the full amount of this 
									note shall be paid. The amounts set forth in this note are not in dispute and 
									that I have full capacity to consent to the payment of such amount.
									<br>
									I promise to pay to Golden Bridge Enterprises (Aust) Pty Ltd <strong>( </strong>
									Hereafter referred to as “Golden Bridge”) or to their order by my binding 
									electronic signature in one or more payments on the date(s) indicated in the 
									payment schedule , or if extended payment request was submitted and processed, 
									the total of payments on or after the next date of any installment comes due. I 
									authorize Golden Bridge to effect this payment by one or more debit entries to 
									the nominated account of my financial institution (bank or credit union) as and 
									when required until this note is paid in full.
									<br>
									I promise to keep open and maintain an adequate balance in my account to ensure 
									all payments are made to Golden Bridge in a timely manner on and up to five (5) 
									days after the scheduled due date(s), until this note is paid in full. If 
									Golden Bridge is unable to collect payment from my provided account or for any 
									reason to effect debit entries as agreed, I promise to pay all sums I owe 
									immediately, by mailing my payment using overnight delivery in the form of a 
									bank cheque or money order to Golden Bridge .
									<br>
									<strong>PAYMENT </strong>By signing this agreement I authorize Golden Bridge to 
									effect ACH debit and credit entries into the bank account submitted. I 
									understand that in the event that my payments are returned unpaid for any 
									reason, I authorize Golden Bridge to effect ACH debit entries without any 
									further notice to me, for the amounts of the debit entries submitted with this 
									or any future electronic loans or extension submissions made by me via the Fax 
									Machine or by the Electronic Form on the Golden Bridge Website. The unpaid 
									amounts will be debited from my nominated account until fully repaid. The 
									amount of my unpaid amounts will consist of the following: Original Loan and 
									Fee account plus any accrued late fees or applicable late fees or applicable 
									NSF charges plus any debt collection fees.
									<br>
									<strong>LATE FEE AND PENALTY INTEREST </strong>In the event that any 
									installment under this note is not paid in full within five (5) days following 
									its scheduled Due Date, I agree to pay a Late Fee of $50 . I will pay an 
									interest of 0.065% per day (or default interest of 24% per annum) of the 
									outstanding debt after 62 days following the date of the advance. This will be 
									added to my outstanding debt.
									<br>
									<strong>DOCUMENTATION </strong>I agree that electronic mail, electronic forms, 
									records, photocopies, and / or facsimile copies of the documents I submit are 
									valid and enforceable as the original. For subsequent applications by internet, 
									I agree that by typing or writing my name as my signature, it is acknowledged 
									and understood that it constitutes an acceptance of all terms and conditions of 
									the master loan agreement and is valid and enforceable. My consent applies to 
									all documents, notices and disclosures relating to this loan transaction and 
									any subsequent loan transactions with Golden Bridge , including this notice and 
									all agreements to extend the due date of a loan or to renew a loan.
									<br>
									<strong>RETURNED OR REJECTED PAYMENTS </strong>In the event my electronic 
									payment of any amount due under this agreement, and on presentation to the 
									named financial institution, is returned due to insufficient funds or credit, 
									stopped payment, or closed account, or any other reason, I agree to pay a $25 
									Returned Item Fee .<br>
									<strong>DISPUTE RESOLUTION </strong>The parties hereto further bind themselves 
									to pay reasonable fees of any solicitor at law who may be employed to recover 
									the amount of this note, or any part hereof, in principal and interest, or to 
									protect the interest of Lender or to compromise or take any other action with 
									required thereto, which fees are hereby fixed at twenty-five (25%) percent of 
									the amount of the unpaid debt. Upon the occurrence of one or more of the 
									following events of default (1) failure to make any monthly payments when due: 
									(2) Failure to perform any obligation under any Security Agreement securing 
									this note: (3) borrower defaults under any other credit extension with Lender; 
									(4) Borrower should die, or become insolvent, or apply for bankruptcy or other 
									relief from creditors; (5) Lender reasonably believes itself to be insecure in 
									the repayment of this note. Lender may, at its option, declare the entire 
									unpaid balance of this Note to be due immediately and payable without notice or 
									demand.
									<br>
									Borrower agrees that the origination fee, if any, included in the prepaid 
									finance charge disclosed above, is fully earned and is not subject to rebate 
									upon prepayment or acceleration of this note, and not considered interest.
									<br>
									All parties hereto severally waive presentment for payment, demand, protest, 
									and notice of protest and non-payment, and all pleas of division and discussion 
									and agree that the payment of this Note may be extended by Lender from time to 
									time, one or more times, without notice, hereby binding themselves jointly, 
									severally, and solidarity, unconditionally waiving all pleas of discussion and 
									division, and as original makers and promissory for the payment hereof in 
									principal, interest, cost and solicitor fees.
									<br>
									Lender may at any time release any of the parties hereto, in whole or in part, 
									from their obligations hereunder without in any manner affecting or impairing 
									the rights against all other parties hereto not so release. All parties hereto 
									severally consent and agree that any and all collateral securing this note may 
									be exchanged or surrendered or otherwise dealt with from time to time without 
									notice to or from any party hereto and without in any manner releasing or 
									altering the obligations of the parties hereto under this Note. No delay on the 
									part of the Lender in exercising any power or right hereunder shall operate as 
									a waiver of any such power of right nor shall any single or partial exercise of 
									any power or right hereunder preclude other or future exercise thereof or the 
									exercise of any other power of right hereunder. .
									<br>
									All parties hereto further severally agree that this Note evidences and sets 
									forth their agreement with the holder hereof and that no modifications hereof 
									shall be binding unless in writing and signed by the parties hereto.
									<br>
									<strong>TRANSACTIONS </strong>These trabansactions shall be made in the State 
									of Victoria in Australia , and Victoria State Law shall govern all aspects 
									thereof.
									<br>
									<strong>BY SIGNING BELOW </strong>By signing below, I acknowledge that I fully 
									understand the Golden Bridge Cash Solution program and procedures and that I 
									have been advised to seek the appropriate advice for any questions I have.
								</p>
							</td>
						</tr>
						<tr>
							<td>
								<table cellSpacing="0" cellPadding="0" width="750" border="0">
									<tr>
										<td colSpan="4">&nbsp;</td>
									</tr>
									<tr>
										<td>Applicant's signature</td>
										<td>__________________</td>
										<td>Witness's signature</td>
										<td>___________________
										</td>
									</tr>
									<tr>
										<td>Print applicant's name</td>
										<td>__________________</td>
										<td>Print witness's name</td>
										<td>___________________
										</td>
									</tr>
									<tr>
										<td>Date</td>
										<td>__________________</td>
										<td>Date
										</td>
										<td>___________________
										</td>
									</tr>
									<tr>
										<td>&nbsp;</td>
									</tr>
									<tr>
										<td align="center" colSpan="4"><A onclick="window.print();" href="#">Print</A> <A onclick="window.close();" href="#">
												Close</A></td>
									</tr>
									<tr>
										<td colSpan="4">&nbsp;</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
				</BLOCKQUOTE></BLOCKQUOTE>
				<OBJECT id="WebBrowser" classid="CLSID:8856F961-340A-11D0-A96B-00C04FD705A2" height="0"
								width="0" VIEWASTEXT>
							</OBJECT>
		</form>
	</body>
</HTML>
