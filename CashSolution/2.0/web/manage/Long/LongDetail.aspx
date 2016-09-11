<%@ Page language="c#" Codebehind="LongDetail.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.Long.LongDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MemberDetail</title>
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<LINK href="../csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<table width="775" border="0" cellspacing="2" cellpadding="2" align="center">
				<tr>
					<td width="767" valign="top">
						<TABLE cellSpacing="2" cellPadding="2" width="100%" border="0">
							<TR>
								<TD colSpan="2" height="30"><STRONG>Initial Loan Details
										<asp:TextBox id="TextBox1" runat="server" Width="64px" Visible="False"></asp:TextBox></STRONG></TD>
							</TR>
							<TR>
								<TD colSpan="2">What is the primary purpose of the loan?</TD>
							</TR>
							<TR>
								<TD colSpan="2" style="width:550px; word-wrap:break-word;"><%=txpurpose%></TD>
							</TR>
							<TR>
								<TD width="55%">How much would you like to borrow?</TD>
								<TD width="45%" height="20"><%=txborrow%></TD>
							</TR>
							<TR>
								<TD>Please select the term of the loan:</TD>
								<TD height="20"><%=dlterms%></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD height="20">&nbsp;</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td>
						<TABLE cellSpacing="0" cellPadding="2" width="99%" border="0">
							<TR>
								<TD colSpan="4" height="30"><STRONG>Personal Details</STRONG></TD>
							</TR>
							<TR>
								<TD colSpan="3" height="20">Are you an existing Golden Bridge customer?</TD>
								<TD width="27%"><%=dlexisting%></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Customer Reference Number :</TD>
								<TD colSpan="2" height="20"><%=txrefnumber%></TD>
							</TR>
							<TR>
								<TD colSpan="4" height="20">For existing Golden Bridge customers only</TD>
							</TR>
							<TR>
								<TD width="25%" height="20">Title/Salutation :</TD>
								<TD width="25%" height="20"><%=dltitle%>
								</TD>
								<TD width="25%" height="20">&nbsp;</TD>
								<TD width="27%">&nbsp;</TD>
							</TR>
							<TR>
								<TD height="20">First Name :</TD>
								<TD height="20"><%=txfname%></TD>
								<TD height="20">Middle Name :</TD>
								<TD><%=txmname%></TD>
							</TR>
							<TR>
								<TD height="20">Surname :</TD>
								<TD height="20"><%=txsname%>
								</TD>
								<TD height="20">&nbsp;</TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD height="20">Gender :</TD>
								<TD height="20"><%=dlgender%></TD>
								<TD height="20">&nbsp;</TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD height="20">Date of Birth :</TD>
								<TD colSpan="3" height="20"><%=birth%></TD>
							</TR>
							<TR>
								<TD colSpan="3" height="20">Home telephone area code and number :</TD>
								<TD><%=txhometel%></TD>
							</TR>
							<TR>
								<TD colSpan="3" height="20">Work telephone area code and number :</TD>
								<TD><%=txworktel%></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Mobile telephone number :</TD>
								<TD colSpan="2" height="20"><%=txmobiletel%>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Email Address :</TD>
								<TD colSpan="2" height="20"><%=txEmail%>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Driver's licence number :</TD>
								<TD height="20"><%=txlnumber%></TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Driver's licence state :</TD>
								<TD height="20"><%=txlstate%></TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Marital Status :</TD>
								<TD colSpan="2" height="20"><%=dlmastatus%></TD>
							</TR>
							<TR>
								<TD colSpan="4" height="30"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="40" colspan="3">
												<strong>Referees </strong>
											</td>
										</tr>
										<tr>
											<td width="33%" height="20">
												Name
											</td>
											<td width="33%">
												Relationship
											</td>
											<td width="33%">
												Contact Number
											</td>
										</tr>
										<tr>
											<td height="20"><%=txReName1%></td>
											<td><%=selReShip1%></td>
											<td><%=txReNum1%></td>
										</tr>
										<tr>
											<td height="20"><%=txReName2%></td>
											<td><%=selReShip2%></td>
											<td><%=txReNum2%></td>
										</tr>
										<tr>
											<td height="20"><%=txReName3%></td>
											<td><%=selReShip3%></td>
											<td><%=txReNum3%></td>
										</tr>
									</table>
								</TD>
							</TR>
							<TR>
								<TD colSpan="4" height="30"><STRONG>Residential Details</STRONG></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Residential Status</TD>
								<TD colSpan="2" height="20"><%=dlrestatus%></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Unit / Apartment No</TD>
								<TD colSpan="2" height="20"><%=txunitno%></TD>
							</TR>
							<TR>
								<TD height="20">Street number</TD>
								<TD height="20"><%=txStreet%></TD>
								<TD height="20">Suburb</TD>
								<TD><%=txSuburb%></TD>
							</TR>
							<TR>
								<TD height="20">State</TD>
								<TD height="20"><%=txState%></TD>
								<TD height="20">Postcode</TD>
								<TD><%=txPost%></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Time at this address:</TD>
								<TD colSpan="2" height="20"><%=timeaddress%></TD>
							</TR>
							<TR>
								<TD colSpan="4" height="20">
									<TABLE cellSpacing="2" cellPadding="0" width="100%" border="0">
										<TR>
											<TD colSpan="2" height="30"><STRONG>Landlord or Real Estate Agent Details</STRONG></TD>
										</TR>
										<TR>
											<TD width="56%" height="20">Name of Landlord or Real Estate Agent</TD>
											<TD width="44%"><%=txlandlord%></TD>
										</TR>
										<TR>
											<TD height="20">Telephone Area Code and Number</TD>
											<TD><%=txareatel%></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<TR>
					<TD colSpan="4">
						<TABLE id="tbUnit" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
							<TR>
								<TD height="30"><STRONG>Previous Residential Details </STRONG>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="30%" height="25">Unit / Apartment No :
											</TD>
											<TD><%=stxunitno1%></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="15%" height="25">Street number :</TD>
											<TD height="25"><%=stxStreet1%></TD>
											<TD width="15%" height="25">Suburb :</TD>
											<TD><%=stxSuburb1%></TD>
										</TR>
										<TR>
											<TD height="25">State :</TD>
											<TD height="25"><%=stxState1%></TD>
											<TD height="25">Postcode :</TD>
											<TD><%=stxPost1%></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="4">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD width="30%" height="25">Time at this address:
														</TD>
														<TD><%=stimeaddress1%></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
						</TABLE>
					</TD>
				</TR>
				<tr>
					<td>
						<table width="98%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td height="30" colspan="2"><strong>Employment Information</strong></td>
							</tr>
							<tr>
								<td height="20" width="49%">
									Employer Name :</td>
								<td width="51%"><%=txEmployer%></td>
							</tr>
							<tr>
								<td height="20">
									Employer's Address:
								</td>
								<td><%=txAddress%></td>
							</tr>
							<tr>
								<td height="20">
									Employer telephone area code and number:
								</td>
								<td><%=txPhone%></td>
							</tr>
							<tr>
								<td height="20">
									Employment Status :
								</td>
								<td><%=dlestatus%></td>
							</tr>
							<tr>
								<td height="20">
									Job Title
								</td>
								<td><%=txJob%></td>
							</tr>
							<tr>
								<td height="20">
									Time Employed:
								</td>
								<td><%=timeemployed%>
								</td>
							</tr>
							<tr>
								<td height="20">
									Take home pay after taxes:
								</td>
								<td><%=txIncome%></td>
							</tr>
							<tr>
								<td height="20">Per:</td>
								<td><%=Per%></td>
							</tr>
							<tr>
								<td height="20">
									Next Payday:
								</td>
								<td><%=npayday%></td>
							</tr>
							<TR>
								<TD>Your rent/mortgage payment:</TD>
								<TD><%= sHousePaymentInfo%></TD>
							</TR>
							<TR>
								<TD>Your regular repayment to other lenders:</TD>
								<TD><%= sOtherLenderInfo%></TD>
							</TR>
							<tr>
								<td height="40" colspan="2"><strong>Bank Information </strong>
								</td>
							</tr>
							<tr>
								<td height="20" colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td>
												Bank Name:
											</td>
											<td><%=txBank%></td>
											<td>
												Branch:
											</td>
											<td><%=txBranch%></td>
										</tr>
										<tr>
											<td>
												Account Name:
											</td>
											<td colspan="3"><%=txAname%></td>
										</tr>
										<tr>
											<td>
												BSB:
											</td>
											<td><%=txBsb%></td>
											<td>
												Account Number:
											</td>
											<td><%=txAnumber%></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td height="20" colspan="2">
									Preferred methods of contact for this loan:
									<%=methods%>
								</td>
							</tr>
							<tr>
								<td height="20" colspan="2">&nbsp;</td>
							</tr>
							<tr>
								<td height="20" colspan="2"><div align="center">
										<asp:HyperLink id="hpEdit" runat="server"><STRONG>Edit</STRONG></asp:HyperLink>&nbsp;<strong><a href="LongList.aspx">Return</a></strong></div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
