<%@ Page language="c#" Codebehind="Index.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Member.Index" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<script language="javascript" src="../../jslib/commCheck.js" type="text/javascript"></script>
			<script language="javascript">		
		function  CheckFeedback2() {
		var ftxfname=document.getElementById("txfname");
		var ftxsname=document.getElementById("txsname");
		var ftxDated=document.getElementById("txDated");
		var ftxDatem=document.getElementById("txDatem");
		var ftxDatey=document.getElementById("txDatey");		
		var ftxEmail=document.getElementById("txEmail");
		
		var ftxStreet=document.getElementById("txStreet");
		var ftxSuburb=document.getElementById("txSuburb");
		var ftxState=document.getElementById("txState");
		var ftxPost=document.getElementById("txPost");
		
		var fdlrestatus=document.getElementById("dlrestatus");
		var ftxlandlord=document.getElementById("txlandlord");
		var ftxareatel=document.getElementById("txareatel");
		//alert(fdlrestatus.value);
		
		if(!chkNull(ftxfname.value)) {
		alert(" Field 'First Name' under 'Personal Information' is not valid!");
		ftxfname.focus();
		return false;
		}
		
		if(!chkNull(ftxsname.value)) {
		alert(" Field 'Surname' under 'Personal Information' is not valid!");
		ftxsname.focus();
		return false;
		}
		
		if(!chkNull(ftxDated.value)) {
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDated.focus();
		return false;
		}
		
		if(!chkdigital(ftxDated.value)) {
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDated.focus();
		return false;
		}
		
		if(ftxDated.value.length>2){
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDated.focus();
		return false;
		}
		
		if(!chkNull(ftxDatem.value)) {
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDatem.focus();
		return false;
		}
		
		if(!chkdigital(ftxDatem.value)) {
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDatem.focus();
		return false;
		}
		
		if(ftxDatem.value.length>2){
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDatem.focus();
		return false;
		}
		
		if(!chkNull(ftxDatey.value)) {
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDatey.focus();
		return false;
		}
		
		if(!chkdigital(ftxDatey.value)) {
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDatey.focus();
		return false;
		}
		
		if(ftxDatey.value.length!=4){
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDatey.focus();
		return false;
		}
		
		if(!chkNull(ftxEmail.value)) {
		alert(" Field 'Email' under 'Personal Information' is not valid!");
		ftxEmail.focus();
		return false;
		}
		
		if(!isEmail(ftxEmail.value)) {
		alert(" Field 'Email' under 'Personal Information' is not valid!");
		ftxEmail.focus();
		return false;
		}
		
		
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
		alert(" Field 'Telephone Area Code' under 'Residential Details' is not valid!");
		ftxareatel.focus();
		return false;
		}
		
		}
		
		return true;
		}
		
		
		function  CheckFeedback4() {		
		var ftxBranch=document.getElementById("txBranch");
		var ftxBank=document.getElementById("txBank");
		var ftxAname=document.getElementById("txAname");
		var ftxBsb=document.getElementById("txBsb");
		var ftxAnumber=document.getElementById("txAnumber");
		var ftxCAnumber=document.getElementById("txCAnumber");
			
		
		if(!chkNull(ftxBank.value)) {
		alert(" Field 'Bank Name' under 'Bank Information' is not valid!");
		ftxBank.focus();
		return false;
		}
		
		if(!chkNull(ftxBranch.value)) {
		alert(" Field 'Branch' under 'Bank Information' is not valid!");
		ftxBranch.focus();
		return false;
		}
		
		if(!chkNull(ftxAname.value)) {
		alert(" Field 'Account Name' under 'Bank Information' is not valid!");
		ftxAname.focus();
		return false;
		}
		
		if(!chkNull(ftxBsb.value)) {
		alert(" Field 'BSB' under 'Bank Information' is not valid!");
		ftxBsb.focus();
		return false;
		}
		
		if(!chkNull(ftxAnumber.value)) {
		alert(" Field 'Bank Account Number' under 'Bank Information' is not valid!");
		ftxAnumber.focus();
		return false;
		}
		
		if(!chkNull(ftxCAnumber.value)) {
		alert(" You must confirm your account number by re-typing it!");
		ftxCAnumber.focus();
		return false;
		}
		
		if(ftxAnumber.value!=ftxCAnumber.value)  {
		alert(" You must confirm your account number by re-typing it!");
		ftxCAnumber.focus();
		return false;
		}		
			
		return true;
		}	
			</script>
			<style type="text/css">.word1 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	.word2 { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	A.word3:link { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	A.word3:hover { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	A.word3:visited { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	A.word3:active { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	</style>
	</HEAD>
	<body leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td><uc1:head id="Head1" runat="server"></uc1:head></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="990" align="center" border="0">
				<tr>
					<td colspan="3" height="10"></td>
				</tr>
				<tr>
					<td width="5">&nbsp;</td>
					<td vAlign="top" align="left" width="200">
						<table cellSpacing="0" cellPadding="0" width="190" border="0">
							<tr>
								<td><IMG height="18" alt="" src="images/1_01.gif" width="190"></td>
							</tr>
							<tr>
								<td background="images/1_07.gif">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td width="17%" height="20">
												<div align="center"><IMG height="10" src="images/1_04.gif" width="16"></div>
											</td>
											<td width="83%">
												<a href="Index.aspx" class="word3">Customer Details</a>
											</td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"></div>
											</td>
											<td>
												<a href="MyLoan.aspx" class="word3">My Loans</a></td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"></div>
											</td>
											<td>
												<a href="ChangePwd.aspx" class="word3">Change Password</a></td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"></div>
											</td>
											<td>
												<a href="ContactUs.aspx" class="word3">Contact Us</a></td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"></div>
											</td>
											<td class="word2">
												<a href="Logout.aspx" class="word3">Logout</a></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><IMG height="5" alt="" src="images/1_09.gif" width="190"></td>
							</tr>
							<tr>
								<td align="center"><br>
									<img src="../images/contact2.gif" width="160" height="106" alt=""></td>
							</tr>
						</table>
					</td>
					<td vAlign="top">
						<table width="100%" border="0" cellSpacing="0" cellPadding="0">
							<tr>
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td bgColor="#cc3300"><IMG height="30" src="images/details.gif" width="400">
												<asp:textbox id="txLoanSid" runat="server" Width="79px" Visible="False"></asp:textbox></td>
										</tr>
										<tr>
											<td height="15"></td>
										</tr>
										<tr>
											<td>Please thoroughly check the details you have entered. You may amend any 
												information by selecting the "Edit this section" link and inputting the correct 
												information. You may print this confirmation page by selecting the print option 
												at the bottom of the screen.</td>
										</tr>
										<tr>
											<td>When you are satisfied with the details, please complete the Declaration and 
												Authority below then select "Submit Application" at the bottom of the screen.</td>
										</tr>
										<tr>
											<td>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><asp:panel id="Panel3" runat="server">
										<TABLE cellSpacing="0" cellPadding="2" width="99%" border="0">
											<TR>
												<TD colSpan="4" height="30"><STRONG>Personal Details&nbsp;&nbsp; </STRONG>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="35%" height="25">Are you an existing Golden Bridge customer?
															</TD>
															<TD><%=sdlexisting%></TD>
														</TR>
														<TR>
															<TD width="35%" height="25">Customer Reference Number :
															</TD>
															<TD><%=stxrefnumber%>&nbsp;&nbsp;(For existing Golden Bridge customers only)
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD width="15%" height="25">Title/Salutation :</TD>
												<TD><%=sdltitle%></TD>
												<TD width="15%">&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="25">First Name :</TD>
												<TD height="25"><%=stxfname%></TD>
												<TD height="25">Middle Name :</TD>
												<TD><%=stxmname%></TD>
											</TR>
											<TR>
												<TD height="25">Surname :</TD>
												<TD height="25"><%=stxsname%></TD>
												<TD height="25">&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="25">Gender :</TD>
												<TD height="25"><%=sdlgender%></TD>
												<TD height="25">&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="25">Date of Birth :</TD>
												<TD colSpan="3" height="20"><%=sbirth%></TD>
											</TR>
											<TR>
												<TD colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="35%" height="25">Home telephone area code and number :
															</TD>
															<TD><%=stxhometel%></TD>
														</TR>
														<TR>
															<TD width="35%" height="25">Work telephone area code and number :
															</TD>
															<TD><%=stxworktel%></TD>
														</TR>
														<TR>
															<TD width="35%" height="25">Mobile telephone number :
															</TD>
															<TD><%=stxmobiletel%></TD>
														</TR>
														<TR>
															<TD width="35%" height="25">Email Address :
															</TD>
															<TD><%=stxEmail%></TD>
														</TR>
														<TR>
															<TD width="35%" height="25">Driver's licence number :
															</TD>
															<TD><%=stxlnumber%></TD>
														</TR>
														<TR>
															<TD width="35%" height="25">Driver's licence state :
															</TD>
															<TD><%=stxlstate%></TD>
														</TR>
														<TR>
															<TD width="35%" height="25">Marital Status :
															</TD>
															<TD><%=sdlmastatus%></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD align="center" colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="90%" border="0">
														<TR>
															<TD colSpan="3" height="25"><STRONG>Referees </STRONG>
															</TD>
														</TR>
														<TR>
															<TD colSpan="3" height="20">
																<P>Please provide 3 referees (relative preferred).
																</P>
															</TD>
														</TR>
														<TR>
															<TD width="33%" height="20">Name
															</TD>
															<TD width="33%">Relationship
															</TD>
															<TD width="33%">Contact Number
															</TD>
														</TR>
														<TR>
															<TD height="20"><%=stxReName1%></TD>
															<TD><%=sselReShip1%></TD>
															<TD><%=stxReNum1%></TD>
														</TR>
														<TR>
															<TD height="20"><%=stxReName2%></TD>
															<TD><%=sselReShip2%></TD>
															<TD><%=stxReNum2%></TD>
														</TR>
														<TR>
															<TD height="20"><%=stxReName3%></TD>
															<TD><%=sselReShip3%></TD>
															<TD><%=stxReNum3%><FONT color="#ff0000">&nbsp; </FONT>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4" height="30"><STRONG>Residential Details </STRONG>
												</TD>
											</TR>
											<TR>
												<TD align="center" colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="30%" height="25">Residential Status :
															</TD>
															<TD><%=sdlrestatus%></TD>
														</TR>
														<TR>
															<TD width="30%" height="25">Unit / Apartment No :
															</TD>
															<TD><%=stxunitno%></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD height="25">Street number</TD>
												<TD height="25"><%=stxStreet%></TD>
												<TD height="25">Suburb</TD>
												<TD><%=stxSuburb%></TD>
											</TR>
											<TR>
												<TD height="25">State</TD>
												<TD height="25"><%=stxState%></TD>
												<TD height="25">Postcode</TD>
												<TD><%=stxPost%></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="30%" height="25">Time at this address:
															</TD>
															<TD><%=stimeaddress%></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4" height="20">
													<TABLE cellSpacing="2" cellPadding="0" width="100%" border="0">
														<TR>
															<TD colSpan="2" height="25">Landlord or Real Estate Agent Details</TD>
														</TR>
														<TR>
															<TD colSpan="2" height="25">The residential status you selected requires more 
																information. Please enter the details for your Landlord or Real Estate agent 
																below.</TD>
														</TR>
														<TR>
															<TD width="30%" height="25">Name of Landlord or Real Estate Agent</TD>
															<TD><%=stxlandlord%></TD>
														</TR>
														<TR>
															<TD height="25">Telephone Area Code and Number</TD>
															<TD><%=stxareatel%></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4" height="25">
													<DIV align="center"><INPUT id="bnEdit2" type="submit" value="Edit>>>" name="Submit22" runat="server">
													</DIV>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4">
													<HR width="100%" color="#cc3300" SIZE="1">
												</TD>
											</TR>
										</TABLE>
									</asp:panel></td>
							</tr>
							<tr>
								<td><asp:panel id="Panel4" runat="server">
										<TABLE cellSpacing="0" cellPadding="2" width="99%" border="0">
											<TR>
												<TD colSpan="4" height="30"><STRONG>Personal Details&nbsp;&nbsp;
														<asp:TextBox id="txPerSid" runat="server" Visible="False" Width="56px"></asp:TextBox></STRONG></TD>
											</TR>
											<TR>
												<TD colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="35%" height="30">Are you an existing Golden Bridge customer?
															</TD>
															<TD><SELECT id="dlexisting" name="select2" runat="server">
																	<OPTION value="1" selected>Yes</OPTION>
																	<OPTION value="0">No</OPTION>
																</SELECT>
															</TD>
														</TR>
														<TR>
															<TD width="35%" height="30">Customer Reference Number :
															</TD>
															<TD><INPUT id="txrefnumber" style="WIDTH: 150px" type="text" name="textfield2" runat="server">&nbsp;&nbsp;(For 
																existing Golden Bridge customers only)
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD width="15%" height="30">Title/Salutation :</TD>
												<TD><SELECT id="dltitle" style="WIDTH: 150px" name="select2" runat="server">
														<OPTION value="Mr" selected>Mr</OPTION>
														<OPTION value="Mrs">Mrs</OPTION>
														<OPTION value="Miss">Miss</OPTION>
														<OPTION value="Ms">Ms</OPTION>
														<OPTION value="Dr">Dr</OPTION>
													</SELECT>
												</TD>
												<TD width="15%">&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="30">First Name :</TD>
												<TD><INPUT id="txfname" style="WIDTH: 150px" type="text" name="textfield2" runat="server">
													<FONT color="#ff0000">*</FONT></TD>
												<TD>Middle Name :</TD>
												<TD><INPUT id="txmname" style="WIDTH: 150px" type="text" name="textfield22" runat="server"></TD>
											</TR>
											<TR>
												<TD height="30">Surname :</TD>
												<TD><INPUT id="txsname" style="WIDTH: 150px" type="text" name="textfield222" runat="server">
													<FONT color="#ff0000">*</FONT></TD>
												<TD>&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="30">Gender :</TD>
												<TD><SELECT id="dlgender" style="WIDTH: 150px" name="select3" runat="server">
														<OPTION value="Male" selected>Male</OPTION>
														<OPTION value="Female">Female</OPTION>
													</SELECT></TD>
												<TD height="20">&nbsp;</TD>
												<TD>&nbsp;</TD>
											</TR>
											<TR>
												<TD height="30">Date of Birth :</TD>
												<TD colSpan="3"><INPUT id="txDated" style="WIDTH: 60px" type="text" name="txDated" runat="server">
													/ <INPUT id="txDatem" style="WIDTH: 60px" type="text" name="Text1" runat="server">
													/ <INPUT id="txDatey" style="WIDTH: 150px" type="text" name="Text2" runat="server">
													&nbsp;<FONT color="#ff0000">*</FONT>&nbsp;&nbsp;(DD/MM/YYYY)</TD>
											</TR>
											<TR>
												<TD colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="35%" height="30">Home telephone area code and number :
															</TD>
															<TD><INPUT id="txhometel" style="WIDTH: 150px" type="text" name="textfield223" runat="server">&nbsp;<FONT color="#ff0000">*</FONT></TD>
														</TR>
														<TR>
															<TD width="35%" height="30">Work telephone area code and number :
															</TD>
															<TD><INPUT id="txworktel" style="WIDTH: 150px" type="text" name="textfield2232" runat="server">&nbsp;<FONT color="#ff0000">*</FONT></TD>
														</TR>
														<TR>
															<TD width="35%" height="30">Mobile telephone number :
															</TD>
															<TD><INPUT id="mobiletel" style="WIDTH: 150px" type="text" name="textfield22322" runat="server"></TD>
														</TR>
														<TR>
															<TD width="35%" height="30">Email Address :
															</TD>
															<TD><INPUT id="txEmail" style="WIDTH: 150px" type="text" name="textfield223222" runat="server">
																&nbsp;<FONT color="#ff0000">*</FONT></TD>
														</TR>
														<TR>
															<TD width="35%" height="30">Driver's licence number :
															</TD>
															<TD><INPUT id="txlnumber" style="WIDTH: 150px" type="text" name="textfield223223" runat="server"></TD>
														</TR>
														<TR>
															<TD width="35%" height="30">Driver's licence state :
															</TD>
															<TD><INPUT id="txlstate" style="WIDTH: 150px" type="text" name="textfield223224" runat="server"></TD>
														</TR>
														<TR>
															<TD width="35%" height="30">Marital Status :
															</TD>
															<TD><SELECT id="dlmastatus" style="WIDTH: 150px" name="select6" runat="server">
																	<OPTION value="Single" selected>Single</OPTION>
																	<OPTION value="Married">Married</OPTION>
																	<OPTION value="Defacto">Defacto</OPTION>
																	<OPTION value="Separated">Separated</OPTION>
																	<OPTION value="Divorced">Divorced</OPTION>
																	<OPTION value="Widowed">Widowed</OPTION>
																</SELECT></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD align="center" colSpan="4" height="30">
													<TABLE cellSpacing="0" cellPadding="0" width="90%" border="0">
														<TR>
															<TD colSpan="3" height="30"><STRONG>Referees </STRONG>
															</TD>
														</TR>
														<TR>
															<TD colSpan="3" height="25">
																<P>Please provide 3 referees (relative preferred).
																</P>
															</TD>
														</TR>
														<TR>
															<TD width="33%" height="25">Name
															</TD>
															<TD width="33%">Relationship
															</TD>
															<TD width="33%">Contact Number
															</TD>
														</TR>
														<TR>
															<TD height="25"><INPUT id="txReName1" style="WIDTH: 150px" type="text" name="textfield292433242" runat="server"></TD>
															<TD><INPUT id="selReShip1" style="WIDTH: 150px" type="text" name="textfield292433243" runat="server"></TD>
															<TD><INPUT id="txReNum1" style="WIDTH: 150px" type="text" name="textfield292433244" runat="server">&nbsp;<FONT color="#ff0000">*</FONT></TD>
														</TR>
														<TR>
															<TD height="25"><INPUT id="txReName2" style="WIDTH: 150px" type="text" name="textfield292433245" runat="server"></TD>
															<TD><INPUT id="selReShip2" style="WIDTH: 150px" type="text" name="textfield292433246" runat="server"></TD>
															<TD><INPUT id="txReNum2" style="WIDTH: 150px" type="text" name="textfield292433247" runat="server">&nbsp;<FONT color="#ff0000">*</FONT></TD>
														</TR>
														<TR>
															<TD height="25"><INPUT id="txReName3" style="WIDTH: 150px" type="text" name="textfield292433248" runat="server"></TD>
															<TD><INPUT id="selReShip3" style="WIDTH: 150px" type="text" name="textfield292433249" runat="server"></TD>
															<TD><INPUT id="txReNum3" style="WIDTH: 150px" type="text" name="textfield2924332410" runat="server">
																<FONT color="#ff0000">&nbsp; </FONT>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4">
													<HR width="100%" color="#cc3300" SIZE="1">
												</TD>
											</TR>
											<TR>
												<TD colSpan="4" height="30"><STRONG>Residential Details
														<asp:TextBox id="txReSid" runat="server" Visible="False" Width="56px"></asp:TextBox></STRONG></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="30%" height="30">Residential Status :
															</TD>
															<TD>
																<asp:DropDownList id="dlrestatus" runat="server" AutoPostBack="True">
																	<asp:ListItem Value="Renting">Renting</asp:ListItem>
																	<asp:ListItem Value="Own home (no mortgage)">Own home (no mortgage)</asp:ListItem>
																	<asp:ListItem Value="Own home (mortgage)">Own home (mortgage)</asp:ListItem>
																	<asp:ListItem Value="Parent Relative">Parent/Relative</asp:ListItem>
																	<asp:ListItem Value="Boarding">Boarding</asp:ListItem>
																	<asp:ListItem Value="Employer supplier">Employer supplier</asp:ListItem>
																</asp:DropDownList></TD>
														</TR>
														<TR>
															<TD width="30%" height="30">Unit / Apartment No :
															</TD>
															<TD><INPUT id="txunitno" style="WIDTH: 150px" type="text" name="textfield2232242" runat="server">
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD height="20">Street number</TD>
												<TD height="20"><INPUT id="txStreet" style="WIDTH: 150px" type="text" name="textfield22322522" runat="server">
													<FONT color="#ff0000">*</FONT></TD>
												<TD height="20">Suburb</TD>
												<TD><INPUT id="txSuburb" style="WIDTH: 150px" type="text" name="textfield223225224" runat="server">
													<FONT color="#ff0000">*</FONT></TD>
											</TR>
											<TR>
												<TD height="20">State</TD>
												<TD height="20"><INPUT id="txState" style="WIDTH: 150px" type="text" name="textfield223225223" runat="server">
													<FONT color="#ff0000">*</FONT></TD>
												<TD height="20">Postcode</TD>
												<TD><INPUT id="txPost" style="WIDTH: 150px" type="text" name="textfield223225224" runat="server">
													<FONT color="#ff0000">*</FONT></TD>
											</TR>
											<TR>
												<TD align="center" colSpan="4">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="30%" height="30">Time at this address:
															</TD>
															<TD><SELECT id="txYearr" name="select5" runat="server">
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
																<SELECT id="txMonthr" name="select5" runat="server">
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
											<TR>
												<TD colSpan="4" height="20">
													<TABLE id="Table1" cellSpacing="2" cellPadding="0" width="100%" border="0" runat="server">
														<TR>
															<TD colSpan="2" height="30">Landlord or Real Estate Agent Details</TD>
														</TR>
														<TR>
															<TD colSpan="2" height="30">The residential status you selected requires more 
																information. Please enter the details for your Landlord or Real Estate agent 
																below.</TD>
														</TR>
														<TR>
															<TD width="30%" height="30">Name of Landlord or Real Estate Agent</TD>
															<TD><INPUT id="txlandlord" type="text" name="textfield2232252" runat="server"></TD>
														</TR>
														<TR>
															<TD height="30">Telephone Area Code and Number</TD>
															<TD><INPUT id="txareatel" type="text" name="textfield2232253" runat="server"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4" height="30">
													<DIV align="center"><INPUT id="Submit2" type="submit" value=" Save " name="Submit2" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<INPUT onclick="history.go(-1);" type="button" value="Return">
													</DIV>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4" height="20">
													<DIV align="center"></DIV>
												</TD>
											</TR>
										</TABLE>
									</asp:panel></td>
							</tr>
							<tr>
								<td><asp:panel id="Panel7" runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="98%" border="0">
											<TR>
												<TD width="100%" colSpan="2" height="30"><STRONG>Bank Information </STRONG>
												</TD>
											</TR>
											<TR>
												<TD colSpan="2" height="25">This must be the account where your pay/benefit is paid 
													into.
												</TD>
											</TR>
											<TR>
												<TD colSpan="2" height="25">This is the account we will credit to and deduct from.
												</TD>
											</TR>
											<TR>
												<TD colSpan="2" height="20">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="15%" height="25">Bank Name:
															</TD>
															<TD><%=stxBank%></TD>
															<TD width="15%">Branch:
															</TD>
															<TD><%=stxBranch%></TD>
														</TR>
														<TR>
															<TD>Account Name:
															</TD>
															<TD colSpan="3"><%=stxAname%></TD>
														</TR>
														<TR>
															<TD>BSB:
															</TD>
															<TD><%=stxBsb%></TD>
															<TD>Account Number:
															</TD>
															<TD><%=stxAnumber%></TD>
														</TR>
														<TR>
															<TD colSpan="2" height="25">Preferred methods of contact for this loan:&nbsp;&nbsp;<%=smethods%>
															</TD>
															<TD colSpan="2"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD colSpan="2" height="25">
													<DIV align="center"><INPUT id="bnEdit4" type="submit" value="Edit>>>" name="Submit42" runat="server"></DIV>
												</TD>
											</TR>
											<TR>
												<TD colSpan="2" height="20">
													<DIV align="center"></DIV>
												</TD>
											</TR>
										</TABLE>
									</asp:panel></td>
							</tr>
							<tr>
								<td><asp:panel id="Panel8" runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="98%" border="0">
											<TR>
												<TD colSpan="2" height="30"><STRONG>Bank Information
														<asp:TextBox id="txBankSid" runat="server" Visible="False" Width="56px"></asp:TextBox></STRONG></TD>
											</TR>
											<TR>
												<TD colSpan="2" height="30"><STRONG>This must be the account where your pay/benefit is 
														paid into.
														<BR>
														This is the account we will credit to and deduct from</STRONG></TD>
											</TR>
											<TR>
												<TD colSpan="2" height="20">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="15%" height="30">Bank Name:
															</TD>
															<TD><INPUT id="txBank" style="WIDTH: 150px" type="text" name="textfield2924332" runat="server">
																<FONT color="#ff0000">*</FONT></TD>
															<TD width="15%" height="30">Branch:
															</TD>
															<TD><INPUT id="txBranch" style="WIDTH: 150px" type="text" name="textfield29243322" runat="server">
																<FONT color="#ff0000">*</FONT></TD>
														</TR>
														<TR>
															<TD width="15%" height="30">Account Name:
															</TD>
															<TD colSpan="3"><INPUT id="txAname" style="WIDTH: 150px" type="text" name="textfield29243323" runat="server">
																<FONT color="#ff0000">*</FONT></TD>
														</TR>
														<TR>
															<TD width="15%" height="30">BSB:
															</TD>
															<TD><INPUT id="txBsb" style="WIDTH: 150px" type="text" name="textfield29243324" runat="server">
																<FONT color="#ff0000">*</FONT></TD>
															<TD width="15%" height="30">Account Number:
															</TD>
															<TD><INPUT id="txAnumber" style="WIDTH: 150px" type="text" name="textfield29243325" runat="server">
																<FONT color="#ff0000">*</FONT></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD width="20%" height="24">Confirm Account Number:
												</TD>
												<TD height="24"><INPUT id="txCAnumber" type="text" size="18" name="textfield292433232" runat="server">
													<FONT color="#ff0000">*</FONT></TD>
											</TR>
											<TR>
												<TD colSpan="2" height="30">Preferred methods of contact for this loan:
												</TD>
											</TR>
											<TR>
												<TD colSpan="2">
													<asp:RadioButtonList id="RadioButtonList1" runat="server" Width="368px" RepeatDirection="Horizontal">
														<asp:ListItem Value="Email" Selected="True">Email</asp:ListItem>
														<asp:ListItem Value="Mobile">Mobile</asp:ListItem>
														<asp:ListItem Value="Home Phone">Home Phone</asp:ListItem>
														<asp:ListItem Value="Work Phone">Work Phone</asp:ListItem>
													</asp:RadioButtonList></TD>
											</TR>
											<TR>
												<TD colSpan="2" height="30">
													<DIV align="center"><INPUT id="bnBank" type="submit" value=" Save " name="Submit4" runat="server"><FONT face="宋体">&nbsp;&nbsp;</FONT>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<INPUT onclick="history.go(-1);" type="button" value="Return"></DIV>
												</TD>
											</TR>
										</TABLE>
									</asp:panel></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colSpan="2" height="25">&nbsp;</td>
				</tr>
				<tr>
					<td colSpan="3"><uc1:bottom id="Bottom1" runat="server"></uc1:bottom></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
