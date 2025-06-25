-- 13
CREATE DATABASE Movies
USE Movies


CREATE TABLE Directors 
(
	Id INT PRIMARY KEY,
	DirectorName NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX) NOT NULL
)

INSERT INTO Directors (Id, DirectorName, Notes)
VALUES 
(1, 'testName1', 'This is a test note'),
(2, 'testName2', 'This is a test note'),
(3, 'testName3', 'This is a test note'),
(4, 'testName4', 'This is a test note'),
(5, 'testName5', 'This is a test note')


CREATE TABLE Genres
(
	Id INT PRIMARY KEY,
	GenreName NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX) NOT NULL
)

INSERT INTO Genres (Id, GenreName, Notes)
VALUES 
(1, 'genreName1', 'This is a test note'),
(2, 'genreName2', 'This is a test note'),
(3, 'genreName3', 'This is a test note'),
(4, 'genreName4', 'This is a test note'),
(5, 'genreName5', 'This is a test note')


CREATE TABLE Categories
(
	Id INT PRIMARY KEY,
	CategoryName NVARCHAR(100) NOT NULL,
	Notes NVARCHAR(MAX)
)

INSERT INTO Categories (Id, CategoryName, Notes)
VALUES 
(1, 'categoryName1', 'This is a test note'),
(2, 'categoryName2', 'This is a test note'),
(3, 'categoryName3', 'This is a test note'),
(4, 'categoryName4', 'This is a test note'),
(5, 'categoryName5', 'This is a test note')



CREATE TABLE Movies
(
	Id INT PRIMARY KEY,
	Title NVARCHAR(100) NOT NULL,
	DirectorId INT NOT NULL,
	CopyrightYear INT NOT NULL,
	[Length] INT NOT NULL,
	GenreId INT NOT NULL,
	CategoryId INT NOT NULL,
	Rating TINYINT NOT NULL,
	Notes NVARCHAR(MAX) NOT NULL
)

INSERT INTO Movies (Id, Title, DirectorId, CopyrightYear, [Length], GenreId, CategoryId, Rating, Notes)
VALUES 
(1, 'testTitle1', 1, 2010, 120, 1, 1, 4, 'this is a test note1'),
(2, 'testTitle2', 2, 2011, 125, 2, 2, 4, 'this is a test note2'),
(3, 'testTitle3', 3, 2012, 115, 3, 3, 4, 'this is a test note3'),
(4, 'testTitle4', 4, 2013, 135, 4, 4, 4, 'this is a test note4'),
(5, 'testTitle5', 5, 2014, 110, 5, 5, 4, 'this is a test note5')