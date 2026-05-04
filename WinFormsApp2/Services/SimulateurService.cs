using WinFormsApp2.Models;
using WinFormsApp2.Models;
using WinFormsApp2.Enums;

namespace WinFormsApp2.Services
{
    public class SimulateurService
    {
        private Vehicule vehicule;
        private Conducteur conducteur;
        private Environnement environnement;
        private PhysicsEngine physicsEngine;
        private Random random;

        public float DistanceMur { get; set; }
        public float DistanceRestante { get; private set; }
        public bool YaEuCollision { get; private set; }
        public int NombreSimulations { get; private set; }
        public int NombreAccidents { get; private set; }
        public float Adherence { get; set; } = 1.0f;
        public float TempsReaction { get; set; } = 1.0f;
        public float EfficaciteFreins { get; set; } = 1.0f;

        public SimulateurService()
        {
            random = new Random();
            InitialiserSimulation();
        }

        public void InitialiserSimulation()
        {
            vehicule = new Voiture();
            conducteur = new Conducteur();
            environnement = new Environnement();
            physicsEngine = new PhysicsEngine(environnement);
            DistanceMur = 200f;
            NombreSimulations = 0;
            NombreAccidents = 0;
        }

        public void ChangerVehicule(TypeVehicule type)
        {
            vehicule = type switch
            {
                TypeVehicule.Voiture => new Voiture(),
                TypeVehicule.Moto => new Moto(),
                TypeVehicule.Autobus => new Autobus(),
                TypeVehicule.Avion => new Avion(),
                TypeVehicule.FauteuilRoulant => new FauteuilRoulant(),
                _ => new Voiture()
            };
        }

        public void ChangerConducteur(Sexe sexe, int age, bool aLePermis, bool alcoolise, bool fatigue)
        {
            conducteur = new Conducteur(
                nom: $"{sexe}_{age}ans",
                sexe: sexe,
                aLePermis: aLePermis,
                estAlcoolise: alcoolise,
                estFatigue: fatigue,
                age: age
            );
        }

        public void ChangerMeteo(EtatMeteoType meteo)
        {
            environnement.ChangerMeteo(meteo);
        }

        public void DefinirVitesse(float vitesse)
        {
            vehicule.Vitesse = vitesse;
        }

        public void DefinirDistanceMur(float distance)
        {
            DistanceMur = distance;
        }

        public void DefinirAdherence(float adherence)
        {
            Adherence = Math.Max(0.1f, Math.Min(2.0f, adherence));
        }

        public void DefinirTempsReaction(float temps)
        {
            TempsReaction = Math.Max(0.5f, Math.Min(5.0f, temps));
        }

        public void DefinirEfficaciteFreins(float efficacite)
        {
            EfficaciteFreins = Math.Max(0.1f, Math.Min(2.0f, efficacite));
        }

        public void SimulerFreinage()
        {
            NombreSimulations++;
            YaEuCollision = physicsEngine.VerifierCollisionMur(vehicule, conducteur, DistanceMur, out float distanceRestante);
            DistanceRestante = distanceRestante;

            if (YaEuCollision)
            {
                NombreAccidents++;
                vehicule.DeclencherAccident();
            }
        }

        public double CalculerTauxAccident()
        {
            double taux = conducteur.TauxAccidentBase;
            taux *= conducteur.CalculerModificateurConducteur();
            taux *= environnement.ObtenirTauxAccidentMultiplicateur();
            return Math.Min(100, taux);
        }

        public string ObtenirInfosSimulation()
        {
            float distanceFreinage = physicsEngine.CalculerDistanceFrainagetotale(vehicule, conducteur) * EfficaciteFreins;
            return $"Véhicule: {vehicule.ObtenirNom()}\n" +
                   $"Vitesse: {vehicule.Vitesse:F1} km/h\n" +
                   $"Distance freinage: {distanceFreinage:F2}m\n" +
                   $"Distance mur: {DistanceMur:F2}m\n" +
                   $"Distance restante: {DistanceRestante:F2}m\n" +
                   $"Conducteur: {conducteur.ObtenirDescription()}\n" +
                   $"Météo: {environnement.EtatMeteoActuel.Description}\n" +
                   $"Adhérence: {Adherence:F2}x\n" +
                   $"Temps réaction: {TempsReaction:F2}s\n" +
                   $"Efficacité freins: {EfficaciteFreins:F2}x\n" +
                   $"Taux accident: {CalculerTauxAccident():F1}%";
        }

        public string ObtenirStatistiques()
        {
            double tauxAccidents = NombreSimulations > 0 ? (NombreAccidents * 100.0 / NombreSimulations) : 0;
            return $"Simulations: {NombreSimulations}\n" +
                   $"Accidents: {NombreAccidents}\n" +
                   $"Taux réel: {tauxAccidents:F1}%\n" +
                   $"Conducteur: {conducteur.ObtenirDescription()}\n" +
                   $"Véhicule: {vehicule.ObtenirNom()}";
        }
    }
}
