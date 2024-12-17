namespace MINIFRAME
{
    partial class FormLogin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            this.btn_Login = new System.Windows.Forms.Button();
            this.btn_Preference = new System.Windows.Forms.LinkLabel();
            this.obj_txt_Username = new System.Windows.Forms.TextBox();
            this.obj_txt_Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.obj_chk_Remember = new System.Windows.Forms.CheckBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_Login
            // 
            this.btn_Login.Location = new System.Drawing.Point(199, 116);
            this.btn_Login.Name = "btn_Login";
            this.btn_Login.Size = new System.Drawing.Size(75, 23);
            this.btn_Login.TabIndex = 4;
            this.btn_Login.Text = "Login";
            this.btn_Login.UseVisualStyleBackColor = true;
            this.btn_Login.Click += new System.EventHandler(this.btn_Login_Click);
            // 
            // btn_Preference
            // 
            this.btn_Preference.AutoSize = true;
            this.btn_Preference.Location = new System.Drawing.Point(296, 121);
            this.btn_Preference.Name = "btn_Preference";
            this.btn_Preference.Size = new System.Drawing.Size(59, 13);
            this.btn_Preference.TabIndex = 5;
            this.btn_Preference.TabStop = true;
            this.btn_Preference.Text = "Preference";
            this.btn_Preference.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.btn_Preference_LinkClicked);
            // 
            // obj_txt_Username
            // 
            this.obj_txt_Username.Location = new System.Drawing.Point(199, 25);
            this.obj_txt_Username.MaxLength = 30;
            this.obj_txt_Username.Name = "obj_txt_Username";
            this.obj_txt_Username.Size = new System.Drawing.Size(156, 20);
            this.obj_txt_Username.TabIndex = 1;
            // 
            // obj_txt_Password
            // 
            this.obj_txt_Password.Location = new System.Drawing.Point(199, 51);
            this.obj_txt_Password.MaxLength = 30;
            this.obj_txt_Password.Name = "obj_txt_Password";
            this.obj_txt_Password.PasswordChar = '*';
            this.obj_txt_Password.Size = new System.Drawing.Size(156, 20);
            this.obj_txt_Password.TabIndex = 3;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(138, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Username";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(140, 54);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Password";
            // 
            // obj_chk_Remember
            // 
            this.obj_chk_Remember.AutoSize = true;
            this.obj_chk_Remember.Location = new System.Drawing.Point(199, 77);
            this.obj_chk_Remember.Name = "obj_chk_Remember";
            this.obj_chk_Remember.Size = new System.Drawing.Size(118, 17);
            this.obj_chk_Remember.TabIndex = 6;
            this.obj_chk_Remember.Text = "Remember my login";
            this.obj_chk_Remember.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 28);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(93, 94);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 7;
            this.pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(395, 196);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.obj_chk_Remember);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.obj_txt_Password);
            this.Controls.Add(this.obj_txt_Username);
            this.Controls.Add(this.btn_Preference);
            this.Controls.Add(this.btn_Login);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormLogin";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Login";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Login;
        private System.Windows.Forms.LinkLabel btn_Preference;
        private System.Windows.Forms.TextBox obj_txt_Username;
        private System.Windows.Forms.TextBox obj_txt_Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.CheckBox obj_chk_Remember;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}