<%@ Register TagPrefix="uc1" TagName="top4" Src="top4.ascx" %>
<%@ Page language="c#" Codebehind="newloan.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.newloan" %>
<%@ Register TagPrefix="uc1" TagName="top1" Src="top1.ascx" %>
<%@ Register TagPrefix="uc1" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="CircleDropDownList" Src="../Include/CircleDropDownList.ascx" %>
<HTML>
	<HEAD>
		<title>newloan</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../jslib/commCheck.js" type="text/javascript"></script>
		<script language="javascript" src="../jslib/jquery-cluetip/lib/jquery-1.7.1.min.js" type="text/javascript"></script>
		<script language="javascript" src="../jslib/jquery-cluetip/jquery.cluetip.min.js" type="text/javascript"></script>
		<script language="javascript">
		function CheckLoan() {	
		
		
		return true;
		}
		</script>
		<style type="text/css">
			.noTopPic LI { BACKGROUND: none transparent scroll repeat 0% 0% }
		</style>
	</HEAD>
	<body leftMargin="0" topMargin="0" MARGINHEIGHT="0" MARGINWIDTH="0">
		<form id="Form1" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="750" align="center" border="0">
				<tr>
					<td style="HEIGHT: 27px" colSpan="2"><FONT><uc1:top4 id="Top41" runat="server"></uc1:top4></FONT></td>
				</tr>
				<tr>
					<td vAlign="top" align="left" width="195" bgColor="#e8e6df"><uc1:leftmenu id="Leftmenu1" runat="server"></uc1:leftmenu></td>
					<td vAlign="top" align="center" width="556">
						<table cellSpacing="1" cellPadding="1" width="510" border="0">
							<tr>
								<td vAlign="top"><asp:panel id="Panel2" runat="server" Height="120px" Width="472px" Visible="True">
										<TABLE border="0" cellSpacing="1" cellPadding="1" width="510">
											<TR>
												<TD><FONT size="+0"></FONT><FONT size="+0"></FONT><BR>
													<BR>
													<P>Please make sure your details are up to date.
														<asp:linkbutton id="LinkButton1" runat="server">Click here </asp:linkbutton>to 
														review and edit your information.
													</P>
												</TD>
											</TR>
											<TR>
												<TD>
													<P>If you have changed your banking details since your last loan application, you 
														need to contact us on 1300 138 916 or Email to <A href="mailto:apply@cashsolution.com.au">
															apply@cashsolution.com.au </A>to obtain a Change of Account Details Form.</P>
												</TD>
											</TR>
											<TR>
												<TD>
													<asp:CheckBox id="CheckBox1" runat="server" Width="192px" Text="My details are up to date"></asp:CheckBox><INPUT style="WIDTH: 40px; HEIGHT: 21px" id="Hidden3" size="1" type="hidden" name="Hidden1"
														runat="server"></TD>
											</TR>
											<TR>
												<TD align="center"><BR>
													<asp:LinkButton id="LinkButton3" runat="server">Next</asp:LinkButton></TD>
											</TR>
										</TABLE>
									</asp:panel></td>
							</tr>
							<tr>
								<td>
									<asp:Panel id="PanelWarning" runat="server" Height="120px" Width="472px" Visible="False">
										<IFRAME height="400" border="0" src="../Warning.htm" frameBorder="no" width="100%"></IFRAME>
										<DIV align="center">
											<asp:LinkButton id="Linkbutton4" runat="server">Next</asp:LinkButton></DIV>
									</asp:Panel>
								</td>
							</tr>
							<tr>
								<td><asp:panel id="Panel1" runat="server" Width="500px" Visible="False">
										<TABLE border="0" cellSpacing="0" cellPadding="0" width="500">
											<TR>
												<TD><FONT size="+0"></FONT><BR>
													Review your information listed below; click the <STRONG>Edit </STRONG>button 
													above each item to change the information. Be sure to click&nbsp;<STRONG>Save </STRONG>
													when you're done.
												</TD>
											</TR>
											<TR>
												<TD>
													<TABLE id="Table1" border="0" cellSpacing="0" cellPadding="0" width="504">
														<TR>
															<TD style="HEIGHT: 39px"><FONT size="+0"></FONT><FONT size="+0"></FONT><FONT size="+0"></FONT><BR>
																<STRONG>Member 
																	Information&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
																	<A href="detailnew.aspx">Edit</A> </STRONG>
															</TD>
														</TR>
														<TR>
															<TD>
																<TABLE style="WIDTH: 496px; HEIGHT: 100px" id="Table2" border="0" cellSpacing="0" cellPadding="0"
																	width="496">
																	<TR>
																		<TD style="WIDTH: 133px" width="133">First Name:</TD>
																		<TD style="WIDTH: 118px" width="118"><%=txFname%></TD>
																		<TD style="WIDTH: 133px">Last Name:</TD>
																		<TD style="WIDTH: 118px"><%=txLname%></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 133px">Postcode:</TD>
																		<TD style="WIDTH: 118px"><%=txPost%></TD>
																		<TD style="WIDTH: 91px">E-Mail:
																		</TD>
																		<TD><%=txEmail%></TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 133px">Driver Licence Number:</TD>
																		<TD style="WIDTH: 118px"><%=txDriver%></TD>
																		<TD style="WIDTH: 91px">State Issued:</TD>
																		<TD><%=txIssue%><FONT size="+0"></FONT></TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
														<TR>
															<TD>
																<TABLE id="Table3" border="0" cellSpacing="0" cellPadding="0" width="397">
																	<TR>
																		<TD>Address&nbsp;:</TD>
																		<TD colSpan="3"><%=txStreet%></TD>
																	</TR>
																	<TR>
																		<TD>City:</TD>
																		<TD style="WIDTH: 80px" width="80"><%=txCity%></TD>
																		<TD style="WIDTH: 104px" width="104" colSpan="2">&nbsp;&nbsp; State:&nbsp;
																			<%=selState%>
																		</TD>
																	</TR>
																	<TR>
																		<TD style="WIDTH: 198px" colSpan="2">Phone Number:</TD>
																		<TD colSpan="2"><%=txTel%></TD>
																	</TR>
																	<TR>
																		<TD colSpan="2">&nbsp;</TD>
																	</TR>
																</TABLE>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD>
													<TABLE id="Table11" border="0" cellSpacing="0" cellPadding="0" width="397">
														<TR>
															<TD colSpan="2"><STRONG>Bank details</STRONG>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
															</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 124px">Bank Name:
																<%=BankName%>
															</TD>
															<TD>Branch:
																<%=Branch%>
															</TD>
														</TR>
														<TR>
															<TD colSpan="2">Account Name:
																<%=AName%>
															</TD>
														</TR>
														<TR>
															<TD style="WIDTH: 124px">BSB:
																<%=Bsb%>
															</TD>
															<TD>Account Number:
																<%=ANumber%>
															</TD>
														</TR>
														<TR>
															<TD colSpan="2">Preferred methods:<%=MContact%></TD>
														</TR>
														<TR>
															<TD colSpan="2" align="center">
																<asp:LinkButton id="LinkButton2" runat="server">Save</asp:LinkButton></TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
										</TABLE>
									</asp:panel></td>
							</tr>
							<tr>
								<td><asp:panel id="Panel3" runat="server" Height="620px" Width="472px" Visible="False">
										<TABLE border="0" cellSpacing="0" cellPadding="0" width="500">
											<TR>
												<TD width="137">Name:
												</TD>
												<TD width="363"><%=huiName%><FONT size="+0"></FONT></TD>
											</TR>
											<TR>
												<TD>Customer Number:
												</TD>
												<TD><%=CustomerNum%><FONT size="+0"></FONT></TD>
											</TR>
											<TR>
												<TD>Item you want to pawn:
												</TD>
												<TD colSpan="3">
													<asp:DropDownList id="drpItems" runat="server" Width="100px">
														<asp:ListItem>Select</asp:ListItem>
														<asp:ListItem>Ring</asp:ListItem>
														<asp:ListItem>Bracelet</asp:ListItem>
														<asp:ListItem>Necklace</asp:ListItem>
														<asp:ListItem>Charm</asp:ListItem>
														<asp:ListItem>Earrings</asp:ListItem>
														<asp:ListItem>Other jewellery </asp:ListItem>
														<asp:ListItem>Gold 每 Coins</asp:ListItem>
														<asp:ListItem>Silver 每 Coins</asp:ListItem>
														<asp:ListItem>Metal 每 Gold </asp:ListItem>
														<asp:ListItem>Metal 每 Silver</asp:ListItem>
														<asp:ListItem>Metal 每 Platinum</asp:ListItem>
													</asp:DropDownList></TD>
											</TR>
											<TR>
												<TD>Condition of Item:
												</TD>
												<TD>
													<asp:DropDownList id="drpItemCondition" runat="server" Width="100px">
														<asp:ListItem>Select</asp:ListItem>
														<asp:ListItem>New</asp:ListItem>
														<asp:ListItem>Used - No damage</asp:ListItem>
														<asp:ListItem>Normal were and tear</asp:ListItem>
														<asp:ListItem>Not applicable</asp:ListItem>
													</asp:DropDownList></TD>
											</TR>
											<TR>
												<TD>Item Description:
												</TD>
												<TD>
													<asp:TextBox id="txItemDescription" runat="server" Width="250" TextMode="MultiLine" Rows="5"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD>Upload a Photo:
												</TD>
												<TD><INPUT id="ItemPhoto" type="file" name="ItemPhoto" runat="server">
												</TD>
											</TR>
											<TR>
												<TD colSpan="2"><STRONG>Loan Information </STRONG>
												</TD>
											</TR>
											<TR>
												<TD>Loan Requested:</TD>
												<TD><FONT color="#990000">$</FONT><INPUT style="WIDTH: 166px; HEIGHT: 22px" id="txLoan" size="11" name="Text1" runat="server"><FONT color="#990000">*<INPUT style="WIDTH: 11px; HEIGHT: 22px" id="Hidden1" size="1" type="hidden" name="Hidden1"
															runat="server"><INPUT style="WIDTH: 11px; HEIGHT: 22px" id="Hidden2" size="1" type="hidden" name="Hidden1"
															runat="server"></FONT></TD>
											</TR>
											<TR>
												<TD colSpan="2">
													<UL class="noTopPic">
														<LI>
															<INPUT id="installment0" value="customDays" type="radio" name="installmentType" runat="server"><LABEL for="installment0">
																Repayment in</LABEL>
															<asp:TextBox id="installmentDays" runat="server" Width="20"></asp:TextBox><LABEL for="installment0">days 
																(maximum of 62days)</LABEL>
														<LI>
															<INPUT id="installment1" value="fixedDays" type="radio" name="installmentType" runat="server"><LABEL for="installment1">
																Repay over</LABEL>
															<asp:DropDownList style="Z-INDEX: 0" id="installmentCount" runat="server">
																<asp:ListItem Value="1">1</asp:ListItem>
																<asp:ListItem Value="2">2</asp:ListItem>
																<asp:ListItem Value="3">3</asp:ListItem>
															</asp:DropDownList><LABEL for="installment1">instalments</LABEL>
														</LI>
													</UL>
													<UL class="noTopPic">
														<LI>
															<TABLE>
																<TR>
																	<TD>&nbsp; &nbsp; &nbsp; Your pay frequency:
																	</TD>
																	<TD>
																		<asp:RadioButtonList id="payCircleType" runat="server" RepeatDirection="Horizontal">
																			<asp:ListItem Value="Weekly" Selected="True">Weekly</asp:ListItem>
																			<asp:ListItem Value="Fnightly">F'nightly</asp:ListItem>
																			<asp:ListItem Value="Monthly">Monthly</asp:ListItem>
																		</asp:RadioButtonList></TD>
																</TR>
															</TABLE>
														<LI>
															&nbsp; &nbsp; &nbsp; Next Payday:DD
															<asp:TextBox id="nextPaydayDD" runat="server" Width="20"></asp:TextBox>/MM
															<asp:TextBox id="nextPaydayMM" runat="server" Width="20"></asp:TextBox>/YYYY
															<asp:TextBox id="nextPaydayYYYY" runat="server" Width="40"></asp:TextBox></LI></UL>
													<asp:button id="Button1" runat="server" Text="Calculate"></asp:button><INPUT style="WIDTH: 16px; HEIGHT: 22px" id="txInstallment" size="1" name="Text2" runat="server"
														visible="false">
												</TD>
											</TR>
											<TR height="5">
												<TD colSpan="2"><STRONG>Repayment Schedule:</STRONG></TD>
											</TR>
											<TR>
												<TD colSpan="2">
													<TABLE border="1" cellSpacing="0" borderColor="#d4d0c8" cellPadding="0" width="95%">
														<TR>
															<TD>Repayment Schedule</TD>
															<TD>Installment1:
																<asp:TextBox id="txd1" runat="server" Width="72px" BorderStyle="None" BorderWidth="0px" ReadOnly="True"></asp:TextBox>&nbsp; 
																&nbsp; $
																<asp:TextBox id="txs1" runat="server" Width="72px" BorderStyle="None" BorderWidth="0px" ReadOnly="True"></asp:TextBox><BR>
																Installment2:
																<asp:TextBox id="txd2" runat="server" Width="72px" BorderStyle="None" BorderWidth="0px" ReadOnly="True"></asp:TextBox>&nbsp; 
																&nbsp; $
																<asp:TextBox id="txs2" runat="server" Width="72px" BorderStyle="None" BorderWidth="0px" ReadOnly="True"></asp:TextBox><BR>
																Installment3:
																<asp:TextBox id="txd3" runat="server" Width="72px" BorderStyle="None" BorderWidth="0px" ReadOnly="True"></asp:TextBox>&nbsp; 
																&nbsp; $
																<asp:TextBox id="txs3" runat="server" Width="72px" BorderStyle="None" BorderWidth="0px" ReadOnly="True"></asp:TextBox><BR>
															</TD>
														</TR>
													</TABLE>
												</TD>
											</TR>
											<TR>
												<TD colSpan="2"><TEXTAREA style="WIDTH: 508px; HEIGHT: 84px" rows="11" cols="60">By typing my name below I am applying for electronic pawn loan and certify that this information is true and correct under penalty of perjury. I authorize Golden Bridge Finance Pty Ltd to verify any information submitted on this application.
													</TEXTAREA></TD>
											</TR>
											<TR>
												<TD colSpan="2">
													<asp:CheckBox id="GoldPackBack" runat="server" Text="Get your Free GoldPack overnight"></asp:CheckBox><BR>
												</TD>
											</TR>
											<TR>
												<TD colSpan="2">To Sign,please type your FULL name here:
													<asp:TextBox id="txFullname" runat="server" Width="192px"></asp:TextBox></TD>
											</TR>
											<TR>
												<TD colSpan="2" align="center"><INPUT id="Button2" value="I agree, Submit" type="button" name="Button2" runat="server"><FONT size="+0">&nbsp;&nbsp; 
														&nbsp; </FONT><INPUT value="Reset" type="reset"></TD>
											</TR>
										</TABLE>
									</asp:panel></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
		<script type="text/javascript">
			$(document).ready(function(){
				var installment0Checked= $("#installment0").attr("checked");
				var installment1Checked= $("#installment1").attr("checked");
	            
				if((installment0Checked== false && installment1Checked==false )|| typeof(installment0Checked)=="undefined" && typeof(installment1Checked)=="undefined")
				{
					$("#installment1").attr("checked","true");
				}
				
				$('a.title').cluetip({splitTitle: '|', arrows: true});
			});
		</script>
	</body>
</HTML>
