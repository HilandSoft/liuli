<%@ Page language="c#" Codebehind="ProcessList.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.manage.ProcessCenter.ProcessList" %>
<%@ Register TagPrefix="cc1" Namespace="YingNet.Common" Assembly="YingNet.Common" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>ProcessCenter</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="../csslib/yingnet.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout">
		<form id="Form1" method="post" runat="server">
			<table height="100%" cellSpacing="0" cellPadding="0" width="100%" bgColor="#fefefe" border="0">
				<tr>
					<td style="HEIGHT: 54px" align="center">
						<table cellSpacing="0" cellPadding="0" width="99%" border="0">
							<tr>
								<td vAlign="top" align="center">
									<asp:dropdownlist id="ddlQuery" runat="server"></asp:dropdownlist><FONT face="宋体">&nbsp;&nbsp;
									</FONT>&nbsp;
									<asp:textbox id="txKey" runat="server"></asp:textbox><FONT face="宋体">&nbsp; </FONT>
									<asp:button id="btnQuery" runat="server" Text="Query"></asp:button><asp:label id="Label1" runat="server"></asp:label><asp:textbox id="txCondition" runat="server" Visible="False" Width="7px"></asp:textbox>&nbsp;
									<asp:button id="btnDelete" runat="server"></asp:button></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td vAlign="top"><cc1:datagridtable id="DataGridTable1" runat="server" Width="100%" BorderStyle="None" BorderWidth="1px"
							CellPadding="4" PageSize="12" BorderColor="#3366CC" BackColor="White" PageCSS="scrollButton" IsShowFoot="True"
							MaxRecord="0" EnableViewState="False" AllowPaging="True" CssClass="tableGrid" AutoGenerateColumns="False" IsAllowPaging="True">
							<PagerStyle Visible="False" HorizontalAlign="Left" ForeColor="#003399" BackColor="#99CCCC" CssClass="gridPager"
								Mode="NumericPages"></PagerStyle>
							<AlternatingItemStyle CssClass="gridAltItem"></AlternatingItemStyle>
							<EditItemStyle CssClass="gridEditItem"></EditItemStyle>
							<FooterStyle ForeColor="#003399" CssClass="gridFooter" BackColor="#99CCCC"></FooterStyle>
							<SelectedItemStyle Font-Bold="True" ForeColor="#CCFF99" CssClass="gridSelectedItem" BackColor="#009999"></SelectedItemStyle>
							<ItemStyle ForeColor="#003399" CssClass="gridItem" BackColor="White"></ItemStyle>
							<HeaderStyle Font-Bold="True" ForeColor="#CCCCFF" CssClass="gridHeader" BackColor="#99CCCC"></HeaderStyle>
							<Columns>
								<asp:BoundColumn Visible="False" DataField="ProcessID"></asp:BoundColumn>
								<asp:TemplateColumn HeaderText="Select">
									<HeaderStyle Width="1%"></HeaderStyle>
									<HeaderTemplate>
										<INPUT id="chkselectall" onclick="checkallorno(this)" type="checkbox"></asp:CheckBox>
									</HeaderTemplate>
									<ItemTemplate>
										<asp:CheckBox id="chkID" runat="server"></asp:CheckBox>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="CustomerNumber">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										CustomerNumber
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="LitCustomerNumber" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="LoanType">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										LoanType
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="LitIsFirstLoan" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="FirstName">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										FirstName
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="LitFirstName" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="MiddleName">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										MiddleName
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="LitMiddleName" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="LastName">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										LastName
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="LitLastName" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Password">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										Password
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="LitPassword" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="DateBirth">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										DateBirth
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="LitDateBirth" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="DriverNumber">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										DriverNumber
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="LitDriverNumber" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Regtime">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										Regtime
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="LitRegtime" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="DocumentStatus">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										DocumentStatus
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="litDocumentCheckList" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="DetailVerification">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										DetailVerification
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="litDetailVerification" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Status">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										Status
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="litStatus" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Score">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										Score
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="LitScore" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Note">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										Note
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="LitNote" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="FollowUpHistory">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										FollowUpHistory
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="LitFollowUpHistory" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
								<asp:TemplateColumn HeaderText="Operate">
									<HeaderStyle></HeaderStyle>
									<HeaderTemplate>
										Operate
									</HeaderTemplate>
									<ItemTemplate>
										<asp:Literal ID="litOperate" Runat="server"></asp:Literal>
									</ItemTemplate>
								</asp:TemplateColumn>
							</Columns>
						</cc1:datagridtable><asp:checkbox id="CheckBox1" runat="server" Visible="False"></asp:checkbox><asp:textbox id="txtParamstr" runat="server" Visible="False"></asp:textbox></td>
				</tr>
			</table>
		</form>
		<script language="javascript" src="../../jslib/datagrid.js" type="text/javascript"></script>
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
		<script src="../../jslib/jquery-1.2.6.min.js"></script>
		<script type="text/javascript">
			$(document).ready(function(){
				
			})
		</script>
	</body>
</HTML>
