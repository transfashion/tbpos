using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace MINIFRAME
{
    public partial class FormLogin : Form
    {
        public event EventHandler PreferenceSet;


        public FormLogin()
        {
            InitializeComponent();

            this.obj_txt_Username.Text = Preference.LoginUsername;
            if (Preference.LoginRemember)
            {
                this.obj_txt_Password.Text = Preference.LoginPassword;
                this.obj_chk_Remember.Checked = true;
            }

            this.obj_txt_Username.Focus();
            this.obj_txt_Username.SelectionStart = this.obj_txt_Username.Text.Length;
            this.obj_txt_Username.SelectionLength = 0;

        }



        private void btn_Login_Click(object sender, EventArgs e)
        {
            //SqlConnection conn = Preference.get
            try
            {
                Log.WriteLine("Authenticating...");
                if (!User.Authenticate(this.obj_txt_Username.Text, this.obj_txt_Password.Text))
                    throw new User.NotFoundException("Access Denied.");

                Preference.LoginUsername = User.UserId;
                Preference.LoginRemember = this.obj_chk_Remember.Checked;
                if (Preference.LoginRemember)
                {
                    Preference.setLoginPassword(this.obj_txt_Password.Text);
                }
                else
                {
                    Preference.ClearLoginPassword();
                }
                Preference.Write();


                this.DialogResult = DialogResult.Yes;
                this.Close();
            }
            catch (User.NotFoundException ex)
            {
                MessageBox.Show("Login Fail.\r\nYou don't have access to this system.\r\n" + ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.WriteLine("Login Fail.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Login Error\r\n" + ex.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Log.WriteLine("Login Error");
                Log.WriteLine(ex.StackTrace);
            }


        }

        private void btn_Preference_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormPreference frmpref = new FormPreference();
            DialogResult res = frmpref.ShowDialog();
            if (res == DialogResult.Yes)
            {
                if (this.PreferenceSet != null)
                    this.PreferenceSet(this, EventArgs.Empty);
            }

            this.obj_txt_Username.Focus();

        }
    }
}