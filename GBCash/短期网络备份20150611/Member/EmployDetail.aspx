<%@ Page language="c#" Codebehind="EmployDetail.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.EmployDetail" %>
<%@ Register TagPrefix="uc1" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top1" Src="top1.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top" Src="top.ascx" %>
<HTML>
	<HEAD>
		<title>detail1</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
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
					<td width="556" align="center" valign="top">
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
									<TD>
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
												<TD colSpan="3"><%=txYear%>
													Years&nbsp;
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
									</TD>
								</TR>
								<TR>
									<TD style="HEIGHT: 24px" align="center"><a href="employmentedit.aspx?Type=2">Edit</a>
										<INPUT id="Hidden3" style="WIDTH: 40px; HEIGHT: 21px" type="hidden" size="1" name="Hidden1"
											runat="server">
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
