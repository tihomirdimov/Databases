CREATE TABLE dbo.Towns
(Id   INT IDENTITY
          PRIMARY KEY,
 Name VARCHAR(50) NOT NULL
);
CREATE TABLE dbo.Addresses
(Id          INT IDENTITY
                 PRIMARY KEY,
 AddressText VARCHAR(50) NOT NULL,
 TownId      INT NOT NULL,
);
CREATE TABLE dbo.Departments
(Id   INT IDENTITY
          PRIMARY KEY,
 Name VARCHAR(50) NOT NULL
);
CREATE TABLE dbo.Employees
(Id           INT IDENTITY
                  PRIMARY KEY,
 FirstName    VARCHAR(50) NOT NULL,
 MiddleName   VARCHAR(50),
 LastName     VARCHAR(50) NOT NULL,
 JobTitle     VARCHAR(50) NOT NULL,
 DepartmentId INT NOT NULL,
 HireDate     DATE,
 Salary       FLOAT(2),
 AddressId    INT
);