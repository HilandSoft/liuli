<%@ Page language="c#" Codebehind="EmployedList.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.EmployedList" %>
<%@ Register TagPrefix="cc1" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<HTML>
	<HEAD>
		<title>MemberList</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="csslib/yingnet.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="../jslib/datagrid.js" type="text/javascript"></script>
		<script language="javascript">
			function showModel(url)
			{
			var wnd = window.showModalDialog(url,null,'dialogWidth=700px;dialogHeight=500px;status:0;help:0;resizable:1;unadorned:1');
			//wnd.dialogHeight = 600px;
			//wnd.dialogWidth = 800px;
			//wnd.dialogLeft = 0px;
			//wnd.dialogTop = 0px;
			}
		
		    function deleteit(o) {
				  var result = getchecknum(o);
				  if (result > 0) {
					  return confirm('Really Delete them?')
				  } else {
					  alert('Please Select What you want to delete!');
					  return false;
				  }
		    }
		    function editit(o) {
				  var result = getchecknum(o);
				  if (result == 1) {
					  return true;
				  } else {
					  alert('请选中一条信息');
					  return false;
				  }
		    }
			function auditit(o) {
				  var result = getchecknum(o);
				  if (result >0) {
					  return true;
				  } else {
					  alert('请选中一条或多条信息');
					  return false;
				  }
		    }
		    function cancelit(o) {
				  var result = getchecknum(o);
				  if (result > 0) {
					  return confirm('确实要更改选中信息的状态？')
				  } else {
					  alert('请选中一条信息');
					  return false;
				  }
		    }
		    function ShowWindow(s)
		    {
		        //window.showModelessDialog(s,window,"dialogHeight: 500px; dialogWidth: 720px; dialogTop: 50px; dialogLeft:30px; edge: Sunken; center: Yes; help: No; resizable: No; status: No;");
		        var iWidth = 0 ;
                var iHeight = 0 ;
                iWidth=window.screen.availWidth-10;
                iHeight=window.screen.availHeight-50;
                var szFeatures = "" ;
                szFeatures =  "resizable=no,status=yes,edge=Sunken,scrollbars=yes,center=yes,help=no,menubar=no,width=720,height=500,top=10,left=30"
                window.open(s,"",szFeatures)
		    }
		    function checkallorno(o) {
	var a = o;

	while (true) {
		var a = a.parentElement;
		if (a == null) {
			break;
		}
		if ( a == "undefined") {
			a = null;
			break;
		}
		if (a.tagName == "TABLE") {
			break;	
		}
	}
	if (a != null) {
		for (i = 0;i < a.rows.length; i++) {
			for (j = 0;j < a.rows[i].cells[0].children.length; j++) {
				var var1 = a.rows[i].cells[0].children[j];
				if (var1.tagName == "INPUT" ) {
					if (var1.type == "checkbox") {
						var1.checked = o.checked;
					}
				}
			}
		}
	}
}
function getchecknum(frm) {
	var result = 0;
	var checkboxnum = 0;
	for (var i = 0; i < frm.length; i++) {
		if (frm.elements[i].type == "checkbox") {
			checkboxnum++;
			//第一个为全选,不计算
			if (checkboxnum > 1) {
			    if (frm.elements[i].checked) {
				    result++;
			    }
			}
		}
	}
	return result;
}
		</script>
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" bgColor="#fefefe" border="0">
				<tr>
					<td style="HEIGHT: 54px">
						<table width="99%" cellpadding="0" cellspacing="0" border="0">
							<tr>
								<td valign="top"><FONT face="宋体">HuiSid&nbsp;&nbsp;&nbsp; </FONT>&nbsp;
									<asp:TextBox id="txKey" runat="server"></asp:TextBox><FONT face="宋体">&nbsp; </FONT>
									<asp:Button id="Button1" runat="server" Text="Query"></asp:Button>&nbsp;<FONT face="宋体">&nbsp;&nbsp;&nbsp;SQL 
										Command:&nbsp;
										<asp:TextBox id="txsql" runat="server" Width="392px"></asp:TextBox>&nbsp;
										<asp:Button id="Button2" runat="server" Text="Execute"></asp:Button>
										<asp:Button id="Button3" runat="server" Text="PrintOut"></asp:Button></FONT></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="top"><cc1:datagridtable id="DataGridTable1" runat="server" IsAllowPaging="True" CssClass="tableGrid" AllowPaging="True"
							EnableViewState="False" MaxRecord="0" IsShowFoot="True" PageCSS="scrollButton" Width="100%" BackColor="White"
							BorderColor="#3366CC" PageSize="12" CellPadding="4" BorderWidth="1px" BorderStyle="None">
							<PagerStyle Visible="False" HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" CssClass="gridPager"
								Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
							<EditItemStyle CssClass="gridEditItem"></EditItemStyle>
							<FooterStyle ForeColor="#003399" CssClass="gridFooter" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" CssClass="gridSelectedItem" BackColor="#009999"></SelectedItemStyle>
							<ItemStyle ForeColor="#003399" CssClass="gridItem" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" CssClass="gridHeader" BackColor="#99CCCC"></HeaderStyle>
						</cc1:datagridtable><asp:textbox id="txtParamstr" runat="server" Visible="False"></asp:textbox></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
