using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MINIFRAME
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
            this.InitPreferenceInfo();

            this.obj_Status_Username.Visible = false;
            this.obj_Status_Message.Visible = false;
            this.obj_Status_Progress.Visible = false;
        }


        public void InitPreferenceInfo()
        {
            this.obj_Status_Database.Text = Preference.DbCatalog + "@" + Preference.DbServer;
            this.obj_Status_Webservice.Text = Preference.CentralServerAddress;
        }

        public void InitUserInfo()
        {
            this.obj_Status_Username.Text = User.UserName;
            this.obj_Status_Username.Visible = true;
            this.obj_Status.Refresh();

        }

        public void InitUserControl(UserControl ui)
        {
            ui.Dock = DockStyle.Fill;
            this.pnl_Main.Controls.Add(ui);
        }
    }
}