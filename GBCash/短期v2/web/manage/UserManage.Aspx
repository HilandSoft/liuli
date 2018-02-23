<%@ Page language="c#" Codebehind="UserManage.Aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Manage.UserManage" %>
<%@ Register TagPrefix="cc1" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<HTML>
	<HEAD>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="csslib/YingNet.css" rel="stylesheet" type="text/css">
		<style> .imgst { FILTER: alpha( opacity = 60 ); POSITION: relative; TOP: 3px } </style>
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

		</script>
	</HEAD>
	<body style="BORDER-RIGHT:0px;BORDER-TOP:0px;MARGIN:0px;BORDER-LEFT:0px;BORDER-BOTTOM:0px">
		<form id="MyForm" method="post" runat="server">
			<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%" bgcolor="#fefefe"
				style="BORDER-RIGHT: #336699 1px solid; BORDER-TOP: #336699 1px solid; BORDER-LEFT: #336699 1px solid; BORDER-BOTTOM: #336699 1px solid"
				ID="Table1">
				<tr>
					<td background="images/left_top_title_bk.gif" height="25" valign="middle"><nobr>&nbsp;<img src="images/left_open_1.gif" style="POSITION: relative; TOP: 1px" border="0" id="image"
								title="显示或关闭左侧导航条" language="javascript" onclick="return image_onclick()" onmouseover="onmouseOutImg()" onmouseout="onmouseOverImg()" class="imgst">&nbsp;</nobr>
						<asp:TextBox id="txtParamstr" runat="server" Visible="False"></asp:TextBox>
					</td>
					<td background="images/left_top_title_bk.gif" height="25" valign="middle" align="right"><nobr>
							<asp:Button id="ButAdd" runat="server" Text="添加用户" CssClass="toolbar"></asp:Button>&nbsp;&nbsp;&nbsp;&nbsp;</nobr>
					</td>
				</tr>
				<tr>
					<td colspan="2">
						<table align="center" width="100%" height="100%" border="1" cellpadding="0" cellspacing="1"
							style="BORDER-RIGHT: 0px;BORDER-TOP: 0px;FONT-SIZE: 12px;BORDER-LEFT: 0px;BORDER-BOTTOM: 0px;BORDER-COLLAPSE: collapse"
							bordercolor="#336699" id="Table2">
							<tr>
								<td height="26"><nobr>&nbsp;&nbsp;&nbsp;用户列表：</nobr></td>
							</tr>
							<tr>
								<td><div id="Div1" style="OVERFLOW-Y: auto;SCROLLBAR-FACE-COLOR: #dee3e7;OVERFLOW-X: auto;SCROLLBAR-HIGHLIGHT-COLOR: #ffffff;WIDTH: 100%;SCROLLBAR-SHADOW-COLOR: #dee3e7;SCROLLBAR-3DLIGHT-COLOR: #d1d7dc;SCROLLBAR-ARROW-COLOR: #006699;SCROLLBAR-TRACK-COLOR: #efefef;SCROLLBAR-DARKSHADOW-COLOR: #98aab1;HEIGHT: 100%">
										<cc1:DataGridTable class="tittable" id="DataGridTable1" runat="server" CssClass="tableGrid" PageCSS="scrollButton"
											MaxRecord="0" EnableViewState="False" AllowPaging="True" AutoGenerateColumns="False" IsAllowPaging="True"
											Width="100%">
											<PagerStyle Visible="False" CssClass="gridPager"></PagerStyle>
											<AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
											<EditItemStyle CssClass="gridEditItem"></EditItemStyle>
											<FooterStyle CssClass="gridFooter"></FooterStyle>
											<SelectedItemStyle CssClass="gridSelectedItem"></SelectedItemStyle>
											<ItemStyle CssClass="gridItem"></ItemStyle>
											<HeaderStyle CssClass="gridHeader"></HeaderStyle>
											<Columns>
												<asp:BoundColumn Visible="False" DataField="id"></asp:BoundColumn>
												<asp:BoundColumn HeaderText="编号">
													<HeaderStyle Width="60px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="account" HeaderText="帐号">
													<HeaderStyle Width="120px"></HeaderStyle>
												</asp:BoundColumn>
												<asp:BoundColumn DataField="name" HeaderText="姓名"></asp:BoundColumn>
												<asp:TemplateColumn HeaderText="管理">
													<HeaderStyle Width="120px"></HeaderStyle>
													<ItemTemplate>
<ASP:LINKBUTTON ID="Linkbutton1" RUNAT="server" COMMANDNAME="edit">
															编辑</ASP:LINKBUTTON>&nbsp; 
<ASP:LINKBUTTON ID="Linkbutton2" RUNAT="server" COMMANDNAME="delete">
															删除</ASP:LINKBUTTON>&nbsp; 
</ItemTemplate>
												</asp:TemplateColumn>
											</Columns>
										</cc1:DataGridTable>
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
