<%@ Page language="c#" Codebehind="NotLogin.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.NotLogin" %>
<html>
	<head>
		<title>没有登录！！！</title>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<script language="javascript">
			//window.top.setTimeout("window.navigate('/manage/index.aspx')",3000);
			window.top.setTimeout("window.alert('您没有登录或者登录超时，请重新登录！');window.close()",3000);
		</script>
	</head>
	<body style="BORDER-RIGHT:0px;BORDER-TOP:0px;MARGIN:0px;BORDER-LEFT:0px;BORDER-BOTTOM:0px">
		<!--<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%" style="BORDER: #336699 1px solid; "
			ID="Table1">
			<tr>
				<td align="center" height="80%">
					<img src="images/nologin.gif" border="0"></td>
			</tr>
			<tr>
				<td align="center" height="20%">
				</td>
			</tr>
		</table>-->
	</body>
</html>
