# ⚡ Setup Rapide - Démarrage en 5 minutes

## 📥 Étape 1 : Cloner le projet (2 min)

### Via Visual Studio (Facile 👍)
1. Ouvrez **Visual Studio 2026**
2. **File** → **Clone Repository**
3. Collez : `https://github.com/sorbonne04/Projetscolaire.git`
4. **Clone**

### Via PowerShell (Plus rapide)
```powershell
git clone https://github.com/sorbonne04/Projetscolaire.git
cd Projetscolaire
```

---

## 🔧 Étape 2 : Configurer le projet (1 min)

```powershell
cd WinFormsApp2

# Restaurer les packages NuGet
dotnet restore

# Compiler le projet
dotnet build
```

**Résultat attendu** ✅
```
Build succeeded.
```

---

## ▶️ Étape 3 : Exécuter l'application (1 min)

```powershell
dotnet run
```

Ou dans Visual Studio :
- Cliquez **Start** (bouton ▶️ en haut)

---

## ✅ Étape 4 : Vérifier l'installation

1. **Une fenêtre WinForms s'ouvre** → ✅ OK
2. **Aucune erreur en console** → ✅ OK
3. **Tous les fichiers chargés** → ✅ OK

---

## 🛠️ Dépannage

### ❌ Erreur : ".NET 10 not found"
```powershell
# Vérifier la version
dotnet --version

# Télécharger .NET 10
# https://dotnet.microsoft.com/download/dotnet/10.0
```

### ❌ Erreur : "git not found"
```powershell
# Installer Git
# https://git-scm.com/download/win
```

### ❌ Erreur : "NuGet restore failed"
```powershell
# Effacer le cache NuGet
dotnet nuget locals all --clear

# Réinstaller
dotnet restore
```

---

## 📚 Prochaines Étapes

✅ Consulter **CONTRIBUTING.md** pour :
- Comprendre l'architecture
- Connaître votre rôle
- Apprendre le workflow Git

✅ Consulter **README.md** pour :
- Vue d'ensemble du projet
- Règles métier
- Technologies utilisées

---

## 🚀 Vous êtes prêt !

👉 Choisissez votre tâche dans **CONTRIBUTING.md**
👉 Créez une branche `feature/...`
👉 Commencez à développer !

Questions ? Demandez à l'équipe ! 💪
