<%@ Page language="c#" Codebehind="LoanInfoForPrint.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.Long.LoanInfoForPrint" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LoanInfoForPrint</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK href="../csslib/yingnet.css" type="text/css" rel="stylesheet">
		<LINK href="../csslib/print.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<table width="96%" border="0" cellspacing="0" cellpadding="0" align="center">
				<div class="Section1">
					<p class="MsoNormal"><span lang="EN-US"><img width="228" height="79" src="images/cashLogo.jpg"></span></p>
					<div style='BORDER-RIGHT:medium none;PADDING-RIGHT:0cm;BORDER-TOP:medium none;PADDING-LEFT:0cm;PADDING-BOTTOM:1pt;BORDER-LEFT:medium none;PADDING-TOP:0cm;BORDER-BOTTOM:windowtext 1.5pt solid'>
						<p class="MsoNormal" align="center" style='BORDER-RIGHT:medium none;PADDING-RIGHT:0cm;BORDER-TOP:medium none;PADDING-LEFT:0cm;PADDING-BOTTOM:0cm;BORDER-LEFT:medium none;PADDING-TOP:0cm;BORDER-BOTTOM:medium none;TEXT-ALIGN:center'><b><span lang="EN-US" style='FONT-SIZE:16pt'>Golden</span></b><b><span lang="EN-US" style='FONT-SIZE:16pt'>
									Bridge</span></b><b><span lang="EN-US" style='FONT-SIZE:16pt'> Enterprise 
									(Aust) Pty Ltd</span></b></p>
					</div>
					<p class="MsoNormal"><b><span lang="EN-US"></span></b>&nbsp;</p>
					<p class="MsoNormal" align="center" style='TEXT-ALIGN:center'><b><span lang="EN-US" style='FONT-SIZE:20pt'>Loan 
								Statement</span></b></p>
					<p class="MsoNormal" style='TEXT-JUSTIFY:inter-ideograph;TEXT-ALIGN:justify'><b><span lang="EN-US" style='FONT-SIZE:14pt'></span></b>&nbsp;</p>
					<p class="MsoNormal"><b><span lang="EN-US">Customer Number: LT<%=sNumber%></span></b></p>
					<p class="MsoNormal"><b><span lang="EN-US"><%=userFullName%></span></b></p>
					<p class="MsoNormal"><b><span lang="EN-US" style='COLOR:black'><%=userAddressDetail%></span></b>
					</p>
					<p class="MsoNormal"><b><span lang="EN-US"></span></b>&nbsp;</p>
					<p class="MsoNormal"><b><span lang="EN-US">Statement Issued Date:<%=statementIssuedDate%></span></b></p>
					<p class="MsoNormal"><b><span lang="EN-US">Amount Outstanding:
								<%=amountOutstanding%>
							</span></b>
					</p>
				</div>
			</table>
			<table class="MsoNormalTable" border="0" cellspacing="0" cellpadding="0" width="541" style='MARGIN-LEFT:4.65pt;WIDTH:406pt;BORDER-COLLAPSE:collapse'>
				<tr style='HEIGHT:12.75pt'>
					<td width="541" colspan="7" valign="bottom" style='PADDING-RIGHT:5.4pt;PADDING-LEFT:5.4pt;PADDING-BOTTOM:0cm;WIDTH:406pt;PADDING-TOP:0cm;HEIGHT:12.75pt'>
						<p class="MsoNormal"><b><span lang="EN-US" style='FONT-SIZE:9pt;COLOR:black;FONT-FAMILY:??'>Member 
									Number:
									<%=sNumber%>
									&nbsp;&nbsp;&nbsp;&nbsp;Loan amount: $<%=sLoan%>&nbsp;&nbsp;&nbsp;&nbsp; 
									RegTime:<%=sRegTime%>
								</span></b>
						</p>
					</td>
				</tr>
				<tr>
					<td><table width="100%" border="0" cellspacing="1" cellpadding="0">
							<tr bgcolor="#66ffff">
								<td height="25"><strong>No.</strong></td>
								<td height="25"><strong>Datedue</strong></td>
								<td><strong>Repaydue</strong></td>
								<td><strong>Penalty</strong></td>
								<td><strong>Late Charge</strong></td>
								<td><strong>PaymentReceived</strong></td>
								<td><strong>RepayTime</strong></td>
								<td><strong>Balance</strong></td>
							</tr>
							<%
				for(int i=0;i<dtPay.Rows.Count;i++)
				{
					string tempNo = (i+1).ToString();
					string Sid=dtPay.Rows[i]["Sid"].ToString();
					string Datedue=dtPay.Rows[i]["Datedue"].ToString();
					string Repaydue="";
					if(dtPay.Rows[i]["Repaydue"].ToString()!="")
					  Repaydue=Convert.ToDouble(dtPay.Rows[i]["Repaydue"]).ToString("0.00");
					string Paid=dtPay.Rows[i]["Paid"].ToString();
					string Penalty=dtPay.Rows[i]["Penalty"].ToString();
					string LateCharge=dtPay.Rows[i]["LateCharge"].ToString();
					string Balance="";
					if(dtPay.Rows[i]["Balance"].ToString()!="")
					{
						Balance=Convert.ToDouble(dtPay.Rows[i]["Balance"]).ToString("0.00");
					}
					string RepayTime=dtPay.Rows[i]["RepayTime"].ToString();
					string OperateTime=dtPay.Rows[i]["OperateTime"].ToString();
				%>
							<tr>
								<td height="25"><%=tempNo%></td>
								<td height="25"><%=Datedue%></td>
								<td><%=Repaydue%></td>
								<td><%=Penalty%></td>
								<td><%=LateCharge%></td>
								<td><%=Paid%></td>
								<td><%=RepayTime%></td>
								<td><%=Balance%></td>
							</tr>
							<%
				}		%>
						</table>
					</td>
				</tr>
			</table>
			<p class="MsoNormal"><span lang="EN-US"></span>&nbsp;</p>
			<p class="MsoNormal"><span lang="EN-US">Should you enquire any further information 
					regarding to this statement please do not hesitate to contact our office at 
					1300 137 906 or email <a href="mailto:payment@pl.cashsolution.com.au">payment@pl.cashsolution.com.au</a>
				</span>
			</p>
			<p class="MsoNormal"><span lang="EN-US"></span>&nbsp;</p>
			<p class="MsoNormal"><span lang="EN-US"></span>&nbsp;</p>
			<p class="MsoNormal"><span lang="EN-US">Yours sincerely,</span></p>
			<p class="MsoNormal"><span lang="EN-US"></span>&nbsp;</p>
			<p class="MsoNormal"><span lang="EN-US">Golden</span><span lang="EN-US"> Bridge</span><span lang="EN-US">
					Cash Solution</span></p>
			<DIV></DIV>
			<tr>
				<td>&nbsp;</td>
			</tr>
			<tr>
				<td height="25"><strong>
						<asp:TextBox id="txPerSid" runat="server" Width="104px" Visible="False"></asp:TextBox></strong></td>
			</tr>
			<tr>
				<td height="25">
					<div align="center"><A onclick="window.print();" href="#">Print</A>&nbsp;<a href="LongList.aspx">Return</a></div>
				</td>
			</tr>
			</TABLE>
		</form>
	</body>
</HTML>
