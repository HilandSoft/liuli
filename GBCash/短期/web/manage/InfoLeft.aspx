<%@ Page language="c#" Codebehind="InfoLeft.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.InfoLeft" %>
<HTML>
	<HEAD>
		<meta name="vs_targetSchema" content="http://schemas.microsoft.com/intellisense/ie5">
		<style type="text/css"> TD { BORDER-RIGHT: #93BBF1 1px solid; BORDER-TOP: #93BBF1 1px solid; BORDER-LEFT: #93BBF1 1px solid; BORDER-BOTTOM: #93BBF1 1px solid }
	.td1 { BORDER-RIGHT: #93BBF1 0px solid; BORDER-TOP: #93BBF1 0px solid; BORDER-LEFT: #93BBF1 0px solid; BORDER-BOTTOM: #93BBF1 0px solid }
	LI { CURSOR: default }
	.normal_item { BORDER-RIGHT: #C5DDFF 1px solid; BORDER-TOP: #C5DDFF 1px solid; BORDER-LEFT: #C5DDFF 1px solid; COLOR: #000000; BORDER-BOTTOM: #C5DDFF 1px solid }
	.focus_item { BORDER-RIGHT: #336699 1px solid; BORDER-TOP: #336699 1px solid; BORDER-LEFT: #336699 1px solid; COLOR: #ffffff; BORDER-BOTTOM: #336699 1px solid; BACKGROUND-COLOR: #93BBF1 }
	.hover_item { BORDER-RIGHT: #93bbf1 1px solid; BORDER-TOP: #93bbf1 1px solid; BORDER-LEFT: #93bbf1 1px solid; COLOR: #4b8ee9; BORDER-BOTTOM: #93bbf1 1px solid; BACKGROUND-COLOR: #bbd8ff }
		</style>
		<script language="JavaScript">
<!--
var loading_wait = 0;
var data_src = null;   //数据源
var focus_row = null;
var focus_path = "";
var current_department = null;
var init_id = null;
var deptid=0;
var trueiid = 0;

/**
 * 转换字符串中的特殊字符, 供 TDC 的 Filter 使用
 */
function encode( str ){
    str = str.toString().replace( "\\", "\\\\" );
    str = str.replace( "*", "\\*" );
    return str.replace( "\"", "\\\"" );
}

/**
 * 准备数据, 等待数据调入完成
 */
function prepareData()
{
    var obj = document.createElement( "OBJECT" );
    document.body.appendChild( obj );

    obj.classid             = "CLSID:333C7BC4-460F-11D0-BC04-0080C7055A83";
    obj.ondatasetcomplete   = onDataSourceReady;
    obj.DataURL             = "InfoGetLeftData.aspx";
    obj.UseHeader           = true;
    obj.CaseSensitive       = false;
    obj.CharSet             = "utf-8";
    obj.EscapeChar          = "\\";

    obj.setAttribute( "is_ready", "false" );   //当is_ready为true时开始初始化  
    data_src = obj;
	destroy();
    init();
}

function Reset()
{
	if (data_src!=null)
	{
		var url = "InfoGetLeftData.aspx";

		data_src.DataURL = url;
		data_src.Reset();
		destroy();
		init1();
	}
}

function init1()
{
    if ( data_src.getAttribute( "is_ready" ) != "true" )
    {
        ++loading_wait;
        if ( loading_wait > 20 ) wait_tip.style.display = "inline";

        window.setTimeout( init1, 20 );
        return;
    }

    wait_tip.style.display = "none";
    load( -1 );  //初始化
    if ( init_id != null || init_id != "" ) locate( init_id );

    tree.onmouseover        = onMouseOverItem;
    tree.onmouseout         = onMouseOutItem;
    tree.onmousedown        = onMouseDownItem;
    tree.ondblclick			= onMouseDbClickItem;
}

function onDataSourceReady(){
    if ( event.reason == 0 ){
        event.srcElement.setAttribute( "is_ready", "true" );
    }
}

/**
 * 初始化树型显示
 */
function init()
{
    if ( data_src.getAttribute( "is_ready" ) != "true" )
    {
        ++loading_wait;
        if ( loading_wait > 20 ) wait_tip.style.display = "inline";   //显示

        window.setTimeout( init, 20 );
        return;
    }

    wait_tip.style.display = "none";   //不显示
    load( -1 );
 
	init_id ="001";
    if ( init_id != null || init_id != "" ) locate( init_id );

    tree.onmouseover        = onMouseOverItem;
    tree.onmouseout         = onMouseOutItem;
    tree.onmousedown        = onMouseDownItem;
    tree.ondblclick			= onMouseDbClickItem;
}

/**
 * 删除所有节点
 */
function destroy()
{
	data_src.setAttribute( "is_ready", "false" );

	tree.onmouseover = null;
	tree.onmouseout = null;
	tree.onmousedown = null;
	document.body.onkeydown = null;

	loading_wait = 0;
	parent_window = null;
	input_box = null;
	focus_row = 0;
	focus_path = "";
	current_department = null;

	while ( tree.rows.length > 0 ) tree.deleteRow( 0 );
}

/**
 * 调入某节点的所有子节点
 */
function load( row )
{
    var parent; // 父节点 ID
    var level;  // 子节点所在层级
    var path;   // 父节点全路径

    if ( row == -1 )
    { // 如果是初始化...
        parent = 0;
        level = 0;
        path = "";
    }
    else
    {
        var e = tree.rows( row );   //第row+1行
        
        // 更新父节点状态
        e.setAttribute( "state", "expanded" );
        e.firstChild.firstChild.src = "images/minus.gif";

        // 根据父节点属性初始化变量
        parent = e.id;
        level = e.getAttribute( "level" ) + 1;
        path = e.getAttribute( "path" );
    }

    // 寻找子节点
    var rs = data_src.recordset;         
    

    // 如果没有找到, 则返回
    if ( rs.recordCount == 0 ) return;

    rs.moveFirst();
    while ( !rs.EOF )
    {
        if ( rs( "parent" ).value == parent )
        {
            if ( row != -1 ) ++row; // 如果 row 不等于 -1, 则 insert; 否则 append

            // 创建 HTML 标签
            var tr = tree.insertRow( row );
            var td = tr.insertCell();
            var img = document.createElement( "IMG" );
            var nobr = document.createElement( "NOBR" );

			td.appendChild( img );
            td.appendChild( nobr );

            tr.id = rs( "id" ).value;
            tr.setAttribute( "level", level );
            tr.setAttribute( "utl_link", rs( "url" ).value );
            tr.setAttribute( "iid", rs( "iid" ).value );
            
            td.className = "normal_item";
            td.style.paddingLeft = ( level * 20 ) + "px";
            img.width = 15;
            img.height = 9;
            nobr.style.cursor = "default";

            if ( rs( "leaf" ).value == "1" )
            { // 如果是叶节点...
                nobr.innerText = rs( "label" ).value;
                img.src = "images/dot.gif";
	            img.style.cursor = "default";
                tr.setAttribute( "path", path + rs( "label" ).value );
                tr.setAttribute( "state", "leaf" );
            }
            else
            {  // 如果该节点有子节点...
                nobr.innerText = rs( "label" ).value;
                img.src = "images/plus.gif";
	            img.style.cursor = "hand";
                tr.setAttribute( "path", path + rs( "label" ).value + "/" );
                tr.setAttribute( "state", "unloaded" );
            }
        }

        rs.moveNext();
    }
}

/**
 * 合并某个节点的所有子节点
 */
function collapse( row )
{
    // 获得节点信息
    var e = tree.rows( row );
    var level = e.getAttribute( "level" );
    var state = e.getAttribute( "state" );

    // 节点必须处于展开状态
    if ( state != "expanded" ) return;

    // 更新其状态
    e.setAttribute( "state", "collapsed" );
    e.firstChild.firstChild.src = "images/plus.gif";

    // 向下搜索其所有直接和间接子节点
    while ( ++row < tree.rows.length )
    {
        var tr = tree.rows( row )
        if ( tr.getAttribute( "level" ) > level )
        {	// 子节点的特点是具有比父节点更大的层级数
            // 隐藏之
            tr.style.display = "none";

            // 如果该子节点处于展开状态, 则更改为合并状态
            if ( tr.getAttribute( "state" ) == "expanded" )
			{
                tr.setAttribute( "state", "collapsed" );
                tr.firstChild.firstChild.src = "images/plus.gif";
            }
		}
		else // 下面再没有子节点了, 停止搜索
        break;
    }
}

/**
 * 展开某个节点, 显示出其所有子节点
 */
function expand( row ){
    // 获得该节点信息
    var e = tree.rows( row );
    var level = e.getAttribute( "level" );
    var state = e.getAttribute( "state" );

    // 如果其子节点没有调入, 调入之即可
    if ( state == "unloaded" ){
        load( row );
        return;
    }

    // 更新节点状态
    e.setAttribute( "state", "expanded" );
    e.firstChild.firstChild.src = "images/minus.gif";

    // 向下搜索子节点
    while ( ++row < tree.rows.length ){
        var tr = tree.rows( row )
        var l = tr.getAttribute( "level" );

        if ( l == level + 1 ) // 只显示出层级数大 1 的子节点
            tr.style.display = "";
        else if ( l <= level ) // 下面再没有子节点了, 停止搜索
            break;
    }
}

/**
 * 如果节点未展开, 则展开之; 否则合并之
 */
function switchExpandState( row ){
    switch ( tree.rows( row ).getAttribute( "state" )){
    case "unloaded":
    case "collapsed":
        expand( row );
        break;

    case "expanded":
        collapse( row );
        break;
    }
}

/**
 * 将焦点定位到某个节点
 */
function focusRow( row ){
    // 清除旧的焦点
    var tr = tree.rows( focus_row );
    tr.firstChild.className = "normal_item";

    focus_row = row;

    // 设置新的焦点
    tr = tree.rows( focus_row );
    tr.firstChild.className = "focus_item";
    focus_path = tr.getAttribute( "path" );

	if ( current_department != tr.getAttribute( "id" ))	{
		current_department = tr.getAttribute( "id" );
	}
}

/**
 * 根据名称寻找某个节点, 返回节点 ID
 */
function find( label ){
    var rs = data_src.recordset;
    rs.moveFirst();
    while ( !rs.EOF && rs( "label" ).value != label ) rs.moveNext();

    if ( rs.EOF )
        return null;
    else
        return rs( "id" ).value;
}

/**
 * 将焦点定位到指定 ID 的节点上
 */
function locate( id ){
    // 根据节点 ID 查找节点
    var rs = data_src.recordset;
    rs.moveFirst();
    while ( !rs.EOF && rs( "id" ).value != id ) rs.moveNext();

    // 如果找到了...
    if ( !rs.EOF ){
        var r;

        if ( rs( "parent" ).value != 0 ){ // 如果不是根节点...
            // 首先定位父节点
            r = locate( rs( "parent" ).value );

            if ( r == -1 ){ // 如果没有找到...
                return -1;
            }else{ // 如果找到了...
                expand( r );
                ++r; // 从父节点所在行的下一行开始寻找
            }
        }
        else
            r = 0; // 从第一行开始寻找

        // 定位本节点
        while( r < tree.rows.length ){
            if ( tree.rows( r ).id == id ){
                focusRow( r );
                
              if (tree.rows( r ).getAttribute( "utl_link") !="" || tree.rows( r ).getAttribute( "utl_link")!="null")
                {
					setMainPageSrc( tree.rows( r ).id, tree.rows( r ).getAttribute( "utl_link"),tree.rows( r ).getAttribute( "iid"));
				}
                return r;
            }

            ++r;
        }
    }

    return -1;
}

/**
 * 响应鼠标进入某节点消息
 */
function onMouseOverItem(){
    var src = window.event.srcElement;
    while ( src.tagName != "TABLE" && src.tagName != "TR" ) src = src.parentElement;
    if ( src.tagName == "TR" ){
        if ( src.rowIndex != focus_row ){
            src.firstChild.className = "hover_item";
        }
    }
}

/**
 * 响应鼠标离开某节点消息
 */
function onMouseOutItem(){
    var src = window.event.srcElement;

    while ( src.tagName != "TABLE" && src.tagName != "TR" ) src = src.parentElement;
    if ( src.tagName == "TR" ){
        if ( src.rowIndex != focus_row ){
            src.firstChild.className = "normal_item";
        }
    }
}


/**
 * 响应鼠标点击某节点消息
 */
function onMouseDownItem()
{
    var src = window.event.srcElement;
    var obj = src;

    while ( obj.tagName != "TABLE" && obj.tagName != "TR" ) obj = obj.parentElement;
    if ( obj.tagName == "TR" )
    {
		
		if ( src.tagName == "IMG" )
		{
			switchExpandState( obj.rowIndex );
		}
		else
		{
			focusRow( obj.rowIndex );
			
      if (src.getAttribute( "utl_link") !="" || src.getAttribute( "utl_link")!="0")
      {
        setMainPageSrc( obj.id , obj.getAttribute( "utl_link"),obj.getAttribute( "iid") );
      }
	}
	}
}

/**
 * 响应鼠标双击某节点消息
 */
function onMouseDbClickItem()
{
    var src = window.event.srcElement;

    while ( src.tagName != "TABLE" && src.tagName != "TR" ) src = src.parentElement;
    if ( src.tagName == "TR" )
    {
        switchExpandState( src.rowIndex );
        
         if (src.getAttribute( "utl_link") !="" || src.getAttribute( "utl_link")!="0")
        {
			    setMainPageSrc(src.id, src.getAttribute( "utl_link"),src.getAttribute( "iid"));
		}


    }
}
function setMainPageSrc(id,src,iid)
{
	deptid = id;
	trueiid = iid;
    window.parent.window.document.all.main.src = src;
}



//-->
		</script>
	</HEAD>
	<body onLoad="prepareData()" style="BORDER-RIGHT:0px;BORDER-TOP:0px;MARGIN:0px;BORDER-LEFT:0px;BORDER-BOTTOM:0px">
		<table border="0" cellpadding="0" cellspacing="0" width="100%" height="100%" bgcolor="#c5ddff"
			style="BORDER-RIGHT: #336699 1px solid; BORDER-TOP: #336699 1px solid; BORDER-LEFT: #336699 1px solid; BORDER-BOTTOM: #336699 1px solid"
			ID="Table1">
			<tr>
				<td bgcolor="#93bbf1" height="25" style="FONT-SIZE: 12px; BORDER-BOTTOM: #336699 1px solid">&nbsp;类别列表：</td>
			</tr>
			<tr>
				<td class="td1"><div id="excel" style="OVERFLOW-Y: auto;SCROLLBAR-FACE-COLOR: #dee3e7;OVERFLOW-X: auto;SCROLLBAR-HIGHLIGHT-COLOR: #ffffff;WIDTH: 100%;SCROLLBAR-SHADOW-COLOR: #dee3e7;SCROLLBAR-3DLIGHT-COLOR: #d1d7dc;SCROLLBAR-ARROW-COLOR: #006699;SCROLLBAR-TRACK-COLOR: #efefef;SCROLLBAR-DARKSHADOW-COLOR: #98aab1;HEIGHT: 100%"><span id="wait_tip" style="PADDING-RIGHT:20px; BORDER-TOP:#336699 1px solid; DISPLAY:none; PADDING-LEFT:20px; FONT-SIZE:12px; PADDING-BOTTOM:20px; COLOR:#999999; PADDING-TOP:20px">正在调入数据, 
							请等待...</span>
						<table id="tree" cellpadding="3" width="100%" style="FONT-SIZE: 12px; BORDER-BOTTOM: #d0d0d0 0px solid">
						</table>
					</div>
				</td>
			</tr>
		</table>
	</body>
</HTML>
