// Géré par : MARIUS

using WinFormsApp2.Enums;

namespace WinFormsApp2.Models
{
    public class Avion : Vehicule
    {
        private const double POIDS_STANDARD = 73000.0;
        private const double MODIFICATEUR_FREINAGE = 0.5;

        public Avion()
        {
            Type = TypeVehicule.Avion;
            Poids = POIDS_STANDARD;
            Vitesse = 0;
            PositionX = 0;
            ModificateurFreinage = MODIFICATEUR_FREINAGE;
        }

        public override float CalculerDistanceFreinage(float coefficientFriction, float vitesseInitiale)
        {
            float vitesseMs = vitesseInitiale / 3.6f;
            float distanceFreinage = (vitesseMs * vitesseMs) / (2 * 5.0f);
            
            return (float)(distanceFreinage * ModificateurFreinage);
        }

        public override void DeclencherAccident()
        {
            Vitesse = 0;
            PositionX = 0;
        }

        public override string ObtenirNom() => "Avion";
    }
}
