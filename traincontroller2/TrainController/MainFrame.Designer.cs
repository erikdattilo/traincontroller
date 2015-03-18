using TrainController.CustomControls;
namespace TrainController {
  partial class MainFrame {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if(disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainFrame));
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.toolStrip1 = new System.Windows.Forms.ToolStrip();
      this.m_clock = new System.Windows.Forms.ToolStripLabel();
      this.m_speed = new System.Windows.Forms.ToolStripTextBox();
      this.m_speedArrows = new ToolStripNumericUpDown();
      this.m_running = new System.Windows.Forms.ToolStripButton();
      this.m_statusText = new System.Windows.Forms.ToolStripLabel();
      this.m_alertText = new System.Windows.Forms.ToolStripLabel();
      this.m_splitter = new System.Windows.Forms.SplitContainer();
      this.m_top = new System.Windows.Forms.TabControl();
      this.tabLayout = new System.Windows.Forms.TabPage();
      this.pictureBox1 = new TrainController.MyCanvas();
      this.tabWelcome = new System.Windows.Forms.TabPage();
      this.splitContainer2 = new System.Windows.Forms.SplitContainer();
      this.tabControl1 = new System.Windows.Forms.TabControl();
      this.tabSchedule = new System.Windows.Forms.TabPage();
      this.tabControl2 = new System.Windows.Forms.TabControl();
      this.tabAlerts = new System.Windows.Forms.TabPage();
      this.tabTrainInfo = new System.Windows.Forms.TabPage();
      this.menuStrip1 = new System.Windows.Forms.MenuStrip();
      this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.coordBarsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.toolStrip1.SuspendLayout();
      this.m_splitter.Panel1.SuspendLayout();
      this.m_splitter.Panel2.SuspendLayout();
      this.m_splitter.SuspendLayout();
      this.m_top.SuspendLayout();
      this.tabLayout.SuspendLayout();
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
      this.splitContainer2.Panel1.SuspendLayout();
      this.splitContainer2.Panel2.SuspendLayout();
      this.splitContainer2.SuspendLayout();
      this.tabControl1.SuspendLayout();
      this.tabControl2.SuspendLayout();
      this.menuStrip1.SuspendLayout();
      this.SuspendLayout();
      // 
      // statusStrip1
      // 
      this.statusStrip1.Location = new System.Drawing.Point(0, 244);
      this.statusStrip1.Name = "statusStrip1";
      this.statusStrip1.Size = new System.Drawing.Size(454, 22);
      this.statusStrip1.TabIndex = 1;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // toolStrip1
      // 
      this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.m_clock,
            this.m_speed,
            this.m_speedArrows,
            this.m_running,
            this.m_statusText,
            this.m_alertText});
      this.toolStrip1.Location = new System.Drawing.Point(0, 24);
      this.toolStrip1.Name = "toolStrip1";
      this.toolStrip1.Size = new System.Drawing.Size(454, 25);
      this.toolStrip1.TabIndex = 1;
      this.toolStrip1.Text = "toolStrip1";
      // 
      // m_clock
      // 
      this.m_clock.Name = "m_clock";
      this.m_clock.Size = new System.Drawing.Size(78, 22);
      this.m_clock.Text = "toolStripLabel1";
      // 
      // m_speed
      // 
      this.m_speed.Name = "m_speed";
      this.m_speed.Size = new System.Drawing.Size(100, 25);
      // 
      // m_speedArrows
      // 
      this.m_speedArrows.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_speedArrows.Image = ((System.Drawing.Image)(resources.GetObject("m_speedArrows.Image")));
      this.m_speedArrows.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_speedArrows.Name = "m_speedArrows";
      this.m_speedArrows.Size = new System.Drawing.Size(23, 22);
      this.m_speedArrows.Text = "toolStripButton1";
      // 
      // m_running
      // 
      this.m_running.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
      this.m_running.Image = ((System.Drawing.Image)(resources.GetObject("m_running.Image")));
      this.m_running.ImageTransparentColor = System.Drawing.Color.Magenta;
      this.m_running.Name = "m_running";
      this.m_running.Size = new System.Drawing.Size(23, 22);
      this.m_running.Text = "toolStripButton1";
      // 
      // m_statusText
      // 
      this.m_statusText.Name = "m_statusText";
      this.m_statusText.Size = new System.Drawing.Size(78, 22);
      this.m_statusText.Text = "toolStripLabel1";
      // 
      // m_alertText
      // 
      this.m_alertText.Name = "m_alertText";
      this.m_alertText.Size = new System.Drawing.Size(78, 22);
      this.m_alertText.Text = "toolStripLabel1";
      // 
      // m_splitter
      // 
      this.m_splitter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_splitter.Location = new System.Drawing.Point(0, 49);
      this.m_splitter.Name = "m_splitter";
      this.m_splitter.Orientation = System.Windows.Forms.Orientation.Horizontal;
      // 
      // m_splitter.Panel1
      // 
      this.m_splitter.Panel1.Controls.Add(this.m_top);
      // 
      // m_splitter.Panel2
      // 
      this.m_splitter.Panel2.Controls.Add(this.splitContainer2);
      this.m_splitter.Size = new System.Drawing.Size(454, 195);
      this.m_splitter.SplitterDistance = 84;
      this.m_splitter.TabIndex = 2;
      // 
      // m_top
      // 
      this.m_top.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.m_top.Controls.Add(this.tabLayout);
      this.m_top.Controls.Add(this.tabWelcome);
      this.m_top.Location = new System.Drawing.Point(0, 0);
      this.m_top.Name = "m_top";
      this.m_top.SelectedIndex = 0;
      this.m_top.Size = new System.Drawing.Size(454, 71);
      this.m_top.TabIndex = 0;
      // 
      // tabLayout
      // 
      this.tabLayout.AutoScroll = true;
      this.tabLayout.Controls.Add(this.pictureBox1);
      this.tabLayout.Location = new System.Drawing.Point(4, 22);
      this.tabLayout.Name = "tabLayout";
      this.tabLayout.Padding = new System.Windows.Forms.Padding(3);
      this.tabLayout.Size = new System.Drawing.Size(446, 45);
      this.tabLayout.TabIndex = 0;
      this.tabLayout.Text = "Layout";
      this.tabLayout.UseVisualStyleBackColor = true;
      // 
      // pictureBox1
      // 
      this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(86, 40);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // tabWelcome
      // 
      this.tabWelcome.Location = new System.Drawing.Point(4, 22);
      this.tabWelcome.Name = "tabWelcome";
      this.tabWelcome.Padding = new System.Windows.Forms.Padding(3);
      this.tabWelcome.Size = new System.Drawing.Size(446, 45);
      this.tabWelcome.TabIndex = 1;
      this.tabWelcome.Text = "Welcome";
      this.tabWelcome.UseVisualStyleBackColor = true;
      // 
      // splitContainer2
      // 
      this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
      this.splitContainer2.Location = new System.Drawing.Point(0, 0);
      this.splitContainer2.Name = "splitContainer2";
      // 
      // splitContainer2.Panel1
      // 
      this.splitContainer2.Panel1.Controls.Add(this.tabControl1);
      // 
      // splitContainer2.Panel2
      // 
      this.splitContainer2.Panel2.Controls.Add(this.tabControl2);
      this.splitContainer2.Size = new System.Drawing.Size(454, 107);
      this.splitContainer2.SplitterDistance = 150;
      this.splitContainer2.TabIndex = 0;
      // 
      // tabControl1
      // 
      this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl1.Controls.Add(this.tabSchedule);
      this.tabControl1.Location = new System.Drawing.Point(0, 0);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(147, 114);
      this.tabControl1.TabIndex = 0;
      // 
      // tabSchedule
      // 
      this.tabSchedule.Location = new System.Drawing.Point(4, 22);
      this.tabSchedule.Name = "tabSchedule";
      this.tabSchedule.Padding = new System.Windows.Forms.Padding(3);
      this.tabSchedule.Size = new System.Drawing.Size(139, 88);
      this.tabSchedule.TabIndex = 0;
      this.tabSchedule.Text = "Schedule";
      this.tabSchedule.UseVisualStyleBackColor = true;
      // 
      // tabControl2
      // 
      this.tabControl2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                  | System.Windows.Forms.AnchorStyles.Left)
                  | System.Windows.Forms.AnchorStyles.Right)));
      this.tabControl2.Controls.Add(this.tabAlerts);
      this.tabControl2.Controls.Add(this.tabTrainInfo);
      this.tabControl2.Location = new System.Drawing.Point(-1, 0);
      this.tabControl2.Name = "tabControl2";
      this.tabControl2.SelectedIndex = 0;
      this.tabControl2.Size = new System.Drawing.Size(298, 114);
      this.tabControl2.TabIndex = 0;
      // 
      // tabAlerts
      // 
      this.tabAlerts.Location = new System.Drawing.Point(4, 22);
      this.tabAlerts.Name = "tabAlerts";
      this.tabAlerts.Padding = new System.Windows.Forms.Padding(3);
      this.tabAlerts.Size = new System.Drawing.Size(290, 88);
      this.tabAlerts.TabIndex = 0;
      this.tabAlerts.Text = "Alerts";
      this.tabAlerts.UseVisualStyleBackColor = true;
      // 
      // tabTrainInfo
      // 
      this.tabTrainInfo.Location = new System.Drawing.Point(4, 22);
      this.tabTrainInfo.Name = "tabTrainInfo";
      this.tabTrainInfo.Padding = new System.Windows.Forms.Padding(3);
      this.tabTrainInfo.Size = new System.Drawing.Size(290, 88);
      this.tabTrainInfo.TabIndex = 1;
      this.tabTrainInfo.Text = "Train Info";
      this.tabTrainInfo.UseVisualStyleBackColor = true;
      // 
      // menuStrip1
      // 
      this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.runToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.helpToolStripMenuItem});
      this.menuStrip1.Location = new System.Drawing.Point(0, 0);
      this.menuStrip1.Name = "menuStrip1";
      this.menuStrip1.Size = new System.Drawing.Size(454, 24);
      this.menuStrip1.TabIndex = 3;
      this.menuStrip1.Text = "menuStrip1";
      // 
      // fileToolStripMenuItem
      // 
      this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
      this.fileToolStripMenuItem.Size = new System.Drawing.Size(35, 20);
      this.fileToolStripMenuItem.Text = "File";
      // 
      // editToolStripMenuItem
      // 
      this.editToolStripMenuItem.Name = "editToolStripMenuItem";
      this.editToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
      this.editToolStripMenuItem.Text = "Edit";
      // 
      // runToolStripMenuItem
      // 
      this.runToolStripMenuItem.Name = "runToolStripMenuItem";
      this.runToolStripMenuItem.Size = new System.Drawing.Size(38, 20);
      this.runToolStripMenuItem.Text = "Run";
      // 
      // viewToolStripMenuItem
      // 
      this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.coordBarsToolStripMenuItem});
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
      this.viewToolStripMenuItem.Text = "View";
      // 
      // coordBarsToolStripMenuItem
      // 
      this.coordBarsToolStripMenuItem.CheckOnClick = true;
      this.coordBarsToolStripMenuItem.Name = "coordBarsToolStripMenuItem";
      this.coordBarsToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
      this.coordBarsToolStripMenuItem.Text = "Coord bars";
      this.coordBarsToolStripMenuItem.Click += new System.EventHandler(this.OnShowCoord_Click);
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
      this.helpToolStripMenuItem.Text = "Help";
      // 
      // MainFrame
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(454, 266);
      this.Controls.Add(this.m_splitter);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.toolStrip1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainFrame";
      this.Text = "MainFrame";
      this.toolStrip1.ResumeLayout(false);
      this.toolStrip1.PerformLayout();
      this.m_splitter.Panel1.ResumeLayout(false);
      this.m_splitter.Panel2.ResumeLayout(false);
      this.m_splitter.ResumeLayout(false);
      this.m_top.ResumeLayout(false);
      this.tabLayout.ResumeLayout(false);
      ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
      this.splitContainer2.Panel1.ResumeLayout(false);
      this.splitContainer2.Panel2.ResumeLayout(false);
      this.splitContainer2.ResumeLayout(false);
      this.tabControl1.ResumeLayout(false);
      this.tabControl2.ResumeLayout(false);
      this.menuStrip1.ResumeLayout(false);
      this.menuStrip1.PerformLayout();
      this.ResumeLayout(false);
      this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.StatusStrip statusStrip1;
    private System.Windows.Forms.ToolStrip toolStrip1;
    private System.Windows.Forms.SplitContainer m_splitter;
    private System.Windows.Forms.SplitContainer splitContainer2;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
    private System.Windows.Forms.TabControl m_top;
    private System.Windows.Forms.TabPage tabLayout;
    private System.Windows.Forms.TabPage tabWelcome;
    private System.Windows.Forms.TabControl tabControl1;
    private System.Windows.Forms.TabPage tabSchedule;
    private System.Windows.Forms.TabControl tabControl2;
    private System.Windows.Forms.TabPage tabAlerts;
    private System.Windows.Forms.TabPage tabTrainInfo;
    private MyCanvas pictureBox1;
    private System.Windows.Forms.ToolStripMenuItem coordBarsToolStripMenuItem;
    public System.Windows.Forms.ToolStripLabel m_clock;
    public System.Windows.Forms.ToolStripTextBox m_speed;
    public ToolStripNumericUpDown m_speedArrows;
    private System.Windows.Forms.ToolStripButton m_running;
    public System.Windows.Forms.ToolStripLabel m_statusText;
    public System.Windows.Forms.ToolStripLabel m_alertText;
    //private System.Windows.Forms.MenuStrip menuStrip1;
    //private System.Windows.Forms.ToolStripMenuItem dsaToolStripMenuItem1;
    //private System.Windows.Forms.ToolStripMenuItem qweToolStripMenuItem2;
    //private System.Windows.Forms.ToolStripMenuItem dasToolStripMenuItem;
    //private System.Windows.Forms.ToolStripMenuItem cxzToolStripMenuItem1;
    //private System.Windows.Forms.ToolStripMenuItem dfqeToolStripMenuItem;


  }
}