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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button_close = new System.Windows.Forms.Button();
            this.button_mode = new System.Windows.Forms.Button();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.button_return = new System.Windows.Forms.Button();
            this.Settings_panel = new System.Windows.Forms.Panel();
            this.Save_button = new System.Windows.Forms.Button();
            this.Control_button = new System.Windows.Forms.Button();
            this.panel_values.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.Settings_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // label_value1
            // 
            this.label_value1.AutoSize = true;
            this.label_value1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label_value1.Location = new System.Drawing.Point(3, 13);
            this.label_value1.Name = "label_value1";
            this.label_value1.Size = new System.Drawing.Size(0, 18);
            this.label_value1.TabIndex = 0;
            // 
            // panel_values
            // 
            this.panel_values.AutoSize = true;
            this.panel_values.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.panel_values.Controls.Add(this.label_value1);
            this.panel_values.Location = new System.Drawing.Point(12, 374);
            this.panel_values.Margin = new System.Windows.Forms.Padding(0);
            this.panel_values.Name = "panel_values";
            this.panel_values.Size = new System.Drawing.Size(6, 31);
            this.panel_values.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(486, 19);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(141, 158);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Location = new System.Drawing.Point(198, 19);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(138, 158);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // button_close
            // 
            this.button_close.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_close.Location = new System.Drawing.Point(3, 12);
            this.button_close.Name = "button_close";
            this.button_close.Size = new System.Drawing.Size(129, 43);
            this.button_close.TabIndex = 4;
            this.button_close.Text = "終了";
            this.button_close.UseVisualStyleBackColor = true;
            this.button_close.Click += new System.EventHandler(this.Button_close_Click);
            this.button_close.MouseDown += new System.Windows.Forms.MouseEventHandler(this.Button_close_MouseDown);
            this.button_close.MouseMove += new System.Windows.Forms.MouseEventHandler(this.Button_close_MouseMove);
            this.button_close.MouseUp += new System.Windows.Forms.MouseEventHandler(this.Button_close_MouseUp);
            // 
            // button_mode
            // 
            this.button_mode.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_mode.Location = new System.Drawing.Point(3, 61);
            this.button_mode.Name = "button_mode";
            this.button_mode.Size = new System.Drawing.Size(129, 43);
            this.button_mode.TabIndex = 5;
            this.button_mode.Text = "pixmesure";
            this.button_mode.UseVisualStyleBackColor = true;
            this.button_mode.Click += new System.EventHandler(this.Button_mode_Click);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Location = new System.Drawing.Point(342, 19);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(138, 158);
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.MouseDown += new System.Windows.Forms.MouseEventHandler(this.PictureBox3_MouseDown);
            this.pictureBox3.MouseMove += new System.Windows.Forms.MouseEventHandler(this.PictureBox3_MouseMove);
            this.pictureBox3.MouseUp += new System.Windows.Forms.MouseEventHandler(this.PictureBox3_MouseUp);
            // 
            // button_return
            // 
            this.button_return.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.button_return.Location = new System.Drawing.Point(3, 110);
            this.button_return.Name = "button_return";
            this.button_return.Size = new System.Drawing.Size(129, 43);
            this.button_return.TabIndex = 7;
            this.button_return.Text = "戻す";
            this.button_return.UseVisualStyleBackColor = true;
            this.button_return.Click += new System.EventHandler(this.Button_return_Click);
            // 
            // Settings_panel
            // 
            this.Settings_panel.Controls.Add(this.Save_button);
            this.Settings_panel.Controls.Add(this.button_mode);
            this.Settings_panel.Controls.Add(this.button_return);
            this.Settings_panel.Controls.Add(this.button_close);
            this.Settings_panel.Location = new System.Drawing.Point(12, 73);
            this.Settings_panel.Name = "Settings_panel";
            this.Settings_panel.Size = new System.Drawing.Size(135, 233);
            this.Settings_panel.TabIndex = 8;
            // 
            // Save_button
            // 
            this.Save_button.Font = new System.Drawing.Font("Yu Gothic UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Save_button.Location = new System.Drawing.Point(3, 159);
            this.Save_button.Name = "Save_button";
            this.Save_button.Size = new System.Drawing.Size(129, 43);
            this.Save_button.TabIndex = 8;
            this.Save_button.Text = "保存";
            this.Save_button.UseVisualStyleBackColor = true;
            this.Save_button.Click += new System.EventHandler(this.Save_button_Click);
            // 
            // Control_button
            // 
            this.Control_button.BackgroundImage = global::SmartMouseWin.Properties.Resources.SettingsImage;
            this.Control_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Control_button.Location = new System.Drawing.Point(12, 19);
            this.Control_button.Name = "Control_button";
            this.Control_button.Size = new System.Drawing.Size(55, 48);
            this.Control_button.TabIndex = 9;
            this.Control_button.UseVisualStyleBackColor = true;
            this.Control_button.Click += new System.EventHandler(this.Control_button_Click);
            // 
            // MesureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Control_button);
            this.Controls.Add(this.Settings_panel);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.panel_values);
            this.Name = "MesureForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.MesureForm_Load);
            this.panel_values.ResumeLayout(false);
            this.panel_values.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.Settings_panel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label_value1;
        private Panel panel_values;
        private PictureBox pictureBox1;
        private PictureBox pictureBox2;
        private Button button_close;
        private Button button_mode;
        private PictureBox pictureBox3;
        private Button button_return;
        private Panel Settings_panel;
        private Button Control_button;
        private Button Save_button;
    }
}