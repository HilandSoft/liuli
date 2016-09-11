<%@ Page language="c#" Codebehind="MemberDetail2.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.MemberDetail2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MemberDetail2</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
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
						<FONT face="ËÎÌå"><INPUT id="Hidden1" style="WIDTH: 8px; HEIGHT: 19px" type="hidden" size="1" name="Hidden1"
								runat="server"> </FONT>
					</td>
				</tr>
				<tr>
					<td colspan="4" align="center">
						<asp:LinkButton id="LinkButton1" runat="server">·µ»Ø</asp:LinkButton><INPUT id="Hidden2" style="WIDTH: 27px; HEIGHT: 19px" type="hidden" size="1" name="Hidden2"
							runat="server"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
