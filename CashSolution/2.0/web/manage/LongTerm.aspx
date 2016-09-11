<%@ Register TagPrefix="cc1" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<%@ Page language="c#" Codebehind="LongTerm.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.LongTerm" %>
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
					  alert('��ѡ��һ����Ϣ');
					  return false;
				  }
		    }
			function auditit(o) {
				  var result = getchecknum(o);
				  if (result >0) {
					  return true;
				  } else {
					  alert('��ѡ��һ���������Ϣ');
					  return false;
				  }
		    }
		    function cancelit(o) {
				  var result = getchecknum(o);
				  if (result > 0) {
					  return confirm('ȷʵҪ����ѡ����Ϣ��״̬��')
				  } else {
					  alert('��ѡ��һ����Ϣ');
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
			//��һ��Ϊȫѡ,������
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
	<body LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table ellSpacing="0" cellPadding="0" width="100%" bgColor="#fefefe" border="0">
				<tr>
					<td>&nbsp;</td>
				</tr>
				<tr>
					<td vAlign="top"><cc1:datagridtable id="DataGridTable1" runat="server" IsAllowPaging="True" AutoGenerateColumns="False"
							CssClass="tableGrid" AllowPaging="True" EnableViewState="False" MaxRecord="0" IsShowFoot="True" PageCSS="scrollButton"
							Width="100%" BackColor="White" BorderColor="#3366CC" PageSize="12" CellPadding="4" BorderWidth="1px" BorderStyle="None">
							<PagerStyle Visible="False" HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" CssClass="gridPager"
								Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
							<EditItemStyle CssClass="gridEditItem"></EditItemStyle>
							<FooterStyle ForeColor="#003399" CssClass="gridFooter" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" CssClass="gridSelectedItem" BackColor="#009999"></SelectedItemStyle>
							<ItemStyle ForeColor="#003399" CssClass="gridItem" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" CssClass="gridHeader" BackColor="#99CCCC"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="sid"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Select">
									<HeaderStyle Width="1%"></HeaderStyle>
									<HeaderTemplate>
										<INPUT id="chkselectall" onclick="checkallorno(this)" type="checkbox"></asp:CheckBox>
									
</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox id="chkID" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:BoundColumn DataField="borrow" HeaderText="how much"></asp:BoundColumn>
								<asp:BoundColumn DataField="terms" HeaderText="Term"></asp:BoundColumn>
								<asp:BoundColumn DataField="refnumber" HeaderText="Number"></asp:BoundColumn>
								<asp:BoundColumn DataField="fname" HeaderText="FirstName"></asp:BoundColumn>
								<asp:BoundColumn DataField="mname" HeaderText="MiddleName"></asp:BoundColumn>
								<asp:BoundColumn DataField="sname" HeaderText="LastName"></asp:BoundColumn>
								<asp:BoundColumn DataField="birth" HeaderText="DateBirth" DataFormatString="{0:yyyy-MM-dd}"></asp:BoundColumn>
								<asp:BoundColumn DataField="email" HeaderText="Email"></asp:BoundColumn>
								<asp:BoundColumn DataField="lnumber" HeaderText="DriverNumber"></asp:BoundColumn>
								<asp:BoundColumn DataField="regdate" HeaderText="Regtime"></asp:BoundColumn>
								<asp:BoundColumn DataField="param1" HeaderText="Status"></asp:BoundColumn>
								<asp:HyperLinkColumn Text="Detail" DataNavigateUrlField="sid" DataNavigateUrlFormatString="LongDetail.aspx?sid={0}"></asp:HyperLinkColumn>
								<asp:HyperLinkColumn Text="Delete" DataNavigateUrlField="sid" DataNavigateUrlFormatString="LongDel.aspx?sid={0}"></asp:HyperLinkColumn>
							</Columns>
						</cc1:datagridtable>
						<asp:checkbox id="CheckBox1" runat="server" Visible="False"></asp:checkbox><asp:textbox id="txtParamstr" runat="server" Visible="False"></asp:textbox></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
