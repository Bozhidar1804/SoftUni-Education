-- 01
SELECT 
	FirstName,
	LastName
FROM Employees
WHERE FirstName LIKE 'Sa%'

-- 02
SELECT
	FirstName,
	LastName
FROM Employees
WHERE LastName LIKE '%ei%'

-- 03
SELECT 
	FirstName
FROM Employees
WHERE DepartmentID IN(3, 10) AND YEAR([HireDate]) BETWEEN 1995 AND 2005

-- 04
SELECT 
	FirstName,
	LastName
FROM Employees
WHERE JobTitle NOT LIKE '%engineer%'

-- 05
SELECT 
	[Name]
FROM Towns
WHERE LEN([Name]) IN(5, 6)
ORDER BY [Name]

-- 06
SELECT
	TownID,
	[Name]
FROM Towns
WHERE LEFT([Name], 1) IN ('M', 'K', 'B', 'E')
-- WHERE [NAME] LIKE '[MKBE%]'
ORDER BY [Name]


-- 07
SELECT
	TownID,
	[Name]
FROM Towns
WHERE LEFT([Name], 1) NOT IN ('R', 'B', 'D')
ORDER BY [Name]


--08
CREATE VIEW [V_EmployeesHiredAfter2000] AS
SELECT
	FirstName,
	LastName
FROM Employees
WHERE YEAR([HireDate]) > 2000


-- 09
SELECT
	FirstName,
	LastName
FROM Employees
WHERE LEN(LastName) = 5

-- 10
SELECT
	EmployeeID,
	FirstName,
	LastName,
	Salary,
	DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
FROM Employees
WHERE Salary BETWEEN 10000 AND 50000
ORDER BY Salary DESC

-- 11
SELECT *
FROM (
			SELECT
				EmployeeID,
				FirstName,
				LastName,
				Salary,
				DENSE_RANK() OVER (PARTITION BY Salary ORDER BY EmployeeID) AS [Rank]
			FROM Employees
			WHERE Salary BETWEEN 10000 AND 50000
      ) AS [RankingSubquery]
WHERE [Rank] = 2
ORDER BY Salary DESC

---
GO

USE [Geography]

GO
---

-- 12 METHOD 1
SELECT 
	CountryName AS [Country Name],
	IsoCode AS [ISO Code]
FROM Countries
WHERE LOWER(CountryName) LIKE '%a%a%a%'
ORDER BY IsoCode

-- 12 METHOD 2
SELECT
	CountryName as [Country Name],
	IsoCode as [ISO Code]
FROM Countries
WHERE LEN([CountryName]) - LEN(REPLACE(LOWER([CountryName]), 'a', '')) >= 3
ORDER BY IsoCode

-- 13
SELECT p.PeakName,
	   r.RiverName,
	   LOWER(CONCAT(SUBSTRING(p.PeakName, 1, LEN(p.PeakName) - 1), r.RiverName)) AS [Mix]
FROM Peaks AS p,
	 Rivers as r
WHERE RIGHT(LOWER(p.PeakName), 1) = LEFT (LOWER(r.RiverName), 1)
ORDER BY Mix

	 
----
GO

USE Diablo

GO
----

-- 14
SELECT TOP(50)
	[Name],
	CONVERT(char(10), [Start],126) AS [Start]
FROM Games
WHERE YEAR([Start]) IN (2011, 2012)
ORDER BY [Start], [Name]


-- 15
SELECT
	Username,
	SUBSTRING([Email], CHARINDEX('@', [Email], 1) + 1, LEN([Email])) AS [Email Provider]
FROM Users
ORDER BY [Email Provider], Username

-- 16
SELECT 
	Username,
	IpAddress AS [IP Address]
FROM Users
WHERE IpAddress LIKE '___.1%.%.___'
ORDER BY Username

-- 17
SELECT
	[Name] AS [Game],
	CASE
		WHEN DATEPART(HOUR, [Start]) >= 0 AND DATEPART(HOUR, [Start]) < 12 THEN 'Morning'
		WHEN DATEPART(HOUR, [Start]) >= 12 AND DATEPART(HOUR, [Start]) < 18 THEN 'Afternoon'
		WHEN DATEPART(HOUR, [Start]) >= 18 AND DATEPART(HOUR, [Start]) < 24 THEN 'Evening'
	END AS [Part of the Day],
	CASE
		WHEN Duration <= 3 THEN 'Extra Short'
		WHEN Duration BETWEEN 4 AND 6 THEN 'Short'
		WHEN Duration > 6 THEN 'Long'
		When Duration IS NULL THEN 'Extra Long'
	END AS [Duration]
FROM Games
ORDER BY [Name], Duration, [Part of the Day]

----
GO

USE Orders

GO
----

-- 18
SELECT
	ProductName,
	OrderDate,
	DATEADD(DAY, 3, OrderDate) AS [Pay Due],
	DATEADD(MONTH, 1, OrderDate) AS [Deliver Due]
FROM Orders