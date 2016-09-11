<%@ Register TagPrefix="uc1" TagName="top1" Src="top1.ascx" %>
<%@ Register TagPrefix="uc1" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Page language="c#" Codebehind="detailnew.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.detailnew" %>
<%@ Register TagPrefix="uc1" TagName="top4" Src="top4.ascx" %>
<HTML>
	<HEAD>
		<title>detailnew</title> 
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table width="750" border="0" align="center" cellpadding="0" cellspacing="0" height="100%">
				<tr>
					<td colspan="2" style="HEIGHT: 27px"><FONT face="宋体">
							<uc1:top4 id="Top41" runat="server"></uc1:top4></FONT>
					</td>
				</tr>
				<tr>
					<td valign="top" width="195" align="left" bgcolor="#e8e6df">
						<uc1:leftmenu id="Leftmenu1" runat="server"></uc1:leftmenu>
					</td>
					<td width="556" align="center">
						<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="504" border="0">
							<TR>
								<TD>&nbsp;</TD>
							</TR>
							<TR>
								<TD><strong>Member Information</strong> <INPUT id="Hidden1" style="WIDTH: 40px; HEIGHT: 21px" type="hidden" size="1" name="Hidden1"
										runat="server">
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="488" border="0" style="WIDTH: 488px; HEIGHT: 132px">
										<TR>
											<TD style="WIDTH: 167px" width="167">First Name:</TD>
											<TD style="WIDTH: 118px" width="118"><INPUT id="txFname" type="text" size="10" name="textfield26" runat="server" readOnly>
												<FONT face="??ì?" color="#990000">*</FONT></TD>
											<TD style="WIDTH: 91px" width="91">Middle Name:</TD>
											<TD width="106">
												<INPUT id="txMname" type="text" size="10" name="textfield262" runat="server" readOnly>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 167px">Last Name:</TD>
											<TD style="WIDTH: 118px">
												<INPUT id="txLname" type="text" size="10" name="textfield27" runat="server" readOnly>
												<FONT face="??ì?" color="#990000">*</FONT>
											</TD>
											<TD style="WIDTH: 91px">&nbsp;</TD>
											<TD>&nbsp;</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 167px">Date of Birth:</TD>
											<TD style="WIDTH: 118px"><INPUT id="txDate" type="text" size="10" name="textfield29" runat="server" readOnly>
												<FONT face="??ì?" color="#990000">*</FONT></TD>
											<TD style="WIDTH: 91px">E-Mail:
											</TD>
											<TD><INPUT id="txEmail" type="text" size="10" name="textfield28" runat="server"> <FONT face="??ì?" color="#990000">
													*</FONT></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 167px">Driver Licence Number:</TD>
											<TD style="WIDTH: 118px">
												<INPUT id="txDriver" type="text" size="10" name="textfield28" runat="server">
											</TD>
											<TD style="WIDTH: 91px">State Issued:</TD>
											<TD><INPUT id="txIssue" type="text" size="10" name="textfield29" runat="server">
											</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD>
									<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="397" border="0">
										<TR>
											<TD width="116">
												Home&nbsp;Address:</TD>
											<TD colSpan="3"><INPUT id="txResident" type="text" size="20" name="textfield2622" runat="server"></TD>
										</TR>
										<TR>
											<TD>Street&nbsp;:</TD>
											<TD colSpan="3"><INPUT id="txStreet" type="text" size="20" name="textfield2622" runat="server">
												<FONT face="??ì?" color="#990000">*</FONT></TD>
										</TR>
										<TR>
											<TD>Suburb:</TD>
											<TD style="WIDTH: 80px" width="80"><INPUT id="txCity" type="text" size="9" name="textfield292" runat="server"><FONT face="??ì?" color="#990000">*</FONT></TD>
											<TD style="WIDTH: 104px" width="104" colSpan="2">&nbsp;&nbsp; State:&nbsp;
												<SELECT id="selState" name="select2" runat="server">
													<OPTION value="ACT" selected>ACT</OPTION>
													<OPTION value="QLD">QLD</OPTION>
													<OPTION value="NSW">NSW</OPTION>
													<OPTION value="NT">NT</OPTION>
													<OPTION value="SA">SA</OPTION>
													<OPTION value="TAS">TAS</OPTION>
													<OPTION value="VIC">VIC</OPTION>
													<OPTION value="WA">WA</OPTION>
												</SELECT></TD>
										</TR>
										<TR>
											<TD>Postcode:</TD>
											<TD colSpan="3"><INPUT id="txPost" type="text" size="20" name="textfield2623" runat="server"><FONT face="??ì?" color="#990000">*</FONT></TD>
										</TR>
										<TR>
											<TD colSpan="4"><BR>
											</TD>
										</TR>
										<tr>
											<td style="WIDTH: 198px" colSpan="2">Time at this address:</td>
											<td colSpan="2"><SELECT id="txYear" name="select2" runat="server">
										<OPTION value="0" selected>0</OPTION>
										<OPTION value="1">1</OPTION>
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
										<OPTION value="0" selected>0</OPTION>
										<OPTION value="1">1</OPTION>
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
										<TR>
											<TD style="WIDTH: 198px" colSpan="2">Home Phone Number:</TD>
											<TD colSpan="2"><INPUT id="txTel" type="text" size="10" name="textfield282" runat="server">
												<FONT face="??ì?" color="#990000">*</FONT></TD>
										</TR>
										<TR>
											<TD style="WIDTH: 198px" colSpan="2">Mobile:</TD>
											<TD colSpan="2"><INPUT id="txMobile" type="text" size="10" name="textfield282" runat="server">
												<FONT face="??ì?" color="#990000"></FONT>
											</TD>
										</TR>
										<TR>
											<TD style="WIDTH: 198px" colSpan="2">Fax:</TD>
											<TD colSpan="2"><INPUT id="txFax" type="text" size="10" name="textfield282" runat="server"><FONT face="??ì?" color="#990000"></FONT></TD>
										</TR>
										<TR>
											<TD colSpan="2">&nbsp;</TD>
										</TR>
									</TABLE>
								</TD>
							</TR>
							<TR>
								<TD><FONT face="宋体">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
									</FONT><INPUT id="Submit1" type="submit" value="Save" name="Submit" runat="server"><FONT face="宋体">&nbsp;&nbsp;&nbsp;
									</FONT><INPUT type="reset" value="Reset" name="Submit2"><FONT face="宋体">&nbsp; <A href="newloan.aspx">
											return</A></FONT></TD>
							</TR>
							<TR>
								<TD>&nbsp;</TD>
							</TR>
						</TABLE>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
