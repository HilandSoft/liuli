<%@ Page language="c#" Codebehind="UserPassChange.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.UserPassChange" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>UserPassChange</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
			<link href="csslib/YingNet.css" rel="stylesheet" type="text/css">
		<script>
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
function check(thisform)
{
	for(i = 0; i < thisform.all.length; i++)
	{
		if ( thisform.all(i).value == "" && thisform.all(i).getAttribute("s_msg")!=null && thisform.all(i).getAttribute("s_msg")!="")
		{	alert(thisform.all(i).getAttribute("s_msg"));
			thisform.all(i).style.backgroundColor = "#FF0000";
			thisform.all(i).focus();
			return false;
		}
		else
		{
			thisform.all(i).style.backgroundColor = "";
		}
	}
}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="MyForm" method="post" runat="server" onsubmit="return check(this)">
			<table id="Table1" style="BORDER-RIGHT: #336699 1px solid; BORDER-TOP: #336699 1px solid; BORDER-LEFT: #336699 1px solid; BORDER-BOTTOM: #336699 1px solid"
				height="100%" cellSpacing="0" cellPadding="0" width="100%" bgColor="#fefefe" border="0">
				<tr>
					<td vAlign="middle" background="images/left_top_title_bk.gif" height="25"><nobr>&nbsp;<IMG language="javascript" class="imgst" id="image" onmouseover="onmouseOutImg()" title="显示或关闭左侧导航条"
								style="POSITION: relative; TOP: 1px" onclick="return image_onclick()" onmouseout="onmouseOverImg()" src="images/left_open_1.gif" border="0">&nbsp;</nobr>
						<asp:textbox id="txtParamstr" runat="server" Visible="False"></asp:textbox></td>
					<td vAlign="middle" align="right" background="images/left_top_title_bk.gif" height="25"><nobr>&nbsp;&nbsp;&nbsp;&nbsp;</nobr>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<table id="Table2" style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; FONT-SIZE: 12px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px; BORDER-COLLAPSE: collapse"
							borderColor="#336699" height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center"
							border="1">
							<tr>
								<td height="26"><nobr>&nbsp;&nbsp;&nbsp;修改密码：</nobr></td>
							</tr>
							<tr>
								<td vAlign="top">
									<table align="center" width="80%">
										<tr>
											<TD style="WIDTH: 93px" height="32"><FONT face="宋体">原密码</FONT></TD>
											<td colspan="8" height="32"><FONT face="宋体">
													<asp:TextBox id="txtOldPass" runat="server" EnableViewState="False" Width="100px" TextMode="Password"></asp:TextBox></FONT></td>
										</tr>
										<TR>
											<TD style="WIDTH: 93px; HEIGHT: 32px"><FONT face="宋体"><FONT face="宋体">新密码</FONT></FONT></TD>
											<TD style="HEIGHT: 32px" colSpan="8"><FONT face="宋体">
													<asp:TextBox id="txtNewPass" runat="server" Width="100px" EnableViewState="False" TextMode="Password"></asp:TextBox></FONT></TD>
										</TR>
										<tr>
											<TD style="WIDTH: 93px; HEIGHT: 32px"><FONT face="宋体"><FONT face="宋体">新密码确认</FONT></FONT></TD>
											<td colspan="8" style="HEIGHT: 32px">
												<asp:TextBox id="txtNewCpass" runat="server" Width="100px" EnableViewState="False" TextMode="Password"></asp:TextBox></td>
										</tr>
										<tr>
											<TD align="center" colSpan="9">
												<asp:Button id="btnSave" runat="server" CssClass="toolbar" Text=" 修 改 "></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;</TD>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
