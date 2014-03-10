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
            this.RetrieveBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.ServerLbl = new System.Windows.Forms.Label();
            this.Lbl = new System.Windows.Forms.Label();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // RetrieveBtn
            // 
            this.RetrieveBtn.Location = new System.Drawing.Point(213, 120);
            this.RetrieveBtn.Name = "RetrieveBtn";
            this.RetrieveBtn.Size = new System.Drawing.Size(197, 23);
            this.RetrieveBtn.TabIndex = 0;
            this.RetrieveBtn.Text = "Retrieve a Message";
            this.RetrieveBtn.UseVisualStyleBackColor = true;
            this.RetrieveBtn.Click += new System.EventHandler(this.RetrieveMessage_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "message";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(213, 120);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(197, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Retrieve a Message";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RetrieveMessage_Click);
            // 
            // ServerLbl
            // 
            this.ServerLbl.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ServerLbl.Location = new System.Drawing.Point(110, 29);
            this.ServerLbl.Name = "ServerLbl";
            this.ServerLbl.Size = new System.Drawing.Size(444, 23);
            this.ServerLbl.TabIndex = 2;
            // 
            // Lbl
            // 
            this.Lbl.AutoSize = true;
            this.Lbl.Location = new System.Drawing.Point(39, 30);
            this.Lbl.Name = "Lbl";
            this.Lbl.Size = new System.Drawing.Size(36, 13);
            this.Lbl.TabIndex = 1;
            this.Lbl.Text = "server";
            // 
            // richTextBox1
            // 
            this.richTextBox1.BackColor = System.Drawing.SystemColors.Control;
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.richTextBox1.Location = new System.Drawing.Point(110, 165);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(444, 179);
            this.richTextBox1.TabIndex = 3;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 370);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.Lbl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.ServerLbl);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.RetrieveBtn);
            this.Name = "Form1";
            this.Text = "TrafficMessageReceiver";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button RetrieveBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label ServerLbl;
        private System.Windows.Forms.Label Lbl;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

