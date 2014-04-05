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
            this.progressTimer = new System.Windows.Forms.Timer(this.components);
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.labelStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.intersectionControl6 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl5 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl4 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl3 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl1 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl2 = new TrafficSimulatorUi.IntersectionControl();
            this.toolStripArduino = new System.Windows.Forms.ToolStrip();
            this.toolStripComboBoxComPorts = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButtonArduino = new System.Windows.Forms.ToolStripButton();
            this.toolStripMessages = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonMS = new System.Windows.Forms.ToolStripButton();
            this.toolStripStats = new System.Windows.Forms.ToolStrip();
            this.toolStripButtonStats = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1.SuspendLayout();
            this.toolStripContainer1.BottomToolStripPanel.SuspendLayout();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.TopToolStripPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.toolStripArduino.SuspendLayout();
            this.toolStripMessages.SuspendLayout();
            this.toolStripStats.SuspendLayout();
            this.SuspendLayout();
            // 
            // progressTimer
            // 
            this.progressTimer.Interval = 40;
            this.progressTimer.Tick += new System.EventHandler(this.progressTimer_Tick);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Dock = System.Windows.Forms.DockStyle.None;
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.labelStatus});
            this.statusStrip1.Location = new System.Drawing.Point(0, 0);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip1.Size = new System.Drawing.Size(1203, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // labelStatus
            // 
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(44, 17);
            this.labelStatus.Text = "Gereed";
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
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(1203, 805);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(1203, 852);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // toolStripContainer1.TopToolStripPanel
            // 
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripMessages);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripArduino);
            this.toolStripContainer1.TopToolStripPanel.Controls.Add(this.toolStripStats);
            // 
            // intersectionControl6
            // 
            this.intersectionControl6.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_RAILWAY;
            this.intersectionControl6.Location = new System.Drawing.Point(800, 3);
            this.intersectionControl6.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl6.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl6.Name = "intersectionControl6";
            this.intersectionControl6.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl6.TabIndex = 11;
            // 
            // intersectionControl5
            // 
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
            this.intersectionControl3.Location = new System.Drawing.Point(403, 403);
            this.intersectionControl3.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl3.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl3.Name = "intersectionControl3";
            this.intersectionControl3.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl3.TabIndex = 8;
            // 
            // intersectionControl1
            // 
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
            this.intersectionControl2.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_5;
            this.intersectionControl2.Location = new System.Drawing.Point(403, 3);
            this.intersectionControl2.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl2.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl2.Name = "intersectionControl2";
            this.intersectionControl2.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl2.TabIndex = 6;
            // 
            // toolStripArduino
            // 
            this.toolStripArduino.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripArduino.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripComboBoxComPorts,
            this.toolStripButtonArduino});
            this.toolStripArduino.Location = new System.Drawing.Point(110, 0);
            this.toolStripArduino.Name = "toolStripArduino";
            this.toolStripArduino.Size = new System.Drawing.Size(200, 25);
            this.toolStripArduino.TabIndex = 1;
            // 
            // toolStripComboBoxComPorts
            // 
            this.toolStripComboBoxComPorts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxComPorts.Name = "toolStripComboBoxComPorts";
            this.toolStripComboBoxComPorts.Size = new System.Drawing.Size(121, 25);
            // 
            // toolStripButtonArduino
            // 
            this.toolStripButtonArduino.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonArduino.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonArduino.Image")));
            this.toolStripButtonArduino.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArduino.Name = "toolStripButtonArduino";
            this.toolStripButtonArduino.Size = new System.Drawing.Size(65, 22);
            this.toolStripButtonArduino.Text = "Verbinden";
            this.toolStripButtonArduino.Click += new System.EventHandler(this.connectButtonClick);
            // 
            // toolStripMessages
            // 
            this.toolStripMessages.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripMessages.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonMS});
            this.toolStripMessages.Location = new System.Drawing.Point(3, 0);
            this.toolStripMessages.Name = "toolStripMessages";
            this.toolStripMessages.Size = new System.Drawing.Size(107, 25);
            this.toolStripMessages.TabIndex = 2;
            // 
            // toolStripButtonMS
            // 
            this.toolStripButtonMS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonMS.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonMS.Image")));
            this.toolStripButtonMS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMS.Name = "toolStripButtonMS";
            this.toolStripButtonMS.Size = new System.Drawing.Size(95, 22);
            this.toolStripButtonMS.Text = "Berichten server";
            this.toolStripButtonMS.Click += new System.EventHandler(this.messageServerButtonClick);
            // 
            // toolStripStats
            // 
            this.toolStripStats.Dock = System.Windows.Forms.DockStyle.None;
            this.toolStripStats.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonStats});
            this.toolStripStats.Location = new System.Drawing.Point(311, 0);
            this.toolStripStats.Name = "toolStripStats";
            this.toolStripStats.Size = new System.Drawing.Size(83, 25);
            this.toolStripStats.TabIndex = 3;
            // 
            // toolStripButtonStats
            // 
            this.toolStripButtonStats.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButtonStats.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonStats.Image")));
            this.toolStripButtonStats.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonStats.Name = "toolStripButtonStats";
            this.toolStripButtonStats.Size = new System.Drawing.Size(71, 22);
            this.toolStripButtonStats.Text = "Statistieken";
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
            this.MinimumSize = new System.Drawing.Size(1211, 890);
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
            this.toolStripArduino.ResumeLayout(false);
            this.toolStripArduino.PerformLayout();
            this.toolStripMessages.ResumeLayout(false);
            this.toolStripMessages.PerformLayout();
            this.toolStripStats.ResumeLayout(false);
            this.toolStripStats.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer progressTimer;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel labelStatus;
        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private TrafficSimulatorUi.IntersectionControl intersectionControl6;
        private TrafficSimulatorUi.IntersectionControl intersectionControl5;
        private TrafficSimulatorUi.IntersectionControl intersectionControl4;
        private TrafficSimulatorUi.IntersectionControl intersectionControl3;
        private TrafficSimulatorUi.IntersectionControl intersectionControl1;
        private TrafficSimulatorUi.IntersectionControl intersectionControl2;
        private System.Windows.Forms.ToolStrip toolStripArduino;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxComPorts;
        private System.Windows.Forms.ToolStripButton toolStripButtonArduino;
        private System.Windows.Forms.ToolStrip toolStripMessages;
        private System.Windows.Forms.ToolStripButton toolStripButtonMS;
        private System.Windows.Forms.ToolStrip toolStripStats;
        private System.Windows.Forms.ToolStripButton toolStripButtonStats;



    }
}
