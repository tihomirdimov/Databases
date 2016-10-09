CREATE TABLE Teachers
(
  TeacherID INT NOT NULL
                CONSTRAINT PK_Teachers_TeacherID PRIMARY KEY,
  Name      NVARCHAR(300) NOT NULL,
  ManagerID INT CONSTRAINT FK_Teachers_ManagerID_Teachers_TeacherID REFERENCES Teachers(TeacherID));

INSERT INTO Teachers
VALUES
(
  101, 'John', NULL),
(
  102, 'Maya', 106),
(
  103, 'Silvia', 106),
(
  104, 'Ted', 105),
(
  105, 'Mark', 101),
(
  106, 'Greta', 101);