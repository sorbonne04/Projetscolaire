    // Géré par : MARIUS
// Géré par : MARIUS

using WinFormsApp2.Enums;

namespace WinFormsApp2.Models
{
    public abstract class Vehicule
    {
        public double Poids { get; set; }
        public double Vitesse { get; set; }
        public double PositionX { get; set; }
        public TypeVehicule Type { get; set; }
        public double ModificateurFreinage { get; set; }

        public abstract float CalculerDistanceFreinage(float coefficientFriction, float vitesseInitiale);
        public abstract void DeclencherAccident();
        public abstract string ObtenirNom();

        public virtual void Freiner(float reduction)
        {
            Vitesse = Math.Max(0, Vitesse - reduction);
        }

        public virtual void Accelerer(float augmentation)
        {
            Vitesse += augmentation;
        }
    }
}
