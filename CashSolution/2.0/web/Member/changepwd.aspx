<%@ Register TagPrefix="uc1" TagName="leftmenu" Src="leftmenu.ascx" %>
<%@ Register TagPrefix="uc1" TagName="top1" Src="top1.ascx" %>
<%@ Page language="c#" Codebehind="changepwd.aspx.cs" AutoEventWireup="false" Inherits="YingNet.WeiXing.WebApp.Member.changepwd" %>
<%@ Register TagPrefix="uc1" TagName="top3" Src="top3.ascx" %>
<HTML>
	<HEAD>
		<title>changepwd</title> 
<META HTTP-EQUIV="Content-Type" CONTENT="text/html; charset=utf-8">
		<LINK href="../css/css.css" type="text/css" rel="stylesheet">
	</HEAD>
	<body MS_POSITIONING="GridLayout" LEFTMARGIN="0" TOPMARGIN="0" MARGINWIDTH="0" MARGINHEIGHT="0">
		<form id="Form1" method="post" runat="server">
			<table width="750" border="0" align="center" cellpadding="0" cellspacing="0" height="100%">
				<tr>
					<td colspan="2" style="HEIGHT: 27px"><FONT face="ËÎÌו">
							<uc1:top3 id="Top31" runat="server"></uc1:top3></FONT>
					</td>
				</tr>
				<tr>
					<td valign="top" width="195" align="left" bgcolor="#e8e6df">
						<uc1:leftmenu id="Leftmenu1" runat="server"></uc1:leftmenu>
					</td>
					<td width="556" align="center" valign="top">
						<table width="500" align="center" border="0" cellspacing="3" cellpadding="3">
							<tr>
								<td>&nbsp;</td>
								<td>&nbsp;</td>
							</tr>
							<tr>
								<td width="224" style="HEIGHT: 17px"><p>Please Input Your Password:
									</p>
								</td>
								<td width="276" style="HEIGHT: 17px"><INPUT type="password" id="oldPwd" name="Password1" runat="server"></td>
							</tr>
							<tr>
								<td width="224" style="HEIGHT: 17px"><p>Please choose a New Password:
									</p>
								</td>
								<td width="276" style="HEIGHT: 17px"><INPUT type="password" id="Password1" name="Password1" runat="server"></td>
							</tr>
							<tr>
								<td><p>Please confirm your New Password:
									</p>
								</td>
								<td><INPUT type="password" id="Password2" name="Password2" runat="server"></td>
							</tr>
							<tr>
								<td colspan="2" align="center"><INPUT id="Button1" type="button" value="Save" name="Button1" runat="server">&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp; 
									&nbsp; <input type="submit" name="Submit2" value="Cancel"></td>
							</tr>
						</table>
					</td>
				</tr>
			</table>
		</form>
	</body>
</HTML>
