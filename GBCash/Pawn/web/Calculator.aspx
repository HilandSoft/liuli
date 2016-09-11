<%@ Register TagPrefix="uc1" TagName="RepaymentCountTypeSelector" Src="UControls/RepaymentCountTypeSelector.ascx" %>
<%@ Register TagPrefix="uc1" TagName="RepaymentCycleTypeSelector" Src="UControls/RepaymentCycleTypeSelector.ascx" %>
<%@ Page language="c#" Codebehind="Calculator.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Calculator" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Calculate</title>
		<meta name="GENERATOR" content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<LINK rel="stylesheet" type="text/css" href="css/css.css">
	</HEAD>
	<body leftMargin="8" topMargin="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellSpacing="0" cellPadding="0" width="380">
				<tr>
					<td>
						<table border="0" cellSpacing="0" cellPadding="0" width="100%">
							<tr>
								<td height="30" colSpan="2">
									<p><strong>What my repayment(s) will be? </strong>
									</p>
								</td>
							</tr>
							<tr>
								<td height="30" width="30%">Loan requested amount:
								</td>
								<td>$ <INPUT style="WIDTH: 150px" id="txLoan" name="textfield292422" runat="server">
									.00 <FONT color="#ff0000">*</FONT>
								</td>
							</tr>
							<tr>
								<td height="30">Your take home pay:
								</td>
								<td>$<INPUT id="txIncome" style="WIDTH:150px" name="textfield2924222" runat="server">
									.00 <FONT color="#ff0000">*</FONT>
								</td>
							</tr>
							<tr>
								<td height="30">Per:</td>
								<td><uc1:repaymentcycletypeselector id="RepaymentCycleTypeSelector1" runat="server"></uc1:repaymentcycletypeselector></td>
							</tr>
							<TR>
								<TD height="30">Date of next payday:
								</TD>
								<TD>DD <INPUT style="WIDTH: 30px" id="txDd1" name="textfield29243" runat="server"> MM
									<INPUT style="WIDTH: 30px" id="txMm1" name="textfield292432" runat="server"> YYYY
									<INPUT style="WIDTH: 60px" id="txYy1" name="textfield292433" runat="server"></TD>
							</TR>
							<tr>
								<td height="30">How long are you going to borrow?
								</td>
								<td><uc1:repaymentcounttypeselector id="RepaymentCountTypeSelector1" runat="server"></uc1:repaymentcounttypeselector></td>
							</tr>
							<tr>
								<td height="30" colSpan="2">&nbsp;</td>
							</tr>
							<tr>
								<td height="30">
									<div align="center"></div>
								</td>
								<td>
									<div align="left"><INPUT id="bnStar2" value="Start over" type="button" name="Submit2" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;<INPUT id="bnCal2" value="Calculate" type="submit" name="Submit" runat="server">
									</div>
								</td>
							</tr>
							<tr>
								<td height="10" colSpan="2">
								</td>
							</tr>
							<tr>
								<td height="30" colSpan="2">
									<table border="0" cellSpacing="0" cellPadding="0" width="100%">
										<tr>
											<td height="30">Payment Schedule:</td>
											<td><asp:Literal id="litSchedule" runat="server"></asp:Literal></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td colSpan="2"><asp:label id="Label1" runat="server"></asp:label></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
		<script type="text/javascript" src="jslib/jquery-1.2.6.min.js"></script>
		<script type="text/javascript" src="jslib/formValidator.js"></script>
		<script type="text/javascript">
			$(document).ready(function () {
				//1.type validate
				$.formValidator.initConfig({ formid: "Form1", alertmessage: true, onerror: function (msg) { alert(msg); } });
				$("#txLoan").formValidator().inputValidator({type:"number", onerror:"please intput number at \"Loan requested amount\""});
				$("#txIncome").formValidator().inputValidator({type:"number", onerror:"please intput number at \"Your take home pay\""});
				
				
				$("#txDd1").formValidator().inputValidator({type:"number",min:1,max:31, onerror:"please intput number at \"Date of next payday\""});
				$("#txMm1").formValidator().inputValidator({type:"number",min:1,max:12, onerror:"please intput number at \"Date of next payday\""});
				$("#txYy1").formValidator().inputValidator({type:"number",min:<%= CurrentYear%>, onerror:"please intput number at \"Date of next payday\""});
				
				
				
				//2.requier validate
				$("#bnCal2").click(function(){
					var txLoanValue= $("#txLoan").val();
					if(txLoanValue.length==0)
					{
						alert("please intput number at \"Loan requested amount\"");
						return false;
					}
					
					var txIncomeValue= $("#txIncome").val();
					if(txIncomeValue.length==0)
					{
						alert("please intput number at \"Your take home pay\"");
						return false;
					}
					
					var txDd1Value= $("#txDd1").val();
					if(txDd1Value.length==0)
					{
						alert("please intput number at \"Date of next payday\"");
						return false;
					}
					
					var txMm1Value= $("#txMm1").val();
					if(txMm1Value.length==0)
					{
						alert("please intput number at \"Date of next payday\"");
						return false;
					}
					
					var txYy1Value= $("#txYy1").val();
					if(txYy1Value.length==0)
					{
						alert("please intput number at \"Date of next payday\"");
						return false;
					}
				});
			});
		</script>
	</body>
</HTML>
