docker exec -i {id databse} mysql -uroot -proot < {sql file}.sql

CREATE ROLE 'admin';
CREATE ROLE 'player';
CREATE ROLE 'shopKeeper';

--b.1
GRANT ALL PRIVILEGES ON db_space_invaders.* TO 'admin' WITH GRANT OPTION;

--b.2
GRANT SELECT ON db_space_invaders.t_arme TO 'player';
GRANT CREATE, SELECT ON db_space_invaders.t_commande TO 'player';

--b.3
GRANT SELECT ON db_space_invaders.t_commande TO 'shopKeeper';
GRANT SELECT ON db_space_invaders.t_joueur TO 'shopKeeper';
GRANT UPDATE, SELECT, DELETE ON db_space_invaders.t_arme TO 'shopKeeper';

--C.1 
SELECT `jouPseudo`, jouNombrePoints FROM t_joueur ORDER BY `jouNombrePoints` DESC;

--C.2
SELECT MAX(`armPrix`) AS "PrixMaximum", MIN(`armPrix`)AS "PrixMinimum", AVG(`armPrix`) AS "PrixMoyen" FROM t_arme;

--C.3
SELECT COUNT(idCommande) AS "NombreCommande", fkJoueur AS "IdJoueur" FROM t_commande GROUP BY fkJoueur ORDER BY COUNT(idCommande) DESC;

--C.4
SELECT COUNT(idCommande) AS "NombreCommande", fkJoueur AS "IdJoueur" FROM t_commande GROUP BY fkJoueur HAVING COUNT(`idCommande`) > 2 ;

--C.5
SELECT t_joueur.jouPseudo, t3.armNom FROM t_joueur
JOIN t_commande AS t2 ON t_joueur.idJoueur = t2.fkJoueur
JOIN t_detail_commande AS t1 ON t2.fkJoueur = t1.fkCommande
JOIN t_arme AS t3 ON t1.fkArme = t3.idArme;

--C.6
SELECT SUM(arme.armPrix*t_detail_commande.detQuantiteCommande) AS TotalDepense, commande.fkJoueur AS idJoueur FROM t_detail_commande
JOIN t_commande as commande ON t_detail_commande.fkCommande = commande.idCommande
JOIN t_arme as arme ON t_detail_commande.fkArme = arme.idArme
GROUP BY idJoueur
ORDER BY TotalDepense DESC
LIMIT 10;

--C.7
SELECT t_joueur.jouPseudo, t_commande.idCommande 
FROM t_commande 
RIGHT JOIN t_joueur ON t_joueur.idJoueur = t_commande.fkJoueur;

--C.8
SELECT t_joueur.jouPseudo, t_commande.idCommande 
FROM t_commande 
LEFT JOIN t_joueur ON t_joueur.idJoueur = t_commande.fkJoueur;

--c.9
SELECT SUM(t_detail_commande.detQuantiteCommande), t_joueur.idJoueur 
FROM t_joueur
LEFT JOIN t_commande ON t_commande.fkJoueur = t_joueur.idJoueur
LEFT JOIN t_detail_commande ON t_detail_commande.fkCommande = t_commande.idCommande
GROUP BY t_joueur.idJoueur;

--C.10
SELECT idJoueur
FROM t_joueur
JOIN t_commande ON fkJoueur = idJoueur
JOIN t_detail_commande ON fkCommande = idCommande
GROUP BY idJoueur
HAVING COUNT(DISTINCT fkArme) > 3;
