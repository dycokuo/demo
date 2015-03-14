namespace DX80_Monitor
{
    partial class Form1
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbPrintName = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rtMessage = new System.Windows.Forms.RichTextBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnBackupBrowse = new System.Windows.Forms.Button();
            this.btnWatchBrowse = new System.Windows.Forms.Button();
            this.txtBackupPath = new System.Windows.Forms.TextBox();
            this.txtWatchPath = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDX80IP = new IPAddressControlLib.IPAddressControl();
            this.txtDX80PORT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.dlgOpenDir = new System.Windows.Forms.FolderBrowserDialog();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStrip_View = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip_Exit = new System.Windows.Forms.ToolStripMenuItem();
            this.label5 = new System.Windows.Forms.Label();
            this.ChkAutoRun = new System.Windows.Forms.CheckBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbPrintName);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnBackupBrowse);
            this.groupBox1.Controls.Add(this.btnWatchBrowse);
            this.groupBox1.Controls.Add(this.txtBackupPath);
            this.groupBox1.Controls.Add(this.txtWatchPath);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(20, 19);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(393, 392);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Setting";
            // 
            // cbPrintName
            // 
            this.cbPrintName.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.cbPrintName.FormattingEnabled = true;
            this.cbPrintName.Location = new System.Drawing.Point(98, 95);
            this.cbPrintName.Name = "cbPrintName";
            this.cbPrintName.Size = new System.Drawing.Size(202, 24);
            this.cbPrintName.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rtMessage);
            this.groupBox2.Location = new System.Drawing.Point(8, 125);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(373, 261);
            this.groupBox2.TabIndex = 5;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message";
            // 
            // rtMessage
            // 
            this.rtMessage.Location = new System.Drawing.Point(6, 18);
            this.rtMessage.Name = "rtMessage";
            this.rtMessage.Size = new System.Drawing.Size(361, 227);
            this.rtMessage.TabIndex = 7;
            this.rtMessage.Text = "";
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.MistyRose;
            this.btnSave.Location = new System.Drawing.Point(306, 76);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 43);
            this.btnSave.TabIndex = 6;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnBackupBrowse
            // 
            this.btnBackupBrowse.Location = new System.Drawing.Point(306, 49);
            this.btnBackupBrowse.Name = "btnBackupBrowse";
            this.btnBackupBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnBackupBrowse.TabIndex = 4;
            this.btnBackupBrowse.Text = "browse";
            this.btnBackupBrowse.UseVisualStyleBackColor = true;
            this.btnBackupBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // btnWatchBrowse
            // 
            this.btnWatchBrowse.Location = new System.Drawing.Point(306, 19);
            this.btnWatchBrowse.Name = "btnWatchBrowse";
            this.btnWatchBrowse.Size = new System.Drawing.Size(75, 23);
            this.btnWatchBrowse.TabIndex = 2;
            this.btnWatchBrowse.Text = "browse";
            this.btnWatchBrowse.UseVisualStyleBackColor = true;
            this.btnWatchBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtBackupPath
            // 
            this.txtBackupPath.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtBackupPath.Location = new System.Drawing.Point(98, 53);
            this.txtBackupPath.Name = "txtBackupPath";
            this.txtBackupPath.Size = new System.Drawing.Size(202, 27);
            this.txtBackupPath.TabIndex = 3;
            // 
            // txtWatchPath
            // 
            this.txtWatchPath.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtWatchPath.Location = new System.Drawing.Point(98, 18);
            this.txtWatchPath.Name = "txtWatchPath";
            this.txtWatchPath.Size = new System.Drawing.Size(202, 27);
            this.txtWatchPath.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 107);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(78, 12);
            this.label6.TabIndex = 0;
            this.label6.Text = "Printer Name：";

            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 12);
            this.label2.TabIndex = 0;
            this.label2.Text = "Backup Path：";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Watch Path：";
            // 
            // txtDX80IP
            // 
            this.txtDX80IP.AllowInternalTab = false;
            this.txtDX80IP.AutoHeight = true;
            this.txtDX80IP.BackColor = System.Drawing.SystemColors.Window;
            this.txtDX80IP.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.txtDX80IP.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtDX80IP.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDX80IP.Location = new System.Drawing.Point(118, 478);
            this.txtDX80IP.MinimumSize = new System.Drawing.Size(114, 27);
            this.txtDX80IP.Name = "txtDX80IP";
            this.txtDX80IP.ReadOnly = false;
            this.txtDX80IP.Size = new System.Drawing.Size(202, 27);
            this.txtDX80IP.TabIndex = 5;
            this.txtDX80IP.Text = "...";
            this.txtDX80IP.Visible = false;
            // 
            // txtDX80PORT
            // 
            this.txtDX80PORT.Font = new System.Drawing.Font("新細明體", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(136)));
            this.txtDX80PORT.Location = new System.Drawing.Point(118, 511);
            this.txtDX80PORT.Name = "txtDX80PORT";
            this.txtDX80PORT.Size = new System.Drawing.Size(202, 27);
            this.txtDX80PORT.TabIndex = 6;
            this.txtDX80PORT.Visible = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 526);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 12);
            this.label4.TabIndex = 0;
            this.label4.Text = "DX80 Port：";
            this.label4.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 493);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 12);
            this.label3.TabIndex = 0;
            this.label3.Text = "DX80 IP：";
            this.label3.Visible = false;
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "DX80 Monitor";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStrip_View,
            this.toolStrip_Exit});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(104, 48);
            // 
            // toolStrip_View
            // 
            this.toolStrip_View.Name = "toolStrip_View";
            this.toolStrip_View.Size = new System.Drawing.Size(103, 22);
            this.toolStrip_View.Text = "View";
            this.toolStrip_View.Click += new System.EventHandler(this.toolStrip_View_Click);
            // 
            // toolStrip_Exit
            // 
            this.toolStrip_Exit.Name = "toolStrip_Exit";
            this.toolStrip_Exit.Size = new System.Drawing.Size(103, 22);
            this.toolStrip_Exit.Text = "Exit";
            this.toolStrip_Exit.Click += new System.EventHandler(this.toolStrip_Exit_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(18, 414);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(157, 12);
            this.label5.TabIndex = 0;
            this.label5.Text = "Start At the Windows Start Up：";
            // 
            // ChkAutoRun
            // 
            this.ChkAutoRun.AutoSize = true;
            this.ChkAutoRun.Location = new System.Drawing.Point(182, 414);
            this.ChkAutoRun.Name = "ChkAutoRun";
            this.ChkAutoRun.Size = new System.Drawing.Size(41, 16);
            this.ChkAutoRun.TabIndex = 8;
            this.ChkAutoRun.Text = "Yes";
            this.ChkAutoRun.UseVisualStyleBackColor = true;
            this.ChkAutoRun.Click += new System.EventHandler(this.ChkAutoRun_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 436);
            this.Controls.Add(this.txtDX80IP);
            this.Controls.Add(this.ChkAutoRun);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtDX80PORT);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DX80_Monitor";
            this.WindowState = System.Windows.Forms.FormWindowState.Minimized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtBackupPath;
        private System.Windows.Forms.TextBox txtWatchPath;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.FolderBrowserDialog dlgOpenDir;
        private System.Windows.Forms.Button btnBackupBrowse;
        private System.Windows.Forms.Button btnWatchBrowse;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RichTextBox rtMessage;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtDX80PORT;
        private System.Windows.Forms.Label label4;
        private IPAddressControlLib.IPAddressControl txtDX80IP;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox ChkAutoRun;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_View;
        private System.Windows.Forms.ToolStripMenuItem toolStrip_Exit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbPrintName;
    }
}

