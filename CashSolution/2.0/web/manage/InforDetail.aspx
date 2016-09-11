<%@ Page language="c#" Codebehind="InforDetail.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.InforDetail" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>InforDetail</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="450" align="center" border="0">
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td><STRONG>Employment Information <INPUT id="Hidden1" style="WIDTH: 64px; HEIGHT: 19px" type="hidden" size="5" name="Hidden1"
								runat="server"> <INPUT id="Hidden2" style="WIDTH: 48px; HEIGHT: 19px" type="hidden" size="2" name="Hidden2"
								runat="server"></STRONG></td>
				</tr>
				<tr>
					<td><asp:panel id="Panel1" runat="server" Width="424px" Height="104px">
							<TABLE cellSpacing="0" cellPadding="0" width="457" align="center" border="0">
								<TR>
									<TD width="313">
										<DIV align="left">Employer:
										</DIV>
									</TD>
									<TD width="299"><%=Employer%></TD>
								</TR>
								<TR>
									<TD>
										<DIV align="left">Employer's Address:
										</DIV>
									</TD>
									<TD><%=EAddress%></TD>
								</TR>
								<TR>
									<TD>
										<DIV align="left">Employer Phone:
										</DIV>
									</TD>
									<TD><%=EPhone%></TD>
								</TR>
								<TR>
									<TD>
										<DIV align="left">Time Employed:
										</DIV>
									</TD>
									<TD><%=TYears%>Years
										<%=TMonths%>
										Months
									</TD>
								</TR>
								<TR>
									<TD>
										<DIV align="left">Take Home Pay:
										</DIV>
									</TD>
									<TD><%=MIncome%></TD>
								</TR>
								<TR>
									<TD>
										<DIV align="left">When are you paid:
										</DIV>
									</TD>
									<TD><%=Wpaid%></TD>
								</TR>
								<TR>
									<TD colSpan="2">
										<DIV align="center">
											<asp:LinkButton id="LinkButton1" runat="server">Return</asp:LinkButton></DIV>
									</TD>
								</TR>
							</TABLE>
						</asp:panel></td>
				</tr>
				<tr>
					<td><asp:panel id="Panel2" runat="server" Width="424px" Height="104px">
							<TABLE cellSpacing="0" cellPadding="0" width="457" align="center" border="0">
								<TR>
									<TD width="313">
										<DIV align="left">Type of benefit:</DIV>
									</TD>
									<TD width="299"><%=Employer%></TD>
								</TR>
								<TR>
									<TD>
										<DIV align="left">Centreline Office:</DIV>
									</TD>
									<TD><%=EAddress%></TD>
								</TR>
								<TR>
									<TD>
										<DIV align="left">Contact Name:</DIV>
									</TD>
									<TD><%=EPhone%></TD>
								</TR>
								<TR>
									<TD>
										<DIV align="left">How long on this benefit:
										</DIV>
									</TD>
									<TD><%=TYears%>Years
										<%=TMonths%>
										Months
									</TD>
								</TR>
								<TR>
									<TD>
										<DIV align="left">Monthly Benefit:</DIV>
									</TD>
									<TD><%=MIncome%></TD>
								</TR>
								<TR>
									<TD>
										<DIV align="left">When are you paid:
										</DIV>
									</TD>
									<TD><%=Wpaid%></TD>
								</TR>
								<TR>
									<TD colSpan="2">
										<DIV align="center">
											<asp:LinkButton id="LinkButton2" runat="server">Return</asp:LinkButton></DIV>
									</TD>
								</TR>
							</TABLE>
						</asp:panel></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
