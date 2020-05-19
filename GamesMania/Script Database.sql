CREATE DATABASE GamesMania
GO

USE GamesMania
GO

CREATE TABLE Fabricante(
id_fabricante INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(50)
)

CREATE TABLE Jogo(
id_jogo INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(50),
id_fabricante INT,
FOREIGN KEY(id_fabricante) REFERENCES Fabricante(id_fabricante)
)

INSERT INTO Fabricante
VALUES('Nintendo'),('Sony'),('Microsoft')

INSERT INTO Jogo
VALUES('Mario', 1), ('FIFA20', 2), ('Forza', 3)


CREATE DATABASE GamesMania
GO

USE GamesMania
GO

CREATE TABLE Fabricante(
id_fabricante INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(50)
)

CREATE TABLE Jogo(
id_jogo INT PRIMARY KEY IDENTITY(1,1),
nome VARCHAR(50),
id_fabricante INT,
FOREIGN KEY(id_fabricante) REFERENCES Fabricante(id_fabricante)
)

INSERT INTO Fabricante
VALUES('Nintendo'),('Sony'),('Microsoft')

INSERT INTO Jogo
VALUES('Mario', 1), ('FIFA20', 2), ('Forza', 3)