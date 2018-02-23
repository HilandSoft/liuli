<%@ Page language="c#" Codebehind="ProductList.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.ProductList" %>
<%@ Register TagPrefix="cc1" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<HTML>
	<HEAD>
		<title>
			<%=WebAppTitle%>
		</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<link href="csslib/yingnet.css" rel="stylesheet" type="text/css">
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
	<body TOPMARGIN="0" LEFTMARGIN="0" RIGHTMARGIN="0" BOTTOMMARGIN="0">
		<form id="MyFrom" method="post" runat="server">
			<table id="Table1" style="BORDER-RIGHT: #336699 1px solid; BORDER-TOP: #336699 1px solid; BORDER-LEFT: #336699 1px solid; BORDER-BOTTOM: #336699 1px solid"
				height="100%" cellSpacing="0" cellPadding="0" width="100%" bgColor="#fefefe" border="0">
				<!--
				<tr>
					<td vAlign="middle" background="images/left_top_title_bk.gif" height="25" class='aaa'>
						<nobr>&nbsp;<IMG language="javascript" class="imgst" id="image" onmouseover="onmouseOutImg()" title="显示或关闭左侧导航条"
								style="POSITION: relative; TOP: 1px" onclick="return image_onclick()" onmouseout="onmouseOverImg()"
								src="images/left_open_1.gif" border="0">&nbsp;</nobr></td>
					<td background="images/left_top_title_bk.gif" height="25" align="right" class='aaa'>产品管理</td>
					<td background="images/left_top_title_bk.gif" height="25" class='aaa'>&nbsp;</td>
				</tr>-->
				<tr>
					<td colSpan="3">
						<table id="Table2" style="BORDER-RIGHT: 0px; BORDER-TOP: 0px; FONT-SIZE: 12px; BORDER-LEFT: 0px; BORDER-BOTTOM: 0px; BORDER-COLLAPSE: collapse"
							borderColor="#336699" height="100%" cellSpacing="1" cellPadding="0" width="100%" align="center"
							border="1">
							<tr>
								<td height="26"><nobr>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
										<INPUT type="button" value="添加产品类型" class="toolbar" id="AddProductType" onclick="window.location='ProductTypeAdd.aspx';">
										<INPUT class="toolbar" id="EditProductType" type="button" value="修改产品类型" onclick="window.location='ProductTypeEdit.aspx';"><INPUT class="toolbar" id="delProductType" type="button" value="删除产品类型" onclick="window.location='ProductTypeDel.aspx';"><INPUT class="toolbar" id="AddProduct" type="button" value="添加产品" name="Button3" onclick="window.location='ProductAdd.aspx';">
										<asp:TextBox id="txtParamstr" runat="server" Visible="False"></asp:TextBox></nobr></td>
							</tr>
							<tr>
								<td>
									<div id="Div1" style="OVERFLOW-Y: auto; SCROLLBAR-FACE-COLOR: #dee3e7; SCROLLBAR-HIGHLIGHT-COLOR: #ffffff; WIDTH: 100%; SCROLLBAR-SHADOW-COLOR: #dee3e7; SCROLLBAR-3DLIGHT-COLOR: #d1d7dc; SCROLLBAR-ARROW-COLOR: #006699; SCROLLBAR-TRACK-COLOR: #efefef; SCROLLBAR-DARKSHADOW-COLOR: #98aab1; HEIGHT: 100%">
										<cc1:DataGridTable id="DataGridTable1" runat="server" PageSize="12" Width="100%" CellPadding="4" BorderColor="#3366CC"
											BackColor="White" BorderWidth="1px" BorderStyle="None" IsAllowPaging="True" AutoGenerateColumns="False"
											AllowPaging="True" EnableViewState="False" MaxRecord="0" CssClass="tableGrid" PageCSS="scrollButton"
											IsShowFoot="True">
											<PagerStyle Visible="False" HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" CssClass="gridPager"
												Mode="NumericPages"></PagerStyle>
											<AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
											<EditItemStyle CssClass="gridEditItem"></EditItemStyle>
											<FooterStyle ForeColor="#003399" CssClass="gridFooter" BackColor="#99CCCC"></FooterStyle>
											<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" CssClass="gridSelectedItem" BackColor="#009999"></SelectedItemStyle>
											<ItemStyle ForeColor="#003399" CssClass="gridItem" BackColor="White"></ItemStyle>
											<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" CssClass="gridHeader" BackColor="#99CCCC"></HeaderStyle>
											<Columns>
												<asp:BoundColumn DataField="PriductID" HeaderText="序号">
													<HeaderStyle Width="40px"></HeaderStyle>
													<FooterStyle Wrap="False"></FooterStyle>
												</asp:BoundColumn>
												<asp:HyperLinkColumn DataNavigateUrlField="PriductID" DataNavigateUrlFormatString="ProductEdit.aspx?ProductID={0:d}"
													DataTextField="ProductName" HeaderText="标题"></asp:HyperLinkColumn>
												<asp:HyperLinkColumn Text="修改" DataNavigateUrlField="PriductID" DataNavigateUrlFormatString="ProductEdit.aspx?ProductID={0:d}"
													HeaderText="修改">
													<HeaderStyle Width="60px"></HeaderStyle>
												</asp:HyperLinkColumn>
												<asp:HyperLinkColumn Text="删除" DataNavigateUrlField="PriductID" DataNavigateUrlFormatString="ProductDel.aspx?ProductID={0:d}"
													HeaderText="删除">
													<HeaderStyle Width="60px"></HeaderStyle>
												</asp:HyperLinkColumn>
											</Columns>
										</cc1:DataGridTable></div>
								</td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
