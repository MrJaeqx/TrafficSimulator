namespace TrafficMessageReceiver
{
    partial class PoliceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PoliceForm));
            this.toolStripContainer1 = new System.Windows.Forms.ToolStripContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.listView1 = new System.Windows.Forms.ListView();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAccident = new System.Windows.Forms.Button();
            this.buttonRedlight = new System.Windows.Forms.Button();
            this.buttonSpeedings = new System.Windows.Forms.Button();
            this.buttonOverview = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.notifyIcon1 = new System.Windows.Forms.NotifyIcon(this.components);
            this.buttonRefresh = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonPrint = new System.Windows.Forms.Button();
            this.buttonSettings = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonRemoveAll = new System.Windows.Forms.Button();
            this.buttonRemove = new System.Windows.Forms.Button();
            this.toolStripContainer1.ContentPanel.SuspendLayout();
            this.toolStripContainer1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStripContainer1
            // 
            // 
            // toolStripContainer1.ContentPanel
            // 
            this.toolStripContainer1.ContentPanel.Controls.Add(this.tableLayoutPanel1);
            this.toolStripContainer1.ContentPanel.Size = new System.Drawing.Size(984, 661);
            this.toolStripContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.toolStripContainer1.Location = new System.Drawing.Point(0, 0);
            this.toolStripContainer1.Name = "toolStripContainer1";
            this.toolStripContainer1.Size = new System.Drawing.Size(984, 661);
            this.toolStripContainer1.TabIndex = 1;
            this.toolStripContainer1.Text = "toolStripContainer1";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 300F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.listView1, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(984, 661);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // listView1
            // 
            this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView1.Location = new System.Drawing.Point(303, 3);
            this.listView1.Name = "listView1";
            this.listView1.Size = new System.Drawing.Size(678, 655);
            this.listView1.TabIndex = 0;
            this.listView1.UseCompatibleStateImageBehavior = false;
            this.listView1.View = System.Windows.Forms.View.Details;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 1;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(3, 3);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(294, 655);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(288, 549);
            this.panel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(this.button1);
            this.panel3.Controls.Add(this.button2);
            this.panel3.Controls.Add(this.buttonRemoveAll);
            this.panel3.Controls.Add(this.buttonRemove);
            this.panel3.Controls.Add(this.buttonSettings);
            this.panel3.Controls.Add(this.buttonPrint);
            this.panel3.Controls.Add(this.buttonSave);
            this.panel3.Controls.Add(this.buttonRefresh);
            this.panel3.Location = new System.Drawing.Point(3, 191);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panel3.Size = new System.Drawing.Size(282, 156);
            this.panel3.TabIndex = 2;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.buttonAccident);
            this.panel2.Controls.Add(this.buttonRedlight);
            this.panel2.Controls.Add(this.buttonSpeedings);
            this.panel2.Controls.Add(this.buttonOverview);
            this.panel2.Location = new System.Drawing.Point(3, 46);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(0, 10, 0, 10);
            this.panel2.Size = new System.Drawing.Size(282, 139);
            this.panel2.TabIndex = 1;
            // 
            // buttonAccident
            // 
            this.buttonAccident.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonAccident.FlatAppearance.BorderSize = 0;
            this.buttonAccident.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonAccident.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonAccident.Location = new System.Drawing.Point(10, 100);
            this.buttonAccident.Name = "buttonAccident";
            this.buttonAccident.Size = new System.Drawing.Size(260, 23);
            this.buttonAccident.TabIndex = 3;
            this.buttonAccident.Text = "Ongevallen";
            this.buttonAccident.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAccident.UseVisualStyleBackColor = false;
            this.buttonAccident.Click += new System.EventHandler(this.toggleViewButtonEvent);
            // 
            // buttonRedlight
            // 
            this.buttonRedlight.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRedlight.FlatAppearance.BorderSize = 0;
            this.buttonRedlight.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRedlight.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonRedlight.Location = new System.Drawing.Point(10, 71);
            this.buttonRedlight.Name = "buttonRedlight";
            this.buttonRedlight.Size = new System.Drawing.Size(260, 23);
            this.buttonRedlight.TabIndex = 2;
            this.buttonRedlight.Text = "Rood licht overtredingen";
            this.buttonRedlight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonRedlight.UseVisualStyleBackColor = false;
            this.buttonRedlight.Click += new System.EventHandler(this.toggleViewButtonEvent);
            // 
            // buttonSpeedings
            // 
            this.buttonSpeedings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSpeedings.FlatAppearance.BorderSize = 0;
            this.buttonSpeedings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSpeedings.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSpeedings.Location = new System.Drawing.Point(10, 42);
            this.buttonSpeedings.Name = "buttonSpeedings";
            this.buttonSpeedings.Size = new System.Drawing.Size(260, 23);
            this.buttonSpeedings.TabIndex = 1;
            this.buttonSpeedings.Text = "Snelheidsovertredingen";
            this.buttonSpeedings.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSpeedings.UseVisualStyleBackColor = false;
            this.buttonSpeedings.Click += new System.EventHandler(this.toggleViewButtonEvent);
            // 
            // buttonOverview
            // 
            this.buttonOverview.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonOverview.FlatAppearance.BorderSize = 0;
            this.buttonOverview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonOverview.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonOverview.Location = new System.Drawing.Point(10, 13);
            this.buttonOverview.Name = "buttonOverview";
            this.buttonOverview.Size = new System.Drawing.Size(260, 23);
            this.buttonOverview.TabIndex = 0;
            this.buttonOverview.Text = "Overzicht";
            this.buttonOverview.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonOverview.UseVisualStyleBackColor = false;
            this.buttonOverview.Click += new System.EventHandler(this.toggleViewButtonEvent);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Politie UI";
            // 
            // notifyIcon1
            // 
            this.notifyIcon1.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon1.Icon")));
            this.notifyIcon1.Text = "notifyIcon1";
            this.notifyIcon1.Visible = true;
            // 
            // buttonRefresh
            // 
            this.buttonRefresh.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRefresh.FlatAppearance.BorderSize = 0;
            this.buttonRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRefresh.Image = global::TrafficMessageReceiver.Properties.Resources.reload;
            this.buttonRefresh.Location = new System.Drawing.Point(10, 13);
            this.buttonRefresh.Name = "buttonRefresh";
            this.buttonRefresh.Size = new System.Drawing.Size(60, 60);
            this.buttonRefresh.TabIndex = 0;
            this.buttonRefresh.UseVisualStyleBackColor = false;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Image = global::TrafficMessageReceiver.Properties.Resources.save;
            this.buttonSave.Location = new System.Drawing.Point(76, 13);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(60, 60);
            this.buttonSave.TabIndex = 1;
            this.buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonPrint
            // 
            this.buttonPrint.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonPrint.FlatAppearance.BorderSize = 0;
            this.buttonPrint.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonPrint.Image = global::TrafficMessageReceiver.Properties.Resources.print;
            this.buttonPrint.Location = new System.Drawing.Point(142, 13);
            this.buttonPrint.Name = "buttonPrint";
            this.buttonPrint.Size = new System.Drawing.Size(60, 60);
            this.buttonPrint.TabIndex = 2;
            this.buttonPrint.UseVisualStyleBackColor = false;
            // 
            // buttonSettings
            // 
            this.buttonSettings.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSettings.FlatAppearance.BorderSize = 0;
            this.buttonSettings.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSettings.Image = global::TrafficMessageReceiver.Properties.Resources.settings;
            this.buttonSettings.Location = new System.Drawing.Point(208, 13);
            this.buttonSettings.Name = "buttonSettings";
            this.buttonSettings.Size = new System.Drawing.Size(60, 60);
            this.buttonSettings.TabIndex = 3;
            this.buttonSettings.UseVisualStyleBackColor = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Location = new System.Drawing.Point(208, 79);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(60, 60);
            this.button1.TabIndex = 7;
            this.button1.UseVisualStyleBackColor = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.button2.FlatAppearance.BorderSize = 0;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Location = new System.Drawing.Point(142, 79);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(60, 60);
            this.button2.TabIndex = 6;
            this.button2.UseVisualStyleBackColor = false;
            // 
            // buttonRemoveAll
            // 
            this.buttonRemoveAll.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRemoveAll.FlatAppearance.BorderSize = 0;
            this.buttonRemoveAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemoveAll.Location = new System.Drawing.Point(76, 79);
            this.buttonRemoveAll.Name = "buttonRemoveAll";
            this.buttonRemoveAll.Size = new System.Drawing.Size(60, 60);
            this.buttonRemoveAll.TabIndex = 5;
            this.buttonRemoveAll.UseVisualStyleBackColor = false;
            // 
            // buttonRemove
            // 
            this.buttonRemove.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonRemove.FlatAppearance.BorderSize = 0;
            this.buttonRemove.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonRemove.Location = new System.Drawing.Point(10, 79);
            this.buttonRemove.Name = "buttonRemove";
            this.buttonRemove.Size = new System.Drawing.Size(60, 60);
            this.buttonRemove.TabIndex = 4;
            this.buttonRemove.UseVisualStyleBackColor = false;
            // 
            // PoliceForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(984, 661);
            this.Controls.Add(this.toolStripContainer1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PoliceForm";
            this.Text = "Politie Stoplicht Interface";
            this.toolStripContainer1.ContentPanel.ResumeLayout(false);
            this.toolStripContainer1.ResumeLayout(false);
            this.toolStripContainer1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ToolStripContainer toolStripContainer1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.ListView listView1;
        private System.Windows.Forms.NotifyIcon notifyIcon1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonOverview;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonAccident;
        private System.Windows.Forms.Button buttonRedlight;
        private System.Windows.Forms.Button buttonSpeedings;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonRemoveAll;
        private System.Windows.Forms.Button buttonRemove;
        private System.Windows.Forms.Button buttonSettings;
        private System.Windows.Forms.Button buttonPrint;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonRefresh;

    }
}

