using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace MINIFRAME
{
    public partial class FormPreference : Form
    {
        public FormPreference()
        {
            InitializeComponent();

            this.obj_txt_DbServer.Text = Preference.DbServer;
            this.obj_txt_DbCatalog.Text = Preference.DbCatalog;
            this.obj_txt_DbUsername.Text = Preference.DbUsername;
            this.obj_txt_DbRole.Text = Preference.DbRole;
            this.obj_txt_DbPassword.Text = Preference.DbPassword;

            this.obj_txt_CentralServerAddress.Text = Preference.CentralServerAddress;

        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            try
            {
                Preference.DbServer = this.obj_txt_DbServer.Text;
                Preference.DbCatalog = this.obj_txt_DbCatalog.Text;
                Preference.DbUsername = this.obj_txt_DbUsername.Text;
                Preference.DbRole = this.obj_txt_DbRole.Text;
                Preference.setDbPassword(this.obj_txt_DbPassword.Text);
                Preference.CentralServerAddress = this.obj_txt_CentralServerAddress.Text;

                Preference.Write();

                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Cannot Save Preference.\r\n" + ex.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}