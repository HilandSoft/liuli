<%@ Page language="c#" Codebehind="ProductFrameSet.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.ProductFrameSet" %>
<html>
	<head>
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script>
		var borderwidth = 0;
		</script>
	</head>
	<frameset cols="172,*" id="frm" bordercolor="#93BBF1" border="1" frameSpacing="4" frameBorder="1"
		style="BORDER-STYLE: none;">
		<frame name="contents" id="contents" src="ProductLeftTree.aspx" scrolling="no">
		<frame name="main" id="main" src="ProductList.aspx" scrolling="yes">
		<noframes>
			<p id="p1">
				�� HTML ��ܼ���ʾ��� Web ҳ����Ҫ�鿴�˿�ܼ�����ʹ��֧�� HTML 4.0 �����߰汾�� Web �������
			</p>
		</noframes>
	</frameset>
</html>
