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
SELECT CONCAT([FirstName], ' ', [MiddleName], ' ', [LastName])
    AS [Full Name]
  FROM Employees
 WHERE Salary = 25000 OR Salary = 14000 OR Salary = 12500 OR Salary = 23600