<%@ Page language="c#" Codebehind="Pawn-Loan-Result.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Pawn_Loans.Pawn_Loan_Result" %>
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
										<a href="http://gbcash.com.au/how-it-works/">How it Works</a></li>
									<li>
										<a href="http://gbcash.com.au/Costs-And-Fees/">Costs &amp; Fees</a></li>
									<li>
										<a href="http://gbcash.com.au/faq.htm">FAQs</a></li>
									<li>
										<a href="http://gbcash.com.au/apply/">Apply Now</a></li>
								</ul>
								</li>
							<li>
								<a href="#">Pawn Loans</a>
								<ul class="nestedchildren">
									<li>
										<a href="http://pawn.gbcash.com.au/Pawn-Loans/how-it-works.aspx">How it Works</a></li>
									<li>
										<a href="http://pawn.gbcash.com.au/Costs-And-Fees/">Costs &amp; Fees</a></li>
									<li>
										<a href="http://pawn.gbcash.com.au/Pawn-Loans/Acceptable-Collateral.aspx">Acceptable 
											Collateral</a></li>
									<li>
										<a href="http://pawn.gbcash.com.au/Pawn-Online-Now.aspx">Pawn Online Now</a></li>
								</ul>
								</li>
							<li>
								<a href="#">Secured Personal Loans</a>
								<ul class="nestedchildren1">
									<li>
										<a href="http://secured.gbcash.com.au/home/how-it-works/">How it Works</a></li>
									<li>
										<a href="http://secured.gbcash.com.au/Home/Costs-And-Fees">Costs &amp; Fees</a></li>
									<li>
										<a href="http://secured.gbcash.com.au/Home/Faqs">FAQs</a></li>
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
									We Buy</a></li>
							<li>
								<a href="http://gbcash.com.au/Sell-Your-Old-Gold-Jewellery/How-To-Sell.aspx">How To 
									Sell</a></li>
							<li>
								<a href="http://gbcash.com.au/Sell-Your-Old-Gold-Jewellery/Today-Prices.aspx">Today’s 
									Prices</a></li>
							<li>
								<a href="http://gbcash.com.au/Sell-Your-Old-Gold-Jewellery/Visit-Us-In-Person.aspx">
									Visit Us In Person</a></li>
						</ul>
					</li>
					<li class="menuItme">
						<a class="menuItemA" href="#">Information</a>
						<ul class="children">
							<li>
								<a href="http://gbcash.com.au/Information/Newsletter.htm">Newsletter</a></li>
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
				<div id="content" style="MARGIN-LEFT: 5px; TOP: 0px; LEFT: 0px">
					<h1>
						Pawn Loan Result</h1>
					<p>Thanks for your pawn loan request. To successfully apply for your loan, you need 
						to send your collateral to us for analysis. You can bring them to our Melbourne 
						office in person or post via our insured GoldPack for free.
					</p>
					<p>Items We Accept</p>
					<ul>
						<li>
							All 9-24 Carat Jewellery</li>
						<li>
							Scrap Gold, Silver or Platinum</li>
						<li>
							Gold - Coins</li>
						<li>
							Silver - Coins</li>
						<li>
							Metal - Gold</li>
						<li>
							Metal - Silver</li>
						<li>
							Metal - Platinum</li>
					</ul>
					<p>
						If you have any question or need any further assistance in regards to your pawn 
						loan request, please contact us on 1300 137 906 or email <a href="mailto:apply@gbcash.com.au">
							apply@gbcash.com.au</a>
					</p>
					<input type="button" value="Close" id="btnClose" />
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
            
            $("#btnClose").click(function(){
				window.location.href="http://gbcash.com.au/default.htm";
            });
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
