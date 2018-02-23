namespace YingNet.WeiXing.DB.Data
{
    using System;

    public class MemberLoadNoteDT
    {
        private string extendedNames;
        private string extendedValues;
        private int memberID;
        private string nodeDesc;
        private int nodeOrder;
        private int nodeStatus;
        private string noteContent;
        private int noteID;

        public string ExtendedNames
        {
            get
            {
                return this.extendedNames;
            }
            set
            {
                this.extendedNames = value;
            }
        }

        public string ExtendedValues
        {
            get
            {
                return this.extendedValues;
            }
            set
            {
                this.extendedValues = value;
            }
        }

        public int MemberID
        {
            get
            {
                return this.memberID;
            }
            set
            {
                this.memberID = value;
            }
        }

        public string NodeDesc
        {
            get
            {
                return this.nodeDesc;
            }
            set
            {
                this.nodeDesc = value;
            }
        }

        public int NodeOrder
        {
            get
            {
                return this.nodeOrder;
            }
            set
            {
                this.nodeOrder = value;
            }
        }

        public int NodeStatus
        {
            get
            {
                return this.nodeStatus;
            }
            set
            {
                this.nodeStatus = value;
            }
        }

        public string NoteContent
        {
            get
            {
                return this.noteContent;
            }
            set
            {
                this.noteContent = value;
            }
        }

        public int NoteID
        {
            get
            {
                return this.noteID;
            }
            set
            {
                this.noteID = value;
            }
        }
    }
}

