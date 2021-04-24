namespace IndoorNav
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxLog = new System.Windows.Forms.TextBox();
            this.pictureBoxGraphics = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphics)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxLog
            // 
            this.textBoxLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxLog.Location = new System.Drawing.Point(0, 0);
            this.textBoxLog.Multiline = true;
            this.textBoxLog.Name = "textBoxLog";
            this.textBoxLog.ReadOnly = true;
            this.textBoxLog.Size = new System.Drawing.Size(1001, 558);
            this.textBoxLog.TabIndex = 0;
            // 
            // pictureBoxGraphics
            // 
            this.pictureBoxGraphics.Dock = System.Windows.Forms.DockStyle.Top;
            this.pictureBoxGraphics.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxGraphics.Image")));
            this.pictureBoxGraphics.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxGraphics.Name = "pictureBoxGraphics";
            this.pictureBoxGraphics.Size = new System.Drawing.Size(1001, 400);
            this.pictureBoxGraphics.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBoxGraphics.TabIndex = 1;
            this.pictureBoxGraphics.TabStop = false;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1001, 558);
            this.Controls.Add(this.pictureBoxGraphics);
            this.Controls.Add(this.textBoxLog);
            this.Name = "MainForm";
            this.Text = "IndoorNav";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxGraphics)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxLog;
        private System.Windows.Forms.PictureBox pictureBoxGraphics;
    }
}

