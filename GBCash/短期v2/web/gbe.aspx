<%@ Page language="c#" Codebehind="gbe.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.gbe" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>gbe</title>
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<LINK href="css/css.css" type="text/css" rel="stylesheet">
			<style type="text/css">
		.unnamed1 { FONT-SIZE: 12px; LINE-HEIGHT: 18px; TEXT-DECORATION: none }
		.fontsmall { FONT-SIZE: 9px; LINE-HEIGHT: 12px; TEXT-DECORATION: none }
		.word1 { FONT-SIZE: 14px; COLOR: #000000; TEXT-DECORATION: none }
		#SearchButton { PADDING-RIGHT: 0.2em; PADDING-LEFT: 0.2em; FONT-SIZE: 11px; PADDING-BOTTOM: 0em; MARGIN-LEFT: 6px; WIDTH: 4.6em; PADDING-TOP: 0em; POSITION: relative; TOP: 1px }
		.SearchBox { FONT-SIZE: 14px }
		</style>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="1" cellPadding="0" width="653" align="center" border="0">
				<tr>
					<td vAlign="top">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td vAlign="top"><IMG src="images/3.JPG"></td>
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td><IMG src="images/4.JPG"></td>
											<td><IMG src="images/5.gif"></td>
										</tr>
										<tr>
											<td colSpan="2">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
												&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>GBE 
													GEN</strong>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td class="unnamed1"><br>
									Customer Ref: <input id="txId" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
										readOnly type="text" name="textfield" runat="server"><INPUT id="Hidden1" style="WIDTH: 24px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
										runat="server"></td>
							</tr>
							<tr>
								<td class="unnamed1">Surname/Company: <input id="txLname" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
										readOnly type="text" name="textfield2" runat="server"> Given Name: <input id="txFname" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
										readOnly type="text" name="textfield22" runat="server"></td>
							</tr>
							<tr>
								<td class="unnamed1">Address: <input id="txAddress" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
										readOnly type="text" name="textfield23" runat="server"> Suburb: <input id="txCity" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
										readOnly type="text" name="textfield232" runat="server"> State: <input id="txState" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
										readOnly type="text" name="textfield2322" runat="server"></td>
							</tr>
							<tr>
								<td class="unnamed1">Post Code: <input id="txPostcode" style="WIDTH: 80px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 18px"
										readOnly type="text" size="8" name="textfield233" runat="server"> Phone: 
									(H)<INPUT id="txHPhone" style="WIDTH: 104px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 18px"
										readOnly type="text" size="12" name="textfield233" runat="server"> (W)<INPUT id="txEPhone" style="WIDTH: 104px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 18px"
										readOnly type="text" size="12" name="textfield233" runat="server">(Mob.)<INPUT id="txMobile" style="WIDTH: 112px; BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; HEIGHT: 20px"
										readOnly type="text" size="13" name="textfield233" runat="server"></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<table cellSpacing="0" cellPadding="0" width="645" border="0" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid">
										<tr>
											<td class="unnamed1"><strong>Payment Agreement </strong>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<strong>B
												</strong>Payment with file upload
												<br>
												<br>
												I authorise and request the debit user detailed below to debit payments from my 
												nominate account, specified below, at intervals and amounts as directed by <strong>Golden 
													Bridge Enterprises </strong>as per the Terms and Conditions of the <strong>Golden 
													Bridge Enterprises </strong>Agreement and any subsequent agreements.
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><strong><br>
										Ezi Debit From Bank Or Cheque Account, Building Society or Credit Union </strong>
								</td>
							</tr>
							<tr>
								<td>
									<table cellSpacing="0" cellPadding="0" width="645" border="0" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid">
										<tr>
											<td width="50%">Financial Institution : <input class="SearchBox" id="txBank" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
													readOnly type="text" name="textfield3" runat="server"></td>
											<td width="50%">Branch : <input id="txBranch" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
													readOnly type="text" name="textfield32" runat="server"></td>
										</tr>
										<tr>
											<td>BSB Number : <input id="txBsb" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
													readOnly type="text" name="textfield33" runat="server"></td>
											<td>Account Number : <input id="txANumber" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
													readOnly type="text" name="textfield322" runat="server"></td>
										</tr>
										<tr>
											<td colSpan="2">Account Name : <input id="txAName" style="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none"
													readOnly type="text" name="textfield332" runat="server"></td>
										</tr>
										<tr>
											<td align="right" colSpan="2">NOTE-Direct Debit is not available on the full range 
												of accounts C if in doubt please refer to your financial institution
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td vAlign="top">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td><strong>Terms And Conditions </strong>
											</td>
										</tr>
										<tr>
											<td class="fontsmall">I/We hereby authorize Ezi Debit Australia Pty Ltd to make 
												periodic withdrawals from the financial institution specified above on behalf 
												of the business as described above. (Hereafter referred to as "the business") 
												The administration of this agreement is conducted by Ezi Debit Australia acting 
												as billing agent for the Business. The services provided by Ezi Debit Australia 
												are administrative to the status of the Agreement and do not extend to the 
												provision of any services or benefits of the Agreement as provided by the 
												Business. This authority shall be interpreted and enforced pursuant to the laws 
												of the state of Queensland . I/We request until further notice in writing to 
												direct debit my/our account described above, any amounts which Ezi Debit 
												Australia, <strong>User ID number 165969 </strong>, may debit or charge me / us 
												through the Ezi Debit system.
											</td>
										</tr>
										<tr>
											<td class="fontsmall">1. The Financial Institution may, in its absolute discretion, 
												determine the order of priority of payments by it if any monies pursuant to 
												this request or any other authority or mandate.
											</td>
										</tr>
										<tr>
											<td class="fontsmall">2. The Financial Institution may, in its absolute discretion, 
												at any time by notice in writing to me / us terminate this request as to future 
												debits.
											</td>
										</tr>
										<tr>
											<td class="fontsmall">3. The user may, by prior arrangement and advice to me / we 
												vary the amount or frequency of future debits.
											</td>
										</tr>
										<tr>
											<td class="fontsmall">
												<p align="left">4. You are advised to verify account details against a recent bank 
													statement and if uncertain you should contact your financial institution.
												</p>
											</td>
										</tr>
										<tr>
											<td class="fontsmall">
												<p align="left">5. It is your responsibility to ensure that you have sufficient 
													clear funds in your nominated account to enable the direct debit to be honoured 
													by your financial institution. Direct debits normally occur overnight; however 
													transactions can take up to three (3) days depending on your financial 
													institution.
												</p>
											</td>
										</tr>
										<tr>
											<td class="fontsmall">
												<p align="left">6. Any dispute arising from this or subsequent direct debits will 
													be in the first instance directed to the business or Ezi Debit Australia . If 
													no resolution is forthcoming you are advised to contact your financial 
													institution.
												</p>
											</td>
										</tr>
										<tr>
											<td class="fontsmall">
												<p align="left">7. We will keep your information about your nominated account at 
													the financial institution private and confidential unless this information is 
													required to investigate a claim made in it relating to an alleged incorrect or 
													wrongful debt, or otherwise required by law.
												</p>
											</td>
										</tr>
										<tr>
											<td class="fontsmall">
												<p>8. By signing this form I/We agree to give 14 working days notice of 
													cancellation in writing to the business.
												</p>
											</td>
										</tr>
										<tr>
											<td class="fontsmall">
												<p>9. I/We authorise the Debit User to verify the details of the abovementioned 
													account with my/our Financial Institution.
												</p>
											</td>
										</tr>
										<tr>
											<td class="fontsmall">
												<p>10. I/We authorise the Financial Institution to release information allowing the 
													Debit User to verify the above mentioned account details.
													<br>
													<br>
												</p>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table cellSpacing="0" cellPadding="0" width="645" border="0" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid">
										<tr>
											<td align="center" colSpan="2"><strong>This authority is to remain in force in 
													accordance with the terms and conditions
													<br>
												</strong><strong>as described on this page, and I / we have read and understand the 
													same. </strong>
											</td>
										</tr>
										<tr>
											<td width="342">Signatory of Nominated Account
												<br>
												<INPUT readonly type="text" width="260" style="WIDTH: 256px; HEIGHT: 22px" size="37"></td>
											<td>Date
												<br>
												<INPUT readonly type="text">
											</td>
										</tr>
										<tr>
											<td width="342">Signatory of Nominated Account
												<br>
												<INPUT readonly type="text" width="260" style="WIDTH: 256px; HEIGHT: 22px" size="37">
											</td>
											<td>Date
												<br>
												<INPUT readonly type="text"></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td width="30%">
												<table width="195" cellpadding="0" cellspacing="0" border="0" style=" BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid">
													<tr>
														<td>
															<strong><A href="#">Staff Members Name:</A><br>
																<br>
																_________________________ </strong>
														</td>
													</tr>
												</table>
											</td>
											<td width="71%">
												<table cellSpacing="0" cellPadding="0" width="450" border="0" style="BORDER-RIGHT: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid">
													<tr>
														<td><strong><A href="#">Ezi Debit Office Use Only</A> </strong>
														</td>
													</tr>
													<tr>
														<td>Date Received: &nbsp;Entered By:&nbsp; Reference #:&nbsp;<br>
															<br>
														</td>
													</tr>
												</table>
											</td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center"><A onclick="window.print();" href="#">Print</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:LinkButton id="LinkButton2" runat="server">Back</asp:LinkButton>
						&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
						<asp:linkbutton id="LinkButton1" runat="server">Next</asp:linkbutton></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
