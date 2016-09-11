namespace YingNet.WeiXing.WebApp.manage
{
	using System;
	using System.Data;
	using System.Web.UI.WebControls;
	using YingNet.Common;
	using YingNet.WeiXing.Business;
	using YingNet.WeiXing.DB.Data;

	public class MemberList : ManageBasePage
	{
		protected Button btnDelete;
		protected Button Button1;
		protected CheckBox CheckBox1;
		protected DataGridTable DataGridTable1;
		protected DropDownList DropDownList1;
		protected Label Label1;
		protected TextBox txCondition;
		protected TextBox txKey;
		protected TextBox txtParamstr;

		private void btnDelete_Click(object sender, EventArgs e)
		{
			string[] strArray = DataGridUtils.getID(this.DataGridTable1);
			if (strArray != null)
			{
				int num = 0;
				HuiyuanBN nbn = new HuiyuanBN(this.Page);
				for (int i = 0; i < strArray.Length; i++)
				{
					int id = Convert.ToInt32(strArray[i]);
					HuiyuanDT dt = nbn.Get(id);
					dt.IsValid = 3;
					if (nbn.Edit(dt))
					{
						num++;
					}
				}
				this.Page.RegisterStartupScript("", "<script language=javascript>alert('" + num.ToString().Trim() + "items are deleted in total');window.location='MemberList.aspx';</script>");
			}
		}

		private void Button1_Click(object sender, EventArgs e)
		{
			if (!(this.DropDownList1.SelectedValue != "0"))
			{
				return;
			}
			string str = "";
			string text = "";
			string str3 = "";
			string str4 = "";
			string str5 = "";
			switch (this.DropDownList1.SelectedValue)
			{
				case "1":
					str = " Fname like '%" + this.txKey.Text + "%' ";
					goto Label_0251;

				case "8":
					str = " Lname like '%" + this.txKey.Text + "%' ";
					goto Label_0251;

				case "2":
					str = " id=" + this.txKey.Text + " ";
					goto Label_0251;

				case "3":
					text = this.txKey.Text;
					str3 = text.Substring(0, 2);
					str4 = text.Substring(3, 2);
					str5 = text.Substring(6, 4);
					str = " day(Regtime) =" + str3 + " and month(Regtime)=" + str4 + " and year(Regtime)=" + str5 + " ";
					goto Label_0251;

				case "4":
					str = " IsValid=1 ";
					goto Label_0251;

				case "5":
					str = " IsValid=0 ";
					goto Label_0251;

				case "6":
					str = " IsValid=8 ";
					goto Label_0251;

				case "7":
					str = " IsValid=9 ";
					break;

				case "10":
					text = this.txKey.Text;
					str3 = text.Substring(0, 2);
					str4 = text.Substring(3, 2);
					str5 = text.Substring(6, 4);
					str = " day(DBirth) =" + str3 + " and month(DBirth)=" + str4 + " and year(DBirth)=" + str5 + " ";
					break;

				case "18":
					str= "E.Employer like '%"+ this.txKey.Text+"%'";
					break;
			}
			
			switch(this.DropDownList1.SelectedValue)
			{
				case "18":
					this.ViewState["SearchJoinEmployment"]= "true";
					break;
				default:
					this.ViewState["SearchJoinEmployment"]= string.Empty;
					break;
			}

			Label_0251:
				this.txCondition.Text = str;
			this.DataGridTable1.DataBind();
		}

		/// <summary>
		/// 判断当前选择的项是否为"未完成"
		/// </summary>
		/// <returns></returns>
		private bool IsChooseUnCompleted()
		{
			if(this.DropDownList1.SelectedValue=="7")
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		private void DataGridTable1_DataBinding(object sender, EventArgs e)
		{
			HuiyuanBN nbn = new HuiyuanBN(this.Page);
			if (this.txCondition.Text == "")
			{
				nbn.QueryNotValid("9");
				nbn.QueryNotValid("3");
			}
			else
			{
				nbn.Filter = this.txCondition.Text;
				
				nbn.QueryNotValid("3");
				if(this.IsChooseUnCompleted()==false)
				{
					nbn.QueryNotValid("9");
				}
			}
			DataTable dt=null;
			if(this.ViewState["SearchJoinEmployment"]==null||this.ViewState["SearchJoinEmployment"].ToString()==string.Empty)
			{
				dt=nbn.GetList();
			}
			else
			{
				dt=nbn.GetListJoinEmployment();
			}
			CommonBasePage.SetPage(this.DataGridTable1, dt);
			base.AddValue("pageno", Convert.ToString((int) (this.DataGridTable1.CurrentPageIndex + 1)));
			this.txtParamstr.Text = base.PackPart(base.ParamValue);
		}

		private void DataGridTable1_ItemDataBound(object sender, DataGridItemEventArgs e)
		{
			if (e.Item.ItemIndex <= -1)
			{
				return;
			}
			string text = e.Item.Cells[12].Text;
			string str2 = "";
			switch (text)
			{
				case "0":
					str2 = "New";
					goto Label_00F5;

				case "1":
					str2 = "Active";
					goto Label_00F5;

				case "2":
					str2 = "Uncompleted";
					goto Label_00F5;

				case "3":
					str2 = "Deleted";
					goto Label_00F5;

				case "5":
					str2 = "Expired";
					goto Label_00F5;

				case "6":
					str2 = "Rejected & Deleted";
					goto Label_00F5;

				case "8":
					str2 = "Rejected";
					break;

				case "9":
					str2 = "Uncompleted";
					break;


				case "18":
					str2= "PreApprove";
					break;
				case "21":
					str2= "ReudcedLimit";
					break;
				case "22":
					str2= "BlackList";
					break;
				case "23":
					str2= "PermantlyBlackList";
					break;
				case "24":
					str2= "Collection";
					break;
			}
			Label_00F5:
				e.Item.Cells[12].Text = str2;
			e.Item.Cells[11].Text = Convert.ToDateTime(e.Item.Cells[11].Text).ToString("dd/MM/yyyy hh:mm:ss");

			//用户的积分显示
			try
			{
				DataRowView rowMember= (DataRowView)e.Item.DataItem;
				
				string scoreDisplay= string.Empty;
				if(rowMember.Row["Param3"]==null||rowMember.Row["Param3"] is DBNull||rowMember.Row["Param3"].ToString()==string.Empty)
				{
					scoreDisplay= "Empty";
				}
				else
				{
					scoreDisplay= Convert.ToString(rowMember.Row["Param3"]);
				}

				e.Item.Cells[13].Text= string.Format("<a href='MemberScore.aspx?id={0}'>{1}</a>",rowMember.Row["id"],scoreDisplay);
			}
			catch
			{}

			//处理用户的Note和 FollowUpHistory
			try
			{
				DataRowView rowMember= (DataRowView)e.Item.DataItem;
				string noteDisplay= string.Empty;
				string followUpDisplay= string.Empty;
				if(rowMember.Row["Note"]==null||rowMember.Row["Note"] is DBNull||rowMember.Row["Note"].ToString()==string.Empty)
				{
					noteDisplay= "Empty";
					e.Item.Cells[16].Text= string.Format("<a href='MemberLoadNotes.aspx?id={0}'>{1}</a>",rowMember.Row["id"],noteDisplay);
				}
				else
				{
					noteDisplay= "Attention";
					e.Item.Cells[16].Text= string.Format("<a dealed='Attention' href='MemberLoadNotes.aspx?id={0}'>{1}</a>",rowMember.Row["id"],noteDisplay);
				}

				if(rowMember.Row["followUpHistory"]==null||rowMember.Row["followUpHistory"] is DBNull||rowMember.Row["followUpHistory"].ToString()==string.Empty)
				{
					followUpDisplay= "Empty";
					e.Item.Cells[17].Text= string.Format("<a href='MemberLoadFollowUpHistory.aspx?id={0}'>{1}</a>",rowMember.Row["id"],followUpDisplay);
				}
				else
				{
					followUpDisplay= "Attention";
					e.Item.Cells[17].Text= string.Format("<a dealed='Attention' href='MemberLoadFollowUpHistory.aspx?id={0}'>{1}</a>",rowMember.Row["id"],followUpDisplay);
				}
			}
			catch
			{}
		}

		private void DataGridTable1_PageIndexChanged(object source, DataGridPageChangedEventArgs e)
		{
			this.DataGridTable1.CurrentPageIndex = e.NewPageIndex;
			this.DataGridTable1.DataBind();
		}

		private void InitializeComponent()
		{
			this.Button1.Click += new EventHandler(this.Button1_Click);
			this.btnDelete.Click += new EventHandler(this.btnDelete_Click);
			this.DataGridTable1.PageIndexChanged += new DataGridPageChangedEventHandler(this.DataGridTable1_PageIndexChanged);
			this.DataGridTable1.DataBinding += new EventHandler(this.DataGridTable1_DataBinding);
			this.DataGridTable1.ItemDataBound += new DataGridItemEventHandler(this.DataGridTable1_ItemDataBound);
			base.Load += new EventHandler(this.Page_Load);
		}

		protected override void OnInit(EventArgs e)
		{
			this.InitializeComponent();
			base.OnInit(e);
		}

		private void Page_Load(object sender, EventArgs e)
		{
			if (!base.IsPostBack)
			{
				this.btnDelete.Text = "Delete";
				this.btnDelete.Attributes["onclick"] = "return deleteit(this.form)";
				this.txtParamstr.Text = base.PackPart(base.ParamValue);
				string str = base.GetValue("pageno");
				if (str != null)
				{
					this.DataGridTable1.CurrentPageIndex = Convert.ToInt32(str) - 1;
				}
				this.DataGridTable1.DataBind();
				ListItem item = null;
				item = new ListItem("Active", "4");
				this.DropDownList1.Items.Add(item);
				item = new ListItem("New", "5");
				this.DropDownList1.Items.Add(item);
				item = new ListItem("Rejected", "6");
				this.DropDownList1.Items.Add(item);
				item = new ListItem("Uncompleted", "7");
				this.DropDownList1.Items.Add(item);
				item= new ListItem("WorkPlace","18");//工作地点
				this.DropDownList1.Items.Add(item);
				this.Label1.Text = "Please enter the date format as DD/MM/YYYY";
			}
			else
			{
				base.ParamValue = base.UnPackPart(this.txtParamstr.Text);
			}
		}
	}
}

