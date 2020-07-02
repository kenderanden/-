namespace Экзамен
{
    partial class Меню
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
            this.buttonUser = new System.Windows.Forms.Button();
            this.buttonManagers = new System.Windows.Forms.Button();
            this.buttonКлиенты = new System.Windows.Forms.Button();
            this.buttonLegalEntities = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonUser
            // 
            this.buttonUser.BackColor = System.Drawing.Color.PaleVioletRed;
            this.buttonUser.Enabled = false;
            this.buttonUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonUser.Location = new System.Drawing.Point(13, 303);
            this.buttonUser.Margin = new System.Windows.Forms.Padding(4);
            this.buttonUser.Name = "buttonUser";
            this.buttonUser.Size = new System.Drawing.Size(264, 51);
            this.buttonUser.TabIndex = 5;
            this.buttonUser.Text = "Пользователи";
            this.buttonUser.UseVisualStyleBackColor = false;
            this.buttonUser.Click += new System.EventHandler(this.buttonUser_Click);
            // 
            // buttonManagers
            // 
            this.buttonManagers.BackColor = System.Drawing.Color.PaleVioletRed;
            this.buttonManagers.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonManagers.Location = new System.Drawing.Point(13, 125);
            this.buttonManagers.Margin = new System.Windows.Forms.Padding(4);
            this.buttonManagers.Name = "buttonManagers";
            this.buttonManagers.Size = new System.Drawing.Size(264, 51);
            this.buttonManagers.TabIndex = 6;
            this.buttonManagers.Text = "Менеджеры";
            this.buttonManagers.UseVisualStyleBackColor = false;
            this.buttonManagers.Click += new System.EventHandler(this.buttonManagers_Click);
            // 
            // buttonКлиенты
            // 
            this.buttonКлиенты.BackColor = System.Drawing.Color.PaleVioletRed;
            this.buttonКлиенты.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonКлиенты.Location = new System.Drawing.Point(13, 184);
            this.buttonКлиенты.Margin = new System.Windows.Forms.Padding(4);
            this.buttonКлиенты.Name = "buttonКлиенты";
            this.buttonКлиенты.Size = new System.Drawing.Size(264, 51);
            this.buttonКлиенты.TabIndex = 7;
            this.buttonКлиенты.Text = "Физические лица";
            this.buttonКлиенты.UseVisualStyleBackColor = false;
            this.buttonКлиенты.Click += new System.EventHandler(this.buttonКлиенты_Click);
            // 
            // buttonLegalEntities
            // 
            this.buttonLegalEntities.BackColor = System.Drawing.Color.PaleVioletRed;
            this.buttonLegalEntities.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLegalEntities.Location = new System.Drawing.Point(13, 244);
            this.buttonLegalEntities.Margin = new System.Windows.Forms.Padding(4);
            this.buttonLegalEntities.Name = "buttonLegalEntities";
            this.buttonLegalEntities.Size = new System.Drawing.Size(264, 51);
            this.buttonLegalEntities.TabIndex = 8;
            this.buttonLegalEntities.Text = "ЮридическиеЛица";
            this.buttonLegalEntities.UseVisualStyleBackColor = false;
            this.buttonLegalEntities.Click += new System.EventHandler(this.buttonLegalEntities_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Экзамен.Properties.Resources.k05isxol;
            this.pictureBox1.Location = new System.Drawing.Point(13, 13);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(264, 104);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // Меню
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(291, 370);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.buttonLegalEntities);
            this.Controls.Add(this.buttonUser);
            this.Controls.Add(this.buttonManagers);
            this.Controls.Add(this.buttonКлиенты);
            this.Font = new System.Drawing.Font("Calibri", 11.25F);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "Меню";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Меню";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Меню_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonUser;
        private System.Windows.Forms.Button buttonManagers;
        private System.Windows.Forms.Button buttonКлиенты;
        private System.Windows.Forms.Button buttonLegalEntities;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}