USE HROADS_TARDE;
GO

SELECT * FROM TipoHabilidade;
GO

SELECT * FROM Classe;
GO
SELECT * FROM Habilidade;
GO
SELECT * FROM ClasseHabilidade;
GO
SELECT * FROM Personagem;
GO
SELECT * FROM TipoUsuario;
GO 
SELECT * FROM Usuario;
GO 

--Selecionar somente os id’s das habilidades classificando-os por ordem
--crescente;
SELECT idHabilidade FROM Habilidades
GO
--Selecionar todos os tipos de habilidades;
SELECT QualHabilidade FROM Habilidades
GO

--Selecionar todas as habilidades e a quais tipos de habilidades elas fazem parte;

SELECT QualHabilidade, QualTipoHabi FROM Habilidades
INNER JOIN TipoHabilidade
ON Habilidades.idTipoHabi = TipoHabilidade.idTipo
GO

--Selecionar todos os personagens e suas respectivas classes;
SELECT NomePer, TipoClasse FROM Personagens
INNER JOIN Classes
ON Personagens.idClasse = Classes.idClasse
GO

--Selecionar todos os personagens e as classes (mesmo que elas não tenham correspondência em personagens);

SELECT NomePer, TipoClasse FROM Personagens
RIGHT JOIN Classes
ON Personagens.idClasse = Classes.idClasse
GO

--Selecionar todas as classes e suas respectivas habilidades;

SELECT TipoClasse, QualHabilidade FROM Classes
LEFT JOIN Habilidades
ON Classes.idClasse = Habilidades.idHabilidade
GO

--Selecionar todas as habilidades e suas classes (somente as que possuem correspondência);
SELECT QualHabilidade, TipoClasse FROM Habilidades
INNER JOIN Classes
ON Habilidades.idHabilidade = Classes.idClasse
GO

--Selecionar todas as habilidades e suas classes (mesmo que elas não tenham correspondência).

SELECT QualHabilidade, TipoClasse FROM Habilidades
RIGHT JOIN Classes
ON Habilidades.idHabilidade = Classes.idClasse
GO