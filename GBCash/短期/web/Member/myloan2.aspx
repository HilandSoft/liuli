<%@ Register TagPrefix="uc1" TagName="MemberLeft" Src="MemberLeft.ascx" %>
<%@ Register TagPrefix="uc1" TagName="MemberTop" Src="MemberTop.ascx" %>
<%@ Register TagPrefix="cc1" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<%@ Page language="c#" Codebehind="myloan2.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.myloan2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<script src="../javascriptN/jquery-1.4.4.min.js" type="text/javascript"></script>
		<link href="../CSSN/final.css" rel="stylesheet" type="text/css">
			<style type="text/css">
        .style2 { FONT-FAMILY: Verdana; FONT-SIZE: small }
        </style>
	</HEAD>
	<body>
		<!--start top-->
		<uc1:MemberTop id="MemberTop1" runat="server"></uc1:MemberTop>
		<!--end top-->
		<!--start homebanner-->
		<!--start subbanner-->
		<div id="subheader">
			<h1>Member Console</h1>
		</div>
		<!--end subbanner-->
		<!--start main-->
		<div id="main">
			<!--start process-->
			<uc1:MemberLeft id="MemberLeft1" runat="server"></uc1:MemberLeft>
			<!--end process-->
			<div id="content" style="MARGIN-LEFT: 0px">
				<form id="Form2" method="post" runat="server">
					<table width="100%" height="100%" cellpadding="0" cellspacing="0" border="0" align="center"
						bgColor="#fefefe">
						<tr>
							<td valign="top">
								<cc1:DataGridTable id="DataGridTable1" runat="server" PageCSS="scrollButton" StartPage="Head" PrevPage="Prev"
									IsShowFoot="True" MaxRecord="0" EnableViewState="False" AllowPaging="True" CssClass="tableGrid"
									AutoGenerateColumns="False" IsAllowPaging="True" NextPage="Next" EndPage="End" Width="98%" BorderStyle="None"
									BorderWidth="0px" ShowHeader="False" PageSize="3">
									<PagerStyle Visible="False" CssClass="gridPager"></PagerStyle>
									<AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
									<EditItemStyle CssClass="gridEditItem"></EditItemStyle>
									<FooterStyle CssClass="gridFooter"></FooterStyle>
									<SelectedItemStyle CssClass="gridSelectedItem"></SelectedItemStyle>
									<ItemStyle CssClass="gridItem"></ItemStyle>
									<HeaderStyle CssClass="gridHeader"></HeaderStyle>
									<Columns>
										<asp:BoundColumn DataField="id"></asp:BoundColumn>
									</Columns>
								</cc1:DataGridTable><asp:textbox id="txtParamstr" runat="server" Visible="False"></asp:textbox>
							</td>
						</tr>
						<tr>
							<td>&nbsp;</td>
						</tr>
					</table>
				</form>
			</div>
		</div>
		<!--end main-->
		<!--start footer-->
		<div style="CLEAR: both"></div>
		<div id="footer">© Copyright Golden Bridge Cash Solution Pty Ltd 2011</div>
		<script type="text/javascript">
        $(document).ready(function(){
				$("#menuItemLoanHistory").addClass("actived");
			});
		</script>
		<!--end footer-->
	</body>
</HTML>
