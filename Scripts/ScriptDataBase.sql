use Escuela
go

create table dbo.Alumno(
Id int identity (1,1) primary key,
Codigo nvarchar(20) not null unique,
Nombre nvarchar(100) not null,
Ciclo int,
Curso int,
Estado bit default 1,
Version RowVersion
)
go

create table dbo.Calificacion(
Id int identity(1,1) primary key,
IdAlumno int references dbo.Alumno(Id) not null,
IdTipoEvaluacion int not null,
Nota decimal(4,2) null
)
go


insert into dbo.Alumno(
	Codigo,
	Nombre,
	Ciclo,
	Curso,
	Estado
)
values
('I201810001','Gabriela Loredo Gomez',3,1,1),
('I201810002','Luis Armando Sanchez Garcia',4,2,1),
('I201810003','Luis Armando Sanchez Loredo',5,3,1),
('I201810004','Matias Sanchez Loredo',6,4,1)
go

insert into dbo.Calificacion(
	IdAlumno,
	IdTipoEvaluacion,
	Nota
)
values
(1,1,14.5),
(1,2,15.0),
(1,3,16.5),
(1,4,17.0),
(1,5,18.5),
(2,1,17.0),
(2,2,16.5),
(2,3,15.0),
(2,4,14.5),
(2,5,13.0),
(3,1,12.5),
(3,2,13.0),
(3,3,14.5),
(3,4,15.0),
(3,5,16.5),
(4,1,17.0),
(4,2,15.5),
(4,3,12.0),
(4,4,11.5),
(4,5,NULL)
GO