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

-- 07
SELECT TOP (5)
	e.EmployeeID,
	e.FirstName,
	p.[Name]
FROM Employees AS e
LEFT JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
LEFT JOIN Projects AS p
ON ep.ProjectID = p.ProjectID
WHERE p.StartDate > '2002-08-13' AND p.EndDate IS NULL
ORDER BY e.EmployeeID
