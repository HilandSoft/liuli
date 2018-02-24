namespace YingNet.WeiXing.WebApp.Include
{
    using System;
    using System.Web.UI;
    using System.Web.UI.WebControls;

    public class CircleDropDownList : UserControl
    {
        protected DropDownList DropDownList1;

        private void BindInfo()
        {
            ListItem item = new ListItem("Weekly", "Weekly");
            ListItem item2 = new ListItem("F'Night", "FNight");
            ListItem item3 = new ListItem("Bi-Month", "BiMonth");
            ListItem item4 = new ListItem("Monthly", "Monthly");
            this.DropDownList1.Items.Add(item);
            this.DropDownList1.Items.Add(item2);
            this.DropDownList1.Items.Add(item3);
            this.DropDownList1.Items.Add(item4);
        }

        private void InitializeComponent()
        {
            base.Load += new EventHandler(this.Page_Load);
        }

        protected override void OnInit(EventArgs e)
        {
            this.InitializeComponent();
            base.OnInit(e);
            if (!base.IsPostBack)
            {
                this.BindInfo();
            }
        }

        private void Page_Load(object sender, EventArgs e)
        {
        }

        public string SelectedValue
        {
            get
            {
                return this.DropDownList1.SelectedValue;
            }
            set
            {
                for (int i = 0; i < this.DropDownList1.Items.Count; i++)
                {
                    if (this.DropDownList1.Items[i].Value == value)
                    {
                        this.DropDownList1.Items[i].Selected = true;
                        break;
                    }
                }
            }
        }
    }
}

