-- Crear la tabla Autor
CREATE TABLE Autor (
    AutorID INT PRIMARY KEY IDENTITY(1,1),  -- Clave primaria, se autoincrementa
    Nombre NVARCHAR(max) NOT NULL            -- Nombre del autor
);

-- Crear la tabla Libro
CREATE TABLE Libro (
    LibroID INT PRIMARY KEY IDENTITY(1,1),   -- Clave primaria, se autoincrementa
    Titulo NVARCHAR(max) NOT NULL,           -- Título del libro
    AutorID INT,                              -- Clave foránea que referencia a Autor
    CONSTRAINT FK_Libro_Autor FOREIGN KEY (AutorID) REFERENCES Autor(AutorID) -- Definición de la clave foránea
);
