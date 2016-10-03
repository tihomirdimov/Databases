CREATE TABLE Users
(
Id BIGINT IDENTITY PRIMARY KEY,
Username NVARCHAR(30) NOT NULL,
Password VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(900),
LastLoginTime TIME,
IsDeleted BIT,
)

INSERT INTO
Users (Username, Password)
VALUES
('User1', 'Pass1'),
('User2', 'Pass2'),
('User3', 'Pass3'),
('User4', 'Pass4'),
('User5', 'Pass5')