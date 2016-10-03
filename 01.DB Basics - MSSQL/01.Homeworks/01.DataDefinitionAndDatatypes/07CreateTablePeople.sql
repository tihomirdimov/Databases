CREATE TABLE people
(
Id INT IDENTITY PRIMARY KEY,
Name NVARCHAR(200) NOT NULL,
Picture VARBINARY(max),
Height FLOAT(2),
Weight FLOAT(2),
Gender NVARCHAR(1) NOT NULL,
Birthdate DATE NOT NULL,
Biography NVARCHAR(max)
)

INSERT INTO
people(Name, Picture, Height, Weight, Gender, Birthdate, Biography)
VALUES
('User1', NULL, 1.40, 80.00, 'm', '1999-01-20', 'bio1'),
('User2', NULL, 1.50, 86.50, 'f', '2000-02-21', 'bio2'),
('User3', NULL, 1.60, 90.88, 'm', '2001-03-22', 'bio3'),
('User4', NULL, 1.70, 45.22, 'm', '2002-04-23', 'bio4'),
('user5', NULL, 1.80, 44.99, 'f', '1901-04-03', 'bio5')