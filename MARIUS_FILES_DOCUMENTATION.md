# ?? Documentation complète - Fichiers MARIUS

## ?? Vue d'ensemble
MARIUS gère l'**architecture et la physique** du simulateur. Ses 10 fichiers couvrent :
- Les énumérations de base
- La hiérarchie des véhicules
- Les calculs de physique
- La gestion de la météo

---

## ?? FICHIERS DÉTAILLÉS

### 1?? **EtatMeteo.cs** - Gestion de la météo

**Localisation** : `WinFormsApp2/Enums/EtatMeteo.cs`

**Contenu** :
```csharp
public enum EtatMeteoType
{
    Sec,           // ?? Adhérence normale
    Pluie,         // ??? Adhérence réduite
    Verglas,       // ?? Route glissante
    Brouillard,    // ??? Visibilité réduite
    Neige          // ?? Très glissant
}

public class EtatMeteo
{
    public double CoefficientFriction;        // Adhérence de la route
    public double TauxAccidentMultiplicateur; // Impact sur accidents
    public string Description;                // Description texte
}
```

**Coefficients de friction** :
| État | Friction | Multiplicateur accidents |
|------|----------|------------------------|
| Sec | 0.8 | 1.0× |
| Pluie | 0.4 | 1.5× |
| Verglas | 0.1 | 3.0× |
| Brouillard | 0.6 | 2.0× |
| Neige | 0.15 | 2.5× |

**Rôle** : Définir les conditions de route qui affectent la physique

---

### 2?? **TypeVehicule.cs** - Énumération des types

**Localisation** : `WinFormsApp2/Enums/TypeVehicule.cs`

**Contenu** :
```csharp
public enum TypeVehicule
{
    Autobus,           // Bus de transport
    Avion,             // Avion (Easter Egg)
    Voiture,           // Berline
    Moto,              // Deux-roues
    FauteuilRoulant    // PMR
}
```

**Rôle** : Liste tous les types de véhicules disponibles

---

### 3?? **Vehicule.cs** - Classe abstraite de base

**Localisation** : `WinFormsApp2/Models/Vehicule.cs`

**Propriétés** :
```csharp
public abstract class Vehicule
{
    public double Poids;                    // En kg
    public double Vitesse;                  // En km/h
    public double PositionX;                // Position X
    public TypeVehicule Type;               // Type du véhicule
    public double ModificateurFreinage;     // Multiplicateur de freinage
}
```

**Méthodes abstraites** (à implémenter dans chaque classe) :
- `CalculerDistanceFreinage()` - Distance pour s'arrêter
- `DeclencherAccident()` - Action lors d'un accident
- `ObtenirNom()` - Nom du véhicule

**Méthodes virtuelles** :
- `Freiner(float reduction)` - Réduit la vitesse
- `Accelerer(float augmentation)` - Augmente la vitesse

**Rôle** : Fournir une interface commune pour tous les véhicules

---

### 4?? **Voiture.cs** - Véhicule standard

**Localisation** : `WinFormsApp2/Models/Voiture.cs`

**Propriétés** :
```csharp
POIDS_STANDARD = 1500 kg        // Poids d'une berline
MODIFICATEUR_FREINAGE = 1.0     // Freinage normal
```

**Formule de freinage** :
```
Distance = (Vitesse² / (2 × Gravité × Friction)) × Modificateur
         = (V² / 19.62 × f) × 1.0
```

**Exemple** :
- Vitesse : 90 km/h = 25 m/s
- Friction : 0.8 (sec)
- Distance = (625 / (19.62 × 0.8)) × 1.0 = **39.7 m**

**Rôle** : Voiture de référence pour les calculs

---

### 5?? **Moto.cs** - Deux-roues

**Localisation** : `WinFormsApp2/Models/Moto.cs`

**Propriétés** :
```csharp
POIDS_STANDARD = 250 kg          // Très léger
MODIFICATEUR_FREINAGE = 0.85     // Freine moins bien (adhérence réduite)
```

**Caractéristique** : 
- Poids très faible ? distance de freinage plus courte en proportion
- Mais adhérence réduite ? modificateur de 0.85

**Exemple** :
- Même 90 km/h + sec
- Distance = (625 / 15.696) × 0.85 = **33.75 m**

**Rôle** : Véhicule léger mais moins stable

---

### 6?? **Autobus.cs** - Transport lourd

**Localisation** : `WinFormsApp2/Models/Autobus.cs`

**Propriétés** :
```csharp
POIDS_STANDARD = 12000 kg        // Très lourd
MODIFICATEUR_FREINAGE = 1.3      // Freine plus lentement
```

**Caractéristique** :
- Poids énorme ? inertie très forte
- Modificateur > 1.0 = distance de freinage augmentée

**Exemple** :
- Même 90 km/h + sec
- Distance = (625 / 15.696) × 1.3 = **51.8 m**

**Rôle** : Montre l'impact de la masse sur le freinage

---

### 7?? **Avion.cs** - Transport aérien (Easter Egg)

**Localisation** : `WinFormsApp2/Models/Avion.cs`

**Propriétés** :
```csharp
POIDS_STANDARD = 73000 kg        // Très très lourd
MODIFICATEUR_FREINAGE = 0.5      // Calcul spécial
```

**Formule spéciale** :
```
Distance = (V² / (2 × 5.0)) × 0.5
         // Utilise 5.0 au lieu de (9.81 × 0.8)
```

**Rôle** : Calculs non réalistes pour l'Easter Egg

---

### 8?? **FauteuilRoulant.cs** - Mobilité réduite

**Localisation** : `WinFormsApp2/Models/FauteuilRoulant.cs`

**Propriétés** :
```csharp
POIDS_STANDARD = 100 kg          // Très léger
MODIFICATEUR_FREINAGE = 1.2      // Freine moins bien (moteur faible)
```

**Caractéristique** :
- Très léger mais accélération limitée
- Freinage moins efficace

**Rôle** : Inclusion et diversité des véhicules

---

### 9?? **Environnement.cs** - Contexte environnemental

**Localisation** : `WinFormsApp2/Models/Environnement.cs`

**Propriétés** :
```csharp
public EtatMeteo EtatMeteoActuel;      // État météo courant
public double Temperature;              // Température (°C)
public double Visibilite;              // Visibilité (m)
public double VitesseVent;             // Vitesse vent (km/h)
```

**Méthodes** :
```csharp
ChangerMeteo(EtatMeteoType type)  // Change la météo
ObtenirCoefficientFriction()      // Retourne friction
ObtenirTauxAccidentMultiplicateur() // Retourne taux accidents
```

**Configurations par météo** :
```
SEC:
  Temperature: 20°C, Visibilité: 1000m, Vent: 5 km/h

PLUIE:
  Temperature: 15°C, Visibilité: 400m, Vent: 15 km/h

VERGLAS:
  Temperature: -5°C, Visibilité: 300m, Vent: 25 km/h

BROUILLARD:
  Temperature: 10°C, Visibilité: 100m, Vent: 5 km/h

NEIGE:
  Temperature: -2°C, Visibilité: 200m, Vent: 20 km/h
```

**Rôle** : Fournir le contexte environnemental

---

### ?? **PhysicsEngine.cs** - Moteur de physique

**Localisation** : `WinFormsApp2/Services/PhysicsEngine.cs`

**Méthodes principales** :

#### 1. `CalculerDistanceFreinage(Vehicule vehicule)`
```
Distance = Vehicule.CalculerDistanceFreinage(friction, vitesse)
```
Distance basique sans modificateurs

#### 2. `CalculerDistanceFrainagetotale(Vehicule v, Conducteur c)`
```
Distance finale = Distance physique 
                × Modificateur véhicule
                × Modificateur conducteur
                × Coefficient friction
```

**Exemple complet** :
- Voiture, 90 km/h, sec, conducteur normal
- Distance base = 39.7 m
- × 1.0 (voiture) × 1.0 (conducteur) × 0.8 (friction) = **31.76 m**

#### 3. `VerifierCollisionMur(Vehicule v, Conducteur c, float distanceMur, out float distanceRestante)`
```
Distance restante = Distance mur - Distance freinage totale

SI Distance restante < 0 ? COLLISION! ??
SINON ? OK ?
```

#### 4. `MettreAJourPosition(Vehicule vehicule)`
```
Nouvelle position = Position courante + (Vitesse × Temps)
```

#### 5. `Accelerer(Vehicule vehicule, float acceleration)`
```
Nouvelle vitesse = Vitesse courante + (Accélération × Temps)
```

#### 6. `Freiner(Vehicule vehicule, float deceleration)`
```
Nouvelle vitesse = Max(0, Vitesse courante - (Décélération × Temps))
```

**Rôle** : Tous les calculs physiques du simulateur

---

## ?? Formules Clés

### Distance de freinage
```
Distance = V² / (2 × g × ?)

Où:
  V = Vitesse en m/s (= vitesse km/h ÷ 3.6)
  g = Gravité = 9.81 m/s²
  ? = Coefficient friction (0.1 à 0.8)
```

### Taux d'accident final
```
Taux accident = TauxBase(sexe) 
              × ModificateurConducteur
              × TauxAccidentMeteo
```

---

## ?? Flux d'utilisation

```
USER SELECT VEHICULE ET METEO
    ?
CREER INSTANCE Vehicule + Environnement
    ?
DEFINIR Vitesse + Distance mur
    ?
APPELER PhysicsEngine.VerifierCollisionMur()
    ?
CALCULER Distance freinage totale
    ?
COMPARER avec distance mur
    ?
AFFICHER Collision ou OK
```

---

## ?? Hiérarchie des véhicules

```
Vehicule (abstraite)
??? Voiture (1500 kg, ×1.0)
??? Moto (250 kg, ×0.85)
??? Autobus (12000 kg, ×1.3)
??? Avion (73000 kg, ×0.5)
??? FauteuilRoulant (100 kg, ×1.2)
```

---

## ?? Points importants

### ? Calcul correct de la friction
- La friction affecte directement la distance de freinage
- Sec (0.8) = meilleure adhérence = plus court
- Verglas (0.1) = mauvaise adhérence = plus long

### ? Poids des véhicules
- Plus lourd = plus difficile à freiner
- Voiture (1500 kg) = référence
- Autobus (12000 kg) = 8× plus lourd

### ? Modificateurs
- < 1.0 = Freine mieux
- > 1.0 = Freine moins bien
- Combinaison de tous les facteurs = résultat final

### ? Distance restante négative
- Indique une collision
- Distance mur insuffisante pour freiner

---

## ?? Résumé des fichiers

| Fichier | Type | Rôle | Lignes |
|---------|------|------|--------|
| EtatMeteo.cs | Enum | Météo | ~70 |
| TypeVehicule.cs | Enum | Types | ~10 |
| Vehicule.cs | Abstract | Base | ~30 |
| Voiture.cs | Classe | Standard | ~40 |
| Moto.cs | Classe | Léger | ~40 |
| Autobus.cs | Classe | Lourd | ~40 |
| Avion.cs | Classe | Easter Egg | ~35 |
| FauteuilRoulant.cs | Classe | PMR | ~40 |
| Environnement.cs | Classe | Contexte | ~70 |
| PhysicsEngine.cs | Service | Physics | ~90 |
| **TOTAL** | | | **~465** |

---

## ?? Conclusions

MARIUS a créé une **architecture solide** :
- ? Hiérarchie claire des véhicules
- ? Mécaniques de physique réalistes
- ? Gestion complète de la météo
- ? Calculs de collision précis
- ? Code bien structuré et maintenable

**Tout fonctionne en harmonie pour simuler les accidents!**

---

**MARIUS - Architecte/Physics | .NET 9 | WinForms**
