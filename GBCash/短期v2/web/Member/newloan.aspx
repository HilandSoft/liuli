<%@ Register TagPrefix="uc1" TagName="MemberLeft" Src="MemberLeft.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MemberTop" Src="MemberTop.ascx" %>
<%@ Page language="c#" Codebehind="newloan.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.newloan" %>
<%@ Register TagPrefix="uc1" TagName="CircleDropDownList" Src="../Include/CircleDropDownList.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<meta content="text/html; charset=UTF-8" http-equiv="Content-Type">
		<LINK href="../jslib/jquery-cluetip/jquery.cluetip.css" type=text/css rel=stylesheet >
		<script type="text/javascript" src="../javascriptN/jquery-1.4.4.min.js"></script>
		<script language="javascript" type="text/javascript" src="../jslib/commCheck.js"></script>
		<script language="javascript" type="text/javascript" src="../jslib/jquery-cluetip/lib/jquery-1.7.1.min.js"></script>
		<script language="javascript" type="text/javascript" src="../jslib/jquery-cluetip/jquery.cluetip.min.js"></script>
		<script language="javascript">
		function CheckLoan() {	
		var fnPayMm=document.getElementById("nPayMm");			
		var fnPayDd=document.getElementById("nPayDd");		
		var fnPayYy=document.getElementById("nPayYy");	
		var ftxLoan=document.getElementById("txLoan");	
		var ftxInstallment=document.getElementById("txInstallment");

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
		
		if((!chkNull(fnPayMm.value))||(!chkNull(fnPayDd.value))||(!chkNull(fnPayYy.value))) {
		alert(" Field 'Next Payday' under 'Member Loan Application' is not valid！");
		return false;
		}
		
		if((!chkdigital(fnPayMm.value))||(!chkdigital(fnPayDd.value))||(!chkdigital(fnPayYy.value))) {
		alert(" Field 'Next Payday' under 'Member Loan Application' is not valid！");
		return false;
		}
		
		if(!chkNull(ftxLoan.value)) {
		alert(" Field 'Loan Requested' under 'Loan Requirements' is not valid！");
		ftxLoan.focus();
		return false;
		}
		
		if(!chkdigital(ftxLoan.value)) {
		alert(" Field 'Loan Requested' under 'Loan Requirements' is not valid！");
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
		<LINK rel="stylesheet" type="text/css" href="../CSSN/final.css">
			<style type="text/css">.style2 { FONT-SIZE: small; FONT-FAMILY: Verdana }
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
			<div style="MARGIN-LEFT: 0px; HEIGHT: 1024px" id="content">
				<form id="Form2" method="post" runat="server">
					<table border="0" cellSpacing="1" cellPadding="1" width="510">
						<tr>
							<td vAlign="top"><asp:panel id="Panel2" runat="server" Visible="False" Width="472px" Height="120px">
									<TABLE cellSpacing="1" cellPadding="1" width="510" border="0">
										<TR>
											<TD><FONT face="宋体"></FONT><FONT face="宋体"></FONT><BR>
												<BR>
												<P>Please make sure your details are up to date.
													<asp:linkbutton id="LinkButton1" runat="server">Click here </asp:linkbutton>to 
													review and edit your information.
												</P>
											</TD>
										</TR>
										<TR>
											<TD>
												<P>If you have changed your banking details since your last loan application, you 
													need to contact us on 1300 138 916 or Email to <A href="mailto:apply@gbcash.com.au">
														apply@gbcash.com.au </A>to obtain a Change of Account Details Form.</P>
											</TD>
										</TR>
										<TR>
											<TD>
												<asp:CheckBox id="CheckBox1" runat="server" Width="192px" Text="My details are up to date"></asp:CheckBox><INPUT id="Hidden3" style="WIDTH: 40px; HEIGHT: 21px" type="hidden" size="1" name="Hidden1"
													runat="server"></TD>
										</TR>
										<TR>
											<TD align="center"><BR>
												<asp:LinkButton id="LinkButton3" runat="server">Next</asp:LinkButton></TD>
										</TR>
									</TABLE>
								</asp:panel></td>
						</tr>
						<tr>
							<td><asp:panel id="PanelWarning" runat="server" Visible="True" Width="472px" Height="120px"><IFRAME border="0" src="../Warning.htm" frameBorder="no" width="100%" height="400"></IFRAME>
									<DIV align="center">
										<asp:LinkButton id="Linkbutton4" runat="server">Next</asp:LinkButton></DIV>
								</asp:panel></td>
						</tr>
						<tr>
							<td><asp:panel id="PanelNoExtensionTip" runat="server" Visible="False" Width="472px" Height="160px">
							Dear customers:<BR>From 01/07/13, our new fee structure 
      will apply to all applications made thereafter. That means in most cases 
      you will be paying lower fees for the same amount you used to pay. <BR>For 
      example, a $400 loan over 4 weeks used to cost you $149.3. From 01/07/13, 
      that same loan, over the same time frame, will only cost $96. So you’ll be 
      $53.3 better off.<BR>However, not all about the good news, no extension 
      will be permitted for applications made after 01/07/13 under the new fee 
      structure. <BR>Please refer to <A href="../Costs-And-Fees/" target="_blank">Costs &amp; Fees</A> for more information. 
      <DIV align="center">
										<asp:LinkButton id="LinkbuttonAcknowledge" runat="server">I acknowledge</asp:LinkButton></DIV>
								</asp:panel></td>
						</tr>
						<tr>
							<td><asp:panel id="Panel1" runat="server" Visible="False" Width="500px">
									<TABLE cellSpacing="0" cellPadding="0" width="500" border="0">
										<TR>
											<TD><FONT face="宋体"></FONT><BR>
												Review your information listed below; click the <STRONG>Edit </STRONG>button 
												above each item to change the information. Be sure to click&nbsp;<STRONG>Save </STRONG>
												when you're done.
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="504" border="0">
													<TR>
														<TD height="39"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><BR>
															<STRONG>Member 
																Information&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<A href="detailnew.aspx">Edit</A> </STRONG>
														</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table2" style="WIDTH: 496px; HEIGHT: 100px" cellSpacing="0" cellPadding="0"
																width="496" border="0">
																<TR>
																	<TD width="133">First Name:</TD>
																	<TD width="118"><%=txFname%></TD>
																	<TD width="91">Middle Name:</TD>
																	<TD width="106"><%=txMname%></TD>
																</TR>
																<TR>
																	<TD width="133">Last Name:</TD>
																	<TD width="118"><%=txLname%></TD>
																	<TD width="91">&nbsp;</TD>
																	<TD>&nbsp;</TD>
																</TR>
																<TR>
																	<TD width="133">Date of Birth:</TD>
																	<TD width="118"><%=txDate%><FONT face="宋体"></FONT></TD>
																	<TD width="91">E-Mail:
																	</TD>
																	<TD><%=txEmail%></TD>
																</TR>
																<TR>
																	<TD width="133">Driver Licence Number:</TD>
																	<TD width="118"><%=txDriver%></TD>
																	<TD width="91">State Issued:</TD>
																	<TD><%=txIssue%><FONT face="宋体"></FONT></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="397" border="0">
																<TR>
																	<TD width="116">Home&nbsp;Address:</TD>
																	<TD colSpan="3"><%=txResident%></TD>
																</TR>
																<TR>
																	<TD>Street&nbsp;:</TD>
																	<TD colSpan="3"><%=txStreet%></TD>
																</TR>
																<TR>
																	<TD>Suburb:</TD>
																	<TD width="80"><%=txCity%></TD>
																	<TD width="104" colSpan="2">&nbsp;&nbsp; State:&nbsp;
																		<%=selState%>
																	</TD>
																</TR>
																<TR>
																	<TD>Postcode:</TD>
																	<TD colSpan="3"><%=txPost%></TD>
																</TR>
																<TR>
																	<TD colSpan="4">&nbsp;
																	</TD>
																</TR>
																<TR>
																	<TD width="198" colSpan="2">Time at this address:</TD>
																	<TD><%=txYearM%>Years
																		<%=txMonthM%>
																		Months
																	</TD>
																</TR>
																<TR>
																	<TD width="198" colSpan="2">Home Phone Number:</TD>
																	<TD colSpan="2"><%=txTel%></TD>
																</TR>
																<TR>
																	<TD width="198" colSpan="2">Mobile:</TD>
																	<TD colSpan="2"><%=txMobile%></TD>
																</TR>
																<TR>
																	<TD width="198" colSpan="2">Fax:</TD>
																	<TD colSpan="2"><%=txFax%></TD>
																</TR>
																<TR>
																	<TD colSpan="2">&nbsp;</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="TableEmp" cellSpacing="0" cellPadding="0" width="397" border="0">
													<TR>
														<TD colSpan="4"><STRONG>Employment 
																Information&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<A href="employmentedit.aspx?Type=1">Edit</A></STRONG></TD>
													</TR>
													<TR>
														<TD colSpan="4"><%=tip1%></TD>
													</TR>
													<TR>
														<TD width="155"><%=tip2%></TD>
														<TD width="242" colSpan="3"><%=txEmployer%></TD>
													</TR>
													<TR>
														<TD><%=tip3%></TD>
														<TD colSpan="3"><%=txAddress%></TD>
													</TR>
													<TR>
														<TD><%=tip4%></TD>
														<TD colSpan="3"><%=txPhone%></TD>
													</TR>
													<TR>
														<TD><%=tip5%></TD>
														<TD colSpan="3"><%=txYear%>Years&nbsp;
															<%=txMonth%>
															Months</TD>
													</TR>
													<TR>
														<TD><%=tip6%></TD>
														<TD colSpan="3"><%=txIncome%>(Take home pay after taxes)</TD>
													</TR>
													<TR>
														<TD>Per:
														</TD>
														<TD colSpan="3"><%=paid%></TD>
													</TR>
													<TR>
														<TD>Next payday:</TD>
														<TD colSpan="3"><%=txMm1%>/<%=txDd1%>
															/<%=txYy1%>
														</TD>
													</TR>
													<TR>
														<TD>&nbsp;</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD>
												<TABLE id="Table11" cellSpacing="0" cellPadding="0" width="397" border="0">
													<TR>
														<TD colSpan="2"><STRONG>Bank details</STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
														</TD>
													</TR>
													<TR>
														<TD width="124">Bank Name:
															<%=BankName%>
														</TD>
														<TD>Branch:
															<%=Branch%>
														</TD>
													</TR>
													<TR>
														<TD colSpan="2">Account Name:
															<%=AName%>
														</TD>
													</TR>
													<TR>
														<TD width="124">BSB:
															<%=Bsb%>
														</TD>
														<TD>Account Number:
															<%=ANumber%>
														</TD>
													</TR>
													<TR>
														<TD colSpan="2">Preferred methods:<%=MContact%></TD>
													</TR>
													<TR>
														<TD colSpan="2">
															<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
																<TR>
																	<TD width="132"><STRONG>Referees</STRONG></TD>
																	<TD width="132">&nbsp;</TD>
																	<TD width="133">&nbsp;</TD>
																</TR>
																<TR>
																	<TD>Name</TD>
																	<TD>Relationship</TD>
																	<TD>Contact Number</TD>
																</TR>
																<TR>
																	<TD><%=Rname1%></TD>
																	<TD><%=Rship1%></TD>
																	<TD><%=Rnum1%></TD>
																</TR>
																<TR>
																	<TD><%=Rname2%></TD>
																	<TD><%=Rship2%></TD>
																	<TD><%=Rnum2%></TD>
																</TR>
																<TR>
																	<TD><%=Rname3%><FONT face="宋体"></FONT></TD>
																	<TD><%=Rship3%><FONT face="宋体"></FONT></TD>
																	<TD><%=Rnum3%></TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD align="center" colSpan="2">
															<asp:LinkButton id="LinkButton2" runat="server">Save</asp:LinkButton></TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
									</TABLE>
								</asp:panel></td>
						</tr>
						<tr>
							<td><asp:panel id="Panel3" runat="server" Visible="False" Width="472px" Height="620px">
									<TABLE cellSpacing="0" cellPadding="0" width="500" border="0">
										<TR>
											<TD width="137">Name:
											</TD>
											<TD width="363"><%=huiName%><FONT face="宋体"></FONT></TD>
										</TR>
										<TR>
											<TD>Customer Number:
											</TD>
											<TD><%=CustomerNum%><FONT face="宋体"></FONT></TD>
										</TR>
										<TR>
											<TD>When are you paid:
											</TD>
											<TD>
												<asp:radiobuttonlist id="RadioButtonList1" runat="server" Width="224px" RepeatDirection="Horizontal">
													<asp:ListItem Value="Weekly" Selected="True">Weekly</asp:ListItem>
													<asp:ListItem Value="F'nightly">F'nightly</asp:ListItem>
													<asp:ListItem Value="Monthly">Monthly &lt;FONT face=&quot;宋体&quot; color=&quot;#990000&quot;&gt;*&lt;/FONT&gt;</asp:ListItem>
												</asp:radiobuttonlist></TD>
										</TR>
										<TR>
											<TD>Next Payday:</TD>
											<TD><FONT face="宋体">DD <INPUT id="nPayDd" size="4" name="textfield292436" runat="server">
													MM <INPUT id="nPayMm" size="4" name="textfield2924324" runat="server"> YYYY <INPUT id="nPayYy" size="4" name="textfield2924334" runat="server"><FONT face="宋体" color="#990000">*</FONT></FONT></TD>
										</TR>
										<TR>
											<TD colSpan="2">&nbsp;</TD>
										</TR>
										<TR>
											<TD colSpan="2"><STRONG>Loan Information </STRONG>
											</TD>
										</TR>
										<TR>
											<TD>Purpose of the loan:</TD>
											<TD>
												<asp:TextBox id="txtLoanPurpose" runat="server" Height="22px" Width="268px"></asp:TextBox><FONT face="ËÎÌå" color="#990000">*</FONT></TD>
										</TR>
										<TR>
											<TD>Loan Requested:</TD>
											<TD><FONT face="宋体" color="#990000">$</FONT><INPUT id="txLoan" style="WIDTH: 166px; HEIGHT: 22px" size="11" name="Text1" runat="server"><FONT face="宋体" color="#990000">*<INPUT id="Hidden1" style="WIDTH: 11px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
														runat="server"><INPUT id="Hidden2" style="WIDTH: 11px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
														runat="server"></FONT></TD>
										</TR>
										<TR>
											<TD colSpan="3">&nbsp;</TD>
										</TR>
										<TR>
											<TD colSpan="3"><STRONG>Financial Obligations</STRONG></TD>
										</TR>
										<TR>
											<TD colSpan="3">
												<UL>
													<LI>
														Are you in default in payment under other <A class="title" title="small amount credit contract: a credit contract is a small amount&#13;&#10;credit contract if:|(a) the contract is not a continuing credit contract; and |(b) the credit provider under the contract is not an ADI; and |(c) the credit limit of the contract is $2,000 (or such other&#13;&#10;amount as is prescribed by the regulations) or less; and |(d) the term of the contract is at least 16 days but not longer than&#13;&#10;1 year (or such other number of years as is prescribed by the regulations); and |(e) the debtor’s obligations under the contract are not, and will&#13;&#10;not be, secured; and |(f) the contract meets any other requirements prescribed by the regulations."
															href="#">Small Amount Credit Contract </A>?
													</LI>
												</UL>
												<asp:RadioButtonList id="rblHasOtherSamllCredit" runat="server" RepeatDirection="Horizontal">
													<asp:ListItem Value="1">Yes</asp:ListItem>
													<asp:ListItem Value="0">No</asp:ListItem>
												</asp:RadioButtonList></TD>
										</TR>
										<TR>
											<TD colSpan="4">&nbsp;</TD>
										</TR>
										<TR>
											<TD colSpan="4">
												<UL>
													<LI>
														How many other small amount credit contracts have you had in the last 90 days?
													</LI>
												</UL>
												<asp:DropDownList id="ddlSmalCreditCount" runat="server">
													<asp:ListItem Value="0">nil</asp:ListItem>
													<asp:ListItem Value="1">1</asp:ListItem>
													<asp:ListItem Value="2">2</asp:ListItem>
													<asp:ListItem Value="3">3</asp:ListItem>
													<asp:ListItem Value="99">More than 3</asp:ListItem>
												</asp:DropDownList></TD>
										</TR>
										<TR>
											<TD colSpan="3">&nbsp;</TD>
										</TR>
										<TR>
											<TD colSpan="3">
												<UL>
													<LI>
														Are you expecting any changes of your gross income in your next three pay 
														cycles?
													</LI>
												</UL>
												<asp:RadioButtonList id="rblIsGrossIncomeChange" runat="server" RepeatDirection="Horizontal">
													<asp:ListItem Value="1">Yes</asp:ListItem>
													<asp:ListItem Value="0">No</asp:ListItem>
												</asp:RadioButtonList></TD>
										</TR>
										<TR>
											<TD colSpan="2">If the answer is “yes”, how much are you expecting to get paid in 
												each pay cycle?</TD>
											<TD>
												<asp:TextBox id="tbxGrossIncomeChangeValue" runat="server"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD colSpan="3">&nbsp;</TD>
										</TR>
										<TR>
											<TD colSpan="3">
												<UL>
													<LI>
														Are you expecting to pay any other credit providers other thanbanks in your 
														next three pay cycle?
													</LI>
												</UL>
												<asp:RadioButtonList id="rblIsPayOtherCredit" runat="server" RepeatDirection="Horizontal">
													<asp:ListItem Value="1">Yes</asp:ListItem>
													<asp:ListItem Value="0">No</asp:ListItem>
												</asp:RadioButtonList></TD>
										</TR>
										<TR>
											<TD colSpan="2">If the answer is “yes”,how much are you expecting to pay in each 
												pay cycle?</TD>
											<TD>
												<asp:TextBox id="tbxPayOtherCreditValue" runat="server"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD colSpan="3">&nbsp;</TD>
										</TR>
										<TR>
											<TD colSpan="3"><STRONG>Expenses Information </STRONG>
											</TD>
										</TR>
										<TR>
											<TD>Your rent/mortgage payment:</TD>
											<TD colSpan="3">$<INPUT id="txtHousePaymentValue" size="12" name="txtHousePaymentValue" runat="server">
												<uc1:CircleDropDownList id="ddlHousePaymentCircle" runat="server"></uc1:CircleDropDownList><FONT face="ËÎÌå" color="#990000">*</FONT></TD>
										</TR>
										<TR>
											<TD>Your regular repayment to other lenders:</TD>
											<TD colSpan="3">$<INPUT id="txtOtherLenderValue" size="12" name="txtOtherLenderValue" runat="server">
												<uc1:CircleDropDownList id="ddlOtherLenderCircle" runat="server"></uc1:CircleDropDownList><FONT face="ËÎÌå" color="#990000">*</FONT></TD>
										</TR>
										<TR>
											<TD>
												<asp:button id="Button1" runat="server" Text="Next"></asp:button><INPUT id="txInstallment" style="WIDTH: 16px; HEIGHT: 22px" size="1" name="Text2" runat="server"
													visible="false"></TD>
										</TR>
									</TABLE>
								</asp:panel><asp:panel id="Panel4" runat="server" Visible="False" Width="472px" Height="620px">
									<TABLE>
										<TR height="5">
											<TD colSpan="2"><STRONG>Financial Table :</STRONG></TD>
										</TR>
										<TR>
											<TD colSpan="2">
												<TABLE borderColor="#d4d0c8" cellSpacing="0" cellPadding="0" width="95%" border="1">
													<TR>
														<TD width="35%">Amount of credit</TD>
														<TD>$
															<asp:Literal id="litAmountOfCredit" Runat="server"></asp:Literal></TD>
													</TR>
													<TR>
														<TD>Charge for credit</TD>
														<TD>$
															<asp:Literal id="litChargeForCredit" Runat="server"></asp:Literal></TD>
													</TR>
													<TR>
														<TD>Total payable</TD>
														<TD>$
															<asp:Literal id="litTotalPayable" Runat="server"></asp:Literal></TD>
													</TR>
													<TR>
														<TD>Repayment in days</TD>
														<TD>
															<asp:Literal id="litRepaymentInDays" Text="day(s)" Runat="server"></asp:Literal></TD>
													</TR>
													<TR>
														<TD>Establishment fee
														</TD>
														<TD>20%</TD>
													</TR>
													<TR>
														<TD>Monthly fee
														</TD>
														<TD>4%</TD>
													</TR>
													<TR>
														<TD>Annual Percentage Rate</TD>
														<TD>
															<asp:Literal id="litAnnualPercentageRate" Text="%" Runat="server"></asp:Literal></TD>
													</TR>
													<TR>
														<TD>Repayment Schedule</TD>
														<TD>
															<TABLE>
																<TR>
																	<TD width="120">&nbsp;</TD>
																	<TD width="130">Date due
																	</TD>
																	<TD width="120">Repayment due</TD>
																</TR>
																<%
									if(payDates4Schedule!=null)
									for( int i=0;i<payDates4Schedule.Length;i++ ){
									%>
																<TR>
																	<TD>Installment
																		<%= i+1 %>
																	</TD>
																	<TD><FONT face="宋体"><%=payDates4Schedule[i].ToString("dd/MM/yyyy")%></FONT></TD>
																	<TD><FONT face="宋体"><%=payAmountPerTime4Schedule.ToString("0.00")%></FONT></TD>
																</TR>
																<%}%>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD width="35%">Charges may become payable</TD>
														<TD>Payment Dishonour Fee: $25 for each payment dishonoured.
															<BR>
															Late Fee: $50 for any installment is not paid in full within 5 days following 
															its scheduled due date.<BR>
															Collection Fee: 50% of outstanding debt.<BR>
														</TD>
													</TR>
												</TABLE>
											</TD>
										</TR>
										<TR>
											<TD colSpan="2">&nbsp;</TD>
										</TR>
										<TR>
											<TD colSpan="2">
												<DIV id="divAgreement" style="BORDER-RIGHT: black 1px solid; BORDER-TOP: black 1px solid; OVERFLOW: auto; BORDER-LEFT: black 1px solid; BORDER-BOTTOM: black 1px solid; HEIGHT: 150px">&nbsp;&nbsp;By 
													typing my name below, I am applying for a new online cash loan and certify that 
													this information is true and correct under penalty of perjury. I authorize 
													Golden Bridge Cash Solution to verify the information I have provided, and to 
													be bound by the terms of the Master Loan Agreement that I signed with my 
													initial loan application. I agree that the payment schedule set above is not in 
													dispute and that I have full capacity to consent to the payment of such amount.
													<BR>
													&nbsp;&nbsp;In the event of default, I agree to pay all applicable penalties 
													including a $25.00 Returned Item Fee, and if the balance is not paid within 5 
													days following its scheduled Due Date, to pay an additional $50 Late Fee.
													<BR>
													&nbsp;&nbsp;I understand that a Debt Collection Fee calculated to be 50% of the 
													total amount owing will be added to my outstanding amount if my account is 
													passed on to a professional Debt Collection Agency. I understand that if I let 
													any of my payments 'bounce', I authorize Golden Bridge Cash Solution to access 
													my account until all loans, fees and penalties are recovered.</DIV>
											</TD>
										</TR>
										<TR>
											<TD colSpan="2">
												<asp:CheckBox id="cbUnderStoodTerm" Text="You must have read and understood Golden Bridge Cash Solution's <a href='../information2.htm' target='_blank'>&#13;&#10;&#9;&#9;&#9;&#9;&#9;&#9;&#9;&#9;&#9;Information Statement</a>,<a href='../Information/Form3A.doc'>Form 3A</a>! "
													Runat="server"></asp:CheckBox></TD>
										</TR>
										<TR>
											<TD colSpan="2">To Sign,please type your FULL name here:
												<asp:TextBox id="txFullname" runat="server" Width="192px"></asp:TextBox></TD>
										</TR>
										<TR>
											<TD align="center" colSpan="2"><INPUT id="Button2" type="button" value="I agree, Submit" name="Button2" runat="server"><FONT face="宋体">&nbsp;&nbsp; 
													&nbsp; </FONT><INPUT type="reset" value="Reset"></TD>
										</TR>
									</TABLE>
								</asp:panel></td>
						</tr>
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
				$("#menuItemNewCashLoan").addClass("actived");
			});
		</script>
		<script type="text/javascript">
			$(document).ready(function(){
				$('a.title').cluetip({splitTitle: '|', arrows: true});
			});
		</script>
		<!--end footer-->
	</body>
</HTML>
