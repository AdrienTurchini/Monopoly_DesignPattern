Nathan BOON & Adrien TURCHINI
# Monopoly_DesignPattern
Project A4 Design Pattern 

Le projet est un Monopoly sur ordinateur. 
C'est un jeu qui se joue à deux joueurs ou plus. 
Sachant que l'échange de carte n'est pas autorisé et qu'une fois une carte achetée par un joueur le seul moyen de la récuperer est l'élimination de ce joueur il est conseillé de ne pas jouer à trop.

Le Monopoly fonctionne comme un Monopoly normal type Paris avec les rues parisiennes, gares etc.
Il implémente toutes les fonctions d'un Monopoly avec 40 cases différentes, la prison, la case départ, le parc gratuit, aller en prison, les cases chance et caisses de communauté ainsi que toutes les différentes propriétés compagnies et gares.

Il est possible d'hypothéquer ses propriétés, de construire des maisons/hôtels. 
On va en prison lorsqu'on fait 3 doubles de suite où qu'on tombe sur la case aller en prison. On peut sortir de prison après trois tours où si on fait un double.
On gagne 200M à chaque fois qu'on passe par la case départ et 400M si on tombe sur la case départ. 

On est éliminé du jeu lorsqu'on doit payer un joueur ou la banque et que l'on a vendu toutes ses maisons et hôtels, hypothéqué toutes ses propriétés mais que cela ne nous permet pas de payer l'adversaire ou la banque. 
Si un adversaire nous élimine, il récupère tous les biens du joueur éliminé, si c'est la banque, les biens du joueurs sont remis en jeux. 

A chaque début de tour, il est possible de gérer ses propriétés (construire, hypothéquer etc.)

Le jeu comporte :
  1) une classe Joueur qui correspond au joueur et qui possède les méthodes nécéssaire au déroulement de la partie soit acheter une propriété, construire des maisons, payer, recevoir de l'argent etc.
  2) une classe plateau qui correspond au plateau de jeu et qui possède une liste de toutes les cases du jeu, une liste de tous les joueurs du jeu ainsi que les méthodes nécéssaires au fonctionnement du jeu, soit lancer les dés, rajouter un joueur, enlever un joueur.
  3) une classe abstraite Case qui est la classe mère des classes Propriété (les rues de Paris), Gare (les gares de Paris), Compagnie (les compagnies eau et éléctricité) et Autres (la case départ, prison, aller en prison, parc gratuit, impôts, taxe de luxe, chance et communauté). 
  4) les 4 classes filles dont on parle au point précédent. 
  5) une classe CaseFactory qui permet de créer les différentes cases.
  6) deux interface IObserver et ISubject qui definissent les fonctions nécéssaire à l'implémentation du design pattern observer
  7) la classe Program qui fait fonctionner le jeu
  
Nous utilison dans ce projet 3 design pattern différent : 

    1) Le Singleton (thread-safe) :

Il permet de faire en sorte que lorsqu'on utilise le programme, il n'est possible d'avoir qu'un seul et unique plateau de jeu. En effet on joue au Monopoly avec un seul plateau et le singleton ne permet de créer un plateau que par une méthode GetPlateau() et non en appelant son constructeur qui est privé. Cette méthode renvoie au constructeur si auncun plateau existe et retourne le plateau existant si un plateau existe déjà. Le Singleton est thread-safe, c'est à dire que plusieurs threads différents ne peuvent pas créer plusieurs plateau. 


    2) Le factory :

Le pattern factory dans notre programme nous permet d'instancier plusieurs "cases" différentes, des propriétés, des cases chance, aller en prison etc. sans devoir au préalable indiquer de quelle classe fille est cette case. En effet toutes les cases du jeu qu'importe leur type sont des classes fille de la classe mère abstraite Case. On peut donc créer 40 cases différentes en instanciant tout simplement une Case à chaque fois et la fabrique (Case Factory) va s'occuper de choisir le bon constructeur afin de créer les différentes instances des classes filles de la classe Case.

Dans notre projet, nous avons pour la classe Case et ses classes filles utilisé des méthodes à la place de propriétés. Cela revient au même et nous avions commencé de la sorte du coup fini comme cela également. 

Nous avons aussi dans la classe Case des méthodes qui ne sont pas nécéssaires à toutes les classes filles commme connaître le nombre de maisons d'une gare qui ne peut pas en avoir. Nous retournons donc des valeurs par défaut (-1 par exemple) lorsque la méthode/propriété est inutile dans la classe fille. Cela nous permet de directement chercher les attributs (par exemple nombre de maisons d'une propriété) depuis la liste de Case du plateau. Il ne nous ai pas nécéssaire de caster la Case en question en fonction de son type afin d'accéder aux attributs particuliers de cette classe. `


    3) L'observer :

Nous avons implémenté le pattern observer dans notre projet avec comme sujet le plateau uniquement et comme observeurs les joueurs uniquement qui observent le plateau. A chaque fois qu'un joueur lance les dés, selon ce qui se passe et l'état de la partie, le joueur est en prison, il à fait trois doubles d'affilés, il est tombé sur une case etc, l'attribut state du plateau prend une valeure différente et on appelle la fonction notify du plateau qui va aller chercher tous les observeurs (les joueurs) indiqué dans la liste des observeurs (liste des joueurs) et lancer la fonction update pour ces joueurs. Si le joueur de la liste n'est pas le joueur actuel qui joue, il ne se passe rien. Si le joueur est le joueur en tour de jeu alors selon l'état du plateau (l'attribut state) il va se passer les différentes actions comme acheter la carte, payer la banque, payer un autre joueur qui reçoit l'argent etc.

Dans notre cas il n'y a qu'un seul type de sujet c'est la classe plateau et qu'un seul type d'observer c'est la classe joueur. Nous avons donc directement indiqué dans les interfaces IObserver et ISubject les classes joueurs et plateau en arguments des fonctions, de même pour la liste des observers inscrit au plateau (voir classe plateau) qui est une liste de Joueurs. Cela a été fait dans un soucis de simplicité car cela évitait de devoir utiliser des objets de type Observer et Subject qu'on devrait alors caster dans certains cas alors qu'on sait que les observers sont des joueurs et le sujet unique est un plateau. Evidemment, si il y avait eu d'autres types de sujet ou d'observer, nous aurions adapté notre programme afin que d'autres classes puissent utiliser ces interfaces et le pattern observer en ne précisant pas plateau et joueur en propriétés dans les interfaces.

-----------------------
Bon jeu ! :) 

