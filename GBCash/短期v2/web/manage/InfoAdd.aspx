<%@ Register TagPrefix="uc1" TagName="HtmlEditor" Src="../HtmlEditor/HtmlEditor.ascx" %>
<%@ Page language="c#" ValidateRequest="false" Codebehind="InfoAdd.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.InfoAdd" %>
<HTML>
	<HEAD>
		<title>
			<%=WebAppTitle%>
		</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		
		<style> .itd { TEXT-ALIGN: right } .iinput { BORDER-RIGHT: #999999 1px solid; BORDER-TOP: #999999 1px solid; FONT-SIZE: 12px; BORDER-LEFT: #999999 1px solid; WIDTH: 200px; BORDER-BOTTOM: #999999 1px solid } </style>
		<script id="clientEventHandlersJS" language="javascript">
function leftReload() {
		window.location='InfoList.aspx';
		//window.parent.carnoc.src="InfoLeftTree.aspx?id="+id
		window.parent.carnoc.location.reload();
		}
function document_onkeydown()
{
	if (event.keyCode==13)
	{
		event.keyCode=9
	}
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
		<form id="MyFrom" method="post" runat="server">
			<table width="632" align="center" style="FONT-SIZE:14px">
				<tr>
					<td height="26">标&nbsp;&nbsp;&nbsp;&nbsp;题：<asp:TextBox id="TextBox1" runat="server" Width="272px"></asp:TextBox>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;<asp:CheckBox id="CheckBox1" runat="server" Text="首页显示"></asp:CheckBox></td>
				</tr>
				
				<TR>
					<TD height="26">标题图片：<INPUT id="File1" type="file" name="File1" runat="server" style="WIDTH: 344px; HEIGHT: 22px"
							size="38">&nbsp;&nbsp;</TD>
				</TR>
				<TR>
					<TD height="26"><FONT face="宋体">类别：
							<asp:DropDownList id="DropDownList1" runat="server" Width="168px"></asp:DropDownList></FONT></TD>
				</TR>
				<TR>
					<TD height="29" style="HEIGHT: 30px"><FONT face="宋体">时间：
							<asp:TextBox id="txTime" runat="server" Width="168px" Height="22px"></asp:TextBox></FONT></TD>
				</TR>
				<tr>
					<td height="26">内&nbsp;&nbsp;&nbsp;&nbsp;容：</td>
				</tr>
				<tr>
					<td height="400"><uc1:HtmlEditor id="HtmlEditor1" runat="server" FileManageURL="../htmleditor/defaultfilemanage.aspx"
							Content=""></uc1:HtmlEditor></td>
				</tr>
			</table>
			<table align="center" height="30" width="200">
				<tr>
					<td align="center" valign="bottom">
						<asp:Button id="Button1" runat="server" Text="保 存"></asp:Button></td>
					<td align="center" valign="bottom"><input type="button" value="取 消" onclick="window.history.back();"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
