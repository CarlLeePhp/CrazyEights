namespace CrazyEightsClient
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.buttonConnect = new System.Windows.Forms.Button();
            this.imageCards = new System.Windows.Forms.ImageList(this.components);
            this.labelStarterPile = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.labelServerIP = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.notes = new System.Windows.Forms.RichTextBox();
            this.checkBoxReady = new System.Windows.Forms.CheckBox();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.buttonDeal = new System.Windows.Forms.Button();
            this.buttonPlace = new System.Windows.Forms.Button();
            this.timerRound = new System.Windows.Forms.Timer(this.components);
            this.radioButtonClubs = new System.Windows.Forms.RadioButton();
            this.radioButtonDiamonds = new System.Windows.Forms.RadioButton();
            this.radioButtonHearts = new System.Windows.Forms.RadioButton();
            this.radioButtonSpades = new System.Windows.Forms.RadioButton();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonConnect
            // 
            this.buttonConnect.Enabled = false;
            this.buttonConnect.Location = new System.Drawing.Point(401, 38);
            this.buttonConnect.Name = "buttonConnect";
            this.buttonConnect.Size = new System.Drawing.Size(90, 34);
            this.buttonConnect.TabIndex = 1;
            this.buttonConnect.Text = "Connect";
            this.buttonConnect.UseVisualStyleBackColor = true;
            this.buttonConnect.Click += new System.EventHandler(this.buttonConnect_Click);
            // 
            // imageCards
            // 
            this.imageCards.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageCards.ImageStream")));
            this.imageCards.TransparentColor = System.Drawing.Color.Transparent;
            this.imageCards.Images.SetKeyName(0, "clubs-2-75.png");
            this.imageCards.Images.SetKeyName(1, "clubs-3-75.png");
            this.imageCards.Images.SetKeyName(2, "clubs-4-75.png");
            this.imageCards.Images.SetKeyName(3, "clubs-5-75.png");
            this.imageCards.Images.SetKeyName(4, "clubs-6-75.png");
            this.imageCards.Images.SetKeyName(5, "clubs-7-75.png");
            this.imageCards.Images.SetKeyName(6, "clubs-8-75.png");
            this.imageCards.Images.SetKeyName(7, "clubs-9-75.png");
            this.imageCards.Images.SetKeyName(8, "clubs-10-75.png");
            this.imageCards.Images.SetKeyName(9, "clubs-j-75.png");
            this.imageCards.Images.SetKeyName(10, "clubs-q-75.png");
            this.imageCards.Images.SetKeyName(11, "clubs-k-75.png");
            this.imageCards.Images.SetKeyName(12, "clubs-a-75.png");
            this.imageCards.Images.SetKeyName(13, "diamonds-2-75.png");
            this.imageCards.Images.SetKeyName(14, "diamonds-3-75.png");
            this.imageCards.Images.SetKeyName(15, "diamonds-4-75.png");
            this.imageCards.Images.SetKeyName(16, "diamonds-5-75.png");
            this.imageCards.Images.SetKeyName(17, "diamonds-6-75.png");
            this.imageCards.Images.SetKeyName(18, "diamonds-7-75.png");
            this.imageCards.Images.SetKeyName(19, "diamonds-8-75.png");
            this.imageCards.Images.SetKeyName(20, "diamonds-9-75.png");
            this.imageCards.Images.SetKeyName(21, "diamonds-10-75.png");
            this.imageCards.Images.SetKeyName(22, "diamonds-j-75.png");
            this.imageCards.Images.SetKeyName(23, "diamonds-q-75.png");
            this.imageCards.Images.SetKeyName(24, "diamonds-k-75.png");
            this.imageCards.Images.SetKeyName(25, "diamonds-a-75.png");
            this.imageCards.Images.SetKeyName(26, "hearts-2-75.png");
            this.imageCards.Images.SetKeyName(27, "hearts-3-75.png");
            this.imageCards.Images.SetKeyName(28, "hearts-4-75.png");
            this.imageCards.Images.SetKeyName(29, "hearts-5-75.png");
            this.imageCards.Images.SetKeyName(30, "hearts-6-75.png");
            this.imageCards.Images.SetKeyName(31, "hearts-7-75.png");
            this.imageCards.Images.SetKeyName(32, "hearts-8-75.png");
            this.imageCards.Images.SetKeyName(33, "hearts-9-75.png");
            this.imageCards.Images.SetKeyName(34, "hearts-10-75.png");
            this.imageCards.Images.SetKeyName(35, "hearts-j-75.png");
            this.imageCards.Images.SetKeyName(36, "hearts-q-75.png");
            this.imageCards.Images.SetKeyName(37, "hearts-k-75.png");
            this.imageCards.Images.SetKeyName(38, "hearts-a-75.png");
            this.imageCards.Images.SetKeyName(39, "spades-2-75.png");
            this.imageCards.Images.SetKeyName(40, "spades-3-75.png");
            this.imageCards.Images.SetKeyName(41, "spades-4-75.png");
            this.imageCards.Images.SetKeyName(42, "spades-5-75.png");
            this.imageCards.Images.SetKeyName(43, "spades-6-75.png");
            this.imageCards.Images.SetKeyName(44, "spades-7-75.png");
            this.imageCards.Images.SetKeyName(45, "spades-8-75.png");
            this.imageCards.Images.SetKeyName(46, "spades-9-75.png");
            this.imageCards.Images.SetKeyName(47, "spades-10-75.png");
            this.imageCards.Images.SetKeyName(48, "spades-j-75.png");
            this.imageCards.Images.SetKeyName(49, "spades-q-75.png");
            this.imageCards.Images.SetKeyName(50, "spades-k-75.png");
            this.imageCards.Images.SetKeyName(51, "spades-a-75.png");
            this.imageCards.Images.SetKeyName(52, "joker-b-75.png");
            this.imageCards.Images.SetKeyName(53, "joker-r-75.png");
            this.imageCards.Images.SetKeyName(54, "back-blue-75-1.png");
            this.imageCards.Images.SetKeyName(55, "back-blue-75-2.png");
            this.imageCards.Images.SetKeyName(56, "back-blue-75-3.png");
            this.imageCards.Images.SetKeyName(57, "back-red-75-1.png");
            this.imageCards.Images.SetKeyName(58, "back-red-75-2.png");
            this.imageCards.Images.SetKeyName(59, "back-red-75-3.png");
            // 
            // labelStarterPile
            // 
            this.labelStarterPile.AutoSize = true;
            this.labelStarterPile.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStarterPile.Location = new System.Drawing.Point(499, 318);
            this.labelStarterPile.Name = "labelStarterPile";
            this.labelStarterPile.Size = new System.Drawing.Size(129, 19);
            this.labelStarterPile.TabIndex = 3;
            this.labelStarterPile.Text = "Starter Pile";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelName.Location = new System.Drawing.Point(24, 61);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(102, 22);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Your Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(132, 61);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(206, 25);
            this.textBoxName.TabIndex = 5;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // labelServerIP
            // 
            this.labelServerIP.AutoSize = true;
            this.labelServerIP.Font = new System.Drawing.Font("Arial", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelServerIP.Location = new System.Drawing.Point(24, 26);
            this.labelServerIP.Name = "labelServerIP";
            this.labelServerIP.Size = new System.Drawing.Size(90, 22);
            this.labelServerIP.TabIndex = 7;
            this.labelServerIP.Text = "Server IP";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(132, 23);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(206, 25);
            this.textBoxServer.TabIndex = 8;
            // 
            // notes
            // 
            this.notes.Location = new System.Drawing.Point(28, 118);
            this.notes.Name = "notes";
            this.notes.Size = new System.Drawing.Size(310, 203);
            this.notes.TabIndex = 9;
            this.notes.Text = "";
            // 
            // checkBoxReady
            // 
            this.checkBoxReady.AutoSize = true;
            this.checkBoxReady.Location = new System.Drawing.Point(527, 52);
            this.checkBoxReady.Name = "checkBoxReady";
            this.checkBoxReady.Size = new System.Drawing.Size(109, 19);
            this.checkBoxReady.TabIndex = 10;
            this.checkBoxReady.Text = "I am ready";
            this.checkBoxReady.UseVisualStyleBackColor = true;
            this.checkBoxReady.CheckedChanged += new System.EventHandler(this.checkBoxReady_CheckedChanged);
            // 
            // timer
            // 
            this.timer.Interval = 500;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // buttonDeal
            // 
            this.buttonDeal.Enabled = false;
            this.buttonDeal.Location = new System.Drawing.Point(855, 478);
            this.buttonDeal.Name = "buttonDeal";
            this.buttonDeal.Size = new System.Drawing.Size(84, 31);
            this.buttonDeal.TabIndex = 11;
            this.buttonDeal.Text = "Deal";
            this.buttonDeal.UseVisualStyleBackColor = true;
            this.buttonDeal.Click += new System.EventHandler(this.buttonDeal_Click);
            // 
            // buttonPlace
            // 
            this.buttonPlace.Enabled = false;
            this.buttonPlace.Location = new System.Drawing.Point(855, 422);
            this.buttonPlace.Name = "buttonPlace";
            this.buttonPlace.Size = new System.Drawing.Size(84, 31);
            this.buttonPlace.TabIndex = 12;
            this.buttonPlace.Text = "Place";
            this.buttonPlace.UseVisualStyleBackColor = true;
            this.buttonPlace.Click += new System.EventHandler(this.buttonPlace_Click);
            // 
            // timerRound
            // 
            this.timerRound.Interval = 500;
            this.timerRound.Tick += new System.EventHandler(this.timerRound_Tick);
            // 
            // radioButtonClubs
            // 
            this.radioButtonClubs.AutoSize = true;
            this.radioButtonClubs.Checked = true;
            this.radioButtonClubs.Enabled = false;
            this.radioButtonClubs.Location = new System.Drawing.Point(855, 270);
            this.radioButtonClubs.Name = "radioButtonClubs";
            this.radioButtonClubs.Size = new System.Drawing.Size(68, 19);
            this.radioButtonClubs.TabIndex = 13;
            this.radioButtonClubs.TabStop = true;
            this.radioButtonClubs.Text = "Clubs";
            this.radioButtonClubs.UseVisualStyleBackColor = true;
            // 
            // radioButtonDiamonds
            // 
            this.radioButtonDiamonds.AutoSize = true;
            this.radioButtonDiamonds.Enabled = false;
            this.radioButtonDiamonds.Location = new System.Drawing.Point(855, 305);
            this.radioButtonDiamonds.Name = "radioButtonDiamonds";
            this.radioButtonDiamonds.Size = new System.Drawing.Size(92, 19);
            this.radioButtonDiamonds.TabIndex = 14;
            this.radioButtonDiamonds.Text = "Diamonds";
            this.radioButtonDiamonds.UseVisualStyleBackColor = true;
            // 
            // radioButtonHearts
            // 
            this.radioButtonHearts.AutoSize = true;
            this.radioButtonHearts.Enabled = false;
            this.radioButtonHearts.Location = new System.Drawing.Point(855, 340);
            this.radioButtonHearts.Name = "radioButtonHearts";
            this.radioButtonHearts.Size = new System.Drawing.Size(76, 19);
            this.radioButtonHearts.TabIndex = 15;
            this.radioButtonHearts.Text = "Hearts";
            this.radioButtonHearts.UseVisualStyleBackColor = true;
            // 
            // radioButtonSpades
            // 
            this.radioButtonSpades.AutoSize = true;
            this.radioButtonSpades.Enabled = false;
            this.radioButtonSpades.Location = new System.Drawing.Point(855, 374);
            this.radioButtonSpades.Name = "radioButtonSpades";
            this.radioButtonSpades.Size = new System.Drawing.Size(76, 19);
            this.radioButtonSpades.TabIndex = 16;
            this.radioButtonSpades.Text = "Spades";
            this.radioButtonSpades.UseVisualStyleBackColor = true;
            // 
            // buttonQuit
            // 
            this.buttonQuit.Enabled = false;
            this.buttonQuit.Location = new System.Drawing.Point(855, 539);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(84, 34);
            this.buttonQuit.TabIndex = 17;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(979, 585);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.radioButtonSpades);
            this.Controls.Add(this.radioButtonHearts);
            this.Controls.Add(this.radioButtonDiamonds);
            this.Controls.Add(this.radioButtonClubs);
            this.Controls.Add(this.buttonPlace);
            this.Controls.Add(this.buttonDeal);
            this.Controls.Add(this.checkBoxReady);
            this.Controls.Add(this.notes);
            this.Controls.Add(this.textBoxServer);
            this.Controls.Add(this.labelServerIP);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelStarterPile);
            this.Controls.Add(this.buttonConnect);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Crazy Eights Client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ImageList imageCards;
        private System.Windows.Forms.Label labelStarterPile;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Label labelServerIP;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.RichTextBox notes;
        private System.Windows.Forms.CheckBox checkBoxReady;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button buttonDeal;
        private System.Windows.Forms.Button buttonPlace;
        private System.Windows.Forms.Timer timerRound;
        private System.Windows.Forms.RadioButton radioButtonClubs;
        private System.Windows.Forms.RadioButton radioButtonDiamonds;
        private System.Windows.Forms.RadioButton radioButtonHearts;
        private System.Windows.Forms.RadioButton radioButtonSpades;
        private System.Windows.Forms.Button buttonQuit;
    }
}

