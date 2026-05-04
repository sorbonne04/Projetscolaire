// Géré par : ETHAN

namespace WinFormsApp2.Views
{
    public class StatsPanel : UserControl
    {
        private Label labelStats;

        public StatsPanel()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            this.BackColor = Color.FromArgb(40, 40, 40);

            var title = new Label
            {
                Text = "📊 STATISTIQUES",
                Font = new Font("Arial", 14, FontStyle.Bold),
                ForeColor = Color.Cyan,
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleCenter
            };

            labelStats = new Label
            {
                Text = "Simulations: 0\nAccidents: 0\nTaux réel: 0%",
                Font = new Font("Courier New", 11),
                ForeColor = Color.LimeGreen,
                Dock = DockStyle.Fill,
                Padding = new Padding(20),
                AutoSize = false
            };

            this.Controls.Add(labelStats);
            this.Controls.Add(title);
        }

        public void UpdateStats(string stats)
        {
            labelStats.Text = stats;
        }
    }
}
