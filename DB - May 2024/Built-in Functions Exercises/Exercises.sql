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