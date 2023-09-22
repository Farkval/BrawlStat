namespace BrawlStat
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
            tagTextBox = new TextBox();
            findPlayerBtn = new Button();
            trophiesLbl = new Label();
            highestTrophiesLbl = new Label();
            potentiallyHighestTrophiesLbl = new Label();
            lvlLbl = new Label();
            soloVictoriesLbl = new Label();
            duoVictoriesLbl = new Label();
            teamVictoriesLbl = new Label();
            clubLbl = new Label();
            brawlersCountLbl = new Label();
            gadgetsCountLbl = new Label();
            starPowersCountLbl = new Label();
            lastBattleTimeLbl = new Label();
            gearsCountLbl = new Label();
            seasonEndTrophiesLbl = new Label();
            blingsCountLbl = new Label();
            brawlersMediumLvlLbl = new Label();
            nameLbl = new Label();
            brawlersPanel = new Panel();
            tagLbl = new Label();
            tagsComboBox = new ComboBox();
            sortingBrawlersComboBox = new ComboBox();
            visualizationStyleComboBox = new ComboBox();
            settingsBtn = new Button();
            SuspendLayout();
            // 
            // tagTextBox
            // 
            tagTextBox.Location = new Point(12, 44);
            tagTextBox.Name = "tagTextBox";
            tagTextBox.Size = new Size(188, 31);
            tagTextBox.TabIndex = 0;
            tagTextBox.TabStop = false;
            tagTextBox.TextChanged += TagTextBox_TextChanged;
            // 
            // findPlayerBtn
            // 
            findPlayerBtn.Location = new Point(206, 44);
            findPlayerBtn.Name = "findPlayerBtn";
            findPlayerBtn.Size = new Size(151, 31);
            findPlayerBtn.TabIndex = 2;
            findPlayerBtn.TabStop = false;
            findPlayerBtn.Text = "Найти";
            findPlayerBtn.UseVisualStyleBackColor = true;
            findPlayerBtn.Click += FindPlayerBtn_Click;
            // 
            // trophiesLbl
            // 
            trophiesLbl.AutoSize = true;
            trophiesLbl.Location = new Point(12, 169);
            trophiesLbl.Margin = new Padding(3, 16, 3, 1);
            trophiesLbl.Name = "trophiesLbl";
            trophiesLbl.Size = new Size(87, 23);
            trophiesLbl.TabIndex = 4;
            trophiesLbl.Text = "Трофеи:";
            // 
            // highestTrophiesLbl
            // 
            highestTrophiesLbl.AutoSize = true;
            highestTrophiesLbl.Location = new Point(12, 282);
            highestTrophiesLbl.Margin = new Padding(3, 16, 3, 1);
            highestTrophiesLbl.Name = "highestTrophiesLbl";
            highestTrophiesLbl.Size = new Size(197, 23);
            highestTrophiesLbl.TabIndex = 5;
            highestTrophiesLbl.Text = "Максимум трофеев:";
            // 
            // potentiallyHighestTrophiesLbl
            // 
            potentiallyHighestTrophiesLbl.AutoSize = true;
            potentiallyHighestTrophiesLbl.Location = new Point(12, 307);
            potentiallyHighestTrophiesLbl.Margin = new Padding(3, 1, 3, 1);
            potentiallyHighestTrophiesLbl.Name = "potentiallyHighestTrophiesLbl";
            potentiallyHighestTrophiesLbl.Size = new Size(252, 46);
            potentiallyHighestTrophiesLbl.TabIndex = 6;
            potentiallyHighestTrophiesLbl.Text = "Потенциальный максимум\r\nтрофеев: ";
            // 
            // lvlLbl
            // 
            lvlLbl.AutoSize = true;
            lvlLbl.Location = new Point(12, 129);
            lvlLbl.Margin = new Padding(3, 1, 3, 1);
            lvlLbl.Name = "lvlLbl";
            lvlLbl.Size = new Size(98, 23);
            lvlLbl.TabIndex = 7;
            lvlLbl.Text = "Уровень:";
            // 
            // soloVictoriesLbl
            // 
            soloVictoriesLbl.AutoSize = true;
            soloVictoriesLbl.Location = new Point(12, 370);
            soloVictoriesLbl.Margin = new Padding(3, 16, 3, 1);
            soloVictoriesLbl.Name = "soloVictoriesLbl";
            soloVictoriesLbl.Size = new Size(186, 23);
            soloVictoriesLbl.TabIndex = 8;
            soloVictoriesLbl.Text = "Одиночных побед:";
            // 
            // duoVictoriesLbl
            // 
            duoVictoriesLbl.AutoSize = true;
            duoVictoriesLbl.Location = new Point(12, 395);
            duoVictoriesLbl.Margin = new Padding(3, 1, 3, 1);
            duoVictoriesLbl.Name = "duoVictoriesLbl";
            duoVictoriesLbl.Size = new Size(153, 23);
            duoVictoriesLbl.TabIndex = 9;
            duoVictoriesLbl.Text = "Парных побед:";
            // 
            // teamVictoriesLbl
            // 
            teamVictoriesLbl.AutoSize = true;
            teamVictoriesLbl.Location = new Point(12, 420);
            teamVictoriesLbl.Margin = new Padding(3, 1, 3, 1);
            teamVictoriesLbl.Name = "teamVictoriesLbl";
            teamVictoriesLbl.Size = new Size(131, 23);
            teamVictoriesLbl.TabIndex = 10;
            teamVictoriesLbl.Text = "Побед 3на3:";
            // 
            // clubLbl
            // 
            clubLbl.AutoSize = true;
            clubLbl.Location = new Point(12, 104);
            clubLbl.Margin = new Padding(3, 1, 3, 1);
            clubLbl.Name = "clubLbl";
            clubLbl.Size = new Size(76, 23);
            clubLbl.TabIndex = 11;
            clubLbl.Text = "Клуб: ";
            // 
            // brawlersCountLbl
            // 
            brawlersCountLbl.AutoSize = true;
            brawlersCountLbl.Location = new Point(12, 460);
            brawlersCountLbl.Margin = new Padding(3, 16, 3, 1);
            brawlersCountLbl.Name = "brawlersCountLbl";
            brawlersCountLbl.Size = new Size(208, 23);
            brawlersCountLbl.TabIndex = 12;
            brawlersCountLbl.Text = "Бравлеров открыто:";
            // 
            // gadgetsCountLbl
            // 
            gadgetsCountLbl.AutoSize = true;
            gadgetsCountLbl.Location = new Point(12, 533);
            gadgetsCountLbl.Margin = new Padding(3, 1, 3, 1);
            gadgetsCountLbl.Name = "gadgetsCountLbl";
            gadgetsCountLbl.Size = new Size(197, 23);
            gadgetsCountLbl.TabIndex = 13;
            gadgetsCountLbl.Text = "Гаджетов открыто:";
            // 
            // starPowersCountLbl
            // 
            starPowersCountLbl.AutoSize = true;
            starPowersCountLbl.Location = new Point(12, 558);
            starPowersCountLbl.Margin = new Padding(3, 1, 3, 1);
            starPowersCountLbl.Name = "starPowersCountLbl";
            starPowersCountLbl.Size = new Size(241, 23);
            starPowersCountLbl.TabIndex = 14;
            starPowersCountLbl.Text = "Звездных сил открыто:";
            // 
            // lastBattleTimeLbl
            // 
            lastBattleTimeLbl.AutoSize = true;
            lastBattleTimeLbl.Location = new Point(12, 623);
            lastBattleTimeLbl.Margin = new Padding(3, 16, 3, 1);
            lastBattleTimeLbl.Name = "lastBattleTimeLbl";
            lastBattleTimeLbl.Size = new Size(230, 23);
            lastBattleTimeLbl.TabIndex = 15;
            lastBattleTimeLbl.Text = "Последний раз в бою:\r\n";
            // 
            // gearsCountLbl
            // 
            gearsCountLbl.AutoSize = true;
            gearsCountLbl.Location = new Point(12, 583);
            gearsCountLbl.Margin = new Padding(3, 1, 3, 1);
            gearsCountLbl.Name = "gearsCountLbl";
            gearsCountLbl.Size = new Size(219, 23);
            gearsCountLbl.TabIndex = 16;
            gearsCountLbl.Text = "Снаряжений открыто:";
            // 
            // seasonEndTrophiesLbl
            // 
            seasonEndTrophiesLbl.AutoSize = true;
            seasonEndTrophiesLbl.Location = new Point(12, 194);
            seasonEndTrophiesLbl.Margin = new Padding(3, 1, 3, 1);
            seasonEndTrophiesLbl.Name = "seasonEndTrophiesLbl";
            seasonEndTrophiesLbl.Size = new Size(175, 46);
            seasonEndTrophiesLbl.TabIndex = 17;
            seasonEndTrophiesLbl.Text = "Трофеев в конце\r\nсезона:";
            // 
            // blingsCountLbl
            // 
            blingsCountLbl.AutoSize = true;
            blingsCountLbl.Location = new Point(12, 242);
            blingsCountLbl.Margin = new Padding(3, 1, 3, 1);
            blingsCountLbl.Name = "blingsCountLbl";
            blingsCountLbl.Size = new Size(197, 23);
            blingsCountLbl.TabIndex = 18;
            blingsCountLbl.Text = "Получит блингов: ";
            // 
            // brawlersMediumLvlLbl
            // 
            brawlersMediumLvlLbl.AutoSize = true;
            brawlersMediumLvlLbl.Location = new Point(12, 485);
            brawlersMediumLvlLbl.Margin = new Padding(3, 1, 3, 1);
            brawlersMediumLvlLbl.Name = "brawlersMediumLvlLbl";
            brawlersMediumLvlLbl.Size = new Size(175, 46);
            brawlersMediumLvlLbl.TabIndex = 19;
            brawlersMediumLvlLbl.Text = "Средний уровень\r\nбравлеров: ";
            // 
            // nameLbl
            // 
            nameLbl.AutoSize = true;
            nameLbl.Location = new Point(12, 79);
            nameLbl.Margin = new Padding(3, 1, 3, 1);
            nameLbl.Name = "nameLbl";
            nameLbl.Size = new Size(54, 23);
            nameLbl.TabIndex = 20;
            nameLbl.Text = "Имя:";
            // 
            // brawlersPanel
            // 
            brawlersPanel.AutoScroll = true;
            brawlersPanel.Location = new Point(363, 44);
            brawlersPanel.Name = "brawlersPanel";
            brawlersPanel.Size = new Size(725, 625);
            brawlersPanel.TabIndex = 21;
            // 
            // tagLbl
            // 
            tagLbl.AutoSize = true;
            tagLbl.Location = new Point(12, 10);
            tagLbl.Margin = new Padding(3, 1, 3, 1);
            tagLbl.Name = "tagLbl";
            tagLbl.Size = new Size(131, 23);
            tagLbl.TabIndex = 22;
            tagLbl.Text = "Тег игрока:";
            // 
            // tagsComboBox
            // 
            tagsComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            tagsComboBox.FormattingEnabled = true;
            tagsComboBox.Location = new Point(206, 7);
            tagsComboBox.Name = "tagsComboBox";
            tagsComboBox.Size = new Size(151, 31);
            tagsComboBox.TabIndex = 23;
            tagsComboBox.TabStop = false;
            tagsComboBox.SelectedIndexChanged += TagsComboBox_SelectedIndexChanged;
            // 
            // sortingBrawlersComboBox
            // 
            sortingBrawlersComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            sortingBrawlersComboBox.FormattingEnabled = true;
            sortingBrawlersComboBox.Items.AddRange(new object[] { "Больше всего трофеев", "Меньше всего трофеев", "Наивысшие трофеи", "По уровню", "Ближе всех к новому рангу", "Потеряет трофеев (за сезон)", "Получит блингов (за сезон)" });
            sortingBrawlersComboBox.Location = new Point(363, 7);
            sortingBrawlersComboBox.Name = "sortingBrawlersComboBox";
            sortingBrawlersComboBox.Size = new Size(301, 31);
            sortingBrawlersComboBox.TabIndex = 24;
            sortingBrawlersComboBox.TabStop = false;
            sortingBrawlersComboBox.SelectedIndexChanged += SortingBrawlersComboBox_SelectedIndexChanged;
            // 
            // visualizationStyleComboBox
            // 
            visualizationStyleComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            visualizationStyleComboBox.FormattingEnabled = true;
            visualizationStyleComboBox.Items.AddRange(new object[] { "Рисунок", "Дерево" });
            visualizationStyleComboBox.Location = new Point(670, 7);
            visualizationStyleComboBox.Name = "visualizationStyleComboBox";
            visualizationStyleComboBox.Size = new Size(200, 31);
            visualizationStyleComboBox.TabIndex = 25;
            visualizationStyleComboBox.TabStop = false;
            visualizationStyleComboBox.SelectedIndexChanged += VisualizationStyleComboBox_SelectedIndexChanged;
            // 
            // settingsBtn
            // 
            settingsBtn.Location = new Point(876, 7);
            settingsBtn.Name = "settingsBtn";
            settingsBtn.Size = new Size(210, 31);
            settingsBtn.TabIndex = 26;
            settingsBtn.TabStop = false;
            settingsBtn.Text = "Настройки";
            settingsBtn.UseVisualStyleBackColor = true;
            settingsBtn.Click += SettingsBtn_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(11F, 23F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1098, 679);
            Controls.Add(settingsBtn);
            Controls.Add(visualizationStyleComboBox);
            Controls.Add(sortingBrawlersComboBox);
            Controls.Add(tagsComboBox);
            Controls.Add(tagLbl);
            Controls.Add(brawlersPanel);
            Controls.Add(nameLbl);
            Controls.Add(brawlersMediumLvlLbl);
            Controls.Add(blingsCountLbl);
            Controls.Add(seasonEndTrophiesLbl);
            Controls.Add(gearsCountLbl);
            Controls.Add(lastBattleTimeLbl);
            Controls.Add(starPowersCountLbl);
            Controls.Add(gadgetsCountLbl);
            Controls.Add(brawlersCountLbl);
            Controls.Add(clubLbl);
            Controls.Add(teamVictoriesLbl);
            Controls.Add(duoVictoriesLbl);
            Controls.Add(soloVictoriesLbl);
            Controls.Add(lvlLbl);
            Controls.Add(potentiallyHighestTrophiesLbl);
            Controls.Add(highestTrophiesLbl);
            Controls.Add(trophiesLbl);
            Controls.Add(findPlayerBtn);
            Controls.Add(tagTextBox);
            Font = new Font("Consolas", 12F, FontStyle.Regular, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Margin = new Padding(4);
            MaximizeBox = false;
            Name = "Form1";
            Text = "BrawlStat";
            Load += Form1_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox tagTextBox;
        private Button findPlayerBtn;
        private Label trophiesLbl;
        private Label highestTrophiesLbl;
        private Label potentiallyHighestTrophiesLbl;
        private Label lvlLbl;
        private Label soloVictoriesLbl;
        private Label duoVictoriesLbl;
        private Label teamVictoriesLbl;
        private Label clubLbl;
        private Label brawlersCountLbl;
        private Label gadgetsCountLbl;
        private Label starPowersCountLbl;
        private Label lastBattleTimeLbl;
        private Label gearsCountLbl;
        private Label seasonEndTrophiesLbl;
        private Label blingsCountLbl;
        private Label brawlersMediumLvlLbl;
        private Label nameLbl;
        private Panel brawlersPanel;
        private Label tagLbl;
        private ComboBox tagsComboBox;
        private ComboBox sortingBrawlersComboBox;
        private ComboBox visualizationStyleComboBox;
        private Button settingsBtn;
    }
}