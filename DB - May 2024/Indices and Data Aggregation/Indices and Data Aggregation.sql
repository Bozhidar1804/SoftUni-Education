-- 01
SELECT
	COUNT(*) AS [Count]
FROM WizzardDeposits

-- 02
SELECT
	MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits

-- 03
SELECT
	DepositGroup,
	MAX(MagicWandSize) AS [LongestMagicWand]
FROM WizzardDeposits
GROUP BY DepositGroup

-- 04
SELECT TOP (2)
	DepositGroup
FROM WizzardDeposits
GROUP BY DepositGroup
ORDER BY AVG(MagicWandSize)

-- 05
SELECT
	DepositGroup,
	SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
GROUP BY DepositGroup


-- 06
SELECT
	DepositGroup,
	SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup

-- 07 !!! useful exercise
SELECT
	DepositGroup,
	SUM(DepositAmount) AS [TotalSum]
FROM WizzardDeposits
WHERE MagicWandCreator = 'Ollivander family'
GROUP BY DepositGroup
HAVING SUM(DepositAmount) < 150000
ORDER BY [TotalSum] DESC


-- 08
SELECT
	DepositGroup,
	MagicWandCreator,
	MIN(DepositCharge) AS [MinDepositCharge]
FROM WizzardDeposits
GROUP BY DepositGroup, MagicWandCreator
ORDER BY MagicWandCreator, DepositGroup


-- 09
SELECT
	CASE
		WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		WHEN Age > 60 THEN '[61+]'
	END AS [AgeGroup],
	COUNT(*) AS [WizardCount]
FROM WizzardDeposits
GROUP BY CASE
	WHEN Age BETWEEN 0 AND 10 THEN '[0-10]'
		WHEN Age BETWEEN 11 AND 20 THEN '[11-20]'
		WHEN Age BETWEEN 21 AND 30 THEN '[21-30]'
		WHEN Age BETWEEN 31 AND 40 THEN '[31-40]'
		WHEN Age BETWEEN 41 AND 50 THEN '[41-50]'
		WHEN Age BETWEEN 51 AND 60 THEN '[51-60]'
		WHEN Age > 60 THEN '[61+]'
	END

-- 10
SELECT DISTINCT
	LEFT(FirstName, 1) AS [FirstLetter]
FROM WizzardDeposits
WHERE DepositGroup = 'Troll Chest'
GROUP BY LEFT(FirstName, 1)
ORDER BY FirstLetter

-- 11
SELECT
	DepositGroup,
	IsDepositExpired,
	AVG(DepositInterest) AS [AverageInterest]
FROM WizzardDeposits
WHERE DepositStartDate > '01/01/1985'
GROUP BY DepositGroup, IsDepositExpired
ORDER BY DepositGroup DESC, IsDepositExpired


-- 12 (first solution)
SELECT
	SUM([Difference]) AS [SumDifference]
FROM (
		SELECT
			FirstName AS [Host Wizard],
			DepositAmount AS [Host Wizard Deposit],
			LEAD(FirstName) OVER(ORDER BY Id) AS [Guest Wizard],
			LEAD(DepositAmount) OVER(ORDER BY Id) AS [Guest Wizard Deposit],
			DepositAmount - LEAD(DepositAmount) OVER(ORDER BY Id) AS [Difference]
		FROM WizzardDeposits
) AS [TableSubquery]

----- second solution
SELECT
	SUM([Difference]) AS [SumDifference]
FROM (
		SELECT 
			wd1.DepositAmount - wd2.DepositAmount AS [Difference]
		FROM WizzardDeposits AS [wd1]
		INNER JOIN WizzardDeposits AS [wd2]
		ON wd1.Id + 1 = wd2.Id
) AS [TableSubquery]


-- 13
SELECT
	DepartmentID,
	SUM(Salary) AS [TotalSalary]
FROM Employees
GROUP BY DepartmentID
ORDER BY DepartmentID


-- 14
SELECT
	DepartmentId,
	MIN(Salary) AS [MinimumSalary]
FROM Employees
WHERE DepartmentID IN (2, 5, 7) AND HireDate > '01/01/2000'
GROUP BY DepartmentID

-- 15
SELECT *
INTO NewTable
FROM Employees
WHERE Salary > 30000

DELETE FROM NewTable
WHERE ManagerID = 42

UPDATE NewTable
SET Salary += 5000
WHERE DepartmentID = 1

SELECT
	DepartmentID,
	AVG(Salary) AS [AverageSalary]
FROM NewTable
GROUP BY DepartmentID


-- 16
SELECT
	DepartmentID,
	MAX(Salary) AS [MaxSalary]
FROM Employees
GROUP BY DepartmentID
HAVING MAX(Salary) NOT BETWEEN 30000 AND 70000


-- 17
SELECT
	COUNT(EmployeeID) AS [Count]
FROM Employees
WHERE ManagerID IS NULL


-- 18
SELECT DISTINCT
	DepartmentID,
	Salary AS [ThirdHighestSalary]
FROM
	(
	SELECT
		DepartmentID,
		Salary,
		DENSE_RANK() OVER(PARTITION BY DepartmentId ORDER BY Salary DESC) AS [SalaryRank]
	FROM Employees
	) AS [RankingSalariesSubquery]
	WHERE SalaryRank = 3


-- 19

SELECT * FROM Employees
SELECT * FROM Departments