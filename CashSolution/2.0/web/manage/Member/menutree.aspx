<%@ Page language="c#" Codebehind="menutree.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.menutree" %>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>menutree</title>
		<meta name="GENERATOR" Content="Microsoft Visual Studio .NET 7.1">
		<meta name="CODE_LANGUAGE" Content="C#">
		<meta name="vs_defaultClientScript" content="JavaScript">
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
	</HEAD>
	<body bgcolor="#e8e6df" LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0"
		MARGINHEIGHT="0">
		<IMG SRC="../images/index_10.gif" WIDTH="191" HEIGHT="22" ALT=""><br>
		<iewc:TreeView id="TreeView1" runat="server" Width="100%">
			<iewc:TreeNode Text="Account info">
				<iewc:TreeNode NavigateUrl="detail1.aspx" Text="Customer detail" Target="right"></iewc:TreeNode>
				<iewc:TreeNode NavigateUrl="myloan2.aspx" Text="My loans" Target="right"></iewc:TreeNode>
				<iewc:TreeNode NavigateUrl="changepwd.aspx" Text="Change Password" Target="right"></iewc:TreeNode>
			</iewc:TreeNode>
			<iewc:TreeNode Text="Apply now">
				<iewc:TreeNode NavigateUrl="newloan.aspx" Text="New cash loan" Target="right"></iewc:TreeNode>
				<iewc:TreeNode NavigateUrl="loanextension.aspx" Text="Loan extension" Target="right"></iewc:TreeNode>
			</iewc:TreeNode>
			<iewc:TreeNode Text="Contact us">
				<iewc:TreeNode NavigateUrl="contaciinfo.aspx" Text="Contact info" Target="right"></iewc:TreeNode>
			</iewc:TreeNode>
			<iewc:TreeNode Text="Logout" NavigateUrl="logout.aspx" Target="right"></iewc:TreeNode>
		</iewc:TreeView>
	</body>
</HTML>
