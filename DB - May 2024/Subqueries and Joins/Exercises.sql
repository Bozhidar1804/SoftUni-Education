-- 01
SELECT TOP (5)
	e.EmployeeId,
	e.JobTitle,
	e.AddressId,
	a.AddressText
FROM Employees AS e
LEFT JOIN Addresses AS a -- LEFT JOIN because addresses are nullable
ON e.AddressID = a.AddressID
ORDER BY e.AddressID --e. because a.AddressID could be null

-- 02
SELECT TOP (50)
	e.FirstName,
	e.LastName,
	t.[Name] AS [Town],
	a.AddressText
FROM Employees AS e
JOIN Addresses AS a
ON e.AddressID = a.AddressID
JOIN Towns AS t
ON a.TownID = t.TownID
ORDER BY FirstName, LastName

-- 03
SELECT
	e.EmployeeID,
	e.FirstName,
	e.LastName,
	d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID AND d.[Name] = 'Sales'
ORDER BY EmployeeID


-- 04
SELECT TOP (5)
	e.EmployeeID,
	e.FirstName,
	e.Salary,
	d.[Name] AS [DepartmentName]
FROM Employees AS e
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID AND e.Salary > 15000
ORDER BY d.DepartmentID

-- 05
SELECT TOP (3)
	e.EmployeeID,
	e.FirstName
FROM Employees AS [e]
LEFT JOIN EmployeesProjects AS [ep]
ON e.EmployeeID = ep.EmployeeID
WHERE ep.ProjectID IS NULL

-- 06
SELECT
	e.FirstName,
	e.LastName,
	e.HireDate,
	d.[Name]
FROM Employees AS e
INNER JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE e.HireDate > '01-01-1999' AND d.[Name] IN('Sales', 'Finance')
ORDER BY e.HireDate

-- 07
SELECT TOP (5)
	e.EmployeeID,
	e.FirstName,
	p.[Name]
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID


-- 08
SELECT
	e.EmployeeID,
	e.FirstName,
	CASE
		WHEN p.StartDate > '01-01-2005' THEN NULL
		ELSE p.[Name]
	END AS [ProjectName]
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE e.EmployeeID = 24

-- 09
SELECT
	e.EmployeeID,
	e.FirstName,
	e.ManagerID,
	m.FirstName AS [ManagerName]
FROM Employees AS e
INNER JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
WHERE e.ManagerID IN(3,7)
ORDER BY e.EmployeeID

-- 10
SELECT TOP (50)
	e.EmployeeID,
	CONCAT(e.FirstName, ' ', e.LastName) AS [EmployeeName],
	CONCAT(m.FirstName, ' ', m.LastName) AS [ManagerName],
	d.[Name]
FROM Employees AS e
JOIN Employees AS m
ON e.ManagerID = m.EmployeeID
JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
ORDER BY e.EmployeeID

-- 11
SELECT TOP (1) (
	SELECT 
		AVG(Salary)
) AS [MinAverageSalary] FROM Employees
GROUP BY DepartmentID
ORDER BY MinAverageSalary


-- 12
SELECT
	c.CountryCode,
	m.MountainRange,
	p.PeakName,
	p.Elevation
FROM Peaks AS p
JOIN Mountains AS m
ON p.MountainId = m.Id
JOIN MountainsCountries AS mc
ON m.Id = mc.MountainId
JOIN Countries AS c
ON mc.CountryCode = c.CountryCode
WHERE c.CountryCode = 'BG' AND p.Elevation > 2835
ORDER BY p.Elevation DESC


-- 13
SELECT
	c.CountryCode,
	COUNT(*) AS [MountainRanges]
FROM MountainsCountries AS mc
JOIN Countries AS c
ON mc.CountryCode = c.CountryCode
JOIN Mountains AS m
ON mc.MountainId = m.Id
WHERE c.CountryCode IN ('US', 'BG', 'RU')
GROUP BY c.CountryCode


-- 14
SELECT TOP(5)
		c.CountryName,
		r.RiverName
FROM Countries AS c
LEFT JOIN CountriesRivers AS cr
ON c.CountryCode = cr.CountryCode
LEFT JOIN Rivers AS r
ON cr.RiverId = r.Id
JOIN Continents AS cont
ON cont.ContinentCode = c.ContinentCode
WHERE c.ContinentCode = 'AF'
ORDER BY c.CountryName


-- 16
SELECT
	COUNT(c.CountryCode) AS [Count]
FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
WHERE mc.MountainId IS NULL


-- 17
SELECT TOP(5)
	c.CountryName,
	MAX(p.Elevation) AS [HighestPeakElevation],
	MAX(r.[Length]) AS [LongestRiverLength]
FROM Countries AS c
LEFT OUTER JOIN MountainsCountries AS mc
ON c.CountryCode = mc.CountryCode
LEFT OUTER JOIN Peaks AS p
ON mc.MountainId = p.MountainId
LEFT OUTER JOIN CountriesRivers AS cr
ON c.CountryCode = cr.CountryCode
LEFT OUTER JOIN Rivers as r
ON cr.RiverId = r.Id
GROUP BY c.CountryName
ORDER BY [HighestPeakElevation] DESC, [LongestRiverLength] DESC

SELECT * FROM Continents
SELECT * FROM Countries
SELECT * FROM Mountains
SELECT * FROM MountainsCountries
SELECT * FROM CountriesRivers
SELECT * FROM Peaks
SELECT * FROM Rivers