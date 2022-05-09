
namespace emgucv
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStripMenuItemfile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1open = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2exit = new System.Windows.Forms.ToolStripMenuItem();
            this.massege = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStripMenuItemfile
            // 
            this.toolStripMenuItemfile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1open,
            this.toolStripMenuItem2exit});
            this.toolStripMenuItemfile.Name = "toolStripMenuItemfile";
            this.toolStripMenuItemfile.Size = new System.Drawing.Size(44, 24);
            this.toolStripMenuItemfile.Text = "file";
            // 
            // toolStripMenuItem1open
            // 
            this.toolStripMenuItem1open.Name = "toolStripMenuItem1open";
            this.toolStripMenuItem1open.Size = new System.Drawing.Size(126, 26);
            this.toolStripMenuItem1open.Text = "open";
            // 
            // toolStripMenuItem2exit
            // 
            this.toolStripMenuItem2exit.Name = "toolStripMenuItem2exit";
            this.toolStripMenuItem2exit.Size = new System.Drawing.Size(126, 26);
            this.toolStripMenuItem2exit.Text = "exit";
            // 
            // massege
            // 
            this.massege.Location = new System.Drawing.Point(0, 0);
            this.massege.Name = "massege";
            this.massege.Size = new System.Drawing.Size(100, 23);
            this.massege.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(26, 110);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(805, 344);
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(737, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 29);
            this.button1.TabIndex = 7;
            this.button1.Text = "בחר תמונה";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(637, 61);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(94, 29);
            this.button2.TabIndex = 8;
            this.button2.Text = "הצג צורות";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 466);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemfile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1open;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2exit;
        private System.Windows.Forms.Label massege;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}

