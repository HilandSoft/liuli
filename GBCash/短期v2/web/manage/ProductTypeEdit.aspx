<%@ Page language="c#" Codebehind="ProductTypeEdit.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.ProductTypeEdit" %>
<HTML>
	<HEAD>
		<title>
			<%=WebAppTitle%>
		</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style> .itd { TEXT-ALIGN: right } .iinput { BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; FONT-SIZE: 12px; BORDER-LEFT: #999999 1px solid; WIDTH: 200px; BORDER-BOTTOM: #999999 1px solid } </style>
		<script id="clientEventHandlersJS" language="javascript">
		function leftReload() {
		window.location='ProductList.aspx';
		window.parent.carnoc.location.reload();
		}

function document_onkeydown()
{
	if (event.keyCode==13)
	{
		event.keyCode=9
	}
}

function browdata_onclick()
{
	window.location='ProductList.aspx';
}

function window_onload()
{
	var src = document.getElementById("TextBox1");
	if ( src )
	{
		src.focus();
	}
}
		</script>
		<script language="javascript" for="document" event="onkeydown">
return document_onkeydown()
		</script>
	</HEAD>
	<body language="javascript" onload="return window_onload()">
		<form id="adddata" method="post" runat="server">
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
														<td height="30" align="center" style='FONT-SIZE:16px'>�� ��&nbsp; �� Ϣ
															<asp:TextBox id="TempID" runat="server" Visible="False"></asp:TextBox></td>
													</tr>
													<tr>
														<td height="5"><hr size="1" width="85%">
														</td>
													</tr>
													<tr>
														<td height="200" width="400" valign="top" align="center"><table>
																<tr>
																	<td align="right">����:</td>
																	<td>
																		<asp:TextBox id="TextBox1" runat="server" CssClass="iinput" Width="240px" DESIGNTIMEDRAGDROP="102"></asp:TextBox></td>
																</tr>
																<TR>
																	<TD align="right">ԭͼ:</TD>
																	<TD><asp:TextBox id="TextBox2" runat="server" Width="176px" CssClass="iinput"></asp:TextBox>
																		<asp:CheckBox id="CheckBox1" runat="server" Text="ɾ��ͼƬ" Font-Size="12px"></asp:CheckBox></TD>
																</TR>
																<tr>
																	<td align="right">ͼƬ:</td>
																	<td><INPUT id="File1" type="file" name="File1" runat="server" class="iinput"></td>
																</tr>
																<tr>
																	<td align="right" valign="top">���:</td>
																	<td>
																		<asp:TextBox id="TextBox3" runat="server" Width="248px" TextMode="MultiLine" Height="160px" CssClass="iinput"></asp:TextBox></td>
																</tr>
															</table>
														</td>
													</tr>
												</table>
											</td>
										</tr>
										<tr>
											<td align="center" height="80">
												<INPUT id="Add" type="button" value="�� ��" name="Add" runat="server">&nbsp;&nbsp;&nbsp;<INPUT id="browdata" type="button" value="�� ��" name="browdata" language="javascript" onclick="return browdata_onclick()">
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
	</body>
</HTML>
