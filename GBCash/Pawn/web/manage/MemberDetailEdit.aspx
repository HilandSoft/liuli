<%@ Register TagPrefix="cc1" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<%@ Register TagPrefix="uc1" TagName="RepaymentCycleTypeSelector" Src="../UControls/RepaymentCycleTypeSelector.ascx" %>
<%@ Page language="c#" Codebehind="MemberDetailEdit.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.MemberDetailEdit" %>
<%@ Register TagPrefix="uc1" TagName="CircleDropDownList" Src="../Include/CircleDropDownList.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MemberDetailEdit</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<INPUT id="Hidden1" type="hidden" size="1" name="Hidden1" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="70%" align="center" bgColor="#fefefe"
				border="0">
				<tr>
					<td colSpan="4"><STRONG>Customer Details For Edit: </STRONG>
					</td>
				</tr>
				<tr>
					<td vAlign="top" width="21%" height="28">First Name:</td>
					<td vAlign="top" width="26%"><asp:textbox id="txtFname" runat="server">
							<%=txFname%>
						</asp:textbox></td>
					<td vAlign="top" width="20%">Last Name:</td>
					<td vAlign="top" width="33%"><asp:textbox id="txtLname" runat="server">
							<%=txLname%>
						</asp:textbox></td>
				</tr>
				<tr>
					<td>Data of Birth:</td>
					<td><asp:textbox id="txtDate" runat="server"></asp:TextBox></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td vAlign="top">Telphone:
					</td>
					<td vAlign="top"><asp:textbox id="txtTelphone" runat="server">
						</asp:textbox></td>
					<td vAlign="top">E-Mail:
					</td>
					<td vAlign="top"><asp:textbox id="txtEmail" runat="server">
							<%=txEmail%>
						</asp:textbox></td>
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
					<td vAlign="top">Address:</td>
					<td vAlign="top">
						
						<asp:textbox id="txtResident" runat="server"></asp:textbox></td>
					<td vAlign="top">Postcode:</td>
					<td vAlign="top"><%=txPost%>
						<asp:textbox id="txtPost" runat="server"></asp:textbox></td>
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
					<td><STRONG>Bank details</STRONG>&nbsp;&nbsp;&nbsp;&nbsp;</td>
					<td></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>Item to pawn:</td>
					<td>
					<asp:DropDownList id=drpItems runat="server" Width="100px">
												<asp:ListItem>Select</asp:ListItem>
												<asp:ListItem>Ring</asp:ListItem>
												<asp:ListItem>Bracelet</asp:ListItem>
												<asp:ListItem>Necklace</asp:ListItem>
												<asp:ListItem>Charm</asp:ListItem>
												<asp:ListItem>Earrings</asp:ListItem>
												<asp:ListItem>Other jewellery </asp:ListItem>
												<asp:ListItem>Gold – Coins</asp:ListItem>
												<asp:ListItem>Silver – Coins</asp:ListItem>
												<asp:ListItem>Metal – Gold </asp:ListItem>
												<asp:ListItem>Metal – Silver</asp:ListItem>
												<asp:ListItem>Metal – Platinum</asp:ListItem>
											</asp:DropDownList>
											</td>
											<td>Condition of Item:</td>
											<td>
											<asp:DropDownList id=drpItemCondition runat="server" Width="100px">
												<asp:ListItem>Select</asp:ListItem>
												<asp:ListItem>New</asp:ListItem>
												<asp:ListItem>Used - No damage</asp:ListItem>
												<asp:ListItem>Normal were and tear</asp:ListItem>
												<asp:ListItem>Not applicable</asp:ListItem>
											</asp:DropDownList>
											</td>
				</tr>
				<tr>
					<td>Item Description:</td>
					<td colspan="3"><asp:TextBox id=txItemDescription runat="server" Width="250" Rows="5" TextMode="MultiLine"></asp:TextBox></td>
				</tr>
				<tr>
					<td>Photo Number:</td>
					<td colspan="3"><asp:TextBox id="txtPhotoNumber" runat="server"  TextMode="SingleLine"></asp:TextBox></td>
					
				</tr>
				<tr>
					<td colSpan="4">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD colSpan="3"><STRONG>Loan Requirements</STRONG><BR>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px" width="143">Loan Requested:</TD>
								<TD colSpan="2">$<INPUT id="txtLoan" style="WIDTH: 166px; HEIGHT: 22px" name="Text1" runat="server"><FONT face="宋体" color="#990000">*
									</FONT>
								</TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px" width="143">Loan Repayment:</TD>
								<TD colSpan="2"><ul>
										<li>
											<input type="radio" name="installmentType" value="customDays" runat="server" id="installment0"><label for="installment0">
												Repayment in</label>
											<asp:TextBox id="installmentDays" runat="server" Width="20"></asp:TextBox>
											<label for="installment0">days (maximum of 62days)</label>
										<li>
											<input type="radio" name="installmentType" value="fixedDays" runat="server" id="installment1"><label for="installment1">
												Repay over</label>
											<asp:DropDownList style="Z-INDEX: 0" id="installmentCount" runat="server">
												<asp:ListItem Value="1">1</asp:ListItem>
												<asp:ListItem Value="2">2</asp:ListItem>
												<asp:ListItem Value="3">3</asp:ListItem>
											</asp:DropDownList>
											<label for="installment1">instalments</label></li>
									</ul>
									*
									<asp:button id="btnCalculate" runat="server" Text="Calculate"></asp:button>(if 
									change schedule,pls must Calculate first)</FONT></TD>
							</TR>
							<TR>
								<TD colSpan="3">Note: Each installment dues on your payday . Please make sure your 
									repayment funds are available in your account for deduction on each installment 
									due date.</TD>
							</TR>
							<tr>
								<td>When are you paid:
								</td>
								<td colSpan="2"><cc1:perradiobuttonlist id="PerRadioButtonList1" runat="server" RepeatDirection="Horizontal"></cc1:perradiobuttonlist></td>
							</tr>
							<tr>
								<td>Next payday:</td>
								<td colSpan="2"><%=txDd1%><asp:textbox id="txtDd1" runat="server" Width="24px"></asp:textbox>/<%=txMm1%><asp:textbox id="txtMm1" runat="server" Width="23px"></asp:textbox>/<%=txYy1%><asp:textbox id="txtYy1" runat="server" Width="40px"></asp:textbox>(DD/MM/YYYY)
								</td>
							</tr>
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
								<TD><FONT face="宋体"><asp:textbox id="d1F" runat="server" Width="113px" BorderStyle="None" ReadOnly="True"></asp:textbox></FONT></TD>
								<TD><FONT face="宋体"><asp:textbox id="s1F" runat="server" Width="113px" BorderStyle="None" ReadOnly="True"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD>2nd Installment
								</TD>
								<TD><FONT face="宋体"><asp:textbox id="d2F" runat="server" Width="113px" BorderStyle="None" ReadOnly="True"></asp:textbox></FONT></TD>
								<TD><FONT face="宋体"><asp:textbox id="s2F" runat="server" Width="113px" BorderStyle="None" ReadOnly="True"></asp:textbox></FONT></TD>
							</TR>
							<TR>
								<TD style="WIDTH: 143px; HEIGHT: 21px">3rd Installment
								</TD>
								<TD><FONT face="宋体"><asp:textbox id="d3F" runat="server" Width="113px" BorderStyle="None" ReadOnly="True"></asp:textbox></FONT></TD>
								<TD><FONT face="宋体"><asp:textbox id="s3F" runat="server" Width="113px" BorderStyle="None" ReadOnly="True"></asp:textbox></FONT></TD>
							</TR>
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
