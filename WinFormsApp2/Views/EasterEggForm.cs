namespace WinFormsApp2.Views
{
    public class EasterEggForm : Form
    {
        public EasterEggForm()
        {
            InitializeComponents();
        }

        private void InitializeComponents()
        {
            this.Text = "?? EASTER EGG - MODE SPÉCIAL ??";
            this.Size = new Size(800, 600);
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(20, 20, 40);
            this.ForeColor = Color.White;

            var panel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(20, 20, 40),
                AutoScroll = true
            };

            // Titre
            var titleLabel = new Label
            {
                Text = "?? VOUS AVEZ DÉBLOQUÉ L'EASTER EGG! ??",
                Font = new Font("Arial", 24, FontStyle.Bold),
                ForeColor = Color.Cyan,
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Top,
                Height = 60,
                AutoSize = false
            };
            panel.Controls.Add(titleLabel);

            // Contenu amusant
            var contentLabel = new Label
            {
                Text = "En réunissant les bonnes conditions,\n" +
                       "vous avez deverrouillé un mode secret!\n\n" +
                       "Mode avion?\n" +
                       "Mode chauffeur de taxi?\n" +
                       "Mode vitesse extrême?\n\n" +
                       "Continuez à tester pour découvrir\n" +
                       "toutes les surprises cachées! ???????",
                Font = new Font("Arial", 14),
                ForeColor = Color.Yellow,
                TextAlign = ContentAlignment.TopCenter,
                Dock = DockStyle.Fill,
                AutoSize = false,
                Padding = new Padding(20)
            };
            panel.Controls.Add(contentLabel);

            // Bouton fermer
            var btnClose = new Button
            {
                Text = "Fermer",
                Font = new Font("Arial", 12, FontStyle.Bold),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                Size = new Size(120, 40),
                Dock = DockStyle.Bottom
            };
            btnClose.Click += (s, e) => this.Close();
            panel.Controls.Add(btnClose);

            this.Controls.Add(panel);
        }
    }
}
