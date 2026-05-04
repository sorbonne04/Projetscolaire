// ===============================================
// ?? EASTER EGG - MODE FUN
// ===============================================
//
// DÉBUTANT - Explication simple du code
//
// ===============================================

/*
 * STRUCTURE DE L'EASTER EGG:
 * 
 * 1. MODÈLES (Models/)
 *    - Obstacle.cs        : Les choses que les voitures vont heurter
 *    - VoitureEasterEgg.cs: Les voitures spéciales pour l'easter egg
 * 
 * 2. SERVICES (Services/)
 *    - EasterEggManager.cs: Gère tous les obstacles
 * 
 * 3. CONTRÔLEURS (Controllers/)
 *    - EasterEggController.cs: Gère la logique du jeu
 * 
 * 4. AFFICHAGE (Views/)
 *    - EasterEggPanel.cs: Dessine l'animation
 *    - MainForm.cs      : Intégration dans l'app principale
 * 
 * 5. CONFIGURATION (Config/)
 *    - EasterEggConfig.cs: Paramètres personnalisables
 * 
 * ===============================================
 * 
 * COMMENT ÇA MARCHE?
 * 
 * 1. L'utilisateur clique sur "?? MODE FUN"
 *    -> ActiverModeEasterEgg() s'exécute
 *    -> EasterEggPanel s'affiche
 * 
 * 2. L'utilisateur clique sur "? SIMULER"
 *    -> ExecuterSimulationEasterEgg() s'exécute
 *    -> ExecuterEasterEgg() crée les collisions
 *    -> L'animation affiche les résultats
 * 
 * 3. Le panneau est actualisé en temps réel
 *    -> Les obstacles explosent
 *    -> Les messages s'affichent
 * 
 * ===============================================
 * 
 * POUR AJOUTER PLUS D'OBSTACLES:
 * 
 * Allez dans EasterEggManager.cs et ajoutez:
 * 
 * Obstacles.Add(new Obstacle(
 *     "Nom de l'obstacle",
 *     posX: 100,        // Position X
 *     posY: 200,        // Position Y
 *     largeur: 80,      // Largeur en pixels
 *     hauteur: 50,      // Hauteur en pixels
 *     couleur: Color.Blue,  // Couleur
 *     emoji: "??"       // Emoji à afficher
 * ));
 * 
 * ===============================================
 * 
 * POUR PERSONNALISER LES COULEURS:
 * 
 * Modifiez EasterEggConfig.cs:
 * 
 * public static readonly Color CielNuit = Color.FromArgb(20, 20, 40);
 * // Les 3 nombres sont: Rouge, Vert, Bleu (0-255)
 * 
 * ===============================================
 * 
 * POUR CHANGER LA VITESSE D'ANIMATION:
 * 
 * Modifiez EasterEggConfig.cs:
 * 
 * public const int ANIMATION_SPEED = 50;  // en millisecondes
 * // Plus petit = plus rapide
 * // Plus grand = plus lent
 * 
 * ===============================================
*/
