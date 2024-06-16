CREATE DATABASE LibraryDb

-- 01
CREATE TABLE Genres(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(30) NOT NULL
)

CREATE TABLE Contacts(
	Id INT PRIMARY KEY IDENTITY,
	Email NVARCHAR(100),
	PhoneNumber NVARCHAR(20),
	PostAddress NVARCHAR(200),
	Website NVARCHAR(50)
)

CREATE TABLE Libraries(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL,
	ContactId INT FOREIGN KEY REFERENCES Contacts(Id) NOT NULL
)

CREATE TABLE Authors(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(100) NOT NULL,
	ContactId INT FOREIGN KEY REFERENCES Contacts(Id) NOT NULL
)

CREATE TABLE Books(
	Id INT PRIMARY KEY IDENTITY,
	Title NVARCHAR(100) NOT NULL,
	YearPublished INT NOT NULL,
	ISBN NVARCHAR(13) UNIQUE NOT NULL,
	AuthorId INT FOREIGN KEY REFERENCES Authors(Id) NOT NULL,
	GenreId INT FOREIGN KEY REFERENCES Genres(Id) NOT NULL
)

CREATE TABLE LibrariesBooks(
	LibraryId INT FOREIGN KEY REFERENCES Libraries(Id) NOT NULL,
	BookId INT FOREIGN KEY REFERENCES Books(Id) NOT NULL,
	PRIMARY KEY(LibraryId, BookId)
)

-- 02
SET IDENTITY_INSERT Contacts ON;

INSERT INTO Contacts(Id, Email, PhoneNumber, PostAddress, Website)
VALUES
(21, NULL, NULL, NULL, NULL),
(22, NULL, NULL, NULL, NULL),
(23, 'stephen.king@example.com', '+4445556666', '15 Fiction Ave, Bangor, ME', 'www.stephenking.com'),
(24, 'suzanne.collins@example.com', '+7778889999', '10 Mockingbird Ln, NY, NY', 'www.suzannecollins.com')

SET IDENTITY_INSERT Contacts OFF;



SET IDENTITY_INSERT Authors ON;

INSERT INTO Authors(Id, [Name], ContactId)
VALUES
(16, 'George Orwell', 21),
(17, 'Aldous Huxley', 22),
(18, 'Stephen King', 23),
(19, 'Suzanne Collins', 24)

SET IDENTITY_INSERT Authors OFF;


SET IDENTITY_INSERT Books ON;

INSERT INTO Books(Id, Title, YearPublished, ISBN, AuthorId, GenreId)
VALUES
(36, '1984', 1949, '9780451524935', 16,	2),
(37, 'Animal Farm', 1945, '9780451526342', 16, 2),
(38, 'Brave New World', 1932, '9780060850524', 17, 2),
(39, 'The Doors of Perception', 1954, '9780060850531', 17, 2),
(40, 'The Shining', 1977, '9780307743657', 18, 9),
(41, 'It', 1986, '9781501142970', 18, 9),
(42, 'The Hunger Games', 2008, '9780439023481', 19, 7),
(43, 'Catching Fire', 2009, '9780439023498', 19, 7),
(44, 'Mockingjay', 2010, '9780439023511', 19, 7)

SET IDENTITY_INSERT Books OFF;

INSERT INTO LibrariesBooks(LibraryId, BookId)
VALUES
(1,	36),
(1,	37),
(2,	38),
(2,	39),
(3,	40),
(3,	41),
(4,	42),
(4,	43),
(5,	44)


-- 03
UPDATE Contacts
SET Website = CONCAT_WS('.', 'www', LOWER(REPLACE(a.[Name], ' ', '')), 'com')
FROM Authors AS a
LEFT JOIN Contacts AS c ON a.ContactId = c.Id
WHERE c.Website IS NULL

SELECT * FROM Contacts
SELECT * FROM Authors

-- 04
DECLARE @AuthorsToDelete TABLE(Id INT)

INSERT INTO @AuthorsToDelete (Id)
	SELECT Id FROM Authors WHERE [Name] = 'Alex Michaelides'

DECLARE @BooksToDelete TABLE(Id INT)

INSERT INTO @BooksToDelete (Id)
	SELECT Id FROM Books WHERE [AuthorId] IN (SELECT Id FROM @AuthorsToDelete)

DELETE FROM LibrariesBooks
WHERE BookId IN (SELECT Id FROM @BooksToDelete)

DELETE FROM Books
WHERE AuthorId IN (SELECT Id FROM @AuthorsToDelete)

DELETE FROM Authors
WHERE Id IN (SELECT Id FROM @AuthorsToDelete)

SELECT * FROM Books
SELECT * FROM LibrariesBooks

-- 05
SELECT
	Title AS [Book Title],
	ISBN,
	YearPublished AS [YearReleased]
FROM Books
ORDER BY YearPublished DESC, Title

SELECT * FROM Books

-- 06
SELECT
	b.Id,
	b.Title,
	b.ISBN,
	g.[Name] AS [Genre]
FROM Books AS b
JOIN Genres AS g
ON b.GenreId = g.Id
WHERE g.[Name] IN ('Biography', 'Historical Fiction')
ORDER BY g.[Name], b.Title

SELECT * FROM Books
SELECT * FROM Genres

-- 07
SELECT
	l.[Name],
	c.Email
FROM Libraries AS l
JOIN LibrariesBooks AS lb ON l.Id = lb.LibraryId
JOIN Books AS b ON lb.BookId = b.Id
JOIN Contacts AS c ON l.ContactId = c.Id
GROUP BY l.[Name], c.Email
HAVING SUM(CASE WHEN b.GenreId = 1 THEN 1 ELSE 0 END) = 0
ORDER BY l.[Name]

SELECT * FROM Libraries
SELECT * FROM LibrariesBooks
SELECT * FROM Contacts
SELECT * FROM Books

-- 08
SELECT TOP(3)
	b.Title,
	b.YearPublished AS [Year],
	g.[Name]
FROM Books AS b
JOIN Genres AS g ON b.GenreId = g.Id
WHERE (b.YearPublished > 2000 AND b.Title LIKE '%a%') OR (b.YearPublished < 1950 AND g.[Name] LIKE '%Fantasy%')
ORDER BY b.Title, b.YearPublished DESC


-- 09
SELECT
	a.[Name] AS [Author],
	c.Email,
	c.PostAddress AS [Address]
FROM Authors AS a
JOIN Contacts AS c ON a.ContactId = c.Id
WHERE c.PostAddress LIKE '%UK%'
ORDER BY a.[Name]

SELECT * FROM Authors
SELECT * FROM Contacts

-- 10
SELECT
	a.[Name] AS [Author],
	b.Title,
	l.[Name] AS [Library],
	c.PostAddress AS [LibraryAddress]
FROM Books AS b
JOIN Genres AS g ON b.GenreId = g.Id
JOIN LibrariesBooks AS lb ON lb.BookId = b.Id
JOIN Libraries AS l ON lb.LibraryId = l.Id
JOIN Contacts AS c ON l.ContactId = c.Id
JOIN Authors AS a ON b.AuthorId = a.Id
WHERE g.[Name] LIKE 'Fiction%' AND c.PostAddress LIKE '%Denver%'
ORDER BY b.Title

SELECT * FROM Books
SELECT * FROM Genres
SELECT * FROM Libraries
SELECT * FROM Contacts
SELECT * FROM Authors

-- 11
CREATE FUNCTION udf_AuthorsWithBooks(@name NVARCHAR(100))
RETURNS INT
AS
BEGIN
	RETURN (SELECT
		COUNT(*)
	FROM Books AS b
	JOIN Authors AS a ON b.AuthorId = a.Id
	WHERE a.[Name] = @name
			)
END

SELECT dbo.udf_AuthorsWithBooks('J.K. Rowling') -- 3

-- 12
