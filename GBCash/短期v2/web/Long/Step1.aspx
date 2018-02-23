<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Page language="c#" Codebehind="Step1.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Step1" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<script language="javascript" src="../jslib/commCheck.js" type="text/javascript"></script>
			<script language="javascript">
		function  CheckFeedback() {
		var ftxpurpose=document.getElementById("txpurpose");
		var ftxborrow=document.getElementById("txborrow");
		
		if(!chkNull(ftxpurpose.value)) {
		alert(" Field 'Primary purpose' under 'Initial Loan Details' is not valid!");
		ftxpurpose.focus();
		return false;
		}
		
		if(!chkNull(ftxborrow.value)) {
		alert(" Field 'How much would you like to borrow' is not valid!");
		ftxborrow.focus();
		return false;
		}
		
		if(!chkdigital(ftxborrow.value)) {
		alert(" Field 'How much would you like to borrow' is not valid!");
		ftxborrow.focus();
		return false;
		}
		
		if(ftxborrow.value<1000){
		alert(" Please note the minimum loan is $1000!");
		ftxborrow.focus();
		return false;
		}
		
		if(ftxborrow.value>5000){
		alert(" Please note the maximum loan is $5000!");
		ftxborrow.focus();
		return false;
		}
		
		return true;
		}
			</script>
			<style type="text/css">
.word1 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
.word2 { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
</style>
	</HEAD>
	<body LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td>
						<uc1:head id="Head1" runat="server"></uc1:head></td>
				</tr>
			</table>
			<table width="990" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td colspan="3" height="10"></td>
				</tr>
				<tr>
					<td width="5">&nbsp;</td>
					<td width="200" valign="top" align="left">
						<table width="190" border="0" cellpadding="0" cellspacing="0">
							<tr>
								<td>
									<img src="images/1_01.gif" width="190" height="18" alt=""></td>
							</tr>
							<tr>
								<td background="images/1_07.gif">
									<table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Pre-qualification</td>
										</tr>
										<tr>
											<td width="17%" height="20"><div align="center"></div>
											</td>
											<td width="83%" class="word2">Apply Now
											</td>
										</tr>
										<tr>
											<td height="20"><div align="center"><img src="images/1_04.gif" width="16" height="10"></div>
											</td>
											<td class="word1">Initial loan information</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">About yourself</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">About your work</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Your bank details</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Application summary</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Submit application</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<img src="images/1_09.gif" width="190" height="5" alt=""></td>
							</tr>
							<tr>
								<td align="center"><br>
									<img src="images/contact2.gif" width="160" height="106" alt=""></td>
							</tr>
						</table>
					</td>
					<td>
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR bgcolor="#cc3300">
								<TD height="30" colSpan="2"><img src="images/step1.gif" width="400" height="30"></TD>
							</TR>
							<tr>
								<td colspan="2" height="10"></td>
							</tr>
							<TR>
								<TD colSpan="2" height="30"><b>Please complete the following details about your loan.</b></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="30">What is the primary purpose of the loan?</TD>
							</TR>
							<TR>
								<TD colSpan="2">&nbsp;
									<asp:TextBox id="txpurpose" runat="server" TextMode="MultiLine" Width="650px" Height="150px"></asp:TextBox>
									<FONT color="#ff0000">*</FONT></TD>
							</TR>
							<TR>
								<TD width="40%" height="30">How much would you like to borrow?</TD>
								<TD>$
									<asp:TextBox id="txborrow" runat="server"></asp:TextBox>.00 <FONT color="#ff0000">* 
										 </FONT>
								</TD>
							</TR>
							<TR>
								<TD>Please select the term of the loan:</TD>
								<TD height="30">
									<asp:DropDownList id="dlterms" runat="server" Width="150">
										<asp:ListItem Value="3" Selected="True">3 Months</asp:ListItem>
										<asp:ListItem Value="4">4 Months</asp:ListItem>
										<asp:ListItem Value="5">5 Months</asp:ListItem>
										<asp:ListItem Value="6">6 Months</asp:ListItem>
										<asp:ListItem Value="7">7 Months</asp:ListItem>
										<asp:ListItem Value="8">8 Months</asp:ListItem>
										<asp:ListItem Value="9">9 Months</asp:ListItem>
										<asp:ListItem Value="10">10 Months</asp:ListItem>
										<asp:ListItem Value="11">11 Months</asp:ListItem>
										<asp:ListItem Value="12">12 Months</asp:ListItem>
									</asp:DropDownList>
									<FONT color="#ff0000">*</FONT></TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">
									<DIV align="left">
										<asp:Label id="Label1" runat="server"></asp:Label></DIV>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">
									<DIV align="center"><INPUT id="Submit1" type="submit" value="Next>>>" name="Submit" runat="server">
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD height="24">&nbsp;</TD>
								<TD height="24">&nbsp;</TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
								<TD height="20">&nbsp;</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td colspan="3">
						<uc1:bottom id="Bottom1" runat="server"></uc1:bottom></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
