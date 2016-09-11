///<copyright>Ӣ����Ѷ�������޹�˾ 1999-2003</copyright>
///<version>V1.0  </verion>
///<createdate>2003-7-7</createdate>
///<author>���ƿ�</author>
///<email>kkdingsoft@sina.com</email>
///<log date="2003-7-7">����</log>


using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;

namespace YingNet.Common
{
   
	/// <summary>
	/// DataGrid ��ժҪ˵����
	/// </summary>
    [
    ToolboxBitmap(typeof(YingNet.Common.DataGridTable), "YingNet.Common.DataGridTable.bmp"), 
    ///DefaultProperty("Text"), 
    ToolboxData("<{0}:DataGridTable runat=server></{0}:DataGridTable>")]
   
    public class DataGridTable : System.Web.UI.WebControls.DataGrid,INamingContainer,IPostBackEventHandler {

	   
        private LinkButton startPage =new LinkButton();
        private LinkButton prevPage =new LinkButton();
        private LinkButton nextPage =new LinkButton();
        private LinkButton endPage =new LinkButton();
        private string sStartPage="Head";
        private string sPrevPage="Prev";
        private string sNextPage="Next";
        private string sEndPage="End";
        private DropDownList numPage=new DropDownList();
        private Panel myPanel=new Panel();
        private string pageCSS="scrollButton";
		private bool isShowFoot=true;
      
        [Bindable(true), 
        Category("��ҳ"), 
        DefaultValue("True"),Description("�Զ����ҳ")] 
        public bool IsAllowPaging{
            get{
                object obj=ViewState["isAllowPaging"];
                return ((null ==obj ) ? true : Convert.ToBoolean( obj));

            }
            set{
                ViewState["isAllowPaging"]=value;
            }
        }
        [Bindable(true), 
        Category("��ҳ"), 
        Description("�ܼ�¼��")] 
        public int MaxRecord{
            get{
                object obj=ViewState["maxRecord"];
                return ((null ==obj ) ? 0 : Convert.ToInt32( obj));
            }
            set{
                ViewState["maxRecord"]=value;
            }
        }
        [Bindable(true), 
        Category("��ҳ"), 
        DefaultValue("��ҳ"),Description("�ص���ҳ")] 
        public string StartPage{
            get{
                return sStartPage;
            }
            set{
                sStartPage=value;
            }
            
        }
        [Bindable(true), 
        Category("��ҳ"), 
        DefaultValue("βҳ"),Description("�ص�βҳ")] 
        public string EndPage{
            get{
                return sEndPage;
                
            }
            set{
                sEndPage=value;
            }
            
        }
        [Bindable(true), 
        Category("��ҳ"), 
        DefaultValue("ǰҳ"),Description("��һҳ")] 
        public string PrevPage{
            get{
                return sPrevPage;
            }
            set{
                sPrevPage=value;
            }
        }
        [Bindable(true), 
        Category("��ҳ"), 
        DefaultValue("��ҳ"),Description("��һҳ")] 
        public string NextPage{
            get{
                return sNextPage;
            }
            set{
                sNextPage=value;
            }
        }
        [Bindable(true), 
        Category("��ҳ���"), 
        DefaultValue(""),Description("��ť��CSS")] 
        public string PageCSS{
            get{
                return pageCSS;
            }
            set{
                pageCSS=value;
            }
        }

		//=======================================================================
		// ***** [ADDED BY DoItNow,2004/6/24] �Ƿ���ʾ �ײ���Ϣ
		//-----------------------------------------------------------------------
		[Bindable(true), 
		Category("��ҳ���"), 
		DefaultValue(""),Description("�Ƿ���ʾFoot��")] 
		public bool IsShowFoot
		{
			get
			{
				return this.isShowFoot;
			}
			set
			{
				this.isShowFoot= value;
			}
		}
		//=======================================================================
      
       

     

        protected override void OnInit(EventArgs e){
            EnableViewState = true;
            CssClass="tableGrid";
            HeaderStyle.CssClass="gridHeader";
            FooterStyle.CssClass="gridFooter";
            PagerStyle.CssClass="gridPager";
            ItemStyle.CssClass="gridItem";
            AlternatingItemStyle.CssClass="gridAltItem";
            EditItemStyle.CssClass="gridEditItem";
            SelectedItemStyle.CssClass="gridSelectedItem";
            base.OnInit(e);
        }

        
        protected override void OnPreRender(EventArgs e) {
            Page.GetPostBackEventReference(this);
        }
        protected override void OnItemDataBound(DataGridItemEventArgs e) {
            base.OnItemDataBound(e);
        }
        protected override void OnItemCommand(DataGridCommandEventArgs e){
            base.OnItemCommand(e);
            
        }
        protected override bool OnBubbleEvent(object source,EventArgs e){
            return base.OnBubbleEvent( source,e);
        }
        

        /// <summary>
        /// ����ط��¼�
        /// </summary>
        /// <param name="eventArgument">������</param>
        public void RaisePostBackEvent(string eventArgument) { 
            int NewPageIndex=0;
            if(PagerStyle.Position.Equals(PagerPosition.Bottom)){
                CurrentPageIndex=Convert.ToInt32( Page.Request.Params[this.UniqueID+":numPageBottom"])-1;
            }else{
                CurrentPageIndex=Convert.ToInt32( Page.Request.Params[this.UniqueID+":numPageTop"])-1;
            }
            if("prevPage".Equals( eventArgument)){
                NewPageIndex=CurrentPageIndex-1;
            }else if("nextPage".Equals( eventArgument)){
                NewPageIndex=CurrentPageIndex+1;
            }else if(eventArgument.StartsWith("endPage" )){
                NewPageIndex=Convert.ToInt32(eventArgument.Substring(7));
            }else if("numPageTop".Equals( eventArgument)){
                NewPageIndex=Convert.ToInt32( Page.Request.Params[this.UniqueID+":numPageTop"])-1;
            }
            else if("numPageBottom".Equals( eventArgument)){
                NewPageIndex=Convert.ToInt32( Page.Request.Params[this.UniqueID+":numPageBottom"])-1;
            }
            OnPageIndexChanged(new DataGridPageChangedEventArgs(this,NewPageIndex));
        }

        /// <summary> 
        /// ���˿ؼ����ָ�ָ�������������
        /// </summary>
        /// <param name="output"> Ҫд������ HTML ��д�� </param>
        /// 

        protected override void Render(HtmlTextWriter output) {
            if(IsAllowPaging)
			{
                AllowPaging=true;
                PagerStyle.Visible=false;
                myPanel.CopyBaseAttributes(this);
                Style.Remove("POSITION");
                Style.Remove("Z-INDEX");
                myPanel.RenderBeginTag(output);
                Table table=new Table();
                table.CopyBaseAttributes(this);
                table.BackColor=(PagerStyle.BackColor.Equals(Color.Empty))?this.BackColor:PagerStyle.BackColor;
                table.BackImageUrl=BackImageUrl;
                table.BorderColor=PagerStyle.BorderColor.IsEmpty?BorderColor:PagerStyle.BorderColor;
                table.BorderStyle=PagerStyle.BorderStyle;
                table.BorderWidth=Unit.Point(0);//(PagerStyle.BorderWidth.IsEmpty)?BorderWidth:PagerStyle.BorderWidth;
                //table.HorizontalAlign=this.HorizontalAlign;
                table.Width=Width;
                table.CellPadding=CellPadding;
                table.CellSpacing=CellSpacing;
                table.GridLines=GridLines;
                table.Font.Size=FontUnit.Point(9);
                TableRow tr=new TableRow();
                table.Controls.Add(tr);
                TableCell td=new TableCell();
                startPage.CssClass=pageCSS;
                startPage.Text=sStartPage;
                prevPage.CssClass=pageCSS;
                prevPage.Text=sPrevPage;
                nextPage.CssClass=pageCSS;
                nextPage.Text=sNextPage;
                endPage.CssClass=pageCSS;
                endPage.Text=sEndPage;
                numPage.CssClass=pageCSS;
                tr.Controls.Add(td);
                td.Attributes["style"]="BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none";
                
				//=======================================================================
				// ***** [ADDED BY DoItNow,2004/6/24] �Ƿ���ʾ �ײ���Ϣ
				//-----------------------------------------------------------------------
				if(this.isShowFoot==true)
				{
					td.Controls.Add(new LiteralControl("&nbsp;&nbsp;Total <font color=red>"+MaxRecord+"</font>Items/<font color=red>"+PageSize+"</font> Items"));
					td.Controls.Add(new LiteralControl("&nbsp;Current<font color=red>"+(CurrentPageIndex+1)+"</font>/<font color=red>"+PageCount+"</font>Pages"));
					td.Controls.Add(new LiteralControl("</td><td  style=\"BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none\">"));
					if(CurrentPageIndex!=0)
					{
						startPage.Attributes["href"]="javascript:"+Page.GetPostBackEventReference(this,"startPage");
						prevPage.Attributes["href"]="javascript:"+Page.GetPostBackEventReference(this,"prevPage");
						td.Controls.Add(startPage);
						td.Controls.Add(new LiteralControl("&nbsp;"));
						td.Controls.Add(prevPage);
						td.Controls.Add(new LiteralControl("&nbsp;"));
					}
					else
					{
						td.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
					}
					if(CurrentPageIndex<(PageCount-1))
					{
						nextPage.Attributes["href"]="javascript:"+Page.GetPostBackEventReference(this,"nextPage");
						endPage.Attributes["href"]="javascript:"+Page.GetPostBackEventReference(this,"endPage"+(PageCount-1));
						td.Controls.Add(nextPage);
						td.Controls.Add(new LiteralControl("&nbsp;"));
						td.Controls.Add(endPage);
						td.Controls.Add(new LiteralControl("&nbsp;"));
					}
					else
					{
						td.Controls.Add(new LiteralControl("&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;"));
					}
					for(int i=0;i<PageCount;i++)
					{
						ListItem list=new ListItem((i+1).ToString());
						if(i==CurrentPageIndex) list.Selected=true;
						numPage.Items.Add(list);
					}
					td.Controls.Add(new LiteralControl("</td><td align=right style=\"BORDER-TOP-STYLE: none; BORDER-RIGHT-STYLE: none; BORDER-LEFT-STYLE: none; BORDER-BOTTOM-STYLE: none\">Go"));
					td.Controls.Add(numPage);
					td.Controls.Add(new LiteralControl(""));
				}
				else
				{
					LiteralControl temp= new LiteralControl(" &nbsp; &nbsp; &nbsp;");
					td.Controls.Add(temp);
				}
				//=======[ADDED END]=====================================================
				

                if(PagerStyle.Position==PagerPosition.Top||PagerStyle.Position==PagerPosition.TopAndBottom){
                    numPage.ID=this.UniqueID+":numPageTop";
                    numPage.Attributes["onchange"]=Page.GetPostBackEventReference(this,"numPageTop");
                    table.RenderControl(output);
                }
                base.Render(output);
                
                if(PagerStyle.Position==PagerPosition.Bottom||PagerStyle.Position==PagerPosition.TopAndBottom){
                    numPage.ID=this.UniqueID+":numPageBottom";
                    numPage.Attributes["onchange"]=Page.GetPostBackEventReference(this,"numPageBottom");
                    table.RenderControl(output);
                }
                myPanel.RenderEndTag(output);
            }
			else
			{
                base.Render(output);
            }
            EnableViewState=false;
        }

     
	}


}
