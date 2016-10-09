CREATE TABLE Employees
(
  Id        INT IDENTITY
                PRIMARY KEY,
  FirstName VARCHAR(50) NOT NULL,
  LastName  VARCHAR(50) NOT NULL,
  Title     VARCHAR(50),
  Notes     VARCHAR(50));

CREATE TABLE Customers
(
  AccountNumber   INT IDENTITY
                      PRIMARY KEY,
  FirstName       VARCHAR(50) NOT NULL,
  LastName        VARCHAR(50) NOT NULL,
  PhoneNumber     VARCHAR(50),
  EmergencyName   VARCHAR(50),
  EmergencyNumber VARCHAR(50),
  Notes           VARCHAR(50));

CREATE TABLE RoomStatus
(
  RoomStatus VARCHAR(50) NOT NULL,
  Note       VARCHAR(50), );

CREATE TABLE RoomTypes
(
  RoomType VARCHAR(50) NOT NULL,
  Notes    VARCHAR(50));

CREATE TABLE BedTypes
(
  BedType VARCHAR(50) NOT NULL,
  Notes   VARCHAR(50));

CREATE TABLE Rooms
(
  RoomNumber INT IDENTITY
                 PRIMARY KEY,
  RoomType   VARCHAR(10) NOT NULL,
  BedType    VARCHAR(50) NOT NULL,
  Rate       FLOAT(2),
  RoomStatus VARCHAR(10),
  Notes      VARCHAR(50));

CREATE TABLE Payments
(
  Id                INT IDENTITY
                        PRIMARY KEY,
  EmployeeId        INT NOT NULL,
  PaymentDate       DATE,
  AccountNumber     INT,
  FirstDateOccupied DATE,
  LastDateOccupied  DATE,
  TotalDays         INT,
  AmountCharged     FLOAT(2),
  TaxRate           FLOAT(2),
  TaxAmount         FLOAT(2),
  PaymentTotal      FLOAT(2),
  Notes             VARCHAR(50));

CREATE TABLE Occupancies
(
  Id            INT IDENTITY
                    PRIMARY KEY,
  EmployeeId    INT NOT NULL,
  DateOccupied  DATE,
  AccountNumber INT NOT NULL,
  RoomNumber    INT NOT NULL,
  RateApplied   FLOAT(2),
  PhoneCharge   FLOAT(20),
  Notes         VARCHAR(50));

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
(FirstName,
 LastName)
VALUES
(
  'Tosho', 'Ivanov'),
(
  'Sasho', 'Georgiev'),
(
  'Mihso', 'Ganchev');

INSERT INTO RoomStatus
(RoomStatus)
VALUES
(
  'occupied'),
(
  'free'),
(
  'maintenance');

INSERT INTO RoomTypes
(RoomType)
VALUES
(
  'single'),
(
  'double'),
(
  'president');

INSERT INTO BedTypes
(BedType)
VALUES
(
  'couch'),
(
  'single bed'),
(
  'double bed');

INSERT INTO Rooms
(RoomType,
 BedType)
VALUES
(
  'single', 'couch'),
(
  'single', 'single bed'),
(
  'double', 'double bed');

INSERT INTO Payments
(EmployeeId)
VALUES
(
  1),
(
  2),
(
  1);

INSERT INTO Occupancies
(EmployeeId,
 AccountNumber,
 RoomNumber)
VALUES
(
  1, 1, 1),
(
  2, 2, 2),
(
  2, 1, 2);