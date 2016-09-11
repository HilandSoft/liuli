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
var data_src = null;   //����Դ
var focus_row = null;
var focus_path = "";
var current_department = null;
var init_id = null;
var deptid=0;
var trueiid = 0;

/**
 * ת���ַ����е������ַ�, �� TDC �� Filter ʹ��
 */
function encode( str ){
    str = str.toString().replace( "\\", "\\\\" );
    str = str.replace( "*", "\\*" );
    return str.replace( "\"", "\\\"" );
}

/**
 * ׼������, �ȴ����ݵ������
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

    obj.setAttribute( "is_ready", "false" );   //��is_readyΪtrueʱ��ʼ��ʼ��  
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
    load( -1 );  //��ʼ��
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
 * ��ʼ��������ʾ
 */
function init()
{
    if ( data_src.getAttribute( "is_ready" ) != "true" )
    {
        ++loading_wait;
        if ( loading_wait > 20 ) wait_tip.style.display = "inline";   //��ʾ

        window.setTimeout( init, 20 );
        return;
    }

    wait_tip.style.display = "none";   //����ʾ
    load( -1 );
 
	init_id ="001";
    if ( init_id != null || init_id != "" ) locate( init_id );

    tree.onmouseover        = onMouseOverItem;
    tree.onmouseout         = onMouseOutItem;
    tree.onmousedown        = onMouseDownItem;
    tree.ondblclick			= onMouseDbClickItem;
}

/**
 * ɾ�����нڵ�
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
 * ����ĳ�ڵ�������ӽڵ�
 */
function load( row )
{
    var parent; // ���ڵ� ID
    var level;  // �ӽڵ����ڲ㼶
    var path;   // ���ڵ�ȫ·��

    if ( row == -1 )
    { // ����ǳ�ʼ��...
        parent = 0;
        level = 0;
        path = "";
    }
    else
    {
        var e = tree.rows( row );   //��row+1��
        
        // ���¸��ڵ�״̬
        e.setAttribute( "state", "expanded" );
        e.firstChild.firstChild.src = "images/minus.gif";

        // ���ݸ��ڵ����Գ�ʼ������
        parent = e.id;
        level = e.getAttribute( "level" ) + 1;
        path = e.getAttribute( "path" );
    }

    // Ѱ���ӽڵ�
    var rs = data_src.recordset;         
    

    // ���û���ҵ�, �򷵻�
    if ( rs.recordCount == 0 ) return;

    rs.moveFirst();
    while ( !rs.EOF )
    {
        if ( rs( "parent" ).value == parent )
        {
            if ( row != -1 ) ++row; // ��� row ������ -1, �� insert; ���� append

            // ���� HTML ��ǩ
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
            { // �����Ҷ�ڵ�...
                nobr.innerText = rs( "label" ).value;
                img.src = "images/dot.gif";
	            img.style.cursor = "default";
                tr.setAttribute( "path", path + rs( "label" ).value );
                tr.setAttribute( "state", "leaf" );
            }
            else
            {  // ����ýڵ����ӽڵ�...
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
 * �ϲ�ĳ���ڵ�������ӽڵ�
 */
function collapse( row )
{
    // ��ýڵ���Ϣ
    var e = tree.rows( row );
    var level = e.getAttribute( "level" );
    var state = e.getAttribute( "state" );

    // �ڵ���봦��չ��״̬
    if ( state != "expanded" ) return;

    // ������״̬
    e.setAttribute( "state", "collapsed" );
    e.firstChild.firstChild.src = "images/plus.gif";

    // ��������������ֱ�Ӻͼ���ӽڵ�
    while ( ++row < tree.rows.length )
    {
        var tr = tree.rows( row )
        if ( tr.getAttribute( "level" ) > level )
        {	// �ӽڵ���ص��Ǿ��бȸ��ڵ����Ĳ㼶��
            // ����֮
            tr.style.display = "none";

            // ������ӽڵ㴦��չ��״̬, �����Ϊ�ϲ�״̬
            if ( tr.getAttribute( "state" ) == "expanded" )
			{
                tr.setAttribute( "state", "collapsed" );
                tr.firstChild.firstChild.src = "images/plus.gif";
            }
		}
		else // ������û���ӽڵ���, ֹͣ����
        break;
    }
}

/**
 * չ��ĳ���ڵ�, ��ʾ���������ӽڵ�
 */
function expand( row ){
    // ��øýڵ���Ϣ
    var e = tree.rows( row );
    var level = e.getAttribute( "level" );
    var state = e.getAttribute( "state" );

    // ������ӽڵ�û�е���, ����֮����
    if ( state == "unloaded" ){
        load( row );
        return;
    }

    // ���½ڵ�״̬
    e.setAttribute( "state", "expanded" );
    e.firstChild.firstChild.src = "images/minus.gif";

    // ���������ӽڵ�
    while ( ++row < tree.rows.length ){
        var tr = tree.rows( row )
        var l = tr.getAttribute( "level" );

        if ( l == level + 1 ) // ֻ��ʾ���㼶���� 1 ���ӽڵ�
            tr.style.display = "";
        else if ( l <= level ) // ������û���ӽڵ���, ֹͣ����
            break;
    }
}

/**
 * ����ڵ�δչ��, ��չ��֮; ����ϲ�֮
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
 * �����㶨λ��ĳ���ڵ�
 */
function focusRow( row ){
    // ����ɵĽ���
    var tr = tree.rows( focus_row );
    tr.firstChild.className = "normal_item";

    focus_row = row;

    // �����µĽ���
    tr = tree.rows( focus_row );
    tr.firstChild.className = "focus_item";
    focus_path = tr.getAttribute( "path" );

	if ( current_department != tr.getAttribute( "id" ))	{
		current_department = tr.getAttribute( "id" );
	}
}

/**
 * ��������Ѱ��ĳ���ڵ�, ���ؽڵ� ID
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
 * �����㶨λ��ָ�� ID �Ľڵ���
 */
function locate( id ){
    // ���ݽڵ� ID ���ҽڵ�
    var rs = data_src.recordset;
    rs.moveFirst();
    while ( !rs.EOF && rs( "id" ).value != id ) rs.moveNext();

    // ����ҵ���...
    if ( !rs.EOF ){
        var r;

        if ( rs( "parent" ).value != 0 ){ // ������Ǹ��ڵ�...
            // ���ȶ�λ���ڵ�
            r = locate( rs( "parent" ).value );

            if ( r == -1 ){ // ���û���ҵ�...
                return -1;
            }else{ // ����ҵ���...
                expand( r );
                ++r; // �Ӹ��ڵ������е���һ�п�ʼѰ��
            }
        }
        else
            r = 0; // �ӵ�һ�п�ʼѰ��

        // ��λ���ڵ�
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
 * ��Ӧ������ĳ�ڵ���Ϣ
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
 * ��Ӧ����뿪ĳ�ڵ���Ϣ
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
 * ��Ӧ�����ĳ�ڵ���Ϣ
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
 * ��Ӧ���˫��ĳ�ڵ���Ϣ
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
				<td bgcolor="#93bbf1" height="25" style="FONT-SIZE: 12px; BORDER-BOTTOM: #336699 1px solid">&nbsp;����б�</td>
			</tr>
			<tr>
				<td class="td1"><div id="excel" style="OVERFLOW-Y: auto;SCROLLBAR-FACE-COLOR: #dee3e7;OVERFLOW-X: auto;SCROLLBAR-HIGHLIGHT-COLOR: #ffffff;WIDTH: 100%;SCROLLBAR-SHADOW-COLOR: #dee3e7;SCROLLBAR-3DLIGHT-COLOR: #d1d7dc;SCROLLBAR-ARROW-COLOR: #006699;SCROLLBAR-TRACK-COLOR: #efefef;SCROLLBAR-DARKSHADOW-COLOR: #98aab1;HEIGHT: 100%"><span id="wait_tip" style="PADDING-RIGHT:20px; BORDER-TOP:#336699 1px solid; DISPLAY:none; PADDING-LEFT:20px; FONT-SIZE:12px; PADDING-BOTTOM:20px; COLOR:#999999; PADDING-TOP:20px">���ڵ�������, 
							��ȴ�...</span>
						<table id="tree" cellpadding="3" width="100%" style="FONT-SIZE: 12px; BORDER-BOTTOM: #d0d0d0 0px solid">
						</table>
					</div>
				</td>
			</tr>
		</table>
	</body>
</HTML>
