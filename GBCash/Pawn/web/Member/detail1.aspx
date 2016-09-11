<%@ Register TagPrefix="uc1" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top1" Src="top1.ascx" %>
<%@ Page language="c#" Codebehind="detail1.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.detail1" %>
<%@ Register TagPrefix="uc1" TagName="top" Src="top.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>detail1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table width="750" border="0" align="center" cellpadding="0" cellspacing="0" height="100%">
				<tr>
					<td colspan="2" style="HEIGHT: 27px"><FONT face="ËÎÌו">
							<uc1:top1 id="Top11" runat="server"></uc1:top1></FONT>
					</td>
				</tr>
				<tr>
					<td valign="top" width="195" align="left" bgcolor="#e8e6df">
						<uc1:leftmenu id="Leftmenu1" runat="server"></uc1:leftmenu>
					</td>
					<td width="556" align="center">
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
									<TD>Member Information
									</TD>
								</TR>
								<TR>
									<TD>
										<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="500" border="0">
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
										<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="397" border="0">
											<TBODY>
												<TR>
													<TD width="116">
														Home&nbspAddress:</TD>
													<TD colSpan="3"><%=txStreet%></TD>
												</TR>
												<TR>
													<TD>City:</TD>
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
												
												<TR>
													<TD style="WIDTH: 198px" colSpan="2">Phone Number:</TD>
													<TD colSpan="2"><%=txTel%></TD>
												</TR>
												
												<TR>
													<TD colSpan="2">&nbsp;</TD>
												</TR>
											</TBODY>
										</TABLE>
									</TD>
								</TR>
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
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
