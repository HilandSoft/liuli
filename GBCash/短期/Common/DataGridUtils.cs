//<copyright>Ӣ����Ѷ�������޹�˾ 1999-2004</copyright>
//<version>V1.0</verion>
//<createdate>2004-3-25</createdate>
//<author>wuhp</author>
//<email>wuhp@yingnet.com</email>
//<log date="2004-3-25">����</log>

using System;
using System.Collections;
using System.Data;
using System.Web.UI.WebControls;

namespace YingNet.Common {
    /// <summary>
    /// DataGrid���߼�
    /// </summary>
    public class DataGridUtils {
        public DataGridUtils() {
        }

        /// <summary>
        /// ����DataGrid��ģ���е�checkbox
        /// </summary>
        /// <param name="dgList">DataGrid</param>
        /// <returns>ѡ�м�¼��ֵ</returns>
        public static string[] getID (DataGrid dgList) {
            return getID(dgList, "chkID");
        }


        /// <summary>
        /// ����DataGrid��ģ���е�checkbox
        /// </summary>
        /// <param name="dgList">DataGrid</param>
        /// <param name="chkID">checkbox�ķ�������ID</param>
        /// <returns>ѡ�м�¼��ֵ</returns>
        public static string[] getID (DataGrid dgList, string chkID) {
            return getID(dgList, chkID, 0);
        }


        /// <summary>
        /// ����DataGrid��ģ���е�checkbox
        /// </summary>
        /// <param name="dgList">DataGrid</param>
        /// <param name="chkID">checkbox�ķ�������ID</param>
        /// <param name="index">ѡ�е�ֵ��������</param>
        /// <returns>ѡ�м�¼��ֵ</returns>
        public static string[] getID (DataGrid dgList, string chkID, int index) {
            IList list = new ArrayList();
            foreach(DataGridItem dgi in dgList.Items) {
                
                //chkID��ÿ����¼���ID,��ס�����Ƿ������˵ģɣģ����ǿͻ��˵ģɣģ�
                System.Web.UI.Control l_ct = dgi.Cells[0].FindControl(chkID);
                if(l_ct != null) {
                    //����������ж��Ƿ��¼���checkbox���ѡ��
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
		/// ����datagrid�ķ�ҳ
		/// </summary>
		/// <param name="dg">datagrid</param>
		/// <param name="dt">datatable</param>
		public static void SetPage (DataGrid dg, DataTable dt) 
		{
			SetPage(dg, dt.Rows.Count);

			dg.DataSource = dt;
		}
        

		/// <summary>
		/// ����datagrid�ķ�ҳ
		/// </summary>
		private static void SetPage (DataGrid dg, int recordnum) 
		{
			//���ҳ
			int maxPage = (int)(recordnum + dg.PageSize - 1) / dg.PageSize;

			if (maxPage == 0) 
			{
				maxPage = 1;
			}

			if (dg.CurrentPageIndex >= maxPage)
			{
				dg.CurrentPageIndex = maxPage - 1;
			}
           
			//�����DataGridTable,����ȫ����¼��,Yingnet.Common.DataGridTableֻ��Ϊ�˼���CRM֮ǰ����Ŀ
			if (dg.GetType().FullName.Equals("YingNet.Common.DataGridTable")) 
			{
				((YingNet.Common.DataGridTable)dg).MaxRecord = recordnum;
			}
		}

    }
}
