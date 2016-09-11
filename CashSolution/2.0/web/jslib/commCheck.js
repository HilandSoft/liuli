// STRING FUNCTIONS
function trim ( str ) {
    // Immediately return if no trimming is needed
    if( (str.charAt(0) != ' ') && (str.charAt(str.length-1) != ' ') ) { return str; }
    // Trim leading spaces
    while( str.charAt(0) == ' ' ) {
        str = '' + str.substring(1,str.length);
    }
    // Trim trailing spaces
    while( str.charAt(str.length-1) == ' ' ) {
        str = '' + str.substring(0,str.length-1);
    }

    return str;
} 

//检查输入是否为空
function chkNull (str) {
  if (trim(str) == '') {
    return false;
  } else {
    return true;
  }
}

//函数名：chkdatetime
//功能介绍：检查是否为时间格式
//参数说明：datetimestr 要检查的字符串
//参数说明：dateseparator 要检查的日期分割符
//参数说明：timeseparator 要检查的时间分割符
//返回值：false：不是时间  true：是时间
function chkdatetime (datetimestr,dateseparator,timeseparator) {
  if (datetimestr == "") {
    return false;
  }
    
  var tmpdate="";
  var tmptime="";
  
  var status;
  status=0;
  
  for (kk=0;kk<datetimestr.length;kk++) {
    if (datetimestr.charAt(kk)== ' ') {
      status++;
    }
    if (status>1) {
      //alert("Invalid format of date!");
      return false;
    }
    if ((status==0) && (datetimestr.charAt(kk)!=' ')) {
      tmpdate=tmpdate+datetimestr.charAt(kk)
    }
    if ((status==1) && (datetimestr.charAt(kk)!=' ')) {
      tmptime=tmptime+datetimestr.charAt(kk)
    }
  }
  if (chkdate(tmpdate,dateseparator)) {
  	//now check time
  	status = 0;
  	if (tmptime == "") {
  	  return false;
  	}
  	var tmphour = "";
  	var tmpminute = "";
    for (kk=0;kk<tmptime.length;kk++) {
      if (tmptime.charAt(kk)== timeseparator) {
        status++;
      }
      if (status>1) {
        //alert("Invalid format of date!");
        return false;
      }
      if ((status==0) && (tmptime.charAt(kk)!=timeseparator)) {
        tmphour=tmphour+tmptime.charAt(kk)
      }
      if ((status==1) && (tmptime.charAt(kk)!=timeseparator)) {
        tmpminute=tmpminute+tmptime.charAt(kk)
      }
    }
    if (!((tmphour>=0) && (tmphour<24))) {
      return false;
    }
    if (!((tmpminute>=0) && (tmpminute<60))) {
      return false;
    }
    return true;
  } 
  return false;
}
//身份证检测
function chkidcard(str)
{
	var reg=/^(\d{15}|\d{18})$/;
	if(!str.match(reg))
	{	
		return false;
	}
}

//函数名：chkdate
//功能介绍：检查是否为日期
//参数说明：datestr 要检查的字符串
//参数说明：separator 要检查的日期分割符
//返回值：false：不是日期  true：是日期
function chkdate(datestr,separator)
{
  var lthdatestr
  if (datestr != "")
    lthdatestr= datestr.length ;
  else
    lthdatestr=0;
    
  var tmpy="";
  var tmpm="";
  var tmpd="";
  //var datestr;
  var status;
  status=0;
  if ( lthdatestr== 0)
    return false;

  
  for (kk=0;kk<lthdatestr;kk++)
  {  if (datestr.charAt(kk)== separator)
    {
      status++;
    }
    if (status>2)
    {
      //alert("Invalid format of date!");
      return false;
    }
    if ((status==0) && (datestr.charAt(kk)!=separator))
    {
      tmpy=tmpy+datestr.charAt(kk)
    }
    if ((status==1) && (datestr.charAt(kk)!=separator))
    {
      tmpm=tmpm+datestr.charAt(kk)
    }
    if ((status==2) && (datestr.charAt(kk)!=separator))
    {
      tmpd=tmpd+datestr.charAt(kk)
    }

  }
  year=new String (tmpy);
  month=new String (tmpm);
  day=new String (tmpd)
  //tempdate= new String (year+month+day);
  //alert(tempdate);
  if ((tmpy.length!=4) || (tmpm.length>2) || (tmpd.length>2))
  {
    //alert("Invalid format of date!");
    return false;
  }
  if (!((1<=month) && (12>=month) && (31>=day) && (1<=day)) )
  {
    //alert ("Invalid month or day!");
    return false;
  }
  if (!((year % 4)==0) && (month==2) && (day==29))
  {
    //alert ("This is not a leap year!");
    return false;
  }
  if ((month<=7) && ((month % 2)==0) && (day>=31))
  {
    //alert ("This month is a small month!");
    return false;
  }
  if ((month>=8) && ((month % 2)==1) && (day>=31))
  {
    //alert ("This month is a small month!");
    return false;
  }
  if ((month==2) && (day==30))
  {
    //alert("The Febryary never has this day!");
    return false;
  }
  return true;
}



//函数名：chknum
//功能介绍：检查是否为数值
//参数说明：要检查的字符串
//返回值：false：不是数值  true：是数值
function chknum(num){
  numstring=".0123456789."
  for(iii=0;iii<num.length;iii++){
    if (numstring.indexOf(num.charAt(iii))==-1)
      return false;
  }
  return true;
}


//函数名：chkdigital
//功能介绍：检查是否为数字
//参数说明：要检查的字符串
//返回值：false：不是数字  true：是数字
function chkdigital(num){
  numstring="0123456789"
  for(iii=0;iii<num.length;iii++){
    if (numstring.indexOf(num.charAt(iii))==-1)
      return false;
  }
  return true;
}



//函数名：chktybh
//功能介绍：检查是否为"yyyy-nnnn"格式编号
//参数说明：要检查的字符串
//返回值：false：不合法  true：合法
function chktybh(bh){
  if (bh.length==8){
    if (bh.charAt(4)!="-"){
      return false;
      }
    if (!chknum(bh.substr(0,4))){
      return false;
      }
    if (!chknum(bh.substr(5,3))){
      return false;
      }
    return true;
  }
  else{
    return false;
  }
}

//函数名：isEamil
//功能介绍：检查是否为email格式
//参数说明：要检查的字符串
//返回值：false：不合法  true：合法
function isEmail(strEmail) {
  if (strEmail.search(/^\w+((-\w+)|(\.\w+))*\@[A-Za-z0-9]+((\.|-)[A-Za-z0-9]+)*\.[A-Za-z0-9]+$/) != -1)
    return true;
  else
    return false;
}


//函数名：chkpostcode
//功能介绍：检查邮编是否合法
//参数说明：要检查的字符串
//返回值：false：不合法  true：合法
function chkpostcode(code){
  if (code.length!=6)
    return false;
  else{
    if (chkdigital(code))
      return true;
    else
      return false;
  }
}

//函数名：chkgmscope
//功能介绍：工贸管辖范围是否合法
//参数说明：要检查的字符串
//返回值：false：不合法  true：合法
function chkgmscope(scope){
  scopeArray=scope.split(",");
  for (i=0;i<scopeArray.length;i++){
    if (scopeArray[i].length!=3){
      return false;
    }else{
      if (!chkdigital(scopeArray[i]))
        return false;
    }
  }
  return true;
}

//函数名：chktel
//功能介绍：检查字符串是否为合法电话号码格式
//参数说明：要检查的字符串
//返回值：false：不合法  true：合法
function chktel(telstr) {
  //不带区号的电话号码
  if((telstr.length == 7) || (telstr.length == 8)) {
    if (chkdigital(telstr)) {
      return true;
    }
  }
  //带区号的电话号码
  if ((telstr.length == 12) || (telstr.length == 13)) {
    telArray = telstr.split("-");
    if (telArray.length == 2){
      //检查区号
      if((telArray[0].length == 3) || (telArray[0].length == 4)) {
        if(chkdigital(telArray[0])) {
          //检查电话号码
          if((telArray[1].length == 7) || (telArray[1].length == 8)) {
            if (chkdigital(telArray[1])) {
              return true;
            }
          }
        }
      }
    }
  }
  return false;
}

//函数名：chkmobile
//功能介绍：检查字符串是否为合法手机号码格式
//参数说明：要检查的字符串
//返回值：false：不合法  true：合法
function chkmobile(str){
  if (str.length!=11){
    return false;
  }else{
    if (chkdigital(str))
      return true;
    else
      return false;
  }
}