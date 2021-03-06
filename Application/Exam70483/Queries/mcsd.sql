CREATE TABLE Persona
(
   ID_column INT NOT NULL IDENTITY(1,1) PRIMARY KEY,
   [NombreCompleto]  nvarchar(128)     not null, 
   [ProfesionOficio] nvarchar(256)     not null 
);

/**********************************/
-- ACCESS LOG
/**********************************/

use [Exam70483Web-db]
/**********************************/
DELETE FROM [dbo].[accessLogs];
/**********************************/
/**********************************/
-- PESONAS
/**********************************/

use [Exam70483Web-db]
/**********************************/
insert into [Persona] ([NombreCompleto],[ProfesionOficio]) values ('Pablo Alejandro Pérez Acosta','Técnico Sistemas');
/**********************************/
delete from persona where id=4;

update persona set nombrecompleto='Roberto Alejandro Blanco Pulido' where id=24;

select * from Persona;

/**********************************/
-- 2020-09-01 corregir tabla persona
/**********************************/
use [Exam70483Web-db]

ALTER TABLE [dbo].[Persona] ALTER COLUMN [NombreCompleto] VARCHAR (64);

ALTER TABLE [dbo].[Persona] ALTER COLUMN [ProfesionOficio] VARCHAR (255);

update [dbo].[Persona] set NombreCompleto='Hernán Gutiérrez Bernal',[ProfesionOficio]='<pendiente>' where id=2;

update [dbo].[Persona] set NombreCompleto='Leonardo Salazar García',[ProfesionOficio]='Odontólogo' where id=5;

update [dbo].[Persona] set NombreCompleto='María Victoria Gil Daza',[ProfesionOficio]='Zootecnista / Comerciante' where id=7;

update [dbo].[Persona] set NombreCompleto='Pablo Alejandro Pérez Acosta',[ProfesionOficio]='Técnico Sistemas' where id=8;

update [dbo].[Persona] set NombreCompleto='Javier Mauricio Villalobos',[ProfesionOficio]='Construcción / Topografía' where id=9;

update [dbo].[Persona] set NombreCompleto='Martha Lucía Caicedo Barahona', [ProfesionOficio]='Gastrónoma' where id=12;

update [dbo].[Persona] set NombreCompleto='Fernando A. Pardo', [ProfesionOficio]='Abogado' where id=13;

update [dbo].[Persona] set NombreCompleto='Nelson Dueñas', [ProfesionOficio]='Ingeniero de Sistemas / Restaurador Muebles Antíguos y Modernos' where id=15;

update [dbo].[Persona] set NombreCompleto='Libardo Orduña Amado', [ProfesionOficio]='Publicísta' where id=16;

update [dbo].[Persona] set NombreCompleto='Ariel Herrera Higuera', [ProfesionOficio]='Ingeniero Mecánico' where id=18;

update [dbo].[Persona] set NombreCompleto='Mario Enrique Rubiano Monroy', [ProfesionOficio]='Ingeniero Civil - Diseñador Estructural' where id=19;

update [dbo].[Persona] set NombreCompleto='Liliana Alexandra Gómez Gelves', [ProfesionOficio]='Diseño de Modas' where id=20;

update [dbo].[Persona] set NombreCompleto='Miguel José Pérez González', [ProfesionOficio]='Ingeniero Mecánico / Especialidad Ingeniería de la Calidad / Aspirante de Maestría en Ingeniería con Énfasis en Mecánica ' where id=21;

update [dbo].[Persona] set NombreCompleto='Javier Posada Sandoval', [ProfesionOficio]='Psicólogo' where id=22;

update [dbo].[Persona] set NombreCompleto='Ana María Puerto Rojas', [ProfesionOficio]='Tecnología en Proyectos Productivos de Planificación y Mercadeo / Analísta Contable' where id=23;

update [dbo].[Persona] set NombreCompleto='Roberto Alejandro Blanco Pulido', [ProfesionOficio]='Ingeniero de Alimentos / Especialista en Gerencia de Proyectos en ingeniería / Candidato a Maestrante en Administración de Empresas - MBA' where id=24;

insert into [dbo].[Persona]
( 
  [NombreCompleto]
 ,[ProfesionOficio]
 ,[Email]
 ,[Telefono]
 ,[Ciudad]
 ,[DescripcionServicio]
 ,[Observaciones]
 )
 values
 (
  'Diego Alejandro Gaitán Rico' --[NombreCompleto]
 ,'Ing de Sistemas / Esp Sist de Calidad, Riesgos & Medio Ambiente / Coach Innovación SIT ' --[ProfesionOficio]
 ,'d_gaitan_r@hotmail.com' -- [Email]
 ,'3102417184' --[Telefono]
 ,'Bogotá' -- [Ciudad]
 ,'Asesoramiento en la plantación de nuevos proyectos, desarrollo de soluciones de innovación en procesos, productos y servicios 	Para lo que requieran a sus órdenes' -- [Descripción Servicio]
 ,''--[Observaciones]
 );

 update dbo.persona set id=1 where NombreCompleto='Diego Alejandro Gaitán Rico';

 /*********************************/

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Hernán Gutiérrez Bernal','pendiente');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Leonardo Salazar García','Odontólogo');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('María Victoria Gil Daza','Zootecnista / Comerciante');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Javier Mauricio Villalobos','Construcción / Topografía');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Martha Lucía Caicedo Barahona','Gastrónoma');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Fernando A. Pardo', 'Abogado');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Nelson Dueñas', 'Ingeniero de Sistemas / Restaurador Muebles Antíguos y Modernos');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Libardo Orduña Amado','Publicísta');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Ariel Herrera Higuera','Ingeniero Mecánico');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Mario Enrique Rubiano Monroy', 'Ingeniero Civil - Diseñador Estructural');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Liliana Alexandra Gómez Gelves','Diseño de Modas');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Miguel José Pérez González', 'Ingeniero Mecánico / Especialidad Ingeniería de la Calidad / Aspirante de Maestría en Ingeniería con Énfasis en Mecánica ');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Javier Posada Sandoval', 'Psicólogo');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Ana María Puerto Rojas', 'Tecnología en Proyectos Productivos de Planificación y Mercadeo / Analísta Contable');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Roberto Alejandro Blanco Pulido', 'Ingeniero de Alimentos / Especialista en Gerencia de Proyectos en ingeniería / Candidato a Maestrante en Administración de Empresas - MBA');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Glenda Amaya', 'Ingeniera de Sistemaas');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Carlos Francisco Reina', 'Médico Veterinario');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Christian Bohorquez', 'Analísta de Sistemas');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Mario Enrique Rubiano', 'Ingeniero Civil / Diseñador Estructural');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Diego Alejandro Gaitán Rico', 'Ing de Sistemas / Esp Sist de Calidad, Riesgos & Medio Ambiente / Coach Innovación SIT ');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Liliana Alexandra Gomez', 'Diseñadora de Modas');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Alex Fernando Miranda Urrego', 'Independiente / Comerciante ');

INSERT INTO [Persona] ([NombreCompleto],[ProfesionOficio]) VALUES('Henry Casadiego', 'Ingeniero de Petróleos');

/**********************************/

use [mcsdexnacato]

update  [dbo].[Persona] set ProfesionOficio='Independiente / Instructor Canino' where id_column = 2;

SELECT 
	 ID_column
    ,[NombreCompleto]
    ,[ProfesionOficio]
FROM
    [dbo].[Persona]
ORDER BY 
    ID_column;

/**********************************/
ALTER TABLE [dbo].[accessLogs] ADD  [IpValue] VARCHAR (32) NULL;		
ALTER TABLE [dbo].[accessLogs] ADD  [LogType] tinyint null;

select dateadd(hour,-5,getdate())

update accessLogs set AccessDate = dateadd(hour,-5,AccessDate)

delete from accessLogs;

/*
	LOG Type

	1 = INFO
	2 = DEBUG
	3 = ERROR
*/

update [dbo].[accessLogs] set LogType = 1;

/**********************************/

use [mcsdexnacato]

delete from accessLogs where id_column in
(83309
,83308
,83307
,83312
,83315
,83314
,83315
,83315
,83315
,83317
,83315
,83317);

/**********************************/

use [mcsdexnacato]

SELECT [ID_column]
      ,[PageName]
      ,[AccessDate]
	  ,[IpValue]
	  ,[LogType]
  FROM [dbo].[accessLogs] order by [ID_column] desc ;

/**********************************/


