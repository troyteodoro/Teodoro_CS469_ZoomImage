namespace Teodoro_CS469_Hwk2
{
    partial class Form1
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
            this.chooseImageButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.coordinateDisplay = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // chooseImageButton
            // 
            this.chooseImageButton.Location = new System.Drawing.Point(12, 12);
            this.chooseImageButton.Name = "chooseImageButton";
            this.chooseImageButton.Size = new System.Drawing.Size(114, 23);
            this.chooseImageButton.TabIndex = 0;
            this.chooseImageButton.Text = "Choose Image";
            this.chooseImageButton.UseVisualStyleBackColor = true;
            this.chooseImageButton.Click += new System.EventHandler(this.chooseImageButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(542, 309);
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // coordinateDisplay
            // 
            this.coordinateDisplay.AutoSize = true;
            this.coordinateDisplay.Location = new System.Drawing.Point(132, 12);
            this.coordinateDisplay.Name = "coordinateDisplay";
            this.coordinateDisplay.Size = new System.Drawing.Size(0, 13);
            this.coordinateDisplay.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.coordinateDisplay);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.chooseImageButton);
            this.Name = "Form1";
            this.Text = "Teodoro CS469 - Image Zoom";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button chooseImageButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label coordinateDisplay;
    }
}

