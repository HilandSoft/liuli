<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Page language="c#" Codebehind="Step3.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Step3" %>
<%@ Register TagPrefix="uc1" TagName="CircleDropDownList" Src="../Include/CircleDropDownList.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<script language="javascript" src="../jslib/commCheck.js" type="text/javascript"></script>
			<script language="javascript">
			
		function  CheckFeedback() {
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
		
		if(!chkNull(ftxEmployer.value)) {
		alert(" Field 'Employer Name' under 'Employment Information' is not valid!");
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
		alert(" Field 'Take home pay' under 'Employment Information' is not valid!");
		ftxIncome.focus();
		return false;
		}
		
		if(!chkdigital(ftxIncome.value)) {
		alert(" Field 'Take home pay' under 'Employment Information' is not valid!");
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
		alert(" Field 'Follow Payday' under 'Employment Information' is not valid!");
		return false;
		}
		
		if((!chkdigital(ftxMm2.value))||(!chkdigital(ftxDd2.value))||(!chkdigital(ftxYy2.value))) {
		alert(" Field 'Follow Payday' under 'Employment Information' is not valid!");
		return false;
		}
		
		if((ftxMm2.value.length>2)||(ftxDd2.value.length>2)||(ftxYy2.value.length!=4)) {
		alert(" Field 'Follow Payday' under 'Employment Information' is not valid!");
		return false;
		}
		}
		
		return true;
		}	
			</script>
			<style type="text/css">.word1 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	.word2 { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
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
											<td height="20">&nbsp;</td>
											<td class="word2">Pre-qualification</td>
										</tr>
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
												<div align="center"><IMG height="10" src="images/1_04.gif" width="16"></div>
											</td>
											<td class="word1">About your work</td>
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
								<td bgColor="#cc3300" colSpan="2" height="30"><IMG height="30" src="images/step3.gif" width="400">
									<asp:textbox id="txLoanSid" runat="server" Visible="False" Width="56px"></asp:textbox></td>
							</tr>
							<tr>
								<td height="10">&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td width="32%" height="30">Employer Name :</td>
								<td><input id="txEmployer" style="WIDTH: 150px" type="text" name="textfield22322" runat="server">
									<FONT color="#ff0000">*
										<asp:TextBox id="txLoan" runat="server" Visible="False"></asp:TextBox></FONT></td>
							</tr>
							<tr>
								<td height="30">Employer's Address:
								</td>
								<td><input id="txAddress" style="WIDTH: 150px" type="text" name="textfield223222" runat="server">
									<FONT color="#ff0000">*</FONT></td>
							</tr>
							<tr>
								<td height="30">Employer telephone area code and number:
								</td>
								<td><input id="txPhone" style="WIDTH: 150px" type="text" name="textfield223223" runat="server">
									<FONT color="#ff0000">*</FONT></td>
							</tr>
							<tr>
								<td height="30">Employment Status :
								</td>
								<td><select id="dlestatus" name="select" runat="server">
										<option value="Full-time" selected>Full-time</option>
										<option value="Part-time">Part-time</option>
										<option value="Casual">Casual</option>
										<option value="Self Employed">Self Employed</option>
										<option value="Other">Other</option>
									</select></td>
							</tr>
							<tr>
								<td height="30">Job Title
								</td>
								<td><input id="txJob" style="WIDTH: 150px" type="text" name="textfield223224" runat="server">
									<FONT color="#ff0000">*</FONT></td>
							</tr>
							<tr>
								<td height="30">Time Employed:
								</td>
								<td><SELECT id="txYear" name="select2" runat="server">
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
										<OPTION value="12">12 or above</OPTION>
									</SELECT>
									Years&nbsp;
									<SELECT id="txMonth" style="WIDTH: 60px" name="select2" runat="server">
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
									Months</td>
							</tr>
							<tr>
								<td height="30">Take home pay after taxes:
								</td>
								<td>$<INPUT id="txIncome" style="WIDTH: 150px" type="text" name="textfield29242" runat="server">
									.00 <FONT color="#ff0000">*</FONT>
								</td>
							</tr>
							<tr>
								<td height="30">Per:</td>
								<td align="left"><asp:radiobuttonlist id="RadioButtonList2" runat="server" Width="70%" AutoPostBack="True" RepeatDirection="Horizontal">
										<asp:ListItem Value="0" Selected="True">Weekly</asp:ListItem>
										<asp:ListItem Value="1">F'nightly</asp:ListItem>
										<asp:ListItem Value="2">Bi-Monthly</asp:ListItem>
										<asp:ListItem Value="3">Monthly &lt;FONT face=&quot;&#203;&#206;&#204;&#229;&quot; 
                  color=&quot;#990000&quot;&gt;*&lt;/FONT&gt;</asp:ListItem>
									</asp:radiobuttonlist></td>
							</tr>
							<tr>
								<td height="30">Next Payday:
								</td>
								<td>DD <INPUT id="txDd1" style="WIDTH: 60px" type="text" name="textfield29243" runat="server">
									MM <INPUT id="txMm1" style="WIDTH: 60px" type="text" name="textfield292432" runat="server">
									YYYY <INPUT id="txYy1" style="WIDTH: 150px" type="text" name="textfield292433" runat="server"></td>
							</tr>
							<tr>
								<td colSpan="2">
									<table id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0" runat="server">
										<tr>
											<td width="32%" height="30">Follow Payday:
											</td>
											<td>DD <INPUT id="txDd2" style="WIDTH: 60px" type="text" name="textfield29243" runat="server">
												MM <INPUT id="txMm2" style="WIDTH: 60px" type="text" name="textfield292432" runat="server">
												YYYY <INPUT id="txYy2" style="WIDTH: 150px" type="text" name="textfield292433" runat="server"></td>
										</tr>
									</table>
								</td>
							</tr>
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
							<tr>
								<td colSpan="2" height="30">&nbsp;</td>
							</tr>
							<tr>
								<td colSpan="2" height="30">
									<div align="center">
										<asp:Button id="bnView" runat="server" Text="View Repayment Schedule"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
										&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<input id="Submit1" type="submit" value="Next>>>" name="Submit" runat="server">
										<asp:Label id="Label1" runat="server"></asp:Label>
									</div>
								</td>
							</tr>
						</table>
						<FONT face="宋体">
							<asp:Panel id="Panel1" runat="server" Visible="False">
								<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
									<TR>
										<TD width="30%" height="30">Repayment Amount:</TD>
										<TD>
											<asp:TextBox id="txRepayA" runat="server" Width="150"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD height="30">Repayment Frequency:</TD>
										<TD>
											<asp:TextBox id="txRepayF" runat="server" Width="150"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD height="30">Number of Instalment:</TD>
										<TD>
											<asp:TextBox id="txNumber" runat="server" Width="150"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD height="30">Payment Start:</TD>
										<TD>
											<asp:TextBox id="txStart" runat="server" Width="150"></asp:TextBox></TD>
									</TR>
									<TR>
										<TD height="30">Payment End:</TD>
										<TD>
											<asp:TextBox id="txEnd" runat="server" Width="150"></asp:TextBox></TD>
									</TR>
								</TABLE>
							</asp:Panel></FONT>
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
