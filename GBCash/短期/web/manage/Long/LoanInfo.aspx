<%@ Page language="c#" Codebehind="LoanInfo.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.Long.LoanInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LongList</title>
		<LINK href="../csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<table width="96%" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td height="25"><strong>Member Number: <%=sNumber%>&nbsp;&nbsp;&nbsp;&nbsp;Loan amount: $<%=sLoan%>&nbsp;&nbsp;&nbsp;&nbsp;
					RegTime:<%=sRegTime%>
							<asp:TextBox id="txPerSid" runat="server" Width="104px" Visible="False"></asp:TextBox></strong></td>
				</tr>
				<tr>
					<td><table width="100%" border="0" cellspacing="1" cellpadding="0">
							<tr bgcolor="#66ffff">
								<td height="25"><strong>No.</strong></td>
								<td height="25"><strong>Datedue</strong></td>
								<td><strong>Repaydue</strong></td>
								<td><strong>Paid</strong></td>
								<td><strong>Penalty</strong></td>
								<td><strong>Late Charge</strong></td>
								<td><strong>Balance</strong></td>
								<td><strong>RepayTime</strong></td>
								<td><strong>OperateTime</strong></td>
								<td><strong>Operate</strong></td>
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
					  Balance=Convert.ToDouble(dtPay.Rows[i]["Balance"]).ToString("0.00");
					string RepayTime=dtPay.Rows[i]["RepayTime"].ToString();
					string OperateTime=dtPay.Rows[i]["OperateTime"].ToString();
				%>
							<tr>
								<td height="25"><%=tempNo%></td>
								<td height="25"><%=Datedue%></td>
								<td><%=Repaydue%></td>
								<td><%=Paid%></td>
								<td><%=Penalty%></td>
								<td><%=LateCharge%></td>
								<td><%=Balance%></td>
								<td><%=RepayTime%></td>
								<td><%=OperateTime%></td>
								<td><a href="LoanPay.aspx?sid=<%=Sid%>&psid=<%=this.txPerSid.Text%>">Operate</a></td>
							</tr>
							<%
				}		%>
						</table>
					</td>
				</tr>
				<tr>
					<td height="25">Operate:<a href=LongOpe.aspx?Ope=15&Sid=<%=sNumber%>>Pre-Approve</a>&nbsp;&nbsp;
					<a href=LongOpe.aspx?Ope=1&Sid=<%=sNumber%>>Approve</a>&nbsp;&nbsp;
					<a href=LongOpe.aspx?Ope=2&Sid=<%=sNumber%>>Complete</a>&nbsp;&nbsp;
					<a href=LongOpe.aspx?Ope=24&Sid=<%=sNumber%>>Collection</a>&nbsp;&nbsp;
					<a href=LongOpe.aspx?Ope=98&Sid=<%=sNumber%>>Delete</a>&nbsp;&nbsp;
					<a href=LongOpe.aspx?Ope=99&Sid=<%=sNumber%>>Reject</a>&nbsp;&nbsp;
					  <div align="center"><A href="LoanInfoForPrint.aspx?sid=<%=sNumber%>">GoToPrintPage</A>&nbsp;<a href="LongList.aspx">Return</a></div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
