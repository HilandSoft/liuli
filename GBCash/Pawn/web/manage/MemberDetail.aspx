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
			<INPUT id="Hidden1" type="hidden" size="1" name="Hidden1" runat="server">
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
					<td vAlign="top" width="20%">Last Name:</td>
					<td vAlign="top" width="33%">
						<%=txLname%>
					</td>
				</tr>
				<tr>
					<td>Data of Birth:</td>
					<td><%=txDate %></td>
					<td></td>
					<td></td>
				</tr>
				<tr>
					<td vAlign="top">Telphone:</td>
					<td vAlign="top">
						<%=txTel%>
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
					<td vAlign="top">Address:</td>
					<td vAlign="top">
						<%=txStreet%>
					</td>
					<td vAlign="top">Postcode:</td>
					<td vAlign="top">
						<%=txPost%>
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
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td vAlign="top">Item to pawn:</td>
					<td vAlign="top" colSpan="3"><%=txItemtoPawn%>
					</td>
				</tr>
				<tr>
					<td vAlign="top">Condition of Item:</td>
					<td vAlign="top" colSpan="3"><%=txItemCondition%>
					</td>
				</tr>
				<tr>
					<td vAlign="top">Item Description:</td>
					<td vAlign="top" colSpan="3"><%=txItemDescription%>
					</td>
				</tr>
				<tr>
					<td vAlign="top">Item Photo:</td>
					<td vAlign="top" ><%=txItemPhoto%>
					</td>
					<td vAlign="top">Item Photo No:</td>
					<td vAlign="top" ><%=txItemPhotoNumber%>
					</td>
				</tr>
				<tr>
					<td vAlign="top">Free GoldPack:</td>
					<td vAlign="top" colSpan="3"><%=txGoldPack%>
					</td>
				</tr>
				<tr>
					<td>&nbsp;</td>
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
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td vAlign="top" colSpan="4">
						<div align="center"><input id="Submit1" type="submit" value="IsValid" name="Submit" runat="server">
							<input id="Submit2" type="submit" value="NotValid" name="Submit" runat="server">
							<input id="Submit3" type="submit" value="Delete" name="Submit2" runat="server">
							<asp:HyperLink id="HyperLinkEdit" runat="server">Edit</asp:HyperLink>
							 <A href="MemberList.aspx">
								Return</A>
						</div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
