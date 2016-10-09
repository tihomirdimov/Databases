SELECT DepartmentID
      ,MIN(Salary) AS MinSalary
  FROM Employees AS e
 WHERE e.DepartmentID IN (2,5,7)
   AND e.HireDate > '20000101'
 GROUP BY DepartmentID