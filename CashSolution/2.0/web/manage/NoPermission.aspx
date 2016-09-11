<%@ Page language="c#" Codebehind="NoPermission.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.NoPermission" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>MemberDel</title>
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
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
					<td background="images/left_top_title_bk.gif" height="25" valign="middle">&nbsp;&nbsp;</td>
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
									<td colspan="2" height="24" bgcolor="#336699">&nbsp;&nbsp;No Permission&nbsp;
										<asp:TextBox id="TextBox1" runat="server" Visible="False"></asp:TextBox><asp:TextBox id="txtParamstr" runat="server" Width="0px" Height="0px"></asp:TextBox></td>
								</tr>
								<tr>
									<td height="120">
										<img src="images/seuity.gif" border="0">
									</td>
									<td align="center">No Permission,Try Other Function or Message to Administrator.</td>
								</tr>
							</table>
							<br>
							<div align="center">&nbsp;&nbsp;</div>
						</div>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
