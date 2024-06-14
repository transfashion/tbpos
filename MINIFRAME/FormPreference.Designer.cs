namespace MINIFRAME
{
    partial class FormPreference
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.obj_tab_Preference = new System.Windows.Forms.TabControl();
            this.obj_tabpage_Database = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.obj_txt_DbPassword = new System.Windows.Forms.TextBox();
            this.obj_txt_DbRole = new System.Windows.Forms.TextBox();
            this.obj_txt_DbUsername = new System.Windows.Forms.TextBox();
            this.obj_txt_DbCatalog = new System.Windows.Forms.TextBox();
            this.obj_txt_DbServer = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label6 = new System.Windows.Forms.Label();
            this.obj_txt_CentralServerAddress = new System.Windows.Forms.TextBox();
            this.obj_tab_Preference.SuspendLayout();
            this.obj_tabpage_Database.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.SuspendLayout();
            // 
            // obj_tab_Preference
            // 
            this.obj_tab_Preference.Controls.Add(this.obj_tabpage_Database);
            this.obj_tab_Preference.Controls.Add(this.tabPage1);
            this.obj_tab_Preference.Dock = System.Windows.Forms.DockStyle.Fill;
            this.obj_tab_Preference.Location = new System.Drawing.Point(5, 5);
            this.obj_tab_Preference.Name = "obj_tab_Preference";
            this.obj_tab_Preference.SelectedIndex = 0;
            this.obj_tab_Preference.Size = new System.Drawing.Size(690, 342);
            this.obj_tab_Preference.TabIndex = 0;
            // 
            // obj_tabpage_Database
            // 
            this.obj_tabpage_Database.Controls.Add(this.label5);
            this.obj_tabpage_Database.Controls.Add(this.label4);
            this.obj_tabpage_Database.Controls.Add(this.label3);
            this.obj_tabpage_Database.Controls.Add(this.label2);
            this.obj_tabpage_Database.Controls.Add(this.label1);
            this.obj_tabpage_Database.Controls.Add(this.obj_txt_DbPassword);
            this.obj_tabpage_Database.Controls.Add(this.obj_txt_DbRole);
            this.obj_tabpage_Database.Controls.Add(this.obj_txt_DbUsername);
            this.obj_tabpage_Database.Controls.Add(this.obj_txt_DbCatalog);
            this.obj_tabpage_Database.Controls.Add(this.obj_txt_DbServer);
            this.obj_tabpage_Database.Location = new System.Drawing.Point(4, 22);
            this.obj_tabpage_Database.Name = "obj_tabpage_Database";
            this.obj_tabpage_Database.Padding = new System.Windows.Forms.Padding(3);
            this.obj_tabpage_Database.Size = new System.Drawing.Size(682, 316);
            this.obj_tabpage_Database.TabIndex = 0;
            this.obj_tabpage_Database.Text = "Database";
            this.obj_tabpage_Database.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(289, 82);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(29, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Role";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(73, 108);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Password";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(71, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(55, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(83, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Catalog";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(88, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Server";
            // 
            // obj_txt_DbPassword
            // 
            this.obj_txt_DbPassword.Location = new System.Drawing.Point(132, 105);
            this.obj_txt_DbPassword.MaxLength = 30;
            this.obj_txt_DbPassword.Name = "obj_txt_DbPassword";
            this.obj_txt_DbPassword.PasswordChar = '*';
            this.obj_txt_DbPassword.Size = new System.Drawing.Size(142, 20);
            this.obj_txt_DbPassword.TabIndex = 4;
            // 
            // obj_txt_DbRole
            // 
            this.obj_txt_DbRole.Location = new System.Drawing.Point(324, 79);
            this.obj_txt_DbRole.MaxLength = 30;
            this.obj_txt_DbRole.Name = "obj_txt_DbRole";
            this.obj_txt_DbRole.Size = new System.Drawing.Size(142, 20);
            this.obj_txt_DbRole.TabIndex = 3;
            // 
            // obj_txt_DbUsername
            // 
            this.obj_txt_DbUsername.Location = new System.Drawing.Point(132, 79);
            this.obj_txt_DbUsername.MaxLength = 30;
            this.obj_txt_DbUsername.Name = "obj_txt_DbUsername";
            this.obj_txt_DbUsername.Size = new System.Drawing.Size(142, 20);
            this.obj_txt_DbUsername.TabIndex = 2;
            // 
            // obj_txt_DbCatalog
            // 
            this.obj_txt_DbCatalog.Location = new System.Drawing.Point(132, 53);
            this.obj_txt_DbCatalog.MaxLength = 30;
            this.obj_txt_DbCatalog.Name = "obj_txt_DbCatalog";
            this.obj_txt_DbCatalog.Size = new System.Drawing.Size(334, 20);
            this.obj_txt_DbCatalog.TabIndex = 1;
            // 
            // obj_txt_DbServer
            // 
            this.obj_txt_DbServer.Location = new System.Drawing.Point(132, 27);
            this.obj_txt_DbServer.MaxLength = 30;
            this.obj_txt_DbServer.Name = "obj_txt_DbServer";
            this.obj_txt_DbServer.Size = new System.Drawing.Size(334, 20);
            this.obj_txt_DbServer.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btn_Ok);
            this.panel1.Controls.Add(this.btn_Cancel);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(5, 347);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(690, 68);
            this.panel1.TabIndex = 1;
            // 
            // btn_Ok
            // 
            this.btn_Ok.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Ok.Location = new System.Drawing.Point(595, 22);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 1;
            this.btn_Ok.Text = "OK";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btn_Cancel.Location = new System.Drawing.Point(514, 22);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 0;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.obj_txt_CentralServerAddress);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(682, 316);
            this.tabPage1.TabIndex = 1;
            this.tabPage1.Text = "Central Server";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(49, 36);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 7;
            this.label6.Text = "Address";
            // 
            // obj_txt_CentralServerAddress
            // 
            this.obj_txt_CentralServerAddress.Location = new System.Drawing.Point(100, 33);
            this.obj_txt_CentralServerAddress.MaxLength = 30;
            this.obj_txt_CentralServerAddress.Name = "obj_txt_CentralServerAddress";
            this.obj_txt_CentralServerAddress.Size = new System.Drawing.Size(334, 20);
            this.obj_txt_CentralServerAddress.TabIndex = 6;
            // 
            // FormPreference
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(700, 420);
            this.Controls.Add(this.obj_tab_Preference);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPreference";
            this.Padding = new System.Windows.Forms.Padding(5);
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Preference";
            this.obj_tab_Preference.ResumeLayout(false);
            this.obj_tabpage_Database.ResumeLayout(false);
            this.obj_tabpage_Database.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl obj_tab_Preference;
        private System.Windows.Forms.TabPage obj_tabpage_Database;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox obj_txt_DbPassword;
        private System.Windows.Forms.TextBox obj_txt_DbRole;
        private System.Windows.Forms.TextBox obj_txt_DbUsername;
        private System.Windows.Forms.TextBox obj_txt_DbCatalog;
        private System.Windows.Forms.TextBox obj_txt_DbServer;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox obj_txt_CentralServerAddress;
    }
}