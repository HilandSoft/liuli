<%@ Register TagPrefix="uc1" TagName="CircleDropDownList" Src="../Include/CircleDropDownList.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top5" Src="top5.ascx" %>
<%@ Page language="c#" Codebehind="employmentedit.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.employmentedit" %>
<%@ Register TagPrefix="uc1" TagName="top4" Src="top4.ascx" %>
<%@ Register TagPrefix="uc1" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top1" Src="top1.ascx" %>
<HTML>
	<HEAD>
		<title>employmentedit</title>
		<META http-equiv="Content-Type" content="text/html; charset=utf-8">
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
			<script language="javascript" src="../jslib/commCheck.js" type="text/javascript"></script>
			<script language="javascript">
		function  CheckFeedback1() {
		var ftxEmployer=document.getElementById("txEmployer");
		var ftxAddress=document.getElementById("txAddress");
		var ftxPhone=document.getElementById("txPhone");
		var ftxJob=document.getElementById("txJob");
		var ftxIncome=document.getElementById("txIncome");		
		var ftxMm1=document.getElementById("txMm1");		
		var ftxDd1=document.getElementById("txDd1");		
		var ftxYy1=document.getElementById("txYy1");
		
		if(!chkNull(ftxEmployer.value)) {
		alert(" Field 'Employer' under 'Employment Information' is not valid");
		ftxEmployer.focus();
		return false;
		}
		
		if(!chkNull(ftxAddress.value)) {
		alert(" Field 'Employer's Address' under 'Employment Information' is not valid");
		ftxAddress.focus();
		return false;
		}
		
		if(!chkNull(ftxPhone.value)) {
		alert(" Field 'Employer's Phone Number' under 'Employment Information' is not valid");
		ftxPhone.focus();
		return false;
		}
		
		if(!chkNull(ftxJob.value)) {
		alert(" Field 'Job Title' under 'Employment Information' is not valid!");
		ftxJob.focus();
		return false;
		}
		
		if(!chkNull(ftxIncome.value)) {
		alert(" Field 'Net Income' under 'Employment Information' is not valid");
		ftxIncome.focus();
		return false;
		}
		
		if((!chkNull(ftxMm1.value))||(!chkNull(ftxDd1.value))||(!chkNull(ftxYy1.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid");
		return false;
		}
		
		if((!chkdigital(ftxMm1.value))||(!chkdigital(ftxDd1.value))||(!chkdigital(ftxYy1.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid");
		return false;
		}
		
		return true;
		}		
		
		
		function  CheckFeedback2() {
		var ftxType=document.getElementById("txType");
		var ftxOffice=document.getElementById("txOffice");
		var ftxContact=document.getElementById("txContact");
		var ftxBenefit=document.getElementById("txBenefit");		
		var ftxMm4=document.getElementById("txMm4");		
		var ftxDd4=document.getElementById("txDd4");		
		var ftxYy4=document.getElementById("txYy4");
		
		if(!chkNull(ftxType.value)) {
		alert(" Field 'Type of Benefit' under 'Employment Information' is not valid");
		ftxType.focus();
		return false;
		}
		
		if(!chkNull(ftxOffice.value)) {
		alert(" Field 'Centreline Office' under 'Employment Information' is not valid");
		ftxOffice.focus();
		return false;
		}
		
		if(!chkNull(ftxContact.value)) {
		alert(" Field 'Contact Name' under 'Employment Information' is not valid");
		ftxContact.focus();
		return false;
		}
		
		if(!chkNull(ftxBenefit.value)) {
		alert(" Field 'Monthly Benefit' under 'Employment Information' is not valid");
		ftxBenefit.focus();
		return false;
		}
		
		if((!chkNull(ftxMm4.value))||(!chkNull(ftxDd4.value))||(!chkNull(ftxYy4.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid");
		return false;
		}
		
		if((!chkdigital(ftxMm4.value))||(!chkdigital(ftxDd4.value))||(!chkdigital(ftxYy4.value))) {
		alert(" Field 'Next Payday' under 'Employment Information' is not valid");
		return false;
		}
		
		return true;
		}
			</script>
	</HEAD>
	<body leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<TABLE height="685" cellSpacing="0" cellPadding="0" width="848" border="0" ms_2d_layout="TRUE">
				<TR vAlign="top">
					<TD width="97" height="685"></TD>
					<TD width="751">
						<table height="684" cellSpacing="0" cellPadding="0" width="750" align="center" border="0">
							<tr>
								<td colSpan="2" height="27"><FONT face=""><uc1:top4 id="Top41" runat="server"></uc1:top4></FONT></td>
							</tr>
							<tr>
								<td vAlign="top" align="left" width="195" bgColor="#e8e6df"><uc1:leftmenu id="Leftmenu1" runat="server"></uc1:leftmenu></td>
								<td align="center" width="556">
									<table cellSpacing="0" cellPadding="0" width="500" border="0">
										<tr>
											<td>
												<TABLE height="100%" cellSpacing="0" cellPadding="0" width="397" border="0">
													<TR>
														<TD><STRONG>Employment Information<INPUT id="Hidden1" type="hidden" size="1" name="Hidden1" runat="server"></STRONG></TD>
													</TR>
													<TR>
														<TD width="168" height="20"><asp:radiobuttonlist id="RadioButtonList1" runat="server" Width="352px" AutoPostBack="True" Visible="False">
																<asp:ListItem Value="0" Selected="True">I'm  currently employed.</asp:ListItem>
																<asp:ListItem Value="1">I'm  on a benefit.</asp:ListItem>
															</asp:radiobuttonlist></TD>
													</TR>
													<TR>
														<TD>&nbsp;</TD>
													</TR>
												</TABLE>
											</td>
										</tr>
										<tr>
											<td><asp:panel id="Panel1" runat="server" Width="430px" Height="232px" Visible="True">
													<TABLE id="Table1" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD>Your Occupation:</TD>
															<TD colSpan="3"><FONT face="???"></FONT></TD>
														</TR>
														<TR>
															<TD>Employer:</TD>
															<TD colSpan="3"><INPUT id="txEmployer" type="text" size="20" name="textfield2922" runat="server"><FONT face="???" color="#990000">*
																</FONT>
															</TD>
														</TR>
														<TR>
															<TD>Employer's Address:</TD>
															<TD colSpan="3"><INPUT id="txAddress" type="text" size="20" name="textfield2923" runat="server"><FONT face="???" color="#990000">*</FONT></TD>
														</TR>
														<TR>
															<TD>Employer Phone:</TD>
															<TD colSpan="3"><INPUT id="txPhone" type="text" size="20" name="textfield2924" runat="server"><FONT face="???" color="#990000">*</FONT></TD>
														</TR>
														<TR>
															<TD width="153">Job Title:</TD>
															<TD colSpan="3"><INPUT id="txJob" type="text" size="20" name="textfield2924" runat="server"><FONT face="宋体" color="#990000">*</FONT></TD>
														</TR>
														<TR>
															<TD>Time Employed:
															</TD>
															<TD colSpan="3"><SELECT id="txYear" name="select2" runat="server">
																	<OPTION value="0" selected>0</OPTION>
																	<OPTION value="1">1</OPTION>
																	<OPTION value="2">2</OPTION>
																	<OPTION value="3">3</OPTION>
																	<OPTION value="4">4</OPTION>
																	<OPTION value="5">5</OPTION>
																	<OPTION value="6">6</OPTION>
																	<OPTION value="7">7</OPTION>
																	<OPTION value="8">8</OPTION>
																	<OPTION value="9">9</OPTION>
																	<OPTION value="10">10</OPTION>
																	<OPTION value="11">11</OPTION>
																	<OPTION value="12">12 or above</OPTION>
																</SELECT>Years&nbsp;
																<SELECT id="txMonth" name="select2" runat="server">
																	<OPTION value="0" selected>0</OPTION>
																	<OPTION value="1">1</OPTION>
																	<OPTION value="2">2</OPTION>
																	<OPTION value="3">3</OPTION>
																	<OPTION value="4">4</OPTION>
																	<OPTION value="5">5</OPTION>
																	<OPTION value="6">6</OPTION>
																	<OPTION value="7">7</OPTION>
																	<OPTION value="8">8</OPTION>
																	<OPTION value="9">9</OPTION>
																	<OPTION value="10">10</OPTION>
																	<OPTION value="11">11</OPTION>
																	<OPTION value="12">12</OPTION>
																</SELECT>Months</TD>
														</TR>
														<TR>
															<TD>Take home pay after taxes:
															</TD>
															<TD colSpan="3"><INPUT id="txIncome" type="text" size="20" name="textfield29242" runat="server"><FONT face="???" color="#990000">*</FONT></TD>
														</TR>
														<TR>
															<TD>When are you paid:
															</TD>
															<TD colSpan="3">
																<asp:RadioButtonList id="RadioButtonList2" runat="server" Width="224px" RepeatDirection="Horizontal">
																	<asp:ListItem Value="Weekly" Selected="True">Weekly</asp:ListItem>
																	<asp:ListItem Value="F'nightly">F'nightly</asp:ListItem>
																	<asp:ListItem Value="Monthly">Monthly &lt;FONT face=&quot;???&quot; color=&quot;#990000&quot;&gt;*&lt;/FONT&gt;</asp:ListItem>
																</asp:RadioButtonList></TD>
														</TR>
														<TR>
															<TD width="153">Next payday:</TD>
															<TD colSpan="3">DD <INPUT id="txDd1" type="text" size="4" name="textfield29243" runat="server">
																MM <INPUT id="txMm1" type="text" size="4" name="textfield292432" runat="server">
																YYYY <INPUT id="txYy1" type="text" size="4" name="textfield292433" runat="server"><FONT face="宋体" color="#990000">*</FONT></TD>
														</TR>
														<TR>
                      <TD>Purpose of the loan:</TD>
                      <TD colSpan=3>
<asp:textbox id=txtLoanPurpose runat="server" Width="168px" Height="45px"></asp:textbox></TD></TR>
                    <TR>
                      <TD>Your rent/mortgage payment:</TD>
                      <TD colSpan=3>$<INPUT id=txtHousePaymentValue type=text 
                        size=12 name=txtHousePaymentValue runat="server"> 
<uc1:circledropdownlist id=ddlHousePaymentCircle runat="server"></uc1:circledropdownlist></TD></TR>
                    <TR>
                      <TD>Your regular repayment to other lenders:</TD>
                      <TD colSpan=3>$<INPUT id=txtOtherLenderValue type=text 
                        size=12 name=txtOtherLenderValue runat="server"> 
<uc1:circledropdownlist id=ddlOtherLenderCircle runat="server"></uc1:circledropdownlist></TD></TR>
                    <TR>
														<TR>
															<TD align="center" colSpan="4"><INPUT id="Save1" type="submit" value="Save" name="Submit" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<INPUT type="reset" value="Reset" name="Submit2">&nbsp;&nbsp; <A href="newloan.aspx">
																	return</A></TD>
														</TR>
													</TABLE>
												</asp:panel></td>
										</tr>
										<tr>
											<td height="202"><asp:panel id="Panel2" runat="server" Width="420px" Height="192px" Visible="False">
													<TABLE id="Table2" cellSpacing="0" cellPadding="0" width="100%" border="0">
														<TR>
															<TD width="127">Type of benefit:</TD>
															<TD colSpan="3"><INPUT id="txType" type="text" size="15" name="textfield2925" runat="server"><FONT face="???" color="#990000">*
																</FONT>
															</TD>
														</TR>
														<TR>
															<TD height="23">Centrelink Office:</TD>
															<TD colSpan="3" height="23"><INPUT id="txOffice" type="text" size="15" name="textfield29222" runat="server"><FONT face="???" color="#990000">*</FONT></TD>
														</TR>
														<TR>
															<TD>Contact Name:</TD>
															<TD colSpan="3"><INPUT id="txContact" type="text" size="15" name="textfield29232" runat="server"><FONT face="???" color="#990000">*</FONT></TD>
														</TR>
														<TR>
															<TD height="22">How long on this benefit:
															</TD>
															<TD colSpan="3" height="22"><SELECT id="txYear2" name="select2" runat="server">
																	<OPTION value="0" selected>0</OPTION>
																	<OPTION value="1">1</OPTION>
																	<OPTION value="2">2</OPTION>
																	<OPTION value="3">3</OPTION>
																	<OPTION value="4">4</OPTION>
																	<OPTION value="5">5</OPTION>
																	<OPTION value="6">6</OPTION>
																	<OPTION value="7">7</OPTION>
																	<OPTION value="8">8</OPTION>
																	<OPTION value="9">9</OPTION>
																	<OPTION value="10">10</OPTION>
																	<OPTION value="11">11</OPTION>
																	<OPTION value="12">12 or above</OPTION>
																</SELECT>Years&nbsp;
																<SELECT id="txMonth2" name="select2" runat="server">
																	<OPTION value="0" selected>0</OPTION>
																	<OPTION value="1">1</OPTION>
																	<OPTION value="2">2</OPTION>
																	<OPTION value="3">3</OPTION>
																	<OPTION value="4">4</OPTION>
																	<OPTION value="5">5</OPTION>
																	<OPTION value="6">6</OPTION>
																	<OPTION value="7">7</OPTION>
																	<OPTION value="8">8</OPTION>
																	<OPTION value="9">9</OPTION>
																	<OPTION value="10">10</OPTION>
																	<OPTION value="11">11</OPTION>
																	<OPTION value="12">12</OPTION>
																</SELECT>Months</TD>
														</TR>
														<TR>
															<TD>Take Home Benefit:</TD>
															<TD colSpan="3"><INPUT id="txBenefit" type="text" size="15" name="textfield2924222" runat="server"><FONT face="???" color="#990000">*</FONT></TD>
														</TR>
														<TR>
															<TD>When are you paid:
															</TD>
															<TD colSpan="3">
																<asp:RadioButtonList id="RadioButtonList3" runat="server" Width="224px" RepeatDirection="Horizontal">
																	<asp:ListItem Value="Weekly" Selected="True">Weekly</asp:ListItem>
																	<asp:ListItem Value="F'nightly">F'nightly</asp:ListItem>
																	<asp:ListItem Value="Monthly">Monthly &lt;FONT face=&quot;???&quot; color=&quot;#990000&quot;&gt;*&lt;/FONT&gt;</asp:ListItem>
																</asp:RadioButtonList></TD>
														</TR>
														<TR>
															<TD width="162">Next benefit due:</TD>
															<TD colSpan="3">DD <INPUT id="txDd4" style="WIDTH: 40px; HEIGHT: 22px" type="text" size="1" name="textfield292436"
																	runat="server"> MM <INPUT id="txMm4" style="WIDTH: 40px; HEIGHT: 22px" type="text" size="1" name="textfield2924324"
																	runat="server"> YYYY <INPUT id="txYy4" style="WIDTH: 56px; HEIGHT: 22px" type="text" size="4" name="textfield2924334"
																	runat="server"><FONT face="宋体" color="#990000">*</FONT></TD>
														</TR>
														<TR>
															<TD align="center" colSpan="4"><INPUT id="Save2" type="submit" value="Save" name="Submit" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																<INPUT type="reset" value="Reset" name="Submit2">&nbsp;&nbsp; <A href="newloan.aspx">
																	return</A>&nbsp;
															</TD>
														</TR>
													</TABLE>
												</asp:panel></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</TD>
				</TR>
			</TABLE>
		</form>
	</body>
</HTML>
