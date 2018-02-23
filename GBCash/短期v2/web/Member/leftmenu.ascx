<%@ Control Language="c#" AutoEventWireup="false" Codebehind="leftmenu.ascx.cs" Inherits="YingNet.WeiXing.WebApp.Member.leftmenu" TargetSchema="http://schemas.microsoft.com/intellisense/ie5"%>
<style type="text/css">
<!--
#PARENT,#nav,li,a{margin:0;padding:0;border:0;}
body {
 font-family: arial, ����, serif;
 font-size:12px;
}
#nav {
 width:140px;
    line-height: 24px; 
 list-style-type: none;
 text-align:left;
    /*��������ul�˵����иߺͱ���ɫ*/
}

/*==================һ��Ŀ¼===================*/
#nav a {
 width: 120px; 
 display: block;
 padding-left:20px;
 /*Width(һ��Ҫ)�����������Li�����*/
}

#nav li {
 background:#CCC; /*һ��Ŀ¼�ı���ɫ*/
 border-bottom:#FFF 1px solid; /*�����һ���ױ�*/
 float:left;
 /*float��left,����Ӧ�����ã���������Firefox����������ʾ
 �̳�Nav��width,���ƿ�ȣ�li�Զ���������*/
}

#nav li a:hover{
 background:#CC0000; /*һ��Ŀ¼onMouseOver��ʾ�ı���ɫ*/
}

#nav a:link  {
 color:#666; text-decoration:none;
}
#nav a:visited  {
 color:#666;text-decoration:none;
}
#nav a:hover  {
 color:#FFF;text-decoration:none;font-weight:bold;
}

/*==================����Ŀ¼===================*/
#nav li ul {
 list-style:none;
 text-align:left;
}
#nav li ul li{ 
 background: #EBEBEB; /*����Ŀ¼�ı���ɫ*/
}

#nav li ul a{
         padding-left:5px;
         width:120px;
 /* padding-left����Ŀ¼�����������ƶ�����Width������������=(�ܿ��-padding-left)*/
}

/*�����Ƕ���Ŀ¼��������ʽ*/

#nav li ul a:link  {
 color:#666; text-decoration:none;
}
#nav li ul a:visited  {
 color:#666;text-decoration:none;
}
#nav li ul a:hover {
 color:#F3F3F3;
 text-decoration:none;
 font-weight:normal;
 background:#CC0000;
 /* ����onmouseover��������ɫ������ɫ*/
}

/*==============================*/
#nav li:hover ul {
 left: auto;
}
#nav li.sfhover ul {
 left: auto;
}
#content {
 clear: left; 
}
#nav ul.collapsed {
 display: none;
}
-->

#PARENT{
 padding-left:20px;
}
</style>
<IMG SRC="../images/index_10.gif" WIDTH="191" HEIGHT="22" ALT=""><br>

<div id="PARENT">
<ul id="nav">
<li><a href="#Menu=ChildMenu1"  onclick="DoMenu('ChildMenu1')">Account info</a>
 <ul id="ChildMenu1" class="collapsed">
 <li><a href="detail1.aspx">Customer Details</a></li>
 <li><a href="EmployDetail.aspx">Employment Details</a></li>
 <li><a href="myloan2.aspx">My Loans</a></li>
 <li><a href="changepwd.aspx">Change Password</a></li>
 </ul>
</li>
<li><a href="#Menu=ChildMenu2" onclick="DoMenu('ChildMenu2')">Apply now</a>
 <ul id="ChildMenu2" class="collapsed">
 <li><a href="newloan.aspx">New cash loan</a></li>
 <li><a href="loanextension.aspx">Loan extension</a></li>
 </ul>
</li>
<li><a href="#Menu=ChildMenu3" onclick="DoMenu('ChildMenu3')">Contact us</a>
 <ul id="ChildMenu3" class="collapsed">
 <li><a href="contaciinfo.aspx">Contact info</a></li>
 </ul>
</li>
<li><a href="#Menu=ChildMenu4" onclick="DoMenu('ChildMenu4')">Manage</a>
 <ul id="ChildMenu4" class="collapsed">
 <li><a href="logout.aspx">Logout</a></li>
 </ul>
</li>
</ul>
</div>

<script type=text/javascript><!--
var LastLeftID = "";

function menuFix() {
 var obj = document.getElementById("nav").getElementsByTagName("li");
 
 for (var i=0; i<obj.length; i++) {
  obj[i].onmouseover=function() {
   this.className+=(this.className.length>0? " ": "") + "sfhover";
  }
  obj[i].onMouseDown=function() {
   this.className+=(this.className.length>0? " ": "") + "sfhover";
  }
  obj[i].onMouseUp=function() {
   this.className+=(this.className.length>0? " ": "") + "sfhover";
  }
  obj[i].onmouseout=function() {
   this.className=this.className.replace(new RegExp("( ?|^)sfhover\\b"), "");
  }
 }
}

function DoMenu(emid)
{
 var obj = document.getElementById(emid); 
 obj.className = (obj.className.toLowerCase() == "expanded"?"collapsed":"expanded");
 if((LastLeftID!="")&&(emid!=LastLeftID)) //�ر���һ��Menu
 {
  document.getElementById(LastLeftID).className = "collapsed";
 }
 LastLeftID = emid;
}

function GetMenuID()
{

 var MenuID="";
 var _paramStr = new String(window.location.href);

 var _sharpPos = _paramStr.indexOf("#");
 
 if (_sharpPos >= 0 && _sharpPos < _paramStr.length - 1)
 {
  _paramStr = _paramStr.substring(_sharpPos + 1, _paramStr.length);
 }
 else
 {
  _paramStr = "";
 }
 
 if (_paramStr.length > 0)
 {
  var _paramArr = _paramStr.split("&");
  if (_paramArr.length>0)
  {
   var _paramKeyVal = _paramArr[0].split("=");
   if (_paramKeyVal.length>0)
   {
    MenuID = _paramKeyVal[1];
   }
  }
 }
 
 if(MenuID!="")
 {
  DoMenu(MenuID)
 }
}

GetMenuID(); //*������function��˳��Ҫע��һ�£���Ȼ��Firefox��GetMenuID()����Ч��
menuFix();
--></script>
