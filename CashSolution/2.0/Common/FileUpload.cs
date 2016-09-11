///<copyright>Ӣ����Ѷ�������޹�˾ 1999-2003</copyright>
///<version>V1.0  </verion>
///<createdate>2003-6-18</createdate>
///<author>���ƿ�</author>
///<email>kkdingsoft@sina.com</email>
///<log date="2003-6-18">����</log>
///<log date="2003-6-24" author="�޸���">���������ִ�����</log>

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
	/// FileUpload ��ժҪ˵����E:\program\Common\FileUpload.bmp
	/// </summary>
    [ToolboxBitmap(typeof(YingNet.Common.FileUpload), "YingNet.Common.Res.FileUpload.bmp"), 
    DefaultProperty("Text"), DefaultEvent("Click"),
    ToolboxData("<{0}:FileUpload runat=server></{0}:FileUpload>")]
    public class FileUpload : System.Web.UI.WebControls.WebControl {

        #region ����
        /// <summary>
        /// �ϴ���ť
        /// </summary>
        private Button button=new Button();
        /// <summary>
        /// �ϴ��ļ�����
        /// </summary>
        private int filenum=1;
        /// <summary>
        /// File����
        /// </summary>
        private HtmlInputFile[] file;
        /// <summary>
        /// ����·����Ĭ��Ϊϵͳ����ʱĿ¼
        /// </summary>
        private string path=System.IO.Path.GetTempPath();
        /// <summary>
        /// �ϴ����ļ�����
        /// </summary>
        private string[] filename;
        /// <summary>
        /// ԭ�ļ���
        /// </summary>
        private string[] oldfilename;
        /// <summary>
        /// ��ȡ�ͻ��˷����ļ���MIME��������
        /// </summary>
        private string[] contentType;
        /// <summary>
        /// ��ȡ�ͻ����ϴ��ļ��Ĵ�С
        /// </summary>
        private int[] contentLength;
        /// <summary>
        /// �ɹ�����
        /// </summary>
        private int successNum=0;
        /// <summary>
        /// ��׺�ļ�����
        /// </summary>
        private string[] suffix;
        /// <summary>
        ///��������д����.txt;.abc
        /// </summary>
        private string filter="";
        /// <summary>
        /// �����ļ��ϴ���С��Ϊ0�ǲ����ƣ���λ���ֽ�
        /// </summary>
        private int size=0;//System.ComponentModel.DefaultEventAttribute
        #endregion

        #region �¼�
        /// <summary>
        /// �ϴ��¼�
        /// </summary>
        [Bindable(true),Category("�¼�"),Description("�ϴ��󼤷����¼�")
        ] 
        public event EventHandler Click;
        #endregion

        #region Properties
        /// <summary>
        /// �ϴ��ļ���
        /// </summary>
        [Bindable(true), 
        Category("����"),Description("�趨�ϴ��ļ��ĸ���"),
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
                button.Attributes["onclick"]="if("+file[0].ID+".value==''){ alert('��ѡ���ϴ����ļ�');return false;}return confirm('��ȷ���ϴ�');";
                this.Controls.Add(button);
            }
            get{
                return filenum;
            }
        }
        /// <summary>
        /// �ϴ���ť���ı�
        /// </summary>
        [Bindable(true), 
        Category("����"), Description("�趨�ϴ��ļ���·��"),
        DefaultValue("1")] 
            /// <summary>
            /// �ϴ�·��
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
        /// �õ��ļ���
        /// </summary>
        public string[] Filename{
            get{
                return filename;
            }
        }
        /// <summary>
        /// �õ�ԭ�ļ���
        /// </summary>
        public string[] OldFilename{
            get{
                return oldfilename;
            }
        }
        /// <summary>
        /// ��ȡ�ͻ��˷����ļ���MIME��������
        /// </summary>
        public string[] ContentType{
            get{
                return contentType;
            }
        }
        /// <summary>
        /// ��ȡ�ͻ����ϴ��ļ��Ĵ�С
        /// </summary>
        public int[] ContentLength{
            get{
                return contentLength;
            }
        }
        /// <summary>
        /// �ϴ���ɹ�����
        /// </summary>
        public int SuccessNum{
            get{
                return successNum;
            }
        }
        /// <summary>
        /// �õ���׺
        /// </summary>
        public string[] Suffix{
            get{
                return  suffix;
            }
        }
        /// <summary>
        /// ������
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
        /// ���ƴ�С
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
        /// ��ݼ�
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
        /// ����
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
        /// �߿���ɫ
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
        /// �߿���
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
        /// �ϴ���Ŀ��
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
		/// �ı�
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

        #region ����
		public FileUpload():base(){
			
			FileNum=1;
			button.Click+=new EventHandler(this.button_Click);
            button.CssClass=CssClass;
			this.Controls.Add(button);
			
		}
        #endregion

        #region ����
		/// <summary>
		/// ��ť�¼�
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void button_Click(object sender, EventArgs e){
			Upload();
			///�����Ĵ���
			///
			if(Click!=null)
				Click(sender,e);		///�״��¼�
		}
		/// <summary>
		/// �ϴ�
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
		/// ��ȡ��׺��
		/// </summary>
		/// <param name="filename">�ļ���</param>
		/// <returns>���ش�.�ĺ�׺��</returns>
		private string GetSuffix(string filename){
			int index=filename.LastIndexOf(".");
			if(index>0){
				return filename.Substring(index);
			}
			return "";
		}
		/// <summary>
		/// ɾ���ϴ����ļ�
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
