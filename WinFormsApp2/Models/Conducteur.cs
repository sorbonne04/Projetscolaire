using WinFormsApp2.Enums;

namespace WinFormsApp2.Models
{
    public class Conducteur
    {
        public Sexe Sexe { get; set; }
        public bool EstAlcoolise { get; set; }
        public bool ALePermis { get; set; }
        public bool EstFatigue { get; set; }
        public int Age { get; set; }
        public string Nom { get; set; }

        public Conducteur(string nom = "Conducteur", Sexe sexe = Sexe.Homme, bool aLePermis = true, bool estAlcoolise = false, bool estFatigue = false, int age = 30)
        {
            Nom = nom;
            Sexe = sexe;
            ALePermis = aLePermis;
            EstAlcoolise = estAlcoolise;
            EstFatigue = estFatigue;
            Age = age;
        }

        public double TauxAccidentBase
        {
            get
            {
                double taux = Sexe == Sexe.Homme ? 5.0 : 10.0;
                if (!ALePermis)
                    taux *= 2.0;
                return taux;
            }
        }

        public double CalculerModificateurConducteur()
        {
            double modificateur = 1.0;

            if (EstAlcoolise)
                modificateur *= 1.5;

            if (EstFatigue)
                modificateur *= 1.3;

            if (!ALePermis)
                modificateur *= 1.4;

            if (Age < 25 || Age > 65)
                modificateur *= 1.2;

            return modificateur;
        }

        public string ObtenirDescription()
        {
            string desc = $"{Sexe} | {(ALePermis ? "? Permis" : "? Sans permis")} | {Age} ans";
            if (EstAlcoolise) desc += " | ?? Alcool";
            if (EstFatigue) desc += " | ?? Fatigue";
            return desc;
        }
    }
}
