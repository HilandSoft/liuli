<%@ Page language="c#" Codebehind="index.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.index" %>
<HTML>
	<HEAD>
		<TITLE>WebSite</TITLE>
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<BODY BGCOLOR="#1865c6" LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form runat="server" method="post">
			<table width="100%" height="100%" border="0" cellpadding="0" cellspacing="0">
				<tr>
					<td align="center" valign="middle"><table width="604" border="0" cellspacing="0" cellpadding="0">
							<tr>
								<td align="center"><img src="images/logo_yingnet_text.gif" width="307" height="28"></td>
							</tr>
							<tr>
								<td><TABLE WIDTH="604" BORDER="0" CELLPADDING="0" CELLSPACING="0">
										<TR>
											<TD>
												<IMG SRC="images/title_login_1.gif" WIDTH="492" HEIGHT="11" ALT=""></TD>
											<TD ROWSPAN="3">&nbsp;
											</TD>
										</TR>
										<TR>
											<TD>
												<table width="491" height="192" border="0" cellpadding="0" cellspacing="0">
													<tr>
														<td background="images/title_bg.gif"><div align="center">
																<table width="96%" border="0" cellspacing="0" cellpadding="0">
																	<tr>
																		<td width="35%" valign="top">
																			<div align="center"><img src="images/logo_yingnet.gif" width="94" height="73"></div>
																		</td>
																		<td width="65%"><div align="center">
																				<TABLE cellSpacing="2" cellPadding="5" width="98%" border="0" style="FONT-SIZE:9pt">
																					<TBODY>
																						<TR>
																							<TD width="29%" align="right"><font color="#213852">Username:</font></TD>
																							<TD width="71%">
																								<asp:TextBox id="loginname" CssClass="textBox" runat="server" Width="150px"></asp:TextBox></TD>
																						</TR>
																						<TR>
																							<TD align="right"><font color="#213852">Pasword:</font></TD>
																							<TD>
																								<asp:TextBox id="password" CssClass="passwordBox" runat="server" TextMode="Password" Width="150px"></asp:TextBox></TD>
																						</TR>
																						<TR align="center" height="40">
																							<TD colSpan="2"><div align="center">
																									<asp:DropDownList CssClass="dropDownList" Runat="server" ID="ddlManagerChoose">
																										<asp:ListItem Value="PawnMember" Selected="True">Pawn Member Management</asp:ListItem>
																										<asp:ListItem Value="SystemManagement">System Management</asp:ListItem>
																									</asp:DropDownList><br>
																									<input name="image2" type="image" value="登 录" src="images/button_login.gif"> <input name="image" type="image" value="重置" src="images/button_quit.gif" width="75" height="20">
																								</div>
																							</TD>
																						</TR>
																					</TBODY>
																				</TABLE>
																			</div>
																		</td>
																	</tr>
																</table>
															</div>
														</td>
													</tr>
												</table>
											</TD>
										</TR>
										<TR>
											<TD>
												<IMG SRC="images/title_login_2.gif" WIDTH="492" HEIGHT="35" ALT=""></TD>
										</TR>
										<TR>
											<TD COLSPAN="2">
												<img src="images/title_login_3.gif" width="604" height="148"></TD>
										</TR>
									</TABLE>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</BODY>
</HTML>
