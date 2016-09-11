<%@ Page language="c#" Codebehind="infotypeedit.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.infotypeedit" %>
<HTML>
	<HEAD>
		<title>
			<%=WebAppTitle%>
		</title>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../csslib/double.css" type="text/css" rel="stylesheet">
		<script>
		function leftReload() {
		window.location='InfoList.aspx';
		//window.parent.carnoc.src="InfoLeftTree.aspx?id="+id
		window.parent.carnoc.location.reload();
		}
		
function image_onclick()
{
	if ( parent.borderwidth == 0 )
	{
		window.parent.document.all.frm.cols = "0,*";
		parent.borderwidth=1;
		var src = document.getElementById("image");
		if ( src )
		{
			src.src="images/left_open_2.gif";
		}
	}
	else
	{
		window.parent.document.all.frm.cols = "172,*";
		parent.borderwidth=0;
		var src = document.getElementById("image");
		if ( src )
		{
			src.src="images/left_open_1.gif";
		}
	}
}


function onmouseOverImg()
{
	var src = event.srcElement;
    if ( src.tagName == "IMG" )
    {
        src.style.filter = "alpha( opacity = 60 )";
    }
	
}

function onmouseOutImg()
{
	var src = event.srcElement;
    if ( src.tagName == "IMG" )
    {
        src.style.filter = "alpha( opacity = 100 )";
    }
}

	

function browdata_onclick()
{
	//window.location='ProductCNShow.aspx';
	window.history.back();
}

		</script>
	</HEAD>
	<body TOPMARGIN="0" LEFTMARGIN="0" RIGHTMARGIN="0" BOTTOMMARGIN="0">
		<form id="MyFrom" method="post" runat="server">
			<table id="Table1" style="BORDER-RIGHT: #336699 1px solid; BORDER-TOP: #336699 1px solid; BORDER-LEFT: #336699 1px solid; BORDER-BOTTOM: #336699 1px solid"
				height="100%" cellSpacing="0" cellPadding="0" width="100%" bgColor="#fefefe" border="0">
				<!--<tr>
					<td vAlign="middle" width="60" background="images/left_top_title_bk.gif" height="25">
						<nobr>&nbsp;<IMG language="javascript" class="imgst" id="image" onmouseover="onmouseOutImg()" title="显示或关闭左侧导航条"
								style="POSITION: relative; TOP: 1px" onclick="return image_onclick()" onmouseout="onmouseOverImg()"
								src="images/left_open_1.gif" border="0">&nbsp;</nobr></td>
					<td background="images/left_top_title_bk.gif" height="25" align="right" style="FONT-SIZE:14px">类型&nbsp;</td>
					<td background="images/left_top_title_bk.gif" height="25" width="30">&nbsp;</td>
				</tr>-->
				<tr>
					<td colSpan="3">
						<table id="Table2" style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; FONT-SIZE: 12px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px; BORDER-COLLAPSE: collapse"
							borderColor="#336699" height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center"
							border="1">
							<tr>
								<td height="26"><nobr>&nbsp;&nbsp;&nbsp;
										<asp:TextBox id="TempID" runat="server" Visible="False"></asp:TextBox></nobr></td>
							</tr>
							<tr>
								<td>
									<div id="Div1" style="OVERFLOW-Y: auto; SCROLLBAR-FACE-COLOR: #dee3e7; SCROLLBAR-HIGHLIGHT-COLOR: #ffffff; WIDTH: 100%; SCROLLBAR-SHADOW-COLOR: #dee3e7; SCROLLBAR-3DLIGHT-COLOR: #d1d7dc; SCROLLBAR-ARROW-COLOR: #006699; SCROLLBAR-TRACK-COLOR: #efefef; SCROLLBAR-DARKSHADOW-COLOR: #98aab1; HEIGHT: 100%"><FONT face="宋体"></FONT><FONT face="宋体"></FONT><FONT face="宋体"></FONT><br>
										<br>
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
													<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0" ID="Table2">
														<tr>
															<td align="center" height="20"></td>
														</tr>
														<tr>
															<td>
																<table width="100%" height="100%">
																	<tr>
																		<td height="30" align="center" style='FONT-SIZE:16px'>添 加 产 品 类 型</td>
																	</tr>
																	<tr>
																		<td height="5"><hr size="1" width="85%">
																		</td>
																	</tr>
																	<tr>
																		<td height="100" width="400" valign="top" align="center"><table>
																				<tr>
																					<td align="right">类型名称:</td>
																					<td><FONT face="宋体">
																							<asp:TextBox id="TextBox1" runat="server"></asp:TextBox></FONT></td>
																				</tr>
																			</table>
																		</td>
																	</tr>
																</table>
															</td>
														</tr>
														<tr>
															<td align="center" height="60">
																<INPUT id="Add" type="button" value="提 交" name="Add" runat="server">&nbsp;&nbsp;&nbsp;<INPUT id="browdata" type="button" value="返 回" name="browdata" language="javascript" onclick="return browdata_onclick()">
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
									</div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
