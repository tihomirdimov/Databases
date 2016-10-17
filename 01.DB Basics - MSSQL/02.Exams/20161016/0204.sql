CREATE TABLE CustomerReviews
(
  ReviewID      INT PRIMARY KEY,
  ReviewContent VARCHAR(255) NOT NULL,
  ReviewGrade   TINYINT CHECK(ReviewGrade>=0
                              AND ReviewGrade<=10),
  AirlineID     INT,
  CustomerID    INT,
  CONSTRAINT FK_CustomerReviews_Airlines FOREIGN KEY(AirlineID) REFERENCES Airlines(AirlineID),
  CONSTRAINT FK_CustomerReviews_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID));

CREATE TABLE CustomerBankAccounts
(
  AccountID     INT PRIMARY KEY,
  AccountNumber VARCHAR(10) NOT NULL
                            UNIQUE,
  Balance       DECIMAL(10, 2) NOT NULL,
  CustomerID    INT,
  CONSTRAINT FK_CustomerBankAccounts_Customers FOREIGN KEY(CustomerID) REFERENCES Customers(CustomerID));