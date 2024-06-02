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