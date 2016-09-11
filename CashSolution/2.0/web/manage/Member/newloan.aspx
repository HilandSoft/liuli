<%@ Register TagPrefix="uc1" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top1" Src="top1.ascx" %>
<%@ Page language="c#" Codebehind="newloan.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.newloan" %>
<%@ Register TagPrefix="uc1" TagName="top4" Src="top4.ascx" %>
<HTML>
	<HEAD>
		<title>newloan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../jslib/commCheck.js" type="text/javascript"></script>
		<script language="javascript">
		function CheckLoan() {	
		var fnPayMm=document.getElementById("nPayMm");			
		var fnPayDd=document.getElementById("nPayDd");		
		var fnPayYy=document.getElementById("nPayYy");	
		var ftxLoan=document.getElementById("txLoan");	
		var ftxInstallment=document.getElementById("txInstallment");
		
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
	</HEAD>
	<body leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="750" align="center" border="0">
				<tr>
					<td style="HEIGHT: 27px" colSpan="2"><FONT face="宋体"><uc1:top4 id="Top41" runat="server"></uc1:top4></FONT></td>
				</tr>
				<tr>
					<td vAlign="top" align="left" width="195" bgColor="#e8e6df"><uc1:leftmenu id="Leftmenu1" runat="server"></uc1:leftmenu></td>
					<td vAlign="top" align="center" width="556">
						<table cellSpacing="1" cellPadding="1" width="510" border="0">
							<tr>
								<td vAlign="top"><asp:panel id="Panel2" runat="server" Height="120px" Width="472px">
										<TABLE cellSpacing="1" cellPadding="1" width="510" border="0">
											<TR>
												<TD><FONT face="宋体"></FONT><BR>
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
														need to contact us on 1300 138 916 or Email to <A href="mailto:apply@cashsolution.com.au">
													apply@cashsolution.com.au </A> to obtain a Change of Account Details Form.</P>
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
								<td><asp:panel id="Panel1" runat="server" Width="500px" Visible="False">
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
															<TD style="HEIGHT: 39px"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><BR>
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
																		<TD style="WIDTH: 133px" width="133">First Name:</TD>
																		<TD style="WIDTH: 118px" width="118"><%=txFname%></TD>
																		<TD style="WIDTH: 91px" width="91">Middle Name:</TD>
																		<TD width="106"><%=txMname%></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 133px">Last Name:</TD>
																		<TD style="WIDTH: 118px"><%=txLname%></TD>
																		<TD style="WIDTH: 91px">&nbsp;</TD>
																		<TD>&nbsp;</TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 133px">Date of Birth:</TD>
																		<TD style="WIDTH: 118px"><%=txDate%><FONT face="宋体"></FONT></TD>
																		<TD style="WIDTH: 91px">E-Mail:
																		</TD>
																		<TD><%=txEmail%></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 133px">Driver Licence Number:</TD>
																		<TD style="WIDTH: 118px"><%=txDriver%></TD>
																		<TD style="WIDTH: 91px">State Issued:</TD>
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
																		<TD style="WIDTH: 80px" width="80"><%=txCity%></TD>
																		<TD style="WIDTH: 104px" width="104" colSpan="2">&nbsp;&nbsp; State:&nbsp;
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
																		<TD style="WIDTH: 198px" colSpan="2">Time at this address:</TD>
																		<TD><%=txYearM%>Years
																			<%=txMonthM%>
																			Months
																		</TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 198px" colSpan="2">Home Phone Number:</TD>
																		<TD colSpan="2"><%=txTel%></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 198px" colSpan="2">Mobile:</TD>
																		<TD colSpan="2"><%=txMobile%></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 198px" colSpan="2">Fax:</TD>
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
													<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="397" border="0">
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
															<TD style="WIDTH: 124px">Bank Name:
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
															<TD style="WIDTH: 124px">BSB:
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
								<td><asp:panel id="Panel3" runat="server" Height="620px" Width="472px" Visible="False">
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
												<TD><FONT face="宋体">DD <INPUT id="nPayDd" type="text" size="4" name="textfield292436" runat="server">
														MM <INPUT id="nPayMm" type="text" size="4" name="textfield2924324" runat="server">
														YYYY <INPUT id="nPayYy" type="text" size="4" name="textfield2924334" runat="server"><FONT face="宋体" color="#990000">*</FONT></FONT></TD>
											</TR>
											<TR>
												<TD>Loan Requested:</TD>
												<TD><FONT face="宋体" color="#990000">$</FONT><INPUT id="txLoan" style="WIDTH: 166px; HEIGHT: 22px" type="text" size="11" name="Text1"
														runat="server"><FONT face="宋体" color="#990000">*<INPUT id="Hidden1" style="WIDTH: 11px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
															runat="server"><INPUT id="Hidden2" style="WIDTH: 11px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
															runat="server"></FONT></TD>
											</TR>
											<TR>
												<TD>Loan Repayment:</TD>
												<TD>
													<asp:DropDownList id="DropDownList1" runat="server">
														<asp:ListItem Value="1">1 installment</asp:ListItem>
														<asp:ListItem Value="2">2 installments</asp:ListItem>
														<asp:ListItem Value="3">3 installments</asp:ListItem>
														<asp:ListItem Value="4">Repay on next payday</asp:ListItem>
													</asp:DropDownList><FONT face="宋体" color="#990000">*
														<asp:button id="Button1" runat="server" Text="Calculate"></asp:button><INPUT id="txInstallment" style="WIDTH: 16px; HEIGHT: 22px" type="text" size="1" name="Text2"
															runat="server" visible="false"></FONT></TD>
											</TR>
											<TR>
												<TD colSpan="2">
													<TABLE cellSpacing="0" cellPadding="0" width="500" border="0">
														<TR>
															<TD width="176" colSpan="3"><STRONG>Repayment Schedule</STRONG></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 176px">&nbsp;</TD>
															<TD>Date due
															</TD>
															<TD>Repayment due</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 176px">1st Installment
															</TD>
															<TD>
																<asp:TextBox id="txd1" runat="server" Width="72px" ReadOnly="True" BorderWidth="0px" BorderStyle="None"></asp:TextBox></TD>
															<TD><FONT face="宋体">
																	<asp:TextBox id="txs1" runat="server" Width="72px" ReadOnly="True" BorderWidth="0px" BorderStyle="None"></asp:TextBox></FONT></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 176px">2nd Installment
															</TD>
															<TD><FONT face="宋体">
																	<asp:TextBox id="txd2" runat="server" Width="72px" ReadOnly="True" BorderWidth="0px" BorderStyle="None"></asp:TextBox></FONT></TD>
															<TD><FONT face="宋体">
																	<asp:TextBox id="txs2" runat="server" Width="72px" ReadOnly="True" BorderWidth="0px" BorderStyle="None"></asp:TextBox></FONT></TD>
														</TR>
														<TR>
															<TD style="WIDTH: 176px; HEIGHT: 21px">3rd Installment
															</TD>
															<TD><FONT face="宋体">
																	<asp:TextBox id="txd3" runat="server" Width="72px" ReadOnly="True" BorderWidth="0px" BorderStyle="None"></asp:TextBox></FONT></TD>
															<TD><FONT face="宋体">
																	<asp:TextBox id="txs3" runat="server" Width="72px" ReadOnly="True" BorderWidth="0px" BorderStyle="None"></asp:TextBox></FONT></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD colSpan="2">&nbsp;</TD>
											</TR>
											<TR>
												<TD colSpan="2"><TEXTAREA style="WIDTH: 508px; HEIGHT: 184px" rows="11" cols="60">By typing my name below, I am applying for a new electronic cash loan and certify that this information is true and correct under penalty of perjury. I authorize Golden Bridge Cash Solution to verify the information I have provided, and to be bound by the terms of the Master Cash Loan Agreement that I signed with my original loan application. I agree that the payment schedule set above is not in dispute and that I have full capacity to consent to the payment of such amount.
In the event of default, I agree to pay all applicable penalties including a $25.00 Returned Item Fee, and if the balance is not paid within 5 days following its scheduled Due Date, to pay an additional $50 Late Fee. I also agree to pay a default interest of 24% per annum of the outstanding debt after 62 days following its scheduled Due Date. I understand that a Debt Collection Fee calculated to be 25% of the total amount owing will be added to my outstanding amount if my account is passed on to professional Debt Collection Agency.
I understand that if I let any of my payments "bounce", I authorize Golden Bridge Cash Solution to access my account until all loans, fees and penalties are recovered.
													</TEXTAREA></TD>
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
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
