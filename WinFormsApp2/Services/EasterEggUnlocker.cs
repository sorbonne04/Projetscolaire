using WinFormsApp2.Models;
using WinFormsApp2.Enums;

namespace WinFormsApp2.Services
{
    public class EasterEggUnlocker
    {
        // Conditions pour débloquer l'easter egg
        public int MinimumSimulations { get; set; } = 10;
        public int MinimumSuccessfulStops { get; set; } = 5;
        public int MinimumAgeDriver { get; set; } = 30;
        public TypeVehicule TargetVehicule { get; set; } = TypeVehicule.Avion;

        private SimulateurService simulateurService;
        public bool IsUnlocked { get; private set; } = false;
        public string UnlockMessage { get; private set; } = "";

        public EasterEggUnlocker(SimulateurService service)
        {
            simulateurService = service;
        }

        public bool CheckUnlockConditions()
        {
            // Condition 1: Au moins X simulations
            if (simulateurService.NombreSimulations < MinimumSimulations)
                return false;

            // Condition 2: Au moins X arrêts réussis (pas d'accidents)
            int successfulStops = simulateurService.NombreSimulations - simulateurService.NombreAccidents;
            if (successfulStops < MinimumSuccessfulStops)
                return false;

            // Condition 3: Conducteur assez âgé
            // Ce serait à récupérer du conducteur courant

            // Condition 4: Avoir utilisé l'avion
            // Ce serait à tracker

            IsUnlocked = true;
            UpdateUnlockMessage();
            return true;
        }

        public void UpdateUnlockMessage()
        {
            if (IsUnlocked)
            {
                UnlockMessage = "?? EASTER EGG DÉBLOQUÉ! ??\n" +
                    "Vous avez déverrouillé un mode spécial!\n" +
                    "Clique sur le bouton mystérieux pour le découvrir!";
            }
        }

        public bool ShouldShowEasterEggButton()
        {
            return CheckUnlockConditions();
        }

        public string GetProgressMessage()
        {
            int successfulStops = simulateurService.NombreSimulations - simulateurService.NombreAccidents;

            return $"Progrès déverrouillage:\n" +
                   $"Simulations: {simulateurService.NombreSimulations}/{MinimumSimulations}\n" +
                   $"Arrêts réussis: {successfulStops}/{MinimumSuccessfulStops}\n" +
                   $"Statut: {(IsUnlocked ? "?? DÉBLOQUÉ!" : "?? Verrouillé")}";
        }
    }
}
