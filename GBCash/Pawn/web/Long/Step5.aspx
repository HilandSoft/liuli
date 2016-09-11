<%@ Register TagPrefix="uc1" TagName="CircleDropDownList" Src="../Include/CircleDropDownList.ascx" %>
<%@ Page language="c#" Codebehind="Step5.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Step5" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<script language="javascript" src="../jslib/commCheck.js" type="text/javascript"></script>
			<script language="javascript">
		function  CheckFeedback1() {
		var ftxpurpose=document.getElementById("txpurpose");
		var ftxborrow=document.getElementById("txborrow");
		
		if(!chkNull(ftxpurpose.value)) {
		alert(" Field 'Primary purpose' under 'Initial Loan Details' is not valid!");
		ftxpurpose.focus();
		return false;
		}
		
		if(!chkNull(ftxborrow.value)) {
		alert(" Field 'How much would you like to borrow' is not valid!");
		ftxborrow.focus();
		return false;
		}
		
		if(!chkdigital(ftxborrow.value)) {
		alert(" Field 'How much would you like to borrow' is not valid!");
		ftxborrow.focus();
		return false;
		}
		
		if(ftxborrow.value<1000){
		alert(" Please note the minimum loan is $1000!");
		ftxborrow.focus();
		return false;
		}
		
		if(ftxborrow.value>5000){
		alert(" Please note the maximum loan is $5000!");
		ftxborrow.focus();
		return false;
		}
		
		return true;
		}
		
		function  CheckFeedback2() {
		var ftxfname=document.getElementById("txfname");
		var ftxsname=document.getElementById("txsname");
		var ftxDated=document.getElementById("txDated");
		var ftxDatem=document.getElementById("txDatem");
		var ftxDatey=document.getElementById("txDatey");
				
		var ftxhometel=document.getElementById("txhometel");		
		var ftxworktel=document.getElementById("txworktel");		
		var ftxEmail=document.getElementById("txEmail");
		
		var ftxReName1=document.getElementById("txReName1");
		var ftxReName2=document.getElementById("txReName2");
		var fselReShip1=document.getElementById("selReShip1");
		var fselReShip2=document.getElementById("selReShip2");
		var ftxReNum1=document.getElementById("txReNum1");
		var ftxReNum2=document.getElementById("txReNum2");
		
		var ftxStreet=document.getElementById("txStreet");
		var ftxSuburb=document.getElementById("txSuburb");
		var ftxState=document.getElementById("txState");
		var ftxPost=document.getElementById("txPost");
		
		var fdlrestatus=document.getElementById("dlrestatus");
		var ftxlandlord=document.getElementById("txlandlord");
		var ftxareatel=document.getElementById("txareatel");
		
		var fDropDownList1=document.getElementById("DropDownList1");
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
		
		if(!chkNull(ftxhometel.value)) {
		alert(" Field 'Home telephone' under 'Personal Information' is not valid!");
		ftxhometel.focus();
		return false;
		}
		
		if(!chkNull(ftxworktel.value)) {
		alert(" Field 'Work telephone' under 'Personal Information' is not valid!");
		ftxworktel.focus();
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
		
		if(!chkNull(ftxReName1.value)) {
		alert(" Field 'Name 1' under 'Personal Information' is not valid!");
		ftxReName1.focus();
		return false;
		}
		
		if(!chkNull(fselReShip1.value)) {
		alert(" Field 'Relationship 1' under 'Personal Information' is not valid!");
		fselReShip1.focus();
		return false;
		}
		
		if(!chkNull(ftxReNum1.value)) {
		alert(" Field 'Contact Number 1' under 'Personal Information' is not valid!");
		ftxReNum1.focus();
		return false;
		}
		
		if(!chkNull(ftxReName2.value)) {
		alert(" Field 'Name 2' under 'Personal Information' is not valid!");
		ftxReName2.focus();
		return false;
		}
		
		if(!chkNull(fselReShip2.value)) {
		alert(" Field 'Relationship 2' under 'Personal Information' is not valid!");
		fselReShip2.focus();
		return false;
		}
		
		if(!chkNull(ftxReNum2.value)) {
		alert(" Field 'Contact Number 2' under 'Personal Information' is not valid!");
		ftxReNum2.focus();
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
			
		function  CheckFeedback3() {
		var ftxEmployer=document.getElementById("txEmployer");
		var ftxAddress=document.getElementById("txAddress");
		var ftxPhone=document.getElementById("txPhone");
		var ftxJob=document.getElementById("txJob");
		var ftxIncome=document.getElementById("txIncome");
		var frm = document.all.Form1;
		for (i=0;i<frm.RadioButtonList2.length;i++){
    if (frm.RadioButtonList2[i].checked==true){
      usertype=frm.RadioButtonList2[i].value;
      break;
    }
  }
		
		var ftxMm1=document.getElementById("txMm1");		
		var ftxDd1=document.getElementById("txDd1");		
		var ftxYy1=document.getElementById("txYy1");
		
		var ftxMm2=document.getElementById("txMm2");		
		var ftxDd2=document.getElementById("txDd2");		
		var ftxYy2=document.getElementById("txYy2");
		
		if(!chkNull(ftxEmployer.value)) {
		alert(" Field 'Employer' under 'Employment Information' is not valid!");
		ftxEmployer.focus();
		return false;
		}
		
		if(!chkNull(ftxAddress.value)) {
		alert(" Field 'Employer's Address' under 'Employment Information' is not valid!");
		ftxAddress.focus();
		return false;
		}
		
		if(!chkNull(ftxPhone.value)) {
		alert(" Field 'Employer's telephone' under 'Employment Information' is not valid!");
		ftxPhone.focus();
		return false;
		}
		
		if(!chkNull(ftxJob.value)) {
		alert(" Field 'Job Title' under 'Employment Information' is not valid!");
		ftxJob.focus();
		return false;
		}
		
		if(!chkNull(ftxIncome.value)) {
		alert(" Field 'Take home' under 'Employment Information' is not valid!");
		ftxIncome.focus();
		return false;
		}
		
		if(!chkdigital(ftxIncome.value)) {
		alert(" Field 'Take home' under 'Employment Information' is not valid!");
		ftxIncome.focus();
		return false;
		}
		
		if((!chkNull(ftxMm1.value))||(!chkNull(ftxDd1.value))||(!chkNull(ftxYy1.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid!");
		return false;
		}
		
		if((!chkdigital(ftxMm1.value))||(!chkdigital(ftxDd1.value))||(!chkdigital(ftxYy1.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid!");
		return false;
		}
		
		if((ftxMm1.value.length>2)||(ftxDd1.value.length>2)||(ftxYy1.value.length!=4)) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid!");
		return false;
		}
		
		if(usertype=="2") {		
		if((!chkNull(ftxMm2.value))||(!chkNull(ftxDd2.value))||(!chkNull(ftxYy2.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid!");
		return false;
		}
		
		if((!chkdigital(ftxMm2.value))||(!chkdigital(ftxDd2.value))||(!chkdigital(ftxYy2.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid!");
		return false;
		}
		
		if((ftxMm2.value.length>2)||(ftxDd2.value.length>2)||(ftxYy2.value.length!=4)) {
		alert(" Field 'Follow Payday' under 'Employment Information' is not valid!");
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
			<style type="text/css">.word1 {
	FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none
}
.word2 {
	FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none
}
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
					<td colSpan="3" height="10"></td>
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
												<div align="center"></div>
											</td>
											<td class="word2" width="83%">Apply Now
											</td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"></div>
											</td>
											<td class="word2">Initial loan information</td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"></div>
											</td>
											<td class="word2">About yourself</td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"></div>
											</td>
											<td class="word2">About your work</td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"></div>
											</td>
											<td class="word2">Your bank details</td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"><IMG height="10" src="images/1_04.gif" width="16"></div>
											</td>
											<td class="word1">Application summary</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Submit application</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><IMG height="5" alt="" src="images/1_09.gif" width="190"></td>
							</tr>
							<tr>
								<td align="center"><br>
									<IMG height="106" alt="" src="images/contact2.gif" width="160"></td>
							</tr>
						</table>
					</td>
					<td vAlign="top">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td>
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td bgColor="#cc3300"><IMG height="30" src="images/step5.gif" width="400">
												<asp:textbox id="txLoanSid" runat="server" Width="79px" Visible="False"></asp:textbox></td>
										</tr>
										<tr>
											<td height="10"></td>
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
											<td height="15"><asp:label id="Label1" runat="server" ForeColor="Red" Font-Bold="True"></asp:label></td>
										</tr>
										<tr>
											<td><asp:panel id="Panel1" runat="server">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD colSpan="2" height="25"><STRONG>Initial Loan Details </STRONG>
															</TD>
														</TR>
														<TR>
															<TD colSpan="2" height="25">Please complete the following details about your loan.</TD>
														</TR>
														<TR>
															<TD colSpan="2" height="25">What is the primary purpose of the loan?</TD>
														</TR>
														<TR>
															<TD colSpan="2"><%=stxpurpose%></TD>
														</TR>
														<TR>
															<TD width="35%" height="25">How much would you like to borrow?</TD>
															<TD>$<%=stxborrow%></TD>
														</TR>
														<TR>
															<TD>Please select the term of the loan:</TD>
															<TD height="25"><%=sdlterms%><FONT face="宋体"></FONT></TD>
														</TR>
														<TR>
															<TD colSpan="2" height="25">
																<DIV align="center"><INPUT id="bnEdit1" type="submit" value="Edit>>>" name="Submit5" runat="server">
																</DIV>
															</TD>
														</TR>
														<TR>
															<TD colSpan="2">
																<HR width="100%" color="#cc3300" SIZE="1">
															</TD>
														</TR>
													</TABLE>
												</asp:panel></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><asp:panel id="Panel2" runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD colSpan="2" height="30"><STRONG>Initial Loan Details </STRONG>
												</TD>
											</TR>
											<TR>
												<TD colSpan="2" height="30">Please complete the following details about your loan.</TD>
											</TR>
											<TR>
												<TD colSpan="2">What is the primary purpose of the loan?</TD>
											</TR>
											<TR>
												<TD colSpan="2"><TEXTAREA id="txpurpose" name="textarea" rows="10" cols="80" runat="server"></TEXTAREA>
													<FONT color="#ff0000">*</FONT></TD>
											</TR>
											<TR>
												<TD width="35%">How much would you like to borrow?</TD>
												<TD height="30">$<INPUT id="txborrow" style="WIDTH: 150px" type="text" name="textfield" runat="server">
													.00 <FONT color="#ff0000">*</FONT>&nbsp;
												</TD>
											</TR>
											<TR>
												<TD>Please select the term of the loan:</TD>
												<TD height="30"><SELECT id="dlterms" style="WIDTH: 150px" name="select" runat="server">
														<OPTION value="3" selected>3 Months</OPTION>
														<OPTION value="4">4 Months</OPTION>
														<OPTION value="5">5 Months</OPTION>
														<OPTION value="6">6 Months</OPTION>
														<OPTION value="7">7 Months</OPTION>
														<OPTION value="8">8 Months</OPTION>
														<OPTION value="9">9 Months</OPTION>
														<OPTION value="10">10 Months</OPTION>
														<OPTION value="11">11 Months</OPTION>
														<OPTION value="12">12 Months</OPTION>
													</SELECT>
													<FONT color="#ff0000">*</FONT></TD>
											</TR>
											<TR>
												<TD colSpan="2" height="30">
													<DIV align="center"><INPUT id="bnInit" type="submit" value=" Save " name="Submit" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
														&nbsp; <INPUT onclick="history.go(-1);" type="button" value="Return"></DIV>
												</TD>
											</TR>
											<TR>
												<TD colSpan="2" height="10"></TD>
											</TR>
										</TABLE>
									</asp:panel></td>
							</tr>
							<tr>
								<td><asp:panel id="Panel3" runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
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
												<TD align="center" colSpan="4" height="30">
													<TABLE cellSpacing="0" cellPadding="0" width="90%" border="0">
														<TR>
															<TD colSpan="3" height="25"><STRONG>Referees </STRONG>
															</TD>
														</TR>
														<TR>
															<TD colSpan="3" height="25">
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
															<TD><%=stxReNum3%></TD>
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
												<TD height="25">Street number :</TD>
												<TD height="25"><%=stxStreet%></TD>
												<TD height="25">Suburb :</TD>
												<TD><%=stxSuburb%></TD>
											</TR>
											<TR>
												<TD height="25">State :</TD>
												<TD height="25"><%=stxState%></TD>
												<TD height="25">Postcode :</TD>
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
													<TABLE id="Table3" cellSpacing="2" cellPadding="0" width="100%" border="0" runat="server">
														<TR>
															<TD colSpan="2" height="25">Landlord or Real Estate Agent Details</TD>
														</TR>
														<TR>
															<TD width="30%" height="25">Name of Landlord or Real Estate Agent :</TD>
															<TD><%=stxlandlord%></TD>
														</TR>
														<TR>
															<TD height="25">Telephone Area Code and Number :</TD>
															<TD><%=stxareatel%></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
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
														<asp:TextBox id="txPerSid" runat="server" Width="56px" Visible="False"></asp:TextBox></STRONG></TD>
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
												<TD>&nbsp;</TD>
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
												<TD align="center" colSpan="4">
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
														<asp:TextBox id="txReSid" runat="server" Width="56px" Visible="False"></asp:TextBox></STRONG></TD>
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
															<TD>
																<asp:DropDownList id="DropDownList1" runat="server" Width="100" AutoPostBack="True">
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
																</asp:DropDownList>Years
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
															<TD><INPUT id="txlandlord" style="WIDTH: 150px" type="text" name="textfield2232252" runat="server">
																<FONT color="#ff0000">*</FONT>
															</TD>
														</TR>
														<TR>
															<TD height="30">Telephone Area Code and Number</TD>
															<TD><INPUT id="txareatel" style="WIDTH: 150px" type="text" name="textfield2232253" runat="server">
																<FONT color="#ff0000">*</FONT>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD colSpan="4">
													<asp:Panel id="Panel9" runat="server" Width="100%" Visible="False">
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
													</asp:Panel></TD>
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
								<td><asp:panel id="Panel5" runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD colSpan="2" height="30"><STRONG>Employment Information </STRONG>
												</TD>
											</TR>
											<TR>
												<TD width="32%" height="25">Employer Name :</TD>
												<TD><%=stxEmployer%></TD>
											</TR>
											<TR>
												<TD height="25">Employer's Address:
												</TD>
												<TD><%=stxAddress%></TD>
											</TR>
											<TR>
												<TD height="25">Employer telephone area code and number:
												</TD>
												<TD><%=stxPhone%></TD>
											</TR>
											<TR>
												<TD height="25">Employment Status :
												</TD>
												<TD><%=sdlestatus%></TD>
											</TR>
											<TR>
												<TD height="25">Job Title
												</TD>
												<TD><%=stxJob%></TD>
											</TR>
											<TR>
												<TD height="25">Time Employed:
												</TD>
												<TD><%=stimeemployed%></TD>
											</TR>
											<TR>
												<TD height="25">Take home pay after taxes:
												</TD>
												<TD>$<%=stxIncome%></TD>
											</TR>
											<TR>
												<TD height="25">Per:</TD>
												<TD><%=sPer%></TD>
											</TR>
											<TR>
												<TD height="25">Next Payday:
												</TD>
												<TD><%=snpayday%></TD>
											</TR>
											<TR>
												<TD>Your rent/mortgage payment:</TD>
												<TD><%= sHousePaymentInfo%></TD>
											</TR>
											<TR>
												<TD>Your regular repayment to other lenders:</TD>
												<TD><%= sOtherLenderInfo%></TD>
											</TR>
											<TR>
												<TD colSpan="2" height="30">
													<DIV align="center"><INPUT id="bnEdit3" type="submit" value="Edit>>>" name="Submit32" runat="server">
													</DIV>
												</TD>
											</TR>
										</TABLE>
									</asp:panel></td>
							</tr>
							<TR>
								<TD>
									<hr width="100%" color="#cc3300" SIZE="1">
								</TD>
							</TR>
							<tr>
								<td><asp:panel id="Panel6" runat="server">
										<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD colSpan="2" height="30"><STRONG>Employment Information
														<asp:TextBox id="txEmpSid" runat="server" Width="150" Visible="False"></asp:TextBox></STRONG></TD>
											</TR>
											<TR>
												<TD width="32%" height="30">Employer Name :</TD>
												<TD><INPUT id="txEmployer" style="WIDTH: 150px" type="text" name="textfield223225" runat="server">
													<FONT color="#ff0000">*</FONT></TD>
											</TR>
											<TR>
												<TD height="30">Employer's Address:
												</TD>
												<TD><INPUT id="txAddress" style="WIDTH: 150px" type="text" name="textfield2232222" runat="server">
													<FONT color="#ff0000">*</FONT></TD>
											</TR>
											<TR>
												<TD height="30">Employer telephone area code and number:
												</TD>
												<TD><INPUT id="txPhone" style="WIDTH: 150px" type="text" name="textfield2232232" runat="server">
													<FONT color="#ff0000">*</FONT></TD>
											</TR>
											<TR>
												<TD height="30">Employment Status :
												</TD>
												<TD><SELECT id="dlestatus" style="WIDTH: 150px" name="select4" runat="server">
														<OPTION value="Full-time" selected>Full-time</OPTION>
														<OPTION value="Part-time">Part-time</OPTION>
														<OPTION value="Casual">Casual</OPTION>
														<OPTION value="Self Employed">Self Employed</OPTION>
														<OPTION value="Other">Other</OPTION>
													</SELECT></TD>
											</TR>
											<TR>
												<TD height="30">Job Title
												</TD>
												<TD><INPUT id="txJob" style="WIDTH: 150px" type="text" name="textfield2232243" runat="server">
													<FONT color="#ff0000">*</FONT></TD>
											</TR>
											<TR>
												<TD height="30">Time Employed:
												</TD>
												<TD><SELECT id="txYear" style="WIDTH: 60px" name="select4" runat="server">
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
													Years&nbsp;
													<SELECT id="txMonth" style="WIDTH: 60px" name="select4" runat="server">
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
													Months</TD>
											</TR>
											<TR>
												<TD height="30">Take home pay after taxes:
												</TD>
												<TD>$ <INPUT id="txIncome" style="WIDTH: 150px" type="text" name="textfield29242" runat="server">
													.00 <FONT color="#ff0000">*</FONT>
												</TD>
											</TR>
											<TR>
												<TD height="30">Per:</TD>
												<TD>
													<asp:RadioButtonList id="RadioButtonList2" runat="server" AutoPostBack="True" RepeatDirection="Horizontal">
														<asp:ListItem Value="0" Selected="True">Weekly</asp:ListItem>
														<asp:ListItem Value="1">F'nightly</asp:ListItem>
														<asp:ListItem Value="2">Bi-Monthly</asp:ListItem>
														<asp:ListItem Value="3">Monthly &lt;FONT face=&quot;&#203;&#206;&#204;&#229;&quot; 
                  color=&quot;#990000&quot;&gt;*&lt;/FONT&gt;</asp:ListItem>
													</asp:RadioButtonList></TD>
											</TR>
											<TR>
												<TD height="30">Next Payday:
												</TD>
												<TD>DD <INPUT id="txDd1" style="WIDTH: 60px" type="text" name="textfield29243" runat="server">
													MM <INPUT id="txMm1" style="WIDTH: 60px" type="text" name="textfield292432" runat="server">
													YYYY <INPUT id="txYy1" style="WIDTH: 150px" type="text" name="textfield292433" runat="server"></TD>
											</TR>
											<TR>
												<TD colSpan="2">
													<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
														<TR>
															<TD width="32%" height="30">Follow Payday:
															</TD>
															<TD>DD <INPUT id="txDd2" style="WIDTH: 60px" type="text" name="textfield29243" runat="server">
																MM <INPUT id="txMm2" style="WIDTH: 60px" type="text" name="textfield292432" runat="server">
																YYYY <INPUT id="txYy2" style="WIDTH: 150px" type="text" name="textfield292433" runat="server"></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>Your rent/mortgage payment:</TD>
												<TD>$<INPUT id="txtHousePaymentValue" type="text" size="12" name="txtHousePaymentValue" runat="server">
													<uc1:CircleDropDownList id="ddlHousePaymentCircle" runat="server"></uc1:CircleDropDownList></TD>
											</TR>
											<TR>
												<TD>Your regular repayment to other lenders:</TD>
												<TD>$<INPUT id="txtOtherLenderValue" type="text" size="12" name="txtOtherLenderValue" runat="server">&nbsp;
													<uc1:CircleDropDownList id="ddlOtherLenderCircle" runat="server"></uc1:CircleDropDownList></TD>
											</TR>
											<TR>
												<TD colSpan="2" height="30">
													<DIV align="center"><INPUT id="bnEmploy" type="submit" value=" Save " name="Submit3" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														<INPUT onclick="history.go(-1);" type="button" value="Return">
													</DIV>
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
												<TD colSpan="2">
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
													<DIV align="center"><INPUT id="bnEdit4" type="submit" value="Edit>>>" name="Submit42" runat="server">&nbsp;
														<FONT face="宋体">&nbsp;&nbsp;</FONT>
														<asp:Button id="bnApption" runat="server" Text="Next>>>"></asp:Button><INPUT id="Hidden1" type="hidden" size="3" name="Hidden1" runat="server"><INPUT id="Hidden2" type="hidden" size="3" name="Hidden1" runat="server"><INPUT id="Hidden3" type="hidden" size="3" name="Hidden1" runat="server"></DIV>
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
														<asp:TextBox id="txBankSid" runat="server" Width="56px" Visible="False"></asp:TextBox></STRONG></TD>
											</TR>
											<TR>
												<TD colSpan="2" height="30"><STRONG>This must be the account where your pay/benefit is 
														paid into. </STRONG>
												</TD>
											</TR>
											<TR>
												<TD colSpan="2" height="30">This is the account we will credit to and deduct from</TD>
											</TR>
											<TR>
												<TD colSpan="2">
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
												<TD width="20%" height="30">Confirm Account Number:
												</TD>
												<TD><INPUT id="txCAnumber" style="WIDTH: 150px" type="text" name="textfield292433232" runat="server">
													<FONT color="#ff0000">*</FONT></TD>
											</TR>
											<TR>
												<TD colSpan="2" height="20">Preferred methods of contact for this loan:
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
					<td colSpan="2">&nbsp;</td>
				</tr>
				<tr>
					<td colSpan="3"><uc1:bottom id="Bottom1" runat="server"></uc1:bottom></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
