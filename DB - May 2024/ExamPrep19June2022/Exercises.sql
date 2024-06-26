CREATE DATABASE Zoo

-- 01
CREATE TABLE Owners(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50)
)

CREATE TABLE AnimalTypes(
	Id INT PRIMARY KEY IDENTITY,
	AnimalType VARCHAR(30) NOT NULL
)

CREATE TABLE Cages(
	Id INT PRIMARY KEY IDENTITY,
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE Animals(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL,
	BirthDate DATE NOT NULL,
	OwnerId INT FOREIGN KEY REFERENCES Owners(Id),
	AnimalTypeId INT FOREIGN KEY REFERENCES AnimalTypes(Id) NOT NULL
)

CREATE TABLE AnimalsCages(
	CageId INT FOREIGN KEY REFERENCES Cages(Id) NOT NULL,
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id) NOT NULL,
	PRIMARY KEY (CageId, AnimalId)
)

CREATE TABLE VolunteersDepartments(
	Id INT PRIMARY KEY IDENTITY,
	DepartmentName VARCHAR(30) NOT NULL
)

CREATE TABLE Volunteers(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	PhoneNumber VARCHAR(15) NOT NULL,
	[Address] VARCHAR(50),
	AnimalId INT FOREIGN KEY REFERENCES Animals(Id),
	DepartmentId INT FOREIGN KEY REFERENCES VolunteersDepartments(Id) NOT NULL
)

-- 02
INSERT INTO Volunteers([Name], PhoneNumber, [Address], AnimalId, DepartmentId)
VALUES ('Anita Kostova', '0896365412', 'Sofia, 5 Rosa str.', 15, 1),
('Dimitur Stoev', '0877564223', null, 42, 4),
('Kalina Evtimova', '0896321112', 'Silistra, 21 Breza str.', 9, 7),
('Stoyan Tomov', '0898564100', 'Montana, 1 Bor str.', 18, 8),
('Boryana Mileva', '0888112233', null, 31, 5)

INSERT INTO Animals([Name], BirthDate, OwnerId, AnimalTypeId)
VALUES ('Giraffe', '2018-09-21', 21, 1),
('Harpy Eagle', '2015-04-17', 15, 3),
('Hamadryas Baboon', '2017-11-02', null, 1),
('Tuatara', '2021-06-30', 2, 4)

-- 03
UPDATE Animals
SET OwnerId = 4
WHERE OwnerId IS NULL

-- 04
DECLARE @VolunteersToDelete TABLE(Id INT)
INSERT INTO @VolunteersToDelete (Id)
	SELECT Id
	FROM Volunteers
	WHERE DepartmentId = 2

DELETE FROM Volunteers
WHERE Id IN (SELECT Id FROM @VolunteersToDelete)

DELETE FROM VolunteersDepartments
WHERE DepartmentName = 'Education program assistant'

SELECT * FROM VolunteersDepartments
SELECT * FROM Volunteers

-- 05
SELECT
	[Name],
	PhoneNumber,
	[Address],
	AnimalId,
	DepartmentId
FROM Volunteers
ORDER BY [Name], AnimalId, DepartmentId

-- 06
SELECT
	a.[Name],
	[at].AnimalType,
	FORMAT(a.BirthDate, 'dd.MM.yyyy') AS [BirthDate]
FROM Animals AS a
JOIN AnimalTypes AS [at]
ON a.AnimalTypeId = [at].Id
ORDER BY a.[Name]

SELECT * FROM Animals
SELECT * FROM AnimalTypes

-- 07
SELECT TOP(5)
	o.[Name],
	COUNT(a.Id) AS [CountOfAnimals]
FROM Animals AS a
JOIN Owners AS o
ON a.OwnerId = o.Id
GROUP BY o.[Name]
ORDER BY CountOfAnimals DESC

SELECT * FROM Owners
SELECT * FROM Animals

-- 08
SELECT
	CONCAT(o.[Name], '-', a.[Name]) AS [OwnersAnimals],
	o.PhoneNumber,
	c.Id AS [CageId]
FROM Animals AS a
JOIN Owners AS o
ON a.OwnerId = o.Id
JOIN Cages AS c
ON c.AnimalTypeId = 1
JOIN AnimalsCages AS ac
ON ac.CageId = c.Id AND a.Id = ac.AnimalId
WHERE a.AnimalTypeId = 1
ORDER BY o.[Name], a.[Name] DESC


SELECT * FROM Owners
SELECT * FROM Animals
SELECT * FROM AnimalTypes
SELECT * FROM AnimalsCages
SELECT * FROM Cages

-- 09
SELECT
	v.[Name],
	v.PhoneNumber,
	SUBSTRING(v.[Address], CHARINDEX(',', v.[Address]) + 1, LEN(v.[Address])) AS [Address]
--	TRIM(REPLACE(REPLACE(v.[Address], 'Sofia', ''), ',', '')) (or LTRIM in the beginning)
FROM Volunteers AS v
WHERE v.DepartmentId = 2 AND v.[Address] LIKE '%Sofia%'
ORDER BY v.[Name] ASC

SELECT * FROM Volunteers
SELECT * FROM VolunteersDepartments

-- 10
SELECT
	a.[Name],
	YEAR(a.BirthDate) AS [BirthYear],
	[at].AnimalType
FROM Animals AS a
JOIN AnimalTypes AS [at]
ON a.AnimalTypeId = [at].Id
WHERE DATEDIFF(YEAR, a.BirthDate, '01/01/2022') < 5 AND a.OwnerId IS NULL AND a.AnimalTypeId != 3
ORDER BY a.[Name]

SELECT * FROM Animals
SELECT * FROM AnimalTypes

-- 11
CREATE FUNCTION udf_GetVolunteersCountFromADepartment (@VolunteersDepartment VARCHAR(30))
RETURNS INT
AS
BEGIN
	RETURN (SELECT
				COUNT(*)
			FROM Volunteers AS v
			JOIN VolunteersDepartments AS vd
			ON v.DepartmentId = vd.Id AND vd.DepartmentName = @VolunteersDepartment)
END

SELECT dbo.udf_GetVolunteersCountFromADepartment ('Zoo events') -- 5

SELECT * FROM Volunteers
SELECT * FROM VolunteersDepartments

GO
-- 12
CREATE PROCEDURE usp_AnimalsWithOwnersOrNot(@AnimalName VARCHAR(30))
AS
BEGIN
	SELECT
		a.[Name],
		ISNULL(o.[Name], 'For adoption') AS [OwnersName]
		--CASE
		--	WHEN o.[Name] IS NULL THEN 'For adoption'
		--	ELSE o.[Name]
		--END AS [OwnersName]
	FROM Animals AS a
	LEFT JOIN Owners AS o -- LEFT because we also want the animals that DO NOT have an owner!!!!!
	ON a.OwnerId = o.Id
	WHERE a.[Name] = @AnimalName
END

EXEC usp_AnimalsWithOwnersOrNot 'Brown bear'
SELECT * FROM Animals