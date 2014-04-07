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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SimulatorForm));
            this.statusStrip = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelIC = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelID = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelSp = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelRL = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripStatusLabelTotal = new System.Windows.Forms.ToolStripStatusLabel();
            this.toolStripMain = new System.Windows.Forms.ToolStrip();
            this.toolStripTextBoxSpawnInterval = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripComboBoxCom = new System.Windows.Forms.ToolStripComboBox();
            this.intersectionControl6 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl5 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl4 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl3 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl2 = new TrafficSimulatorUi.IntersectionControl();
            this.intersectionControl1 = new TrafficSimulatorUi.IntersectionControl();
            this.toolStripButtonSpawn = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton6 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton4 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton3 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton5 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonMS = new System.Windows.Forms.ToolStripButton();
            this.toolStripButtonArduino = new System.Windows.Forms.ToolStripButton();
            this.statusStrip.SuspendLayout();
            this.toolStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // statusStrip
            // 
            this.statusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabelIC,
            this.toolStripStatusLabelID,
            this.toolStripStatusLabelSp,
            this.toolStripStatusLabelRL,
            this.toolStripStatusLabelTotal});
            this.statusStrip.Location = new System.Drawing.Point(0, 822);
            this.statusStrip.Name = "statusStrip";
            this.statusStrip.RenderMode = System.Windows.Forms.ToolStripRenderMode.ManagerRenderMode;
            this.statusStrip.Size = new System.Drawing.Size(1200, 24);
            this.statusStrip.SizingGrip = false;
            this.statusStrip.TabIndex = 0;
            this.statusStrip.Text = "statusStrip1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(1068, 19);
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
            this.toolStripStatusLabelSp.Size = new System.Drawing.Size(24, 19);
            this.toolStripStatusLabelSp.Text = "Sp";
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
            // toolStripMain
            // 
            this.toolStripMain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripButtonSpawn,
            this.toolStripTextBoxSpawnInterval,
            this.toolStripButton1,
            this.toolStripButton2,
            this.toolStripButton6,
            this.toolStripButton4,
            this.toolStripButton3,
            this.toolStripButton5,
            this.toolStripSeparator1,
            this.toolStripButtonMS,
            this.toolStripSeparator2,
            this.toolStripButtonArduino,
            this.toolStripComboBoxCom});
            this.toolStripMain.Location = new System.Drawing.Point(0, 0);
            this.toolStripMain.Name = "toolStripMain";
            this.toolStripMain.Size = new System.Drawing.Size(1200, 25);
            this.toolStripMain.TabIndex = 1;
            this.toolStripMain.Text = "Toolstrip";
            // 
            // toolStripTextBoxSpawnInterval
            // 
            this.toolStripTextBoxSpawnInterval.Enabled = false;
            this.toolStripTextBoxSpawnInterval.Name = "toolStripTextBoxSpawnInterval";
            this.toolStripTextBoxSpawnInterval.Size = new System.Drawing.Size(50, 25);
            this.toolStripTextBoxSpawnInterval.Text = "100";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripComboBoxCom
            // 
            this.toolStripComboBoxCom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBoxCom.Name = "toolStripComboBoxCom";
            this.toolStripComboBoxCom.Size = new System.Drawing.Size(121, 25);
            // 
            // intersectionControl6
            // 
            this.intersectionControl6.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_RAILWAY;
            this.intersectionControl6.Location = new System.Drawing.Point(800, 22);
            this.intersectionControl6.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl6.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl6.Name = "intersectionControl6";
            this.intersectionControl6.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl6.TabIndex = 7;
            // 
            // intersectionControl5
            // 
            this.intersectionControl5.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_4;
            this.intersectionControl5.Location = new System.Drawing.Point(800, 422);
            this.intersectionControl5.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl5.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl5.Name = "intersectionControl5";
            this.intersectionControl5.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl5.TabIndex = 6;
            // 
            // intersectionControl4
            // 
            this.intersectionControl4.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_3;
            this.intersectionControl4.Location = new System.Drawing.Point(0, 422);
            this.intersectionControl4.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl4.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl4.Name = "intersectionControl4";
            this.intersectionControl4.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl4.TabIndex = 5;
            // 
            // intersectionControl3
            // 
            this.intersectionControl3.Location = new System.Drawing.Point(400, 422);
            this.intersectionControl3.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl3.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl3.Name = "intersectionControl3";
            this.intersectionControl3.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl3.TabIndex = 4;
            // 
            // intersectionControl2
            // 
            this.intersectionControl2.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_5;
            this.intersectionControl2.Location = new System.Drawing.Point(400, 22);
            this.intersectionControl2.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl2.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl2.Name = "intersectionControl2";
            this.intersectionControl2.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl2.TabIndex = 3;
            // 
            // intersectionControl1
            // 
            this.intersectionControl1.IntersectionType = TrafficSimulatorUi.IntersectionType.TYPE_2;
            this.intersectionControl1.Location = new System.Drawing.Point(0, 22);
            this.intersectionControl1.MaximumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl1.MinimumSize = new System.Drawing.Size(400, 400);
            this.intersectionControl1.Name = "intersectionControl1";
            this.intersectionControl1.Size = new System.Drawing.Size(400, 400);
            this.intersectionControl1.TabIndex = 2;
            // 
            // toolStripButtonSpawn
            // 
            this.toolStripButtonSpawn.Checked = true;
            this.toolStripButtonSpawn.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripButtonSpawn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonSpawn.Image = global::TrafficSimulator.Properties.Resources.Car_Add;
            this.toolStripButtonSpawn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonSpawn.Name = "toolStripButtonSpawn";
            this.toolStripButtonSpawn.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonSpawn.Text = "Spawn weggebruikers";
            this.toolStripButtonSpawn.Click += new System.EventHandler(this.spawnerToggle);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "1";
            this.toolStripButton1.Click += new System.EventHandler(this.clearIntersectionButtonClick);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "2";
            this.toolStripButton2.Click += new System.EventHandler(this.clearIntersectionButtonClick);
            // 
            // toolStripButton6
            // 
            this.toolStripButton6.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton6.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton6.Image")));
            this.toolStripButton6.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton6.Name = "toolStripButton6";
            this.toolStripButton6.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton6.Text = "3";
            this.toolStripButton6.Click += new System.EventHandler(this.clearIntersectionButtonClick);
            // 
            // toolStripButton4
            // 
            this.toolStripButton4.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton4.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton4.Image")));
            this.toolStripButton4.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton4.Name = "toolStripButton4";
            this.toolStripButton4.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton4.Text = "4";
            this.toolStripButton4.Click += new System.EventHandler(this.clearIntersectionButtonClick);
            // 
            // toolStripButton3
            // 
            this.toolStripButton3.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton3.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton3.Image")));
            this.toolStripButton3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton3.Name = "toolStripButton3";
            this.toolStripButton3.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton3.Text = "5";
            this.toolStripButton3.Click += new System.EventHandler(this.clearIntersectionButtonClick);
            // 
            // toolStripButton5
            // 
            this.toolStripButton5.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.toolStripButton5.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton5.Image")));
            this.toolStripButton5.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton5.Name = "toolStripButton5";
            this.toolStripButton5.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton5.Text = "6";
            this.toolStripButton5.Click += new System.EventHandler(this.clearIntersectionButtonClick);
            // 
            // toolStripButtonMS
            // 
            this.toolStripButtonMS.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonMS.Image = global::TrafficSimulator.Properties.Resources.Transmit_Blue;
            this.toolStripButtonMS.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonMS.Name = "toolStripButtonMS";
            this.toolStripButtonMS.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonMS.Text = "Berichten server";
            this.toolStripButtonMS.Click += new System.EventHandler(this.messageServerToggle);
            // 
            // toolStripButtonArduino
            // 
            this.toolStripButtonArduino.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonArduino.Image = global::TrafficSimulator.Properties.Resources.Connect;
            this.toolStripButtonArduino.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonArduino.Name = "toolStripButtonArduino";
            this.toolStripButtonArduino.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonArduino.Text = "Arduino";
            this.toolStripButtonArduino.Click += new System.EventHandler(this.arduinoToggle);
            // 
            // SimulatorForm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1200, 846);
            this.Controls.Add(this.toolStripMain);
            this.Controls.Add(this.intersectionControl6);
            this.Controls.Add(this.intersectionControl5);
            this.Controls.Add(this.intersectionControl4);
            this.Controls.Add(this.intersectionControl3);
            this.Controls.Add(this.intersectionControl2);
            this.Controls.Add(this.intersectionControl1);
            this.Controls.Add(this.statusStrip);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "SimulatorForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Traffic Simulator";
            this.statusStrip.ResumeLayout(false);
            this.statusStrip.PerformLayout();
            this.toolStripMain.ResumeLayout(false);
            this.toolStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.StatusStrip statusStrip;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelIC;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelID;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelSp;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelRL;
        private System.Windows.Forms.ToolStrip toolStripMain;
        private System.Windows.Forms.ToolStripButton toolStripButtonSpawn;
        private System.Windows.Forms.ToolStripTextBox toolStripTextBoxSpawnInterval;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripButton toolStripButton3;
        private System.Windows.Forms.ToolStripButton toolStripButton4;
        private System.Windows.Forms.ToolStripButton toolStripButton5;
        private System.Windows.Forms.ToolStripButton toolStripButton6;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton toolStripButtonMS;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton toolStripButtonArduino;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBoxCom;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabelTotal;
        private TrafficSimulatorUi.IntersectionControl intersectionControl1;
        private TrafficSimulatorUi.IntersectionControl intersectionControl2;
        private TrafficSimulatorUi.IntersectionControl intersectionControl3;
        private TrafficSimulatorUi.IntersectionControl intersectionControl4;
        private TrafficSimulatorUi.IntersectionControl intersectionControl5;
        private TrafficSimulatorUi.IntersectionControl intersectionControl6;




    }
}
