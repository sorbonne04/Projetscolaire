// Géré par : MARIUS

namespace WinFormsApp2.Enums
{
    public enum EtatMeteoType
    {
        Sec,
        Pluie,
        Verglas,
        Brouillard,
        Neige
    }

    public class EtatMeteo
    {
        public EtatMeteoType Type { get; }
        public double CoefficientFriction { get; }
        public double TauxAccidentMultiplicateur { get; }
        public string Description { get; }

        private EtatMeteo(EtatMeteoType type, double coefficientFriction, double tauxAccidentMultiplicateur, string description)
        {
            Type = type;
            CoefficientFriction = coefficientFriction;
            TauxAccidentMultiplicateur = tauxAccidentMultiplicateur;
            Description = description;
        }

        public static EtatMeteo ObtenirEtat(EtatMeteoType type) => type switch
        {
            EtatMeteoType.Sec => new EtatMeteo(
                EtatMeteoType.Sec,
                coefficientFriction: 0.8,
                tauxAccidentMultiplicateur: 1.0,
                "Conditions sèches - Adhérence optimale"
            ),
            EtatMeteoType.Pluie => new EtatMeteo(
                EtatMeteoType.Pluie,
                coefficientFriction: 0.4,
                tauxAccidentMultiplicateur: 1.5,
                "Pluie - Adhérence réduite de 50% (+50% accidents)"
            ),
            EtatMeteoType.Verglas => new EtatMeteo(
                EtatMeteoType.Verglas,
                coefficientFriction: 0.1,
                tauxAccidentMultiplicateur: 3.0,
                "Verglas - Route très glissante (+200% accidents)"
            ),
            EtatMeteoType.Brouillard => new EtatMeteo(
                EtatMeteoType.Brouillard,
                coefficientFriction: 0.6,
                tauxAccidentMultiplicateur: 2.0,
                "Brouillard - Visibilité réduite (+100% accidents)"
            ),
            EtatMeteoType.Neige => new EtatMeteo(
                EtatMeteoType.Neige,
                coefficientFriction: 0.15,
                tauxAccidentMultiplicateur: 2.5,
                "Neige - Conditions dangereuses (+150% accidents)"
            ),
            _ => throw new ArgumentException("État météo inconnu")
        };

        public override string ToString() => Description;
    }
}
