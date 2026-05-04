    // Géré par : MARIUS

using WinFormsApp2.Enums;

namespace WinFormsApp2.Models
{
    public class Environnement
    {
        public EtatMeteo EtatMeteoActuel { get; set; }
        public double Temperature { get; set; }
        public double Visibilite { get; set; }
        public double VitesseVent { get; set; }

        public Environnement()
        {
            EtatMeteoActuel = EtatMeteo.ObtenirEtat(EtatMeteoType.Sec);
            Temperature = 20.0;
            Visibilite = 1000.0;
            VitesseVent = 0;
        }

        public void ChangerMeteo(EtatMeteoType type)
        {
            EtatMeteoActuel = EtatMeteo.ObtenirEtat(type);
            
            switch (type)
            {
                case EtatMeteoType.Sec:
                    Temperature = 20.0;
                    Visibilite = 1000.0;
                    VitesseVent = 5.0;
                    break;
                case EtatMeteoType.Pluie:
                    Temperature = 15.0;
                    Visibilite = 400.0;
                    VitesseVent = 15.0;
                    break;
                case EtatMeteoType.Verglas:
                    Temperature = -5.0;
                    Visibilite = 300.0;
                    VitesseVent = 25.0;
                    break;
                case EtatMeteoType.Brouillard:
                    Temperature = 10.0;
                    Visibilite = 100.0;
                    VitesseVent = 5.0;
                    break;
                case EtatMeteoType.Neige:
                    Temperature = -2.0;
                    Visibilite = 200.0;
                    VitesseVent = 20.0;
                    break;
            }
        }

        public double ObtenirCoefficientFriction() => EtatMeteoActuel.CoefficientFriction;
        
        public double ObtenirTauxAccidentMultiplicateur() => EtatMeteoActuel.TauxAccidentMultiplicateur;
        
        public string ObtenirDescription() => 
            $"Météo: {EtatMeteoActuel.Description} | Temp: {Temperature}°C | Visibilité: {Visibilite}m | Vent: {VitesseVent} km/h";
    }
}
