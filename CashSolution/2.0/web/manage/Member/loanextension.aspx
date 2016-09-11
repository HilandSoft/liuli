<%@ Page language="c#" Codebehind="loanextension.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.loanextension" %>
<%@ Register TagPrefix="uc1" TagName="top5" Src="top5.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top1" Src="top1.ascx" %>
<%@ Register TagPrefix="uc1" TagName="leftmenu" Src="leftmenu.ascx" %>
<HTML>
	<HEAD>
		<title>loanextension</title> 
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table width="750" border="0" align="center" cellpadding="0" cellspacing="0" height="100%">
				<tr>
					<td colspan="2" style="HEIGHT: 27px"><FONT face="宋体">
							<uc1:top5 id="Top51" runat="server"></uc1:top5></FONT>
					</td>
				</tr>
				<tr>
					<td valign="top" width="195" align="left" bgcolor="#e8e6df">
						<uc1:leftmenu id="Leftmenu1" runat="server"></uc1:leftmenu>
					</td>
					<td width="556" align="center" valign="top">
						<table cellSpacing="0" cellPadding="0" width="500" border="0">
							<tr>
								<td colSpan="2">
									<p><strong>Your loan extension application must be sent to us no later than two 
											business days before your next due payment date. <INPUT id="Hidden2" style="WIDTH: 40px; HEIGHT: 21px" type="hidden" size="1" name="Hidden1"
												runat="server"> </strong>
									</p>
								</td>
							</tr>
							<tr>
								<td width="130">Name:
								</td>
								<td width="370"><%=Name%></td>
							</tr>
							<tr>
								<td>Customer Number:
								</td>
								<td><%=CustomerNum%></td>
							</tr>
							<tr>
								<td>Original Loan Amount:
								</td>
								<td>
									<%=LoanAmount%>
								</td>
							</tr>
							<tr>
								<td colSpan="2">
									<table cellSpacing="0" cellPadding="0" width="500" border="0">
										<tr>
											<td colSpan="5"><strong>Current Payment Schedule:</strong>
											</td>
										</tr>
										<tr>
											<td width="20%">Installment
											</td>
											<td width="25%">Due date
											</td>
											<td width="20%">Payment due
											</td>
											<td width="10%">&nbsp;</td>
											<td width="25%"></td>
										</tr>
										<%=Content1%>
										<tr>
											<td align="right" colSpan="5"><FONT face="宋体">
													<asp:Button id="Button2" runat="server" Text="Calculate"></asp:Button>
													<INPUT id="Hidden1" style="WIDTH: 35px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
														runat="server"> &nbsp;&nbsp;</FONT>&nbsp;&nbsp; <FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
												</FONT>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colSpan="2">
									<table cellSpacing="0" cellPadding="0" width="500" border="0">
										<tr>
											<td colspan="3"><strong>New Payment Schedule</strong></td>
										</tr>
										<tr>
											<td style="HEIGHT: 20px">Installment
											</td>
											<td style="HEIGHT: 20px">Due date
											</td>
											<td style="HEIGHT: 20px">Payment due
											</td>
										</tr>
										<tr>
											<td>Extension Fee
											</td>
											<td><asp:TextBox id="txDuedate" runat="server" Width="72px" BorderStyle="None" BorderWidth="0px"
													ReadOnly="True"></asp:TextBox></td>
											<td>
												<asp:TextBox id="txYanQi" runat="server" Width="72px" BorderStyle="None" BorderWidth="0px" ReadOnly="True"></asp:TextBox></td>
										</tr>
										<!--
										<tr>
											<td colspan="3">
												New Payment Schedule:
											</td>
										</tr>
										-->
										<tr>
											<td style="HEIGHT: 20px">Installment1
											</td>
											<td style="HEIGHT: 20px">
												<asp:TextBox id="txd1" runat="server" Width="72px" BorderStyle="None" BorderWidth="0px" ReadOnly="True"></asp:TextBox>
											</td>
											<td style="HEIGHT: 20px">
												<asp:TextBox id="txs1" runat="server" Width="72px" BorderStyle="None" BorderWidth="0px" ReadOnly="True"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td style="HEIGHT: 20px">Installment2
											</td>
											<td style="HEIGHT: 20px">
												<asp:TextBox id="txd2" runat="server" Width="72px" BorderStyle="None" BorderWidth="0px" ReadOnly="True"></asp:TextBox>
											</td>
											<td style="HEIGHT: 20px">
												<asp:TextBox id="txs2" runat="server" Width="72px" BorderStyle="None" BorderWidth="0px" ReadOnly="True"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td style="HEIGHT: 20px">Installment3
											</td>
											<td style="HEIGHT: 20px">
												<asp:TextBox id="txd3" runat="server" Width="72px" BorderStyle="None" BorderWidth="0px" ReadOnly="True"></asp:TextBox>
											</td>
											<td style="HEIGHT: 20px">
												<asp:TextBox id="txs3" runat="server" Width="72px" BorderStyle="None" BorderWidth="0px" ReadOnly="True"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td colSpan="3">
												<%=Content2%>
												<FONT face="宋体"></FONT>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colspan="2">
									Note: Your loan extension fee due on your original installment due date.
									<br>
									<TEXTAREA style="WIDTH: 504px; HEIGHT: 192px" rows="12" cols="60">By typing my name below, I am applying for an extension of my current electronic cash loan and certify that this information is true and correct under penalty of perjury. I authorize Golden Bridge Cash Solution to verify the information I have provided, and to be bound by the terms of the Master Cash Loan Agreement that I signed with my original loan application. I agree that the payment schedule set above is not in dispute and that I have full capacity to consent to the payment of such amount.
In the event of default, I agree to pay all applicable penalties including a $25.00 Returned Item Fee, and if the balance is not paid within 5 days following its scheduled Due Date, to pay an additional $50 Late Fee. I also agree to pay a default interest of 24% per annum of the outstanding debt after 62 days following its scheduled Due Date. I understand that a Debt Collection Fee calculated to be 25% of the total amount owing will be added to my outstanding amount if my account is passed on to professional Debt Collection Agency.
I understand that if I let any of my payments "bounce", I authorize Golden Bridge Cash Solution to access my account until all loans, fees and penalties are recovered.</TEXTAREA>
								</td>
							</tr>
							<tr>
								<td colspan="2">To Sign,please type your FULL name here:
									<asp:TextBox id="txFullname" runat="server" Width="192px"></asp:TextBox></td>
							</tr>
							<tr>
								<td colSpan="2">
									<div align="center"><br>
										<asp:button id="Button1" runat="server" Text="I agree, Submit"></asp:button>
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
