create database JOSE_FARIAS
go

use JOSE_FARIAS
GO

create table Usuario(
idusuario int primary key identity,
nombre nvarchar(100),
correo nvarchar(200),
clave nvarchar(300)
)
go

create table tarea(
idtarea int primary key identity,
titulo nvarchar(100),
descripcion nvarchar(500),
fecha_creacion datetime2 default current_timestamp,
completada bit default 0
)
go

INSERT into Usuario(nombre, correo, clave)
values('José Farias', 'jose@mail.com', '12345')
go

insert into tarea(titulo, descripcion) values('Aprender C#', 'Aprender y practicar C#')
go

select * from tarea
go