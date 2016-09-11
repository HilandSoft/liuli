<%@ Page language="c#" Codebehind="StepWarning.aspx.cs" AutoEventWireup="false" Inherits="PLCash.StepWarning" %>
<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="Root/CSS/css.css" type="text/css" rel="stylesheet">
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
		<style type="text/css">
				.word1 { COLOR: #cc3300; FONT-SIZE: 12px; FONT-WEIGHT: bold; TEXT-DECORATION: none }
				.word2 { COLOR: #cc3300; FONT-SIZE: 12px; TEXT-DECORATION: none }
				.warningData { FONT-FAMILY: "Arial"; FONT-SIZE: 12pt; FONT-WEIGHT: bold }
				.a10 { FONT-FAMILY: "Arial"; FONT-SIZE: 10pt }
				.a8 { FONT-FAMILY: "Arial"; FONT-SIZE: 8pt }
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
											<td width="17%" height="20"><div align="center"><img src="images/1_04.gif" width="16" height="10"></div>
											</td>
											<td width="83%" class="word1">Apply Now
											</td>
										</tr>
										<tr>
											<td height="20">&nbsp;</td>
											<td class="word2">Initial loan information</td>
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
					<td valign="top">
						<TABLE cellSpacing="0" cellPadding="0" width="100%" border="0">
							<TR bgcolor="#cc3300">
								<TD height="30" colSpan="2"><img src="images/step0.gif" width="400" height="30"></TD>
							</TR>
							<tr>
								<td colspan="2" height="10"></td>
							</tr>
							<TR>
								<TD colSpan="2"><span class="a10"><b>Warning about small amount credit contracts - warning 
											on websites</b> (subparagraph 28XXB (d) (i))</span><br>
									<br>
									<span class="a10"><b><img src="images/warning.gif">Do you really need a loan today?*</b></span><br>
									<span class="a10">It can be expensive to borrow small amounts of money and 
										borrowing may not solve your money problems.</span><br>
									<br>
									<span class="a10">Check your options before you borrow:</span><br>
									<span class="a10">. For information about other options for managing bills and 
										debts, ring 1800 007 007 from anywhere in Australia to talk to a free and 
										independent financial counsellor</span><br>
									<span class="a10">. Talk to your electricity, gas, phone or water provider to see 
										if you can work out a payment plan</span><br>
									<span class="a10">. If you are on government benefits, ask if you can receive an 
										advance from Centrelink: Phone: 13 17 94</span><br>
									<br>
									<span class="a10">The Government's MoneySmart website shows you how small amount 
										loans work and suggests other options that may help you.</span><br>
									<br>
									<span class="a8">* This statement is an Australian Government requirement under the 
										National Consumer Credit Protection Act 2009.</span>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">
									<DIV align="center"></DIV>
								</TD>
							</TR>
							<TR>
								<TD colSpan="2" height="20">
									<DIV align="center">
										<INPUT id="Submit1" type="submit" value="Next>>>" name="Submit" runat="server">
									</DIV>
								</TD>
							</TR>
							<TR>
								<TD width="55%" height="24">&nbsp;</TD>
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
