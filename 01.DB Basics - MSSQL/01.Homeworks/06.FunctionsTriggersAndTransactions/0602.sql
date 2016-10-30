CREATE PROCEDURE usp_GetEmployeesSalaryAboveNumber
  @EmployeeSalary MONEY
AS
BEGIN
SELECT e.FirstName,
       e.LastName
FROM Employees e
WHERE e.Salary>=@EmployeeSalary;
END;