# 🚗 WinForms Crash Test Simulator

Un simulateur d'accidents et de freinage développé en **C# WinForms** avec architecture **MVC**.

## 📋 Architecture du Projet

```
WinFormsApp2/
├── Enums/                    # Énumérations (MARIUS)
│   ├── EtatMeteo.cs         → Sec, Pluie, Verglas
│   ├── Sexe.cs              → Homme, Femme (ETHAN)
│   └── TypeVehicule.cs      → Autobus, Avion, Voiture, Moto, FauteuilRoulant
│
├── Models/                   # Modèles métier (MARIUS)
│   ├── Vehicule.cs          → Classe abstraite
│   ├── Moto.cs              → Héritage
│   ├── Voiture.cs           → Héritage
│   ├── Autobus.cs           → Héritage
│   ├── FauteuilRoulant.cs   → Héritage
│   ├── Avion.cs             → Héritage
│   ├── Environnement.cs     → Gestion friction météo
│   └── Conducteur.cs        → Sexe, Alcool, Permis (ETHAN)
│
├── Services/                 # Couche métier
│   ├── PhysicsEngine.cs     → Calculs freinage (MARIUS)
│   ├── CollisionManager.cs  → Détection collisions (TARIK)
│   └── SimulateurService.cs → Logique globale (ETHAN)
│
├── Controllers/              # Contrôleurs
│   └── SimulationController.cs → Lien Vue/Modèle (ETHAN)
│
└── Views/                    # Interface graphique (TARIK)
    ├── MainForm.cs          → Fenêtre principale
    ├── DashboardControl.cs  → Panel sliders
    └── StatsPanel.cs        → Résultats (ETHAN)
```

## 🎯 Répartition des Responsabilités

| Développeur | Rôle | Fichiers |
|-------------|------|----------|
| **MARIUS** | Architecture/Physics | Enums (EtatMeteo, TypeVehicule), Models (Vehicule + enfants, Environnement), PhysicsEngine |
| **ETHAN** | Métier/Business | Enums (Sexe), Models (Conducteur), Services, Controllers, Views (StatsPanel) |
| **TARIK** | UI/UX | Views (MainForm, DashboardControl), CollisionManager |

## 🚀 Mise en Démarrage

### Prérequis
- **.NET 10** ou supérieur
- **Visual Studio 2022** Community Edition
- **Windows** (WinForms)

### Installation
```bash
git clone https://github.com/sorbienne04/Projetscolaire.git
cd WinFormsApp2
```

### Compilation
```bash
dotnet build
```

### Exécution
```bash
dotnet run
```

## 📝 Règles Métier

### Taux d'Accident
- **Homme** : 5%
- **Femme** : 10%
- **Sans Permis** : ×2

### Coefficient de Friction (Météo)
- **Sec** : 0.8
- **Pluie** : 0.4
- **Verglas** : 0.1

## 📚 Documentation

### Classe Vehicule (Abstraite)
```csharp
public abstract class Vehicule
{
    public double Poids { get; set; }
    public double Vitesse { get; set; }
    public double PositionX { get; set; }

    public abstract float CalculerDistanceFreinage(float coefficientFriction, float vitesseInitiale);
    public abstract void DeclencherAccident();
}
```

### Classe Conducteur
```csharp
public class Conducteur
{
    public Sexe Sexe { get; set; }
    public bool EstAlcoolise { get; set; }
    public bool ALePermis { get; set; }
    public double TauxAccidentBase { get; }
}
```

## 🔧 Technologies Utilisées

- **Langage** : C# 12
- **Framework** : .NET 10
- **UI** : Windows Forms
- **Architecture** : Model-View-Controller (MVC)
- **Versioning** : Git/GitHub

## 📞 Contact

**Équipe de développement**
- Marius - Architecture/Physics
- Ethan - Business Logic
- Tarik - UI/UX

---

**Dernier commit** : Initial commit - Architecture MVC complète
**Branche actuelle** : `main`
