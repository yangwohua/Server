namespace 安居服务器1._0
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lb_Client = new System.Windows.Forms.ListBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pbimg2 = new System.Windows.Forms.PictureBox();
            this.pbimg1 = new System.Windows.Forms.PictureBox();
            this.pbimg0 = new System.Windows.Forms.PictureBox();
            this.lb_ClientData = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ip_tb = new System.Windows.Forms.ComboBox();
            this.lstMsg = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.start_bt = new System.Windows.Forms.Button();
            this.dk_tb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.clearToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tool_time = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbimg2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbimg1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbimg0)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lb_Client);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(666, 661);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Client";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lb_Client
            // 
            this.lb_Client.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_Client.FormattingEnabled = true;
            this.lb_Client.ItemHeight = 19;
            this.lb_Client.Location = new System.Drawing.Point(12, 30);
            this.lb_Client.Name = "lb_Client";
            this.lb_Client.Size = new System.Drawing.Size(640, 175);
            this.lb_Client.TabIndex = 4;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox4);
            this.groupBox3.Controls.Add(this.lb_ClientData);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox3.Location = new System.Drawing.Point(3, 208);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(660, 450);
            this.groupBox3.TabIndex = 3;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "DataClient";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.pbimg2);
            this.groupBox4.Controls.Add(this.pbimg1);
            this.groupBox4.Controls.Add(this.pbimg0);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox4.Location = new System.Drawing.Point(3, 211);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(654, 236);
            this.groupBox4.TabIndex = 6;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "IMG";
            // 
            // pbimg2
            // 
            this.pbimg2.Location = new System.Drawing.Point(466, 30);
            this.pbimg2.Name = "pbimg2";
            this.pbimg2.Size = new System.Drawing.Size(180, 180);
            this.pbimg2.TabIndex = 2;
            this.pbimg2.TabStop = false;
            // 
            // pbimg1
            // 
            this.pbimg1.Location = new System.Drawing.Point(245, 30);
            this.pbimg1.Name = "pbimg1";
            this.pbimg1.Size = new System.Drawing.Size(180, 180);
            this.pbimg1.TabIndex = 1;
            this.pbimg1.TabStop = false;
            // 
            // pbimg0
            // 
            this.pbimg0.Location = new System.Drawing.Point(12, 30);
            this.pbimg0.Name = "pbimg0";
            this.pbimg0.Size = new System.Drawing.Size(180, 180);
            this.pbimg0.TabIndex = 0;
            this.pbimg0.TabStop = false;
            // 
            // lb_ClientData
            // 
            this.lb_ClientData.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lb_ClientData.FormattingEnabled = true;
            this.lb_ClientData.ItemHeight = 19;
            this.lb_ClientData.Location = new System.Drawing.Point(12, 30);
            this.lb_ClientData.Name = "lb_ClientData";
            this.lb_ClientData.Size = new System.Drawing.Size(637, 175);
            this.lb_ClientData.TabIndex = 5;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ip_tb);
            this.groupBox2.Controls.Add(this.lstMsg);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.start_bt);
            this.groupBox2.Controls.Add(this.dk_tb);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.menuStrip1);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Bold);
            this.groupBox2.Location = new System.Drawing.Point(666, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupBox2.Size = new System.Drawing.Size(518, 661);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Message";
            // 
            // ip_tb
            // 
            this.ip_tb.Location = new System.Drawing.Point(136, 488);
            this.ip_tb.Name = "ip_tb";
            this.ip_tb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.ip_tb.Size = new System.Drawing.Size(186, 29);
            this.ip_tb.TabIndex = 20;
            this.ip_tb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ip_tb_KeyPress);
            // 
            // lstMsg
            // 
            this.lstMsg.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstMsg.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lstMsg.FormattingEnabled = true;
            this.lstMsg.HorizontalScrollbar = true;
            this.lstMsg.ItemHeight = 19;
            this.lstMsg.Location = new System.Drawing.Point(3, 27);
            this.lstMsg.Name = "lstMsg";
            this.lstMsg.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lstMsg.Size = new System.Drawing.Size(512, 441);
            this.lstMsg.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 21);
            this.label2.TabIndex = 18;
            this.label2.Text = "label2";
            // 
            // start_bt
            // 
            this.start_bt.Font = new System.Drawing.Font("宋体", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.start_bt.Location = new System.Drawing.Point(385, 488);
            this.start_bt.Name = "start_bt";
            this.start_bt.Size = new System.Drawing.Size(106, 72);
            this.start_bt.TabIndex = 5;
            this.start_bt.Text = "启 动";
            this.start_bt.UseVisualStyleBackColor = true;
            this.start_bt.Click += new System.EventHandler(this.button1_Click);
            // 
            // dk_tb
            // 
            this.dk_tb.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.dk_tb.Location = new System.Drawing.Point(136, 532);
            this.dk_tb.MaxLength = 4;
            this.dk_tb.Multiline = true;
            this.dk_tb.Name = "dk_tb";
            this.dk_tb.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.dk_tb.Size = new System.Drawing.Size(186, 28);
            this.dk_tb.TabIndex = 16;
            this.dk_tb.Text = "8104";
            this.dk_tb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label3.Location = new System.Drawing.Point(24, 532);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label3.Size = new System.Drawing.Size(54, 21);
            this.label3.TabIndex = 3;
            this.label3.Text = "PORT";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(24, 488);
            this.label1.Name = "label1";
            this.label1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.label1.Size = new System.Drawing.Size(109, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "IPaddress";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clearToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(3, 633);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(512, 25);
            this.menuStrip1.TabIndex = 19;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // clearToolStripMenuItem
            // 
            this.clearToolStripMenuItem.Name = "clearToolStripMenuItem";
            this.clearToolStripMenuItem.Size = new System.Drawing.Size(48, 21);
            this.clearToolStripMenuItem.Text = "clear";
            this.clearToolStripMenuItem.Click += new System.EventHandler(this.clearToolStripMenuItem_Click);
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.ContextMenuStrip = this.contextMenuStrip1;
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "点我不要钱";
            this.notifyIcon1.Visible = true;
            this.notifyIcon1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon1_MouseDoubleClick);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(105, 48);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem2.Text = "显 示";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(104, 22);
            this.toolStripMenuItem3.Text = "退 出";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // tool_time
            // 
            this.tool_time.Interval = 2;
            this.tool_time.Tick += new System.EventHandler(this.tool_time_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1184, 661);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1200, 700);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1000, 700);
            this.Name = "Form1";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "服务器";
            this.MinimumSizeChanged += new System.EventHandler(this.Form1_MinimumSizeChanged);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Leave += new System.EventHandler(this.Form1_Leave);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pbimg2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbimg1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbimg0)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox dk_tb;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button start_bt;
        private System.Windows.Forms.ListBox lstMsg;
        private System.Windows.Forms.ListBox lb_Client;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
    
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Timer tool_time;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem clearToolStripMenuItem;
        private System.Windows.Forms.ComboBox ip_tb;
        private System.Windows.Forms.ListBox lb_ClientData;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.PictureBox pbimg2;
        private System.Windows.Forms.PictureBox pbimg1;
        private System.Windows.Forms.PictureBox pbimg0;
    }
}

