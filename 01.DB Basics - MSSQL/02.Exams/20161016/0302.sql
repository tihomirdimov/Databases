SELECT e.CustomerID,
       e.FirstName+' '+e.LastName
AS 'Full Name',
       e.Gender
FROM Customers
AS e
ORDER BY [Full Name] ASC,
         CustomerID ASC;