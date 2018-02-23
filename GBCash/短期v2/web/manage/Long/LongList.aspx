<%@ Page language="c#" Codebehind="LongList.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.Long.LongList" %>
<%@ Register TagPrefix="cc1" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<HTML>
	<HEAD>
		<title>LongList</title>
		<LINK href="../csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<table cellPadding="0" width="100%" bgColor="#fefefe" border="0" ellSpacing="0">
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td align="center" height="12">Search By:
						<asp:DropDownList id="DropDownList1" runat="server">
							<asp:ListItem Value="0">Please Select</asp:ListItem>
							<asp:ListItem Value="1">Member ID</asp:ListItem>
							<asp:ListItem Value="2">First Name</asp:ListItem>
							<asp:ListItem Value="3">Last Name</asp:ListItem>
							<asp:ListItem Value="4">Time</asp:ListItem>
							<asp:ListItem Value="5">Birthday</asp:ListItem>
							<asp:ListItem Value="6">Approved</asp:ListItem>
							<asp:ListItem Value="15">Pre-Approved</asp:ListItem>
							<asp:ListItem Value="7">Completed</asp:ListItem>
							<asp:ListItem Value="98">Deleted</asp:ListItem>
							<asp:ListItem Value="99">Rejected</asp:ListItem>
							<asp:ListItem Value="100">New</asp:ListItem>
							<asp:ListItem Value="101">Expired</asp:ListItem>
							<asp:ListItem Value="18">WorkPlace</asp:ListItem>
						</asp:DropDownList>&nbsp;<FONT face="ËÎÌו">&nbsp; </FONT>
						<asp:TextBox id="txKey" runat="server"></asp:TextBox><FONT face="ËÎÌו">&nbsp; </FONT>
						<asp:Button id="Button1" runat="server" Text="Query"></asp:Button>
						<asp:TextBox id="txCondition" runat="server" Width="150px" Visible="False"></asp:TextBox>
						Please enter the date format as DD/MM/YYYY
					</td>
				</tr>
				<tr>
					<td vAlign="top"><cc1:datagridtable id="DataGridTable1" runat="server" BorderStyle="None" BorderWidth="1px" CellPadding="4"
							PageSize="12" BorderColor="#3366CC" BackColor="White" Width="100%" PageCSS="scrollButton" IsShowFoot="True"
							MaxRecord="0" EnableViewState="False" AllowPaging="True" CssClass="tableGrid" AutoGenerateColumns="False" IsAllowPaging="True"
							StartPage="Head" PrevPage="Prev" NextPage="Next" EndPage="End">
							<PagerStyle Visible="False" HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" CssClass="gridPager"
								Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
							<EditItemStyle CssClass="gridEditItem"></EditItemStyle>
							<FooterStyle ForeColor="#003399" CssClass="gridFooter" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" CssClass="gridSelectedItem" BackColor="#009999"></SelectedItemStyle>
							<ItemStyle ForeColor="#003399" CssClass="gridItem" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" CssClass="gridHeader" BackColor="#99CCCC"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="sid"></asp:BoundColumn>
								<asp:TemplateColumn Visible="False" HeaderText="Select">
									<HeaderStyle Width="1%"></HeaderStyle>
									<HeaderTemplate>
										<INPUT id="chkselectall" onclick="checkallorno(this)" type="checkbox"></asp:CheckBox>
									
</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox id="chkID" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn Visible="False" HeaderText="how much"></asp:BoundColumn>
								<asp:BoundColumn Visible="False" HeaderText="Term"></asp:BoundColumn>
								<asp:BoundColumn DataField="Sid" HeaderText="Customer NO"></asp:BoundColumn>
								<asp:BoundColumn DataField="ReferenceNum" HeaderText="Number"></asp:BoundColumn>
								<asp:BoundColumn DataField="Fname" HeaderText="FirstName"></asp:BoundColumn>
								<asp:BoundColumn DataField="mname" HeaderText="MiddleName"></asp:BoundColumn>
								<asp:BoundColumn DataField="sname" HeaderText="LastName"></asp:BoundColumn>
								<asp:BoundColumn DataField="DBirth" HeaderText="DateBirth"></asp:BoundColumn>
								<asp:BoundColumn DataField="Email" HeaderText="Email"></asp:BoundColumn>
								<asp:BoundColumn DataField="RegTime" HeaderText="Regtime" DataFormatString="{0:dd/MM/yyyy hh:mm:ss}"></asp:BoundColumn>
								<asp:BoundColumn DataField="Status" HeaderText="Status"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="Loan" DataNavigateUrlField="Sid" DataNavigateUrlFormatString="LoanInfo.aspx?sid={0}"></asp:HyperLinkColumn>
								<asp:HyperLinkColumn Text="Detail" DataNavigateUrlField="Sid" DataNavigateUrlFormatString="LongDetail.aspx?sid={0}"></asp:HyperLinkColumn>
								<asp:TemplateColumn><HeaderTemplate>Notes</HeaderTemplate></asp:TemplateColumn>
								<asp:TemplateColumn><HeaderTemplate>FollowUpHistory</HeaderTemplate></asp:TemplateColumn>
								<asp:HyperLinkColumn Visible="False" Text="Approve" DataNavigateUrlField="Sid" DataNavigateUrlFormatString="LongApprove.aspx?sid={0}"></asp:HyperLinkColumn>
								<asp:TemplateColumn></asp:TemplateColumn>
								<asp:HyperLinkColumn Text="ToProcessCenter" DataNavigateUrlField="Sid" DataNavigateUrlFormatString="SendToProcessCenter.aspx?id={0}"></asp:HyperLinkColumn>
								<asp:HyperLinkColumn Text="ToFollowupCenter" DataNavigateUrlField="Sid" DataNavigateUrlFormatString="SendToFollowupCenter.aspx?id={0}"></asp:HyperLinkColumn>
							</Columns>
						</cc1:datagridtable><asp:checkbox id="CheckBox1" runat="server" Visible="False"></asp:checkbox><asp:textbox id="txtParamstr" runat="server" Visible="False"></asp:textbox>
						<asp:Label id="Label1" runat="server"></asp:Label></td>
				</tr>
			</table>
		</form>
		<script src=../../jslib/jquery-1.2.6.min.js></script>
		<script type="text/javascript">
			$(document).ready(function(){
				$("a[@dealed]").addClass("Attention");
			})
		</script>
	</body>
</HTML>
