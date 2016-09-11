<%@ Page language="c#" Codebehind="Login.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Login" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<script language="javascript" src="../jslib/commCheck.js" type="text/javascript"></script>
			<script language="javascript">
		function  CheckFeedback() {
		var ftxUsername=document.getElementById("txUsername");
		var ftxPwd=document.getElementById("txPwd");
		
		if(!chkNull(ftxUsername.value)) {
		alert(" Field 'Username' under 'Login' is not valid!");
		ftxUsername.focus();
		return false;
		}
		
		if(!chkNull(ftxPwd.value)) {
		alert(" Field 'Password' under 'Login' is not valid!");
		ftxPwd.focus();
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
                                      <td width="17%" height="20"><div align="center"><img src="images/1_04.gif" width="16" height="10"></div></td>
                                      <td width="83%" class="word1">Member Login </td>
                                    </tr>
                                    <tr>
                                      <td height="20"><div align="center"></div></td>
                                      <td class="word2">Privacy Policy</td>
                                    </tr>
                                    <tr>
                                      <td height="20"><div align="center"></div></td>
                                      <td class="word2"> Comparison Rate </td>
                                    </tr>
                                    <tr>
                                      <td height="20"><div align="center"></div></td>
                                      <td class="word2">Contact Us</td>
                                    </tr>
                                    <tr>
                                      <td height="20">&nbsp;
                                          <DIV></DIV></td>
                                      <td class="word2">Calculator</td>
                                    </tr>
                                    <tr>
                                      <td height="20">&nbsp;
                                          <DIV></DIV></td>
                                      <td class="word2">FAQs</td>
                                    </tr>
                                  </table></td>
							</tr>
							<tr>
								<td>
									<img src="images/1_09.gif" width="190" height="5" alt=""></td>
							</tr>
							<tr>
								<td align=center><br>
									<img src="images/contact2.gif" width="160" height="106" alt=""></td>
							</tr>
						</table>
					</td>
					<td valign="top">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR bgcolor="#cc3300">
								<TD height="30"><img src="images/login.gif" width="400" height="30"></TD>
							</TR>
							<TR>
								<TD height="20" align="center"><table width="95%" border="0" cellpadding="1" cellspacing="2">
										<tr>
											<td colspan="2">&nbsp;</td>
										</tr>
										<tr>
											<td width="40%" align=right>Username:</td>
											<td><input name="textfield23" type="text" style="WIDTH:200px;HEIGHT:22px" id="txUsername" runat="server"></td>
										</tr>
										<tr>
											<td align=right>Password:</td>
											<td><input name="textfield24" type="password" style="WIDTH:200px;HEIGHT:22px" id="txPwd" runat="server"></td>
										</tr>
										<tr>
											<td colspan="2" align="center">
												<input type="submit" name="Submit2" value="Submit" id="Submit1" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
												&nbsp; <input type="reset" name="Submit2" value="Reset"></td>
										</tr>
									</table>
								</TD>
							</TR>
							<TR>
								<TD height="20">
									<DIV align="center"></DIV>
								</TD>
							</TR>
							<TR>
								<TD height="20">
									<DIV align="center">
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD width="45%" height="24">&nbsp;</TD>
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
