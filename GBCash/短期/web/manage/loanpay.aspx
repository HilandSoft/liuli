<%@ Page language="c#" Codebehind="loanpay.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.loanpay" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>loanpay</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../jslib/commCheck.js" type="text/javascript"></script>
		<script language="javascript" src="../jslib/cal_layers.js"></script>
		<script language="javascript" src="../jslib/cal_menu.js"></script>
		<script language="javascript" src="../jslib/cal_pop.js"></script>
		<script language="javascript">
		function  Check1() {
		var ftxPaid=document.getElementById("txPaid1");
		var ftxPenalty=document.getElementById("txPenalty1");
		var ftxPtime=document.getElementById("txPtime1");
		var ftxOtime=document.getElementById("txOtime1");
		
		if(!chkNull(ftxPaid.value)) {
		alert("还款额不能为空！");
		ftxPaid.focus();
		return false;
		}	
		if(!chknum(ftxPaid.value)) {
		alert("还款额含有非法字符！");
		ftxPaid.focus();
		return false;
		}
		
		if(!chkNull(ftxPenalty.value)) {
		alert("罚款额不能为空！");
		ftxPenalty.focus();
		return false;
		}	
		if(!chknum(ftxPenalty.value)) {
		alert("罚款额含有非法字符！");
		ftxPenalty.focus();
		return false;
		}
		
		if(!chkNull(ftxPtime.value)) {
		alert("还款日期不能为空！");
		ftxPtime.focus();
		return false;
		}	
		if(!chkNull(ftxOtime.value)) {
		alert("操作日期不能为空！");
		ftxOtime.focus();
		return false;
		}	
		return true;
		}
		
		function  Check2() {
		var ftxPaid=document.getElementById("txPaid2");
		var ftxPenalty=document.getElementById("txPenalty2");
		var ftxPtime=document.getElementById("txPtime2");
		var ftxOtime=document.getElementById("txOtime2");
		
		if(!chkNull(ftxPaid.value)) {
		alert("还款额不能为空！");
		ftxPaid.focus();
		return false;
		}	
		if(!chknum(ftxPaid.value)) {
		alert("还款额含有非法字符！");
		ftxPaid.focus();
		return false;
		}
		
		if(!chkNull(ftxPenalty.value)) {
		alert("罚款额不能为空！");
		ftxPenalty.focus();
		return false;
		}	
		if(!chknum(ftxPenalty.value)) {
		alert("罚款额含有非法字符！");
		ftxPenalty.focus();
		return false;
		}
		
		if(!chkNull(ftxPtime.value)) {
		alert("还款日期不能为空！");
		ftxPtime.focus();
		return false;
		}	
		if(!chkNull(ftxOtime.value)) {
		alert("操作日期不能为空！");
		ftxOtime.focus();
		return false;
		}	
		return true;
		}
		
		function  Check3() {
		var ftxPaid=document.getElementById("txPaid3");
		var ftxPenalty=document.getElementById("txPenalty3");
		var ftxPtime=document.getElementById("txPtime3");
		var ftxOtime=document.getElementById("txOtime3");
		
		if(!chkNull(ftxPaid.value)) {
		alert("还款额不能为空！");
		ftxPaid.focus();
		return false;
		}	
		if(!chknum(ftxPaid.value)) {
		alert("还款额含有非法字符！");
		ftxPaid.focus();
		return false;
		}
		
		if(!chkNull(ftxPenalty.value)) {
		alert("罚款额不能为空！");
		ftxPenalty.focus();
		return false;
		}	
		if(!chknum(ftxPenalty.value)) {
		alert("罚款额含有非法字符！");
		ftxPenalty.focus();
		return false;
		}
		
		if(!chkNull(ftxPtime.value)) {
		alert("还款日期不能为空！");
		ftxPtime.focus();
		return false;
		}	
		if(!chkNull(ftxOtime.value)) {
		alert("操作日期不能为空！");
		ftxOtime.focus();
		return false;
		}	
		return true;
		}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="800" border="0">
				<tr>
					<td colSpan="2"><strong>贷款冲减,罚款</strong></td>
				</tr>
				<tr>
					<td width="151">Application Date: <INPUT id="Hidden1" style="WIDTH: 16px; HEIGHT: 19px" type="hidden" size="1" name="Hidden1"
							runat="server">
					</td>
					<td width="649"><%=RTime%></td>
				</tr>
				<tr>
					<td>Loan Amount:
					</td>
					<td><%=Loan%></td>
				</tr>
				<tr>
					<td>Payment Schedule:</td>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td style="HEIGHT: 111px" colSpan="2">
						<table cellSpacing="0" cellPadding="0" width="1000" border="0">
							<tr>
								<td width="91">&nbsp;</td>
								<td width="139">Date due
								</td>
								<td width="176">Repayment due
								</td>
								<td style="WIDTH: 143px" width="143">Paid
								</td>
								<td style="WIDTH: 139px" width="139">Penalty
								</td>
								<td style="WIDTH: 142px" width="142">Repay Time
								</td>
								<td width="172"><FONT face="宋体"></FONT></td>
							</tr>
							<tr>
								<td>Installment 1
								</td>
								<td><%=Date1%></td>
								<td><%=Repay1%></td>
								<td style="WIDTH: 143px"><asp:textbox id="txPaid1" runat="server" Width="114px"></asp:textbox></td>
								<td style="WIDTH: 139px"><asp:textbox id="txPenalty1" runat="server" Width="114px"></asp:textbox>&nbsp;</td>
								<td style="WIDTH: 142px"><asp:textbox id="txPtime1" ondblclick="popUpCalendar(this, this, 'yyyy-mm-dd');" onclick="popUpCalendar(this, this, 'yyyy-mm-dd');"
										runat="server" Width="114px" ReadOnly="True"></asp:textbox>&nbsp;</td>
								<td><asp:button id="Button1" runat="server" Text="Submit"></asp:button></td>
							</tr>
							<tr>
								<td>Installment 2
								</td>
								<td><%=Date2%></td>
								<td><%=Repay2%></td>
								<td style="WIDTH: 143px"><asp:textbox id="txPaid2" runat="server" Width="114px"></asp:textbox></td>
								<td style="WIDTH: 139px"><asp:textbox id="txPenalty2" runat="server" Width="114px"></asp:textbox></td>
								<td style="WIDTH: 142px"><asp:textbox id="txPtime2" ondblclick="popUpCalendar(this, this, 'yyyy-mm-dd');" onclick="popUpCalendar(this, this, 'yyyy-mm-dd');"
										runat="server" Width="114px" ReadOnly="True"></asp:textbox></td>
								<td><asp:button id="Button2" runat="server" Text="Submit" Enabled="False"></asp:button></td>
							</tr>
							<tr>
								<td>Installment 3
								</td>
								<td><%=Date3%></td>
								<td><%=Repay3%></td>
								<td style="WIDTH: 143px"><asp:textbox id="txPaid3" runat="server" Width="114px"></asp:textbox></td>
								<td style="WIDTH: 139px"><asp:textbox id="txPenalty3" runat="server" Width="114px"></asp:textbox></td>
								<td style="WIDTH: 142px"><asp:textbox id="txPtime3" ondblclick="popUpCalendar(this, this, 'yyyy-mm-dd');" onclick="popUpCalendar(this, this, 'yyyy-mm-dd');"
										runat="server" Width="114px" ReadOnly="True"></asp:textbox></td>
								<td><asp:button id="Button3" runat="server" Text="Submit" Enabled="False"></asp:button></td>
							</tr>
							<tr>
								<td colSpan="8"><FONT face="宋体"></FONT></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center" colSpan="2"><A onclick="history.go(-1);" href="#">Return</A></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
