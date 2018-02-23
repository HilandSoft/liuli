namespace YingNet.WeiXing.DB
{
    using System;
    using System.Data;
    using System.Data.SqlClient;
    using YingNet.Common;
    using YingNet.WeiXing.DB.Data;

    public class MemberLoadNoteDB : DBAccess
    {
        public override object ConvertItem(SqlDataReader dr)
        {
            MemberLoadNoteDT edt = new MemberLoadNoteDT();
            edt.ExtendedNames = Convert.ToString(dr["ExtendedNames"]);
            edt.ExtendedValues = Convert.ToString(dr["ExtendedValues"]);
            edt.MemberID = Convert.ToInt32(dr["MemberID"]);
            edt.NodeDesc = Convert.ToString(dr["NodeDesc"]);
            edt.NodeOrder = Convert.ToInt32(dr["NodeOrder"]);
            edt.NodeStatus = Convert.ToInt32(dr["NodeStatus"]);
            edt.NoteContent = Convert.ToString(dr["NoteContent"]);
            edt.NoteID = Convert.ToInt32(dr["NoteID"]);
            return edt;
        }

        public MemberLoadNoteDT GetOneItem(int noteID)
        {
            MemberLoadNoteDT edt = null;
            SqlDataReader dr = null;
            try
            {
                string commandText = " select * from [MemberLoadNote] where NoteID=@NoteID;";
                SqlParameter[] commandParameters = new SqlParameter[] { base.MakeInParam("@NoteID", SqlDbType.Int, 4, noteID) };
                dr = SqlHelper.ExecuteReader(Config.DataSource, CommandType.Text, commandText, commandParameters);
                if (dr.Read())
                {
                    edt = (MemberLoadNoteDT) this.ConvertItem(dr);
                }
                else
                {
                    edt = null;
                }
                dr.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return edt;
        }

        public MemberLoadNoteDT GetOneItemByMemberID(int memberID)
        {
            MemberLoadNoteDT edt = null;
            SqlDataReader dr = null;
            try
            {
                string commandText = " select * from [MemberLoadNote] where MemberID=@MemberID;";
                SqlParameter[] commandParameters = new SqlParameter[] { base.MakeInParam("@MemberID", SqlDbType.Int, 4, memberID) };
                dr = SqlHelper.ExecuteReader(Config.DataSource, CommandType.Text, commandText, commandParameters);
                if (dr.Read())
                {
                    edt = (MemberLoadNoteDT) this.ConvertItem(dr);
                }
                else
                {
                    edt = null;
                }
                dr.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return edt;
        }

        public override SqlParameter[] GetParameter(object obj)
        {
            MemberLoadNoteDT edt = (MemberLoadNoteDT) obj;
            return new SqlParameter[] { base.MakeInParam("@ExtendedNames", SqlDbType.NVarChar, 0xfa0, edt.ExtendedNames), base.MakeInParam("@ExtendedValues", SqlDbType.NVarChar, 0xfa0, edt.ExtendedValues), base.MakeInParam("@MemberID", SqlDbType.Int, 4, edt.MemberID), base.MakeInParam("@NodeDesc", SqlDbType.NVarChar, 0xfa0, edt.NodeDesc), base.MakeInParam("@NoteContent", SqlDbType.NVarChar, 0xfa0, edt.NoteContent), base.MakeInParam("@NodeOrder", SqlDbType.Int, 4, edt.NodeOrder), base.MakeInParam("@NodeStatus", SqlDbType.Int, 4, edt.NodeStatus), base.MakeInParam("@NoteID", SqlDbType.Int, 4, edt.NoteID) };
        }

        public int Insert(object ob)
        {
            try
            {
                string commandText = " insert into [MemberLoadNote] (NodeStatus,NodeOrder,NoteContent,NodeDesc,MemberID,ExtendedValues,ExtendedNames) values (@NodeStatus,@NodeOrder,@NoteContent,@NodeDesc,@MemberID,@ExtendedValues,@ExtendedNames);";
                SqlHelper.ExecuteScalar(Config.DataSource, CommandType.Text, commandText, this.GetParameter(ob));
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return 0;
        }

        public override bool Update(object ob)
        {
            try
            {
                string commandText = " update [MemberLoadNote] set NodeStatus=@NodeStatus,NodeOrder=@NodeOrder,NoteContent=@NoteContent,NodeDesc=@NodeDesc,MemberID=@MemberID,ExtendedValues=@ExtendedValues,ExtendedNames=@ExtendedNames Where NoteID=@NoteID";
                SqlHelper.ExecuteScalar(Config.DataSource, CommandType.Text, commandText, this.GetParameter(ob));
            }
            catch (Exception exception)
            {
                throw exception;
            }
            return true;
        }
    }
}

