<%@ Page language="c#" Codebehind="AdminInfo.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.AdminManage.AdminInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>AdminInfo</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style> .itd { TEXT-ALIGN: right } .iinput { BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; FONT-SIZE: 12px; BORDER-LEFT: #999999 1px solid; WIDTH: 200px; BORDER-BOTTOM: #999999 1px solid } </style>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table cellpadding="15" align="center">
				<tr>
					<td>
						<table border="0" cellpadding="0" cellspacing="0" align="center" style="FONT-SIZE: 1px"
							ID="Table1">
							<tr height="8">
								<td width="8" style="BORDER-TOP: #555555 1px solid; BORDER-LEFT: #555555 1px solid">&nbsp;</td>
								<td style="BORDER-RIGHT: #555555 1px solid; BORDER-TOP: #555555 1px solid">&nbsp;</td>
								<td width="8">&nbsp;</td>
							</tr>
							<tr>
								<td style="BORDER-LEFT: #555555 1px solid; BORDER-BOTTOM: #555555 1px solid">&nbsp;</td>
								<td style="BORDER-RIGHT: #555555 1px solid; PADDING-RIGHT: 8px; PADDING-BOTTOM: 8px; BORDER-BOTTOM: #555555 1px solid">
									<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" ID="Table2"
										style="FONT-SIZE:14px">
										<tr>
											<td align="center" height="20"></td>
										</tr>
										<tr>
											<td>
												<table width="100%" height="100%">
													<tr>
														<td height="30" align="center" style='FONT-SIZE:16px'>Create/Edit NewManager</td>
													</tr>
													<tr>
														<td height="5"><hr size="1" width="85%">
														</td>
													</tr>
													<tr>
														<td height="200" width="400" valign="top" align="center"><table>
																<tr>
																	<td align="right">UserName:</td>
																	<td><asp:TextBox id="txtUserName" runat="server" Width="240px" CssClass="iinput"></asp:TextBox></td>
																</tr>
																<tr>
																	<td align="right">Password:</td>
																	<td><asp:TextBox id="txtPassword" runat="server" Width="240px" CssClass="iinput" TextMode="Password"></asp:TextBox></td>
																</tr>
																<tr>
																	<td align="right"><FONT face=""><FONT face="">Confirm</FONT></FONT> Password:</td>
																	<td><asp:TextBox id="txtPassword2" runat="server" Width="240px" CssClass="iinput" TextMode="Password"></asp:TextBox>
																		<asp:CompareValidator id="CompareValidator1" runat="server" ErrorMessage="*" ControlToCompare="txtPassword"
																			ControlToValidate="txtPassword2"></asp:CompareValidator></td>
																</tr>
																<tr>
																	<td align="right" valign="top">Enable:</td>
																	<td>
																		<asp:CheckBox Runat="server" ID="chbEnable" Checked="True"></asp:CheckBox>
																	</td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td align="center" height="80">
												<INPUT id="Add" type="button" value="Save" name="Add" runat="server">&nbsp;&nbsp;&nbsp;<INPUT id="browdata" type="button" value="Cancle" name="browdata" language="javascript"
													onclick="return gotoList()">
											</td>
										</tr>
									</table>
								</td>
								<td bgcolor="#aaaaaa">&nbsp;</td>
							</tr>
							<tr height="8">
								<td>&nbsp;</td>
								<td bgcolor="#aaaaaa">&nbsp;</td>
								<td bgcolor="#aaaaaa">&nbsp;</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
		<script type="text/javascript">
			function gotoList()
			{
				window.location='AdminList.aspx';
			}
		</script>
	</body>
</HTML>
