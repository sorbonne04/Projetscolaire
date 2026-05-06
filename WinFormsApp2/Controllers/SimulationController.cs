// Géré par : ETHAN
// Géré par : ETHAN

using WinFormsApp2.Models;
using WinFormsApp2.Services;
using WinFormsApp2.Enums;

namespace WinFormsApp2.Controllers
{
    public class SimulationController
    {
        private SimulateurService simulateurService;

        public event EventHandler OnSimulationChanged;

        public SimulationController()
        {
            simulateurService = new SimulateurService();
        }

        // Nouveau: accès au service pour Easter Egg
        public SimulateurService GetSimulateurService()
        {
            return simulateurService;
        }

        public void ChangerVehicule(TypeVehicule type)
        {
            simulateurService.ChangerVehicule(type);
            OnSimulationChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ChangerConducteur(Sexe sexe, int age, bool aLePermis, bool alcoolise, bool fatigue)
        {
            simulateurService.ChangerConducteur(sexe, age, aLePermis, alcoolise, fatigue);
            OnSimulationChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ChangerMeteo(EtatMeteoType meteo)
        {
            simulateurService.ChangerMeteo(meteo);
            OnSimulationChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ChangerVitesse(float vitesse)
        {
            simulateurService.DefinirVitesse(vitesse);
            OnSimulationChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ChangerDistanceMur(float distance)
        {
            simulateurService.DefinirDistanceMur(distance);
            OnSimulationChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ChangerAdherence(float adherence)
        {
            simulateurService.DefinirAdherence(adherence);
            OnSimulationChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ChangerTempsReaction(float temps)
        {
            simulateurService.DefinirTempsReaction(temps);
            OnSimulationChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ChangerEfficaciteFreins(float efficacite)
        {
            simulateurService.DefinirEfficaciteFreins(efficacite);
            OnSimulationChanged?.Invoke(this, EventArgs.Empty);
        }

        public void ExecuterSimulation()
        {
            simulateurService.SimulerFreinage();
            OnSimulationChanged?.Invoke(this, EventArgs.Empty);
        }

        public string ObtenirInfos() => simulateurService.ObtenirInfosSimulation();
        public string ObtenirStatistiques() => simulateurService.ObtenirStatistiques();
        public bool YaEuCollision => simulateurService.YaEuCollision;
        public float DistanceRestante => simulateurService.DistanceRestante;
    }
}

