<%@ Page language="c#" Codebehind="Calculator.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Calculator" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<script language="javascript" src="../jslib/commCheck.js" type="text/javascript"></script>
			<style type="text/css">
.word1 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
.word2 { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
</style>
			<script language="javascript">
function Check1() {
var vtxIncome=document.getElementById("txIncome");
var vdlterms=document.getElementById("dlterms");

if(vtxIncome.value.length==0) {
		alert(" The following field are required:Your take home pay!");
		vtxIncome.focus();
		return false;
}

if(vdlterms.value.length==0) {
		alert(" The following field are required:How long are you going to borrow!");
		vdlterms.focus();
		return false;
}		
		return true;
}


function Check2() {
var vtxLoan=document.getElementById("txLoan");
var vtxIncome2=document.getElementById("txIncome2");
var vdlterms2=document.getElementById("dlterms2");
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

if(vtxLoan.value.length==0) {
		alert(" The following field are required:Loan requested amount!");
		vtxLoan.focus();
		return false;
}
		
		if(!chkdigital(vtxLoan.value)) {
		alert(" The following field are required:Loan requested amount!");
		vtxLoan.focus();
		return false;
		}
		
		if((vtxLoan.value<1000)||(vtxLoan.value>5000)){
		alert(" Field 'Loan requested amount' is not valid!");
		vtxLoan.focus();
		return false;
		}

if(vtxIncome2.value.length==0) {
		alert(" The following field are required:Your take home pay!");
		vtxIncome2.focus();
		return false;
}
		
		if(!chkdigital(vtxIncome2.value)) {
		alert(" The following field are required:Your take home pay!");
		vtxIncome2.focus();
		return false;
		}
		
		if((!chkNull(ftxMm1.value))||(!chkNull(ftxDd1.value))||(!chkNull

(ftxYy1.value))) {
		alert(" The following field are required:Next Payday!");
		return false;
		}
		
		if((!chkdigital(ftxMm1.value))||(!chkdigital(ftxDd1.value))||(!

chkdigital(ftxYy1.value))) {
		alert(" The following field are required:Next Payday!");
		return false;
		}
		
		if((ftxMm1.value.length>2)||(ftxDd1.value.length>2)||

(ftxYy1.value.length!=4)) {
		alert(" The following field are required:Next Payday!");
		return false;
		}
		
		if(usertype=="2") {		
		if((!chkNull(ftxMm2.value))||(!chkNull(ftxDd2.value))||(!chkNull

(ftxYy2.value))) {
		alert(" The following field are required:Following next payday!");
		return false;
		}
		
		if((!chkdigital(ftxMm2.value))||(!chkdigital(ftxDd2.value))||(!

chkdigital(ftxYy2.value))) {
		alert(" The following field are required:Following next payday!");
		return false;
		}
		
		if((ftxMm2.value.length>2)||(ftxDd2.value.length>2)||

(ftxYy2.value.length!=4)) {
		alert(" The following field are required:Following next payday!");
		return false;
		}
		}

if(vdlterms2.value.length==0) {
		alert(" The following field are required:How long are you going to borrow!");
		vdlterms2.focus();
		return false;
}
		
		return true;
}
			</script>
	</HEAD>
	<body LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td>
						<uc1:head id="Head1" runat="server"></uc1:head>
					</td>
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
                            <td height="50">&nbsp;</td>
                          </tr>
                          <tr>
                            <td><div align="center"><img src="images/calculator.jpg" width="140" height="210"></div></td>
                          </tr>
                        </table></td>
					<td valign="top">
						<table width="100%" border="0" cellspacing="0" cellpadding="0">
							<TR bgcolor="#cc3300">
								<TD height="30"><img src="images/Calculator.gif" width="400" height="30"></TD>
							</TR>
							<tr>
								<td height="10"></td>
							</tr>
							<tr>
								<td><table width="100%" border="0" cellspacing="1" cellpadding="1">
										<tr>
											<td colspan="2"><p>This calculator is only for the personal loans. For payday loans, 
													please refer to our <a href="../fees.htm" target="_blank">Cost and Fees</a> for 
													more information.
												</p>
											</td>
										</tr>
										<tr>
											<td width="15%">
												I want to calculate:
											</td>
											<td>
												<asp:RadioButtonList id="RadioButtonList1" runat="server" Width="224px" AutoPostBack="True">
													<asp:ListItem Value="1" Selected="True">How much I can borrow?</asp:ListItem>
													<asp:ListItem Value="2">What my repayment(s) will be?</asp:ListItem>
												</asp:RadioButtonList></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><table width="100%" border="0" cellspacing="0" cellpadding="0" id="Table1" runat="server">
										<tr>
											<td height="30" colspan="2"><p><strong>How much I can borrow? </strong>
												</p>
											</td>
										</tr>
										<tr>
											<td width="26%" height="30">
												Your take home pay:
											</td>
											<td>$ <INPUT id="txIncome" type="text" style="WIDTH:150px" name="textfield29242" runat="server">
												.00 <FONT color="#ff0000">*</FONT> 
											</td>
										</tr>
										<tr>
											<td height="30">Per:</td>
											<td><asp:RadioButtonList id="rbPer" runat="server" RepeatDirection="Horizontal">
													<asp:ListItem Value="0" Selected="True">Weekly</asp:ListItem>
													<asp:ListItem Value="1">F'nightly</asp:ListItem>
													<asp:ListItem Value="2">Bi-Monthly</asp:ListItem>
													<asp:ListItem Value="3">Monthly</asp:ListItem>
												</asp:RadioButtonList></td>
										</tr>
										<tr>
											<td height="30">
												How long are you going to borrow?
											</td>
											<td><SELECT id="dlterms" name="select" runat="server" style="WIDTH:150px">
													<OPTION value="" selected>------Select-----</OPTION>
													<OPTION value="3">3 Months</OPTION>
													<OPTION value="4">4 Months</OPTION>
													<OPTION value="5">5 Months</OPTION>
													<OPTION value="6">6 Months</OPTION>
													<OPTION value="7">7 Months</OPTION>
													<OPTION value="8">8 Months</OPTION>
													<OPTION value="9">9 Months</OPTION>
													<OPTION value="10">10 Months</OPTION>
													<OPTION value="11">11 Months</OPTION>
													<OPTION value="12">12 Months</OPTION>
												</SELECT></td>
										</tr>
										<tr>
											<td height="30" colspan="2">
												Note: The minimum loan amount is $1000 and maximum is $5000.
											</td>
										</tr>
										<tr>
											<td></td>
											<td height="30"><div align="left"><INPUT id="bnStar1" type="button" value="Start over" name="Submit2" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;
													<INPUT id="bnCal1" type="submit" value="Calculate" name="Submit" runat="server">
												</div>
											</td>
										</tr>
										<tr>
											<td height="30">
												You can borrow up to:
											</td>
											<td>
												$ <INPUT id="txBorrow" type="text" style="WIDTH:150px" name="textfield29242" runat="server"
													readonly> 
											</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td>&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><table width="100%" border="0" cellspacing="0" cellpadding="0" id="Table2" runat="server">
										<tr>
											<td height="30" colspan="2"><p><strong>What my repayment(s) will be? </strong>
												</p>
											</td>
										</tr>
										<tr>
											<td width="30%" height="30">
												Loan requested amount:
											</td>
											<td>$
  <INPUT id="txLoan" type="text" style="WIDTH:150px" name="textfield292422" runat="server">
												  .00 <FONT color="#ff0000">*</FONT> </td></tr>
										<tr>
											<td height="30">Your take home pay:
											</td>
											<td>$
  <INPUT id="txIncome2" type="text" style="WIDTH:150px" name="textfield2924222" runat="server">
												  .00 <FONT color="#ff0000">*</FONT> </td></tr>
										<tr>
											<td height="30">Per:</td>
											<td>
												<asp:RadioButtonList id="RadioButtonList2" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
													<asp:ListItem Value="0" Selected="True">Weekly</asp:ListItem>
													<asp:ListItem Value="1">F'nightly</asp:ListItem>
													<asp:ListItem Value="2">Bi-Monthly</asp:ListItem>
													<asp:ListItem Value="3">Monthly</asp:ListItem>
												</asp:RadioButtonList></td>
										</tr>
										<TR>
											<TD height="30">
												<P>Date of next payday:
												</P>
											</TD>
											<TD>DD <INPUT id="txDd1" type="text" style="WIDTH:60px" name="textfield29243" runat="server">
												MM <INPUT id="txMm1" type="text" style="WIDTH:60px" name="textfield292432" runat="server">
												YYYY <INPUT id="txYy1" type="text" style="WIDTH:150px" name="textfield292433" runat="server"></TD>
										</TR>
										<tr>
											<td colspan="2">
												<asp:Panel id="Panel1" runat="server" Visible="False">
													<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="30%" height="20">
																<P>Following next payday:
																</P>
															</TD>
															<TD>DD <INPUT id="txDd2" style="WIDTH: 60px" type="text" name="textfield29243" runat="server">
																MM <INPUT id="txMm2" style="WIDTH: 60px" type="text" name="textfield292432" runat="server">
																YYYY <INPUT id="txYy2" style="WIDTH: 150px" type="text" name="textfield292433" runat="server"></TD>
														</TR>
													</TABLE>
												</asp:Panel>
											</td>
										</tr>
										<tr>
											<td height="30">How long are you going to borrow?
											</td>
											<td><SELECT id="dlterms2" name="select2" runat="server" style="WIDTH:150px">
													<OPTION value="" selected>------Select-----</OPTION>
													<OPTION value="3">3 Months</OPTION>
													<OPTION value="4">4 Months</OPTION>
													<OPTION value="5">5 Months</OPTION>
													<OPTION value="6">6 Months</OPTION>
													<OPTION value="7">7 Months</OPTION>
													<OPTION value="8">8 Months</OPTION>
													<OPTION value="9">9 Months</OPTION>
													<OPTION value="10">10 Months</OPTION>
													<OPTION value="11">11 Months</OPTION>
													<OPTION value="12">12 Months</OPTION>
												</SELECT></td>
										</tr>
										<tr>
											<td height="30" colspan="2">Note: The minimum loan amount is $1000 and maximum is 
												$5000.
											</td>
										</tr>
										<tr>
											<td height="30"><div align="center">
												</div>
											</td>
											<td><div align="left"><INPUT id="bnStar2" type="button" value="Start over" name="Submit2" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;<INPUT id="bnCal2" type="submit" value="Calculate" name="Submit" runat="server">
												</div>
											</td>
										</tr>
										<tr>
											<td height="30" colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
													<tr>
														<td width="30%" height="30">Repayment Amount:</td>
														<td>
															<asp:TextBox id="txRepayA" runat="server" Width="150"></asp:TextBox></td>
													</tr>
													<tr>
														<td height="30">Repayment Frequency:</td>
														<td>
															<asp:TextBox id="txRepayF" runat="server" Width="150"></asp:TextBox></td>
													</tr>
													<tr>
														<td height="30">Number of Instalment:</td>
														<td>
															<asp:TextBox id="txNumber" runat="server" Width="150"></asp:TextBox></td>
													</tr>
													<tr>
														<td height="30">Payment Start:</td>
														<td>
															<asp:TextBox id="txStart" runat="server" Width="150"></asp:TextBox></td>
													</tr>
													<tr>
														<td height="30">Payment End:</td>
														<td>
															<asp:TextBox id="txEnd" runat="server" Width="150"></asp:TextBox></td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td colspan="2"><asp:Label id="Label1" runat="server"></asp:Label></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colspan="3"><uc1:bottom id="Bottom1" runat="server"></uc1:bottom></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
