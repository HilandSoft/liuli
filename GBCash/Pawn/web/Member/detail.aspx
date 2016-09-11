<%@ Page language="c#" Codebehind="detail.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.detail" %>
<%@ Register TagPrefix="uc1" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top1" Src="top1.ascx" %>
<HTML>
	<HEAD>
		<title>detail</title> 
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body>
		<form id="Form1" method="post" runat="server">
			<table width="750" border="0" align="center" cellpadding="0" cellspacing="0" height="100%">
				<tr>
					<td colspan="2" style="HEIGHT: 27px"><FONT face="">
							<uc1:top1 id="Top11" runat="server"></uc1:top1></FONT>
					</td>
				</tr>
				<tr>
					<td valign="top" width="195" align="left" bgcolor="#e8e6df">
						<uc1:leftmenu id="Leftmenu1" runat="server"></uc1:leftmenu>
					</td>
					<td width="556" align="center">
						<table cellSpacing="0" cellPadding="0" width="95%" border="0">
							<tr>
								<td>
									<p><strong>Please make sure these are always kept up to date. </strong><strong>If you 
											have any problems updating this information, please contact us at 1300 137 906 </strong>
									</p>
								</td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>Member Information <INPUT id="Hidden1" style="WIDTH: 40px; HEIGHT: 21px" type="hidden" size="1" name="Hidden1"
										runat="server">
								</td>
							</tr>
							<tr>
								<td>
									<table cellSpacing="0" cellPadding="0" border="0" style="WIDTH: 100%; HEIGHT: 129px">
										
										<tr>
											<td style="WIDTH: 25%" width="136">First Name:</td>
											<td style="WIDTH: 30%" width="124"><input id="txFname" type="text" size="15" name="textfield26" runat="server" readOnly>
												<FONT face="???" color="#990000">*</FONT></td>
											<td>Last Name:</td>
											<td>
												<input id="txLname" type="text" size="15" name="textfield27" runat="server" readOnly>
												<FONT face="???" color="#990000">*</FONT>
											</td>
										</tr>
										<tr>
											<td>Customer No:</td>
											<td><input id="txNo" type="text" size="15" name="textfield27" runat="server" readOnly></td>
										</tr>
										<tr>
											<td>Date of Birth:</td>
											<td><input id="txDate" type="text" size="15" name="textfield29" runat="server" readOnly>
												<FONT face="???" color="#990000">*</FONT></td>
											<td>E-Mail:
											</td>
											<td><input id="txEmail" type="text" size="15" name="textfield28" runat="server"> <FONT face="???" color="#990000">
													*</FONT></td>
										</tr>
										<tr>
											<td>Driver Licence Number:</td>
											<td><FONT face="???"><INPUT id="txDriver" type="text" size="15" name="textfield28" runat="server">
												</FONT>
											</td>
											<td>State Issued:</td>
											<td><FONT face=""><FONT face="???"><INPUT id="txIssue" type="text" size="15" name="textfield29" runat="server"></FONT></FONT></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table cellSpacing="0" cellPadding="0" width="95%" border="0">
										<tr>
											<td width="142">
												Address:</td>
											<td colSpan="3"><input id="txResident" type="text" size="20" name="textfield2622" runat="server"></td>
											<td>City:</td>
											<td style="WIDTH: 80px" width="80"><input id="txCity" type="text" size="9" name="textfield292" runat="server"><FONT face="???" color="#990000">*</FONT></td>
											<td style="WIDTH: 104px" width="280" colSpan="2">&nbsp;&nbsp; State:&nbsp;
												<SELECT id="selState" name="select2" runat="server">
													<OPTION value="ACT" selected>ACT</OPTION>
													<OPTION value="QLD">QLD</OPTION>
													<OPTION value="NSW">NSW</OPTION>
													<OPTION value="NT">NT</OPTION>
													<OPTION value="SA">SA</OPTION>
													<OPTION value="TAS">TAS</OPTION>
													<OPTION value="VIC">VIC</OPTION>
													<OPTION value="WA">WA</OPTION>
												</SELECT></td>
										</tr>
										<tr>
											<td>Postcode:</td>
											<td colSpan="3"><input id="txPost" type="text" size="20" name="textfield2623" runat="server"><FONT face="???" color="#990000">*</FONT></td>
										</tr>
										<tr>
											<td colSpan="4">&nbsp;</td>
										</tr>
										
										<tr>
											<td style="WIDTH: 198px" colSpan="2">Phone Number:</td>
											<td colSpan="2"><input id="txTel" type="text" size="10" name="textfield282" runat="server">
												<FONT face="???" color="#990000">*</FONT></td>
										</tr>
										
										<tr>
											<td colSpan="2">&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td align="center"><input id="Submit1" type="submit" value="Save" name="Submit" runat="server"><FONT face="">&nbsp;&nbsp;&nbsp;
									</FONT><input type="reset" value="Reset" name="Submit2"></td>
							</tr>
							<tr>
								<td>&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
			&nbsp;</form>
	</body>
</HTML>
