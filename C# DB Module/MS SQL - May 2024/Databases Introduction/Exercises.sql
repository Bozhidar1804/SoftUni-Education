-- 1
CREATE DATABASE Minions

-- 2
CREATE TABLE Minions
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL,
	Age INT
)

CREATE TABLE Towns
(
	Id INT PRIMARY KEY,
	[Name] VARCHAR(100) NOT NULL
)

-- 3
ALTER TABLE Minions
	ADD [TownId] INT FOREIGN KEY REFERENCES Towns(Id)

-- 4
INSERT INTO Towns
VALUES
	(1, 'Sofia'),
	(2, 'Plovdiv'),
	(3, 'Varna')

INSERT INTO Minions
VALUES
	(1, 'Kevin', 22, 1),
	(2, 'Bob', 15, 3),
	(3, 'Steward', NULL, 2)

-- 5
TRUNCATE TABLE Minions

-- 6
DROP TABLE Minions
DROP TABLE Towns

-- 7
CREATE TABLE People 
(
	Id INT PRIMARY KEY IDENTITY,
	[Name] VARCHAR(200) NOT NULL,
	Picture VARBINARY(MAX) NULL,
	CHECK(DATALENGTH(PICTURE) <= 2000000),
	Height DECIMAL(3, 2) NULL,
	Weight DECIMAL(5, 2) NULL,
	Gender CHAR(1) NOT NULL,
	CHECK(Gender = 'f' OR Gender = 'm'),
	Birthdate DATE NOT NULL,
	Biography NVARCHAR(MAX) NULL
)

INSERT INTO People
VALUES
	('Bozhidar', null, 1.80, 80, 'm', '04-18-2006', 'Wants to be a millionaire'),
	('Georgi', null, 1.85, 85, 'm', '01-12-2002', 'Wants to be a teacher'),
	('Petar', null, 1.90, 90, 'm', '06-20-2003', 'Wants to be an entrepreneur'),
	('Ivailo', null, 1.61, 50, 'm', '10-01-1999', 'Wants to be an athlete'),
	('Plamen', null, 1.85, 83, 'm', '12-06-2015', 'Wants to be a millionaire too')


-- 8
CREATE TABLE Users 
(
	Id BIGINT PRIMARY KEY IDENTITY,
	Username VARCHAR(30) NOT NULL,
	[Password] VARCHAR(26) NOT NULL,
	ProfilePicture VARBINARY(MAX),
	-- LIMIT TO 90 000 !!!
	LastLoginTime DATETIME2,
	IsDeleted BIT
)

INSERT INTO Users
VALUES
	('Bozhidar', '1804ad', null, '04-18-2024', 0),
	('Georgi', '123415', null, '12-12-2023', 1),
	('Ivan', '1234524', null, '09-23-2022', 0),
	('Petar', '12341235', null, '06-04-2021', 1),
	('Pavel', '1234135', null, '02-01-2024', 0)

DROP TABLE Users

-- 9
ALTER TABLE [Users] 
DROP CONSTRAINT PK__Users__3214EC077EB52C51;

ALTER TABLE [Users]
ADD CONSTRAINT PK_IdUsername PRIMARY KEY (Id, Username);

-- 10
ALTER TABLE [Users]
ADD CONSTRAINT CHK_PasswordMinLen CHECK(LEN([Password]) >= 5);

-- 11
ALTER TABLE [Users]
ADD CONSTRAINT DF_LastLoginCurrent DEFAULT GETDATE() FOR [LastLoginTime];

INSERT INTO [Users] ([Username], [Password], IsDeleted)
VALUES
	('Pesho', '123asd', 0)

-- 12
ALTER TABLE [Users]
DROP CONSTRAINT PK_IdUsername

ALTER TABLE [Users]
ADD CONSTRAINT PK_Id PRIMARY KEY (Id);

ALTER TABLE [Users]
ADD CONSTRAINT UC_Username UNIQUE (Username);

ALTER TABLE [Users]
ADD CONSTRAINT CHK_UsernameMinLen CHECK(LEN([Username]) >= 3);

-- 13

