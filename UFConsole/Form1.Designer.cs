namespace UFConsole
{
    partial class Form1
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.app_sidebar = new System.Windows.Forms.Panel();
            this.btnEditDesign = new System.Windows.Forms.Button();
            this.cblivePreview = new System.Windows.Forms.CheckBox();
            this.lblVersion = new System.Windows.Forms.Label();
            this.btnGitHub = new System.Windows.Forms.PictureBox();
            this.sidebarTransition = new System.Windows.Forms.Timer(this.components);
            this.txtUserInput = new System.Windows.Forms.TextBox();
            this.txtConsole = new System.Windows.Forms.RichTextBox();
            this.colorDialog = new System.Windows.Forms.ColorDialog();
            this.LiveThemeUpdater = new System.Windows.Forms.Timer(this.components);
            this.app_menubar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).BeginInit();
            this.app_sidebar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGitHub)).BeginInit();
            this.SuspendLayout();
            // 
            // app_menubar
            // 
            this.app_menubar.Size = new System.Drawing.Size(814, 42);
            // 
            // app_title
            // 
            this.app_title.BackColor = System.Drawing.Color.Transparent;
            this.app_title.Size = new System.Drawing.Size(110, 28);
            this.app_title.Text = "UFConsole";
            // 
            // btnSettings
            // 
            this.btnSettings.BackColor = System.Drawing.Color.Transparent;
            this.btnSettings.Click += new System.EventHandler(this.btnSettings_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(769, 2);
            // 
            // app_sidebar
            // 
            this.app_sidebar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.app_sidebar.Controls.Add(this.btnEditDesign);
            this.app_sidebar.Controls.Add(this.cblivePreview);
            this.app_sidebar.Controls.Add(this.lblVersion);
            this.app_sidebar.Controls.Add(this.btnGitHub);
            this.app_sidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.app_sidebar.Location = new System.Drawing.Point(0, 42);
            this.app_sidebar.Name = "app_sidebar";
            this.app_sidebar.Size = new System.Drawing.Size(300, 436);
            this.app_sidebar.TabIndex = 2;
            // 
            // btnEditDesign
            // 
            this.btnEditDesign.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnEditDesign.Location = new System.Drawing.Point(195, 368);
            this.btnEditDesign.Name = "btnEditDesign";
            this.btnEditDesign.Size = new System.Drawing.Size(99, 36);
            this.btnEditDesign.TabIndex = 6;
            this.btnEditDesign.Text = "Edit Design";
            this.btnEditDesign.UseVisualStyleBackColor = true;
            this.btnEditDesign.Click += new System.EventHandler(this.btnEditDesign_Click);
            // 
            // cblivePreview
            // 
            this.cblivePreview.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.cblivePreview.AutoSize = true;
            this.cblivePreview.Location = new System.Drawing.Point(195, 410);
            this.cblivePreview.Name = "cblivePreview";
            this.cblivePreview.Size = new System.Drawing.Size(101, 21);
            this.cblivePreview.TabIndex = 5;
            this.cblivePreview.Text = "Live preview";
            this.cblivePreview.UseVisualStyleBackColor = true;
            this.cblivePreview.CheckedChanged += new System.EventHandler(this.cblivePreview_CheckedChanged);
            // 
            // lblVersion
            // 
            this.lblVersion.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblVersion.AutoSize = true;
            this.lblVersion.Location = new System.Drawing.Point(3, 414);
            this.lblVersion.Name = "lblVersion";
            this.lblVersion.Size = new System.Drawing.Size(50, 17);
            this.lblVersion.TabIndex = 1;
            this.lblVersion.Text = "V. 1.0.4";
            // 
            // btnGitHub
            // 
            this.btnGitHub.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnGitHub.Image = ((System.Drawing.Image)(resources.GetObject("btnGitHub.Image")));
            this.btnGitHub.Location = new System.Drawing.Point(0, 377);
            this.btnGitHub.Name = "btnGitHub";
            this.btnGitHub.Size = new System.Drawing.Size(39, 34);
            this.btnGitHub.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.btnGitHub.TabIndex = 0;
            this.btnGitHub.TabStop = false;
            this.btnGitHub.Click += new System.EventHandler(this.btnGitHub_Click);
            // 
            // sidebarTransition
            // 
            this.sidebarTransition.Interval = 10;
            this.sidebarTransition.Tick += new System.EventHandler(this.sidebarTransition_Tick);
            // 
            // txtUserInput
            // 
            this.txtUserInput.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(70)))), ((int)(((byte)(70)))), ((int)(((byte)(100)))));
            this.txtUserInput.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtUserInput.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.txtUserInput.Font = new System.Drawing.Font("Segoe UI", 11F);
            this.txtUserInput.ForeColor = System.Drawing.Color.LightGray;
            this.txtUserInput.Location = new System.Drawing.Point(300, 453);
            this.txtUserInput.Name = "txtUserInput";
            this.txtUserInput.Size = new System.Drawing.Size(514, 25);
            this.txtUserInput.TabIndex = 4;
            this.txtUserInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtUserInput_KeyDown);
            // 
            // txtConsole
            // 
            this.txtConsole.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.txtConsole.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConsole.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtConsole.Font = new System.Drawing.Font("Segoe UI Semibold", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConsole.ForeColor = System.Drawing.Color.LightGray;
            this.txtConsole.Location = new System.Drawing.Point(300, 42);
            this.txtConsole.Name = "txtConsole";
            this.txtConsole.ReadOnly = true;
            this.txtConsole.Size = new System.Drawing.Size(514, 411);
            this.txtConsole.TabIndex = 5;
            this.txtConsole.Text = "";
            this.txtConsole.TextChanged += new System.EventHandler(this.txtConsole_TextChanged);
            // 
            // colorDialog
            // 
            this.colorDialog.FullOpen = true;
            // 
            // LiveThemeUpdater
            // 
            this.LiveThemeUpdater.Interval = 1000;
            this.LiveThemeUpdater.Tick += new System.EventHandler(this.LiveThemeUpdater_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(814, 478);
            this.Controls.Add(this.txtConsole);
            this.Controls.Add(this.txtUserInput);
            this.Controls.Add(this.app_sidebar);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "UFConsole";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(50)))), ((int)(((byte)(50)))), ((int)(((byte)(100)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Controls.SetChildIndex(this.app_menubar, 0);
            this.Controls.SetChildIndex(this.app_sidebar, 0);
            this.Controls.SetChildIndex(this.txtUserInput, 0);
            this.Controls.SetChildIndex(this.txtConsole, 0);
            this.app_menubar.ResumeLayout(false);
            this.app_menubar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnSettings)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnClose)).EndInit();
            this.app_sidebar.ResumeLayout(false);
            this.app_sidebar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnGitHub)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel app_sidebar;
        private System.Windows.Forms.Timer sidebarTransition;
        private System.Windows.Forms.TextBox txtUserInput;
        private System.Windows.Forms.RichTextBox txtConsole;
        private System.Windows.Forms.PictureBox btnGitHub;
        private System.Windows.Forms.Label lblVersion;
        private System.Windows.Forms.ColorDialog colorDialog;
        private System.Windows.Forms.Timer LiveThemeUpdater;
        private System.Windows.Forms.CheckBox cblivePreview;
        private System.Windows.Forms.Button btnEditDesign;
    }
}

