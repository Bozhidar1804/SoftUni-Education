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