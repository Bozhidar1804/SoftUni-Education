CREATE DATABASE TouristAgency

-- 01
CREATE TABLE Countries(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(50) NOT NULL
)

CREATE TABLE Destinations(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Rooms(
	Id INT PRIMARY KEY IDENTITY,
	[Type] VARCHAR(40) NOT NULL,
	Price DECIMAL(18, 2) NOT NULL,
	BedCount INT NOT NULL
		CHECK(BedCount > 0 AND BedCount <= 10)
)

CREATE TABLE Hotels(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	DestinationId INT FOREIGN KEY REFERENCES Destinations(Id) NOT NULL
)

CREATE TABLE Tourists(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL,
	PhoneNumber VARCHAR(20) NOT NULL,
	Email VARCHAR(80),
	CountryId INT FOREIGN KEY REFERENCES Countries(Id) NOT NULL
)

CREATE TABLE Bookings(
	Id INT PRIMARY KEY IDENTITY,
	ArrivalDate DATETIME2 NOT NULL,
	DepartureDate DATETIME2 NOT NULL,
	AdultsCount INT NOT NULL
		CHECK(AdultsCount >= 1 AND AdultsCount <= 10),
	ChildrenCount INT NOT NULL
		CHECK(ChildrenCount >= 0 AND ChildrenCount <= 9),
	TouristId INT FOREIGN KEY REFERENCES Tourists(Id) NOT NULL,
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
)

CREATE TABLE HotelsRooms(
	HotelId INT FOREIGN KEY REFERENCES Hotels(Id) NOT NULL,
	RoomId INT FOREIGN KEY REFERENCES Rooms(Id) NOT NULL,
	PRIMARY KEY (HotelId, RoomId)
)

-- 02
INSERT INTO Tourists([Name], PhoneNumber, Email, CountryId)
VALUES ('John Rivers', '653-551-1555', 'john.rivers@example.com', 6),
('Adeline Agla�', '122-654-8726', 'adeline.aglae@example.com', 2),
('Sergio Ramirez', '233-465-2876', 's.ramirez@example.com', 3),
('Johan M�ller', '322-876-9826', 'j.muller@example.com', 7),
('Eden Smith', '551-874-2234', 'eden.smith@example.com', 6)

INSERT INTO Bookings(ArrivalDate, DepartureDate, AdultsCount, ChildrenCount, TouristId, HotelId,RoomId)
VALUES ('2024-03-01', '2024-03-11', 1, 0, 21, 3, 5),
('2023-12-28', '2024-01-06', 2, 1, 22, 13, 3),
('2023-11-15', '2023-11-20', 1, 2, 23, 19, 7),
('2023-12-05', '2023-12-09', 4, 0, 24, 6, 4),
('2024-05-01', '2024-05-07', 6, 0, 25, 14, 6)

-- 03
UPDATE Bookings
SET DepartureDate = DATEADD(DAY, 1, DepartureDate)
WHERE ArrivalDate > '2023-12-01' AND ArrivalDate < '2023-12-31'
--WHERE DepartureDate LIKE '2023-12%'

UPDATE Tourists
SET Email = Null
WHERE [Name] LIKE '%MA%'

-- 04
DECLARE @TouristsToDelete TABLE(Id INT)

INSERT INTO @TouristsToDelete (Id)
	SELECT Id
	FROM Tourists
	WHERE [Name] LIKE '%Smith'

DELETE FROM Bookings
WHERE [TouristId] IN (
						SELECT Id
						FROM @TouristsToDelete
					 )

DELETE FROM Tourists
WHERE Id IN (
				SELECT Id
				FROM @TouristsToDelete
			)


-- 05
SELECT
	FORMAT(ArrivalDate, 'yyyy-MM-dd') AS [ArrivalDate],
	AdultsCount,
	ChildrenCount
FROM Bookings AS b
JOIN Rooms AS r
ON b.RoomId = r.Id
ORDER BY r.Price DESC, ArrivalDate

SELECT * FROM Rooms
SELECT * FROM Bookings

-- 06
SELECT
 h.Id,
 h.[Name]
FROM Hotels AS h
JOIN HotelsRooms AS hr
ON h.Id = hr.HotelId
JOIN Rooms AS r
ON hr.RoomId = r.Id
JOIN Bookings AS b
ON b.HotelId = h.Id
WHERE r.[Type] = 'VIP Apartment'
GROUP BY h.Id, h.[Name]
ORDER BY COUNT(*) DESC

SELECT * FROM Hotels
SELECT * FROM Destinations


-- 07
SELECT 
	t.Id,
	t.[Name],
	t.PhoneNumber
FROM Tourists AS t
LEFT JOIN Bookings AS b
ON b.TouristId = t.Id
WHERE b.Id IS NULL
ORDER BY t.[Name] ASC

SELECT * FROM Tourists

-- 08
SELECT TOP(10)
	h.[Name],
	d.[Name],
	c.[Name]
FROM Bookings AS b
JOIN Hotels AS h
ON b.HotelId = h.Id
JOIN Destinations AS d
ON h.DestinationId = d.Id
JOIN Countries AS c
ON d.CountryId = c.Id
WHERE ArrivalDate < '2023-12-31' AND b.HotelId % 2 <> 0
ORDER BY c.[Name], b.ArrivalDate

SELECT * FROM Bookings
SELECT * FROM Hotels
SELECT * FROM Destinations
SELECT * FROM Countries

-- 09