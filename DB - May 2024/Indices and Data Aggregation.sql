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

SELECT * FROM WizzardDeposits