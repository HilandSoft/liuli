<%@ Page language="c#" Codebehind="detail1.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.detail1" %>
<%@ Register TagPrefix="uc1" TagName="MemberTop" Src="MemberTop.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MemberLeft" Src="MemberLeft.ascx" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<script src="../javascriptN/jquery-1.4.4.min.js" type="text/javascript"></script>
		
		<link href="../CSSN/final.css" rel="stylesheet" type="text/css">
			<style type="text/css">
        .style2 { FONT-FAMILY: Verdana; FONT-SIZE: small }
        </style>
	</HEAD>
	<body>
		<!--start top-->
		<uc1:MemberTop id="MemberTop1" runat="server"></uc1:MemberTop>
		<!--end top-->
		<!--start homebanner-->
		<!--start subbanner-->
		<div id="subheader">
			<h1>Member Console</h1>
		</div>
		<!--end subbanner-->
		<!--start main-->
		<div id="main">
			<!--start process-->
			<uc1:MemberLeft id="MemberLeft1" runat="server"></uc1:MemberLeft>
			<!--end process-->
			<div id="content" style="MARGIN-LEFT: 0px">
				<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="504" border="0">
							<TBODY>
								<TR>
									<TD>
										<P><STRONG>Please make sure these are always kept up to date. </STRONG><STRONG>If you 
												have any problems updating this information, please contact us at 1300 137 906 </STRONG>
										</P>
									</TD>
								</TR>
								<TR>
									<TD>&nbsp;</TD>
								</TR>
								<TR>
									<TD><STRONG>Member Information</strong>
									</TD>
								</TR>
								<TR>
									<TD>
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<tr>
												<td height=20>Title:</td>
												<td colspan=3><%=dlTitle%></td>
											</tr>
											<TR>
												<TD style="WIDTH: 198px; HEIGHT: 20px" width="198">First Name:</TD>
												<TD style="WIDTH: 118px; HEIGHT: 20px" width="118"><%=txFname%></TD>
												<TD style="WIDTH: 111px; HEIGHT: 20px" width="111">Middle Name:</TD>
												<TD width="106" style="HEIGHT: 20px"><%=txMname%></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 198px">Last Name:</TD>
												<TD style="WIDTH: 118px"><%=txLname%></TD>
												<TD style="WIDTH: 111px">Customer No:</TD>
												<TD><%=customno%></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 198px">Date of Birth:</TD>
												<TD style="WIDTH: 118px"><%=txDate%></TD>
												<TD style="WIDTH: 111px">E-Mail:
												</TD>
												<TD><%=txEmail%></TD>
											</TR>
											<TR>
												<TD style="WIDTH: 198px">Driver Licence Number:</TD>
												<TD style="WIDTH: 118px"><%=txDriver%>
												</TD>
												<TD style="WIDTH: 111px">State Issued:</TD>
												<TD><%=txIssue%></TD>
											</TR>
										</TABLE>
									</TD>
								</TR>
								<TR>
									<TD>
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TBODY>
												<TR>
													<TD width="116">
														Home&nbsp;Address:</TD>
													<TD colSpan="3"><%=txResident%></TD>
												</TR>
												<TR>
													<TD>Street:</TD>
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
													<TD colSpan="4">&nbsp;</TD>
												</TR>
												<tr>
													<td style="WIDTH: 198px" colSpan="2">Time at this address:</td>
													<td><%=txYear%>
														Years
														<%=txMonth%>
														Months
													</td>
												</tr>
												<TR>
													<TD style="WIDTH: 198px" colSpan="2">Home Phone Number:</TD>
													<TD colSpan="2"><%=txTel%></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 198px" colSpan="2">Mobile:</TD>
													<TD colSpan="2"><%=txMobile%>
														</FONT></TD>
												</TR>
												<TR>
													<TD style="WIDTH: 198px" colSpan="2">Fax:</TD>
													<TD colSpan="2">
														<%=txFax%>
													</TD>
												</TR>
												<TR>
													<TD colSpan="2">&nbsp;</TD>
												</TR>
											</TBODY>
										</TABLE>
									</TD>
								</TR>
								<tr>
									<td>
									<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
											<TR>
												<TD colSpan="4"><STRONG>Employment Information</STRONG>
												</TD>
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
											<%=tip7%>
											<TR>
												<TD><%=tip5%></TD>
												<TD colSpan="3"><%=txYear2%>
													Years&nbsp;
													<%=txMonth2%>
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
												<TD colSpan="3"><%=txMm1%>
													/<%=txDd1%>
													/<%=txYy1%>
												</TD>
											</TR>
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
											<TR>
												<TD>&nbsp;</TD>
											</TR>
										</TABLE>
									</td>
								</tr>
								<TR>
									<TD style="HEIGHT: 24px">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<a href="detail.aspx">Edit</a>
									</TD>
								</TR>
								<TR>
									<TD>&nbsp;</TD>
								</TR>
							</TBODY>
						</TABLE>
			</div>
		</div>
		<!--end main-->
		<!--start footer-->
		<div style="CLEAR: both"></div>
		<div id="footer">© Copyright Golden Bridge Cash Solution Pty Ltd 2011</div>
		<script type="text/javascript">
			$(document).ready(function(){
				$("#menuItemYourProfile").addClass("actived");
			});
		</script>
		<!--end footer-->
	</body>
</HTML>
						
					