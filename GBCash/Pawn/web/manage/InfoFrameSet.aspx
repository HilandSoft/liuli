<%@ Page language="c#" Codebehind="InfoFrameSet.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.InfoFrameSet" %>
<%






%>
<html>
	<head>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script>
		var borderwidth = 0;
				
		</script>
	</head>
	<frameset cols="172,*" id="frm" bordercolor="#93BBF1" border="1" frameSpacing="4" frameBorder="1"
		style="BORDER-STYLE: none;">
		<frame name="contents" id="contents" src="InfoLeftTree.aspx" scrolling="no">
		<frame name="main" id="main" src="InfoList.aspx" scrolling="yes">
		<noframes>
			<p id="p1"><img 
				此 HTML 框架集显示多个 Web 页。若要查看此框架集，请使用支持 HTML 4.0 及更高版本的 Web 浏览器。
			</p>
		</noframes>
	</frameset>
</html>
