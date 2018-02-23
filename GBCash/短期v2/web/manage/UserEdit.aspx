<%@ Page language="c#" Codebehind="UserEdit.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.UserEdit" %>
<HTML>
	<HEAD>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
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

function selectdept_onclick() {
    var ReturnObj = new Object();
    ReturnObj.DeptName	= MyForm.DeptName.value;
    ReturnObj.DeptID	= MyForm.DeptID.value;
   
    var ret =window.showModalDialog("deptselectdlg.htm",ReturnObj,"dialogHeight: 400px; dialogWidth: 500px; dialogTop: 50px; dialogLeft: 80px; edge: Sunken; center: Yes; help: No; resizable: No; status: No;");
    if ( ret != "" )
    {
	    MyForm.DeptName.value = ReturnObj.DeptName;
		MyForm.DeptID.value   = ReturnObj.DeptID;
    }
}

function checkbox_onclock(c)
{
	var src = document.getElementById("Label1");
	
	for (var i=0; i<src.all.length; i++)
	{
		var checkboxsrc = src.all[i];
		if (checkboxsrc.name == 'Checkbox1')
		{
			checkboxsrc.checked = c.checked;
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
						<asp:textbox id="txtParamstr" runat="server" Visible="False"></asp:textbox>
						<asp:TextBox id="TexSaveID" runat="server" Visible="False"></asp:TextBox></td>
					<td vAlign="middle" align="right" background="images/left_top_title_bk.gif" height="25"><nobr><INPUT type="button" value="返回" id="Button1" class="toolbar" name="Button1" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;</nobr>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<table id="Table2" style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; FONT-SIZE: 12px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px; BORDER-COLLAPSE: collapse"
							borderColor="#336699" height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center"
							border="1">
							<tr>
								<td height="26"><nobr>&nbsp;&nbsp;&nbsp;修改用户：</nobr></td>
							</tr>
							<tr>
								<td vAlign="top">
									<table align="center" width="80%">
										<tr height="32">
											<td><asp:Label id="lab_user" runat="server">用户名</asp:Label>
											</td>
											<td><asp:TextBox id="Tex_User" runat="server" s_msg="用户名不能为空!" Enabled="False"></asp:TextBox>
											</td>
											<td>
											</td>
											<td>
											</td>
											<td><asp:Label id="Lab_name" runat="server">姓名</asp:Label>
											</td>
											<td><asp:TextBox id="Tex_Name" runat="server" s_msg="密码不能为空!"></asp:TextBox>
											</td>
										</tr>
										<tr>
											<td colspan="8" height="32"><nobr>权限：&nbsp;&nbsp;&nbsp;&nbsp;</nobr></td>
										</tr>
										<tr>
											<td colspan="8">&nbsp;&nbsp;&nbsp;&nbsp;<INPUT id="maincheckbox" onclick="return checkbox_onclock(this)" type="checkbox">全选<br>
												<asp:Label id="Label1" runat="server"></asp:Label></td>
										</tr>
										<tr>
											<td colspan="8" align="center">
												<asp:Button id="Button2" runat="server" Text=" 更 新 " CssClass="toolbar"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;</td>
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
