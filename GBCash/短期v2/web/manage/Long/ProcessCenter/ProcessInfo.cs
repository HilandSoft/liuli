namespace YingNet.WeiXing.WebApp.manage.Long.ProcessCenter
{
    using System;
    using System.Data;
    using System.Web.UI.WebControls;
    using YingNet.Common;
    using YingNet.Common.Utils;
    using YingNet.WeiXing.Business;
    using YingNet.WeiXing.DB.Data;
    using YingNet.WeiXing.STRUCTURE;

    public class ProcessInfo : ManageBasePage2
    {
        protected Button bnReturn;
        protected Button bnSave;
        protected Button btnDetailsVerified;
        protected Button btnFinalApproval;
        protected Button btnPreApproval;
        protected Button btnSave;
        protected Button btnSendForPreApproval;
        protected CheckBox cbBankStatement;
        protected CheckBox cbDirectDebitRequest;
        protected CheckBox cbID;
        protected CheckBox cbMasterLoanAgreement;
        protected CheckBox cbPaySlip;
        protected CheckBox cbUtilityBill;
        protected TextBox ConversationTrack;
        protected HyperLink HyperLink1;
        protected Label LabMemberID;
        private int ProcessID = 0;
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
        protected TextBox tbJobTitle;
        protected TextBox tbJobTitle2;
        protected TextBox tbNextPaydayDD;
        protected TextBox tbNextPaydayMM;
        protected TextBox tbNextPaydayYYYY;
        protected TextBox tbPayAfterTaxes;
        protected TextBox tbPayAfterTaxes2;
        protected TextBox tbPayFrequency;
        protected TextBox tbPayFrequency2;
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
                    LemploymentBN tbn = new LemploymentBN(this.Page);
                    LemploymentDT tdt = tbn.Get(Convert.ToInt32(this.Session["CurrentEmpID"]));
                    tdt.EAddress = this.tbEmployerAddress2.Text;
                    tdt.EName = this.tbEmpolyerName2.Text;
                    tdt.EStatus = this.tbEmploymentStatus2.Text;
                    tdt.JobTitle = this.tbJobTitle2.Text;
                    try
                    {
                        tdt.TakePay = Convert.ToDouble(this.tbPayAfterTaxes2.Text);
                    }
                    catch
                    {
                    }
                    tbn.Edit(tdt);
                }
                LpersonBN nbn = new LpersonBN(this.Page);
                LpersonDT detail = nbn.Get(dt.UserID);
                if (detail != null)
                {
                    detail.Mobile = this.tbEmployerTelephone2.Text;
                    detail.HTelnum = this.tbHomeTelephone2.Text;
                    detail.WTelnum = this.tbWorkTelephone2.Text;
                    nbn.Edit(detail);
                }
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
                dt.LastOperateDate = SafeDateTime.LocalNow;
                rbn.Edit(dt);
                base.Response.Redirect("ProcessList.aspx");
            }
        }

        private void btnPreApproval_Click(object sender, EventArgs e)
        {
            CSProcessCenterBN rbn = new CSProcessCenterBN(this.Page);
            CSProcessCenterDT dt = rbn.Get(this.ProcessID);
            if (dt != null)
            {
                dt.ConversationTrack = this.ConversationTrack.Text;
                dt.ProcessStatus = ProcessCenterStatusEnum.PreApproved;
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

        private void btnSendForPreApproval_Click(object sender, EventArgs e)
        {
            CSProcessCenterBN rbn = new CSProcessCenterBN(this.Page);
            CSProcessCenterDT dt = rbn.Get(this.ProcessID);
            if (dt != null)
            {
                dt.ConversationTrack = this.ConversationTrack.Text;
                dt.DocumentCheckListStatus = DocumentCheckListStatusEnum.Checked;
                dt.ProcessStatus = ProcessCenterStatusEnum.PreApproval;
                dt.LastOperateDate = SafeDateTime.LocalNow;
                dt.IsDocumentBankStatement = this.cbBankStatement.Checked;
                dt.IsDocumentDirectDebitRequest = this.cbDirectDebitRequest.Checked;
                dt.IsDocumentID = this.cbID.Checked;
                dt.IsDocumentMasterLoanAgreemnet = this.cbMasterLoanAgreement.Checked;
                dt.IsDocumentPaySlip = this.cbPaySlip.Checked;
                dt.IsDocumentUtilityBill = this.cbUtilityBill.Checked;
                rbn.Edit(dt);
                base.Response.Redirect("ProcessList.aspx");
            }
        }

        private void InitializeComponent()
        {
            this.btnSendForPreApproval.Click += new EventHandler(this.btnSendForPreApproval_Click);
            this.btnPreApproval.Click += new EventHandler(this.btnPreApproval_Click);
            this.btnDetailsVerified.Click += new EventHandler(this.btnDetailsVerified_Click);
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
                this.cbBankStatement.Checked = rdt.IsDocumentBankStatement;
                this.cbDirectDebitRequest.Checked = rdt.IsDocumentDirectDebitRequest;
                this.cbID.Checked = rdt.IsDocumentID;
                this.cbMasterLoanAgreement.Checked = rdt.IsDocumentMasterLoanAgreemnet;
                this.cbPaySlip.Checked = rdt.IsDocumentPaySlip;
                this.cbUtilityBill.Checked = rdt.IsDocumentUtilityBill;
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
                LpersonDT ndt = new LpersonBN(this.Page).Get(rdt.UserID);
                if (ndt != null)
                {
                    this.tbEmployerTelephone2.Text = ndt.Mobile;
                    this.tbHomeTelephone2.Text = ndt.HTelnum;
                    this.tbWorkTelephone2.Text = ndt.WTelnum;
                }
                LemploymentBN tbn = new LemploymentBN(this.Page);
                tbn.QueryLoanSid(rdt.UserID);
                DataTable list = tbn.GetList();
                if ((list != null) && (list.Rows.Count > 0))
                {
                    DataRow row2 = list.Rows[0];
                    this.Session["CurrentEmpID"] = Convert.ToInt32(row2["sid"]);
                    this.tbEmployerAddress2.Text = Convert.ToString(row2["EAddress"]);
                    this.tbEmpolyerName2.Text = Convert.ToString(row2["EName"]);
                    this.tbEmploymentStatus2.Text = Convert.ToString(row2["EStatus"]);
                    this.tbJobTitle2.Text = Convert.ToString(row2["JobTitle"]);
                    this.tbPayAfterTaxes2.Text = Convert.ToString(row2["TakePay"]);
                    this.tbTimeEmployed2.Text = Convert.ToString(row2["TimeYears"]) + "Year(s)" + Convert.ToString(row2["TimeMonths"]) + "Month(s)";
                }
                else
                {
                    this.Session["CurrentEmpID"] = 0;
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
                this.btnSendForPreApproval.Enabled = false;
                this.cbBankStatement.Enabled = false;
                this.cbDirectDebitRequest.Enabled = false;
                this.cbID.Enabled = false;
                this.cbMasterLoanAgreement.Enabled = false;
                this.cbPaySlip.Enabled = false;
                this.cbUtilityBill.Enabled = false;
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
                this.btnPreApproval.Enabled = false;
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
                return FunnctionModuleEnum.LProcessCenter;
            }
            set
            {
                base.FunnctionModuleName = value;
            }
        }
    }
}

