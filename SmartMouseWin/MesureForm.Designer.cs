namespace SmartMouseWin
{
    partial class MesureForm
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
            this.label_value1 = new System.Windows.Forms.Label();
            this.panel_values = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel_values.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label_value1
            // 
            this.label_value1.AutoSize = true;
            this.label_value1.Location = new System.Drawing.Point(3, 13);
            this.label_value1.Name = "label_value1";
            this.label_value1.Size = new System.Drawing.Size(101, 15);
            this.label_value1.TabIndex = 0;
            this.label_value1.Text = "ここに値が入ります。";
            // 
            // panel_values
            // 
            this.panel_values.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_values.Controls.Add(this.label_value1);
            this.panel_values.Location = new System.Drawing.Point(12, 12);
            this.panel_values.Name = "panel_values";
            this.panel_values.Size = new System.Drawing.Size(168, 43);
            this.panel_values.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(361, 25);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(405, 413);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // MesureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel_values);
            this.Name = "MesureForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MesureForm_Load);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.MesureForm_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.MesureForm_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.MesureForm_MouseUp);
            this.panel_values.ResumeLayout(false);
            this.panel_values.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Label label_value1;
        private Panel panel_values;
        private PictureBox pictureBox1;
    }
}