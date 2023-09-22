namespace BrawlStat
{
    partial class SettingsForm
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
            mainFormColorBtn = new Button();
            settingsFormColorBtn = new Button();
            SuspendLayout();
            // 
            // mainFormColorBtn
            // 
            mainFormColorBtn.Location = new Point(16, 14);
            mainFormColorBtn.Margin = new Padding(4, 3, 4, 3);
            mainFormColorBtn.Name = "mainFormColorBtn";
            mainFormColorBtn.Size = new Size(380, 32);
            mainFormColorBtn.TabIndex = 0;
            mainFormColorBtn.TabStop = false;
            mainFormColorBtn.Text = "Изменить цвет основной формы";
            mainFormColorBtn.UseVisualStyleBackColor = true;
            mainFormColorBtn.Click += MainFormColorBtn_Click;
            // 
            // settingsFormColorBtn
            // 
            settingsFormColorBtn.Location = new Point(16, 52);
            settingsFormColorBtn.Margin = new Padding(4, 3, 4, 3);
            settingsFormColorBtn.Name = "settingsFormColorBtn";
            settingsFormColorBtn.Size = new Size(380, 32);
            settingsFormColorBtn.TabIndex = 1;
            settingsFormColorBtn.TabStop = false;
            settingsFormColorBtn.Text = "Изменить цвет формы настроек";
            settingsFormColorBtn.UseVisualStyleBackColor = true;
            settingsFormColorBtn.Click += SettingsFormColorBtn_Click;
            // 
            // SettingsForm
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(414, 518);
            Controls.Add(settingsFormColorBtn);
            Controls.Add(mainFormColorBtn);
            Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "SettingsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SettingsForm";
            ResumeLayout(false);
        }

        #endregion

        private Button mainFormColorBtn;
        private Button settingsFormColorBtn;
    }
}