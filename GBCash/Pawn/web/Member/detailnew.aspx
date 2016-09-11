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
		<TABLE border="0" cellSpacing="0" cellPadding="0" width="579" height="961" ms_2d_layout="TRUE">
			<TR vAlign="top">
				<TD height="961" width="579">
					<form id="Form1" method="post" runat="server">
						<TABLE border="0" cellSpacing="0" cellPadding="0" width="890" height="577" ms_2d_layout="TRUE">
							<TR vAlign="top">
								<TD height="577" width="139"></TD>
								<TD width="751">
									<table width="750" border="0" align="center" cellpadding="0" cellspacing="0" height="576">
										<tr>
											<td colspan="2" height="27"><FONT face="���">
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
														<TD><strong>Member Information</strong> <INPUT id="Hidden1" type="hidden" size="1" name="Hidden1" runat="server">
														</TD>
													</TR>
													<TR>
														<TD>
															<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="488" border="0">
																<TR>
																	<TD width="167">First Name:</TD>
																	<TD width="118"><INPUT id="txFname" size="10" name="textfield26" runat="server" readOnly>
																		<FONT color="#990000">*</FONT></TD>
																	<TD width="167">Last Name:</TD>
																	<TD width="118">
																		<INPUT id="txLname" size="10" name="textfield27" runat="server" readOnly> <FONT face="??��?" color="#990000">
																			*</FONT>
																	</TD>
																</TR>
																<TR>
																	<TD width="167">Postcode:</TD>
																	<TD><INPUT id="txPost" name="textfield2623" runat="server"><FONT color="#990000">*</FONT></TD>
																	<TD>E-Mail:
																	</TD>
																	<TD><INPUT id="txEmail" size="10" name="textfield28" runat="server"> <FONT  color="#990000">
																			*</FONT></TD>
																</TR>
																<TR>
																	<TD width="167">Driver Licence Number:</TD>
																	<TD width="118">
																		<INPUT id="txDriver" size="10" name="textfield28" runat="server">
																	</TD>
																	<TD width="91">State Issued:</TD>
																	<TD><INPUT id="txIssue" size="10" name="textfield29" runat="server">
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
																		Address:</TD>
																	<TD colSpan="3"><INPUT id="txStreet" name="textfield2622" runat="server"></TD>
																</TR>
																<TR>
																	<TD>City:</TD>
																	<TD width="80"><INPUT id="txCity" size="9" name="textfield292" runat="server"><FONT face="??��?" color="#990000">*</FONT></TD>
																	<TD width="104" colSpan="2">&nbsp;&nbsp; State:&nbsp;
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
																	<TD colSpan="2" width="198">Phone Number:</TD>
																	<TD colSpan="2"><INPUT id="txTel" size="10" name="textfield282" runat="server"> <FONT face="??��?" color="#990000">
																			*</FONT></TD>
																</TR>
																<TR>
																	<TD colSpan="2">&nbsp;</TD>
																</TR>
															</TABLE>
														</TD>
													</TR>
													<TR>
														<TD><FONT face="���">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
															</FONT><INPUT id="Submit1" type="submit" value="Save" name="Submit" runat="server"><FONT face="����">&nbsp;&nbsp;&nbsp;
															</FONT><INPUT type="reset" value="Reset" name="Submit2"><FONT face="����">&nbsp; <A href="newloan.aspx">
																	return</A></FONT></TD>
													</TR>
													<TR>
														<TD>&nbsp;</TD>
													</TR>
												</TABLE>
											</td>
										</tr>
									</table>
								</TD>
							</TR>
						</TABLE>
					</form>
				</TD>
			</TR>
		</TABLE>
	</body>
</HTML>
