<%@ Control Language="c#" AutoEventWireup="false" Codebehind="RepaymentCycleTypeSelector.ascx.cs" Inherits="YingNet.WeiXing.WebApp.UControls.RepaymentCycleTypeSelector" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<asp:RadioButtonList id="rblPaymentCycleType" runat="server" RepeatDirection="Horizontal" AutoPostBack="True">
	<asp:ListItem Value="Weekly" Selected="True">Weekly</asp:ListItem>
	<asp:ListItem Value="F'nightly">F'nightly</asp:ListItem>
	<asp:ListItem Value="Monthly">Monthly</asp:ListItem>
</asp:RadioButtonList>
