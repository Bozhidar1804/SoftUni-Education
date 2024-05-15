-- 02
SELECT *
  FROM [Departments]

-- 03
SELECT [Name]
  FROM [Departments]

-- 04
SELECT [FirstName], [LastName], [Salary]
  FROM Employees

-- 05
SELECT [FirstName], [MiddleName], [LastName]
  FROM Employees

-- 06
SELECT CONCAT([FirstName], '.', [LastName], '@', 'softuni.bg')
	AS [Full Email Address]
  FROM Employees

-- 07
SELECT DISTINCT [Salary]
           FROM Employees

-- 08
SELECT *
  FROM Employees
 WHERE [JobTitle] = 'Sales Representative'

-- 09
SELECT [FirstName], [LastName], [JobTitle]
  FROM Employees
 WHERE Salary >= 20000 AND Salary <= 30000

-- 10
SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName]) -- SELECT CONCAT_WS(' ', ....)
    AS [Full Name]
  FROM Employees
 WHERE Salary IN (25000, 14000, 12500, 23600)

-- 11
SELECT [FirstName], [LastName]
  FROM Employees
 WHERE ManagerID IS NULL

-- 12
SELECT [FirstName], [LastName], [Salary]
  FROM Employees
 WHERE Salary > 50000
 ORDER BY Salary DESC

-- 13
SELECT TOP (5) [FirstName], [LastName]
  FROM Employees
ORDER BY Salary DESC

-- 14
SELECT [FirstName], [LastName]
  FROM Employees
WHERE DepartmentID <> 4

-- 15
  SELECT *
    FROM Employees
ORDER BY [Salary] DESC,
         [FirstName],
		 [LastName] DESC,
		 [MiddleName]

-- 16
CREATE VIEW [V_EmployeesSalaries]
         AS (
				SELECT [FirstName], [LastName], [Salary]
				  FROM Employees
		    )

-- 17
CREATE VIEW [V_EmployeeNameJobTitle]
		 AS (
				SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName])
					AS [Full Name],
					   [JobTitle]
					AS [Job Title]
				  FROM Employees 
			)

-- 18
SELECT DISTINCT [JobTitle]
		   FROM Employees

-- 19
SELECT TOP (10) *
      FROM Projects
  ORDER BY [StartDate], [Name]

-- 20
