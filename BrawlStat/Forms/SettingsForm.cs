using BrawlStat.Data;

namespace BrawlStat
{
    public partial class SettingsForm : Form
    {
        Form MainForm;
        public SettingsForm(Form main)
        {
            InitializeComponent();
            MainForm = main;
        }
        private void MainFormColorBtn_Click(object sender, EventArgs e)
        {
            using ColorDialog cd = new();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                MainForm.BackColor = cd.Color;
                SaveColorsData();
            }
        }

        private void SettingsFormColorBtn_Click(object sender, EventArgs e)
        {
            using ColorDialog cd = new();
            if (cd.ShowDialog() == DialogResult.OK)
            {
                BackColor = cd.Color;
                SaveColorsData();
            }
        }
        private void SaveColorsData()
        {
            string path = Path.Combine(AppDB.FormsData, "ColorsData.txt");
            if (!new DirectoryInfo(AppDB.FormsData).Exists) Directory.CreateDirectory(AppDB.FormsData);
            if (!new FileInfo(path).Exists) File.Create(path).Close();

            Color c1 = MainForm.BackColor;
            Color c2 = BackColor;
            using StreamWriter writer = new(path, false);
            writer.WriteLine($"{c1.R}:{c1.G}:{c1.B}");
            writer.WriteLine($"{c2.R}:{c2.G}:{c2.B}");
        }
    }
}
