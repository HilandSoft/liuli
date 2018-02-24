namespace YingNet.WeiXing.WebApp.manage.ProcessCenter
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;

    public class ProcessInfoForNotFirst : ManageBasePage2
    {
        protected Button btnDetailsVerified;
        protected Button btnDocumnetReceived;
        protected Button btnFinalApproval;
        protected Button btnNoDocumnetReceived;
        protected Button btnSave;
        protected Button btnSendTaskToVA;
        protected TextBox ConversationTrack;
        protected HyperLink HyperLink1;
        protected Label LabMemberID;
        private int ProcessID = 0;
        protected TextBox tbDocumentRequired;
        protected TextBox tbEmployerAddress;
        protected TextBox tbEmployerAddress2;
        protected TextBox tbEmployerTelephone;
        protected TextBox tbEmployerTelephone2;
        protected TextBox tbEmploymentStatus;
        protected TextBox tbEmploymentStatus2;
        protected TextBox tbEmpolyerName;
        protected TextBox tbEmpolyerName2;
        protected TextBox tbHomeTelephone;
        protected TextBox tbHomeTelephone2;
        protected TextBox tbHomeTelephone3;
        protected TextBox tbJobTitle;
        protected TextBox tbJobTitle2;
        protected TextBox tbNextPaydayDD;
        protected TextBox tbNextPaydayMM;
        protected TextBox tbNextPaydayYYYY;
        protected TextBox tbPayAfterTaxes;
        protected TextBox tbPayAfterTaxes2;
        protected TextBox tbPayFrequency;
        protected TextBox tbPayFrequency2;
        protected TextBox tbTask;
        protected TextBox tbTimeEmployed;
        protected TextBox tbTimeEmployed2;
        protected TextBox tbWorkTelephone;
        protected TextBox tbWorkTelephone2;
        protected TextBox txPerSid;
        protected TextBox txSid;

        private void btnDetailsVerified_Click(object sender, EventArgs e)
        {
            CSProcessCenterBN rbn = new CSProcessCenterBN(this.Page);
            CSProcessCenterDT dt = rbn.Get(this.ProcessID);
            if (dt != null)
            {
                dt.ConversationTrack = this.ConversationTrack.Text;
                dt.DetailsVerificationStatus = DetailsVerificationStatusEnum.Done;
                dt.ProcessStatus = ProcessCenterStatusEnum.DetailVerified;
                if (dt.ProcessStatusDisplay == "Pending")
                {
                    dt.ProcessStatusDisplay = "Processing";
                }
                else
                {
                    dt.ProcessStatusDisplay = "DetailsVerified";
                }
                dt.LastOperateDate = SafeDateTime.LocalNow;
                rbn.Edit(dt);
                bool flag = false;
                CSUserLoanInfoCheckBN kbn = new CSUserLoanInfoCheckBN(this.Page);
                CSUserLoanInfoCheckDT kdt = kbn.Get(this.ProcessID);
                if (kdt == null)
                {
                    flag = true;
                    kdt = new CSUserLoanInfoCheckDT();
                    kdt.CheckOther1 = 0;
                    kdt.CheckOther2 = 0;
                    kdt.CheckOther3 = string.Empty;
                    kdt.CheckOther4 = string.Empty;
                    kdt.UserLoanType = UserLoanTypes.Short;
                    kdt.UserID = dt.UserID;
                    kdt.ProcessID = dt.ProcessID;
                }
                kdt.EmployerAddress = this.tbEmployerAddress.Text;
                kdt.EmployerName = this.tbEmpolyerName.Text;
                kdt.EmployerTelephone = this.tbEmployerTelephone.Text;
                kdt.HomeTelephone = this.tbHomeTelephone.Text;
                kdt.PayFrequency = this.tbPayFrequency.Text;
                try
                {
                    kdt.TakeHomePayAfterTaxes = Convert.ToDecimal(this.tbPayAfterTaxes.Text);
                }
                catch
                {
                }
                kdt.JobTitle = this.tbJobTitle.Text;
                kdt.TimeEmployed = this.tbTimeEmployed.Text;
                kdt.WorkTelephone = this.tbWorkTelephone.Text;
                try
                {
                    kdt.NextPayday = new DateTime(Convert.ToInt32(this.tbNextPaydayYYYY.Text), Convert.ToInt32(this.tbNextPaydayMM.Text), Convert.ToInt32(this.tbNextPaydayDD.Text));
                }
                catch
                {
                    kdt.NextPayday = new DateTime(0x6d9, 1, 2);
                }
                kdt.EmploymentStatusText = this.tbEmploymentStatus.Text;
                if (flag)
                {
                    kbn.Add(kdt);
                }
                else
                {
                    kbn.Edit(kdt);
                }
                if ((this.Session["CurrentEmpID"] != null) && (Convert.ToInt32(this.Session["CurrentEmpID"]) > 0))
                {
                    EmployedBN dbn = new EmployedBN(this.Page);
                    EmployedDT ddt = dbn.Get(Convert.ToInt32(this.Session["CurrentEmpID"]));
                    if (ddt != null)
                    {
                        ddt.EAddress = this.tbEmployerAddress2.Text;
                        ddt.Employer = this.tbEmpolyerName2.Text;
                        ddt.Wpaid = this.tbPayFrequency2.Text;
                        try
                        {
                            ddt.MIncome = Convert.ToSingle(this.tbPayAfterTaxes2.Text);
                        }
                        catch
                        {
                        }
                        ddt.Param5 = this.tbJobTitle2.Text;
                        ddt.EPhone = this.tbWorkTelephone2.Text;
                        dbn.Edit(ddt);
                    }
                }
                HuiyuanBN nbn = new HuiyuanBN(this.Page);
                HuiyuanDT ndt = nbn.Get(dt.UserID);
                if (ndt != null)
                {
                    ndt.HTel = this.tbHomeTelephone2.Text;
                    ndt.Mobile = this.tbEmployerTelephone2.Text;
                    nbn.Edit(ndt);
                }
                base.Response.Redirect("ProcessList.aspx");
            }
        }

        private void btnDocumnetReceived_Click(object sender, EventArgs e)
        {
            CSProcessCenterBN rbn = new CSProcessCenterBN(this.Page);
            CSProcessCenterDT dt = rbn.Get(this.ProcessID);
            if (dt != null)
            {
                dt.ConversationTrack = this.ConversationTrack.Text;
                dt.DocumentRequired = this.tbDocumentRequired.Text;
                dt.DocumentRequiredStatus = DocumentRequiredStatusEnum.Received;
                dt.ProcessStatus = ProcessCenterStatusEnum.PreApproved;
                if (dt.ProcessStatusDisplay == "Pending")
                {
                    dt.ProcessStatusDisplay = "Processing";
                }
                else
                {
                    dt.ProcessStatusDisplay = "DocReceived";
                }
                dt.LastOperateDate = SafeDateTime.LocalNow;
                rbn.Edit(dt);
                base.Response.Redirect("ProcessList.aspx");
            }
        }

        private void btnFinalApproval_Click(object sender, EventArgs e)
        {
            CSProcessCenterBN rbn = new CSProcessCenterBN(this.Page);
            CSProcessCenterDT dt = rbn.Get(this.ProcessID);
            if (dt != null)
            {
                dt.ConversationTrack = this.ConversationTrack.Text;
                dt.ProcessStatus = ProcessCenterStatusEnum.FinalApproval;
                dt.ProcessStatusDisplay = "FinalApproval";
                dt.LastOperateDate = SafeDateTime.LocalNow;
                rbn.Edit(dt);
                base.Response.Redirect("ProcessList.aspx");
            }
        }

        private void btnNoDocumnetReceived_Click(object sender, EventArgs e)
        {
            CSProcessCenterBN rbn = new CSProcessCenterBN(this.Page);
            CSProcessCenterDT dt = rbn.Get(this.ProcessID);
            if (dt != null)
            {
                dt.ConversationTrack = this.ConversationTrack.Text;
                dt.DocumentRequired = this.tbDocumentRequired.Text;
                dt.DocumentRequiredStatus = DocumentRequiredStatusEnum.NoDocumnetRequired;
                dt.ProcessStatus = ProcessCenterStatusEnum.PreApproved;
                if (dt.ProcessStatusDisplay == "Pending")
                {
                    dt.ProcessStatusDisplay = "Processing";
                }
                else
                {
                    dt.ProcessStatusDisplay = "NoDocReceived";
                }
                dt.LastOperateDate = SafeDateTime.LocalNow;
                rbn.Edit(dt);
                base.Response.Redirect("ProcessList.aspx");
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            CSProcessCenterBN rbn = new CSProcessCenterBN(this.Page);
            CSProcessCenterDT dt = rbn.Get(this.ProcessID);
            if (dt != null)
            {
                dt.ConversationTrack = this.ConversationTrack.Text;
                rbn.Edit(dt, false);
                base.Response.Redirect("ProcessList.aspx");
            }
        }

        private void btnSendTaskToVA_Click(object sender, EventArgs e)
        {
            CSProcessCenterBN rbn = new CSProcessCenterBN(this.Page);
            CSProcessCenterDT dt = rbn.Get(this.ProcessID);
            if (dt != null)
            {
                dt.ConversationTrack = this.ConversationTrack.Text;
                dt.Task = this.tbTask.Text;
                dt.ProcessStatus = ProcessCenterStatusEnum.PreApproval;
                dt.ProcessStatusDisplay = "TaskSent";
                dt.LastOperateDate = SafeDateTime.LocalNow;
                rbn.Edit(dt);
                base.Response.Redirect("ProcessList.aspx");
            }
        }

        private void InitializeComponent()
        {
            this.btnSendTaskToVA.Click += new EventHandler(this.btnSendTaskToVA_Click);
            this.btnDetailsVerified.Click += new EventHandler(this.btnDetailsVerified_Click);
            this.btnDocumnetReceived.Click += new EventHandler(this.btnDocumnetReceived_Click);
            this.btnNoDocumnetReceived.Click += new EventHandler(this.btnNoDocumnetReceived_Click);
            this.btnFinalApproval.Click += new EventHandler(this.btnFinalApproval_Click);
            this.btnSave.Click += new EventHandler(this.btnSave_Click);
            base.Load += new EventHandler(this.Page_Load);
        }

        private void LoadInfo()
        {
            CSProcessCenterDT rdt = new CSProcessCenterBN(this.Page).Get(this.ProcessID);
            if (rdt != null)
            {
                this.LabMemberID.Text = rdt.UserID.ToString();
                this.ConversationTrack.Text = rdt.ConversationTrack;
                this.tbTask.Text = rdt.Task;
                this.tbDocumentRequired.Text = rdt.DocumentRequired;
                CSUserLoanInfoCheckBN kbn = new CSUserLoanInfoCheckBN(this.Page);
                CSUserLoanInfoCheckDT kdt = kbn.Get(this.ProcessID);
                if (kdt == null)
                {
                    kbn.CleanStatus();
                    kbn.Filter = string.Format(" UserLoanType={0} ", (int) rdt.UserLoanType);
                    kbn.Filter = string.Format(" UserID={0} ", rdt.UserID);
                    DataTable table = kbn.GetList();
                    if ((table != null) && (table.Rows.Count > 0))
                    {
                        DataRow row = table.Rows[0];
                        this.tbEmployerAddress.Text = Convert.ToString(row["EmployerAddress"]);
                        this.tbEmpolyerName.Text = Convert.ToString(row["EmployerName"]);
                        this.tbEmployerTelephone.Text = Convert.ToString(row["EmployerTelephone"]);
                        this.tbHomeTelephone.Text = Convert.ToString(row["HomeTelephone"]);
                        this.tbPayFrequency.Text = Convert.ToString(row["PayFrequency"]);
                        this.tbPayAfterTaxes.Text = Convert.ToString(row["TakeHomePayAfterTaxes"]);
                        this.tbJobTitle.Text = Convert.ToString(row["JobTitle"]);
                        this.tbTimeEmployed.Text = Convert.ToString(row["TimeEmployed"]);
                        this.tbWorkTelephone.Text = Convert.ToString(row["WorkTelephone"]);
                        if (row["NextPayday"] != DBNull.Value)
                        {
                            DateTime time = Convert.ToDateTime(row["NextPayday"]);
                            if (time > new DateTime(0x6d9, 1, 3))
                            {
                                this.tbNextPaydayDD.Text = time.Day.ToString("00");
                                this.tbNextPaydayMM.Text = time.Month.ToString("00");
                                this.tbNextPaydayYYYY.Text = time.Year.ToString("0000");
                            }
                        }
                    }
                }
                else
                {
                    this.tbEmployerAddress.Text = kdt.EmployerAddress;
                    this.tbEmpolyerName.Text = kdt.EmployerName;
                    this.tbEmployerTelephone.Text = kdt.EmployerTelephone;
                    this.tbHomeTelephone.Text = kdt.HomeTelephone;
                    this.tbPayFrequency.Text = kdt.PayFrequency;
                    this.tbPayAfterTaxes.Text = kdt.TakeHomePayAfterTaxes.ToString();
                    this.tbJobTitle.Text = kdt.JobTitle;
                    this.tbTimeEmployed.Text = kdt.TimeEmployed;
                    this.tbWorkTelephone.Text = kdt.WorkTelephone;
                    this.tbEmploymentStatus.Text = kdt.EmploymentStatusText;
                    if (kdt.NextPayday > new DateTime(0x6d9, 1, 3))
                    {
                        this.tbNextPaydayDD.Text = kdt.NextPayday.Day.ToString("00");
                        this.tbNextPaydayMM.Text = kdt.NextPayday.Month.ToString("00");
                        this.tbNextPaydayYYYY.Text = kdt.NextPayday.Year.ToString("0000");
                    }
                }
                EmployedBN dbn = new EmployedBN(this.Page);
                dbn.Filter = string.Format(" huiSid={0} ", rdt.UserID);
                DataTable list = dbn.GetList();
                if ((list != null) && (list.Rows.Count > 0))
                {
                    DataRow row2 = list.Rows[0];
                    this.tbEmployerAddress2.Text = Convert.ToString(row2["EAddress"]);
                    this.tbEmpolyerName2.Text = Convert.ToString(row2["Employer"]);
                    this.tbPayFrequency2.Text = Convert.ToString(row2["Wpaid"]);
                    this.tbPayAfterTaxes2.Text = Convert.ToString(row2["MIncome"]);
                    this.tbJobTitle2.Text = Convert.ToString(row2["Param5"]);
                    this.tbTimeEmployed2.Text = string.Concat(new object[] { Convert.ToString(row2["TYears"]), "Year(s) ", Convert.ToInt32(row2["TMonths"]), "Month(s)" });
                    this.tbWorkTelephone2.Text = Convert.ToString(row2["EPhone"]);
                    this.Session["CurrentEmpID"] = Convert.ToInt32(row2["id"]);
                }
                else
                {
                    this.Session["CurrentEmpID"] = 0;
                }
                HuiyuanDT ndt = new HuiyuanBN(this.Page).Get(rdt.UserID);
                if (ndt != null)
                {
                    if (ndt.IsEmployed == 1)
                    {
                        this.tbEmploymentStatus2.Text = "PartTime";
                    }
                    else
                    {
                        this.tbEmploymentStatus2.Text = "FullTime";
                    }
                    this.tbHomeTelephone2.Text = ndt.HTel;
                    this.tbEmployerTelephone2.Text = ndt.Mobile;
                }
            }
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
        }

        private void Page_Load(object sender, EventArgs e)
        {
            this.ProcessID = Convert.ToInt32(base.Request.QueryString["ProcessID"]);
            this.SetState();
            if (!base.IsPostBack)
            {
                this.LoadInfo();
            }
        }

        private void SetState()
        {
            bool flag = false;
            bool flag2 = false;
            bool flag3 = false;
            bool flag4 = false;
            if (base.UserPermission == null)
            {
                if (base.SystemUserAccount.ToLower() == "superlily")
                {
                    flag = true;
                    flag2 = true;
                    flag3 = true;
                    flag4 = true;
                }
            }
            else
            {
                flag = this.ValitadePermissionOperate((CommonOperateEnum) base.UserPermission.PermissionProcessCenter, CommonOperateEnum.DocumentCheckList);
                flag2 = this.ValitadePermissionOperate((CommonOperateEnum) base.UserPermission.PermissionProcessCenter, CommonOperateEnum.DetailsVerification);
                flag3 = this.ValitadePermissionOperate((CommonOperateEnum) base.UserPermission.PermissionProcessCenter, CommonOperateEnum.PreApproval);
                flag4 = this.ValitadePermissionOperate((CommonOperateEnum) base.UserPermission.PermissionProcessCenter, CommonOperateEnum.FinalApproval);
            }
            if (!flag)
            {
                this.btnSendTaskToVA.Enabled = false;
            }
            if (!flag2)
            {
                this.btnDetailsVerified.Enabled = false;
                this.tbEmployerAddress.Enabled = false;
                this.tbEmployerTelephone.Enabled = false;
                this.tbEmploymentStatus.Enabled = false;
                this.tbEmpolyerName.Enabled = false;
                this.tbHomeTelephone.Enabled = false;
                this.tbJobTitle.Enabled = false;
            }
            if (!flag3)
            {
                this.btnDocumnetReceived.Enabled = false;
                this.btnNoDocumnetReceived.Enabled = false;
            }
            if (!flag4)
            {
                this.btnFinalApproval.Enabled = false;
            }
        }

        protected override bool ValitadePermissionOperate(CommonOperateEnum operatesOwned, CommonOperateEnum operateNeedValited)
        {
            if (operateNeedValited == CommonOperateEnum.CreateEdit)
            {
                if ((operatesOwned & CommonOperateEnum.DetailsVerification) != 0)
                {
                    return true;
                }
                if ((operatesOwned & CommonOperateEnum.DocumentCheckList) != 0)
                {
                    return true;
                }
                if ((operatesOwned & CommonOperateEnum.FinalApproval) != 0)
                {
                    return true;
                }
                if ((operatesOwned & CommonOperateEnum.PreApproval) != 0)
                {
                    return true;
                }
            }
            return base.ValitadePermissionOperate(operatesOwned, operateNeedValited);
        }

        protected override CommonOperateEnum CommonOperate
        {
            get
            {
                return CommonOperateEnum.CreateEdit;
            }
            set
            {
                base.CommonOperate = value;
            }
        }

        protected override FunnctionModuleEnum FunnctionModuleName
        {
            get
            {
                return FunnctionModuleEnum.ProcessCenter;
            }
            set
            {
                base.FunnctionModuleName = value;
            }
        }
    }
}

