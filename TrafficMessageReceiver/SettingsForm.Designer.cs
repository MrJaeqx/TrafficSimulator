namespace TrafficMessageReceiver
{
    partial class SettingsForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxPort = new System.Windows.Forms.TextBox();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.comboBoxRefresh = new System.Windows.Forms.ComboBox();
            this.checkBoxRefresh = new System.Windows.Forms.CheckBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(178, 40);
            this.label1.TabIndex = 0;
            this.label1.Text = "Instellingen";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel1.Controls.Add(this.label3);
            this.panel1.Controls.Add(this.textBoxPort);
            this.panel1.Controls.Add(this.textBoxServer);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Location = new System.Drawing.Point(19, 52);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(3);
            this.panel1.Size = new System.Drawing.Size(284, 103);
            this.panel1.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 48);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Poort";
            // 
            // textBoxPort
            // 
            this.textBoxPort.Location = new System.Drawing.Point(10, 64);
            this.textBoxPort.Name = "textBoxPort";
            this.textBoxPort.Size = new System.Drawing.Size(268, 22);
            this.textBoxPort.TabIndex = 2;
            this.textBoxPort.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(10, 23);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(268, 22);
            this.textBoxServer.TabIndex = 1;
            this.textBoxServer.TextChanged += new System.EventHandler(this.textChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 7);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 13);
            this.label2.TabIndex = 0;
            this.label2.Text = "Server adres";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel2.Controls.Add(this.buttonSave);
            this.panel2.Controls.Add(this.buttonCancel);
            this.panel2.Location = new System.Drawing.Point(19, 231);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(3);
            this.panel2.Size = new System.Drawing.Size(284, 36);
            this.panel2.TabIndex = 2;
            // 
            // buttonSave
            // 
            this.buttonSave.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonSave.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonSave.FlatAppearance.BorderSize = 0;
            this.buttonSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSave.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSave.Location = new System.Drawing.Point(147, 6);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(131, 23);
            this.buttonSave.TabIndex = 2;
            this.buttonSave.Text = "Opslaan";
            this.buttonSave.UseVisualStyleBackColor = false;
            // 
            // buttonCancel
            // 
            this.buttonCancel.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.FlatAppearance.BorderSize = 0;
            this.buttonCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonCancel.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonCancel.Location = new System.Drawing.Point(10, 6);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(131, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "Annuleren";
            this.buttonCancel.UseVisualStyleBackColor = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDark;
            this.panel3.Controls.Add(this.comboBoxRefresh);
            this.panel3.Controls.Add(this.checkBoxRefresh);
            this.panel3.Location = new System.Drawing.Point(19, 161);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(3);
            this.panel3.Size = new System.Drawing.Size(284, 64);
            this.panel3.TabIndex = 3;
            // 
            // comboBoxRefresh
            // 
            this.comboBoxRefresh.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxRefresh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.comboBoxRefresh.FormattingEnabled = true;
            this.comboBoxRefresh.Items.AddRange(new object[] {
            "10 seconden",
            "30 seconden",
            "1 minuut",
            "2 minuten",
            "5 minuten",
            "10 minuten"});
            this.comboBoxRefresh.Location = new System.Drawing.Point(10, 29);
            this.comboBoxRefresh.Name = "comboBoxRefresh";
            this.comboBoxRefresh.Size = new System.Drawing.Size(268, 21);
            this.comboBoxRefresh.TabIndex = 2;
            this.comboBoxRefresh.SelectedIndexChanged += new System.EventHandler(this.comboBoxRefresh_SelectedIndexChanged);
            // 
            // checkBoxRefresh
            // 
            this.checkBoxRefresh.AutoSize = true;
            this.checkBoxRefresh.Location = new System.Drawing.Point(10, 6);
            this.checkBoxRefresh.Name = "checkBoxRefresh";
            this.checkBoxRefresh.Size = new System.Drawing.Size(153, 17);
            this.checkBoxRefresh.TabIndex = 1;
            this.checkBoxRefresh.Text = "Automatisch vernieuwen";
            this.checkBoxRefresh.UseVisualStyleBackColor = true;
            this.checkBoxRefresh.CheckedChanged += new System.EventHandler(this.checkBoxRefresh_CheckedChanged);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.ClientSize = new System.Drawing.Size(315, 286);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SettingsForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Instellingen";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxPort;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox comboBoxRefresh;
        private System.Windows.Forms.CheckBox checkBoxRefresh;
    }
}