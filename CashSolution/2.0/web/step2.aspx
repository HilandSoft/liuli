<%@ Page language="c#" Codebehind="step2.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.step2" %>
<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN" >
<HTML>
	<HEAD>
		<title>step2</title>
		<meta content="Microsoft Visual Studio .NET 7.1" name="GENERATOR">
		<meta content="C#" name="CODE_LANGUAGE">
		<meta content="JavaScript" name="vs_defaultClientScript">
		<meta content="http://schemas.microsoft.com/intellisense/ie5" name="vs_targetSchema">
		<LINK href="css/css.css" type="text/css" rel="stylesheet">
		<script language="javascript" src="jslib/commCheck.js" type="text/javascript"></script>
		<script language="javascript">
		function  CheckFeedback() {
		var ftxFname=document.getElementById("txFname");
		var ftxLname=document.getElementById("txLname");
		var ftxDated=document.getElementById("txDated");
		var ftxDatem=document.getElementById("txDatem");
		var ftxDatey=document.getElementById("txDatey");		
		var ftxEmail=document.getElementById("txEmail");		
				
		var ftxResident=document.getElementById("txResident");
		var ftxStreet=document.getElementById("txStreet");
		var ftxCity=document.getElementById("txCity");
		var ftxPost=document.getElementById("txPost");
		
		var ftxTel=document.getElementById("txTel");
		
		var ftxUser=document.getElementById("txUser");
		var ftxPass=document.getElementById("txPass");
		var ftxConfirm=document.getElementById("txConfirm");
		
		if(!chkNull(ftxFname.value)) {
		alert(" Field 'First Name' under 'Personal Information' is not valid!");
		ftxFname.focus();
		return false;
		}
		
		if(!chkNull(ftxLname.value)) {
		alert(" Field 'Last Name' under 'Personal Information' is not valid!");
		ftxLname.focus();
		return false;
		}
		
		if(!chkNull(ftxDated.value)) {
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDated.focus();
		return false;
		}
		
		if(!chkdigital(ftxDated.value)) {
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDated.focus();
		return false;
		}
		
		if(ftxDated.value.length>2){
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDated.focus();
		return false;
		}
		
		if(!chkNull(ftxDatem.value)) {
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDatem.focus();
		return false;
		}
		
		if(!chkdigital(ftxDatem.value)) {
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDatem.focus();
		return false;
		}
		
		if(ftxDatem.value.length>2){
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDatem.focus();
		return false;
		}
		
		if(!chkNull(ftxDatey.value)) {
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDatey.focus();
		return false;
		}
		
		if(!chkdigital(ftxDatey.value)) {
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDatey.focus();
		return false;
		}
		
		if(ftxDatey.value.length!=4){
		alert(" Field 'Date of Birth' under 'Personal Information' is not valid!");
		ftxDatey.focus();
		return false;
		}
		
		if(!chkNull(ftxEmail.value)) {
		alert(" Field 'Email' under 'Personal Information' is not valid!");
		ftxEmail.focus();
		return false;
		}
		
		if(!isEmail(ftxEmail.value)) {
		alert(" Field 'Email' under 'Personal Information' is not valid!");
		ftxEmail.focus();
		return false;
		}
		
		if(!chkNull(ftxResident.value)) {
		alert(" Field 'Home Address' under 'Personal Information' is not valid!");
		ftxResident.focus();
		return false;
		}
		
		if(!chkNull(ftxStreet.value)) {
		alert(" Field 'Street Address' under 'Personal Information' is not valid!");
		ftxStreet.focus();
		return false;
		}
		
		if(!chkNull(ftxCity.value)) {
		alert(" Field 'Suburb' under 'Personal Information' is not valid!");
		ftxCity.focus();
		return false;
		}
		
		if(!chkNull(ftxPost.value)) {
		alert(" Field 'Post Code' under 'Personal Information' is not valid!");
		ftxPost.focus();
		return false;
		}
		
		if(!chkdigital(ftxPost.value)) {
		alert(" Field 'Post Code' under 'Personal Information' is not valid!");
		ftxPost.focus();
		return false;
		}
		
		if(!chkNull(ftxTel.value)) {
		alert(" Field 'Home Phone Number' under 'Personal Information' is not valid!");
		ftxTel.focus();
		return false;
		}
		
		if(!chkNull(ftxUser.value)) {
		alert(" Please specify a valid Username!");
		ftxUser.focus();
		return false;
		}
		
		if(!chkNull(ftxPass.value)) {
		alert(" Please specify a valid Password!");
		ftxPass.focus();
		return false;
		}
		
		if(!chkNull(ftxConfirm.value)) {
		alert(" Please confirm your password!");
		ftxConfirm.focus();
		return false;
		}
		
		if(ftxPass.value!=ftxConfirm.value) {
		alert(" Please confirm your password!");
		ftxConfirm.focus();
		return false;
		}
		
		return true;
		}
		</script>
	</HEAD>
	<body LEFTMARGIN="8" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table cellSpacing="0" cellPadding="0" width="396" border="0" align="center">
				<tr>
					<td>&nbsp;
					</td>
				</tr>
				<tr>
					<td align="center">
						<table cellSpacing="0" cellPadding="0" width="100%" border="0">
							<tr>
								<td colSpan="4"><strong>Personal Information</strong>
									<br>
								</td>
							</tr>
							<tr>
								<td width="136">Title:</td>
								<td colspan="2"><FONT face="宋体" color="#990000">
										<asp:DropDownList id="dlTitle" runat="server">
											<asp:ListItem Value="Mr">Mr</asp:ListItem>
											<asp:ListItem Value="Mrs">Mrs</asp:ListItem>
											<asp:ListItem Value="Miss">Miss</asp:ListItem>
											<asp:ListItem Value="Ms">Ms</asp:ListItem>
											<asp:ListItem Value="Dr">Dr</asp:ListItem>
										</asp:DropDownList>*</FONT></td>
							</tr>
							<tr>
								<td width="136">First Name:</td>
								<td width="113"><input id="txFname" type="text" size="9" name="textfield26" runat="server"><FONT face="宋体" color="#990000">*</FONT></td>
								<td width="82">Middle Name:</td>
								<td width="67"><INPUT id="txMname" type="text" size="8" name="textfield26" runat="server"></td>
							</tr>
							<tr>
								<td>Last Name:</td>
								<td>
									<input id="txLname" type="text" size="9" name="textfield27" runat="server"><FONT face="宋体" color="#990000">*</FONT>
								</td>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td>Date of Birth:</td>
								<td colspan="3">
									<INPUT id="txDated" type="text" size="2" name="txDated" runat="server">/<INPUT id="txDatem" type="text" size="2" name="Text1" runat="server">/<INPUT id="txDatey" type="text" size="4" name="Text2" runat="server"><FONT face="宋体" color="#990000">*</FONT>&nbsp;&nbsp;(DD/MM/YYYY)</td>
							</tr>
							<tr>
								<td>E-Mail:
								</td>
								<td colspan="3"><input id="txEmail" type="text" size="20" name="textfield28" runat="server"><FONT face="宋体" color="#990000">*</FONT></td>
							</tr>
							<tr>
								<td>Driver Licence Number:</td>
								<td><INPUT id="txDriver" type="text" size="9" name="textfield28" runat="server"></td>
								<td>State Issued:</td>
								<td>
									<INPUT id="txIssue" type="text" size="8" name="textfield29" runat="server">
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td><FONT face="宋体">&nbsp;</FONT><br>
						<table cellSpacing="0" cellPadding="0" width="397" border="0">
							<tr>
								<td width="133">
									Home&nbsp;Address:</td>
								<td width="264"><input id="txResident" type="text" size="20" name="textfield262" runat="server"><FONT face="宋体" color="#990000">*</FONT></td>
							</tr>
							<tr>
								<td>Street :</td>
								<td><input id="txStreet" type="text" size="20" name="textfield2622" runat="server"><FONT face="宋体" color="#990000">*</FONT></td>
							</tr>
							<tr>
								<td>Suburb:</td>
								<td><input id="txCity" type="text" size="20" name="textfield292" runat="server"><FONT face="宋体" color="#990000">*</FONT>&nbsp;&nbsp;State:&nbsp;
									<SELECT id="selState" name="select2" runat="server">
									  <option value="NT">NT</option>
									  <option value="SA">SA</option>
									  <option value="TAS">TAS</option>
									  <option value="VIC">VIC</option>
									  <option value="WA">WA</option>
									</SELECT>
									Please note that the loans are currently not available for the residents in ACT, NSW and QLD.
									</td>
							</tr>
						</table>
						<table cellSpacing="0" cellPadding="0" width="397" border="0">
							<tr>
								<td colspan="2"></td>
							</tr>
							<tr>
								<td width="133">Postcode:</td>
								<td width="264"><input id="txPost" type="text" size="20" name="textfield2623" runat="server"><FONT face="宋体" color="#990000">*</FONT></td>
							</tr>
							<tr>
								<td colSpan="2"><p>
									</p>
								</td>
							</tr>
							<tr>
								<td colSpan="2"><table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td width="34%">Time at this address:</td>
											<td width="66%"><SELECT id="txYear" name="select2" runat="server">
													<OPTION value="0" selected>0</OPTION>
													<OPTION value="1">1</OPTION>
													<OPTION value="2">2</OPTION>
													<OPTION value="3">3</OPTION>
													<OPTION value="4">4</OPTION>
													<OPTION value="5">5</OPTION>
													<OPTION value="6">6</OPTION>
													<OPTION value="7">7</OPTION>
													<OPTION value="8">8</OPTION>
													<OPTION value="9">9</OPTION>
													<OPTION value="10">10</OPTION>
													<OPTION value="11">11</OPTION>
													<OPTION value="12">12 or above</OPTION>
												</SELECT>Years
												<SELECT id="txMonth" name="select2" runat="server">
													<OPTION value="0" selected>0</OPTION>
													<OPTION value="1">1</OPTION>
													<OPTION value="2">2</OPTION>
													<OPTION value="3">3</OPTION>
													<OPTION value="4">4</OPTION>
													<OPTION value="5">5</OPTION>
													<OPTION value="6">6</OPTION>
													<OPTION value="7">7</OPTION>
													<OPTION value="8">8</OPTION>
													<OPTION value="9">9</OPTION>
													<OPTION value="10">10</OPTION>
													<OPTION value="11">11</OPTION>
													<OPTION value="12">12</OPTION>
												</SELECT>Months</td>
										</tr>
									</table>
								</td>
							</tr>
							<tr>
								<td>Home Phone Number:</td>
								<td><input id="txTel" type="text" size="20" name="textfield282" runat="server"><FONT face="宋体" color="#990000">*</FONT></td>
							</tr>
							<tr>
								<td>Mobile:</td>
								<td><input id="txMobile" type="text" size="20" name="textfield282" runat="server"><FONT face="宋体" color="#990000">&nbsp;</FONT></td>
							</tr>
							<tr>
								<td>Fax:</td>
								<td><input id="txFax" type="text" size="20" name="textfield282" runat="server"><FONT face="宋体" color="#990000">&nbsp;</FONT></td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td>
						<table cellSpacing="0" cellPadding="0" width="397" border="0">
							<tr>
								<td colSpan="2"><br>
									<strong>Login Information </strong>
								</td>
							</tr>
							<tr>
								<td colSpan="2">&nbsp;</td>
							</tr>
							<tr>
								<td colspan="2">
									<table width="100%" border="0" cellspacing="0" cellpadding="0">
										<tr>
											<td width="34%">Username:</td>
											<td width="66%"><input id="txUser" type="text" style="WIDTH:150px;HEIGHT:20px" name="textfield210" runat="server"><FONT face="宋体" color="#990000">*</FONT></td>
										</tr>
										<tr>
											<td>Password:</td>
											<td><input id="txPass" type="password" style="WIDTH:150px;HEIGHT:20px" name="textfield211"
													runat="server"><FONT face="宋体" color="#990000">*</FONT></td>
										</tr>
										<tr>
											<td>Confirm Password:</td>
											<td><input id="txConfirm" type="password" style="WIDTH:150px;HEIGHT:20px" name="textfield211"
													runat="server"><FONT face="宋体" color="#990000">*</FONT></td>
										</tr>
									</table>
								</td>
							</tr>
						</table>
					</td>
				</tr>
				<tr>
					<td align="center"><input id="Submit1" type="submit" value="Next>>>" name="Submit" runat="server"></td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
