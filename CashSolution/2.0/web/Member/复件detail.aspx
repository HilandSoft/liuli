<%@ Page language="c#" Codebehind="detail.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.detail" %>
<%@ Register TagPrefix="uc1" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top1" Src="top1.ascx" %>
<HTML>
	<HEAD>
		<title>detail</title> 
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
		<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
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
						<table cellSpacing="0" cellPadding="0" width="504" border="0">
							<tr>
								<td>
									<p><strong>Please make sure these are always kept up to date. </strong><strong>If you 
											have any problems updating this information, please contact us at 1300 137 906. </strong>
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
									<table cellSpacing="0" cellPadding="0" width="496" border="0" style="WIDTH: 496px; HEIGHT: 129px">
										<tr>
											<td style="WIDTH: 132px" width="132">First Name:</td>
											<td style="WIDTH: 118px" width="118"><input id="txFname" type="text" size="10" name="textfield26" runat="server" readOnly>
												<FONT face="???" color="#990000">*</FONT></td>
											<td style="WIDTH: 91px" width="91">Middle Name:</td>
											<td width="106">
												<INPUT id="txMname" type="text" size="10" name="textfield262" runat="server" readOnly>
											</td>
										</tr>
										<tr>
											<td style="WIDTH: 132px">Last Name:</td>
											<td style="WIDTH: 118px">
												<input id="txLname" type="text" size="10" name="textfield27" runat="server" readOnly>
												<FONT face="???" color="#990000">*</FONT>
											</td>
											<td style="WIDTH: 91px">Customer No:</td>
											<td><input id="txNo" type="text" size="10" name="textfield27" runat="server" readOnly></td>
										</tr>
										<tr>
											<td style="WIDTH: 132px">Date of Birth:</td>
											<td style="WIDTH: 118px"><input id="txDate" type="text" size="10" name="textfield29" runat="server" readOnly>
												<FONT face="???" color="#990000">*</FONT></td>
											<td style="WIDTH: 91px">E-Mail:
											</td>
											<td><input id="txEmail" type="text" size="10" name="textfield28" runat="server"> <FONT face="???" color="#990000">
													*</FONT></td>
										</tr>
										<tr>
											<td style="WIDTH: 132px">Driver Licence Number:</td>
											<td style="WIDTH: 118px"><FONT face="???"><INPUT id="txDriver" type="text" size="10" name="textfield28" runat="server">
												</FONT>
											</td>
											<td style="WIDTH: 91px">State Issued:</td>
											<td><FONT face=""><FONT face="???"><INPUT id="txIssue" type="text" size="10" name="textfield29" runat="server"></FONT></FONT></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>
									<table cellSpacing="0" cellPadding="0" width="397" border="0">
										<tr>
											<td width="116">
												Home&nbsp;Address:</td>
											<td colSpan="3"><input id="txResident" type="text" size="20" name="textfield2622" runat="server"></td>
										</tr>
										<tr>
											<td>Street&nbsp;:</td>
											<td colSpan="3"><input id="txStreet" type="text" size="20" name="textfield2622" runat="server">
												<FONT face="???" color="#990000">*</FONT></td>
										</tr>
										<tr>
											<td>Suburb:</td>
											<td style="WIDTH: 80px" width="80"><input id="txCity" type="text" size="9" name="textfield292" runat="server"><FONT face="???" color="#990000">*</FONT></td>
											<td style="WIDTH: 104px" width="104" colSpan="2">&nbsp;&nbsp; State:&nbsp;
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
											<td style="WIDTH: 198px" colSpan="2">Time at this address:</td>
											<td colSpan="2"><SELECT id="txYear" name="select2" runat="server"><OPTION value="1" selected>1</OPTION>
													<OPTION value="2">2</OPTION>
													<OPTION value="3">3</OPTION>
													<OPTION value="4">4</OPTION>
													<OPTION value="5">5</OPTION>
													<OPTION value="6">6</OPTION>
													<OPTION value="7">7</OPTION>
													<OPTION value="8">8</OPTION>
													<OPTION value="9">9</OPTION>
													<OPTION value="10">10</OPTION>
													<OPTION value="11">11</OPTION>
													<OPTION value="12">12 or above</OPTION>
												</SELECT>Years
												<SELECT id="txMonth" name="select2" runat="server">
													<OPTION value="1" selected>1</OPTION>
													<OPTION value="2">2</OPTION>
													<OPTION value="3">3</OPTION>
													<OPTION value="4">4</OPTION>
													<OPTION value="5">5</OPTION>
													<OPTION value="6">6</OPTION>
													<OPTION value="7">7</OPTION>
													<OPTION value="8">8</OPTION>
													<OPTION value="9">9</OPTION>
													<OPTION value="10">10</OPTION>
													<OPTION value="11">11</OPTION>
													<OPTION value="12">12</OPTION>
												</SELECT>Months</td>
										</tr>
										<tr>
											<td style="WIDTH: 198px" colSpan="2">Home Phone Number:</td>
											<td colSpan="2"><input id="txTel" type="text" size="10" name="textfield282" runat="server">
												<FONT face="???" color="#990000">*</FONT></td>
										</tr>
										<tr>
											<td style="WIDTH: 198px" colSpan="2">Mobile:</td>
											<td colSpan="2"><input id="txMobile" type="text" size="10" name="textfield282" runat="server">
												<FONT face="???" color="#990000"></FONT>
											</td>
										</tr>
										<tr>
											<td style="WIDTH: 198px" colSpan="2">Fax:</td>
											<td colSpan="2"><input id="txFax" type="text" size="10" name="textfield282" runat="server"><FONT face="???" color="#990000"></FONT></td>
										</tr>
										<tr>
											<td colSpan="2">&nbsp;</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><FONT face="">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</FONT><input id="Submit1" type="submit" value="Save" name="Submit" runat="server"><FONT face="">&nbsp;&nbsp;&nbsp;
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
