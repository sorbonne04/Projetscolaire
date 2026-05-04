// Géré par : MARIUS

using WinFormsApp2.Enums;

namespace WinFormsApp2.Models
{
    public class Moto : Vehicule
    {
        private const float GRAVITE = 9.81f;
        private const double POIDS_STANDARD = 250.0;
        private const double MODIFICATEUR_FREINAGE = 0.85;

        public Moto()
        {
            Type = TypeVehicule.Moto;
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
            
            return (float)(distanceFreinage * MODIFICATEUR_FREINAGE);
        }

        public override void DeclencherAccident()
        {
            Vitesse = 0;
            PositionX = 0;
        }

        public override string ObtenirNom() => "Moto";
    }
}
