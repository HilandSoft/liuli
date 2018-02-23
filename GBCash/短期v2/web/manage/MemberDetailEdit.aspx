<%@ Register TagPrefix="uc1" TagName="CircleDropDownList" Src="../Include/CircleDropDownList.ascx" %>
<%@ Page language="c#" Codebehind="MemberDetailEdit.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.MemberDetailEdit" %>
<%@ Register TagPrefix="uc1" TagName="RepaymentCycleTypeSelector" Src="../UControls/RepaymentCycleTypeSelector.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MemberDetailEdit</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="csslib/yingnet.css">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="70%" bgColor="#fefefe" align="center"
				height="100%">
				<tr>
					<td colSpan="4"><STRONG>Customer Details For Edit: </STRONG>
					</td>
				</tr>
				<tr>
					<td height="28" vAlign="top" width="21%">Title:</td>
					<td vAlign="top" colSpan="3"><asp:textbox id="txtTitle" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td height="28" vAlign="top" width="21%">First Name:</td>
					<td vAlign="top" width="26%"><asp:textbox id="txtFname" runat="server"></asp:textbox></td>
					<td vAlign="top" width="20%">Middle Name:</td>
					<td vAlign="top" width="33%"><asp:textbox id="txtMname" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td vAlign="top">Last Name:</td>
					<td vAlign="top"><asp:textbox id="txtLname" runat="server"></asp:textbox></td>
					<td vAlign="top">&nbsp;
					</td>
					<td vAlign="top">&nbsp;
					</td>
				</tr>
				<tr>
					<td vAlign="top">Date of Birth:</td>
					<td vAlign="top"><asp:textbox id="txtDate" runat="server"></asp:textbox></td>
					<td vAlign="top">E-Mail:
					</td>
					<td vAlign="top"><asp:textbox id="txtEmail" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td vAlign="top">Driver Licence Number:</td>
					<td vAlign="top">
						<%=txDriver%>
						<asp:textbox id="txtDriver" runat="server"></asp:textbox></td>
					<td vAlign="top">State Issued:</td>
					<td vAlign="top">
						<%=txIssue%>
						<asp:textbox id="txtIssue" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td vAlign="top">Home Address:</td>
					<td vAlign="top" colSpan="3">
						<%=txResident%>
						<asp:textbox id="txtResident" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td vAlign="top">Street:</td>
					<td vAlign="top" colSpan="3">
						<%=txStreet%>
						<asp:textbox id="txtStreet" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td vAlign="top">City:</td>
					<td vAlign="top">
						<%=txCity%>
						<asp:textbox id="txtCity" runat="server"></asp:textbox></td>
					<td vAlign="top">State:</td>
					<td vAlign="top">
						<%=selState%>
						<asp:dropdownlist id="ddlState" runat="server"></asp:dropdownlist></td>
				</tr>
				<tr>
					<td vAlign="top">Postcode:</td>
					<td vAlign="top" colSpan="3">
						<%=txPost%>
						<asp:textbox id="txtPost" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td style="HEIGHT: 21px">Time at this address:</td>
					<td style="HEIGHT: 21px" colSpan="3"><%=txYeard%>
						<asp:textbox id="txtYeard" runat="server" Width="32px"></asp:textbox>Years
						<%=txMonthd%>
						<asp:textbox id="txtMonthd" runat="server" Width="32px"></asp:textbox>Months
					</td>
				</tr>
				<tr>
					<td vAlign="top">Home Phone Number:</td>
					<td vAlign="top" colSpan="3">
						<%=txTel%>
						<asp:textbox id="txtTel" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td vAlign="top">Mobile:</td>
					<td vAlign="top" colSpan="3"><%=txMobile%>
						<asp:textbox id="txtMobile" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td vAlign="top">Fax:</td>
					<td vAlign="top" colSpan="3"><%=txFax%>
						<INPUT style="WIDTH: 8px; HEIGHT: 19px" id="Hidden1" size="1" type="hidden" name="Hidden1"
							runat="server">
						<asp:textbox id="txtFax" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td colSpan="4"><strong>Employment Information</strong></td>
				</tr>
				<tr>
					<td><%=tip2%></td>
					<td><%=txEmployer%>
						<asp:textbox id="txtEmployer" runat="server"></asp:textbox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td><%=tip3%></td>
					<td><%=txAddress%>
						<asp:textbox id="txtAddress" runat="server"></asp:textbox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td><%=tip4%></td>
					<td><%=txPhone%>
						<asp:textbox id="txtPhone" runat="server"></asp:textbox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td><%=tip5%></td>
					<td colSpan="3"><%=txYear%><asp:textbox id="txtYear" runat="server" Width="32px"></asp:textbox>Years&nbsp;
						<%=txMonth%>
						<asp:textbox id="txtMonth" runat="server" Width="32px"></asp:textbox>Months</td>
				</tr>
				<tr>
					<td><%=tip6%></td>
					<td colSpan="3"><asp:textbox id="txtIncome" runat="server"></asp:textbox>(Take home 
						pay after taxes)</td>
				</tr>
				<tr>
					<td><%=tip7%></td>
					<td colSpan="3"><asp:textbox id="txtJob" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td>When are you paid:
					</td>
					<td><cc1:perradiobuttonlist id="PerRadioButtonList1" runat="server" RepeatDirection="Horizontal"></cc1:perradiobuttonlist></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>Next payday:</td>
					<td><%=txDd1%><asp:textbox id="txtDd1" runat="server" Width="24px"></asp:textbox>/<%=txMm1%><asp:textbox id="txtMm1" runat="server" Width="23px"></asp:textbox>/<%=txYy1%><asp:textbox id="txtYy1" runat="server" Width="40px"></asp:textbox>(DD/MM/YYYY)
					</td>
					<td></td>
					<td></td>
				</tr>
				<TR>
					<TD>Purpose of the loan:</TD>
					<TD colSpan="3"><asp:textbox id="txtLoanPurpose" runat="server" Width="168px" Height="45px"></asp:textbox></TD>
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
				<TR>
					<TD>Any default under other SACC</TD>
					<TD colSpan="3"><asp:radiobuttonlist id="rblHasOtherSamllCredit" runat="server" RepeatDirection="Horizontal">
							<asp:ListItem Value="1" Selected="True">Yes</asp:ListItem>
							<asp:ListItem Value="0">No</asp:ListItem>
						</asp:radiobuttonlist></TD>
				</TR>
				<TR>
					<TD>How many SACC in the last 90 days</TD>
					<TD colSpan="3"><asp:dropdownlist id="ddlSmalCreditCount" runat="server">
							<asp:ListItem Value="0">nil</asp:ListItem>
							<asp:ListItem Value="1">1</asp:ListItem>
							<asp:ListItem Value="2">2</asp:ListItem>
							<asp:ListItem Value="3">3</asp:ListItem>
							<asp:ListItem Value="99">More than 3</asp:ListItem>
						</asp:dropdownlist></TD>
				</TR>
				<tr>
					<td>Does gross income change:</td>
					<td>
						<asp:RadioButtonList id="rblIsGrossIncomeChange" runat="server" RepeatDirection="Horizontal">
							<asp:ListItem Value="1">Yes</asp:ListItem>
							<asp:ListItem Value="0">No</asp:ListItem>
						</asp:RadioButtonList>
					</td>
					<td>Gross income value</td>
					<td><asp:TextBox id="tbxGrossIncomeChangeValue" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td>Does Pay Other Credit:</td>
					<td><asp:RadioButtonList id="rblIsPayOtherCredit" runat="server" RepeatDirection="Horizontal">
							<asp:ListItem Value="1">Yes</asp:ListItem>
							<asp:ListItem Value="0">No</asp:ListItem>
						</asp:RadioButtonList></td>
					<td>Pay Other Credit Value</td>
					<td><asp:TextBox id="tbxPayOtherCreditValue" runat="server"></asp:TextBox></td>
				</tr>
				<tr>
					<td colSpan="4">&nbsp;</td>
				</tr>
				<tr>
					<td><STRONG>Bank details</STRONG>&nbsp;&nbsp;&nbsp;&nbsp;</td>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>Bank Name:</td>
					<td><%=BankName%>
						<asp:textbox id="txtBankName" runat="server"></asp:textbox></td>
					<td>Branch:</td>
					<td><%=Branch%>
						<asp:textbox id="txtBranch" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td>Account Name:</td>
					<td><%=AName%>
						<asp:textbox id="txtAName" runat="server"></asp:textbox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>BSB:</td>
					<td><%=Bsb%>
						<asp:textbox id="txtBsb" runat="server"></asp:textbox></td>
					<td>Account Number:</td>
					<td><%=ANumber%>
						<asp:textbox id="txtANumber" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td>Preferred methods:</td>
					<td><%=MContact%>
						<asp:textbox id="txtMContact" runat="server"></asp:textbox></td>
				</tr>
				<tr>
					<td colSpan="4">
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td><STRONG>Referees</STRONG></td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>Name</td>
								<td>Relationship</td>
								<td>Contact Number</td>
							</tr>
							<tr>
								<td><%=Rname1%>
									<asp:textbox id="txtRname1" runat="server"></asp:textbox></td>
								<td><%=Rship1%>
									<asp:textbox id="txtRship1" runat="server"></asp:textbox></td>
								<td><%=Rnum1%>
									<asp:textbox id="txtRnum1" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td><%=Rname2%>
									<asp:textbox id="txtRname2" runat="server"></asp:textbox></td>
								<td><%=Rship2%>
									<asp:textbox id="txtRship2" runat="server"></asp:textbox></td>
								<td><%=Rnum2%>
									<asp:textbox id="txtRnum2" runat="server"></asp:textbox></td>
							</tr>
							<tr>
								<td><%=Rname3%>
									<asp:textbox id="txtRname3" runat="server"></asp:textbox></td>
								<td><%=Rship3%>
									<asp:textbox id="txtRship3" runat="server"></asp:textbox></td>
								<td><%=Rnum3%>
									<asp:textbox id="txtRnum3" runat="server"></asp:textbox></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colSpan="4">
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="100%">
							<TR>
								<TD colSpan="3"><STRONG>Loan Requirements</STRONG><BR>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px" width="143">Loan Requested:</TD>
								<TD colSpan="2">$<INPUT style="WIDTH: 166px; HEIGHT: 22px" id="txtLoan" name="Text1" runat="server"><FONT color="#990000" face="ËÎÌו">*
										<asp:button id="btnCalculate" runat="server" Text="Calculate"></asp:button>(if 
										change schedule,pls must Calculate first)</FONT>
								</TD>
							</TR>
							<TR>
								<TD colSpan="3">Note: Each installment dues on your payday . Please make sure your 
									repayment funds are available in your account for deduction on each installment 
									due date.</TD>
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
							<%
									if(payDates4Schedule!=null)
									for( int i=0;i<payDates4Schedule.Length;i++ ){
									%>
							<TR>
								<TD>Installment
									<%= i+1 %>
								</TD>
								<TD><FONT face="ËÎÌו"><%=payDates4Schedule[i].ToString("dd/MM/yyyy")%></FONT></TD>
								<TD><FONT face="ËÎÌו"><%=payAmountPerTime4Schedule.ToString("0.00")%></FONT></TD>
							</TR>
							<%}%>
							<TR>
								<TD style="WIDTH: 143px" align="center">&nbsp;</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td vAlign="top" colSpan="4">
						<div align="center"><input id="SaveButton" type="submit" value="Save" name="Submit" runat="server">&nbsp;&nbsp;
							<A href="MemberList.aspx">Return</A>
						</div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
