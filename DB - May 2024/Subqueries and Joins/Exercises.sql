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