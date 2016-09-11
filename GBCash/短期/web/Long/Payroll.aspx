<%@ Page language="c#" Codebehind="Payroll.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Payroll" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<script language="javascript" src="../jslib/commCheck.js" type="text/javascript"></script>
			<style type="text/css">
.word1 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
.word2 { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
.style1 { FONT-WEIGHT: bold; FONT-SIZE: 14pt }
</style>
	</HEAD>
	<body LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table width="650" border="0" cellSpacing="0" cellPadding="0" align="center">
				<tr>
					<td valign="top">
					</td>
				</tr>
				<tr>
					<td align="center"><div align="left"><IMG src="images/logo.gif"></div>
					</td>
				</tr>
				<tr>
					<td align="center"><span class="style1">Payroll Deduction Authority</span></td>
				</tr>
				<tr>
					<td align="center"><br>
						<br>
						<div align="left">To:
							<%=stxEmployer%>
							(my employer)<br>
							AND: Golden Bridge Enterprises (Aust) Pty Ltd (ABN 92 112 483 226) PO Box
							18323, Collins Street East, VIC 8003 <br>
							FROM:
							<%=stxfname%>
							<%=stxmname%>
							<%=stxsname%>
							(“applicant / borrower”)<br>
						</div>
					</td>
				</tr>
				<tr>
					<td align="center"><div align="left"><strong><br>
								<br>
								PREAMLE:<br>
							</strong>The applicant / borrower has taken out or is in the process of taking 
							a loan with Golden Bridge Enterprises (Aust) Pty Ltd (Hereafter referred to as "Golden Bridge") . Pursuant to the terms of 
							the loan of the loan contract, the applicant / borrower has agreed that in the 
							event that the borrower fails to meet his/her obligations under the loan 
							contract, upon written request of Golden Bridge, the borrower will authorize his/her 
							employer to deduct the amount of the repayments from the borrower's wage/salary 
							and to credit such deductions direct to Golden Bridge.<br>
							<br>
						</div>
					</td>
				</tr>
				<tr>
					<td align="center"><div align="left">
							<p><strong>AUTHORITY:</strong></p>
							<p>I,
								<%=stxfname%>
								<%=stxmname%>
								<%=stxsname%>
								hereby authorize my employer
								<%=stxEmployer%>
								to :</p>
							<p>1. deduct from any periodical payment made to me on account of my employment the 
								maximum  25% of my net pay per payment; and<br>
								2. to credit those deductions to the nominated bank account of Golden Bridge
							</p>
							<p>Until such time as my obligations to Golden Bridge under my loan contract have 
								been met in full.</p>
							<p>This authorization will not be revoked, by any party, until all monies owing to 
								Golden Bridge have been paid.</p>
							<p>I acknowledge that this Payroll Deduction Arrangement is governed by terms of 
								the Contract signed by me and received from Golden Bridge
								<br>
								<br>
							</p>
						</div>
					</td>
				</tr>
				<tr>
					<td align="center"><div align="left">
							<table width="100%" border="0" cellspacing="0" cellpadding="0">
								<tr>
									<td width="29%" height="35">Signature of applicant/borrower</td>
									<td width="71%">______________________________________________________________</td>
								</tr>
								<tr>
									<td height="35">Date</td>
									<td>______________________________________________________________</td>
								</tr>
								<tr>
									<td height="35">Name of applicant/borrower
									</td>
									<td>______________________________________________________________</td>
								</tr>
							</table>
						</div>
					</td>
				</tr>
				<tr>
					<td height="30"><div align="center">
							<asp:TextBox id="txPerSid" runat="server" Width="1px" Visible="False"></asp:TextBox>
							<A onclick="window.print();" href="#">Print</A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:LinkButton id="Linkbutton3" runat="server">Back</asp:LinkButton>
							&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
							<asp:LinkButton id="LinkButton1" runat="server">Next</asp:LinkButton>
							<asp:LinkButton id="LinkButton2" runat="server" Visible="false">Next</asp:LinkButton></div>
					</td>
				</tr>
				<tr>
					<td>
						<table width="650" cellpadding="0" cellspacing="0" border="0" align="center">
							<tr>
								<td height="20"><div align="center">&nbsp;</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
