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
            this.labelMessage = new System.Windows.Forms.Label();
            this.buttonConnect = new System.Windows.Forms.Button();
            this.imageCards = new System.Windows.Forms.ImageList(this.components);
            this.buttonTest = new System.Windows.Forms.Button();
            this.labelStarterPile = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // labelMessage
            // 
            this.labelMessage.AutoSize = true;
            this.labelMessage.Location = new System.Drawing.Point(121, 187);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(159, 15);
            this.labelMessage.TabIndex = 0;
            this.labelMessage.Text = "Message from Server";
            // 
            // buttonConnect
            // 
            this.buttonConnect.Enabled = false;
            this.buttonConnect.Location = new System.Drawing.Point(345, 39);
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
            this.imageCards.Images.SetKeyName(0, "clubs-a-75.png");
            this.imageCards.Images.SetKeyName(1, "clubs-2-75.png");
            this.imageCards.Images.SetKeyName(2, "clubs-3-75.png");
            this.imageCards.Images.SetKeyName(3, "clubs-4-75.png");
            this.imageCards.Images.SetKeyName(4, "clubs-5-75.png");
            this.imageCards.Images.SetKeyName(5, "clubs-6-75.png");
            this.imageCards.Images.SetKeyName(6, "clubs-7-75.png");
            this.imageCards.Images.SetKeyName(7, "clubs-8-75.png");
            this.imageCards.Images.SetKeyName(8, "clubs-9-75.png");
            this.imageCards.Images.SetKeyName(9, "clubs-10-75.png");
            this.imageCards.Images.SetKeyName(10, "clubs-j-75.png");
            this.imageCards.Images.SetKeyName(11, "clubs-q-75.png");
            this.imageCards.Images.SetKeyName(12, "clubs-k-75.png");
            this.imageCards.Images.SetKeyName(13, "diamonds-a-75.png");
            this.imageCards.Images.SetKeyName(14, "diamonds-2-75.png");
            this.imageCards.Images.SetKeyName(15, "diamonds-3-75.png");
            this.imageCards.Images.SetKeyName(16, "diamonds-4-75.png");
            this.imageCards.Images.SetKeyName(17, "diamonds-5-75.png");
            this.imageCards.Images.SetKeyName(18, "diamonds-6-75.png");
            this.imageCards.Images.SetKeyName(19, "diamonds-7-75.png");
            this.imageCards.Images.SetKeyName(20, "diamonds-8-75.png");
            this.imageCards.Images.SetKeyName(21, "diamonds-9-75.png");
            this.imageCards.Images.SetKeyName(22, "diamonds-10-75.png");
            this.imageCards.Images.SetKeyName(23, "diamonds-j-75.png");
            this.imageCards.Images.SetKeyName(24, "diamonds-q-75.png");
            this.imageCards.Images.SetKeyName(25, "diamonds-k-75.png");
            this.imageCards.Images.SetKeyName(26, "hearts-a-75.png");
            this.imageCards.Images.SetKeyName(27, "hearts-2-75.png");
            this.imageCards.Images.SetKeyName(28, "hearts-3-75.png");
            this.imageCards.Images.SetKeyName(29, "hearts-4-75.png");
            this.imageCards.Images.SetKeyName(30, "hearts-5-75.png");
            this.imageCards.Images.SetKeyName(31, "hearts-6-75.png");
            this.imageCards.Images.SetKeyName(32, "hearts-7-75.png");
            this.imageCards.Images.SetKeyName(33, "hearts-8-75.png");
            this.imageCards.Images.SetKeyName(34, "hearts-9-75.png");
            this.imageCards.Images.SetKeyName(35, "hearts-10-75.png");
            this.imageCards.Images.SetKeyName(36, "hearts-j-75.png");
            this.imageCards.Images.SetKeyName(37, "hearts-q-75.png");
            this.imageCards.Images.SetKeyName(38, "hearts-k-75.png");
            this.imageCards.Images.SetKeyName(39, "spades-a-75.png");
            this.imageCards.Images.SetKeyName(40, "spades-2-75.png");
            this.imageCards.Images.SetKeyName(41, "spades-3-75.png");
            this.imageCards.Images.SetKeyName(42, "spades-4-75.png");
            this.imageCards.Images.SetKeyName(43, "spades-5-75.png");
            this.imageCards.Images.SetKeyName(44, "spades-6-75.png");
            this.imageCards.Images.SetKeyName(45, "spades-7-75.png");
            this.imageCards.Images.SetKeyName(46, "spades-8-75.png");
            this.imageCards.Images.SetKeyName(47, "spades-9-75.png");
            this.imageCards.Images.SetKeyName(48, "spades-10-75.png");
            this.imageCards.Images.SetKeyName(49, "spades-j-75.png");
            this.imageCards.Images.SetKeyName(50, "spades-q-75.png");
            this.imageCards.Images.SetKeyName(51, "spades-k-75.png");
            this.imageCards.Images.SetKeyName(52, "joker-b-75.png");
            this.imageCards.Images.SetKeyName(53, "joker-r-75.png");
            this.imageCards.Images.SetKeyName(54, "back-blue-75-1.png");
            this.imageCards.Images.SetKeyName(55, "back-blue-75-2.png");
            this.imageCards.Images.SetKeyName(56, "back-blue-75-3.png");
            this.imageCards.Images.SetKeyName(57, "back-red-75-1.png");
            this.imageCards.Images.SetKeyName(58, "back-red-75-2.png");
            this.imageCards.Images.SetKeyName(59, "back-red-75-3.png");
            // 
            // buttonTest
            // 
            this.buttonTest.Location = new System.Drawing.Point(264, 254);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(75, 31);
            this.buttonTest.TabIndex = 2;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // labelStarterPile
            // 
            this.labelStarterPile.AutoSize = true;
            this.labelStarterPile.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.labelStarterPile.Location = new System.Drawing.Point(520, 280);
            this.labelStarterPile.Name = "labelStarterPile";
            this.labelStarterPile.Size = new System.Drawing.Size(129, 19);
            this.labelStarterPile.TabIndex = 3;
            this.labelStarterPile.Text = "Starter Pile";
            // 
            // labelName
            // 
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(55, 50);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(79, 15);
            this.labelName.TabIndex = 4;
            this.labelName.Text = "Your Name";
            // 
            // textBoxName
            // 
            this.textBoxName.Location = new System.Drawing.Point(161, 39);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(155, 25);
            this.textBoxName.TabIndex = 5;
            this.textBoxName.TextChanged += new System.EventHandler(this.textBoxName_TextChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(971, 556);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelStarterPile);
            this.Controls.Add(this.buttonTest);
            this.Controls.Add(this.buttonConnect);
            this.Controls.Add(this.labelMessage);
            this.Name = "MainForm";
            this.Text = "Crazy Eights Client";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.Button buttonConnect;
        private System.Windows.Forms.ImageList imageCards;
        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Label labelStarterPile;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.TextBox textBoxName;
    }
}

