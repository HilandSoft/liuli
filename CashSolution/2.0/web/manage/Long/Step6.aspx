<%@ Page language="c#" Codebehind="Step6.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Step6" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
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
											<td height="20"><div align="center"></div>
											</td>
											<td class="word2">Initial loan information</td>
										</tr>
										<tr>
											<td height="20"><div align="center"></div>
											</td>
											<td class="word2">About yourself</td>
										</tr>
										<tr>
											<td height="20"><div align="center"></div>
											</td>
											<td class="word2">About your work</td>
										</tr>
										<tr>
											<td height="20"><div align="center"></div>
											</td>
											<td class="word2">Your bank details</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Application summary</td>
										</tr>
										<tr>
											<td height="20"><div align="center"><img src="images/1_04.gif" width="16" height="10"></div>
											</td>
											<td class="word1">Submit application</td>
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
					<td valign="top">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR>
								<TD colSpan="2" height="30" bgcolor="#cc3300"><img src="images/step6.gif" width="400" height="30">
									<asp:TextBox id="txPerSid" runat="server" Visible="False" Width="56px"></asp:TextBox></TD>
							</TR>
							<tr>
								<td colspan="2" height="15"></td>
							</tr>
							<TR>
								<TD colSpan="2">
									I have read and understand the particulars which have been completed in this 
									form and state that those particulars are true, complete and correct and have 
									been provided to the Golden Bridge to enable it to determine whether or not to 
									provide to me a Loan for which I hereby make formal application.
								</TD>
							</TR>
							<TR>
								<TD colSpan="2">I acknowledge and agree that the Golden Bridge may contact my 
									employer, accountant and if applicable landlord/real estate agent and other 
									referee to verify details which I have provided on this form.</TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">
									<DIV align="center"></DIV>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">
									<DIV align="center">
										<asp:CheckBox id="CheckBox1" runat="server" Text="I Agree" AutoPostBack="True"></asp:CheckBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<INPUT id="Submit1" type="submit" value="Submit Application" name="Submit" runat="server">
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD width="55%">&nbsp;</TD>
								<TD width="45%" height="20">&nbsp;</TD>
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
