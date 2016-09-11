<%@ Register TagPrefix="uc1" TagName="MemberLeft" Src="MemberLeft.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MemberTop" Src="MemberTop.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CircleDropDownList" Src="../Include/CircleDropDownList.ascx" %>
<%@ Page language="c#" Codebehind="detail.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.detail" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<meta content="text/html; charset=UTF-8" http-equiv="Content-Type">
		<script type="text/javascript" src="../javascriptN/jquery-1.4.4.min.js"></script>
		<script language="javascript" type="text/javascript" src="../jslib/commCheck.js"></script>
		<script language="javascript">
		function  CheckFeedback1() {
		var ftxEmployer=document.getElementById("txEmployer");
		var ftxAddress=document.getElementById("txAddress");
		var ftxPhone=document.getElementById("txPhone");
		var ftxJob=document.getElementById("txJob");
		var ftxIncome=document.getElementById("txIncome");		
		var ftxMm1=document.getElementById("txMm1");		
		var ftxDd1=document.getElementById("txDd1");		
		var ftxYy1=document.getElementById("txYy1");
		
		if(!chkNull(ftxEmployer.value)) {
		alert(" Field 'Employer' under 'Employment Information' is not valid");
		ftxEmployer.focus();
		return false;
		}
		
		if(!chkNull(ftxAddress.value)) {
		alert(" Field 'Employer's Address' under 'Employment Information' is not valid");
		ftxAddress.focus();
		return false;
		}
		
		if(!chkNull(ftxPhone.value)) {
		alert(" Field 'Employer's Phone Number' under 'Employment Information' is not valid");
		ftxPhone.focus();
		return false;
		}
		
		if(!chkNull(ftxJob.value)) {
		alert(" Field 'Job Title' under 'Employment Information' is not valid!");
		ftxJob.focus();
		return false;
		}
		
		if(!chkNull(ftxIncome.value)) {
		alert(" Field 'Net Income' under 'Employment Information' is not valid");
		ftxIncome.focus();
		return false;
		}
		
		if((!chkNull(ftxMm1.value))||(!chkNull(ftxDd1.value))||(!chkNull(ftxYy1.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid");
		return false;
		}
		
		if((!chkdigital(ftxMm1.value))||(!chkdigital(ftxDd1.value))||(!chkdigital(ftxYy1.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid");
		return false;
		}
		
		return true;
		}		
		
		
		function  CheckFeedback2() {
		var ftxType=document.getElementById("txType");
		var ftxOffice=document.getElementById("txOffice");
		var ftxContact=document.getElementById("txContact");
		var ftxBenefit=document.getElementById("txBenefit");		
		var ftxMm4=document.getElementById("txMm4");		
		var ftxDd4=document.getElementById("txDd4");		
		var ftxYy4=document.getElementById("txYy4");
		
		if(!chkNull(ftxType.value)) {
		alert(" Field 'Type of Benefit' under 'Employment Information' is not valid");
		ftxType.focus();
		return false;
		}
		
		if(!chkNull(ftxOffice.value)) {
		alert(" Field 'Centreline Office' under 'Employment Information' is not valid");
		ftxOffice.focus();
		return false;
		}
		
		if(!chkNull(ftxContact.value)) {
		alert(" Field 'Contact Name' under 'Employment Information' is not valid");
		ftxContact.focus();
		return false;
		}
		
		if(!chkNull(ftxBenefit.value)) {
		alert(" Field 'Monthly Benefit' under 'Employment Information' is not valid");
		ftxBenefit.focus();
		return false;
		}
		
		if((!chkNull(ftxMm4.value))||(!chkNull(ftxDd4.value))||(!chkNull(ftxYy4.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid");
		return false;
		}
		
		if((!chkdigital(ftxMm4.value))||(!chkdigital(ftxDd4.value))||(!chkdigital(ftxYy4.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid");
		return false;
		}
		
		return true;
		}
		</script>
		<LINK rel="stylesheet" type="text/css" href="../CSSN/final.css">
			<style type="text/css">.style2 {
	FONT-FAMILY: Verdana; FONT-SIZE: small
}
</style>
	</HEAD>
	<body>
		<!--start top--><uc1:membertop id="MemberTop1" runat="server"></uc1:membertop>
		<!--end top-->
		<!--start homebanner-->
		<!--start subbanner-->
		<div id="subheader">
			<h1>Member Console</h1>
		</div>
		<!--end subbanner-->
		<!--start main-->
		<div id="main">
			<!--start process--><uc1:memberleft id="MemberLeft1" runat="server"></uc1:memberleft>
			<!--end process-->
			<div style="MARGIN-LEFT: 0px" id="content">
				<form id="Form1" method="post" runat="server">
					<table border="0" cellSpacing="0" cellPadding="0" width="95%">
						<tr>
							<td>
								<p><strong>Please make sure these are always kept up to date. </strong><strong>If you 
										have any problems updating this information, please contact us at 1300 137 906 </strong>
								</p>
							</td>
						</tr>
						<tr>
							<td>&nbsp;</td>
						</tr>
						<tr>
							<td>Member Information <INPUT style="WIDTH: 40px; HEIGHT: 21px" id="Hidden1" size="1" type="hidden" name="Hidden1"
									runat="server">
							</td>
						</tr>
						<tr>
							<td>
								<table style="WIDTH: 100%; HEIGHT: 129px" border="0" cellSpacing="0" cellPadding="0">
									<tr>
										<td>Title:</td>
										<td colSpan="3"><asp:dropdownlist id="dlTitle" runat="server">
												<asp:ListItem Value="Mr">Mr</asp:ListItem>
												<asp:ListItem Value="Mrs">Mrs</asp:ListItem>
												<asp:ListItem Value="Miss">Miss</asp:ListItem>
												<asp:ListItem Value="Ms">Ms</asp:ListItem>
												<asp:ListItem Value="Dr">Dr</asp:ListItem>
											</asp:dropdownlist></td>
									</tr>
									<tr>
										<td width="136">First Name:</td>
										<td width="124"><input id="txFname" readOnly size="15" name="textfield26" runat="server">
											<FONT color="#990000" face="???">*</FONT></td>
										<td width="91">Middle Name:</td>
										<td><INPUT id="txMname" readOnly size="15" name="textfield262" runat="server">
										</td>
									</tr>
									<tr>
										<td>Last Name:</td>
										<td><input id="txLname" readOnly size="15" name="textfield27" runat="server"> <FONT color="#990000" face="???">
												*</FONT>
										</td>
										<td>Customer No:</td>
										<td><input id="txNo" readOnly size="15" name="textfield27" runat="server"></td>
									</tr>
									<tr>
										<td>Date of Birth:</td>
										<td><input id="txDate" readOnly size="15" name="textfield29" runat="server"> <FONT color="#990000" face="???">
												*</FONT></td>
										<td>E-Mail:
										</td>
										<td><input id="txEmail" size="15" name="textfield28" runat="server"> <FONT color="#990000" face="???">
												*</FONT></td>
									</tr>
									<tr>
										<td>Driver Licence Number:</td>
										<td><FONT face="???"><INPUT id="txDriver" size="15" name="textfield28" runat="server"> </FONT>
										</td>
										<td>State Issued:</td>
										<td><FONT face=""><FONT face="???"><INPUT id="txIssue" size="15" name="textfield29" runat="server"></FONT></FONT></td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td>
								<table border="0" cellSpacing="0" cellPadding="0" width="95%">
									<tr>
										<td width="142">Home&nbsp;Address:</td>
										<td colSpan="3"><input id="txResident" name="textfield2622" runat="server"></td>
									</tr>
									<tr>
										<td>Street&nbsp;:</td>
										<td colSpan="3"><input id="txStreet" name="textfield2622" runat="server"> <FONT color="#990000" face="???">
												*</FONT></td>
									</tr>
									<tr>
										<td>Suburb:</td>
										<td width="80"><input id="txCity" size="9" name="textfield292" runat="server"><FONT color="#990000" face="???">*</FONT></td>
										<td width="104" colSpan="2">&nbsp;&nbsp; State:&nbsp;
											<SELECT id="selState" name="select2" runat="server">
												<OPTION selected value="ACT">ACT</OPTION>
												<OPTION value="QLD">QLD</OPTION>
												<OPTION value="NSW">NSW</OPTION>
												<OPTION value="NT">NT</OPTION>
												<OPTION value="SA">SA</OPTION>
												<OPTION value="TAS">TAS</OPTION>
												<OPTION value="VIC">VIC</OPTION>
												<OPTION value="WA">WA</OPTION>
											</SELECT></td>
									</tr>
									<tr>
										<td>Postcode:</td>
										<td colSpan="3"><input id="txPost" name="textfield2623" runat="server"><FONT color="#990000" face="???">*</FONT></td>
									</tr>
									<tr>
										<td colSpan="4">&nbsp;</td>
									</tr>
									<tr>
										<td width="198" colSpan="2">Time at this address:</td>
										<td colSpan="2"><SELECT id="txYear" name="select2" runat="server">
												<OPTION selected value="0">0</OPTION>
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
												<OPTION value="12">12 or above</OPTION>
											</SELECT>Years
											<SELECT id="txMonth" name="select2" runat="server">
												<OPTION selected value="0">0</OPTION>
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
											</SELECT>Months</td>
									</tr>
									<tr>
										<td width="198" colSpan="2">Home Phone Number:</td>
										<td colSpan="2"><input id="txTel" size="10" name="textfield282" runat="server"> <FONT color="#990000" face="???">
												*</FONT></td>
									</tr>
									<tr>
										<td width="198" colSpan="2">Mobile:</td>
										<td colSpan="2"><input id="txMobile" size="10" name="textfield282" runat="server"> <FONT color="#990000" face="???">
											</FONT>
										</td>
									</tr>
									<tr>
										<td width="198" colSpan="2">Fax:</td>
										<td colSpan="2"><input id="txFax" size="10" name="textfield282" runat="server"><FONT color="#990000" face="???"></FONT></td>
									</tr>
									<tr>
										<td colSpan="2">&nbsp;</td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td>&nbsp;</td>
						</tr>
					</table>
					<table border="0" cellSpacing="0" cellPadding="0" width="500">
						<tr>
							<td>
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="397" height="100%">
									<TR>
										<TD><STRONG>Employment Information<INPUT id="Hidden2" size="1" type="hidden" name="Hidden1" runat="server"></STRONG></TD>
									</TR>
									<TR>
										<TD height="20" width="168"><asp:radiobuttonlist id="RadioButtonList1" runat="server" Visible="False" AutoPostBack="True" Width="352px">
												<asp:ListItem Value="0" Selected="True">I'm  currently employed.</asp:ListItem>
												<asp:ListItem Value="1">I'm  on a benefit.</asp:ListItem>
											</asp:radiobuttonlist></TD>
									</TR>
									<TR>
										<TD>&nbsp;</TD>
									</TR>
								</TABLE>
							</td>
						</tr>
						<tr>
							<td><asp:panel id="Panel1" runat="server" Visible="True" Width="430px" Height="232px">
									<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD>Your Occupation:</TD>
											<TD colSpan="3"><FONT face="???"></FONT></TD>
										</TR>
										<TR>
											<TD>Employer:</TD>
											<TD colSpan="3"><INPUT id="txEmployer" name="textfield2922" runat="server"><FONT color="#990000" face="???">*
												</FONT>
											</TD>
										</TR>
										<TR>
											<TD>Employer's Address:</TD>
											<TD colSpan="3"><INPUT id="txAddress" name="textfield2923" runat="server"><FONT color="#990000" face="???">*</FONT></TD>
										</TR>
										<TR>
											<TD>Employer Phone:</TD>
											<TD colSpan="3"><INPUT id="txPhone" name="textfield2924" runat="server"><FONT color="#990000" face="???">*</FONT></TD>
										</TR>
										<TR>
											<TD width="153">Job Title:</TD>
											<TD colSpan="3"><INPUT id="txJob" name="textfield2924" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
										</TR>
										<TR>
											<TD>Time Employed:
											</TD>
											<TD colSpan="3"><SELECT id="Select1" name="select2" runat="server">
													<OPTION selected value="0">0</OPTION>
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
													<OPTION value="12">12 or above</OPTION>
												</SELECT>Years&nbsp;
												<SELECT id="Select2" name="select2" runat="server">
													<OPTION selected value="0">0</OPTION>
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
												</SELECT>Months</TD>
										</TR>
										<TR>
											<TD>Take home pay after taxes:
											</TD>
											<TD colSpan="3"><INPUT id="txIncome" name="textfield29242" runat="server"><FONT color="#990000" face="???">*</FONT></TD>
										</TR>
										<TR>
											<TD>When are you paid:
											</TD>
											<TD colSpan="3">
												<asp:RadioButtonList id="RadioButtonList2" runat="server" Width="224px" RepeatDirection="Horizontal">
													<asp:ListItem Value="Weekly" Selected="True">Weekly</asp:ListItem>
													<asp:ListItem Value="F'nightly">F'nightly</asp:ListItem>
													<asp:ListItem Value="Monthly">Monthly &lt;FONT face=&quot;???&quot; color=&quot;#990000&quot;&gt;*&lt;/FONT&gt;</asp:ListItem>
												</asp:RadioButtonList></TD>
										</TR>
										<TR>
											<TD width="153">Next payday:</TD>
											<TD colSpan="3">DD <INPUT id="txDd1" size="4" name="textfield29243" runat="server"> 
												MM <INPUT id="txMm1" size="4" name="textfield292432" runat="server"> YYYY <INPUT id="txYy1" size="4" name="textfield292433" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
										</TR>
										<TR>
											<TD>Purpose of the loan:</TD>
											<TD colSpan="3">
												<asp:textbox id="txtLoanPurpose" runat="server" Width="168px" Height="45px"></asp:textbox></TD>
										</TR>
										<TR>
											<TD>Your rent/mortgage payment:</TD>
											<TD colSpan="3">$<INPUT id="txtHousePaymentValue" size="12" name="txtHousePaymentValue" runat="server">
												<uc1:circledropdownlist id="ddlHousePaymentCircle" runat="server"></uc1:circledropdownlist></TD>
										</TR>
										<TR>
											<TD>Your regular repayment to other lenders:</TD>
											<TD colSpan="3">$<INPUT id="txtOtherLenderValue" size="12" name="txtOtherLenderValue" runat="server">
												<uc1:circledropdownlist id="ddlOtherLenderCircle" runat="server"></uc1:circledropdownlist></TD>
										</TR>
										
									</TABLE>
								</asp:panel></td>
						</tr>
						<tr>
							<td height="100"><asp:panel id="Panel2" runat="server" Visible="False" Width="420px" Height="192px">
									<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="100%">
										<TR>
											<TD width="127">Type of benefit:</TD>
											<TD colSpan="3"><INPUT id="txType" size="15" name="textfield2925" runat="server"><FONT color="#990000" face="???">*
												</FONT>
											</TD>
										</TR>
										<TR>
											<TD height="23">Centrelink Office:</TD>
											<TD height="23" colSpan="3"><INPUT id="txOffice" size="15" name="textfield29222" runat="server"><FONT color="#990000" face="???">*</FONT></TD>
										</TR>
										<TR>
											<TD>Contact Name:</TD>
											<TD colSpan="3"><INPUT id="txContact" size="15" name="textfield29232" runat="server"><FONT color="#990000" face="???">*</FONT></TD>
										</TR>
										<TR>
											<TD height="22">How long on this benefit:
											</TD>
											<TD height="22" colSpan="3"><SELECT id="txYear2" name="select2" runat="server">
													<OPTION selected value="0">0</OPTION>
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
													<OPTION value="12">12 or above</OPTION>
												</SELECT>Years&nbsp;
												<SELECT id="txMonth2" name="select2" runat="server">
													<OPTION selected value="0">0</OPTION>
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
												</SELECT>Months</TD>
										</TR>
										<TR>
											<TD>Take Home Benefit:</TD>
											<TD colSpan="3"><INPUT id="txBenefit" size="15" name="textfield2924222" runat="server"><FONT color="#990000" face="???">*</FONT></TD>
										</TR>
										<TR>
											<TD>When are you paid:
											</TD>
											<TD colSpan="3">
												<asp:RadioButtonList id="RadioButtonList3" runat="server" Width="224px" RepeatDirection="Horizontal">
													<asp:ListItem Value="Weekly" Selected="True">Weekly</asp:ListItem>
													<asp:ListItem Value="F'nightly">F'nightly</asp:ListItem>
													<asp:ListItem Value="Monthly">Monthly &lt;FONT face=&quot;???&quot; color=&quot;#990000&quot;&gt;*&lt;/FONT&gt;</asp:ListItem>
												</asp:RadioButtonList></TD>
										</TR>
										<TR>
											<TD width="162">Next benefit due:</TD>
											<TD colSpan="3">DD <INPUT style="WIDTH: 40px; HEIGHT: 22px" id="txDd4" size="1" name="textfield292436" runat="server">
												MM <INPUT style="WIDTH: 40px; HEIGHT: 22px" id="txMm4" size="1" name="textfield2924324" runat="server">
												YYYY <INPUT style="WIDTH: 56px; HEIGHT: 22px" id="txYy4" size="4" name="textfield2924334" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
										</TR>
										
									</TABLE>
								</asp:panel></td>
						</tr>
						<TR>
											<TD align="center"><INPUT id="Submit1" value="Save" type="submit" name="Submit" runat="server"><FONT face="">&nbsp;&nbsp;&nbsp;
												</FONT><INPUT value="Reset" type="reset" name="Submit2"></TD>
										</TR>
					</table>
				</form>
			</div>
		</div>
		<!--end main-->
		<!--start footer-->
		<div style="CLEAR: both"></div>
		<div id="footer">© Copyright Golden Bridge Cash Solution Pty Ltd 2011</div>
		<script type="text/javascript">
        $(document).ready(function(){
				$("#menuItemYourProfile").addClass("actived");
			});
		</script>
		<!--end footer-->
	</body>
</HTML>
