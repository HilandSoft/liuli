<%@ Register TagPrefix="uc1" TagName="head" Src="head.ascx" %>
<%@ Register TagPrefix="uc1" TagName="bottom" Src="bottom.ascx" %>
<%@ Page language="c#" Codebehind="MyLoan.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Long.Member.MyLoan" %>
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<LINK href="../../css/css.css" type="text/css" rel="stylesheet">
			<meta http-equiv="Content-Type" content="text/html; charset=utf-8">
			<script language="javascript" src="../../jslib/commCheck.js" type="text/javascript"></script>
			<style type="text/css">.word1 { FONT-WEIGHT: bold; FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	.word2 { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	A.word3:link { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	A.word3:hover { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	A.word3:visited { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	A.word3:active { FONT-SIZE: 12px; COLOR: #cc3300; TEXT-DECORATION: none }
	</style>
	</HEAD>
	<body leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="100%" align="center" border="0">
				<tr>
					<td><uc1:head id="Head1" runat="server"></uc1:head></td>
				</tr>
			</table>
			<table cellSpacing="0" cellPadding="0" width="990" align="center" border="0">
				<tr>
					<td colspan="3" height="10"></td>
				</tr>
				<tr>
					<td width="5">&nbsp;</td>
					<td width="200" valign="top" align="left">
						<table cellSpacing="0" cellPadding="0" width="190" border="0">
							<tr>
								<td><IMG height="18" alt="" src="images/1_01.gif" width="190"></td>
							</tr>
							<tr>
								<td background="images/1_07.gif">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td width="17%" height="20">
												<div align="center"></div>
											</td>
											<td width="83%">
												<a href="Index.aspx" class="word3">Customer Details</a>
											</td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"><IMG height="10" src="images/1_04.gif" width="16"></div>
											</td>
											<td>
												<a href="MyLoan.aspx" class="word3">My Loans</a></td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"></div>
											</td>
											<td>
												<a href="ChangePwd.aspx" class="word3">Change Password</a></td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"></div>
											</td>
											<td>
												<a href="ContactUs.aspx" class="word3">Contact Us</a></td>
										</tr>
										<tr>
											<td height="20">
												<div align="center"></div>
											</td>
											<td class="word2">
												<a href="Logout.aspx" class="word3">Logout</a></td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td><IMG height="5" alt="" src="images/1_09.gif" width="190"></td>
							</tr>
							<tr>
								<td align="center"><br>
									<img src="../images/contact2.gif" width="160" height="106" alt=""></td>
							</tr>
						</table>
					</td>
					<td vAlign="top">
						<table width="100%" border="0" cellSpacing="0" cellPadding="0">
							<tr>
								<td valign="top">
									<table cellSpacing="0" cellPadding="0" width="100%" border="0">
										<tr>
											<td bgColor="#cc3300"><IMG height="30" src="images/myloan.gif" width="400">&nbsp;
												<asp:TextBox id="txPerSid" runat="server" Visible="False" Width="64px"></asp:TextBox></td>
										</tr>
										<tr>
											<td>
											</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td height="10"></td>
							</tr>
							<tr>
								<td><strong>Member Number:
										<%=sNumber%>
									</strong>
									<table bordercolor='#e8e6df' align='center' width='99%' border='1' cellspacing='0' cellpadding='0'>
										<tr>
											<td bgcolor='#e8eedf' height="25" width="12%"><STRONG>Datedue</STRONG></td>
											<td bgcolor='#e8eedf' height="25" width="12%"><STRONG>Repaydue</STRONG></td>
											<td bgcolor='#e8eedf' height="25" width="8%"><STRONG>Paid</STRONG></td>
											<td bgcolor='#e8eedf' height="25" width="10%"><STRONG>Penalty</STRONG></td>
											<td bgcolor='#e8eedf' height="25" width="15%"><STRONG>Late Charge</STRONG></td>
											<td bgcolor='#e8eedf' height="25" width="10%"><STRONG>Balance</STRONG></td>
											<td bgcolor='#e8eedf' height="25" width="12%"><STRONG>RepayTime</STRONG></td>
											<td bgcolor='#e8eedf' height="25"><STRONG>OperateTime</STRONG></td>
										</tr>
										<%
				for(int i=0;i<dtPay.Rows.Count;i++)
				{
					string Sid=dtPay.Rows[i]["Sid"].ToString();
					string Datedue=dtPay.Rows[i]["Datedue"].ToString();
					string Repaydue=Convert.ToDouble(dtPay.Rows[i]["Repaydue"]).ToString("0.00");
					string Paid=dtPay.Rows[i]["Paid"].ToString();
					string Penalty=dtPay.Rows[i]["Penalty"].ToString();
					string LateCharge=dtPay.Rows[i]["LateCharge"].ToString();
					string Balance=Convert.ToDouble(dtPay.Rows[i]["Balance"]).ToString("0.00");
					string RepayTime="",OperateTime="";
					RepayTime=dtPay.Rows[i]["RepayTime"].ToString();
					OperateTime=dtPay.Rows[i]["OperateTime"].ToString();
					if(RepayTime=="")
					  RepayTime="&nbsp;";
					OperateTime=OperateTime.Replace("-","/");
					if(OperateTime=="")
					  OperateTime="&nbsp;";
					//string RepayTime=dtPay.Rows[i]["RepayTime"].ToString();
					//string OperateTime=dtPay.Rows[i]["OperateTime"].ToString();
				%>
										<tr>
											<td height="25"><%=Datedue%></td>
											<td><%=Repaydue%></td>
											<td><%=Paid%></td>
											<td><%=Penalty%></td>
											<td><%=LateCharge%></td>
											<td><%=Balance%></td>
											<td><%=RepayTime%></td>
											<td><%=OperateTime%></td>
										</tr>
										<%
				}		%>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td colSpan="2" height="40">&nbsp;</td>
				</tr>
				<tr>
					<td colSpan="3"><uc1:bottom id="Bottom1" runat="server"></uc1:bottom></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
