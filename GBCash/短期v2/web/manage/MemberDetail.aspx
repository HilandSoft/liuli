<%@ Page language="c#" Codebehind="MemberDetail.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.MemberDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MemberDetail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="70%" align="center" bgColor="#fefefe"
				border="0">
				<tr>
					<td colSpan="4"><STRONG>Customer Details: </STRONG>
					</td>
				</tr>
				<tr>
					<td vAlign="top" width="21%" height="28">Title:</td>
					<td vAlign="top" colspan="3">
						<%=dlTitle%>
					</td>
				</tr>
				<tr>
					<td vAlign="top" width="21%" height="28">First Name:</td>
					<td vAlign="top" width="26%">
						<%=txFname%>
					</td>
					<td vAlign="top" width="20%">Middle Name:</td>
					<td vAlign="top" width="33%">
						<%=txMname%>
					</td>
				</tr>
				<tr>
					<td vAlign="top">Last Name:</td>
					<td vAlign="top">
						<%=txLname%>
					</td>
					<td vAlign="top">&nbsp;
					</td>
					<td vAlign="top">&nbsp;
					</td>
				</tr>
				<tr>
					<td vAlign="top">Date of Birth:</td>
					<td vAlign="top">
						<%=txDate%>
					</td>
					<td vAlign="top">E-Mail:
					</td>
					<td vAlign="top">
						<%=txEmail%>
					</td>
				</tr>
				<tr>
					<td vAlign="top">Driver Licence Number:</td>
					<td vAlign="top">
						<%=txDriver%>
					</td>
					<td vAlign="top">State Issued:</td>
					<td vAlign="top">
						<%=txIssue%>
					</td>
				</tr>
				<tr>
					<td vAlign="top">Home Address:</td>
					<td vAlign="top" colSpan="3">
						<%=txResident%>
					</td>
				</tr>
				<tr>
					<td vAlign="top">Street:</td>
					<td vAlign="top" colSpan="3">
						<%=txStreet%>
					</td>
				</tr>
				<tr>
					<td vAlign="top">City:</td>
					<td vAlign="top">
						<%=txCity%>
					</td>
					<td vAlign="top">State:</td>
					<td vAlign="top">
						<%=selState%>
					</td>
				</tr>
				<tr>
					<td vAlign="top">Postcode:</td>
					<td vAlign="top" colSpan="3">
						<%=txPost%>
					</td>
				</tr>
				<tr>
					<td>Time at this address:</td>
					<td colSpan="3"><%=txYeard%>
						Years
						<%=txMonthd%>
						Months
					</td>
				</tr>
				<tr>
					<td vAlign="top">Home Phone Number:</td>
					<td vAlign="top" colSpan="3">
						<%=txTel%>
					</td>
				</tr>
				<tr>
					<td vAlign="top">Mobile:</td>
					<td vAlign="top" colSpan="3"><%=txMobile%></td>
				</tr>
				<tr>
					<td vAlign="top">Fax:</td>
					<td vAlign="top" colSpan="3"><%=txFax%>
						<FONT face="ËÎÌו"><INPUT id="Hidden1" style="WIDTH: 8px; HEIGHT: 19px" type="hidden" size="1" name="Hidden1"
								runat="server"> </FONT>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td colSpan="4"><strong>Employment Information</strong></td>
				</tr>
				<tr>
					<td><%=tip2%></td>
					<td><%=txEmployer%></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td><%=tip3%></td>
					<td><%=txAddress%></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td><%=tip4%></td>
					<td><%=txPhone%></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td><%=tip5%></td>
					<td colSpan="3"><%=txYear%>
						Years&nbsp;
						<%=txMonth%>
						Months</td>
				</tr>
				<tr>
					<td><%=tip6%></td>
					<td colSpan="3"><%=txIncome%>
						(Take home pay after taxes)</td>
				</tr>
				<tr>
					<td><%=tip7%></td>
					<td colSpan="3"><%=txJob%>
					</td>
				</tr>
				<tr>
					<td>When are you paid:
					</td>
					<td><%=paid%></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>Next payday:</td>
					<td><%=txDd1%>
						/<%=txMm1%>
						/<%=txYy1%>
					</td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>Loan purpose:</td>
					<td colspan="3"><%=loanPurpose%></td>
				</tr>
				<tr>
					<td>Rent/mortgage payment:</td>
					<td colspan="3"><%=houseInfo%></td>
				</tr>
				<tr>
					<td>Other lenders:</td>
					<td colspan="3"><%=otherLenderInfo%></td>
				</tr>
				<tr>
					<td>Any default under other SACC:</td>
					<td colspan="3"><%=otherSmallCreditHas%></td>
				</tr>
				<tr>
					<td>How many SACC in the last 90 days:</td>
					<td colspan="3"><%=otherSmallCreditCount%></td>
				</tr>
				<tr>
					<td>Does gross income change:</td>
					<td><%=IsGrossIncomeChange%></td>
					<td>Gross income value</td>
					<td><%= GrossIncomeChangeValue%></td>
				</tr>
				<tr>
					<td>Does Pay Other Credit:</td>
					<td><%=IsPayOtherCredit%></td>
					<td>Pay Other Credit Value</td>
					<td><%= PayOtherCreditValue%></td>
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
					<td><%=BankName%></td>
					<td>Branch:</td>
					<td><%=Branch%>
					</td>
				</tr>
				<tr>
					<td>Account Name:</td>
					<td><%=AName%></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td>BSB:</td>
					<td><%=Bsb%></td>
					<td>Account Number:</td>
					<td><%=ANumber%></td>
				</tr>
				<tr>
					<td>Preferred methods:</td>
					<td><%=MContact%></td>
				</tr>
				<tr>
					<td colSpan="4">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
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
								<td><%=Rname1%></td>
								<td><%=Rship1%></td>
								<td><%=Rnum1%></td>
							</tr>
							<tr>
								<td><%=Rname2%></td>
								<td><%=Rship2%></td>
								<td><%=Rnum2%></td>
							</tr>
							<tr>
								<td><%=Rname3%></td>
								<td><%=Rship3%></td>
								<td><%=Rnum3%></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td vAlign="top" colSpan="4">
						<div align="center"><input id="Submit1" type="submit" value="IsValid" name="Submit" runat="server">
							<input id="Submit2" type="submit" value="NotValid" name="Submit" runat="server">
							<input id="Submit3" type="submit" value="Delete" name="Submit2" runat="server">
							<asp:HyperLink id="HyperLinkEdit" runat="server">Edit</asp:HyperLink>
							<A href="MemberList.aspx">Return</A>
						</div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
