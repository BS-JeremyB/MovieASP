/*
Modèle de script de post-déploiement							
--------------------------------------------------------------------------------------
 Ce fichier contient des instructions SQL qui seront ajoutées au script de compilation.		
 Utilisez la syntaxe SQLCMD pour inclure un fichier dans le script de post-déploiement.			
 Exemple :      :r .\monfichier.sql								
 Utilisez la syntaxe SQLCMD pour référencer une variable dans le script de post-déploiement.		
 Exemple :      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/



EXEC [dbo].[NewUser] 'John', 'Doe', 'johndoe@mail.be', 'Test1234='
EXEC [dbo].[NewUser] 'Jane', 'Doe', 'janedoe@mail.be', 'Test1234='

INSERT INTO [Movie] ([PosterUrl], [Title], [Description], [Genre], [ReleaseDate])
VALUES ('https://fr.web.img4.acsta.net/c_310_420/medias/04/34/49/043449_af.jpg', 'The Matrix', 'A computer hacker learns from mysterious rebels about the true nature of his reality and his role in the war against its controllers.', 'Action', '1999-03-31')

INSERT INTO [Movie] ([PosterUrl], [Title], [Description], [Genre], [ReleaseDate])
VALUES ('https://fr.web.img6.acsta.net/c_310_420/medias/nmedia/00/02/53/34/affiche.jpg', 'The Matrix Reloaded', 'Neo and his allies
fight against their machines with the help of exiled rebels.', 'Action', '2003-05-15')

INSERT INTO [Movie] ([PosterUrl], [Title], [Description], [Genre], [ReleaseDate])
VALUES ('https://fr.web.img5.acsta.net/c_310_420/medias/nmedia/18/35/14/64/18364977.jpg', 'The Matrix Revolutions', 'The human city of Zion defends itself against the massive invasion of the machines as Neo fights to end the war at another front while also opposing the rogue Agent Smith.', 'Action', '2003-11-05')

INSERT INTO [Movie] ([PosterUrl], [Title], [Description], [Genre], [ReleaseDate])
VALUES ('https://fr.web.img5.acsta.net/c_310_420/medias/nmedia/00/02/16/27/69218096_af.jpg', 'The Lord of the Rings: The Fellowship of the Ring', 'A meek Hobbit from the Shire and eight companions set out on a journey to destroy the powerful One Ring and save Middle-earth from the Dark Lord Sauron.', 'Adventure', '2001-12-19')

INSERT INTO [Movie] ([PosterUrl], [Title], [Description], [Genre], [ReleaseDate])
VALUES ('https://fr.web.img5.acsta.net/c_310_420/medias/nmedia/00/02/54/95/affiche2.jpg', 'The Lord of the Rings: The Two Towers', 'While Frodo and Sam edge closer to Mordor with the help of the shifty Gollum, the divided fellowship makes a stand against Sauron''s new ally, Saruman, and his hordes of Isengard.', 'Adventure', '2002-12-18')


INSERT INTO [UserMovie] ([UserId], [MovieId])
VALUES (1, 1)

INSERT INTO [UserMovie] ([UserId], [MovieId])
VALUES (1, 2)

INSERT INTO [UserMovie] ([UserId], [MovieId])
VALUES (1, 3)

INSERT INTO [UserMovie] ([UserId], [MovieId])
VALUES (2, 4)

INSERT INTO [UserMovie] ([UserId], [MovieId])
VALUES (2, 5)




