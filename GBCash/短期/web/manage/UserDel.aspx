<%@ Page language="c#" Codebehind="UserDel.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.UserDel" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title></title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
			<link href="csslib/YingNet.css" rel="stylesheet" type="text/css">
	
		<style> .imgst { FILTER: alpha( opacity = 60 ); POSITION: relative; TOP: 3px } </style>
		<script language="javascript">
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
		window.parent.document.all.frm.cols = "210,*";
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

		</script>
		<script id="clientEventHandlersJS" language="javascript">
<!--

function retu_onclick() {
window.history.back();
}

//-->
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%" bgcolor="#fefefe"
				style="BORDER-RIGHT: #336699 1px solid; BORDER-TOP: #336699 1px solid; BORDER-LEFT: #336699 1px solid; BORDER-BOTTOM: #336699 1px solid"
				ID="Table1">
				<tr>
					<td background="images/left_top_title_bk.gif" height="25" valign="middle">&nbsp;<img src="images/left_open_1.gif" style="POSITION: relative; TOP: 1px" border="0"
							id="image" title="显示或关闭左侧导航条" language="javascript" onclick="return image_onclick()" onmouseover="onmouseOutImg()" onmouseout="onmouseOverImg()" class="imgst">&nbsp;</td>
					<td background="images/left_top_title_bk.gif" height="25" valign="middle" align="right">
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<div id="Div1" style="OVERFLOW-Y: auto;SCROLLBAR-FACE-COLOR: #dee3e7;OVERFLOW-X: auto;SCROLLBAR-HIGHLIGHT-COLOR: #ffffff;WIDTH: 100%;SCROLLBAR-SHADOW-COLOR: #dee3e7;SCROLLBAR-3DLIGHT-COLOR: #d1d7dc;SCROLLBAR-ARROW-COLOR: #006699;SCROLLBAR-TRACK-COLOR: #efefef;SCROLLBAR-DARKSHADOW-COLOR: #98aab1;HEIGHT: 100%">
							<br>
							<br>
							<br>
							<table width="300" align="center" border="1" cellpadding="2" cellspacing="0">
								<tr>
									<td height="24" bgcolor="#336699" style="FONT-SIZE:14px;COLOR:#ffffff">&nbsp;&nbsp;删除用户
										<asp:TextBox id="TextBox1" runat="server" Visible="False"></asp:TextBox><asp:TextBox id="txtParamstr" runat="server" Width="0px" Height="0px"></asp:TextBox></td>
								</tr>
								<tr>
									<td height="120" align="center">
										<asp:Label id="LabMsg" runat="server" Width="80%" Font-Size="12px"></asp:Label></td>
								</tr>
							</table>
							<br>
							<div align="center"><INPUT type="button" value=" 是 " id='returnmain' runat="server" NAME="returnmain">&nbsp;&nbsp;<INPUT id="retu" type="button" value=" 否 " language="javascript" onclick="return retu_onclick()"></div>
						</div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
