<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<%@ Page language="c#" Codebehind="ReferFriend.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.ReferFriend" %>
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<script language="javascript" src="../jslib/commCheck.js" type="text/javascript"></script>
			<style type="text/css">
.word1 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
.word2 { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
.word3 { FONT-WEIGHT: bold; FONT-SIZE: 14px; COLOR: #000000; TEXT-DECORATION: none }
</style>
	</HEAD>
	<body LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table width="100%" border="0" cellspacing="0" cellpadding="0" align="center">
				<tr>
					<td>
						<uc1:head id="Head1" runat="server"></uc1:head>
					</td>
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
											<td width="17%" height="20"><div align="center"></div>
											</td>
											<td width="83%" class="word2">Member Login
											</td>
										</tr>
										<tr>
											<td height="20"><div align="center"></div>
											</td>
											<td class="word2">Privacy Policy</td>
										</tr>
										<tr>
											<td height="20"><div align="center"></div>
											</td>
											<td class="word2">
												Comparison Rate
											</td>
										</tr>
										<tr>
											<td height="20"><div align="center"></div>
											</td>
											<td class="word2">Contact Us</td>
										</tr>
										<tr>
											<td height="20">&nbsp;
												<DIV></DIV>
											</td>
											<td class="word2">Calculator</td>
										</tr>
										<tr>
											<td height="20">&nbsp;
												<DIV></DIV>
											</td>
											<td class="word2">FAQs</td>
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
							<TR bgcolor="#cc3300">
								<TD height="30"><img src="images/referfriend.gif" width="400" height="30"></TD>
							</TR>
							<tr>
								<td colspan="2" height="10"></td>
							</tr>
							<TR>
								<TD>
									<table width="100%" border="0" cellspacing="0" cellpadding="8">
										<tr>
											<td><p><strong>Friend referential </strong>
												</p>
												<p><strong>In addition to helping your friends save a bundle on their loans with Golden 
														Bridge Cash Solution, you can earn a bundle with unlimited referral bonuses! </strong>
													<br>
													<br>
													<br>
													When you become a member, you will be eligible as a referee. When your friend 
													quotes your member ID in their application, your friend will get a lower 
													interest rate and you will get a bonus of $50. For every friend, who 
													successfully applied for a loan, we'll give you credit by depositing directly 
													into your nominated bank account. They'll be happy, and you'll be happy.
												</p>
												<p class="word3">&nbsp;</p>
											</td>
										</tr>
									</table>
								</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
				<tr>
					<td colspan="3"><uc1:bottom id="Bottom1" runat="server"></uc1:bottom></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
