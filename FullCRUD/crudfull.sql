create database CRUDFULL

CREATE TABLE Marca(
IdMarca int identity(1,1) primary key,
Nombre varchar(50),
Descripcion varchar(100)
)
CREATE TABLE Categoria(
IdCategoria int identity(1,1) primary key,
Nombre varchar(50),
Descripcion varchar(100)
)

create table Producto
(
IdProducto int identity(1,1) primary key,
IdMarca int,
IdCategoria int,
Nombre varchar(50),
Descripcion varchar(100),
Precio decimal(18,4)

Constraint Relaciones_P_Categoria foreign key (IdCategoria) references Categoria(IdCategoria),
Constraint Relaciones_P_Marca foreign key (IdMarca) references Marca(IdMarca)
)

create table Usuario
(
idCliente int primary key identity (1,1),
Nombre varchar(50),
Apellido varchar(50),
Cedula nvarchar (50)
)
go

--Procedimientos Almacenados

--Ingresar

create proc spIngresarMarca
@idmarca int output,
@nombre varchar(50),
@descripcion varchar(100)
as insert into Marca(Nombre,Descripcion) values(@nombre,@descripcion)
go

create proc spIngresarCategoria
@idcategoria int output,
@nombre varchar(50),
@descripcion varchar(100)
as insert into Categoria(Nombre,Descripcion) values(@nombre,@descripcion)
go

create procedure spIngresarProductor
@idproducto int output,
@idmarca int,
@idcategoria int,
@nombre varchar(50),
@descripcion varchar(100),
@precio decimal(18,4)
as insert into Producto values(@idmarca,@idcategoria,@nombre,@descripcion,@precio)
go

exec spIngresarProductor null,1,1,'NOMBRE PRODUCTO','DESCRIPCION PRODUCTO',25.52

select * from Producto
select * from Marca

go

create procedure spModificarMarca
@idmarca int,
@nombre varchar(50),
@descripcion varchar(100)
as update Marca set
Nombre = @nombre,
Descripcion = @descripcion
where IdMarca = @idmarca

exec spModificarMarca 2,'Modificacion de MARCA','Descripcion de marca'

select * from Marca