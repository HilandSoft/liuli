<%@ Control Language="c#" AutoEventWireup="false" Codebehind="leftmenu.ascx.cs" Inherits="YingNet.WeiXing.WebApp.Member.leftmenu" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<%@ Register TagPrefix="iewc" Namespace="Microsoft.Web.UI.WebControls" Assembly="Microsoft.Web.UI.WebControls" %>
<IMG SRC="../images/index_10.gif" WIDTH="191" HEIGHT="22" ALT=""><br>
<iewc:TreeView id="TreeView1" runat="server" Width="100%">
	<iewc:TreeNode Text="Account info">
		<iewc:TreeNode NavigateUrl="detail1.aspx" Text="Customer Details"></iewc:TreeNode>
		<iewc:TreeNode NavigateUrl="EmployDetail.aspx" Text="Employment Details"></iewc:TreeNode>
		<iewc:TreeNode NavigateUrl="myloan2.aspx" Text="My Loans"></iewc:TreeNode>
		<iewc:TreeNode NavigateUrl="changepwd.aspx" Text="Change Password"></iewc:TreeNode>
	</iewc:TreeNode>
	<iewc:TreeNode Text="Apply now">
		<iewc:TreeNode NavigateUrl="newloan.aspx" Text="New cash loan"></iewc:TreeNode>
		<iewc:TreeNode NavigateUrl="loanextension.aspx" Text="Loan extension"></iewc:TreeNode>
	</iewc:TreeNode>
	<iewc:TreeNode Text="Contact us">
		<iewc:TreeNode NavigateUrl="contaciinfo.aspx" Text="Contact info"></iewc:TreeNode>
	</iewc:TreeNode>
	<iewc:TreeNode Text="Logout" NavigateUrl="logout.aspx"></iewc:TreeNode>
</iewc:TreeView>
