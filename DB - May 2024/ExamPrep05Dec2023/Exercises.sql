CREATE DATABASE RailwaysDb

-- 01
CREATE TABLE Passengers(
	Id INT PRIMARY KEY IDENTITY,
	[Name] NVARCHAR(80) NOT NULL
)

CREATE TABLE Towns(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(30) NOT NULL
)

CREATE TABLE RailwayStations(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(50) NOT NULL,
	TownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE Trains(
	Id INT PRIMARY KEY IDENTITY,
	HourOfDeparture VARCHAR(5) NOT NULL,
	HourOfArrival VARCHAR(5) NOT NULL,
	DepartureTownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL,
	ArrivalTownId INT FOREIGN KEY REFERENCES Towns(Id) NOT NULL
)

CREATE TABLE TrainsRailwayStations(
	TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL,
	RailwayStationId INT FOREIGN KEY REFERENCES RailwayStations(Id) NOT NULL,
	PRIMARY KEY (TrainId, RailwayStationId)
)

CREATE TABLE MaintenanceRecords(
	Id INT PRIMARY KEY IDENTITY,
	DateOfMaintenance DATE NOT NULL,
	Details VARCHAR(2000) NOT NULL,
	TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL
)

CREATE TABLE Tickets(
	Id INT PRIMARY KEY IDENTITY,
	Price DECIMAL(10, 2) NOT NULL,
	DateOfDeparture DATE NOT NULL,
	DateOfArrival DATE NOT NULL,
	TrainId INT FOREIGN KEY REFERENCES Trains(Id) NOT NULL,
	PassengerId INT FOREIGN KEY REFERENCES Passengers(Id) NOT NULL
)

-- 02
INSERT INTO Trains(HourOfDeparture, HourOfArrival, DepartureTownId, ArrivalTownId)
VALUES ('07:00', '19:00', 1, 3),
('08:30', '20:30', 5, 6),
('09:00', '21:00', 4, 8),
('06:45', '03:55', 27, 7),
('10:15', '12:15', 15, 5)

INSERT INTO TrainsRailwayStations(TrainId, RailwayStationId)
VALUES (36, 1), 
(36, 4),
(36, 31),
(36, 57),
(36, 7),
(37, 13), 
(37, 54),
(37, 60),
(37, 16),
(38, 10),
(38, 50),
(38, 52),
(38, 22),
(39, 68),
(39, 3),
(39, 31),
(39, 19),
(40, 41),
(40, 7),
(40, 52),
(40, 13)

INSERT INTO Tickets(Price, DateOfDeparture, DateOfArrival, TrainId, PassengerId)
VALUES (90.00, '2023-12-01', '2023-12-01', 36, 1),
(115.00, '2023-08-02', '2023-08-02', 37, 2),
(160.00, '2023-08-03', '2023-08-03', 38, 3),
(255.00, '2023-09-01', '2023-09-02', 39, 21),
(95.00, '2023-09-02', '2023-09-03', 40, 22)

-- 03
UPDATE Tickets
SET DateOfArrival = DATEADD(DAY, 7, DateOfArrival)
WHERE DateOfDeparture > '2023-10-31'

UPDATE Tickets
SET DateOfDeparture = DATEADD(DAY, 7, DateOfDeparture)
WHERE DateOfDeparture > '2023-10-31'

SELECT * FROM Tickets

-- 04
DECLARE @TrainsToDelete TABLE (Id INT)

INSERT INTO @TrainsToDelete (Id)
	SELECT Id FROM Trains WHERE DepartureTownId = 3

DELETE FROM TrainsRailwayStations
WHERE TrainId IN (SELECT Id FROM @TrainsToDelete)

DELETE FROM Tickets
WHERE TrainId IN (SELECT Id FROM @TrainsToDelete)

DELETE FROM MaintenanceRecords
WHERE TrainId IN (SELECT Id FROM @TrainsToDelete)

DELETE FROM Trains
WHERE Id IN (SELECT Id FROM @TrainsToDelete)

SELECT * FROM Trains
SELECT * FROM Towns

-- 05
SELECT
	DateOfDeparture,
	Price AS [TicketPrice]
FROM Tickets
ORDER BY Price, DateOfDeparture DESC

-- 06
SELECT
	p.[Name] AS [PassengerName],
	t.Price,
	t.DateOfDeparture,
	t.TrainId
FROM Tickets AS t
JOIN Passengers AS p
ON t.PassengerId = p.Id
ORDER BY Price DESC, p.[Name]

SELECT * FROM Tickets
SELECT * FROM Passengers

-- 07
SELECT
	t.[Name] AS [Town],
	rs.[Name] AS [RailwayStation]
FROM RailwayStations AS rs
JOIN Towns AS t
ON rs.TownId = t.Id
WHERE rs.Id NOT IN (SELECT RailwayStationId FROM TrainsRailwayStations)
ORDER BY t.[Name], rs.[Name]

SELECT * FROM RailwayStations
SELECT * FROM Towns

-- 08
SELECT TOP(3)
	t.Id AS [TrainId],
	t.HourOfDeparture,
	ti.Price AS [TicketPrice],
	[to].[Name] AS [Destination]
FROM Trains AS t
JOIN Tickets as ti
ON t.Id = ti.TrainId
JOIN Towns AS [to]
ON t.ArrivalTownId = [to].Id
WHERE CAST(t.HourOfDeparture AS DATETIME) BETWEEN '08:00' AND '08:59' AND ti.Price > 50
ORDER BY ti.Price

SELECT * FROM Trains
SELECT * FROM Tickets
SELECT * FROM Towns

-- 09