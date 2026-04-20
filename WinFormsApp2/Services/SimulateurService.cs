// Géré par : ETHAN

using WinFormsApp2.Models;

namespace WinFormsApp2.Services
{
    public class SimulateurService
    {
        public Vehicule VehiculeActuel { get; set; }
        public Conducteur ConducteurActuel { get; set; }
        public Environnement EnvironnementActuel { get; set; }

        public void LancerSimulation()
        {
            throw new NotImplementedException();
        }

        public double CalculerRisqueGlobal()
        {
            throw new NotImplementedException();
        }
    }
}
