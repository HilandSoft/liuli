<%@ Register TagPrefix="uc1" TagName="MemberLeft" Src="MemberLeft.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MemberTop" Src="MemberTop.ascx" %>
<%@ Page language="c#" Codebehind="loanextension.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.loanextension" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<script src="../javascriptN/jquery-1.4.4.min.js" type="text/javascript"></script>
		<LINK href="../CSSN/final.css" type="text/css" rel="stylesheet">
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
			<div id="content" style="MARGIN-LEFT: 0px">
				<form id="Form2" method="post" runat="server">
					<table cellSpacing="0" cellPadding="0" width="500" border="0">
						<tr>
							<td colSpan="2">
								<p><strong>Your loan extension application must be sent to us no later than two 
										business days before your next due payment date. <INPUT id="Hidden2" style="WIDTH: 40px; HEIGHT: 21px" type="hidden" size="1" name="Hidden1"
											runat="server"> <INPUT id="HiddenCalced" type="hidden" name="Hidden3" runat="server"></strong></p>
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
										<td width="20%">Due date
										</td>
										<td width="20%">Payment due
										</td>
										<td width="5%">&nbsp;</td>
										<td width="35%"></td>
									</tr>
									<%=Content1%>
									<tr>
										<td align="right" colSpan="5"><FONT face="����">
												<asp:Label id="LabWarning" runat="server" Visible="False" ForeColor="Red">Label</asp:Label><asp:button id="Button2" runat="server" Text="Calculate"></asp:button><INPUT id="Hidden1" style="WIDTH: 35px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
													runat="server"> &nbsp;&nbsp;</FONT>&nbsp;&nbsp; <FONT face="����">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
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
										<td colSpan="3"><strong>New Payment Schedule</strong></td>
									</tr>
									<tr>
										<td height="20">Installment
										</td>
										<td height="20">Due date
										</td>
										<td height="20">Payment due
										</td>
									</tr>
									<%=ContentNewSchedule%>
									<tr>
										<td colSpan="3">
											<%=Content2%>
										</td>
									</tr>
								</table>
							</td>
						</tr>
						<tr>
							<td colSpan="2">Note: Your loan extension fee due on your original installment due 
								date.
								<br>
								<TEXTAREA style="WIDTH: 504px; HEIGHT: 192px" rows="12" cols="60">By typing my name below, I am applying for an extension of my current electronic cash loan and certify that this information is true and correct under penalty of perjury. I authorize Golden Bridge Cash Solution to verify the information I have provided, and to be bound by the terms of the Master Cash Loan Agreement that I signed with my original loan application. I agree that the payment schedule set above is not in dispute and that I have full capacity to consent to the payment of such amount.
In the event of default, I agree to pay all applicable penalties including a $25.00 Returned Item Fee, and if the balance is not paid within 5 days following its scheduled Due Date, to pay an additional $50 Late Fee. I also agree to pay a default interest of 24% per annum of the outstanding debt after 62 days following its scheduled Due Date. I understand that a Debt Collection Fee calculated to be 25% of the total amount owing will be added to my outstanding amount if my account is passed on to professional Debt Collection Agency.
I understand that if I let any of my payments "bounce", I authorize Golden Bridge Cash Solution to access my account until all loans, fees and penalties are recovered.</TEXTAREA>
							</td>
						</tr>
						<tr>
							<td colSpan="2">To Sign,please type your FULL name here:
								<asp:textbox id="txFullname" runat="server" Width="192px"></asp:textbox></td>
						</tr>
						<tr>
							<td colSpan="2">
								<div align="center"><br>
									<asp:button id="Button1" runat="server" Text="I agree, Submit"></asp:button></div>
							</td>
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
				$("#menuItemLoanExtension").addClass("actived");
			});
		</script>
		<!--end footer-->
	</body>
</HTML>
