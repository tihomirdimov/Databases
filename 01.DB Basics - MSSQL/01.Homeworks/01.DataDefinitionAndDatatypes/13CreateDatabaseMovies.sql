CREATE TABLE Directors 
(
Id INT IDENTITY PRIMARY KEY,
DirectorName VARCHAR(50) NOT NULL,
Notes VARCHAR(50),
)
CREATE TABLE Genres
(
Id INT IDENTITY PRIMARY KEY,
GenreName VARCHAR(50) NOT NULL,
Notes VARCHAR(50),
)
CREATE TABLE Categories
(
Id INT IDENTITY PRIMARY KEY,
CategoryName VARCHAR(50) NOT NULL,
Notes VARCHAR(50),
)
CREATE TABLE Movies
(
Id INT IDENTITY PRIMARY KEY,
Title VARCHAR(50) NOT NULL,
DirectorId INT,
CopyrightYear DATE,
Length INT,
GenreId INT,
CategoryId INT,
Rating INT,
Notes VARCHAR(50)
)

INSERT INTO
Directors (DirectorName)
VALUES
('Kubrick'),
('Hitchcock'),
('Spielberg'),
('Bay'),
('Moore')

INSERT INTO
Genres (GenreName)
VALUES
('Compedy'),
('Action'),
('Sci-fi'),
('Thriller'),
('Documentary')

INSERT INTO
Categories (CategoryName)
VALUES
('European'),
('Asian'),
('Erotic'),
('Noir'),
('Retro')

INSERT INTO
Movies (Title)
VALUES
('Fast and furious'),
('Mr. Nobody'),
('Interstellar'),
('Lucy'),
('Kill Bill Vol. 1')