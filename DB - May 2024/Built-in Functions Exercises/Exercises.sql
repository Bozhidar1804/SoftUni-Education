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
