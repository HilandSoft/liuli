<%@ Register TagPrefix="uc1" TagName="CircleDropDownList" Src="Include/CircleDropDownList.ascx" %>
<%@ Page language="c#" Codebehind="step3.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.step3" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>step3</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/css.css" type="text/css" rel="stylesheet">
		<LINK href="jslib/jquery-cluetip/jquery.cluetip.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="jslib/commCheck.js" type="text/javascript"></script>
		<script language="javascript" src="jslib/jquery-cluetip/lib/jquery-1.7.1.min.js" type="text/javascript"></script>
		<script language="javascript" src="jslib/jquery-cluetip/jquery.cluetip.min.js" type="text/javascript"></script>
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
		
		var ftxtHousePaymentValue= document.getElementById("txtHousePaymentValue");
		var ftxtOtherLenderValue= document.getElementById("txtOtherLenderValue");
		
		
		if(!chkNull(ftxtHousePaymentValue.value)) {
		alert(" Field 'Your rent/mortgage payment' under 'Expenses Information' is not valid!");
		ftxtHousePaymentValue.focus();
		return false;
		}
		
		if(!chkNull(ftxtOtherLenderValue.value)) {
		alert(" Field 'Your regular repayment to other lenders' under 'Expenses Information' is not valid!");
		ftxtOtherLenderValue.focus();
		return false;
		}
		
		
		var ftxtLoanPurpose= document.getElementById("txtLoanPurpose");
		if(!chkNull(ftxtLoanPurpose.value)) {
		alert("Please specify the primary purpose of the loan!");
		ftxtLoanPurpose.focus();
		return false;
		}
		
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
		alert(" Field 'Employer's Phone Number' under 'Employment Information' is not valid!");
		ftxPhone.focus();
		return false;
		}
		
		if(!chkNull(ftxJob.value)) {
		alert(" Field 'Job Title' under 'Employment Information' is not valid!");
		ftxJob.focus();
		return false;
		}
		
		if(!chkNull(ftxIncome.value)) {
		alert(" Field 'Net Income' under 'Employment Information' is not valid!");
		ftxIncome.focus();
		return false;
		}
		
		if(!chkdigital(ftxIncome.value)) {
		alert(" Field 'Net Income' under 'Employment Information' is not valid!");
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
		/*if((!chkNull(ftxMm1.value))||(!chkNull(ftxDd1.value))||(!chkNull(ftxYy1.value))||(!chkNull(ftxMm2.value))||(!chkNull(ftxDd2.value))||(!chkNull(ftxYy2.value))||(!chkNull(ftxMm3.value))||(!chkNull(ftxDd3.value))||(!chkNull(ftxYy3.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid！");
		return false;
		}
		
		if((!chkdigital(ftxMm1.value))||(!chkdigital(ftxDd1.value))||(!chkdigital(ftxYy1.value))||(!chkdigital(ftxMm2.value))||(!chkdigital(ftxDd2.value))||(!chkdigital(ftxYy2.value))||(!chkdigital(ftxMm3.value))||(!chkdigital(ftxDd3.value))||(!chkdigital(ftxYy3.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid！");
		return false;
		}*/
		
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
		alert(" Field 'Type of Benefit' under 'Employment Information' is not valid!");
		ftxType.focus();
		return false;
		}
		
		if(!chkNull(ftxOffice.value)) {
		alert(" Field 'Centreline Office' under 'Employment Information' is not valid!");
		ftxOffice.focus();
		return false;
		}
		
		if(!chkNull(ftxContact.value)) {
		alert(" Field 'Contact Name' under 'Employment Information' is not valid!");
		ftxContact.focus();
		return false;
		}
		
		if(!chkNull(ftxBenefit.value)) {
		alert(" Field 'Take Home Benefit' under 'Employment Information' is not valid!");
		ftxBenefit.focus();
		return false;
		}
		
		if(!chkdigital(ftxBenefit.value)) {
		alert(" Field 'Take Home Benefit' under 'Employment Information' is not valid!");
		ftxBenefit.focus();
		return false;
		}
		
		if((!chkNull(ftxMm4.value))||(!chkNull(ftxDd4.value))||(!chkNull(ftxYy4.value))) {
		alert(" Field 'Next benefit due' under 'Employment Information' is not valid!");
		return false;
		}
		
		if((!chkdigital(ftxMm4.value))||(!chkdigital(ftxDd4.value))||(!chkdigital(ftxYy4.value))) {
		alert(" Field 'Next benefit due' under 'Employment Information' is not valid!");
		return false;
		}
		
		if((ftxMm4.value.length>2)||(ftxDd4.value.length>2)||(ftxYy4.value.length!=4)) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid!");
		return false;
		}
		/*if((!chkNull(ftxMm4.value))||(!chkNull(ftxDd4.value))||(!chkNull(ftxYy4.value))||(!chkNull(ftxMm5.value))||(!chkNull(ftxDd5.value))||(!chkNull(ftxYy5.value))||(!chkNull(ftxMm6.value))||(!chkNull(ftxDd6.value))||(!chkNull(ftxYy6.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid！");
		return false;
		}
		
		if((!chkdigital(ftxMm4.value))||(!chkdigital(ftxDd4.value))||(!chkdigital(ftxYy4.value))||(!chkdigital(ftxMm5.value))||(!chkdigital(ftxDd5.value))||(!chkdigital(ftxYy5.value))||(!chkdigital(ftxMm6.value))||(!chkdigital(ftxDd6.value))||(!chkdigital(ftxYy6.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid！");
		return false;
		}*/		
		
		return true;
		}
		
		
		function  CheckFeedback3() {
		var ftxBranch=document.getElementById("txBranch");
		var ftxBank=document.getElementById("txBank");
		var ftxAname=document.getElementById("txAname");
		var ftxBsb=document.getElementById("txBsb");
		var ftxAnumber=document.getElementById("txAnumber");
		var ftxCAnumber=document.getElementById("txCAnumber");
		
		var ftxReName1=document.getElementById("txReName1");
		var ftxReName2=document.getElementById("txReName2");
		var ftxReNum1=document.getElementById("txReNum1");
		var ftxReNum2=document.getElementById("txReNum2");
		
		if(!chkNull(ftxBranch.value)) {
		alert(" Field 'Branch' under 'Bank Information' is not valid!");
		ftxBranch.focus();
		return false;
		}
		
		if(!chkNull(ftxBank.value)) {
		alert(" Field 'Bank Name' under 'Bank Information' is not valid!");
		ftxBank.focus();
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
		
		/*--*****  *****--*/
		
		if(!chkNull(ftxReName1.value)) {
		alert(" Field 'Name 1' under 'Referees' is not valid!");
		ftxReName1.focus();
		return false;
		}
		
		if(!chkNull(ftxReNum1.value)) {
		alert(" Field 'Contact Number 1' under 'Referees' is not valid!");
		ftxReNum1.focus();
		return false;
		}
		
		if(!chkNull(ftxReName2.value)) {
		alert(" Field 'Name 2' under 'Referees' is not valid!");
		ftxReName2.focus();
		return false;
		}
		
		if(!chkNull(ftxReNum2.value)) {
		alert(" Field 'Contact Number 2' under 'Referees' is not valid!");
		ftxReNum2.focus();
		return false;
		}
		
		return true;
		}
		
		function  CheckFeedback4() {
		if(!CheckFeedback1()) return false;
		if(!CheckFeedback3()) return false;
		return true;
		}
		
		function  CheckFeedback5() {
		if(!CheckFeedback2()) return false;
		if(!CheckFeedback3()) return false;
		return true;
		}
		
		function CheckLoan() {		
		var ftxLoan=document.getElementById("txLoan");	
		var ftxInstallment=document.getElementById("txInstallment");
		
		if(!chkNull(ftxLoan.value)) {
		alert(" Field 'Loan Requested' under 'Loan Requirements' is not valid!");
		ftxLoan.focus();
		return false;
		}
		
		if(!chkdigital(ftxLoan.value)) {
		alert(" Field 'Loan Requested' under 'Loan Requirements' is not valid!");
		ftxLoan.focus();
		return false;
		}
		
		/*if(!chkNull(ftxInstallment.value)) {
		alert(" Field 'Number of Instalment' under 'Loan Requirements' is not valid！");
		ftxInstallment.focus();
		return false;
		}
		
		if(!chkdigital(ftxInstallment.value)) {
		alert(" Field 'Number of Instalment' under 'Loan Requirements' is not valid！");
		ftxInstallment.focus();
		return false;
		}
		
		if(ftxInstallment.value>3) {
		alert(" Field 'Number of Instalment' under 'Loan Requirements' is not valid！");
		ftxInstallment.focus();
		return false;
		}*/
		
		return true;
		}
		</script>
	</HEAD>
	<body leftMargin="8" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="396" border="0">
				<TBODY>
					<TR>
						<TD><asp:panel id="Panel5" runat="server" Width="344px">
								<TABLE style="WIDTH: 397px; HEIGHT: 56px" border="0" cellSpacing="0" cellPadding="0" width="397">
									<TR>
										<TD><STRONG>Employment Information</STRONG></TD>
									</TR>
									<TR>
										<TD>
											<asp:radiobuttonlist id="RadioButtonList1" runat="server" Width="352px" Visible="False" AutoPostBack="True">
												<asp:ListItem Value="0" Selected="True">I'm  currently employed.</asp:ListItem>
												<asp:ListItem Value="1">I'm  on a benefit.</asp:ListItem>
											</asp:radiobuttonlist></TD>
									</TR>
								</TABLE>
							</asp:panel></TD>
					</TR>
					<tr>
						<td><asp:panel id="Panel1" runat="server" Width="344px" Visible="True">
								<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="397">
									<TR>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 153px">Employer:
											<asp:TextBox id="txhuiSid" runat="server" Width="24px" Visible="False"></asp:TextBox></TD>
										<TD colSpan="3"><INPUT id="txEmployer" size="32" name="textfield2922" runat="server">
											<FONT color="#990000" face="宋体">*</FONT></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 153px">Employer's Address:</TD>
										<TD colSpan="3"><INPUT id="txAddress" size="32" name="textfield2923" runat="server">
											<FONT color="#990000" face="宋体">*</FONT></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 153px">Employer Phone Number:</TD>
										<TD colSpan="3"><INPUT id="txPhone" size="32" name="textfield2924" runat="server"> <FONT color="#990000" face="宋体">
												*</FONT></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 153px">Job Title:</TD>
										<TD colSpan="3"><INPUT id="txJob" size="32" name="textfield2924" runat="server"> <FONT color="#990000" face="宋体">
												*</FONT></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 153px">Time Employed:
										</TD>
										<TD colSpan="3"><SELECT id="txYear" name="select2" runat="server"><OPTION selected value="0">0</OPTION>
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
											</SELECT>Months</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 153px">Take home pay after taxes:
										</TD>
										<TD colSpan="3">$<INPUT id="txIncome" size="12" name="textfield29242" runat="server">.00<FONT color="#990000" face="宋体">
												<FONT color="#990000" face="宋体">*</FONT></FONT></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 153px">Per:
										</TD>
										<TD colSpan="3">
											<asp:RadioButtonList id="RadioButtonList2" runat="server" Width="224px" RepeatDirection="Horizontal">
												<asp:ListItem Value="Weekly" Selected="True">Weekly</asp:ListItem>
												<asp:ListItem Value="F'nightly">F'nightly</asp:ListItem>
												<asp:ListItem Value="Monthly">Monthly &lt;FONT face=&quot;宋体&quot; color=&quot;#990000&quot;&gt;*&lt;/FONT&gt;</asp:ListItem>
											</asp:RadioButtonList></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 153px">Next payday:</TD>
										<TD colSpan="3">DD <INPUT id="txDd1" size="2" name="textfield29243" runat="server"> 
											MM <INPUT id="txMm1" size="2" name="textfield292432" runat="server"> YYYY <INPUT id="txYy1" size="4" name="textfield292433" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 153px" colSpan="4">&nbsp;</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 153px" colSpan="4"><STRONG>Financial Obligations</STRONG></TD>
									</TR>
									<TR>
										<TD colSpan="4">Are you in default in payment under other <a class="title" href="#" title="small amount credit contract: a credit contract is a small amount
credit contract if:|(a) the contract is not a continuing credit contract; and |(b) the credit provider under the contract is not an ADI; and |(c) the credit limit of the contract is $2,000 (or such other
amount as is prescribed by the regulations) or less; and |(d) the term of the contract is at least 16 days but not longer than
1 year (or such other number of years as is prescribed by the regulations); and |(e) the debtor’s obligations under the contract are not, and will
not be, secured; and |(f) the contract meets any other requirements prescribed by the regulations.">small amount credit contract</a>?
											<asp:RadioButtonList style="Z-INDEX: 0" id="rblHasOtherSamllCredit" runat="server" RepeatDirection="Horizontal">
												<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
												<asp:ListItem Value="0">No</asp:ListItem>
											</asp:RadioButtonList></TD>
									</TR>
									<TR>
										<TD colSpan="4">How many other small amount credit contracts have you had in the 
											last 90 days?
											<asp:DropDownList style="Z-INDEX: 0" id="ddlSmalCreditCount" runat="server">
												<asp:ListItem Value="0">Select</asp:ListItem>
												<asp:ListItem Value="1">1</asp:ListItem>
												<asp:ListItem Value="2">2</asp:ListItem>
												<asp:ListItem Value="3">3</asp:ListItem>
												<asp:ListItem Value="99">More than 3</asp:ListItem>
											</asp:DropDownList></TD>
									</TR> 
									<TR>
										<TD style="WIDTH: 153px" colSpan="4"><STRONG>Expenses Information</STRONG></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 153px">Your rent/mortgage payment:</TD>
										<TD colSpan="3">$<INPUT id="txtHousePaymentValue" type="text" size="12" name="txtHousePaymentValue" runat="server">
											<uc1:CircleDropDownList id="ddlHousePaymentCircle" runat="server"></uc1:CircleDropDownList></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 153px">Your regular repayment to other lenders:</TD>
										<TD colSpan="3">$<INPUT id="txtOtherLenderValue" type="text" size="12" name="txtOtherLenderValue" runat="server">&nbsp;
											<uc1:CircleDropDownList id="ddlOtherLenderCircle" runat="server"></uc1:CircleDropDownList></TD>
									</TR> <!--
									<TR>
										<TD>&nbsp;</TD>
										<TD colSpan="3">MM <INPUT id="txMm2" type="text" size="4" name="textfield2924322" runat="server">
											DD <INPUT id="txDd2" type="text" size="4" name="textfield292434" runat="server">
											YY <INPUT id="txYy2" type="text" size="4" name="textfield2924332" runat="server"><FONT face="宋体" color="#990000">*</FONT></TD>
									</TR>
									<TR>
										<TD>&nbsp;</TD>
										<TD colSpan="3">MM <INPUT id="txMm3" type="text" size="4" name="textfield2924323" runat="server">
											DD <INPUT id="txDd3" type="text" size="4" name="textfield292435" runat="server">
											YY <INPUT id="txYy3" type="text" size="4" name="textfield2924333" runat="server"><FONT face="宋体" color="#990000">*</FONT></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="4">
											<asp:LinkButton id="LinkButton1" runat="server">Next >>></asp:LinkButton></TD>
									</TR>
									--></TABLE>
							</asp:panel></td>
					<tr>
						<td><asp:panel id="Panel2" runat="server" Width="380px" Visible="False">
								<TABLE id="Table2" border="0" cellSpacing="0" cellPadding="0" width="397">
									<TR>
										<TD style="WIDTH: 162px">&nbsp;</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 162px" width="162">Type of benefit:</TD>
										<TD colSpan="3"><INPUT id="txType" size="22" name="textfield2925" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 162px">Centrelink Office:</TD>
										<TD colSpan="3"><INPUT id="txOffice" size="22" name="textfield29222" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 162px">Contact Telephone Number:</TD>
										<TD colSpan="3"><INPUT id="txContact" size="22" name="textfield29232" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 162px; HEIGHT: 22px">How long on this benefit:
										</TD>
										<TD style="HEIGHT: 22px" colSpan="3"><SELECT id="txYear2" name="select2" runat="server"><OPTION selected value="0">0</OPTION>
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
										<TD style="WIDTH: 162px">Take Home Benefit:</TD>
										<TD colSpan="3"><FONT color="#990000" face="宋体">$</FONT><INPUT id="txBenefit" size="15" name="textfield2924222" runat="server"><FONT color="#990000" face="宋体">.00
												<FONT color="#990000" face="宋体">*</FONT></FONT><FONT color="#990000" face="宋体"></FONT></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 162px">Per:
										</TD>
										<TD colSpan="3">
											<asp:RadioButtonList id="RadioButtonList3" runat="server" Width="224px" RepeatDirection="Horizontal">
												<asp:ListItem Value="Weekly" Selected="True">Weekly</asp:ListItem>
												<asp:ListItem Value="F'nightly">F'nightly</asp:ListItem>
												<asp:ListItem Value="Monthly">Monthly &lt;FONT face=&quot;宋体&quot; color=&quot;#990000&quot;&gt;*&lt;/FONT&gt;</asp:ListItem>
											</asp:RadioButtonList></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 162px">Next benefit due:</TD>
										<TD colSpan="3">DD <INPUT style="WIDTH: 40px; HEIGHT: 22px" id="txDd4" size="1" name="textfield292436" runat="server">
											MM <INPUT style="WIDTH: 40px; HEIGHT: 22px" id="txMm4" size="1" name="textfield2924324" runat="server">
											YYYY <INPUT style="WIDTH: 56px; HEIGHT: 22px" id="txYy4" size="4" name="textfield2924334" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
									</TR> <!--
									<TR>
										<TD>&nbsp;</TD>
										<TD colSpan="3">MM <INPUT id="txMm5" type="text" size="4" name="textfield29243222" runat="server">
											DD <INPUT id="txDd5" type="text" size="4" name="textfield2924342" runat="server">
											YY <INPUT id="txYy5" type="text" size="4" name="textfield29243322" runat="server"><FONT face="宋体" color="#990000">*</FONT></TD>
									</TR>
									<TR>
										<TD>&nbsp;</TD>
										<TD colSpan="3">MM <INPUT id="txMm6" type="text" size="4" name="textfield29243232" runat="server">
											DD <INPUT id="txDd6" type="text" size="4" name="textfield2924352" runat="server">
											YY <INPUT id="txYy6" type="text" size="4" name="textfield29243332" runat="server"><FONT face="宋体" color="#990000">*</FONT></TD>
									</TR>
									<TR>
										<TD align="center" colSpan="4">
											<asp:LinkButton id="Linkbutton2" runat="server">Next >>></asp:LinkButton></TD>
									</TR>
									--></TABLE>
							</asp:panel></td>
					</tr>
					<tr>
						<td><asp:panel id="Panel3" runat="server" Width="392px" Visible="True">
								<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="397">
									<TR>
										<TD>&nbsp;</TD>
									</TR>
									<TR>
										<TD colSpan="4"><STRONG>Bank Information<BR>
												This must be the account where your pay / benefit is paid into.
												<BR>
												This is the account we will credit to and deduct from</STRONG></TD>
									</TR>
									<TR>
										<TD width="85">Bank Name:</TD>
										<TD width="105"><INPUT id="txBank" size="10" name="textfield2102" runat="server"> <FONT color="#990000" face="宋体">
												*</FONT></TD>
										<TD width="99">Branch:</TD>
										<TD width="108"><INPUT id="txBranch" size="10" name="textfield210" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
									</TR>
									<TR>
										<TD>Account Name:</TD>
										<TD colSpan="3"><INPUT id="txAname" name="textfield211" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
									</TR>
									<TR>
										<TD>BSB:</TD>
										<TD><INPUT id="txBsb" size="10" name="textfield2112" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
										<TD>Account Number:</TD>
										<TD><INPUT id="txAnumber" size="10" name="textfield21122" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
									</TR>
									<TR>
										<TD colSpan="2">Confirm Account Numer:</TD>
										<TD colSpan="2"><INPUT id="txCAnumber" name="textfield2113" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
									</TR>
									<TR>
										<TD colSpan="4">Preferred methods of contact for this loan:<BR>
											<asp:RadioButtonList id="RadioButtonList4" runat="server" Width="312px" RepeatDirection="Horizontal">
												<asp:ListItem Value="Email" Selected="True">Email</asp:ListItem>
												<asp:ListItem Value="Mobile">Mobile</asp:ListItem>
												<asp:ListItem Value="Home Phone">Home Phone</asp:ListItem>
												<asp:ListItem Value="Work Phone">Work Phone</asp:ListItem>
											</asp:RadioButtonList></TD>
									</TR>
								</TABLE>
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="397">
									<TR>
										<TD width="132"><STRONG><BR>
												Referees</STRONG></TD>
										<TD width="132">&nbsp;</TD>
										<TD width="133">&nbsp;</TD>
									</TR>
									<TR>
										<TD colSpan="3">Please provide 3 referees (relative preferred).</TD>
									</TR>
									<TR>
										<TD>Name</TD>
										<TD>Relationship</TD>
										<TD>Contact Number</TD>
									</TR>
									<TR>
										<TD><INPUT style="WIDTH: 96px; HEIGHT: 22px" id="txReName1" size="10" name="Text1" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
										<TD><FONT face="宋体"><INPUT style="WIDTH: 96px; HEIGHT: 22px" id="selReShip1" size="10" name="Text1" runat="server"></FONT></TD>
										<TD><INPUT style="WIDTH: 96px; HEIGHT: 22px" id="txReNum1" size="10" name="Text4" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
									</TR>
									<TR>
										<TD><INPUT style="WIDTH: 96px; HEIGHT: 22px" id="txReName2" size="10" name="Text2" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
										<TD><INPUT style="WIDTH: 96px; HEIGHT: 22px" id="selReShip2" size="10" name="Text1" runat="server"></TD>
										<TD><INPUT style="WIDTH: 96px; HEIGHT: 22px" id="txReNum2" size="10" name="Text5" runat="server"><FONT color="#990000" face="宋体">*</FONT></TD>
									</TR>
									<TR>
										<TD><INPUT style="WIDTH: 96px; HEIGHT: 22px" id="txReName3" size="10" name="Text3" runat="server"></TD>
										<TD><FONT face="宋体"><INPUT style="WIDTH: 96px; HEIGHT: 22px" id="selReShip3" size="10" name="Text1" runat="server"></FONT></TD>
										<TD><INPUT style="WIDTH: 96px; HEIGHT: 22px" id="txReNum3" size="10" name="Text6" runat="server"></TD>
									</TR>
									<TR>
										<TD colSpan="4" align="center">
											<asp:LinkButton id="Linkbutton3" runat="server">Next >>></asp:LinkButton></TD>
									</TR>
								</TABLE>
							</asp:panel></td>
					</tr>
					<tr>
						<td align="center"><asp:panel id="Panel4" runat="server" Width="392px" Visible="False" Height="208px">
								<TABLE border="0" cellSpacing="0" cellPadding="0" width="390">
									<TR>
										<TD colSpan="3"><STRONG>Loan Requirements</STRONG><BR>
										</TD>
									</TR>
									<TR>
										<TD colSpan="3">What is the primary purpose of the loan:
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 143px" colSpan="3">
											<asp:TextBox id="txtLoanPurpose" runat="server" Width="392px" Height="22px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 143px" width="143">Loan Requested:</TD>
										<TD colSpan="2">$<INPUT style="WIDTH: 166px; HEIGHT: 22px" id="txLoan" name="Text1" runat="server"><FONT color="#990000" face="宋体">*<INPUT style="WIDTH: 11px; HEIGHT: 22px" id="Hidden1" size="1" type="hidden" name="Hidden1"
													runat="server"> </FONT>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 143px" width="143">Loan Repayment:</TD>
										<TD colSpan="2"><FONT color="#990000" face="宋体">
												<asp:DropDownList id="DropDownList1" runat="server">
													<asp:ListItem Value="1">1 installment</asp:ListItem>
													<asp:ListItem Value="2">2 installments</asp:ListItem>
													<asp:ListItem Value="3">3 installments</asp:ListItem>
													<asp:ListItem Value="4">Repay on next payday</asp:ListItem>
												</asp:DropDownList>*
												<asp:Button id="Button1" runat="server" Text="Calculate"></asp:Button><INPUT style="WIDTH: 16px; HEIGHT: 22px" id="txInstallment" size="1" name="Text2" runat="server"
													visible="false"></FONT></TD>
									</TR>
									<TR>
										<TD colSpan="3">Note: Each installment dues on your payday . Please make sure your 
											repayment funds are available in your account for deduction on each installment 
											due date.</TD>
									</TR>
									<TR>
										<TD colSpan="3"></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 160px" width="143" colSpan="3"><BR>
											<STRONG>Repayment Schedule</STRONG></TD>
									</TR>
									<TR>
										<TD>&nbsp;</TD>
										<TD>Date due
										</TD>
										<TD>Repayment due</TD>
									</TR>
									<TR>
										<TD>1st Installment
										</TD>
										<TD><FONT face="宋体">
												<asp:TextBox id="d1F" runat="server" Width="113px" ReadOnly="True" BorderStyle="None"></asp:TextBox></FONT></TD>
										<TD><FONT face="宋体">
												<asp:TextBox id="s1" runat="server" Width="113px" ReadOnly="True" BorderStyle="None"></asp:TextBox></FONT></TD>
									</TR>
									<TR>
										<TD>2nd Installment
										</TD>
										<TD><FONT face="宋体">
												<asp:TextBox id="d2F" runat="server" Width="113px" ReadOnly="True" BorderStyle="None"></asp:TextBox></FONT></TD>
										<TD><FONT face="宋体">
												<asp:TextBox id="s2" runat="server" Width="113px" ReadOnly="True" BorderStyle="None"></asp:TextBox></FONT></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 143px; HEIGHT: 21px">3rd Installment
										</TD>
										<TD><FONT face="宋体">
												<asp:TextBox id="d3F" runat="server" Width="113px" ReadOnly="True" BorderStyle="None"></asp:TextBox></FONT></TD>
										<TD><FONT face="宋体">
												<asp:TextBox id="s3" runat="server" Width="113px" ReadOnly="True" BorderStyle="None"></asp:TextBox></FONT></TD>
									</TR>
									<TR id="annualRateRow" runat="server">
										<TD colSpan="3">
											<TABLE>
												<TR>
													<TD colSpan="3"></TD>
												</TR>
												<TR>
													<TD colSpan="3"><STRONG>Annual Percentage Rate</STRONG>
														<asp:Label id="labAnnualRate" Runat="server"></asp:Label></TD>
												</TR>
												<TR>
													<TD colSpan="3">Note: Credit charges are 1.333% per day of the credit advanced over 
														the repayment period of time. The total charge of the credit is evenly 
														distributed to each installment. Chargeable repayment period won't start until 
														your next payday, if you choose to repay other than "repay on your next payday" 
														option and there is not more than 15 days to your next payday. For early 
														repayment, chargeable repayment period is from credit advance date to the 
														actual repayment date.</TD>
												</TR>
												<TR>
													<TD style="WIDTH: 160px" width="143" colSpan="3"><BR>
														<STRONG>Comparison Rate Schedule</STRONG></TD>
												</TR>
												<TR>
													<TD colSpan="3">Cash loans provided by Golden Bridge Enterprises (Aust) Pty Ltd<BR>
														Date of issue: 01/10/05<BR>
														<TABLE border="1" cellSpacing="0" borderColor="inactiveborder" cellPadding="0">
															<TR>
																<TD>Loan Amount</TD>
																<TD></TD>
																<TD>Loan term</TD>
																<TD>Comparison Rate p.a.</TD>
																<TD>Annual Percentage Rate</TD>
															</TR>
															<TR>
																<TD>$250.00</TD>
																<TD>(unsecured)</TD>
																<TD>2 weeks</TD>
																<TD>486.89%</TD>
																<TD>486.89%</TD>
															</TR>
															<TR>
																<TD>$600.00</TD>
																<TD>(unsecured)</TD>
																<TD>8 weeks</TD>
																<TD>486.89%</TD>
																<TD>486.89%</TD>
															</TR>
														</TABLE>
													</TD>
												</TR>
												<TR>
													<TD colSpan="3"><STRONG>WARNING</STRONG>: This Comparison Rate applies only to the 
														example or examples given. Different amounts and terms will result in different 
														comparison rates. Costs such as redraw fees or early repayment fees, and cost 
														savings such as fee waivers, are not included in the Comparison Rate but may 
														influence the cost of the loan.</TD>
												</TR>
											</TABLE>
										</TD>
									</TR>
									<TR>
										<TD style="WIDTH: 143px" align="center">&nbsp;</TD>
									</TR>
									<TR>
										<TD colSpan="3"><TEXTAREA id="TEXTAREA1" rows="3" cols="46" readOnly name="TEXTAREA1" runat="server" value="By typing my name below I am applying for electronic cash loan and certify that this information is true and correct under penalty of perjury. I authorize Golden Bridge Cash Solution to verify any information submitted on this application."></TEXTAREA>
										</TD>
									</TR>
									<TR>
										<TD colSpan="3"></TD>
									</TR>
									<TR>
										<TD colSpan="3">To Sign,please type your FULL name here:
											<asp:TextBox id="txFullname" runat="server" Width="145px"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD style="WIDTH: 143px">&nbsp;</TD>
									</TR>
									<TR>
										<TD colSpan="3" align="center"><INPUT style="WIDTH: 110px; HEIGHT: 24px" id="Submit1" value="I agree, Submit" type="submit"
												name="Submit" runat="server"><FONT face="宋体">&nbsp;&nbsp;&nbsp; </FONT><INPUT style="WIDTH: 52px; HEIGHT: 24px" value="Reset" type="submit" name="Submit2"></TD>
									</TR>
								</TABLE>
							</asp:panel></td>
					</tr>
				</TBODY>
			</table>
		</form>
		<script type="text/javascript">
			$(document).ready(function(){
				$('a.title').cluetip({splitTitle: '|', arrows: true});
			});
		</script>
	</body>
</HTML>
