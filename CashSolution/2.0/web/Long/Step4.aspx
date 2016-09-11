<%@ Page language="c#" Codebehind="Step4.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Step4" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<script language="javascript" src="../jslib/commCheck.js" type="text/javascript"></script>
			<script language="javascript">
			
		function  CheckFeedback() {		
		var ftxBranch=document.getElementById("txBranch");
		var ftxBank=document.getElementById("txBank");
		var ftxAname=document.getElementById("txAname");
		var ftxBsb=document.getElementById("txBsb");
		var ftxAnumber=document.getElementById("txAnumber");
		var ftxCAnumber=document.getElementById("txCAnumber");
			
		
		if(!chkNull(ftxBank.value)) {
		alert(" Field 'Bank Name' under 'Bank Information' is not valid!");
		ftxBank.focus();
		return false;
		}
		
		if(!chkNull(ftxBranch.value)) {
		alert(" Field 'Branch' under 'Bank Information' is not valid!");
		ftxBranch.focus();
		return false;
		}
		
		if(!chkNull(ftxAname.value)) {
		alert(" Field 'Account Name' under 'Bank Information' is not valid!");
		ftxAname.focus();
		return false;
		}
		
		if(!chkNull(ftxBsb.value)) {
		alert(" Field 'BSB' under 'Bank Information' is not valid!");
		ftxBsb.focus();
		return false;
		}
		
		if(!chkNull(ftxAnumber.value)) {
		alert(" Field 'Bank Account Number' under 'Bank Information' is not valid!");
		ftxAnumber.focus();
		return false;
		}
		
		if(!chkNull(ftxCAnumber.value)) {
		alert(" You must confirm your account number by re-typing it!");
		ftxCAnumber.focus();
		return false;
		}
		
		if(ftxAnumber.value!=ftxCAnumber.value)  {
		alert(" You must confirm your account number by re-typing it!");
		ftxCAnumber.focus();
		return false;
		}		
			
		return true;
		}	
			</script>
	        <style type="text/css">
<!--
.word1 {font-size: 12px;
	font-weight: bold;
	color: #CC3300;
	text-decoration: none;
}
.word2 {font-size: 12px;
	color: #CC3300;
	text-decoration: none;
}
-->
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
                          <td> <img src="images/1_01.gif" width="190" height="18" alt=""></td>
                        </tr>
                        <tr>
                          <td background="images/1_07.gif">
                            <table width="100%"  border="0" cellspacing="0" cellpadding="0">
										<tr>
										  <td height="20">&nbsp;</td>
										  <td class="word2">Pre-qualification</td>
									  </tr>
                              <tr>
                                <td width="17%" height="20"><div align="center"></div></td>
                                <td width="83%" class="word2">Apply Now </td>
                              </tr>
                              <tr>
                                <td height="20"><div align="center"></div></td>
                                <td class="word2">Initial loan information</td>
                              </tr>
                              <tr>
                                <td height="20"><div align="center"></div></td>
                                <td class="word2">About yourself</td>
                              </tr>
                              <tr>
                                <td height="20"><div align="center"></div></td>
                                <td class="word2">About your work</td>
                              </tr>
                              <tr>
                                <td height="20"><div align="center"><img src="images/1_04.gif" width="16" height="10"></div></td>
                                <td class="word1">Your bank details</td>
                              </tr>
                              <tr>
                                <td height="20">&nbsp;</td>
                                <td class="word2">Application summary</td>
                              </tr>
                              <tr>
                                <td height="20">&nbsp;</td>
                                <td class="word2">Submit application</td>
                              </tr>
                          </table></td>
                        </tr>
                        <tr>
                          <td> <img src="images/1_09.gif" width="190" height="5" alt=""></td>
                        </tr>
							<tr>
								<td align=center><br>
									<img src="images/contact2.gif" width="160" height="106" alt=""></td>
							</tr>
                      </table></td>
					<td valign="top"><table width="100%" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td height="40" colspan="2" bgcolor="#CC3300"><img src="images/step4.gif" width="400" height="30">
								  <asp:TextBox id="txLoanSid" runat="server" Width="6px" Visible="False"></asp:TextBox>
								</td>
							</tr>
							<tr>
								<td height="30" colspan="2"><strong><br>
							    This must be the account where your pay is 
										paid into.
										
										</strong></td>
							</tr>
							<tr>
							<td height=30 colspan=2><b>This is the account we will credit to and deduct from.</b></td>
							</tr>
							<tr>
								<td colspan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td width=15% height=30>
												Bank Name:
											</td>
											<td><INPUT id="txBank" type="text" style="width:150" name="textfield2924332" runat="server">
												<FONT color="#ff0000">*</FONT></td>
											<td width=15%>
												Branch:
											</td>
											<td><INPUT id="txBranch" type="text" style="width:150" name="textfield29243322" runat="server">
												<FONT color="#ff0000">*</FONT></td>
										</tr>
										<tr>
											<td height=30>
												Account Name:
											</td>
											<td colspan="3"><INPUT id="txAname" type="text" style="width:150" name="textfield29243323" runat="server">
												<FONT color="#ff0000">*</FONT></td>
										</tr>
										<tr>
											<td height=30>
												BSB:
											</td>
											<td><INPUT id="txBsb" type="text" style="width:150" name="textfield29243324" runat="server">
												<FONT color="#ff0000">*</FONT></td>
											<td>
												Account Number:
											</td>
											<td><INPUT id="txAnumber" type="text" style="width:150" name="textfield29243325" runat="server">
												<FONT color="#ff0000">*</FONT></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td width="20%" height="30">
									Confirm Account Number:
								</td>
								<td><INPUT id="txCAnumber" type="text" style="width:150" name="textfield292433232" runat="server">
									<FONT color="#ff0000">*</FONT></td>
							</tr>
							<tr>
								<td height="30" colspan="2">
									Preferred methods of contact for this loan:
								</td>
							</tr>
							<tr>
								<td colspan="2">
									<asp:RadioButtonList id="RadioButtonList1" runat="server" RepeatDirection="Horizontal" Width="368px">
										<asp:ListItem Value="Email" Selected="True">Email</asp:ListItem>
										<asp:ListItem Value="Mobile">Mobile</asp:ListItem>
										<asp:ListItem Value="Home Phone">Home Phone</asp:ListItem>
										<asp:ListItem Value="Work Phone">Work Phone</asp:ListItem>
									</asp:RadioButtonList></td>
							</tr>
							<tr>
								<td height="20" colspan="2">&nbsp;</td>
							</tr>
							<tr>
								<td height="30" colspan="2"><div align="center">
										<input id="Submit1" type="submit" value="Next>>>" name="Submit" runat="server">
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
				  <td colspan="2">&nbsp;</td>
			  </tr>
				<tr>
					<td colspan="3">
						<uc1:bottom id="Bottom1" runat="server"></uc1:bottom></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
