SELECT 
	Min(AvgTable.AverageDepSalary) AS MinAverageSalary
	FROM
(SELECT e.DepartmentID,
	AVG(e.Salary) AS AverageDepSalary
FROM Employees AS e
GROUP BY DepartmentID) AS [AvgTable]