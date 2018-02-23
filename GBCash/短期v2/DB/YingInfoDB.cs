namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class YingInfoDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            YingInfoDT odt = new YingInfoDT();
            odt.InfoIsTop = Convert.ToBoolean(dr["InfoIsTop"]);
            odt.InfoPubDate = Convert.ToDateTime(dr["InfoPubDate"]);
            odt.InfoID = Convert.ToInt32(dr["InfoID"]);
            odt.InfoTitle = Convert.ToString(dr["InfoTitle"]);
            odt.ImgPath = Convert.ToString(dr["ImgPath"]);
            odt.InfoTypeNo = Convert.ToString(dr["InfoTypeNo"]);
            odt.InfoContent = Convert.ToString(dr["InfoContent"]);
            return odt;
        }

        public DataTable GetList()
        {
            return this.RunSqlString("SELECT InfoID, InfoTitle,InfoContent, InfoIsTop, InfoTypeNo,ImgPath, InfoPubDate FROM YingInfo ORDER BY InfoPubDate DESC", "data");
        }

        public YingInfoDT GetOneDT(int id)
        {
            return (YingInfoDT) this.GetOneItem(id);
        }

        public override SqlParameter[] GetParameter(int id)
        {
            return new SqlParameter[] { base.MakeInParam("@InfoID", SqlDbType.Int, 4, id) };
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            YingInfoDT odt = (YingInfoDT) obj;
            return new SqlParameter[] { base.MakeInParam("@InfoIsTop", SqlDbType.Bit, 1, odt.InfoIsTop), base.MakeInParam("@InfoPubDate", SqlDbType.DateTime, 8, odt.InfoPubDate), base.MakeInParam("@InfoID", SqlDbType.Int, 4, odt.InfoID), base.MakeInParam("@InfoTitle", SqlDbType.NVarChar, 800, odt.InfoTitle), base.MakeInParam("@ImgPath", SqlDbType.NVarChar, 600, odt.ImgPath), base.MakeInParam("@InfoTypeNo", SqlDbType.NVarChar, 240, odt.InfoTypeNo), base.MakeInParam("@InfoContent", SqlDbType.NText, 0, odt.InfoContent) };
        }
    }
}

