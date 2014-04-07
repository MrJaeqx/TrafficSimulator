namespace TrafficSimulator
{
    partial class SimulatorForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulatorForm));
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelIC = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelID = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSp = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRL = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.intersectionControl6 = new TrafficSimulatorUi.IntersectionControl();
            this.contextMenuStripIntersection = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemClearAll = new System.Windows.Forms.ToolStripMenuItem();
            this.intersectionControl5 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl4 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl3 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl1 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl2 = new TrafficSimulatorUi.IntersectionControl();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonSpawn = new System.Windows.Forms.ToolStripButton();
            this.toolStripTextBoxSpawnInterval = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonMS = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButtonArduino = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonSend = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBoxCom = new System.Windows.Forms.ToolStripComboBox();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.contextMenuStripIntersection.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus,
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelIC,
            this.toolStripStatusLabelID,
            this.toolStripStatusLabelSp,
            this.toolStripStatusLabelRL,
            this.toolStripStatusLabelTotal});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1203, 24);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(44, 19);
            this.labelStatus.Text = "Gereed";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1008, 19);
            this.toolStripStatusLabel1.Spring = true;
            // 
            // toolStripStatusLabelIC
            // 
            this.toolStripStatusLabelIC.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelIC.Name = "toolStripStatusLabelIC";
            this.toolStripStatusLabelIC.Size = new System.Drawing.Size(22, 19);
            this.toolStripStatusLabelIC.Text = "IC";
            // 
            // toolStripStatusLabelID
            // 
            this.toolStripStatusLabelID.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelID.Name = "toolStripStatusLabelID";
            this.toolStripStatusLabelID.Size = new System.Drawing.Size(22, 19);
            this.toolStripStatusLabelID.Text = "ID";
            // 
            // toolStripStatusLabelSp
            // 
            this.toolStripStatusLabelSp.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelSp.Name = "toolStripStatusLabelSp";
            this.toolStripStatusLabelSp.Size = new System.Drawing.Size(43, 19);
            this.toolStripStatusLabelSp.Text = "Speed";
            // 
            // toolStripStatusLabelRL
            // 
            this.toolStripStatusLabelRL.BorderSides = System.Windows.Forms.ToolStripStatusLabelBorderSides.Right;
            this.toolStripStatusLabelRL.Name = "toolStripStatusLabelRL";
            this.toolStripStatusLabelRL.Size = new System.Drawing.Size(24, 19);
            this.toolStripStatusLabelRL.Text = "RL";
            // 
            // toolStripStatusLabelTotal
            // 
            this.toolStripStatusLabelTotal.Name = "toolStripStatusLabelTotal";
            this.toolStripStatusLabelTotal.Size = new System.Drawing.Size(25, 19);
            this.toolStripStatusLabelTotal.Text = "Tot";
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.BottomToolStripPanel
            // 
            this.toolStripContainer1.BottomToolStripPanel.Controls.Add(this.statusStrip1);
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.intersectionControl6);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.intersectionControl5);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.intersectionControl4);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.intersectionControl3);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.intersectionControl1);
            this.toolStripContainer1.ContentPanel.Controls.Add(this.intersectionControl2);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1203, 803);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1203, 852);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripMain);
            // 
            // intersectionControl6
            // 
            this.intersectionControl6.ContextMenuStrip = this.contextMenuStripIntersection;
            this.intersectionControl6.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_RAILWAY;
            this.intersectionControl6.Location = new System.Drawing.Point(800, 3);
            this.intersectionControl6.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl6.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl6.Name = "intersectionControl6";
            this.intersectionControl6.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl6.TabIndex = 11;
            // 
            // contextMenuStripIntersection
            // 
            this.contextMenuStripIntersection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemClearAll});
            this.contextMenuStripIntersection.Name = "contextMenuStripIntersection";
            this.contextMenuStripIntersection.Size = new System.Drawing.Size(193, 26);
            this.contextMenuStripIntersection.Text = "Kruispunt";
            // 
            // toolStripMenuItemClearAll
            // 
            this.toolStripMenuItemClearAll.Name = "toolStripMenuItemClearAll";
            this.toolStripMenuItemClearAll.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItemClearAll.Text = "Alle kruispunten legen";
            this.toolStripMenuItemClearAll.Click += new System.EventHandler(this.toolStripMenuItemClearAll_Click);
            // 
            // intersectionControl5
            // 
            this.intersectionControl5.ContextMenuStrip = this.contextMenuStripIntersection;
            this.intersectionControl5.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_4;
            this.intersectionControl5.Location = new System.Drawing.Point(800, 403);
            this.intersectionControl5.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl5.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl5.Name = "intersectionControl5";
            this.intersectionControl5.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl5.TabIndex = 10;
            // 
            // intersectionControl4
            // 
            this.intersectionControl4.ContextMenuStrip = this.contextMenuStripIntersection;
            this.intersectionControl4.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_3;
            this.intersectionControl4.Location = new System.Drawing.Point(3, 403);
            this.intersectionControl4.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl4.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl4.Name = "intersectionControl4";
            this.intersectionControl4.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl4.TabIndex = 9;
            // 
            // intersectionControl3
            // 
            this.intersectionControl3.ContextMenuStrip = this.contextMenuStripIntersection;
            this.intersectionControl3.Location = new System.Drawing.Point(403, 403);
            this.intersectionControl3.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl3.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl3.Name = "intersectionControl3";
            this.intersectionControl3.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl3.TabIndex = 8;
            // 
            // intersectionControl1
            // 
            this.intersectionControl1.ContextMenuStrip = this.contextMenuStripIntersection;
            this.intersectionControl1.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_2;
            this.intersectionControl1.Location = new System.Drawing.Point(3, 3);
            this.intersectionControl1.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl1.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl1.Name = "intersectionControl1";
            this.intersectionControl1.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl1.TabIndex = 7;
            // 
            // intersectionControl2
            // 
            this.intersectionControl2.ContextMenuStrip = this.contextMenuStripIntersection;
            this.intersectionControl2.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_5;
            this.intersectionControl2.Location = new System.Drawing.Point(403, 3);
            this.intersectionControl2.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl2.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl2.Name = "intersectionControl2";
            this.intersectionControl2.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl2.TabIndex = 6;
            // 
            // toolStripMain
            // 
            this.toolStripMain.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSpawn,
            this.toolStripTextBoxSpawnInterval,
            this.toolStripSeparator1,
            this.toolStripButtonMS,
            this.toolStripSeparator2,
            this.toolStripButtonArduino,
            this.toolStripButtonSend,
            this.toolStripComboBoxCom});
            this.toolStripMain.Location = new System.Drawing.Point(3, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(235, 25);
            this.toolStripMain.TabIndex = 4;
            // 
            // toolStripButtonSpawn
            // 
            this.toolStripButtonSpawn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSpawn.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSpawn.Image")));
            this.toolStripButtonSpawn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSpawn.Name = "toolStripButtonSpawn";
            this.toolStripButtonSpawn.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSpawn.Text = "Spawn random";
            this.toolStripButtonSpawn.Click += new System.EventHandler(this.spawnerToggle);
            // 
            // toolStripTextBoxSpawnInterval
            // 
            this.toolStripTextBoxSpawnInterval.Name = "toolStripTextBoxSpawnInterval";
            this.toolStripTextBoxSpawnInterval.Size = new System.Drawing.Size(40, 25);
            this.toolStripTextBoxSpawnInterval.Text = "500";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonMS
            // 
            this.toolStripButtonMS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMS.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMS.Image")));
            this.toolStripButtonMS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMS.Name = "toolStripButtonMS";
            this.toolStripButtonMS.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonMS.Text = "Berichten server";
            this.toolStripButtonMS.Click += new System.EventHandler(this.messageServerToggle);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripButtonArduino
            // 
            this.toolStripButtonArduino.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonArduino.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonArduino.Image")));
            this.toolStripButtonArduino.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArduino.Name = "toolStripButtonArduino";
            this.toolStripButtonArduino.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonArduino.Text = "Arduino";
            this.toolStripButtonArduino.Click += new System.EventHandler(this.arduinoToggle);
            // 
            // toolStripButtonSend
            // 
            this.toolStripButtonSend.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSend.Enabled = false;
            this.toolStripButtonSend.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonSend.Image")));
            this.toolStripButtonSend.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSend.Name = "toolStripButtonSend";
            this.toolStripButtonSend.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSend.Text = "Schakel trein";
            // 
            // toolStripComboBoxCom
            // 
            this.toolStripComboBoxCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxCom.Name = "toolStripComboBoxCom";
            this.toolStripComboBoxCom.Size = new System.Drawing.Size(75, 25);
            // 
            // SimulatorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.ClientSize = new System.Drawing.Size(1203, 852);
            this.Controls.Add(this.toolStripContainer1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1219, 890);
            this.MinimumSize = new System.Drawing.Size(1211, 858);
            this.Name = "SimulatorForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Traffic Simulator";
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.toolStripContainer1.BottomToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.BottomToolStripPanel.PerformLayout();
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.ResumeLayout(false);
            this.toolStripContainer1.TopToolStripPanel.PerformLayout();
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.contextMenuStripIntersection.ResumeLayout(false);
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private TrafficSimulatorUi.IntersectionControl intersectionControl6;
        private TrafficSimulatorUi.IntersectionControl intersectionControl5;
        private TrafficSimulatorUi.IntersectionControl intersectionControl4;
        private TrafficSimulatorUi.IntersectionControl intersectionControl3;
        private TrafficSimulatorUi.IntersectionControl intersectionControl1;
        private TrafficSimulatorUi.IntersectionControl intersectionControl2;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelID;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSp;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRL;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelIC;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonSpawn;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSpawnInterval;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonMS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonArduino;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxCom;
        private System.Windows.Forms.ToolStripButton toolStripButtonSend;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripIntersection;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemClearAll;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTotal;



    }
}
