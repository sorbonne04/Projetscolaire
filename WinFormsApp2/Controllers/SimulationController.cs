// Géré par : ETHAN

using WinFormsApp2.Services;

namespace WinFormsApp2.Controllers
{
    public class SimulationController
    {
        private readonly SimulateurService _simulateurService;

        public SimulationController(SimulateurService simulateurService)
        {
            _simulateurService = simulateurService;
        }

        public void DemarrerSimulation()
        {
            throw new NotImplementedException();
        }

        public void ArreterSimulation()
        {
            throw new NotImplementedException();
        }
    }
}
