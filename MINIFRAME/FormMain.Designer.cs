namespace MINIFRAME
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.obj_Status = new System.Windows.Forms.StatusStrip();
            this.obj_Status_Username = new System.Windows.Forms.ToolStripStatusLabel();
            this.obj_Status_Database = new System.Windows.Forms.ToolStripStatusLabel();
            this.obj_Status_Webservice = new System.Windows.Forms.ToolStripStatusLabel();
            this.obj_Status_Message = new System.Windows.Forms.ToolStripStatusLabel();
            this.obj_Status_Progress = new System.Windows.Forms.ToolStripProgressBar();
            this.pnl_Main = new System.Windows.Forms.Panel();
            this.obj_Status.SuspendLayout();
            this.SuspendLayout();
            // 
            // obj_Status
            // 
            this.obj_Status.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.obj_Status_Username,
            this.obj_Status_Database,
            this.obj_Status_Webservice,
            this.obj_Status_Message,
            this.obj_Status_Progress});
            this.obj_Status.Location = new System.Drawing.Point(0, 350);
            this.obj_Status.Name = "obj_Status";
            this.obj_Status.Size = new System.Drawing.Size(648, 22);
            this.obj_Status.TabIndex = 0;
            this.obj_Status.Text = "statusStrip1";
            // 
            // obj_Status_Username
            // 
            this.obj_Status_Username.Name = "obj_Status_Username";
            this.obj_Status_Username.Size = new System.Drawing.Size(60, 17);
            this.obj_Status_Username.Text = "Username";
            // 
            // obj_Status_Database
            // 
            this.obj_Status_Database.Name = "obj_Status_Database";
            this.obj_Status_Database.Size = new System.Drawing.Size(55, 17);
            this.obj_Status_Database.Text = "Database";
            // 
            // obj_Status_Webservice
            // 
            this.obj_Status_Webservice.Name = "obj_Status_Webservice";
            this.obj_Status_Webservice.Size = new System.Drawing.Size(67, 17);
            this.obj_Status_Webservice.Text = "Webservice";
            this.obj_Status_Webservice.Visible = false;
            // 
            // obj_Status_Message
            // 
            this.obj_Status_Message.Name = "obj_Status_Message";
            this.obj_Status_Message.Size = new System.Drawing.Size(416, 17);
            this.obj_Status_Message.Spring = true;
            this.obj_Status_Message.Text = "Message";
            this.obj_Status_Message.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // obj_Status_Progress
            // 
            this.obj_Status_Progress.Name = "obj_Status_Progress";
            this.obj_Status_Progress.Size = new System.Drawing.Size(100, 16);
            // 
            // pnl_Main
            // 
            this.pnl_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnl_Main.Location = new System.Drawing.Point(0, 0);
            this.pnl_Main.Name = "pnl_Main";
            this.pnl_Main.Size = new System.Drawing.Size(648, 350);
            this.pnl_Main.TabIndex = 1;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(648, 372);
            this.Controls.Add(this.pnl_Main);
            this.Controls.Add(this.obj_Status);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMain";
            this.Text = "POS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.obj_Status.ResumeLayout(false);
            this.obj_Status.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip obj_Status;
        private System.Windows.Forms.ToolStripStatusLabel obj_Status_Username;
        private System.Windows.Forms.ToolStripStatusLabel obj_Status_Database;
        private System.Windows.Forms.ToolStripStatusLabel obj_Status_Message;
        private System.Windows.Forms.ToolStripProgressBar obj_Status_Progress;
        private System.Windows.Forms.ToolStripStatusLabel obj_Status_Webservice;
        private System.Windows.Forms.Panel pnl_Main;
    }
}

