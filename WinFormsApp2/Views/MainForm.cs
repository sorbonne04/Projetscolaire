using WinFormsApp2.Controllers;
// Géré par : TARIK

using System.Text;

namespace WinFormsApp2.Views
{
    public partial class MainForm : Form
    {
        private SimulationController controller;
        private bool yaEuCollision = false;
        private bool simulationExecutee = false;
        private TextBox txtInfos;
        private Panel vizPanel;

        public MainForm()
        {
            InitializeComponent();
            controller = new SimulationController();
        }

        private void InitializeComponent()
        {
            this.Text = "Simulateur de Freinage";
            this.Size = new Size(1400, 800);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.FromArgb(30, 30, 30);
            this.ForeColor = Color.White;

            var mainLayout = new TableLayoutPanel
            {
                Dock = DockStyle.Fill,
                ColumnCount = 3,
                RowCount = 1,
                AutoSize = false
            };
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 220));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100));
            mainLayout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 280));
            mainLayout.RowStyles.Add(new RowStyle(SizeType.Percent, 100));

            // === GAUCHE: Contrôles ===
            var leftPanel = new FlowLayoutPanel
            {
                BackColor = Color.FromArgb(40, 40, 40),
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false,
                AutoScroll = true,
                Padding = new Padding(8)
            };

            // Vehicule
            leftPanel.Controls.Add(new Label { Text = "VEHICULE", ForeColor = Color.Cyan, Font = new Font("Arial", 9, FontStyle.Bold), AutoSize = true, Margin = new Padding(0, 5, 0, 3) });
            var comboVehicule = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList, Margin = new Padding(0, 0, 0, 8) };
            comboVehicule.Items.AddRange(new[] { "Voiture", "Moto", "Autobus", "Avion", "Fauteuil" });
            comboVehicule.SelectedIndex = 0;
            leftPanel.Controls.Add(comboVehicule);

            // Conducteur
            leftPanel.Controls.Add(new Label { Text = "CONDUCTEUR", ForeColor = Color.Cyan, Font = new Font("Arial", 9, FontStyle.Bold), AutoSize = true, Margin = new Padding(0, 5, 0, 3) });
            var comboConducteur = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList, Margin = new Padding(0, 0, 0, 3) };
            comboConducteur.Items.AddRange(new[] { "Homme", "Femme" });
            comboConducteur.SelectedIndex = 0;
            leftPanel.Controls.Add(comboConducteur);

            var spinAge = new NumericUpDown { Value = 30, Minimum = 18, Maximum = 100, Width = 200, Margin = new Padding(0, 0, 0, 3) };
            leftPanel.Controls.Add(new Label { Text = "Age:", ForeColor = Color.White, Font = new Font("Arial", 8), AutoSize = true, Margin = new Padding(0, 0, 0, 0) });
            leftPanel.Controls.Add(spinAge);

            var checkPermis = new CheckBox { Text = "Permis", Checked = true, ForeColor = Color.White, AutoSize = true, Margin = new Padding(0, 3, 0, 0) };
            leftPanel.Controls.Add(checkPermis);
            var checkAlcool = new CheckBox { Text = "Alcoolise", ForeColor = Color.White, AutoSize = true, Margin = new Padding(0, 2, 0, 0) };
            leftPanel.Controls.Add(checkAlcool);
            var checkFatigue = new CheckBox { Text = "Fatigue", ForeColor = Color.White, AutoSize = true, Margin = new Padding(0, 2, 0, 8) };
            leftPanel.Controls.Add(checkFatigue);

            // Meteo
            leftPanel.Controls.Add(new Label { Text = "METEO", ForeColor = Color.Cyan, Font = new Font("Arial", 9, FontStyle.Bold), AutoSize = true, Margin = new Padding(0, 5, 0, 3) });
            var comboMeteo = new ComboBox { Width = 200, DropDownStyle = ComboBoxStyle.DropDownList, Margin = new Padding(0, 0, 0, 8) };
            comboMeteo.Items.AddRange(new[] { "Beau", "Pluie", "Neige", "Brouillard" });
            comboMeteo.SelectedIndex = 0;
            leftPanel.Controls.Add(comboMeteo);

            // Vitesse
            leftPanel.Controls.Add(new Label { Text = "Vitesse (km/h):", ForeColor = Color.Cyan, Font = new Font("Arial", 9, FontStyle.Bold), AutoSize = true, Margin = new Padding(0, 5, 0, 3) });
            var sliderVitesse = new TrackBar { Minimum = 0, Maximum = 200, Value = 50, Width = 200, Height = 35, Margin = new Padding(0, 0, 0, 0) };
            leftPanel.Controls.Add(sliderVitesse);
            var lblVitesseVal = new Label { Text = "50 km/h", ForeColor = Color.Yellow, Font = new Font("Arial", 9, FontStyle.Bold), AutoSize = true, Margin = new Padding(0, 0, 0, 8) };
            leftPanel.Controls.Add(lblVitesseVal);

            // Distance
            leftPanel.Controls.Add(new Label { Text = "Distance (m):", ForeColor = Color.Cyan, Font = new Font("Arial", 9, FontStyle.Bold), AutoSize = true, Margin = new Padding(0, 5, 0, 3) });
            var sliderDistance = new TrackBar { Minimum = 50, Maximum = 500, Value = 200, Width = 200, Height = 35, Margin = new Padding(0, 0, 0, 0) };
            leftPanel.Controls.Add(sliderDistance);
            var lblDistanceVal = new Label { Text = "200 m", ForeColor = Color.Yellow, Font = new Font("Arial", 9, FontStyle.Bold), AutoSize = true, Margin = new Padding(0, 0, 0, 15) };
            leftPanel.Controls.Add(lblDistanceVal);

            // Boutons
            var btnSimuler = new Button { Text = "SIMULER", Width = 200, Height = 40, BackColor = Color.FromArgb(0, 150, 136), ForeColor = Color.White, Font = new Font("Arial", 10, FontStyle.Bold), Margin = new Padding(0, 5, 0, 3) };
            leftPanel.Controls.Add(btnSimuler);
            var btnReset = new Button { Text = "RESET", Width = 200, Height = 40, BackColor = Color.FromArgb(200, 50, 50), ForeColor = Color.White, Font = new Font("Arial", 10, FontStyle.Bold), Margin = new Padding(0, 0, 0, 0) };
            leftPanel.Controls.Add(btnReset);

            mainLayout.Controls.Add(leftPanel, 0, 0);

            // === CENTRE: Visualization avec graphisme ===
            var centerPanel = new Panel { BackColor = Color.FromArgb(50, 50, 70), Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };

            var lblViz = new Label { Text = "VISUALISATION", ForeColor = Color.Cyan, Font = new Font("Arial", 12, FontStyle.Bold), Dock = DockStyle.Top, Height = 30, TextAlign = ContentAlignment.MiddleCenter, BackColor = Color.FromArgb(50, 50, 80) };
            centerPanel.Controls.Add(lblViz);

            var vizPanel = new Panel { Dock = DockStyle.Fill, BackColor = Color.FromArgb(50, 50, 70) };
            this.vizPanel = vizPanel;  // Garder la référence
            vizPanel.Paint += (s, e) =>
            {
                e.Graphics.Clear(Color.FromArgb(50, 50, 70));
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;

                int w = vizPanel.Width;
                int h = vizPanel.Height;

                // Route
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(40, 40, 40)), 0, h / 2, w, 80);
                var dashedPen = new Pen(Color.Yellow, 2) { DashStyle = System.Drawing.Drawing2D.DashStyle.Dash };
                e.Graphics.DrawLine(dashedPen, 0, h / 2 + 40, w, h / 2 + 40);

                string vehicule = comboVehicule.SelectedItem?.ToString() ?? "Voiture";
                string obstacle = "";

                // DESSINER LE VEHICULE SELON TYPE
                if (vehicule == "Voiture")
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Red), 80, h / 2 + 10, 70, 40);
                    e.Graphics.FillRectangle(new SolidBrush(Color.DarkRed), 90, h / 2 - 10, 50, 20);
                    e.Graphics.FillEllipse(new SolidBrush(Color.Black), 95, h / 2 + 45, 15, 15);
                    e.Graphics.FillEllipse(new SolidBrush(Color.Black), 125, h / 2 + 45, 15, 15);
                    obstacle = "McDo";
                    e.Graphics.FillRectangle(new SolidBrush(Color.SaddleBrown), w - 150, h / 2 - 50, 140, 150);
                    e.Graphics.DrawString("McDo", new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Yellow), w - 130, h / 2 + 40);
                }
                else if (vehicule == "Moto")
                {
                    // Moto = 2 roues, chassis fin
                    e.Graphics.FillRectangle(new SolidBrush(Color.Blue), 80, h / 2 + 15, 50, 25);
                    e.Graphics.FillEllipse(new SolidBrush(Color.Black), 90, h / 2 + 35, 12, 12);
                    e.Graphics.FillEllipse(new SolidBrush(Color.Black), 110, h / 2 + 35, 12, 12);
                    obstacle = "Pieton";
                    e.Graphics.FillEllipse(new SolidBrush(Color.Wheat), w - 130, h / 2 - 40, 30, 30);
                    e.Graphics.FillRectangle(new SolidBrush(Color.Wheat), w - 125, h / 2 + 10, 20, 40);
                }
                else if (vehicule == "Autobus")
                {
                    // Bus = grand rectangle
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(200, 100, 50)), 60, h / 2 + 5, 100, 50);
                    e.Graphics.FillRectangle(new SolidBrush(Color.Cyan), 65, h / 2 + 10, 20, 15);
                    e.Graphics.FillRectangle(new SolidBrush(Color.Cyan), 90, h / 2 + 10, 20, 15);
                    e.Graphics.FillRectangle(new SolidBrush(Color.Cyan), 115, h / 2 + 10, 20, 15);
                    e.Graphics.FillEllipse(new SolidBrush(Color.Black), 75, h / 2 + 50, 18, 18);
                    e.Graphics.FillEllipse(new SolidBrush(Color.Black), 120, h / 2 + 50, 18, 18);
                    obstacle = "Petite Voiture";
                    e.Graphics.FillRectangle(new SolidBrush(Color.Blue), w - 130, h / 2 - 30, 80, 35);
                }
                else if (vehicule == "Avion")
                {
                    // Avion = fuselage + ailes
                    e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 85, h / 2 + 20, 60, 20);
                    e.Graphics.FillRectangle(new SolidBrush(Color.Gray), 60, h / 2 + 25, 110, 10);
                    e.Graphics.FillPolygon(new SolidBrush(Color.Gray), new Point[] { new Point(145, h / 2 + 20), new Point(160, h / 2 + 25), new Point(145, h / 2 + 30) });
                    obstacle = "Tours Jumelles";
                    e.Graphics.FillRectangle(new SolidBrush(Color.Gray), w - 170, h / 2 - 80, 50, 150);
                    e.Graphics.FillRectangle(new SolidBrush(Color.Gray), w - 100, h / 2 - 80, 50, 150);
                }
                else if (vehicule == "Fauteuil")
                {
                    // Fauteuil = 2 roues + chassis
                    e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(150, 100, 50)), 85, h / 2 + 10, 50, 40);
                    e.Graphics.FillEllipse(new SolidBrush(Color.Black), 90, h / 2 + 45, 16, 16);
                    e.Graphics.FillEllipse(new SolidBrush(Color.Black), 120, h / 2 + 45, 16, 16);
                    obstacle = "Escalier";
                    for (int i = 0; i < 6; i++)
                    {
                        e.Graphics.FillRectangle(new SolidBrush(Color.SaddleBrown), w - 150 + i * 18, h / 2 - 30 + i * 15, 15, 15);
                    }
                }

                // Barre de distance restante - calculer avant d'afficher
                float distMax = sliderDistance.Value;
                float vitesse = sliderVitesse.Value;

                // Calculer la distance de freinage approximativement
                float distanceFreinage = (vitesse * vitesse) / (2 * 9.81f * 1.0f);  // adhérence ~1.0

                // Distance restante = distance mur - distance freinage
                float distRestante = distMax - distanceFreinage;
                if (distRestante < 0) distRestante = 0;

                // Largeur de la barre proportionnelle
                float barWidth = 0;
                if (distMax > 0)
                {
                    barWidth = (w - 320) * (distRestante / distMax);
                }
                if (barWidth < 0) barWidth = 0;

                // Fond rouge (danger)
                e.Graphics.FillRectangle(new SolidBrush(Color.FromArgb(100, 0, 0)), 160, h / 2 - 35, w - 320, 20);

                // Barre bleue (distance restante)
                if (distRestante > 0)
                {
                    e.Graphics.FillRectangle(new SolidBrush(Color.Cyan), 160, h / 2 - 35, barWidth, 20);
                }

                // Bordure blanche
                e.Graphics.DrawRectangle(new Pen(Color.White, 2), 160, h / 2 - 35, w - 320, 20);

                // Label avec distance restante
                e.Graphics.DrawString($"Distance restante: {Math.Max(0, distRestante):F0}m / {distMax:F0}m", new Font("Arial", 9), new SolidBrush(Color.White), 170, h / 2 - 60);

                // Afficher COLLISION! SEULEMENT s'il y a vraiment eu collision
                if (yaEuCollision)
                {
                    e.Graphics.DrawString("COLLISION!", new Font("Arial", 20, FontStyle.Bold), new SolidBrush(Color.Red), w / 2 - 60, h / 2 - 100);
                    e.Graphics.DrawString($"{vehicule} fonce dans {obstacle}!", new Font("Arial", 12), new SolidBrush(Color.White), 20, 20);
                }
                else if (simulationExecutee)
                {
                    e.Graphics.DrawString("OK - PAS DE COLLISION", new Font("Arial", 16, FontStyle.Bold), new SolidBrush(Color.Green), w / 2 - 100, h / 2 - 100);
                }
            };

            centerPanel.Controls.Add(vizPanel);
            mainLayout.Controls.Add(centerPanel, 1, 0);

            // === DROIT: Infos ===
            var rightPanel = new Panel { BackColor = Color.FromArgb(40, 40, 40), Dock = DockStyle.Fill, BorderStyle = BorderStyle.FixedSingle };

            var lblInfos = new Label { Text = "DONNEES", ForeColor = Color.Cyan, Font = new Font("Arial", 9, FontStyle.Bold), Dock = DockStyle.Top, Height = 22, TextAlign = ContentAlignment.MiddleLeft, Padding = new Padding(8, 0, 0, 0), BackColor = Color.FromArgb(50, 50, 70) };
            rightPanel.Controls.Add(lblInfos);

            var txtInfos = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                BackColor = Color.FromArgb(20, 20, 20),
                ForeColor = Color.LimeGreen,
                BorderStyle = BorderStyle.None,
                Font = new Font("Courier New", 7),
                Padding = new Padding(5),
                ScrollBars = ScrollBars.Both,
                WordWrap = false
            };
            txtInfos.Text = "Cliquez sur SIMULER pour voir les données...";
            this.txtInfos = txtInfos;  // Garder la référence
            rightPanel.Controls.Add(txtInfos);

            mainLayout.Controls.Add(rightPanel, 2, 0);

            this.Controls.Add(mainLayout);

            // === Événements ===
            sliderVitesse.ValueChanged += (s, e) => lblVitesseVal.Text = sliderVitesse.Value + " km/h";
            sliderDistance.ValueChanged += (s, e) => lblDistanceVal.Text = sliderDistance.Value + " m";
            comboVehicule.SelectedValueChanged += (s, e) => vizPanel.Invalidate();

            btnSimuler.Click += (s, e) =>
            {
                // Changer le véhicule
                var typeVehicule = comboVehicule.SelectedIndex == 0 ? WinFormsApp2.Enums.TypeVehicule.Voiture : 
                                   comboVehicule.SelectedIndex == 1 ? WinFormsApp2.Enums.TypeVehicule.Moto :
                                   comboVehicule.SelectedIndex == 2 ? WinFormsApp2.Enums.TypeVehicule.Autobus :
                                   comboVehicule.SelectedIndex == 3 ? WinFormsApp2.Enums.TypeVehicule.Avion :
                                   WinFormsApp2.Enums.TypeVehicule.FauteuilRoulant;

                var sexe = comboConducteur.SelectedIndex == 0 ? WinFormsApp2.Enums.Sexe.Homme : WinFormsApp2.Enums.Sexe.Femme;
                var meteo = comboMeteo.SelectedIndex == 0 ? WinFormsApp2.Enums.EtatMeteoType.Sec :
                            comboMeteo.SelectedIndex == 1 ? WinFormsApp2.Enums.EtatMeteoType.Pluie :
                            comboMeteo.SelectedIndex == 2 ? WinFormsApp2.Enums.EtatMeteoType.Neige :
                            comboMeteo.SelectedIndex == 3 ? WinFormsApp2.Enums.EtatMeteoType.Brouillard :
                            WinFormsApp2.Enums.EtatMeteoType.Verglas;

                controller.ChangerVehicule(typeVehicule);
                controller.ChangerConducteur(sexe, (int)spinAge.Value, checkPermis.Checked, checkAlcool.Checked, checkFatigue.Checked);
                controller.ChangerMeteo(meteo);
                controller.ChangerVitesse(sliderVitesse.Value);
                controller.ChangerDistanceMur(sliderDistance.Value);
                controller.ExecuterSimulation();

                // Vérifier s'il y a eu collision
                yaEuCollision = controller.YaEuCollision;

                // Afficher les données avec formatage
                StringBuilder sb = new StringBuilder();
                sb.AppendLine("=== RESULTAT DE SIMULATION ===");
                sb.AppendLine();

                string infos = controller.ObtenirInfos();
                foreach (var line in infos.Split('\n'))
                {
                    sb.AppendLine(line);
                }

                if (yaEuCollision)
                {
                    sb.AppendLine();
                    if (typeVehicule == WinFormsApp2.Enums.TypeVehicule.Avion)
                    {
                        sb.AppendLine(">>> ATTENTAT REUSSI <<<");
                    }
                    else
                    {
                        sb.AppendLine(">>> COLLISION DETECTEE <<<");
                    }
                }
                else
                {
                    sb.AppendLine();
                    sb.AppendLine(">>> PAS DE COLLISION <<<");
                }

                this.txtInfos.Text = sb.ToString();

                // Marquer la simulation comme exécutée
                simulationExecutee = true;

                // Redessiner
                this.vizPanel.Invalidate();
            };

            btnReset.Click += (s, e) =>
            {
                controller = new SimulationController();
                sliderVitesse.Value = 50;
                sliderDistance.Value = 200;
                lblVitesseVal.Text = "50 km/h";
                lblDistanceVal.Text = "200 m";
                this.txtInfos.Text = "En attente de simulation...";
                simulationExecutee = false;
                yaEuCollision = false;
                this.vizPanel.Invalidate();
            };
        }
    }
}
