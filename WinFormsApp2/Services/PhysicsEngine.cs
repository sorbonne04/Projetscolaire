// Géré par : MARIUS

using WinFormsApp2.Models;
using WinFormsApp2.Enums;

namespace WinFormsApp2.Services
{
    public class PhysicsEngine
    {
        private const float GRAVITE = 9.81f;
        private const float TEMPS_SIMULATION = 0.016f;

        private Environnement environnement;

        public PhysicsEngine(Environnement environnement)
        {
            this.environnement = environnement ?? throw new ArgumentNullException(nameof(environnement));
        }

        public float CalculerDistanceFreinage(Vehicule vehicule)
        {
            float coefficientFriction = (float)environnement.ObtenirCoefficientFriction();
            float vitesse = (float)vehicule.Vitesse;
            
            return vehicule.CalculerDistanceFreinage(coefficientFriction, vitesse);
        }

        public float CalculerDistanceFrainagetotale(Vehicule vehicule, Conducteur conducteur)
        {
            float distancePhysique = CalculerDistanceFreinage(vehicule);

            double modificateurVehicule = vehicule.ModificateurFreinage;
            double modificateurConducteur = conducteur.CalculerModificateurConducteur();
            double modificateurMeteo = environnement.ObtenirCoefficientFriction();

            float distanceFinal = (float)(distancePhysique * modificateurVehicule * modificateurConducteur * modificateurMeteo);

            return distanceFinal;
        }

        public bool VerifierCollisionMur(Vehicule vehicule, Conducteur conducteur, float distanceMur, out float distanceRestante)
        {
            float distanceFrainagetotale = CalculerDistanceFrainagetotale(vehicule, conducteur);
            distanceRestante = distanceMur - distanceFrainagetotale;
            
            return distanceRestante < 0;
        }

        public bool SimulerFreinageUrgence(Vehicule vehicule, Conducteur conducteur, float distanceObstacle, out float distanceArret)
        {
            distanceArret = CalculerDistanceFrainagetotale(vehicule, conducteur);
            return distanceArret > distanceObstacle;
        }

        public void MettreAJourPosition(Vehicule vehicule)
        {
            float vitesseMs = (float)vehicule.Vitesse / 3.6f;
            float distance = vitesseMs * TEMPS_SIMULATION;
            vehicule.PositionX += distance;
        }

        public void Accelerer(Vehicule vehicule, float acceleration)
        {
            vehicule.Vitesse += acceleration * TEMPS_SIMULATION;
        }

        public void Freiner(Vehicule vehicule, float deceleration)
        {
            vehicule.Vitesse = Math.Max(0, vehicule.Vitesse - (deceleration * TEMPS_SIMULATION));
        }

        public string ObtenirInfosPhysiques(Vehicule vehicule, Conducteur conducteur)
        {
            float distanceFreinage = CalculerDistanceFreinage(vehicule);
            float distanceFinal = CalculerDistanceFrainagetotale(vehicule, conducteur);
            
            return $"{vehicule.ObtenirNom()} | {conducteur.ObtenirDescription()}\n" +
                   $"Vitesse={vehicule.Vitesse:F1} km/h | Distance base={distanceFreinage:F2}m | Distance finale={distanceFinal:F2}m";
        }

        public void ChangerEnvironnement(Environnement nouvelEnvironnement)
        {
            environnement = nouvelEnvironnement ?? throw new ArgumentNullException(nameof(nouvelEnvironnement));
        }
    }
}
