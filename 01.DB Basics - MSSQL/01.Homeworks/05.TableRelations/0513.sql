SELECT e.EmployeeID,
       e.FirstName,
       CASE
         WHEN YEAR(p.StartDate)>=2005
         THEN NULL
         ELSE p.Name
       END
AS ProjectName
FROM Employees e
INNER JOIN
EmployeesProjects ep
ON ep.EmployeeID=e.EmployeeID
    LEFT JOIN
    Projects p
    ON p.ProjectID=ep.ProjectID
WHERE e.EmployeeID=24;