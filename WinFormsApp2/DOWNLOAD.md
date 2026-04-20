# 📥 Comment Télécharger le Projet - Guide Collaborateurs

Bienvenue dans l'équipe ! Suivez ce guide pour télécharger et commencer à travailler sur le simulateur.

---

## 🎯 Trois Méthodes de Téléchargement

### **Méthode 1 : Cloner avec Git (Recommandé ⭐)**

#### Prérequis
- Installer **Git** : https://git-scm.com/

#### Commandes

**Windows PowerShell**
```powershell
# Ouvrir PowerShell et naviguez où vous voulez stocker le projet
cd C:\Users\VotreNom\Documents

# Cloner le repository
git clone https://github.com/sorbonne04/Projetscolaire.git

# Entrer dans le dossier
cd Projetscolaire/WinFormsApp2

# Voir le contenu
ls
```

**Linux/Mac Terminal**
```bash
# Même commandes
git clone https://github.com/sorbonne04/Projetscolaire.git
cd Projetscolaire/WinFormsApp2
```

✅ **Avantage** : Vous pouvez tirer les mises à jour avec `git pull`

---

### **Méthode 2 : Télécharger ZIP (Facile 👍)**

1. Allez sur : **https://github.com/sorbonne04/Projetscolaire**

2. Cliquez le bouton vert **`Code`**
   ```
   ▼ Code
   ```

3. Sélectionnez **`Download ZIP`**
   ```
   📦 Download ZIP
   ```

4. **Décompressez** le fichier téléchargé

5. Ouvrez `WinFormsApp2.sln` dans Visual Studio

❌ **Inconvénient** : Vous ne pouvez pas facilement tirer les mises à jour

---

### **Méthode 3 : Cloner Directement dans Visual Studio (Facile ⭐⭐)**

#### Prérequis
- **Visual Studio 2022+** installé

#### Étapes

1. Ouvrez **Visual Studio 2026**

2. Cliquez **File** dans le menu
   ```
   File → Clone Repository...
   ```

3. Une fenêtre s'ouvre
   ```
   Repository location (URL ou path)
   https://github.com/sorbonne04/Projetscolaire.git
   ```

4. Collez l'URL :
   ```
   https://github.com/sorbonne04/Projetscolaire.git
   ```

5. Choisissez un **dossier local** (ex: `C:\Users\VotreNom\source\repos`)

6. Cliquez **Clone** et attendez

7. Visual Studio ouvre automatiquement le projet ✅

---

## ✅ Vérifier que tout fonctionne

Après avoir téléchargé, vérifiez l'installation :

```powershell
# Naviguez dans le dossier
cd WinFormsApp2

# Compilez
dotnet build
```

**Résultat attendu ✅**
```
Build succeeded.
```

Si vous voyez des erreurs :
- Consultez **SETUP.md** dans le repository
- Ou demandez à Marius, Ethan ou Tarik

---

## 📁 Structure du dossier téléchargé

```
Projetscolaire/
└── WinFormsApp2/
    ├── Enums/
    ├── Models/
    ├── Services/
    ├── Controllers/
    ├── Views/
    ├── Program.cs
    ├── WinFormsApp2.csproj
    ├── README.md              ← Lisez ceci d'abord
    ├── SETUP.md               ← Setup rapide
    ├── CONTRIBUTING.md        ← Workflow et tâches
    └── .gitignore
```

---

## 🚀 Prochaines Étapes

1. **Lire les documentations**
   - 📖 `README.md` - Vue d'ensemble
   - ⚡ `SETUP.md` - Démarrage rapide
   - 🤝 `CONTRIBUTING.md` - Workflow et tâches

2. **Identifier votre rôle**
   - 🔴 **MARIUS** : Physics & Architecture
   - 🔵 **ETHAN** : Business Logic
   - 🟢 **TARIK** : UI/UX

3. **Créer votre branche**
   ```powershell
   git checkout main
   git pull origin main
   git checkout -b feature/votre-tache
   ```

4. **Commencer à développer** 💻

---

## 💡 Tips & Astuces

### Mettre à jour votre copie locale
```bash
git pull origin main
```

### Voir l'historique des commits
```bash
git log --oneline
```

### Voir les branches disponibles
```bash
git branch -a
```

### Changer de branche
```bash
git checkout nom-de-la-branche
```

---

## 🆘 Problèmes Courants

### ❌ "fatal: not a git repository"
**Solution** : Assurez-vous que vous êtes dans le bon dossier
```powershell
# Vous devez être dans WinFormsApp2/
cd WinFormsApp2
git status
```

### ❌ "fatal: could not connect to GitHub.com"
**Solution** : Vérifiez votre connexion Internet
```powershell
ping github.com
```

### ❌ "error: The following files would be overwritten by merge"
**Solution** : Consultez `CONTRIBUTING.md` section Dépannage

---

## 📞 Besoin d'Aide ?

1. Consultez les documentations dans le repository
2. Contactez votre équipe :
   - **MARIUS** : Problèmes Physics/Architecture
   - **ETHAN** : Problèmes Business Logic
   - **TARIK** : Problèmes UI/UX

---

## 🎉 Vous êtes Prêt !

Vous avez maintenant le projet sur votre machine. 

👉 Allez lire `CONTRIBUTING.md` pour connaître votre prochaine tâche !

Bienvenue dans l'équipe ! 🚀
