/*Espace pour les notes personneles lors de la création du projet. NE RIEN CODER DEDANS!!!
 * 
 * GameLoop: Facteur. Income: Point A > Point B.
 * 
 * Addition fight ennemis quand pas sur les senties battus (& Forcer le joueur a sortir des sentiers battus)
 * 
 * Component List[ Inventaire:OK, Movement:OK, Position:OK, Render:OK, Collision:OK, Map: OK ??]
 * 
 * Menu Component???
 * Shop Component???
 * Interact Component???
 * 
 * 
 * TODO: Ok-fy Movement et Render
 * 
 * Doing: Fixing CollisionManager: Le joueur spawne OOB
 * 
 * 
 * State Machine
 * 1 State par Type de Location (Shop/Inn, City, country, Planet, ...)
 * Qui gère la sortie du village/shop/inn etc... CollisionManager
 * 
 * Event Manager
 * 
 * IStates: Render normal pour City et World ET SHOP
 * Comportement spécifique Shop: collision avec objet proposer achat.
 * Comportement colision City et Shop, si collision Exit, exit location
 * 
 * Event: Touches
 * 
 * 
 * 
 * 
 * 
 * 
*/