<%@ Page language="c#" Codebehind="CustomInfo.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.CustomInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<style type="text/css"> 
			.unnamed1 { FONT-SIZE: 10px; LINE-HEIGHT: 12px; TEXT-DECORATION: none } .unnamed2 { FONT-SIZE: 10px; LINE-HEIGHT: 12px; TEXT-DECORATION: none } TD { FONT-SIZE: 9pt; LINE-HEIGHT: 20px; FONT-FAMILY: "Arial", "Helvetica", "sans-serif" } .style2 {
	font-size: 19pt;
	font-weight: bold;
}
            </style>
	</HEAD>
	<body LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table width="650" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td><table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td width="21%" rowspan="2"><IMG src="images/logo.gif"></td>
								<td width="79%" height="40"><span class="style2">Customer 
											  Information</span>
								</td>
							</tr>
							<tr>
								<td><div align="right"><strong>Customer No: LT<%=CustomerId%></strong>
								    </div></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
				<td height="25"></td>
				</tr>
				<tr>
					<td><table width="100%" border="0" cellspacing="0" cellpadding="0" style="BORDER-RIGHT: #000000 1px solid; BORDER-TOP: #000000 1px solid; BORDER-LEFT: #000000 1px solid; BORDER-BOTTOM: #000000 1px solid">
							
							<tr>
								<td colspan="4"><strong>1. Personal details</strong></td>
							</tr>
							<tr>
								<td width="20%">Title</td>
								<td width="30%"><%=sdltitle%></td>
								<td width="20%">Marital status</td>
								<td width="30%"><%=sdlmastatus%></td>
							</tr>
							<tr>
								<td>First name</td>
								<td><%=stxfname%></td>
								<td>Middle name(s)</td>
								<td><%=stxmname%></td>
							</tr>
							<tr>
								<td>Surname</td>
								<td><%=stxsname%></td>
								<td colspan="2">Gender &nbsp;<%=sdlgender%>&nbsp;&nbsp;&nbsp;&nbsp;Date of birth 
									&nbsp;<%=sbirth%></td>
							</tr>
							<tr>
								<td>Residential address</td>
								<td><%=stxunitno%>
									<%=stxStreet%></td>
								<td>Residential status</td>
								<td><%=sdlrestatus%></td>
							</tr>
							<tr>
								<td colspan="2">
									Suburb&nbsp;&nbsp;<%=stxSuburb%>
									State&nbsp;&nbsp;<%=stxState%>
									Postcode&nbsp;&nbsp;<%=stxPost%></td>
								<td>Time at this address</td>
								<td><%=stimeaddress%></td>
							</tr>
							<tr>
								<td>Home phone</td>
								<td><%=stxhometel%></td>
								<td>Mobile phone</td>
								<td><%=stxmobiletel%></td>
							</tr>
							<tr>
								<td>Email address</td>
								<td><%=stxEmail%></td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>Driver's licence number</td>
								<td><%=stxlnumber%></td>
								<td>State issued</td>
								<td><%=stxlstate%></td>
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
								<td colspan="4"><strong>2. Employment details</strong></td>
							</tr>
							<tr>
								<td width="20%">Job tiltle</td>
								<td width="30%"><%=stxJob%></td>
								<td width="20%">Time employed</td>
								<td width="30%"><%=stimeemployed%></td>
							</tr>
							<tr>
								<td>Employer name</td>
								<td colspan="3"><%=stxEmployer%></td>
							</tr>
							<tr>
								<td>Employer's address</td>
								<td colspan="3"><%=stxAddress%></td>
							</tr>
							<tr>
								<td>Work pbone</td>
								<td><%=stxPhone%></td>
								<td>Employment status</td>
								<td><%=sdlestatus%></td>
							</tr>
							<tr>
								<td>Net Income</td>
								<td>$<%=stxIncome%>&nbsp;Per&nbsp;<%=sPer%></td>
								<td>Next payday</td>
								<td><%=snpayday%></td>
							</tr>
							<tr>
								<td>Your rent/mortgage payment</td>
								<td><%= sHousePaymentInfo%></td>
								<td>Your regular repayment to other lenders</td>
								<td><%= sOtherLenderInfo%></td>
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
								<td colspan="4"><strong>3. Bank details</strong></td>
							</tr>
							<tr>
								<td width="20%">Bank name</td>
								<td width="30%"><%=stxBank%></td>
								<td width="20%">Branch</td>
								<td width="30%"><%=stxBranch%></td>
							</tr>
							<tr>
								<td>Account name</td>
								<td><%=stxAname%></td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>BSB</td>
								<td><%=stxBsb%></td>
								<td>Account number</td>
								<td><%=stxAnumber%></td>
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
								<td colspan="3"><strong>4. Referees</strong></td>
							</tr>
							<tr>
								<td width="33%">Name</td>
								<td width="33%">Relationship</td>
								<td width="33%">Contact number</td>
							</tr>
							<tr>
								<td><%=stxReName1%></td>
								<td><%=sselReShip1%></td>
								<td><%=stxReNum1%></td>
							</tr>
							<tr>
								<td><%=stxReName2%></td>
								<td><%=sselReShip2%></td>
								<td><%=stxReNum2%></td>
							</tr>
							<tr>
								<td><%=stxReName3%></td>
								<td><%=sselReShip3%></td>
								<td><%=stxReNum3%></td>
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
								<td><strong>5. Declaration and authority</strong></td>
							</tr>
							<tr>
								<td>I have read and understand the particulars which have been completed in this 
									form and state that those particulars are true, complete and correct and have 
									been provided to  Golden Bridge to enable it to determine whether or not to 
									provide to me a Loan for which I hereby make formal application.
									<br>
									I acknowledge and agree that  Golden Bridge may contact my employer, 
									accountant and if applicable landlord/real estate agent and other referee to 
									verify details which I have provided on this form.</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td>&nbsp;</td>
								<td width="77%">&nbsp;</td>
							</tr>
							<tr>
								<td height="25" width="23%"><strong>Applicant’s signature</strong></td>
								<td>______________________________________________________________</td>
							</tr>
							<tr>
								<td height="25"><strong>Print applicant’s name </strong>
								</td>
								<td>______________________________________________________________</td>
							</tr>
							<tr>
								<td height="25"><strong>Date</strong></td>
								<td>______________________________________________________________</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td height="30"><div align="center">
							<asp:TextBox id="txPerSid" runat="server" Width="1px" Visible="False"></asp:TextBox><A onclick="window.print();" href="#">Print</A>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:LinkButton id="LinkButton1" runat="server">Next</asp:LinkButton></div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
