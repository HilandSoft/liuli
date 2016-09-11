<%@ Page language="c#" Codebehind="MainFrameSet.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.Long.MainFrameSet" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" > 

<html>
	<head>
		<title>
		</title>
		<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language=javascript>
		window.open("openwindow.aspx","","");
		</script>
	</head>
	<frameset rows="109,*" border="0" frameSpacing="0" frameBorder="0">
		<frame name="banner" src="MainTop.aspx" scrolling="no" noresize>
		<frame name="main" src="LongList.aspx" scrolling= auto>
		<noframes>
			<p id="p1">
				此 HTML 框架集显示多个 Web 页。若要查看此框架集，请使用支持 HTML 4.0 及更高版本的 Web 浏览器。
			</p>
		</noframes>
	</frameset>
</html>