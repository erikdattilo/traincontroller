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
      this.statusStrip1 = new System.Windows.Forms.StatusStrip();
      this.m_splitter = new System.Windows.Forms.SplitContainer();
      this.m_top = new System.Windows.Forms.TabControl();
      this.tabLayout = new System.Windows.Forms.TabPage();
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
      this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
      this.pictureBox1 = new MyCanvas();
      this.m_splitter.Panel1.SuspendLayout();
      this.m_splitter.Panel2.SuspendLayout();
      this.m_splitter.SuspendLayout();
      this.m_top.SuspendLayout();
      this.tabLayout.SuspendLayout();
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
      this.statusStrip1.Size = new System.Drawing.Size(292, 22);
      this.statusStrip1.TabIndex = 1;
      this.statusStrip1.Text = "statusStrip1";
      // 
      // m_splitter
      // 
      this.m_splitter.Dock = System.Windows.Forms.DockStyle.Fill;
      this.m_splitter.Location = new System.Drawing.Point(0, 24);
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
      this.m_splitter.Size = new System.Drawing.Size(292, 220);
      this.m_splitter.SplitterDistance = 97;
      this.m_splitter.TabIndex = 2;
      // 
      // m_top
      // 
      this.m_top.Controls.Add(this.tabLayout);
      this.m_top.Controls.Add(this.tabWelcome);
      this.m_top.Location = new System.Drawing.Point(28, 4);
      this.m_top.Name = "m_top";
      this.m_top.SelectedIndex = 0;
      this.m_top.Size = new System.Drawing.Size(200, 100);
      this.m_top.TabIndex = 0;
      // 
      // tabLayout
      // 
      this.tabLayout.Controls.Add(this.pictureBox1);
      this.tabLayout.Location = new System.Drawing.Point(4, 22);
      this.tabLayout.Name = "tabLayout";
      this.tabLayout.Padding = new System.Windows.Forms.Padding(3);
      this.tabLayout.Size = new System.Drawing.Size(192, 74);
      this.tabLayout.TabIndex = 0;
      this.tabLayout.Text = "Layout";
      this.tabLayout.UseVisualStyleBackColor = true;
      // 
      // tabWelcome
      // 
      this.tabWelcome.Location = new System.Drawing.Point(4, 22);
      this.tabWelcome.Name = "tabWelcome";
      this.tabWelcome.Padding = new System.Windows.Forms.Padding(3);
      this.tabWelcome.Size = new System.Drawing.Size(192, 74);
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
      this.splitContainer2.Size = new System.Drawing.Size(292, 119);
      this.splitContainer2.SplitterDistance = 97;
      this.splitContainer2.TabIndex = 0;
      // 
      // tabControl1
      // 
      this.tabControl1.Controls.Add(this.tabSchedule);
      this.tabControl1.Location = new System.Drawing.Point(47, 38);
      this.tabControl1.Name = "tabControl1";
      this.tabControl1.SelectedIndex = 0;
      this.tabControl1.Size = new System.Drawing.Size(200, 100);
      this.tabControl1.TabIndex = 0;
      // 
      // tabSchedule
      // 
      this.tabSchedule.Location = new System.Drawing.Point(4, 22);
      this.tabSchedule.Name = "tabSchedule";
      this.tabSchedule.Padding = new System.Windows.Forms.Padding(3);
      this.tabSchedule.Size = new System.Drawing.Size(192, 74);
      this.tabSchedule.TabIndex = 0;
      this.tabSchedule.Text = "Schedule";
      this.tabSchedule.UseVisualStyleBackColor = true;
      // 
      // tabControl2
      // 
      this.tabControl2.Controls.Add(this.tabAlerts);
      this.tabControl2.Controls.Add(this.tabTrainInfo);
      this.tabControl2.Location = new System.Drawing.Point(-21, 38);
      this.tabControl2.Name = "tabControl2";
      this.tabControl2.SelectedIndex = 0;
      this.tabControl2.Size = new System.Drawing.Size(200, 100);
      this.tabControl2.TabIndex = 0;
      // 
      // tabAlerts
      // 
      this.tabAlerts.Location = new System.Drawing.Point(4, 22);
      this.tabAlerts.Name = "tabAlerts";
      this.tabAlerts.Padding = new System.Windows.Forms.Padding(3);
      this.tabAlerts.Size = new System.Drawing.Size(192, 74);
      this.tabAlerts.TabIndex = 0;
      this.tabAlerts.Text = "Alerts";
      this.tabAlerts.UseVisualStyleBackColor = true;
      // 
      // tabTrainInfo
      // 
      this.tabTrainInfo.Location = new System.Drawing.Point(4, 22);
      this.tabTrainInfo.Name = "tabTrainInfo";
      this.tabTrainInfo.Padding = new System.Windows.Forms.Padding(3);
      this.tabTrainInfo.Size = new System.Drawing.Size(192, 74);
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
      this.menuStrip1.Size = new System.Drawing.Size(292, 24);
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
      this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
      this.viewToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
      this.viewToolStripMenuItem.Text = "View";
      // 
      // helpToolStripMenuItem
      // 
      this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
      this.helpToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
      this.helpToolStripMenuItem.Text = "Help";
      // 
      // pictureBox1
      // 
      this.pictureBox1.Location = new System.Drawing.Point(0, 0);
      this.pictureBox1.Name = "pictureBox1";
      this.pictureBox1.Size = new System.Drawing.Size(100, 50);
      this.pictureBox1.TabIndex = 0;
      this.pictureBox1.TabStop = false;
      // 
      // MainFrame
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(292, 266);
      this.Controls.Add(this.m_splitter);
      this.Controls.Add(this.statusStrip1);
      this.Controls.Add(this.menuStrip1);
      this.MainMenuStrip = this.menuStrip1;
      this.Name = "MainFrame";
      this.Text = "MainFrame";
      this.m_splitter.Panel1.ResumeLayout(false);
      this.m_splitter.Panel2.ResumeLayout(false);
      this.m_splitter.ResumeLayout(false);
      this.m_top.ResumeLayout(false);
      this.tabLayout.ResumeLayout(false);
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
    //private System.Windows.Forms.MenuStrip menuStrip1;
    //private System.Windows.Forms.ToolStripMenuItem dsaToolStripMenuItem1;
    //private System.Windows.Forms.ToolStripMenuItem qweToolStripMenuItem2;
    //private System.Windows.Forms.ToolStripMenuItem dasToolStripMenuItem;
    //private System.Windows.Forms.ToolStripMenuItem cxzToolStripMenuItem1;
    //private System.Windows.Forms.ToolStripMenuItem dfqeToolStripMenuItem;


  }
}