DROP SCHEMA TappitTechnicalTest CASCADE;
CREATE SCHEMA TappitTechnicalTest;
SET SCHEMA 'TappitTechnicalTest';

DROP TABLE IF EXISTS TappitTechnicalTest.Sports;
CREATE TABLE TappitTechnicalTest.Sports(
	SportId SERIAL,
	Name Varchar(50) NOT NULL,
	IsEnabled Boolean NOT NULL,
 	CONSTRAINT PK_Sports PRIMARY KEY 
	(
		SportId 
	) 
);
INSERT INTO TappitTechnicalTest.Sports (SportId, Name, IsEnabled) VALUES (1, N'American Football', true);
INSERT INTO TappitTechnicalTest.Sports (SportId, Name, IsEnabled) VALUES (2, N'Baseball', true); 
INSERT INTO TappitTechnicalTest.Sports (SportId, Name, IsEnabled) VALUES (3, N'Basketball', true);

DROP TABLE IF EXISTS TappitTechnicalTest.People;
CREATE TABLE TappitTechnicalTest.People(
	PersonId SERIAL,
	FirstName Varchar(50) NOT NULL,
	LastName Varchar(50) NOT NULL,
	IsAuthorised Boolean NOT NULL,
	IsValid Boolean NOT NULL,
	IsEnabled Boolean NOT NULL,ß
 	CONSTRAINT PK_People PRIMARY KEY 
	(
		PersonId 
	) 
);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (1, N'Frank', N'Smith', false, true, false);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (2, N'Bob', N'Mason', false, false, false);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (3, N'David', N'Adams', false, true, true);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (4, N'Eve', N'Jones', false, false, false);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (5, N'Steven', N'Taylor', false, true, true);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (6, N'Hannah', N'Butler', false, false, false);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (7, N'John', N'Edwards', false, true, false);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (8, N'Oliver', N'Woods', false, false, false);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (9, N'Natan', N'Lee', false, true, true);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (10, N'Thomas', N'Brown', false, true, true);
INSERT INTO TappitTechnicalTest.People (PersonId, FirstName, LastName, IsAuthorised, IsValid, IsEnabled) VALUES (11, N'Otto', N'Campbell', true, true, false);

DROP TABLE IF EXISTS TappitTechnicalTest.FavouriteSports;
CREATE TABLE TappitTechnicalTest.FavouriteSports(
	PersonId int NOT NULL,
	SportId int NOT NULL,
 	CONSTRAINT PK_FavouriteSports PRIMARY KEY 
	(
		PersonId,
		SportId 
	),
	CONSTRAINT FK_FavouriteSports_People
      FOREIGN KEY(PersonId) 
	  REFERENCES TappitTechnicalTest.People(PersonId),
	CONSTRAINT FK_FavouriteSports_Sports
      FOREIGN KEY(SportId) 
	  REFERENCES TappitTechnicalTest.Sports(SportId)
);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (1, 1);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (1, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (1, 3);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (2, 1);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (2, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (3, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (4, 1);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (4, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (4, 3);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (5, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (6, 1);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (7, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (7, 3);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (8, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (9, 1);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (10, 1);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (10, 2);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (10, 3);
INSERT INTO TappitTechnicalTest.FavouriteSports (PersonId, SportId) VALUES (11, 1);
 

 
 