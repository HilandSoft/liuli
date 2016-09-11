<%@ Register TagPrefix="uc1" TagName="FileUpload" Src="../Upload/FileUpload.ascx" %>
<%@ Page language="c#" Codebehind="DefaultFileManage.aspx.cs" AutoEventWireup="false" Inherits="YingNet.ControlLib.HtmlEditor.DefaultFileManage" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>DefaultFileManage</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<script language="javascript">
function returnImage(imgsrc, alttext) {
	error = 0	
	var sel = window.top.opener.foo.document.selection;

	if (sel!=null) {
		var rng = sel.createRange();
	   	if (rng!=null) {			
			HTMLTextField = '<img src="' + imgsrc + '" alt="' + alttext + '">';
			rng.pasteHTML(HTMLTextField)
		} // End if
	} // End If

	if (error != 1) {
		window.top.opener.foo.focus();
		window.top.self.close();
	}
	window.top.close();
	
}		
function returnHref(hrefurl, hrefdesc) {
	error = 0	
	var sel = window.top.opener.foo.document.selection;

	if (sel!=null) {
		var rng = sel.createRange();
	   	if (rng!=null) {		
			HTMLTextField = '<a href="' + hrefurl + '">' + hrefdesc + '</a>';
			rng.pasteHTML(HTMLTextField)
		} // End if
	} // End If

	if (error != 1) {
		window.top.opener.foo.focus();
		window.top.self.close();
	}
	window.top.close();
	
}		
		</script>
	</HEAD>
	<body bottomMargin="0" leftMargin="0" topMargin="0" rightMargin="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="90%" align="center" border="0">
				<tr>
					<td>
						<table cellSpacing="1" cellPadding="6" width="100%" align="center" bgColor="#cccccc" border="0">
							<tr bgColor="#ffffff">
								<td width="27%" bgColor="#ffffff">
									<div align="right">上传文件：</div>
								</td>
								<td width="73%"><uc1:fileupload id="upload" runat="server"></uc1:fileupload>&nbsp;<asp:button id="btnUpload" runat="server" Text="上传"></asp:button>
								</td>
							</tr>
							<tr bgColor="#ffffff">
								<td bgColor="#ffffff">
									<div align="right">使用说明：</div>
								</td>
								<td>双击文件名可将上传内容添加到信息内容中。</td>
							</tr>
						</table>
						<table cellSpacing="1" cellPadding="6" width="100%" align="center" bgColor="#cccccc" border="0">
							<tr bgColor="#4a96de">
								<td colSpan="2" height="20"><font color="#ffffff">已上传文件列表：</font></td>
							</tr>
							<tr bgColor="#ffffff">
								<td bgColor="#ffffff" colSpan="2"><asp:datagrid id="dgdList" runat="server" AutoGenerateColumns="False" Width="100%">
										<Columns>
											<asp:BoundColumn DataField="orgName" HeaderText="文件名"></asp:BoundColumn>
											<asp:BoundColumn DataField="serverName" HeaderText="服务器文件名"></asp:BoundColumn>
											<asp:BoundColumn DataField="filesize" HeaderText="文件大小"></asp:BoundColumn>
											<asp:BoundColumn DataField="contenttype" HeaderText="文件类型"></asp:BoundColumn>
											<asp:TemplateColumn HeaderText="删除">
												<ItemTemplate>
													<asp:LinkButton id="lnkDelete" runat="server" CommandName="Delete">删除</asp:LinkButton>
												</ItemTemplate>
											</asp:TemplateColumn>
										</Columns>
									</asp:datagrid></td>
							</tr>
						</table>
					</td>
					<td>&nbsp;</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
