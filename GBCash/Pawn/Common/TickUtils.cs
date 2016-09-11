//<copyright>Ӣ����Ѷ�������޹�˾ 1999-2004</copyright>
//<version>V1.0</verion>
//<createdate>2004-3-15</createdate>
//<author>wuhp</author>
//<email>wuhp@yingnet.com</email>
//<log date="2004-3-15">����</log>

using System;

namespace YingNet.Common {
    /// <summary>
    /// ����ʱ��ת�����߼�,��0001/01/01��ʼ
    /// </summary>
    public class TickUtils {
        public TickUtils() {
        }

        /// <summary>
        /// ���ص�ǰʱ��ĺ����ʾ
        /// </summary>
        /// <returns>����ʱ��</returns>
        public static long GetTick () {
            return ConvertToMilli(System.DateTime.Now.Ticks);
        }

        /// <summary>
        /// ����ָ�����ڵĿ�ʼʱ��ĺ����ʾ
        /// </summary>
        /// <param name="date">ʱ��</param>
        /// <returns>����ʱ��</returns>
        public static long GetTick (string date) {
            return ConvertToMilli(Convert.ToDateTime(date).Ticks);
        }

        /// <summary>
        /// ����ָ��������
        /// </summary>
        /// <param name="tick">����ʱ��</param>
        /// <param name="daydiff">ʱ���</param>
        /// <returns>����ʱ��</returns>
        public static long AddDays (long tick, int daydiff) {
            return (tick + 24L * 60 * 60 * 1000 * daydiff);
        }

        /// <summary>
        /// ��ʽ��ʱ��
        /// </summary>
        /// <param name="tick">����ʱ��</param>
        /// <returns>��ʽ�����ʱ���ַ���</returns>
        public static string DateFormat (long tick) {
            return DateUtils.DateFormat(ConvertToDateTime(tick));
        }

        /// <summary>
        /// ��ʽ��ʱ��
        /// </summary>
        /// <param name="tick">����ʱ��</param>
        /// <param name="format">��ʽ����</param>
        /// <returns>��ʽ�����ʱ���ַ���</returns>
        public static string DateFormat (long tick, string format) {
            return DateUtils.DateFormat(ConvertToDateTime(tick), format);
        }

        /// <summary>
        /// ��ʽ������ʱ��
        /// </summary>
        /// <param name="tick">����ʱ��</param>
        /// <returns>��ʽ���������ʱ���ַ���</returns>
        public static string DateTimeFormat (long tick) {
            return DateUtils.DateFormat(ConvertToDateTime(tick));
        }

        /// <summary>
        /// ��ʽ������ʱ��
        /// </summary>
        /// <param name="tick">����ʱ��</param>
        /// <param name="format">��ʽ����</param>
        /// <returns>��ʽ���������ʱ���ַ���</returns>
        public static string DateTimeFormat (long tick, string format) {
            return DateUtils.DateFormat(ConvertToDateTime(tick), format);
        }

        /// <summary>
        /// ��dotnet 100��΢��ת��Ϊ����
        /// </summary>
        /// <param name="nano">dotnet��100��΢��</param>
        /// <returns>����ʱ��</returns>
        private static long ConvertToMilli (long nano) {
            return nano / 10000;
        }

        /// <summary>
        /// ������תΪdatetime����
        /// </summary>
        /// <param name="tick">����ʱ��</param>
        /// <returns>ʱ�����</returns>
        public static DateTime ConvertToDateTime (long tick) {
            return new DateTime(tick * 10000);
        }
    }
}
