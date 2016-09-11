///<copyright>英网资讯技术有限公司 1999-2003</copyright>
///<version>V1.0  </verion>
///<createdate>2003-6-18</createdate>
///<author>丁科康</author>
///<email>kkdingsoft@sina.com</email>
///<log date="2003-6-18">创建</log>
///<log date="2003-6-24" author="修改人">增加连接字串方法</log>

using System;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.ComponentModel;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Drawing;
using System.Drawing.Design; 

namespace YingNet.Common
{
	/// <summary>
	/// FileUpload 的摘要说明。E:\program\Common\FileUpload.bmp
	/// </summary>
    [ToolboxBitmap(typeof(YingNet.Common.FileUpload), "YingNet.Common.Res.FileUpload.bmp"), 
    DefaultProperty("Text"), DefaultEvent("Click"),
    ToolboxData("<{0}:FileUpload runat=server></{0}:FileUpload>")]
    public class FileUpload : System.Web.UI.WebControls.WebControl {

        #region 变量
        /// <summary>
        /// 上传按钮
        /// </summary>
        private Button button=new Button();
        /// <summary>
        /// 上传文件个数
        /// </summary>
        private int filenum=1;
        /// <summary>
        /// File对象
        /// </summary>
        private HtmlInputFile[] file;
        /// <summary>
        /// 保存路径，默认为系统的临时目录
        /// </summary>
        private string path=System.IO.Path.GetTempPath();
        /// <summary>
        /// 上传的文件名组
        /// </summary>
        private string[] filename;
        /// <summary>
        /// 原文件名
        /// </summary>
        private string[] oldfilename;
        /// <summary>
        /// 获取客户端发送文件的MIME内容类型
        /// </summary>
        private string[] contentType;
        /// <summary>
        /// 获取客户端上传文件的大小
        /// </summary>
        private int[] contentLength;
        /// <summary>
        /// 成功个数
        /// </summary>
        private int successNum=0;
        /// <summary>
        /// 后缀文件名组
        /// </summary>
        private string[] suffix;
        /// <summary>
        ///过滤器，写法是.txt;.abc
        /// </summary>
        private string filter="";
        /// <summary>
        /// 限制文件上传大小，为0是不限制，单位是字节
        /// </summary>
        private int size=0;//System.ComponentModel.DefaultEventAttribute
        #endregion

        #region 事件
        /// <summary>
        /// 上传事件
        /// </summary>
        [Bindable(true),Category("事件"),Description("上传后激发的事件")
        ] 
        public event EventHandler Click;
        #endregion

        #region Properties
        /// <summary>
        /// 上传文件数
        /// </summary>
        [Bindable(true), 
        Category("参数"),Description("设定上传文件的个数"),
        DefaultValue("1")] 
        public int FileNum{
            set{
                if(value<1){
                    value=1;
                }
                filenum=value;
                this.Controls.Clear();
                file=new HtmlInputFile[filenum];
                filename=new string[filenum];
                oldfilename=new string[filenum];
                contentType=new String[filenum];
                contentLength=new int[filenum];
                suffix=new string[filenum];
                for(int i=0;i<filenum;i++) {
                    file[i]=new HtmlInputFile();
                    file[i].Attributes["class"]=CssClass;
                    file[i].Style["width"]=(Width.Value-button.Width.Value)+"";
                    this.Controls.Add(file[i]);
                }
                button.CssClass=CssClass;
                file[0].ID=file[0].Name;
                button.Attributes["onclick"]="if("+file[0].ID+".value==''){ alert('请选择上传的文件');return false;}return confirm('请确认上传');";
                this.Controls.Add(button);
            }
            get{
                return filenum;
            }
        }
        /// <summary>
        /// 上传按钮的文本
        /// </summary>
        [Bindable(true), 
        Category("参数"), Description("设定上传文件的路径"),
        DefaultValue("1")] 
            /// <summary>
            /// 上传路径
            /// </summary>
        public string UploadPath {
            set{
                if("".Equals(value)||value==null){
                    value=System.IO.Path.GetTempPath();
                }
                path=value;
            }
            get{
                return path;
            }
        }
        /// <summary>
        /// 得到文件名
        /// </summary>
        public string[] Filename{
            get{
                return filename;
            }
        }
        /// <summary>
        /// 得到原文件名
        /// </summary>
        public string[] OldFilename{
            get{
                return oldfilename;
            }
        }
        /// <summary>
        /// 获取客户端发送文件的MIME内容类型
        /// </summary>
        public string[] ContentType{
            get{
                return contentType;
            }
        }
        /// <summary>
        /// 获取客户端上传文件的大小
        /// </summary>
        public int[] ContentLength{
            get{
                return contentLength;
            }
        }
        /// <summary>
        /// 上传后成功个数
        /// </summary>
        public int SuccessNum{
            get{
                return successNum;
            }
        }
        /// <summary>
        /// 得到后缀
        /// </summary>
        public string[] Suffix{
            get{
                return  suffix;
            }
        }
        /// <summary>
        /// 过滤器
        /// </summary>
        public string Filter{
            set{
                filter=value;
            }
            get{
                return filter;
            }
        }
        /// <summary>
        /// 限制大小
        /// </summary>
        public int FileSize{
            set{
                size=value;
            }
            get{
                return size;
            }
        }
        /// <summary>
        /// 快捷键
        /// </summary>
        public override string AccessKey{
            get{
                return button.AccessKey;
            }
            set{
                button.AccessKey=value;
            }
        }
        /// <summary>
        /// 背景
        /// </summary>
        public override System.Drawing.Color BackColor{
            get{
                return button.BackColor;
            }
            set{
                button.BackColor=value;
            }
        }
        /// <summary>
        /// 边框颜色
        /// </summary>
        public override System.Drawing.Color BorderColor{
            get{
                return button.BorderColor;
            }
            set{
                button.BorderColor=value;
            }
        }
        /// <summary>
        /// 边框风格
        /// </summary>
        public override BorderStyle BorderStyle{
            get{
                return button.BorderStyle;
            }
            set{
                button.BorderStyle=value;
            }
        }
        /// <summary>
        /// 上传框的宽度
        /// </summary>
        public int UploadSize{
            get{
                return file[0].Size;
            }
            set{
                for(int i=0;i<file.Length;i++){
                    file[i].Size=value;
                }
            }
        }
		/// <summary>
		/// 文本
		/// </summary>
		[Bindable(true), 
			Category("Appearance"), 
			DefaultValue("")] 
		public string Text 
		{
			get
			{
				return button.Text;
			}

			set
			{
				button.Text = value;
			}
		}
		#endregion

        #region 构造
		public FileUpload():base(){
			
			FileNum=1;
			button.Click+=new EventHandler(this.button_Click);
            button.CssClass=CssClass;
			this.Controls.Add(button);
			
		}
        #endregion

        #region 方法
		/// <summary>
		/// 按钮事件
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_Click(object sender, EventArgs e){
			Upload();
			///添加你的代码
			///
			if(Click!=null)
				Click(sender,e);		///抛处事件
		}
		/// <summary>
		/// 上传
		/// </summary>
		private void Upload(){
			System.Web.HttpPostedFile postedFile;
			for(int i=0;i<filenum;i++){
                try{
                    postedFile=file[i].PostedFile;
                    if(postedFile!=null) {
                        if(postedFile.ContentLength>size && size!=0){
                            break;
                        }
                        string s=postedFile.FileName;
                        int j=s.LastIndexOf("\\");
                        if(j==-1) break;
                        oldfilename[i]=s.Substring(j+1);
                        ContentType[i]=postedFile.ContentType;
                        ContentLength[i]=postedFile.ContentLength;
                        string suf=GetSuffix(oldfilename[i]);
                        if(filter.Length>0 && filter.IndexOf(suf)>-1){
                            break;
                        }
                        filename[i]=DateTime.Now.Ticks.ToString();
                        suffix[i]=suf;
                        if(!Directory.Exists(path)){
                            Directory.CreateDirectory(path);
                        }
                        postedFile.SaveAs(System.IO.Path.Combine(path,filename[i]+suf));
                        successNum++;
					
                    }
                }catch{
                }
			}
		}
		/// <summary>
		/// 获取后缀名
		/// </summary>
		/// <param name="filename">文件名</param>
		/// <returns>返回带.的后缀名</returns>
		private string GetSuffix(string filename){
			int index=filename.LastIndexOf(".");
			if(index>0){
				return filename.Substring(index);
			}
			return "";
		}
		/// <summary>
		/// 删除上传的文件
		/// </summary>
		public void DeleteFile(){
			foreach(string s in filename){
				if(s==null||"".Equals(s)) continue;
				File.Delete(path+"\\"+s);
			}
		}
			
        #endregion
	}
}
