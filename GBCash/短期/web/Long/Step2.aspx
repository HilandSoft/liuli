<%@ Page SmartNavigation="true" language="c#" Codebehind="Step2.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Step2" %>
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
		
		if(ftxDated.value.length<2){
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
		
		if(ftxDatem.value.length<2){
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
		return true;
		}
			</script>
			<style type="text/css">
.word1 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
.word2 { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
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
					<td>
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD colSpan="4" height="30" bgcolor="#cc3300">
									<img src="images/step2.gif" width="400" height="30">
									<asp:TextBox id="txLoanSid" runat="server" Width="1px" Visible="False"></asp:TextBox></TD>
							</TR>
							<tr>
								<td colspan="2" height="10"></td>
							</tr>
							<tr>
								<td colspan="4">
									<table width="100%" cellpadding="0" cellspacing="0" border="0">
										<tr>
											<td height="30" colspan="2"><strong> Personal Details </strong>
											</td>
										</tr>
										<tr>
											<td height="30" width="35%">Are you an existing Golden Bridge customer?</td>
										  <td><SELECT id="dlexisting" name="select" runat="server">
													<OPTION value="1" selected>Yes</OPTION>
													<OPTION value="0">No</OPTION>
												</SELECT> 
											Note: To apply you must have completed your current loan with Golden Bridge.. </td>
										</tr>
										<tr>
											<td height="30">Customer Reference Number :</td>
											<td><INPUT id="txrefnumber" type="text" style="WIDTH:150px" name="textfield" runat="server">
												&nbsp;&nbsp;(For existing Golden Bridge customers only)
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<TR>
								<TD width="15%" height="30">Title/Salutation :</TD>
								<TD><SELECT id="dltitle" name="select2" runat="server" style="WIDTH:150px">
										<OPTION value="Mr" selected>Mr</OPTION>
										<OPTION value="Mrs">Mrs</OPTION>
										<OPTION value="Miss">Miss</OPTION>
										<OPTION value="Ms">Ms</OPTION>
										<OPTION value="Dr">Dr</OPTION>
									</SELECT>
								</TD>
								<TD width="15%" height="30">&nbsp;</TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD height="30">First Name :</TD>
								<TD><INPUT id="txfname" type="text" style="WIDTH:150px" name="textfield2" runat="server">
									<FONT color="#ff0000">*</FONT></TD>
								<TD height="30">Middle Name :</TD>
								<TD><INPUT id="txmname" type="text" style="WIDTH:150px" name="textfield22" runat="server"></TD>
							</TR>
							<TR>
								<TD height="30">Surname :</TD>
								<TD><INPUT id="txsname" type="text" style="WIDTH:150px" name="textfield222" runat="server">
									<FONT color="#ff0000">*</FONT></TD>
								<TD height="30">&nbsp;</TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD height="30">Gender :</TD>
								<TD><SELECT id="dlgender" name="select3" runat="server" style="WIDTH:150px">
										<OPTION value="Male" selected>Male</OPTION>
										<OPTION value="Female">Female</OPTION>
									</SELECT></TD>
								<TD height="20">&nbsp;</TD>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD height="30">Date of Birth :</TD>
								<TD colSpan="3" height="20"><INPUT id="txDated" type="text" style="WIDTH:60px" name="txDated" runat="server">
									/ <INPUT id="txDatem" type="text" style="WIDTH:60px" name="Text1" runat="server">
									/ <INPUT id="txDatey" type="text" style="WIDTH:150px" name="Text2" runat="server">
									&nbsp;<FONT color="#ff0000">*</FONT>&nbsp;&nbsp;(DD/MM/YYYY)</TD>
							</TR>
							<tr>
								<td colspan="4">
									<table width="100%" cellpadding="0" cellspacing="0" border="0">
										<tr>
											<td height="30" width="35%">
												Home telephone area code and number :
											</td>
											<td><INPUT id="txhometel" type="text" style="WIDTH:150px" name="textfield223" runat="server">&nbsp;<FONT color="#ff0000">*</FONT></td>
										</tr>
										<tr>
											<td height="30" width="35%">
												Work telephone area code and number :
											</td>
											<td><INPUT id="txworktel" type="text" style="WIDTH:150px" name="textfield2232" runat="server">&nbsp;<FONT color="#ff0000">*</FONT></td>
										</tr>
										<tr>
											<td height="30" width="35%">
												Mobile telephone number :
											</td>
											<td><INPUT id="mobiletel" type="text" style="WIDTH:150px" name="textfield22322" runat="server"></td>
										</tr>
										<tr>
											<td height="30" width="35%">
												Email Address :
											</td>
											<td><INPUT id="txEmail" type="text" style="WIDTH:150px" name="textfield223222" runat="server">
												&nbsp;<FONT color="#ff0000">*</FONT></td>
										</tr>
										<tr>
											<td height="30" width="35%">
												Driver's licence number :
											</td>
											<td><INPUT id="txlnumber" type="text" style="WIDTH:150px" name="textfield223223" runat="server"></td>
										</tr>
										<tr>
											<td height="30" width="35%">
												Driver's licence state :
											</td>
											<td><INPUT id="txlstate" type="text" style="WIDTH:150px" name="textfield223224" runat="server"></td>
										</tr>
										<tr>
											<td height="30" width="35%">
												Marital Status :
											</td>
											<td><SELECT id="dlmastatus" name="select6" runat="server" style="WIDTH:150px">
													<OPTION value="Single" selected>Single</OPTION>
													<OPTION value="Married">Married</OPTION>
													<OPTION value="Defacto">Defacto</OPTION>
													<OPTION value="Separated">Separated</OPTION>
													<OPTION value="Divorced">Divorced</OPTION>
													<OPTION value="Widowed">Widowed</OPTION>
												</SELECT></td>
										</tr>
									</table>
								</td>
							</tr>
							<TR>
								<TD colSpan="4" align="center"><table width="90%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="30" colspan="3">
												<strong>Referees </strong>
											</td>
										</tr>
										<tr>
											<td height="25" colspan="3"><p>Please provide 3 referees (relative preferred).
												</p>
											</td>
										</tr>
										<tr>
											<td width="33%" height="25">
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
											<td height="25"><INPUT id="txReName1" type="text" style="WIDTH:150px" name="textfield292433242" runat="server"></td>
											<td><INPUT id="selReShip1" type="text" style="WIDTH:150px" name="textfield292433243" runat="server"></td>
											<td><INPUT id="txReNum1" type="text" style="WIDTH:150px" name="textfield292433244" runat="server">&nbsp;<FONT color="#ff0000">*</FONT></td>
										</tr>
										<tr>
											<td height="25"><INPUT id="txReName2" type="text" style="WIDTH:150px" name="textfield292433245" runat="server"></td>
											<td><INPUT id="selReShip2" type="text" style="WIDTH:150px" name="textfield292433246" runat="server"></td>
											<td><INPUT id="txReNum2" type="text" style="WIDTH:150px" name="textfield292433247" runat="server">&nbsp;<FONT color="#ff0000">*</FONT></td>
										</tr>
										<tr>
											<td height="25"><INPUT id="txReName3" type="text" style="WIDTH:150px" name="textfield292433248" runat="server"></td>
											<td><INPUT id="selReShip3" type="text" style="WIDTH:150px" name="textfield292433249" runat="server"></td>
											<td><INPUT id="txReNum3" type="text" style="WIDTH:150px" name="textfield2924332410" runat="server">
												<FONT color="#ff0000">&nbsp; </FONT>
											</td>
										</tr>
									</table>
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
