<%@ Page language="c#" Codebehind="Pawn-Loan-Information.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Pawn_Loans.Pawn_Loan_Information" %>
<HTML>
	<HEAD>
		<title>Golden Bridge Cash Solution</title>
		<meta http-equiv="Content-Type" content="text/html; charset=UTF-8">
		<link href="./CSSN/style.css" rel="stylesheet" type="text/css">
			<link href="./CSSN/jquery-ui-1.9.0.custom.min.css" rel="stylesheet" type="text/css">
				<!--<script type="text/javascript" src="http://code.jquery.com/jquery-1.8.0.min.js"></script>-->
				<script type="text/javascript" src="./javascriptN/jquery-1.4.4.min.js"></script>
				<script type="text/javascript" src="./javascriptN/jquery.watermark.min.js"></script>
				<script src="./javascriptN/jquery.validate.js" type="text/javascript"></script>
				<script src="http://code.jquery.com/ui/jquery-ui-git.js" type="text/javascript"></script>
				<style type="text/css"> .form { WIDTH: 100% } .leftrow { TEXT-ALIGN: right; PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; WIDTH: 35%; PADDING-RIGHT: 5px; PADDING-TOP: 0px } .rightrow { TEXT-ALIGN: left; PADDING-BOTTOM: 5px; PADDING-LEFT: 5px; WIDTH: 65%; PADDING-RIGHT: 5px; PADDING-TOP: 0px } .label { LINE-HEIGHT: 28px; PADDING-LEFT: 20px; FONT-FAMILY: Georgia, "Times New Roman" ,Times,serif; HEIGHT: 28px; COLOR: #a46610; FONT-SIZE: 14px } UL.btns A { TEXT-ALIGN: center; LINE-HEIGHT: 35px; WIDTH: 105px; DISPLAY: block; FONT-FAMILY: Georgia, "Times New Roman" ,Times,serif; BACKGROUND: url(../imagesN/greenbtn.gif) no-repeat 0px 0px; HEIGHT: 35px; COLOR: #ffffff; FONT-SIZE: 15px; TEXT-DECORATION: none } UL.btns A:hover { COLOR: black } #content UL LI { LIST-STYLE: none none outside } </style>
	</HEAD>
	<body>
		<form id="form1" runat="server">
			<!--start top-->
			<div id="top">
				<div class="logo">
					<a href="./"><img src="./imagesN/logo.jpg" alt="Golden Bridge Cash Solution"></a></div>
				<div class="call">
					Call Us 1300 137 906</div>
			</div>
			<!--end top-->
			<!--start nav-->
			<div id="nav">
				<ul class="menus">
					<li class="menuItme">
						<a class="menuItemA actived" href="http://gbcash.com.au/default.htm">Home</a>
					</li>
					<li class="menuItme">
						<a class="menuItemA" href="http://gbcash.com.au/About-Us/">About Us</a>
					</li>
					<li class="menuItme">
						<a class="menuItemA" href="#">Loan Options</a>
						<ul class="children">
							<li>
								<a href="#">Payday Loans</a>
								<ul class="nestedchildren">
									<li>
										<a href="http://gbcash.com.au/how-it-works/">How it Works</a>
									<li>
										<a href="http://gbcash.com.au/Costs-And-Fees/">Costs &amp; Fees</a>
									<li>
										<a href="http://gbcash.com.au/faq.htm">FAQs</a>
									<li>
										<a href="http://gbcash.com.au/apply/">Apply Now</a></li>
								</ul>
							<li>
								<a href="#">Pawn Loans</a>
								<ul class="nestedchildren">
									<li>
										<a href="http://pawn.gbcash.com.au/Pawn-Loans/how-it-works.aspx">How it Works</a>
									<li>
										<a href="http://pawn.gbcash.com.au/Costs-And-Fees/">Costs &amp; Fees</a>
									<li>
										<a href="http://pawn.gbcash.com.au/Pawn-Loans/Acceptable-Collateral.aspx">Acceptable 
											Collateral</a>
									<li>
										<a href="http://pawn.gbcash.com.au/Pawn-Online-Now.aspx">Pawn Online Now</a></li>
								</ul>
							<li>
								<a href="#">Secured Personal Loans</a>
								<ul class="nestedchildren1">
									<li>
										<a href="http://secured.gbcash.com.au/home/how-it-works/">How it Works</a>
									<li>
										<a href="http://secured.gbcash.com.au/Home/Costs-And-Fees">Costs &amp; Fees</a>
									<li>
										<a href="http://secured.gbcash.com.au/Home/Faqs">FAQs</a>
									<li>
										<a href="http://secured.gbcash.com.au/Secured/Pre-qualification">Apply Now</a></li>
								</ul>
							</li>
						</ul>
					</li>
					<li class="menuItme">
						<a class="menuItemA" href="#">Sell Your Old Gold Jewellery</a>
						<ul class="children">
							<li>
								<a href="http://gbcash.com.au/Sell-Your-Old-Gold-Jewellery/What-We-Buy.aspx">What 
									We Buy</a>
							<li>
								<a href="http://gbcash.com.au/Sell-Your-Old-Gold-Jewellery/How-To-Sell.aspx">How To 
									Sell</a>
							<li>
								<a href="http://gbcash.com.au/Sell-Your-Old-Gold-Jewellery/Today-Prices.aspx">Today’s 
									Prices</a>
							<li>
								<a href="http://gbcash.com.au/Sell-Your-Old-Gold-Jewellery/Visit-Us-In-Person.aspx">
									Visit Us In Person</a></li>
						</ul>
					</li>
					<li class="menuItme">
						<a class="menuItemA" href="#">Information</a>
						<ul class="children">
							<li>
								<a href="http://gbcash.com.au/Information/Newsletter.htm">Newsletter</a>
							<li>
								<a href="http://gbcash.com.au/Information/Relevant-Links.htm">Relevant Links</a></li>
						</ul>
					</li>
					<li class="last menuItme">
						<a class="menuItemA" href="http://gbcash.com.au/Contact-Us/">Contact Us</a>
					</li>
				</ul>
			</div>
			<!--end nav-->
			<!--start homebanner-->
			<!--start subbanner-->
			<div id="subheader">
				<h1>
					Pawn Online Now</h1>
			</div>
			<!--end subbanner-->
			<!--start main-->
			<div id="main">
				<!--start process-->
				<div id="process" style="FLOAT: right">
					<h1 class="phoneicon">
						Golden Bridge Cash Solution</h1>
					<ul>
						<li class="contactdetials">
							Tel: 1300 137 906</li>
						<li class="contactdetials">
							Fax: 1300 138 916</li>
						<li class="contactdetials">
							Email: info@cashsolution.com.au
						</li>
						<li class="contactdetials">
							PO Box 347</li>
						<li class="contactdetials">
							Collins Street West, VIC 8007</li>
						<li class="contactdetials">
							92 112 483 226</li>
						<li class="contactdetials">
							Australian Credit Licence No.: 388601</li>
						<li class="contactdetials">
							COSL member No.: 0002491</li>
						<li class="contactdetials">
							<img style="PADDING-TOP: 20px" src="./imagesN/contactpic.jpg" width="255" height="170"></li>
					</ul>
				</div>
				<!--end process-->
				<div id="content" style="PADDING-BOTTOM: 10px; MARGIN-LEFT: 5px; TOP: 0px; LEFT: 0px">
					<h1>
						Loan Information</h1>
					<table cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
						<TR>
							<TD width="143">Request Value:</TD>
							<TD>$<INPUT id="txLoan" style="WIDTH: 166px; HEIGHT: 22px" name="Text1" runat="server"><FONT color="#990000">*<INPUT id="Hidden1" style="WIDTH: 11px; HEIGHT: 22px" type="hidden" size="1" name="Hidden1"
										runat="server"> </FONT>
							</TD>
						</TR>
						<tr>
							<td colspan="2">Note: Final quote will be provided based on the analysis of the 
								items upon receipt.
							</td>
						</tr>
						<tr>
							<td align="center"></td>
						</tr>
					</table>
					<br>
					<h1>
						Loan Repayment Options</h1>
					<p>To make it easier for you to manage your repayment(s), we highly suggest you to 
						choose your payday as repayment date. There is NO interest up to your next 
						payday, if you choose to repay in instalment(s). However, if you decided to 
						repay early, interest will be calculated daily from the date of loan approval.
					</p>
					<ul>
						<li>
							<input type="radio" name="installmentType" value="customDays" runat="server" id="installment0"><label for="installment0">
								Repayment in</label>
							<asp:TextBox id="installmentDays" runat="server" Width="20"></asp:TextBox>
							<label for="installment0">
								days (maximum of 62days)</label>
						<li>
							<input type="radio" name="installmentType" value="fixedDays" runat="server" id="installment1"><label for="installment1">
								Repay over</label>
							<asp:DropDownList style="Z-INDEX: 0" id="installmentCount" runat="server">
								<asp:ListItem Value="1">1</asp:ListItem>
								<asp:ListItem Value="2">2</asp:ListItem>
								<asp:ListItem Value="3">3</asp:ListItem>
							</asp:DropDownList>
							<label for="installment1">instalments</label></li>
					</ul>
					<ul>
						<li>
							<table>
								<tr>
									<td>&nbsp; &nbsp; &nbsp; Your pay frequency:
									</td>
									<td>
										<asp:RadioButtonList id="payCircleType" runat="server" RepeatDirection="Horizontal">
											<asp:ListItem Value="Weekly" Selected="True">Weekly</asp:ListItem>
											<asp:ListItem Value="Fnightly">F'nightly</asp:ListItem>
											<asp:ListItem Value="Monthly">Monthly</asp:ListItem>
										</asp:RadioButtonList>
									</td>
								</tr>
							</table>
						<li>
							&nbsp; &nbsp; &nbsp; Next Payday:DD<asp:TextBox id="nextPaydayDD" runat="server" Width="20"></asp:TextBox>/MM<asp:TextBox id="nextPaydayMM" runat="server" Width="20"></asp:TextBox>/YYYY<asp:TextBox id="nextPaydayYYYY" runat="server" Width="40"></asp:TextBox>
						</li>
					</ul>
					<p><asp:Button id="btnCalculate" runat="server" Text="Calculate"></asp:Button>
					</p>
					<table cellSpacing="0" cellPadding="0" width="100%" border="0" align="center">
						<TR>
							<TD width="160" colSpan="3"><BR>
								<STRONG>Repayment Schedule</STRONG></TD>
						</TR>
						<TR>
							<TD>&nbsp;</TD>
							<TD>Date due
							</TD>
							<TD>Repayment due</TD>
						</TR>
						<TR>
							<TD>1st Installment
							</TD>
							<TD><FONT>
									<asp:TextBox id="d1F" runat="server" Width="113px" BorderStyle="None" ReadOnly="True"></asp:TextBox></FONT></TD>
							<TD><FONT>
									<asp:TextBox id="s1" runat="server" Width="113px" BorderStyle="None" ReadOnly="True"></asp:TextBox></FONT></TD>
						</TR>
						<TR>
							<TD>2nd Installment
							</TD>
							<TD><FONT>
									<asp:TextBox id="d2F" runat="server" Width="113px" BorderStyle="None" ReadOnly="True"></asp:TextBox></FONT></TD>
							<TD><FONT>
									<asp:TextBox id="s2" runat="server" Width="113px" BorderStyle="None" ReadOnly="True"></asp:TextBox></FONT></TD>
						</TR>
						<TR>
							<TD height="21" width="143">3rd Installment
							</TD>
							<TD><FONT>
									<asp:TextBox id="d3F" runat="server" Width="113px" BorderStyle="None" ReadOnly="True"></asp:TextBox></FONT></TD>
							<TD><FONT>
									<asp:TextBox id="s3" runat="server" Width="113px" BorderStyle="None" ReadOnly="True"></asp:TextBox></FONT></TD>
						</TR>
						<TR style="DISPLAY:none">
							<TD colSpan="3">Annual Percentage Rate
								<asp:Label id="labAnnualRate" Runat="server"></asp:Label></TD>
						</TR>
					</table>
					<TABLE id="Table3" cellSpacing="0" cellPadding="0" width="100%" border="0">
						<TR>
							<TD>&nbsp;</TD>
						</TR>
						<TR>
							<TD colSpan="4"><STRONG>Bank Information</STRONG><BR>
								This must be the account where your pay / benefit is paid into.
								<BR>
								This is the account we will credit to and deduct from</TD>
						</TR>
						<TR>
							<TD width="85">Bank Name:</TD>
							<TD width="105"><INPUT id="txBank" size="10" name="textfield2102" runat="server"> <FONT face="宋体" color="#990000">
									*</FONT></TD>
							<TD width="99">Branch:</TD>
							<TD width="108"><INPUT id="txBranch" size="10" name="textfield210" runat="server"><FONT face="宋体" color="#990000">*</FONT></TD>
						</TR>
						<TR>
							<TD>Account Name:</TD>
							<TD colSpan="3"><INPUT id="txAname" name="textfield211" runat="server"><FONT face="宋体" color="#990000">*</FONT></TD>
						</TR>
						<TR>
							<TD>BSB:</TD>
							<TD><INPUT id="txBsb" size="10" name="textfield2112" runat="server"><FONT face="宋体" color="#990000">*</FONT></TD>
							<TD>Account Number:</TD>
							<TD><INPUT id="txAnumber" size="10" name="textfield21122" runat="server"><FONT face="宋体" color="#990000">*</FONT></TD>
						</TR>
						<TR>
							<TD colSpan="2">Confirm Account Numer:</TD>
							<TD colSpan="2"><INPUT id="txCAnumber" name="textfield2113" runat="server"><FONT face="宋体" color="#990000">*</FONT></TD>
						</TR>
					</TABLE>
					<br>
					<p style="BORDER-BOTTOM: black thin solid; BORDER-LEFT: black thin solid; BORDER-TOP: black thin solid; BORDER-RIGHT: black thin solid">
						&nbsp; &nbsp; By typing my name below I am applying for electronic pawn loan 
						and certify that this information is true and correct under penalty of perjury. 
						I authorize Golden Bridge Finance Pty Ltd to verify any information submitted 
						on this application.
					</p>
					<asp:CheckBox id="GoldPackBack" runat="server" Text="Get your Free GoldPack overnight"></asp:CheckBox>
					<table width="100%">
						<TR>
							<TD colSpan="3">To Sign,please type your FULL name here:
								<asp:TextBox id="txFullname" runat="server" Width="145px"></asp:TextBox></TD>
						</TR>
						<TR>
							<TD width="143">&nbsp;</TD>
						</TR>
						<TR>
							<TD align="center" colSpan="3"><INPUT id="Submit1" style="WIDTH: 110px; HEIGHT: 24px" type="submit" value="I agree, Submit"
									name="Submit" runat="server">&nbsp;&nbsp;&nbsp;<INPUT style="WIDTH: 52px; HEIGHT: 24px" type="submit" value="Reset" name="Submit2"></TD>
						</TR>
					</table>
				</div>
			</div>
			<!--end main-->
			<!--start footer-->
			<div style="CLEAR: both">
			</div>
			<div id="footer">
				© Copyright Golden Bridge Cash Solution Pty Ltd 2011</div>
			<script type="text/javascript">

        function setCurrentMenu(liSelector, aSelector) {
            $(liSelector).addClass("activedprocess");
            $(aSelector).addClass("activedprocesstxt");
        }

        var mouseover_tid = [];
        var mouseout_tid = [];

        jQuery(document).ready(function () {
            jQuery('.menus > li,.menus > li > .children > li').each(function (index) {
                jQuery(this).hover(

			        function () {
			            var _self = this;
			            clearTimeout(mouseout_tid[index]);
			            mouseover_tid[index] = setTimeout(function () {
			                jQuery(_self).find('ul:eq(0)').fadeIn(200);
			            }, 400);
			        },

			        function () {
			            var _self = this;
			            clearTimeout(mouseover_tid[index]);
			            mouseout_tid[index] = setTimeout(function () {
			                jQuery(_self).find('ul:eq(0)').fadeOut(200);
			            }, 400);
			        }

		        );
            });
            
            var installment0Checked= $("#installment0").attr("checked");
            var installment1Checked= $("#installment1").attr("checked");
            
            if(installment0Checked== false && installment1Checked==false )
            {
				$("#installment1").attr("checked","true");
            }
        });
			</script>
			<script src="http://jqueryui.com/themeroller/themeswitchertool/"></script>
			<script>
        $.fn.themeswitcher && $('<div/>').css({
            position: "absolute",
            right: 10,
            top: 10
        }).appendTo(document.body).themeswitcher();
			</script>
			<!--end footer-->
		</form>
	</body>
</HTML>
