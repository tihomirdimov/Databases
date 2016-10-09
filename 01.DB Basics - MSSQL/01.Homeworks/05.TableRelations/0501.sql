CREATE TABLE Passports
(PassportID     INT NOT NULL
                    CONSTRAINT PK_Passports_PassportID PRIMARY KEY,
 PassportNumber NVARCHAR(200) NOT NULL
);
CREATE TABLE Persons
(PersonID   INT NOT NULL
                CONSTRAINT PK_Persons_PersonID PRIMARY KEY,
 FirstName  NVARCHAR(150) NOT NULL,
 Salary     MONEY NOT NULL,
 PassportID INT CONSTRAINT FK_Persons_PassportID_Passports_PassportID REFERENCES Passports(PassportID)
);