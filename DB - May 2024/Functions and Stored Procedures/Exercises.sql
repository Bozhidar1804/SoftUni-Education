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