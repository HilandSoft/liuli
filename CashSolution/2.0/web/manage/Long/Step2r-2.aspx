<%@ Page language="c#" Codebehind="Step2r.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Step2r" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<script language="javascript" src="../jslib/commCheck.js" type="text/javascript"></script>
			<script language="javascript">
		function  CheckFeedback2() {		
		var ftxStreet=document.getElementById("txStreet");
		var ftxSuburb=document.getElementById("txSuburb");
		var ftxState=document.getElementById("txState");
		var ftxPost=document.getElementById("txPost");
		
		var fdlrestatus=document.getElementById("dlrestatus");
		var ftxlandlord=document.getElementById("txlandlord");
		var ftxareatel=document.getElementById("txareatel");
		
		var fDropDownList1=document.getElementById("DropDownList1");		
		
		if(!chkNull(ftxStreet.value)) {
		alert(" Field 'Street number' under 'Residential Details' is not valid!");
		ftxStreet.focus();
		return false;
		}
		
		if(!chkNull(ftxSuburb.value)) {
		alert(" Field 'Suburb' under 'Residential Details' is not valid!");
		ftxSuburb.focus();
		return false;
		}
		
		if(!chkNull(ftxState.value)) {
		alert(" Field 'State' under 'Residential Details' is not valid!");
		ftxState.focus();
		return false;
		}
		
		if(!chkNull(ftxPost.value)) {
		alert(" Field 'Postcode' under 'Residential Details' is not valid!");
		ftxPost.focus();
		return false;
		}
		
		if(fdlrestatus.value=="Renting") {
		
		if(!chkNull(ftxlandlord.value)) {
		alert(" Field 'Name of Landlord' under 'Residential Details' is not valid!");
		ftxlandlord.focus();
		return false;
		}
		
		if(!chkNull(ftxareatel.value)) {
		alert(" Field 'Telephone Area Code and Number' under 'Residential Details' is not valid!");
		ftxareatel.focus();
		return false;
		}		
		}
		
		var iyear=fDropDownList1.value;
		if(iyear*1<5) {
		var ftxStreet1=document.getElementById("txStreet1");
		var ftxSuburb1=document.getElementById("txSuburb1");
		var ftxState1=document.getElementById("txState1");
		var ftxPost1=document.getElementById("txPost1");
		
		if(!chkNull(ftxStreet1.value)) {
		alert(" Field 'Street number' under 'Previous Residential Details' is not valid!");
		ftxStreet1.focus();
		return false;
		}
		
		if(!chkNull(ftxSuburb1.value)) {
		alert(" Field 'Suburb' under 'Previous Residential Details' is not valid!");
		ftxSuburb1.focus();
		return false;
		}
		
		if(!chkNull(ftxState1.value)) {
		alert(" Field 'State' under 'Previous Residential Details' is not valid!");
		ftxState1.focus();
		return false;
		}
		
		if(!chkNull(ftxPost1.value)) {
		alert(" Field 'Postcode' under 'Previous Residential Details' is not valid!");
		ftxPost1.focus();
		return false;
		}
		}
		
		return true;
		}
			</script>
			<style type="text/css">
.word1 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
.word2 { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
.style1 {	color: #000000;
	font-size: 7pt;
}
            </style>
	</HEAD>
	<body LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td>
						<uc1:head id="Head1" runat="server"></uc1:head></td>
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
											<td height="20">&nbsp;</td>
											<td class="word2">Pre-qualification</td>
										</tr>
										<tr>
											<td width="17%" height="20"><div align="center"></div>
											</td>
											<td width="83%" class="word2">Apply Now
											</td>
										</tr>
										<tr>
											<td height="20"><div align="center"></div>
											</td>
											<td class="word2">Initial loan information</td>
										</tr>
										<tr>
											<td height="20"><div align="center"><img src="images/1_04.gif" width="16" height="10"></div>
											</td>
											<td class="word1">About yourself</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">About your work</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Your bank details</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Application summary</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Submit application</td>
										</tr>
									</table>
								</td>
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
					<td valign="top">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD colSpan="4" height="30" bgcolor="#cc3300">
									<img src="images/step2.gif" width="400" height="30">
									<asp:TextBox id="txLoanSid" runat="server" Width="1px" Visible="False"></asp:TextBox></TD>
							</TR>
							<tr>
								<td colspan="2" height="10"></td>
							</tr>
							<TR>
								<TD colSpan="4" height="30"><STRONG>Residential Details</STRONG></TD>
							</TR>
							<TR>
								<TD colSpan="4" align="center"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="30" width="30%">
												Residential Status :
											</td>
											<td>
												<asp:DropDownList id="dlrestatus" runat="server" AutoPostBack="True">
													<asp:ListItem Value="Renting">Renting</asp:ListItem>
													<asp:ListItem Value="Own home (no mortgage)">Own home (no mortgage)</asp:ListItem>
													<asp:ListItem Value="Own home (mortgage)">Own home (mortgage)</asp:ListItem>
													<asp:ListItem Value="Parent Relative">Parent/Relative</asp:ListItem>
													<asp:ListItem Value="Boarding">Boarding</asp:ListItem>
													<asp:ListItem Value="Employer supplier">Employer supplier</asp:ListItem>
												</asp:DropDownList>
											</td>
										</tr>
										<tr>
											<td height="30" width="30%">
												Unit / Apartment No :
											</td>
											<td>
												<INPUT id="txunitno" type="text" style="WIDTH:150px" name="textfield2232242" runat="server">
											</td>
										</tr>
									</table>
								</TD>
							</TR>
							<TR>
								<TD height="30">Street:</TD>
								<TD><INPUT id="txStreet" type="text" style="WIDTH:150px" name="textfield22322522" runat="server">
									<FONT color="#ff0000">*</FONT></TD>
								<TD width="15%">Suburb :</TD>
								<TD><INPUT id="txSuburb" type="text" style="WIDTH:150px" name="textfield223225224" runat="server">
									<FONT color="#ff0000">*</FONT></TD>
							</TR>
							<TR>
								<TD height="30">State :</TD>
								<TD><INPUT id="txState" type="text" style="WIDTH:150px" name="textfield223225223" runat="server">
									<FONT color="#ff0000">*</FONT></TD>
								<TD>Postcode :</TD>
							  <TD><INPUT id="txPost" type="text" style="WIDTH:150px" name="textfield223225224" runat="server">
								  <FONT color="#ff0000">* </FONT><span class="style1"> Note: Loans are currently not available to the residents in WA. </span></TD>
							</TR>
							<TR>
								<TD colSpan="4" align="center"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="30" width="30%">
												Time at this address:
											</td>
											<td>
												<asp:DropDownList id="DropDownList1" runat="server" AutoPostBack="True" Width="120">
													<asp:ListItem Value="0" Selected="True">0</asp:ListItem>
													<asp:ListItem Value="1">1</asp:ListItem>
													<asp:ListItem Value="2">2</asp:ListItem>
													<asp:ListItem Value="3">3</asp:ListItem>
													<asp:ListItem Value="4">4</asp:ListItem>
													<asp:ListItem Value="5">5</asp:ListItem>
													<asp:ListItem Value="6">6</asp:ListItem>
													<asp:ListItem Value="7">7</asp:ListItem>
													<asp:ListItem Value="8">8</asp:ListItem>
													<asp:ListItem Value="9">9</asp:ListItem>
													<asp:ListItem Value="10">10</asp:ListItem>
													<asp:ListItem Value="11">11</asp:ListItem>
													<asp:ListItem Value="12">12 or above</asp:ListItem>
												</asp:DropDownList>
												Years
												<SELECT id="txMonth" name="select5" runat="server" style="WIDTH:120px">
													<OPTION value="0" selected>0</OPTION>
													<OPTION value="1">1</OPTION>
													<OPTION value="2">2</OPTION>
													<OPTION value="3">3</OPTION>
													<OPTION value="4">4</OPTION>
													<OPTION value="5">5</OPTION>
													<OPTION value="6">6</OPTION>
													<OPTION value="7">7</OPTION>
													<OPTION value="8">8</OPTION>
													<OPTION value="9">9</OPTION>
													<OPTION value="10">10</OPTION>
													<OPTION value="11">11</OPTION>
													<OPTION value="12">12</OPTION>
												</SELECT>
												Months
											</td>
										</tr>
									</table>
								</TD>
							</TR>
							<TR>
								<TD colSpan="4" height="20">
									<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server" id="Table1">
										<TR>
											<TD colSpan="2" height="30">Landlord or Real Estate Agent Details</TD>
										</TR>
										<TR>
											<TD colSpan="2" height="30">The residential status you selected requires more 
												information. Please enter the details for your Landlord or Real Estate agent 
												below.</TD>
										</TR>
										<TR>
											<TD width="30%" height="30">Name of Landlord or Real Estate Agent :</TD>
											<TD><INPUT id="txlandlord" type="text" style="WIDTH:150px" name="textfield2232252" runat="server">
												<FONT color="#ff0000">*</FONT></TD>
										</TR>
										<TR>
											<TD height="30">Telephone Area Code and Number :</TD>
											<TD><INPUT id="txareatel" type="text" style="WIDTH:150px" name="textfield2232253" runat="server">
												<FONT color="#ff0000">*</FONT></TD>
										</TR>
										<TR>
											<TD colSpan="2" height="30">
											</TD>
										</TR>
									</TABLE>
												<asp:Panel id="Panel1" runat="server" Width="100%" Visible="False">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD height="30"><B>Previous Residential Details</B>
															</TD>
														</TR>
														<TR>
															<TD>
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD width="30%" height="30">Unit / Apartment No :
																		</TD>
																		<TD><INPUT id="txUnitNo1" style="WIDTH: 150px" type="text" name="textfield2232242" runat="server">
																		</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																	<TR>
																		<TD height="30">Street number :</TD>
																		<TD><INPUT id="txStreet1" style="WIDTH: 150px" type="text" name="textfield22322522" runat="server">
																			<FONT color="#ff0000">*</FONT></TD>
																		<TD>Suburb :</TD>
																		<TD><INPUT id="txSuburb1" style="WIDTH: 150px" type="text" name="textfield223225224" runat="server">
																			<FONT color="#ff0000">*</FONT></TD>
																	</TR>
																	<TR>
																		<TD height="30">State :</TD>
																		<TD><INPUT id="txState1" style="WIDTH: 150px" type="text" name="textfield223225223" runat="server">
																			<FONT color="#ff0000">*</FONT></TD>
																		<TD>Postcode :</TD>
																		<TD><INPUT id="txPost1" style="WIDTH: 150px" type="text" name="textfield223225224" runat="server">
																			<FONT color="#ff0000">*</FONT></TD>
																	</TR>
																	<TR>
																		<TD align="center" colSpan="4">
																			<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																				<TR>
																					<TD width="30%" height="30">Time at this address:
																					</TD>
																					<TD><SELECT id="txYear1" style="WIDTH: 120px" name="select5" runat="server">
																							<OPTION value="0" selected>0</OPTION>
																							<OPTION value="1">1</OPTION>
																							<OPTION value="2">2</OPTION>
																							<OPTION value="3">3</OPTION>
																							<OPTION value="4">4</OPTION>
																							<OPTION value="5">5</OPTION>
																							<OPTION value="6">6</OPTION>
																							<OPTION value="7">7</OPTION>
																							<OPTION value="8">8</OPTION>
																							<OPTION value="9">9</OPTION>
																							<OPTION value="10">10</OPTION>
																							<OPTION value="11">11</OPTION>
																							<OPTION value="12 or above">12 or above</OPTION>
																						</SELECT>
																						Years
																						<SELECT id="txMonth1" style="WIDTH: 120px" name="select5" runat="server">
																							<OPTION value="0" selected>0</OPTION>
																							<OPTION value="1">1</OPTION>
																							<OPTION value="2">2</OPTION>
																							<OPTION value="3">3</OPTION>
																							<OPTION value="4">4</OPTION>
																							<OPTION value="5">5</OPTION>
																							<OPTION value="6">6</OPTION>
																							<OPTION value="7">7</OPTION>
																							<OPTION value="8">8</OPTION>
																							<OPTION value="9">9</OPTION>
																							<OPTION value="10">10</OPTION>
																							<OPTION value="11">11</OPTION>
																							<OPTION value="12">12</OPTION>
																						</SELECT>
																						Months
																					</TD>
																				</TR>
																			</TABLE>
																		</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
												</asp:Panel>
								</TD>
							</TR>
							<TR>
								<TD colSpan="4"><hr color="#cc3300" width="100%" size="1">
								</TD>
							</TR>
							<TR>
								<TD colSpan="4" height="30">
									<DIV align="center">
										<INPUT id="Submit2" type="submit" value="Next>>>" name="Submit" runat="server">
									</DIV>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td colspan="3">
						<uc1:bottom id="Bottom1" runat="server"></uc1:bottom></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
