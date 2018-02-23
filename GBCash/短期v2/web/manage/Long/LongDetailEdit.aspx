<%@ Register TagPrefix="cc1" Namespace="YingNet.WeiXing.WebApp.UserControls" Assembly="YingNet.Common" %>
<%@ Page language="c#" Codebehind="LongDetailEdit.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.Long.LongDetailEdit" %>
<%@ Register TagPrefix="cc2" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<%@ Register TagPrefix="uc1" TagName="CircleDropDownList" Src="../../Include/CircleDropDownList.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LongDetailEdit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="2" cellPadding="2" width="775" align="center" border="0">
				<tr>
					<td vAlign="top" width="767">
						<TABLE cellSpacing="2" cellPadding="2" width="100%" border="0">
							<TR>
								<TD colSpan="2" height="30"><STRONG>Initial Loan Details
										<asp:textbox id="TextBox1" runat="server" Width="64px" Visible="False"></asp:textbox></STRONG></TD>
							</TR>
							<TR>
								<TD colSpan="2">What is the primary purpose of the loan?</TD>
							</TR>
							<TR>
								<TD colSpan="2"><asp:textbox id="txtpurpose" runat="server" Width="576px" TextMode="MultiLine" Height="88px"></asp:textbox></TD>
							</TR>
							<TR>
								<TD width="55%">How much would you like to borrow?</TD>
								<TD width="45%" height="20"><asp:textbox id="txtborrow" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD>The term of the loan:</TD>
								<TD height="20"><asp:textbox id="txtdlterms" runat="server"></asp:textbox>Months</TD>
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
								<TD width="27%"><cc2:truefalsedropdownlist id="ddlexisting" runat="server"></cc2:truefalsedropdownlist></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Customer Reference Number :</TD>
								<TD colSpan="2" height="20"><asp:textbox id="txtrefnumber" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="4" height="20">For existing Golden Bridge customers only</TD>
							</TR>
							<TR>
								<TD width="25%" height="20">Title/Salutation :</TD>
								<TD width="25%" height="20"><asp:textbox id="txtdltitle" runat="server"></asp:textbox></TD>
								<TD width="25%" height="20">&nbsp;</TD>
								<TD width="27%">&nbsp;</TD>
							</TR>
							<TR>
								<TD height="20">First Name :</TD>
								<TD height="20"><asp:textbox id="txtfname" runat="server"></asp:textbox></TD>
								<TD height="20">Middle Name :</TD>
								<TD><asp:textbox id="txtmname" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD height="20">Surname :</TD>
								<TD height="20"><asp:textbox id="txtsname" runat="server"></asp:textbox></TD>
								<TD height="20">&nbsp;</TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD height="20">Gender :</TD>
								<TD height="20"><asp:textbox id="txtdlgender" runat="server"></asp:textbox></TD>
								<TD height="20">&nbsp;</TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD height="20">Date of Birth :</TD>
								<TD colSpan="3" height="20"><asp:textbox id="txtbirthDD" runat="server" Width="32px"></asp:textbox><FONT face="宋体">/</FONT>
									<asp:textbox id="txtbirthMM" runat="server" Width="32px"></asp:textbox><FONT face="宋体">/</FONT>
									<asp:textbox id="txtbirthYYYY" runat="server" Width="56px"></asp:textbox><FONT face="宋体">(DD/MM/YYYY)</FONT></TD>
							</TR>
							<TR>
								<TD colSpan="3" height="20">Home telephone area code and number :</TD>
								<TD><asp:textbox id="txthometel" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="3" height="20">Work telephone area code and number :</TD>
								<TD><asp:textbox id="txtworktel" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Mobile telephone number :</TD>
								<TD colSpan="2" height="20"><asp:textbox id="txtmobiletel" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Email Address :</TD>
								<TD colSpan="2" height="20"><asp:textbox id="txtEmail" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Driver's licence number :</TD>
								<TD height="20"><asp:textbox id="txtlnumber" runat="server"></asp:textbox></TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Driver's licence state :</TD>
								<TD height="20"><asp:textbox id="txtlstate" runat="server"></asp:textbox></TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Marital Status :</TD>
								<TD colSpan="2" height="20"><asp:textbox id="txtdlmastatus" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="4" height="30">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td colSpan="3" height="40"><strong>Referees </strong>
											</td>
										</tr>
										<tr>
											<td width="33%" height="20">Name
											</td>
											<td width="33%">Relationship
											</td>
											<td width="33%">Contact Number
											</td>
										</tr>
										<tr>
											<td height="20"><asp:textbox id="txtReName1" runat="server"></asp:textbox></td>
											<td><asp:textbox id="txtselReShip1" runat="server"></asp:textbox></td>
											<td><asp:textbox id="txtReNum1" runat="server"></asp:textbox></td>
										</tr>
										<tr>
											<td height="20"><asp:textbox id="txtReName2" runat="server"></asp:textbox></td>
											<td><asp:textbox id="txtselReShip2" runat="server"></asp:textbox></td>
											<td><asp:textbox id="txtReNum2" runat="server"></asp:textbox></td>
										</tr>
										<tr>
											<td height="20"><asp:textbox id="txtReName3" runat="server"></asp:textbox></td>
											<td><asp:textbox id="txtselReShip3" runat="server"></asp:textbox></td>
											<td><asp:textbox id="txtReNum3" runat="server"></asp:textbox></td>
										</tr>
									</table>
								</TD>
							</TR>
							<TR>
								<TD colSpan="4" height="30"><STRONG>Residential Details</STRONG></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Residential Status</TD>
								<TD colSpan="2" height="20"><asp:textbox id="txtdlrestatus" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Unit / Apartment No</TD>
								<TD colSpan="2" height="20"><asp:textbox id="txtunitno" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD height="20">Street number</TD>
								<TD height="20"><asp:textbox id="txtStreet" runat="server"></asp:textbox></TD>
								<TD height="20">Suburb</TD>
								<TD><asp:textbox id="txtSuburb" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD height="20">State</TD>
								<TD height="20"><asp:textbox id="txtState" runat="server"></asp:textbox></TD>
								<TD height="20">Postcode</TD>
								<TD><asp:textbox id="txtPost" runat="server"></asp:textbox></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">Time at this address:</TD>
								<TD colSpan="2" height="20"><asp:textbox id="txttimeaddressYear" runat="server" Width="40px"></asp:textbox>Year(s)<asp:textbox id="txttimeaddressMonth" runat="server" Width="32px"></asp:textbox>Month(s)</TD>
							</TR>
							<TR>
								<TD colSpan="4" height="20">
									<TABLE cellSpacing="2" cellPadding="0" width="100%" border="0">
										<TR>
											<TD colSpan="2" height="30"><STRONG>Landlord or Real Estate Agent Details</STRONG></TD>
										</TR>
										<TR>
											<TD width="56%" height="20">Name of Landlord or Real Estate Agent</TD>
											<TD width="44%"><asp:textbox id="txtlandlord" runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD height="20">Telephone Area Code and Number</TD>
											<TD><asp:textbox id="txtareatel" runat="server"></asp:textbox></TD>
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
											<TD><asp:textbox id="txtstxunitno1" runat="server"></asp:textbox></TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
										<TR>
											<TD width="15%" height="25">Street number :</TD>
											<TD height="25"><asp:textbox id="txtstxStreet1" runat="server"></asp:textbox></TD>
											<TD width="15%" height="25">Suburb :</TD>
											<TD><asp:textbox id="txtstxSuburb1" runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD height="25">State :</TD>
											<TD height="25"><asp:textbox id="txtstxState1" runat="server"></asp:textbox></TD>
											<TD height="25">Postcode :</TD>
											<TD><asp:textbox id="txtstxPost1" runat="server"></asp:textbox></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="4">
												<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
													<TR>
														<TD width="30%" height="25">Time at this address:
														</TD>
														<TD><asp:textbox id="txtstimeaddress1Year" runat="server" Width="40px"></asp:textbox>Year(s)<asp:textbox id="txtstimeaddress1Month" runat="server" Width="32px"></asp:textbox>Month(s)</TD>
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
						<table cellSpacing="0" cellPadding="0" width="98%" border="0">
							<tr>
								<td colSpan="2" height="30"><strong>Employment Information</strong></td>
							</tr>
							<tr>
								<td width="49%" height="20">Employer Name :</td>
								<td width="51%"><asp:textbox id="txtEmployer" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td height="20">Employer's Address:
								</td>
								<td><asp:textbox id="txtAddress" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td height="20">Employer telephone area code and number:
								</td>
								<td><asp:textbox id="txtPhone" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td height="20">Employment Status :
								</td>
								<td><asp:textbox id="txtdlestatus" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td height="20">Job Title
								</td>
								<td><asp:textbox id="txtJob" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td height="20">Time Employed:
								</td>
								<td><asp:textbox id="txttimeemployedYear" runat="server" Width="40px"></asp:textbox>Year(s)
									<asp:textbox id="txttimeemployedMonth" runat="server" Width="40px"></asp:textbox>Month(s)
								</td>
							</tr>
							<tr>
								<td height="20">Take home pay after taxes:
								</td>
								<td><asp:textbox id="txtIncome" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td height="20">Per:</td>
								<td><cc2:perdropdownlist id="ddlPer" runat="server"></cc2:perdropdownlist></td>
							</tr>
							<tr>
								<td height="20">Next Payday:
								</td>
								<td><asp:textbox id="txtnpaydayDD" runat="server" Width="32px"></asp:textbox><FONT face="宋体">/</FONT>
									<asp:textbox id="txtnpaydayMM" runat="server" Width="32px"></asp:textbox><FONT face="宋体">/</FONT>
									<asp:textbox id="txtnpaydayYYYY" runat="server" Width="56px"></asp:textbox><FONT face="宋体">(DD/MM/YYYY)</FONT></td>
							</tr>
							<TR>
								<TD>Rent/mortgage payment:</TD>
								<TD>$<INPUT id="txtHousePaymentValue" type="text" size="12" name="txtHousePaymentValue" runat="server">
									<uc1:CircleDropDownList id="ddlHousePaymentCircle" runat="server"></uc1:CircleDropDownList></TD>
							</TR>
							<TR>
								<TD>Regular repayment to other lenders:</TD>
								<TD>$<INPUT id="txtOtherLenderValue" type="text" size="12" name="txtOtherLenderValue" runat="server">&nbsp;
									<uc1:CircleDropDownList id="ddlOtherLenderCircle" runat="server"></uc1:CircleDropDownList></TD>
							</TR>
							<tr>
								<td colSpan="2" height="40"><strong>Bank Information </strong>
								</td>
							</tr>
							<tr>
								<td colSpan="2" height="20">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td>Bank Name:
											</td>
											<td><asp:textbox id="txtBank" runat="server"></asp:textbox></td>
											<td>Branch:
											</td>
											<td><asp:textbox id="txtBranch" runat="server"></asp:textbox></td>
										</tr>
										<tr>
											<td>Account Name:
											</td>
											<td colSpan="3"><asp:textbox id="txtAname" runat="server"></asp:textbox></td>
										</tr>
										<tr>
											<td>BSB:
											</td>
											<td><asp:textbox id="txtBsb" runat="server"></asp:textbox></td>
											<td>Account Number:
											</td>
											<td><asp:textbox id="txtAnumber" runat="server"></asp:textbox></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colSpan="2" height="20">Preferred methods of contact for this loan:
									<asp:textbox id="txtmethods" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td colSpan="2" height="20">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2" height="20">
									<div align="center">
										<asp:Button id="Calculate" runat="server" Text="Calculate"></asp:Button><FONT face="宋体">&nbsp;
										</FONT>
										<asp:button id="SaveButton" runat="server" Text="Save"></asp:button><STRONG>&nbsp;</STRONG><A href="LongList.aspx"><STRONG>Return</STRONG></A></div>
								</td>
							</tr>
						</table>
						<div align="center">
							(if change schedule,pls must Calculate first)</div>
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
