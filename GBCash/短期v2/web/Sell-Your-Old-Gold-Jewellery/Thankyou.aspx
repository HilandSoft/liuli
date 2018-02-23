<%@ page language="C#" autoeventwireup="true" inherits="Sell_Your_Old_Gold_Jewellery_Thankyou, App_Web_megxcffm" enableviewstatemac="false" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head>
<meta http-equiv="Content-Type" content="text/html; charset=UTF-8" />
<title>Golden Bridge Cash Solution</title>
<link href="../CSSN/style.css" rel="stylesheet" type="text/css" />
<script src="../javascriptN/jquery-1.4.4.min.js" type="text/javascript"></script>

<style type="text/css">
<!--
.style1 {
	font-size: 16px;
	font-weight: bold;
}
-->
</style>
</head>

<body>
<!--start top-->
<div id="top">
<div class="logo"><a href="../"><img src="../imagesN/logo.jpg" alt="Golden Bridge Cash Solution" /></a></div>
<div class="call">Call Us 1300 137 906</div>
</div>
<!--end top-->

<!--start nav-->
 <div id="nav">
        <ul class="menus">
            <li class="menuItme"><a class="menuItemA actived" href="../default.htm">Home</a> </li>   
             <li class="menuItme"><a class="menuItemA" href="../About-Us/">About Us</a> </li>        
            <li class="menuItme"><a class="menuItemA" href="#">Loan Options</a>
                <ul class="children">
                    <li><a href="#">Payday Loans</a>
                        <ul class="nestedchildren">
                            <li><a href="http://gbcash.com.au/how-it-works/">How it Works</a></li>
                            <li><a href="http://gbcash.com.au/Costs-And-Fees/">Costs & Fees</a></li>
                            <li><a href="http://gbcash.com.au/faq.htm">FAQs</a></li>  
                             <li><a href="http://gbcash.com.au/apply/">Apply Now</a></li>                        
                        </ul>
                    </li>
                     <li><a href="#">Pawn Loans</a>
                     <ul class="nestedchildren">
                            <li><a href="http://gbcash.com.au/Pawn-Loans/how-it-works.aspx">How it Works</a></li>
                            <li><a href="http://gbcash.com.au/Pawn-Loans/Acceptable-Collateral.aspx">Acceptable Collateral</a></li>
                            <li><a href="http://gbcash.com.au/Pawn-Loans/Pawn-Online-Now.aspx">Pawn Online Now</a></li>                            
                      </ul>
                    </li>
                     <li><a href="#">Secured Personal Loans</a>
                     <ul class="nestedchildren1">
                            <li><a href="http://secured.gbcash.com.au/home/how-it-works/">How it Works</a></li>
                            <li><a href="http://secured.gbcash.com.au/Home/Costs-And-Fees">Costs & Fees</a></li>
                            <li><a href="http://secured.gbcash.com.au/Home/Faqs">FAQs</a></li>  
                             <li><a href="http://secured.gbcash.com.au/Secured/Pre-qualification">Apply Now</a></li>                         
                       </ul>
                     </li>
                </ul>
            </li>           
            <li class="menuItme"><a class="menuItemA" href="#">Sell Your Old Gold Jewellery</a>
                <ul class="children">
                    <li><a href="../Sell-Your-Old-Gold-Jewellery/What-We-Buy.aspx">What We Buy</a></li>
                    <li><a href="../Sell-Your-Old-Gold-Jewellery/How-To-Sell.aspx">How To Sell</a></li>
                    <li><a href="../Sell-Your-Old-Gold-Jewellery/Today-Prices.aspx">Today’s Prices</a></li>
                    <li><a href="../Sell-Your-Old-Gold-Jewellery/Visit-Us-In-Person.aspx">Visit Us In Person</a></li>
                </ul>
            </li>           
            <li class="menuItme">
					<a class="menuItemA" href="#">Calculators</a>
					<ul class="children">
						<li>
							<a href="http://gbcash.com.au/Calculator/default.htm">Payday Loans</a>
						<li>
							<a href="http://secured.gbcash.com.au/Home/Secured-Loans-Calculator/">Secured Personal Loans</a></li>
					</ul>
				</li>
            <li class="last menuItme"><a class="menuItemA" href="../Contact-Us/">Contact Us</a> </li>
        </ul>
</div>
<!--end nav-->

<!--start homebanner-->
<!--start subbanner-->
<div id="subheader">
<h1>Secure Gold Pack Request</h1>
</div>
<!--end subbanner-->

<!--start main-->
<div id="main">
<!--start process-->
<div id="process">
<h1>Simple Steps to Sell Gold </h1>

<ul>
<li id="liPreQualification" class="activedprocess"><a class="activedprocesstxt">Send your Gold Items </a></li>
<li id="liInitial" ><a >Free Valuation </a></li>
<li id="liBusiness"><a >Accept Offer </a></li>
<li id="liPersonal"><a >Receive Payment</a></li>
</ul>

</div>
<!--end process-->

<!--start content-->
<div id="content">
<div>
    <p class="style1">Thank you for your Secure Gold Pack request! One of our customer representatives will contact you shortly. </p>
    <p>&nbsp; </p>
</div>
</div>
<!--end content-->

</div>
<!--end main-->

<!--start footer-->
<div style="clear:both;"></div><div id="footer">&copy; Copyright Golden Bridge Cash Solution Pty Ltd 2011</div>
<!--end footer-->
<script type="text/javascript">
    $(document).ready(function () {

    });

    function setCurrentMenu(liSelector, aSelector) {
        $(liSelector).addClass("activedprocess");
        $(aSelector).addClass("activedprocesstxt");
    }
</script>
<script type="text/javascript">
    var mouseover_tid = [];
    var mouseout_tid = [];

    jQuery(document).ready(function () {

        jQuery('.menus > li, .menus > li > .children > li').each(function (index) {
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
    });	
    </script>
</body>
</html>