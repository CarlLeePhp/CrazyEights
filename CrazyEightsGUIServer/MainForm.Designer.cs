namespace CrazyEightsGUIServer
{
    partial class MainForm
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.richTextBoxNotes = new System.Windows.Forms.RichTextBox();
            this.labelMaxPlayers = new System.Windows.Forms.Label();
            this.radioButtonMax4 = new System.Windows.Forms.RadioButton();
            this.radioButtonMax3 = new System.Windows.Forms.RadioButton();
            this.radioButtonMax2 = new System.Windows.Forms.RadioButton();
            this.buttonStop = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStart.Location = new System.Drawing.Point(55, 111);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(131, 50);
            this.buttonStart.TabIndex = 0;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonClose.Location = new System.Drawing.Point(55, 386);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(131, 50);
            this.buttonClose.TabIndex = 1;
            this.buttonClose.Text = "Close";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // richTextBoxNotes
            // 
            this.richTextBoxNotes.Location = new System.Drawing.Point(239, 52);
            this.richTextBoxNotes.Name = "richTextBoxNotes";
            this.richTextBoxNotes.Size = new System.Drawing.Size(299, 384);
            this.richTextBoxNotes.TabIndex = 2;
            this.richTextBoxNotes.Text = "";
            // 
            // labelMaxPlayers
            // 
            this.labelMaxPlayers.AutoSize = true;
            this.labelMaxPlayers.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelMaxPlayers.Location = new System.Drawing.Point(55, 31);
            this.labelMaxPlayers.Name = "labelMaxPlayers";
            this.labelMaxPlayers.Size = new System.Drawing.Size(143, 19);
            this.labelMaxPlayers.TabIndex = 3;
            this.labelMaxPlayers.Text = "How many players";
            // 
            // radioButtonMax4
            // 
            this.radioButtonMax4.AutoSize = true;
            this.radioButtonMax4.Location = new System.Drawing.Point(143, 67);
            this.radioButtonMax4.Name = "radioButtonMax4";
            this.radioButtonMax4.Size = new System.Drawing.Size(36, 19);
            this.radioButtonMax4.TabIndex = 4;
            this.radioButtonMax4.Tag = "";
            this.radioButtonMax4.Text = "4";
            this.radioButtonMax4.UseVisualStyleBackColor = true;
            // 
            // radioButtonMax3
            // 
            this.radioButtonMax3.AutoSize = true;
            this.radioButtonMax3.Location = new System.Drawing.Point(101, 67);
            this.radioButtonMax3.Name = "radioButtonMax3";
            this.radioButtonMax3.Size = new System.Drawing.Size(36, 19);
            this.radioButtonMax3.TabIndex = 5;
            this.radioButtonMax3.Tag = "";
            this.radioButtonMax3.Text = "3";
            this.radioButtonMax3.UseVisualStyleBackColor = true;
            // 
            // radioButtonMax2
            // 
            this.radioButtonMax2.AutoSize = true;
            this.radioButtonMax2.Checked = true;
            this.radioButtonMax2.Location = new System.Drawing.Point(59, 67);
            this.radioButtonMax2.Name = "radioButtonMax2";
            this.radioButtonMax2.Size = new System.Drawing.Size(36, 19);
            this.radioButtonMax2.TabIndex = 6;
            this.radioButtonMax2.TabStop = true;
            this.radioButtonMax2.Tag = "";
            this.radioButtonMax2.Text = "2";
            this.radioButtonMax2.UseVisualStyleBackColor = true;
            // 
            // buttonStop
            // 
            this.buttonStop.Font = new System.Drawing.Font("Arial", 16.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonStop.Location = new System.Drawing.Point(55, 179);
            this.buttonStop.Name = "buttonStop";
            this.buttonStop.Size = new System.Drawing.Size(131, 50);
            this.buttonStop.TabIndex = 7;
            this.buttonStop.Text = "Stop";
            this.buttonStop.UseVisualStyleBackColor = true;
            this.buttonStop.Click += new System.EventHandler(this.buttonStop_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(596, 515);
            this.ControlBox = false;
            this.Controls.Add(this.buttonStop);
            this.Controls.Add(this.radioButtonMax2);
            this.Controls.Add(this.radioButtonMax3);
            this.Controls.Add(this.radioButtonMax4);
            this.Controls.Add(this.labelMaxPlayers);
            this.Controls.Add(this.richTextBoxNotes);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonStart);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "MainForm";
            this.Text = "Crazy Eights Server";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.RichTextBox richTextBoxNotes;
        private System.Windows.Forms.Label labelMaxPlayers;
        private System.Windows.Forms.RadioButton radioButtonMax4;
        private System.Windows.Forms.RadioButton radioButtonMax3;
        private System.Windows.Forms.RadioButton radioButtonMax2;
        private System.Windows.Forms.Button buttonStop;
    }
}

