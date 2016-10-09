CREATE TABLE Categories
(
  Id          INT IDENTITY
                  PRIMARY KEY,
  Category    VARCHAR(50) NOT NULL,
  DailyRate   FLOAT(2),
  WeeklyRate  FLOAT(2),
  MonthlyRate FLOAT(2),
  WeekendRate FLOAT(2)
  );

CREATE TABLE cars
(
  Id          INT IDENTITY
                  PRIMARY KEY,
  PlateNumber VARCHAR(50) NOT NULL,
  Make        VARCHAR(50),
  Model       VARCHAR(50),
  CarYear     DATE,
  CategoryId  INT,
  Doors       INT,
  Picture     VARBINARY(900),
  Condition   VARCHAR(50),
  Available   BIT);

CREATE TABLE Employees
(
  Id        INT IDENTITY
                PRIMARY KEY,
  FirstName VARCHAR(50) NOT NULL,
  LastName  VARCHAR(50) NOT NULL,
  Title     VARCHAR(10),
  Notes     VARCHAR(50));

CREATE TABLE Customers
(
  Id                  INT IDENTITY
                          PRIMARY KEY,
  DriverLicenceNumber VARCHAR(10) NOT NULL,
  FullName            VARCHAR(50),
  Address             VARCHAR(50),
  City                VARCHAR(50),
  ZIPCode             INT,
  Notes               VARCHAR(50));

CREATE TABLE RentalOrders
(
  Id               INT IDENTITY
                       PRIMARY KEY,
  EmployeeId       INT NOT NULL,
  CustomerId       INT NOT NULL,
  CarId            INT,
  CarCondition     VARCHAR(50),
  TankLevel        INT,
  KilometrageStart INT,
  KilometrageEnd   INT,
  TotalKilometrage INT,
  StartDate        DATE,
  EndDate          DATE,
  TotalDays        INT,
  RateApplied      FLOAT(2),
  TaxRate          FLOAT(2),
  OrderStatus      BIT,
  Notes            VARCHAR(50));

INSERT INTO Categories
(Category)
VALUES
(
  'van'),
(
  'sedan'),
(
  'coupe');

INSERT INTO Cars
(PlateNumber)
VALUES
(
  'CA9999TT'),
(
  'PK7777AA'),
(
  'OB4444AP');

INSERT INTO Employees
(FirstName,
 LastName)
VALUES
(
  'Ivan', 'Ivanov'),
(
  'Pesho', 'Golfov'),
(
  'Grisha', 'Ganchev');

INSERT INTO Customers
(DriverLicenceNumber)
VALUES
(
  'CB0101TT'),
(
  'PK7667AA'),
(
  'EB8202AA');

INSERT INTO RentalOrders
(EmployeeId,
 CustomerId)
VALUES
(
  1, 2),
(
  2, 2),
(
  1, 3);