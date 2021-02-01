CREATE TABLE Persona
(
   ID_column INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
   [NombreCompleto]  nvarchar(128)     not null, 
   [ProfesionOficio] nvarchar(256)     not null 
);
