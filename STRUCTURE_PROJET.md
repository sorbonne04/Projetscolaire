# ?? Structure du Projet - Répartition des Responsabilités

## ?? Répartition des Développeurs

| Développeur | Rôle | Fichiers |
|-------------|------|----------|
| **MARIUS** | Architecture/Physics | 7 fichiers |
| **ETHAN** | Métier/Business | 5 fichiers |
| **TARIK** | UI/UX | 2 fichiers |

---

## ?? Arborescence complète du projet

```
WinFormsApp2/
?
??? ?? Enums/                    # Énumérations
?   ??? EtatMeteo.cs            ? Sec, Pluie, Verglas (MARIUS)
?   ??? Sexe.cs                 ? Homme, Femme (ETHAN) ?? IMPORTANT: Double dégât femme ligne 27
?   ??? TypeVehicule.cs         ? Autobus, Avion, Voiture, Moto, FauteuilRoulant (MARIUS)
?
??? ?? Models/                   # Modèles métier
?   ??? Vehicule.cs             ? Classe abstraite (MARIUS)
?   ??? Moto.cs                 ? Héritage Vehicule (MARIUS)
?   ??? Voiture.cs              ? Héritage Vehicule (MARIUS)
?   ??? Autobus.cs              ? Héritage Vehicule (MARIUS)
?   ??? FauteuilRoulant.cs      ? Héritage Vehicule (MARIUS)
?   ??? Avion.cs                ? Héritage Vehicule (MARIUS)
?   ??? Environnement.cs        ? Gestion friction météo (MARIUS)
?   ??? Conducteur.cs           ? Sexe, Alcool, Permis, Age (ETHAN)
?
??? ?? Services/                 # Couche métier
?   ??? PhysicsEngine.cs        ? Calculs freinage (MARIUS)
?   ??? CollisionManager.cs     ? Détection collisions (TARIK)
?   ??? SimulateurService.cs    ? Logique globale (ETHAN)
?
??? ?? Controllers/              # Contrôleurs
?   ??? SimulationController.cs ? Lien Vue/Modèle (ETHAN)
?
??? ?? Views/                    # Interface graphique
?   ??? MainForm.cs             ? Fenêtre principale (TARIK)
?   ??? MainForm.resx           ? Ressources MainForm (TARIK)
?   ??? StatsPanel.cs           ? Panneau résultats (ETHAN)
?   ??? EasterEggForm.cs        ? Mode FUN (TARIK)
?
??? ?? Services/                 # Services spécialisés
?   ??? EasterEggUnlocker.cs    ? Logique Easter Egg (TARIK)
?
??? Program.cs                  ? Point d'entrée application
??? WinFormsApp2.csproj         ? Configuration projet
??? README.md                   ? Documentation principale
```

---

## ?? Détail par Développeur

### ?? **MARIUS** - Architecture & Physique (7 fichiers)

**Enums (2 fichiers):**
- `WinFormsApp2/Enums/EtatMeteo.cs`
- `WinFormsApp2/Enums/TypeVehicule.cs`

**Models (5 fichiers):**
- `WinFormsApp2/Models/Vehicule.cs` (classe abstraite)
- `WinFormsApp2/Models/Voiture.cs` (héritage)
- `WinFormsApp2/Models/Autobus.cs` (héritage)
- `WinFormsApp2/Models/Moto.cs` (héritage)
- `WinFormsApp2/Models/Environnement.cs` (gestion friction)

**Services (1 fichier):**
- `WinFormsApp2/Services/PhysicsEngine.cs` (calculs freinage)

---

### ?? **ETHAN** - Métier & Business (5 fichiers)

**Enums (1 fichier):**
- `WinFormsApp2/Enums/Sexe.cs`

**Models (1 fichier):**
- `WinFormsApp2/Models/Conducteur.cs` (logique conducteur + modificateurs)

**Services (1 fichier):**
- `WinFormsApp2/Services/SimulateurService.cs` (logique globale simulation)

**Controllers (1 fichier):**
- `WinFormsApp2/Controllers/SimulationController.cs` (lien Vue/Modèle)

**Views (1 fichier):**
- `WinFormsApp2/Views/StatsPanel.cs` (affichage statistiques)

---

### ?? **TARIK** - Interface & UX (2 fichiers)

**Views (3 fichiers):**
- `WinFormsApp2/Views/MainForm.cs` (fenêtre principale)
- `WinFormsApp2/Views/MainForm.resx` (ressources graphiques)
- `WinFormsApp2/Views/EasterEggForm.cs` (interface mode FUN)

**Services (1 fichier):**
- `WinFormsApp2/Services/CollisionManager.cs` (gestion collisions UI)
- `WinFormsApp2/Services/EasterEggUnlocker.cs` (logique Easter Egg)

---

## ?? Points Importants

### ?? Doublement de Dégât pour les Femmes
**Fichier:** `WinFormsApp2/Models/Conducteur.cs` (ETHAN)
**Ligne:** 27
```csharp
double taux = Sexe == Sexe.Homme ? 5.0 : 10.0;
```
**Explications:**
- Taux d'accident hommes: `5.0`
- Taux d'accident femmes: `10.0` (DOUBLE)
- Modifiée également par d'autres facteurs (alcool, fatigue, permis, âge)

---

## ?? Technologies

- **Framework:** .NET 9
- **UI:** WinForms
- **Architecture:** MVC Pattern
- **Repository:** GitHub (https://github.com/sorbienne04/Projetscolaire)

---

## ?? Historique des Commits

```
e658f83 - Add developer assignments: MARIUS, ETHAN, TARIK to all files
c56fa42 - Remove additional documentation files from WinFormsApp2
416f123 - Fix: Remove corrupted text in MainForm namespace
3fda6a9 - Clean up: Remove unnecessary documentation files, keep only main README
3f365d7 - Update project with latest changes and documentation
```

---

**Dernier update:** 2024 | **Projet:** Simulateur de Véhicules | **.NET:** 9 | **Statut:** ? Compilé et Synchronisé
