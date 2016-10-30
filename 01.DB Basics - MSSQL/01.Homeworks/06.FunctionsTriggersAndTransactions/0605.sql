CREATE FUNCTION ufn_GetSalaryLevel
(
  @Salary MONEY)
RETURNS NVARCHAR(7)
AS
BEGIN
RETURN
(
  SELECT CASE
           WHEN @Salary>50000
           THEN 'High'
           ELSE CASE
                  WHEN @Salary<=50000
                       AND @Salary>=30000
                  THEN 'Average'
                  ELSE 'Low'
                END
         END
);
END;