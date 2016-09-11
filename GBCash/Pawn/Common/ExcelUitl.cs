using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.HtmlControls;
using System.IO;

namespace YingNet.Common
{
	/// <summary>
	/// ExcelUitl 的摘要说明。
	/// </summary>
	public class ExcelUitl
	{
		public ExcelUitl()
		{
			//
			// TODO: 在此处添加构造函数逻辑
			//
		}

		public void ExportToExcel(System.Web.UI.Control ctl)
		{
			Page page= ctl.Page;
			bool CurrCtlVisible=ctl.Visible;
			ctl.Visible=true;        
			page.Response.AppendHeader("Content-Disposition","attachment;filename=Excel.xls"); 
			page.Response.ContentEncoding = System.Text.Encoding.GetEncoding("GB2312");
			page.Response.ContentType = "application/ms-excel";
			ctl.Page.EnableViewState = false;
			System.IO.StringWriter tw = new System.IO.StringWriter();
			System.Web.UI.HtmlTextWriter hw = new HtmlTextWriter(tw);
			ctl.RenderControl(hw);
			page.Response.Write(tw.ToString());
			page.Response.End();
           
			ctl.Page.EnableViewState = true;
			ctl.Visible=CurrCtlVisible;
		}
	}
}
