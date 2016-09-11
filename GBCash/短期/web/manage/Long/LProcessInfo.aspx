<%@ Page language="c#" Codebehind="LProcessInfo.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.Long.LProcessInfo" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>LongList</title>
		<LINK href="../csslib/yingnet.css" type="text/css" rel="stylesheet">
			<script language="javascript" src="jslib/cal_layers.js"></script>
			<script language="javascript" src="jslib/cal_menu.js"></script>
			<script language="javascript" src="jslib/cal_pop.js"></script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="1" width="70%" align="center" border="0">
				<tr>
					<td colSpan="2" height="25">&nbsp;
						<asp:textbox id="txSid" runat="server" Width="40px" Visible="False"></asp:textbox><asp:textbox id="txPerSid" runat="server" Width="40px" Visible="False"></asp:textbox></td>
				</tr>
				<tr>
					<td colSpan="2">
						<div align="left">Step1:</div>
						<div align="left">Document check list(Checked/Incomplete)</div>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<div align="left">
							<table cellSpacing="0" cellPadding="1" width="90%" border="1">
								<tr>
									<td align="right" width="45%">Master Loan Agreement</td>
									<td align="left"><asp:checkbox id="cbMasterLoanAgreement" Runat="server"></asp:checkbox></td>
								</tr>
								<tr>
									<td align="right">Direct Debit Request</td>
									<td align="left"><asp:checkbox id="cbDirectDebitRequest" Runat="server"></asp:checkbox></td>
								</tr>
								<tr>
									<td align="right">Pay Slip</td>
									<td align="left"><asp:checkbox id="cbPaySlip" Runat="server"></asp:checkbox></td>
								</tr>
								<tr>
									<td align="right">Bank Statement</td>
									<td align="left"><asp:checkbox id="cbBankStatement" Runat="server"></asp:checkbox></td>
								</tr>
								<tr>
									<td align="right">ID</td>
									<td align="left"><asp:checkbox id="cbID" Runat="server"></asp:checkbox></td>
								</tr>
								<tr>
									<td align="right">Utility Bill</td>
									<td align="left"><asp:checkbox id="cbUtilityBill" Runat="server"></asp:checkbox></td>
								</tr>
							</table>
						</div>
						<div style="HEIGHT: 3px"></div>
						<div>&nbsp;<asp:button id="btnSendForPreApproval" runat="server" Text="Send For Pre-approval"></asp:button></div>
					</td>
				</tr>
				<tr>
					<td height="25"></td>
					<td>&nbsp;
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<div align="left">Step2:</div>
						<div align="left">Pre Approval</div>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<div style="HEIGHT: 3px"></div>
						<div>&nbsp;<asp:button id="btnPreApproval" runat="server" Text="Send For Pre-approval"></asp:button></div>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<div align="left">Step3:</div>
						<div align="left">Employment verification + home phone verifaction(no need if 
							mobile is provided) Import all the information need to be verified and allow 
							comment,such as below:</div>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<div align="left">
							<table cellSpacing="0" cellPadding="1" width="90%" border="1">
								<tr>
									<td align="right" width="35%">Empolyer Name</td>
									<td align="left"><asp:textbox id="tbEmpolyerName" Runat="server"></asp:textbox></td>
								</tr>
								<tr>
									<td align="right">Employer Address</td>
									<td align="left"><asp:textbox id="tbEmployerAddress" Runat="server"></asp:textbox></td>
								</tr>
								<tr>
									<td align="right">Employer Telephone</td>
									<td align="left"><asp:textbox id="tbEmployerTelephone" Runat="server"></asp:textbox></td>
								</tr>
								<tr>
									<td align="right">Work Telephone</td>
									<td align="left"><asp:textbox id="tbWorkTelephone" Runat="server"></asp:textbox></td>
								</tr>
								<tr>
									<td align="right">Employment Status</td>
									<td align="left"><asp:textbox id="tbEmploymentStatus" Runat="server"></asp:textbox></td>
								</tr>
								<tr>
									<td align="right">Job Title</td>
									<td align="left"><asp:textbox id="tbJobTitle" Runat="server"></asp:textbox></td>
								</tr>
								<tr>
									<td align="right">Time Employed</td>
									<td align="left"><asp:textbox id="tbTimeEmployed" Runat="server"></asp:textbox></td>
								</tr>
								<tr>
									<td align="right">Pay After Taxes</td>
									<td align="left"><asp:textbox id="tbPayAfterTaxes" Runat="server"></asp:textbox></td>
								</tr>
								<tr>
									<td align="right">Pay Frequency</td>
									<td align="left"><asp:textbox id="tbPayFrequency" Runat="server"></asp:textbox></td>
								</tr>
								<tr>
									<td align="right">Next Payday</td>
									<td align="left"><asp:textbox id="tbNextPaydayDD" Runat="server" Width="24px"></asp:textbox>/
											<asp:textbox id="tbNextPaydayMM" Width="24px" Runat="server" ></asp:textbox>/
											<asp:textbox id="tbNextPaydayYYYY" Width="56px" Runat="server"></asp:textbox>(DD/MM/YYYY)</td>
								</tr>
								<tr>
									<td align="right">Home Telephone</td>
									<td align="left"><asp:textbox id="tbHomeTelephone" Runat="server"></asp:textbox></td>
								</tr>
							</table>
						</div>
						<div style="HEIGHT: 3px"></div>
						<div>&nbsp;<asp:button id="btnDetailsVerified" runat="server" Text="Details Verified"></asp:button></div>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<div align="left">Step4:</div>
						<div align="left">Final Approval</div>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<div style="HEIGHT: 3px"></div>
						<div>&nbsp;<asp:button id="btnFinalApproval" runat="server" Text="Final Approval"></asp:button></div>
					</td>
				</tr>
				<tr>
					<td height="25"></td>
					<td>&nbsp;
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<div>Conversation Track</div>
					</td>
				</tr>
				<tr>
					<td colSpan="2">
						<asp:TextBox Runat="server" TextMode="MultiLine" ID="ConversationTrack" Width="552px" Height="82px"></asp:TextBox>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>