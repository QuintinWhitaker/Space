namespace Space
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
            this.components = new System.ComponentModel.Container();
            this.gameTime = new System.Windows.Forms.Timer(this.components);
            this.scoreLabel1 = new System.Windows.Forms.Label();
            this.scoreLabel2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameTime
            // 
            this.gameTime.Enabled = true;
            this.gameTime.Interval = 20;
            this.gameTime.Tick += new System.EventHandler(this.gameTime_Tick);
            // 
            // scoreLabel1
            // 
            this.scoreLabel1.AutoSize = true;
            this.scoreLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel1.Location = new System.Drawing.Point(197, 376);
            this.scoreLabel1.Name = "scoreLabel1";
            this.scoreLabel1.Size = new System.Drawing.Size(0, 29);
            this.scoreLabel1.TabIndex = 0;
            // 
            // scoreLabel2
            // 
            this.scoreLabel2.AutoSize = true;
            this.scoreLabel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.scoreLabel2.Location = new System.Drawing.Point(528, 375);
            this.scoreLabel2.Name = "scoreLabel2";
            this.scoreLabel2.Size = new System.Drawing.Size(0, 29);
            this.scoreLabel2.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.scoreLabel2);
            this.Controls.Add(this.scoreLabel1);
            this.DoubleBuffered = true;
            this.Name = "Form1";
            this.Text = "Form1";
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.Form1_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer gameTime;
        private System.Windows.Forms.Label scoreLabel1;
        private System.Windows.Forms.Label scoreLabel2;
    }
}

