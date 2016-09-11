//<copyright>英网资讯技术有限公司 1999-2004</copyright>
//<version>V1.0</verion>
//<createdate>2004-3-25</createdate>
//<author>wuhp</author>
//<email>wuhp@yingnet.com</email>
//<log date="2004-3-25">创建</log>

using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

namespace YingNet.Common {
    /// <summary>
    /// DataGrid工具集
    /// </summary>
    public class DataGridUtils {
        public DataGridUtils() {
        }

        /// <summary>
        /// 返回DataGrid的模板列的checkbox
        /// </summary>
        /// <param name="dgList">DataGrid</param>
        /// <returns>选中记录的值</returns>
        public static string[] getID (DataGrid dgList) {
            return getID(dgList, "chkID");
        }


        /// <summary>
        /// 返回DataGrid的模板列的checkbox
        /// </summary>
        /// <param name="dgList">DataGrid</param>
        /// <param name="chkID">checkbox的服务器端ID</param>
        /// <returns>选中记录的值</returns>
        public static string[] getID (DataGrid dgList, string chkID) {
            return getID(dgList, chkID, 0);
        }


        /// <summary>
        /// 返回DataGrid的模板列的checkbox
        /// </summary>
        /// <param name="dgList">DataGrid</param>
        /// <param name="chkID">checkbox的服务器端ID</param>
        /// <param name="index">选中的值的索引列</param>
        /// <returns>选中记录的值</returns>
        public static string[] getID (DataGrid dgList, string chkID, int index) {
            IList list = new ArrayList();
            foreach(DataGridItem dgi in dgList.Items) {
                
                //chkID是每个记录项的ID,记住，这是服务器端的ＩＤ，不是客户端的ＩＤ．
                System.Web.UI.Control l_ct = dgi.Cells[0].FindControl(chkID);
                if(l_ct != null) {
                    //下面语句是判断是否记录项的checkbox框初选种
                    if(((System.Web.UI.WebControls.CheckBox)l_ct).Checked) {
                        list.Add(dgi.Cells[index].Text);
                    }
                }
            }
            if (list.Count == 0) {
                return null;
            } else {
                string[] s = new string[list.Count];
                list.CopyTo(s, 0);
                return s;
            }
		}

		public static void SetPage (DataGrid dg, IList list) 
		{
			SetPage(dg, list.Count);

			dg.DataSource = list;
		}

		/// <summary>
		/// 设置datagrid的分页
		/// </summary>
		/// <param name="dg">datagrid</param>
		/// <param name="dt">datatable</param>
		public static void SetPage (DataGrid dg, DataTable dt) 
		{
			SetPage(dg, dt.Rows.Count);

			dg.DataSource = dt;
		}
        

		/// <summary>
		/// 设置datagrid的分页
		/// </summary>
		private static void SetPage (DataGrid dg, int recordnum) 
		{
			//最大页
			int maxPage = (int)(recordnum + dg.PageSize - 1) / dg.PageSize;

			if (maxPage == 0) 
			{
				maxPage = 1;
			}

			if (dg.CurrentPageIndex >= maxPage)
			{
				dg.CurrentPageIndex = maxPage - 1;
			}
           
			//如果是DataGridTable,设置全部记录数,Yingnet.Common.DataGridTable只是为了兼容CRM之前的项目
			if (dg.GetType().FullName.Equals("YingNet.Common.DataGridTable")) 
			{
				((YingNet.Common.DataGridTable)dg).MaxRecord = recordnum;
			}
		}

    }
}
