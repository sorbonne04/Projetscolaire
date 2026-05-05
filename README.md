# Simulateur de Véhicules - WinForms .NET 9

Application WinForms pour simuler le comportement de différents types de véhicules sous diverses conditions météorologiques.

## ?? Fonctionnalités principales

### Simulation
- **Simulation physique réaliste** : Accélération, freinage, consommation de carburant
- **Différents types de véhicules** : Voiture, Autobus, Avion, Moto, Fauteuil Roulant
- **Conditions météorologiques** : Normal, Pluie, Brouillard, Neige
- **Tableaux statistiques** : Suivi de la vitesse, consommation, et distances parcourues

### Mode FUN (Easter Egg) ??
Activez le mode FUN pour une expérience amusante avec animations interactives :

#### Comment activer ?
1. Lancez l'application
2. Cliquez sur le bouton **"?? MODE FUN"** (en rose)
3. Cliquez sur **"?? SIMULER"** pour lancer l'animation

#### Qu'est-ce qui se passe ?
- **?? Avion** ? fonce dans les Tours Jumelles ??
- **?? BodyPositive** ? fonce dans le McDonald's ??
- **?? Petite Voiture** ? s'écrase dans le Parking ???
- **? Sportive** ? fonce dans le Mur de Briques ??
- **?? Fourgon** ? traverse la Fontaine ??

Animations d'explosion et résultats amusants en temps réel !

#### Retour à la normale
Cliquez à nouveau sur **"?? MODE FUN"** pour revenir à la simulation classique.

## ?? Architecture

```
WinFormsApp2/
??? Models/              # Modèles de données (Véhicule, Conducteur, etc.)
??? Views/               # Interfaces utilisateur
??? Services/            # Services métier (PhysicsEngine, Simulateur)
??? Controllers/         # Logique de contrôle
??? Enums/              # Énumérations (EtatMeteo, TypeVehicule)
??? Program.cs          # Point d'entrée
```

## ??? Dépendances

- .NET 9
- WinForms
- Classes standard .NET

## ?? Utilisation

1. Lancez l'application
2. Sélectionnez un type de véhicule et un conducteur
3. Configurez les conditions météorologiques
4. Cliquez sur "SIMULER" pour lancer la simulation

Optionnel : Activez le mode FUN pour un rendu amusant !

## ?? Structure du code

### Véhicules supportés
- `Voiture` : Véhicule terrestre standard
- `Autobus` : Transport public
- `Avion` : Transport aérien
- `Moto` : Deux-roues
- `FauteuilRoulant` : Mobilité réduite

### Conditions météorologiques
- Normal
- Pluie (réduit la vitesse de 20%)
- Brouillard (réduit la visibilité)
- Neige (réduit la vitesse de 30%)

## ?? Contrôles

- **SIMULER** : Lance la simulation
- **RÉINITIALISER** : Réinitialise les paramètres
- **?? MODE FUN** : Active/désactive le mode Easter Egg amusant

---

**Projet scolaire | .NET 9 | WinForms**
