// Géré par : ETHAN

using WinFormsApp2.Enums;

namespace WinFormsApp2.Models
{
    
    /// Règle métier : Homme = 5%, Femme = 10%. Si ALePermis est false, le taux est multiplié par 2.
    
    public class Conducteur
    {
        public Sexe Sexe { get; set; }
        public bool EstAlcoolise { get; set; }
        public bool ALePermis { get; set; }

        public double TauxAccidentBase
        {
            get
            {
                throw new NotImplementedException();
            }
        }
    }
}
