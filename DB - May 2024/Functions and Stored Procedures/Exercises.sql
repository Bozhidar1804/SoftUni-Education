-- 01
CREATE PROCEDURE usp_GetEmployeesSalaryAbove35000
	AS
	BEGIN
		SELECT
			FirstName,
			LastName
		FROM Employees
		WHERE Salary > 35000
	END

EXEC usp_GetEmployeesSalaryAbove35000

-- 02
CREATE OR ALTER PROCEDURE [usp_GetEmployeesSalaryAboveNumber] @GivenValue DECIMAL(18, 4)
	AS
	BEGIN
		SELECT
			FirstName,
			LastName
		FROM Employees
		WHERE Salary >= @GivenValue
	END

EXEC usp_GetEmployeesSalaryAboveNumber 48100

-- 03
CREATE OR ALTER PROCEDURE usp_GetTownsStartingWith @Value VARCHAR(10)
	AS
	BEGIN
		SELECT
			[Name]
		FROM Towns
		WHERE [Name] LIKE @Value + '%'
	END

EXEC usp_GetTownsStartingWith 'b'
SELECT * FROM Towns

-- 04
CREATE PROCEDURE usp_GetEmployeesFromTown @TownName VARCHAR(20)
	AS
	BEGIN
		SELECT
			FirstName,
			LastName
		FROM Employees AS e
		JOIN Addresses AS a
		ON e.AddressID = a.AddressID
		JOIN Towns as t
		ON a.TownID = t.TownID
		WHERE t.[Name] = @TownName
	END

EXEC usp_GetEmployeesFromTown 'Sofia'

SELECT * FROM Employees
SELECT * FROM Addresses
SELECT * FROM Towns

-- 05
CREATE FUNCTION ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(10)
AS
BEGIN
	DECLARE @SalaryLevel NVARCHAR(10)

	IF(@salary < 30000)
	SET @SalaryLevel = 'Low'

	ELSE IF(@salary BETWEEN 30000 AND 50000)
	SET @SalaryLevel = 'Average'

	ELSE IF(@salary > 50000)
	SET @SalaryLevel = 'High'

	RETURN @SalaryLevel
END

SELECT
	Salary,
	dbo.ufn_GetSalaryLevel(Salary) AS [Salary Level]
FROM Employees

-- 06
CREATE PROCEDURE usp_EmployeesBySalaryLevel @LevelOfSalary VARCHAR(10)
	AS
	BEGIN
		SELECT
			FirstName AS [First Name],
			LastName AS [Last Name]
		FROM Employees
		WHERE dbo.ufn_GetSalaryLevel(Salary) = @LevelOfSalary
	END

EXEC usp_EmployeesBySalaryLevel 'High'

-- 07
CREATE FUNCTION ufn_IsWordComprised(@setOfLetters VARCHAR(50), @word VARCHAR(50))
RETURNS BIT
AS
BEGIN
	DECLARE @wordIndex INT = 1;

	WHILE (@wordIndex <= LEN(@word))
	BEGIN
		DECLARE @currentCharacter CHAR = SUBSTRING(@word, @wordIndex, 1)

		IF (CHARINDEX(@currentCharacter, @setOfLetters) = 0)
		BEGIN
			RETURN 0;
		END

		SET @wordIndex += 1;
	END
	RETURN 1;
END

SELECT dbo.ufn_IsWordComprised('oistmiahf', 'Sofia')

-- 08
CREATE PROCEDURE usp_DeleteEmployeesFromDepartment (@departmentId INT)
AS
BEGIN
	DECLARE @EmployeesToDelete TABLE ([ID] INT)
	INSERT INTO @EmployeesToDelete 
									SELECT EmployeeID
									FROM Employees
									WHERE DepartmentID = @departmentId
									
	DELETE
	FROM EmployeesProjects
	WHERE EmployeeID IN (
							SELECT *
							FROM @EmployeesToDelete
						)

	ALTER TABLE Departments
	ALTER COLUMN ManagerID INT

	UPDATE Departments
	   SET ManagerID = NULL
	WHERE ManagerID IN (
							SELECT *
							FROM @EmployeesToDelete
						)

	UPDATE Employees
	   SET ManagerID = NULL
	WHERE ManagerID IN (
							SELECT *
							FROM @EmployeesToDelete
						)

	DELETE
	FROM Employees
	WHERE DepartmentID = @departmentId

	DELETE
	FROM Departments
	WHERE DepartmentID = @departmentId

	SELECT COUNT(*)
	FROM Employees
	WHERE DepartmentID = @departmentId
END

-- 09 Bank Database
CREATE PROCEDURE usp_GetHoldersFullName
AS
BEGIN
	SELECT
		CONCAT(FirstName, ' ', LastName) AS [Full Name]
	FROM AccountHolders
END


-- 10
CREATE OR ALTER PROCEDURE usp_GetHoldersWithBalanceHigherThan(@Amount MONEY)
AS
BEGIN
	SELECT
		ah.FirstName AS [First Name],
		ah.LastName AS [Last Name]
	FROM AccountHolders AS ah
	JOIN Accounts AS a
	ON ah.Id = a.AccountHolderId
	GROUP BY ah.FirstName, ah.LastName
	HAVING SUM(a.Balance) > @Amount
	ORDER BY ah.FirstName, ah.LastName
END

EXEC usp_GetHoldersWithBalanceHigherThan 1000


-- 11
CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(10, 4), @Interest FLOAT, @Years INT)
RETURNS DECIMAL(10, 4)
AS
BEGIN
	DECLARE @CalculatedValue DECIMAL(10 , 4) = @Sum * (POWER((1 + @Interest), @Years))
	RETURN @CalculatedValue
END

SELECT dbo.ufn_CalculateFutureValue(1000, 0.1, 5) AS [Output] -- 1610.5100


-- 12
CREATE PROCEDURE usp_CalculateFutureValueForAccount(@AccountId INT, @Interest FLOAT)
AS
BEGIN
	SELECT
		a.Id AS [Account Id],
		ah.FirstName AS [First Name],
		ah.LastName AS [Last Name],
		a.Balance,
		dbo.ufn_CalculateFutureValue(a.Balance, @Interest, 5) AS [Balance in 5 years]
	FROM Accounts AS a
	JOIN AccountHolders AS ah
	ON a.AccountHolderId = ah.Id
	WHERE a.Id = @AccountId
END

EXEC usp_CalculateFutureValueForAccount 1, 0.1

SELECT * FROM Accounts
SELECT * FROM AccountHolders

-- 13 Diablo Database
CREATE FUNCTION ufn_CashInUsersGames (@GameName NVARCHAR(50))
RETURNS TABLE
AS
RETURN (
	SELECT
		SUM(Cash) AS [SumCash]
	FROM (
			SELECT 
				ug.Cash,
				ROW_NUMBER() OVER(ORDER BY ug.Cash DESC) AS [RowNumber]
			FROM UsersGames AS ug
			JOIN Games AS g
			ON ug.GameId = g.Id
			WHERE g.[Name] = @GameName
		 ) AS [RankingSubQuery]
		 WHERE RowNumber % 2 <> 0
		 )
