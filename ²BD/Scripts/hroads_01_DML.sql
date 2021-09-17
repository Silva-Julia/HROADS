USE HROADS_TARDE;
GO


--DML


INSERT INTO TipoHabilidade(QualTipoHabi)
VALUES('Ataque'),('Defesa'),('Cura'),('Magia');
GO



INSERT INTO Classe(TipoClasse)
VALUES('Barbaro'),('Cruzado'),('Caçadora de Demônios'),('Monge'),('Necromante'),('Feiticeiro'),('Arcanista');
GO


INSERT INTO Habilidade(idTipoHabilidade,Nome)
VALUES(1, 'Lança Mortal'), (2,'Escudo Supremo'), (3,'Recuperar Vida');
GO
INSERT INTO Habilidade(idTipoHabilidade,Nome)
VALUES(4, 'NULL');
GO




INSERT INTO ClasseHabilidade(idClasse,idHabilidade)
VALUES(1, 1 ), (2,2), (3,1),(4,3), (5,4), (6,3), (7,4), (1,2), (4,2);
GO




INSERT INTO Personagem(idClasse,NomePer,CapaMaxVida,CapaMaxMana,DataCriacao,DataAtual)
VALUES(1, 'DeBug', '100','80','09/08/2021','16/09/2021'), (2,'BitBug','70','100','10/08/2021','15/09/2021'), (7,'Fer8','75','60','11/08/2021','17/09/2021');
GO

INSERT INTO TipoUsuario(permissao)
VALUES	('Administrador'),('Jogador');
GO

INSERT INTO Usuario (email,senha,idTipoUsuario)
VALUES	('admin@admin.com', 'admin', 1),('jogador@jogador.com', 'jogador', 2);
GO

UPDATE Personagens
SET NomePer = 'Fer7'
WHERE idPersonagem = (3)
GO

UPDATE Classes
SET TipoClasse = 'Necromancer'
WHERE idClasse = (5)
GO