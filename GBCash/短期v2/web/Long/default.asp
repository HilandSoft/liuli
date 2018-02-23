<!--#include file="top.asp"-->
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<HTML>
 <HEAD>
  <TITLE>:: Welcome to Golden Bridge :: Easy Cash Solutions :: </TITLE>
  <META NAME="Generator" CONTENT="EditPlus">
  <META NAME="Author" CONTENT="">
  <META NAME="Keywords" CONTENT="">
  <META NAME="Description" CONTENT="">
<LINK href="StyleSheet\myCss.css" type="text/css" rel="stylesheet">
		<style type="text/css">#pscroller1 { BORDER-RIGHT: black 0px solid; PADDING-RIGHT: 5px; BORDER-TOP: black 0px solid; PADDING-LEFT: 15px; PADDING-BOTTOM: 5px; BORDER-LEFT: black 0px solid; WIDTH: 280px; PADDING-TOP: 5px; BORDER-BOTTOM: black 0px solid; HEIGHT: 30px; BACKGROUND-COLOR: #ffffff }
		</style>
		<script type="text/javascript">
/*
/*Example message arrays for the two demo scrollers*/

var pausecontent=new Array()
pausecontent[0]='Same Day Approval'
pausecontent[1]='Secure and Confidential'
pausecontent[2]='Fast and Easy'

		</script>
		<script type="text/javascript">
function pausescroller(content, divId, divClass, delay){
this.content=content //message array content
this.tickerid=divId //ID of ticker div to display information
this.delay=delay //Delay between msg change, in miliseconds.
this.mouseoverBol=0 //Boolean to indicate whether mouse is currently over scroller (and pause it if it is)
this.hiddendivpointer=1 //index of message array for hidden div
document.write('<div id="'+divId+'" class="'+divClass+'" style="position: relative; overflow: hidden"><div class="innerDiv" style="position: absolute; width: 100%" id="'+divId+'1">'+content[0]+'</div><div class="innerDiv" style="position: absolute; width: 100%; visibility: hidden" id="'+divId+'2">'+content[1]+'</div></div>')
var scrollerinstance=this
if (window.addEventListener) //run onload in DOM2 browsers
window.addEventListener("load", function(){scrollerinstance.initialize()}, false)
else if (window.attachEvent) //run onload in IE5.5+
window.attachEvent("onload", function(){scrollerinstance.initialize()})
else if (document.getElementById) //if legacy DOM browsers, just start scroller after 0.5 sec
setTimeout(function(){scrollerinstance.initialize()}, 500)
}

pausescroller.prototype.initialize=function(){
this.tickerdiv=document.getElementById(this.tickerid)
this.visiblediv=document.getElementById(this.tickerid+"1")
this.hiddendiv=document.getElementById(this.tickerid+"2")
this.visibledivtop=parseInt(pausescroller.getCSSpadding(this.tickerdiv))
//set width of inner DIVs to outer DIV's width minus padding (padding assumed to be top padding x 2)
this.visiblediv.style.width=this.hiddendiv.style.width=this.tickerdiv.offsetWidth-(this.visibledivtop*2)+"px"
this.getinline(this.visiblediv, this.hiddendiv)
this.hiddendiv.style.visibility="visible"
var scrollerinstance=this
document.getElementById(this.tickerid).onmouseover=function(){scrollerinstance.mouseoverBol=1}
document.getElementById(this.tickerid).onmouseout=function(){scrollerinstance.mouseoverBol=0}
if (window.attachEvent) //Clean up loose references in IE
window.attachEvent("onunload", function(){scrollerinstance.tickerdiv.onmouseover=scrollerinstance.tickerdiv.onmouseout=null})
setTimeout(function(){scrollerinstance.animateup()}, this.delay)
}


// -------------------------------------------------------------------
// animateup()- Move the two inner divs of the scroller up and in sync
// -------------------------------------------------------------------

pausescroller.prototype.animateup=function(){
var scrollerinstance=this
if (parseInt(this.hiddendiv.style.top)>(this.visibledivtop+5)){
this.visiblediv.style.top=parseInt(this.visiblediv.style.top)-5+"px"
this.hiddendiv.style.top=parseInt(this.hiddendiv.style.top)-5+"px"
setTimeout(function(){scrollerinstance.animateup()}, 100)
}
else{
this.getinline(this.hiddendiv, this.visiblediv)
this.swapdivs()
setTimeout(function(){scrollerinstance.setmessage()}, this.delay)
}
}

// -------------------------------------------------------------------
// swapdivs()- Swap between which is the visible and which is the hidden div
// -------------------------------------------------------------------

pausescroller.prototype.swapdivs=function(){
var tempcontainer=this.visiblediv
this.visiblediv=this.hiddendiv
this.hiddendiv=tempcontainer
}

pausescroller.prototype.getinline=function(div1, div2){
div1.style.top=this.visibledivtop+"px"
div2.style.top=Math.max(div1.parentNode.offsetHeight, div1.offsetHeight)+"px"
}

// -------------------------------------------------------------------
// setmessage()- Populate the hidden div with the next message before it's visible
// -------------------------------------------------------------------

pausescroller.prototype.setmessage=function(){
var scrollerinstance=this
if (this.mouseoverBol==1) //if mouse is currently over scoller, do nothing (pause it)
setTimeout(function(){scrollerinstance.setmessage()}, 100)
else{
var i=this.hiddendivpointer
var ceiling=this.content.length
this.hiddendivpointer=(i+1>ceiling-1)? 0 : i+1
this.hiddendiv.innerHTML=this.content[this.hiddendivpointer]
this.animateup()
}
}

pausescroller.getCSSpadding=function(tickerobj){ //get CSS padding value, if any
if (tickerobj.currentStyle)
return tickerobj.currentStyle["paddingTop"]
else if (window.getComputedStyle) //if DOM2
return window.getComputedStyle(tickerobj, "").getPropertyValue("padding-top")
else
return 0
}

		</script>
	</HEAD>
	<body topMargin="0">
		<table borderColor="#cccccc" cellSpacing="0" cellPadding="0" width="779" align="center"
			border="1">
			<tr vAlign="top">
				<td>
					<table cellSpacing="0" cellPadding="0" width="769" border="0">
						<tr vAlign="top">
							<td width="769">
								<table cellSpacing="0" cellPadding="0" width="769" border="0">
									<tr vAlign="top">
										<td align="center" width="515" background="images\Holidays.gif" height="242">
											<table height="190" cellSpacing="0" cellPadding="0" width="400" border="0">
												<tr vAlign="top">
													<td height="175"></td>
												</tr>
												<tr vAlign="top">
													<td class="HeadText">
														<object classid="clsid:D27CDB6E-AE6D-11cf-96B8-444553540000" codebase="http://download.macromedia.com/pub/shockwave/cabs/flash/swflash.cab#version=6,0,29,0" width="400" height="40">
                                                              <param name="movie" value="flash/hlt.swf">
                                                              <param name="quality" value="high">
                                                              <embed src="flash/hlt.swf" quality="high" pluginspage="http://www.macromedia.com/go/getflashplayer" type="application/x-shockwave-flash" width="400" height="40"></embed>
													    </object></td>
												</tr>
											</table>
										</td>
										<td align="center" width="258" background="images\Dollars.gif" height="242">
											<table cellSpacing="0" cellPadding="0" width="200" border="0">
												<tr>
													<td></td>
													<td height="35"></td>
												</tr>
												<tr vAlign="top">
													<td vAlign="middle" align="left" width="27" height="24"><IMG src="images\RightSign.gif" border="0">
													</td>
													<td class="RightHeadText" vAlign="middle" align="left" width="150" height="35">Apply 
														Online
													</td>
												</tr>
												<tr vAlign="top">
													<td vAlign="middle" align="left" width="27" height="24"><IMG src="images\RightSign.gif" border="0">
													</td>
													<td class="RightHeadText" vAlign="middle" align="left" width="150" height="35">No 
														Application Fee
													</td>
												</tr>
												<tr vAlign="top">
													<td vAlign="middle" align="left" width="27" height="24"><IMG src="images\RightSign.gif" border="0">
													</td>
													<td class="RightHeadText" vAlign="middle" align="left" width="150" height="35">Cash 
														Overnight
													</td>
												</tr>
											</table>
										</td>
									</tr>
								</table>
							</td>
						</tr>
					</table>
					<table cellSpacing="0" cellPadding="0" width="769" border="0">
						<tr vAlign="top">
							<td width="769">
								<table cellSpacing="0" cellPadding="0" width="769" border="0">
									<tr vAlign="top">
										<td width="536" background="images\PayTypes.gif" height="154">
											<table cellSpacing="0" cellPadding="0" width="100%" border="0">
												<tr vAlign="top">
													<td width="50%">
														<table cellSpacing="0" cellPadding="0" width="100%" border="0">
															<tr vAlign="top">
																<td align="center" height="44">&nbsp;</td>
															</tr>
															<tr vAlign="top">
																<td class="WhiteText" align="center">Payday Loans</td>
															</tr>
															<tr vAlign="top">
																<td align="center" height="15"></td>
															</tr>
															<tr vAlign="top">
																<td class="Text1" align="center"><b>From $50 to $1,500</b>
																	<br>
																	Up to 62 days</td>
															</tr>
															<tr vAlign="top">
																<td align="center" height="3"></td>
															</tr>
															<tr vAlign="top">
																<td align="right"><A href="http://www.cashsolution.com.au/index1.htm" target="_blank"><IMG height="25" src="images\ApplyOnline.gif" width="120" border="0"></A>&nbsp;&nbsp;&nbsp;</td>
															</tr>
														</table>
													</td>
													<td width="50%">
														<table cellSpacing="0" cellPadding="0" width="100%" border="0">
															<tr vAlign="top">
																<td align="center" height="44">&nbsp;</td>
															</tr>
															<tr vAlign="top">
																<td class="WhiteText" align="center">Personal Loans</td>
															</tr>
															<tr vAlign="top">
																<td align="center" height="15"></td>
															</tr>
															<tr vAlign="top">
																<td class="Text1" align="center"><b>From $1,000 to $5,000 </b>
																	<br>
																	3 Months to 1 Year</td>
															</tr>
															<tr vAlign="top">
																<td align="center" height="3"></td>
															</tr>
															<tr vAlign="top">
																<td align="right"><A href="http://www.cashsolution.com.au/Long/index.aspx"><IMG height="25" src="images\ApplyOnline.gif" width="120" border="0"></A>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;</td>
															</tr>
														</table>
													</td>
												</tr>
											</table>
										</td>
										<td width="237" background="images\DollarImage.gif" height="154"></td>
									</tr>
								</table>
								<table borderColor="red" cellSpacing="0" cellPadding="0" width="769" border="0">
									<tr vAlign="top">
										<td height="10"></td>
									</tr>
									<tr vAlign="top">
										<td class="Terms" align="left" width="769">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<font color="#ff0000">*</font> Terms and Conditions are available on 
											application form.
										</td>
									</tr>
									<tr vAlign="top">
										<td class="Terms" align="left" width="769">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
											<font color="#ff0000">*</font> Subject to Verification and Final Credit 
											Assessment.
										</td>
									</tr>
									<tr vAlign="top">
										<td height="30"></td>
									</tr>
								</table>
								
							</td>
						</tr>
					</table>
				</td>
			</tr>
			</table>
			<table border="0" cellpadding="0" cellspacing="0"><tr><td height=10></td></tr>
			</table>
	</body>
 <!--#include file="bottom.asp"-->
</HTML>
