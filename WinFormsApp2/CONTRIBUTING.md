# 🤝 Guide de Contribution - WinForms Crash Test Simulator

Bienvenue dans le projet ! Ce guide explique comment cloner, configurer et contribuer au simulateur de freinage.

## 📥 Installation du Projet

### Prérequis
- **Git** installé : https://git-scm.com/
- **.NET 10** SDK : https://dotnet.microsoft.com/download
- **Visual Studio 2022+** Community Edition

### 1️⃣ Cloner le repository

#### Option A : Via Git Command Line
```bash
git clone https://github.com/sorbonne04/Projetscolaire.git
cd Projetscolaire/WinFormsApp2
```

#### Option B : Via Visual Studio
1. Ouvrez **Visual Studio 2026**
2. **File** → **Clone Repository**
3. URL : `https://github.com/sorbonne04/Projetscolaire.git`
4. **Clone** et attendez

#### Option C : Télécharger en ZIP
1. https://github.com/sorbonne04/Projetscolaire
2. Cliquez **Code** → **Download ZIP**
3. Décompressez le dossier

### 2️⃣ Ouvrir le projet

```bash
# Visual Studio
double-click WinFormsApp2.sln

# Ou via terminal
dotnet open WinFormsApp2.sln
```

### 3️⃣ Compiler et tester

```bash
# Compiler
dotnet build

# Exécuter
dotnet run

# Tests (quand ajoutés)
dotnet test
```

---

## 👥 Répartition des Tâches

### 🔴 **MARIUS** - Architecture & Physics
```
Fichiers responsabilité :
├── Enums/
│   ├── EtatMeteo.cs
│   └── TypeVehicule.cs
├── Models/
│   ├── Vehicule.cs (classe abstraite)
│   ├── Moto.cs
│   ├── Voiture.cs
│   ├── Autobus.cs
│   ├── FauteuilRoulant.cs
│   ├── Avion.cs
│   └── Environnement.cs
└── Services/
    └── PhysicsEngine.cs

Tâches :
- Implémenter CalculerDistanceFreinage() pour chaque véhicule
- Développer PhysicsEngine (calculs de freinage)
- Gérer les coefficients de friction selon météo
```

### 🔵 **ETHAN** - Business Logic & Controllers
```
Fichiers responsabilité :
├── Enums/
│   └── Sexe.cs
├── Models/
│   └── Conducteur.cs
├── Services/
│   └── SimulateurService.cs
├── Controllers/
│   └── SimulationController.cs
└── Views/
    └── StatsPanel.cs

Tâches :
- Implémenter TauxAccidentBase (Conducteur)
- Développer SimulateurService (logique globale)
- Créer SimulationController (lien Vue-Modèle)
- Designer StatsPanel (affichage résultats)
```

### 🟢 **TARIK** - UI/UX & Collisions
```
Fichiers responsabilité :
├── Services/
│   └── CollisionManager.cs
└── Views/
    ├── MainForm.cs
    └── DashboardControl.cs

Tâches :
- Développer CollisionManager (détection collisions)
- Designer MainForm (fenêtre principale)
- Créer DashboardControl (sliders et contrôles)
```

---

## 🔄 Workflow Git

### Créer une branche de travail

```bash
# Mettre à jour main
git checkout main
git pull origin main

# Créer une branche pour votre tâche
git checkout -b feature/nom-feature
# Exemple : git checkout -b feature/physics-engine
```

### Commiter vos changements

```bash
# Voir les modifications
git status

# Ajouter vos fichiers
git add .

# Commiter avec message clair
git commit -m "feat: Implement CalculerDistanceFreinage for Moto"

# Push vers GitHub
git push origin feature/nom-feature
```

### Créer une Pull Request (PR)

1. Allez sur GitHub : https://github.com/sorbonne04/Projetscolaire
2. Cliquez sur **Pull requests**
3. Cliquez **New pull request**
4. Sélectionnez votre branche
5. Décrivez vos changements
6. Attendez la review des autres

### Mettre à jour votre branche

```bash
# Si main a été mis à jour
git fetch origin
git rebase origin/main
git push origin feature/nom-feature -f
```

---

## 📋 Convention de Commit

Format : `type(scope): description`

### Types autorisés
- **feat** : Nouvelle fonctionnalité
- **fix** : Correction de bug
- **refactor** : Restructuration code
- **docs** : Documentation
- **test** : Ajout de tests
- **style** : Formatage, pas de logic

### Exemples valides
```
feat(models): Add Vehicule abstract class
fix(physics): Correct friction calculation
docs(readme): Update installation steps
refactor(services): Simplify SimulateurService logic
```

---

## 📁 Structure du Projet

```
WinFormsApp2/
├── Enums/                          # Énumérations globales
│   ├── EtatMeteo.cs                → MARIUS
│   ├── Sexe.cs                     → ETHAN
│   └── TypeVehicule.cs             → MARIUS
│
├── Models/                         # Modèles métier
│   ├── Vehicule.cs                 → MARIUS (abstrait)
│   ├── Moto.cs, Voiture.cs, ...    → MARIUS (héritage)
│   ├── Environnement.cs            → MARIUS
│   └── Conducteur.cs               → ETHAN
│
├── Services/                       # Couche métier
│   ├── PhysicsEngine.cs            → MARIUS
│   ├── CollisionManager.cs         → TARIK
│   └── SimulateurService.cs        → ETHAN
│
├── Controllers/                    # Contrôleurs
│   └── SimulationController.cs     → ETHAN
│
├── Views/                          # Interface graphique
│   ├── MainForm.cs                 → TARIK
│   ├── DashboardControl.cs         → TARIK
│   └── StatsPanel.cs               → ETHAN
│
├── .gitignore                      # Fichiers ignorés
├── README.md                       # Documentation
└── CONTRIBUTING.md                 # Ce fichier
```

---

## ✅ Règles de Qualité Code

1. **Nommage** : PascalCase pour classes/méthodes, camelCase pour variables
2. **Commentaires** : Expliquez le "pourquoi", pas le "quoi"
3. **Tests** : Testez localement avant de push
4. **Format** : Utilisez Ctrl+K+D dans Visual Studio pour formater
5. **Responsabilité** : Restez dans votre domaine (Enums, Models, Services assignés)

---

## 🐛 Signaler un Bug

1. Allez sur **Issues** : https://github.com/sorbonne04/Projetscolaire/issues
2. Cliquez **New issue**
3. Décrivez le problème avec :
   - Description claire
   - Étapes de reproduction
   - Résultat attendu vs actuel

---

## 📞 Support

**Questions ?** Contactez l'équipe :
- **MARIUS** : Architecture & Physics
- **ETHAN** : Business Logic & Controllers
- **TARIK** : UI/UX & Collisions

---

**Dernière mise à jour** : GitHub Copilot
**Projet** : WinForms Crash Test Simulator v1.0
**Framework** : .NET 10 + Windows Forms
