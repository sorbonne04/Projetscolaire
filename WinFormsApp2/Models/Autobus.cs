// Géré par : MARIUS

using WinFormsApp2.Enums;

namespace WinFormsApp2.Models
{
    public class Autobus : Vehicule
    {
        private const float GRAVITE = 9.81f;
        private const double POIDS_STANDARD = 12000.0;
        private const double MODIFICATEUR_FREINAGE = 1.3;

        public Autobus()
        {
            Type = TypeVehicule.Autobus;
            Poids = POIDS_STANDARD;
            Vitesse = 0;
            PositionX = 0;
            ModificateurFreinage = MODIFICATEUR_FREINAGE;
        }

        public override float CalculerDistanceFreinage(float coefficientFriction, float vitesseInitiale)
        {
            if (coefficientFriction <= 0 || vitesseInitiale < 0)
                return 0;

            float vitesseMs = vitesseInitiale / 3.6f;
            float distanceFreinage = (vitesseMs * vitesseMs) / (2 * GRAVITE * coefficientFriction);
            
            return (float)(distanceFreinage * ModificateurFreinage);
        }

        public override void DeclencherAccident()
        {
            Vitesse = 0;
            PositionX = 0;
        }

        public override string ObtenirNom() => "Autobus";
    }
}
