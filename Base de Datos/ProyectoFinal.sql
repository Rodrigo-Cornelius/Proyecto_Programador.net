use master
go

if exists(select * from sysdatabases where name = 'Proyecto')
begin
	drop database Proyecto
end
go

create database Proyecto
go

use Proyecto
go

-------------------------------------------------------------------------------------

-- TABLAS

create table Paises
(
	CodigoP varchar(3) not null primary key check(CodigoP like '[A-Z][A-Z][A-Z]'),
	Nombre varchar(30) not null check(LEN(Nombre) > 0) 
)
go

create table Ciudades
(
	CodigoC varchar(3) not null check(CodigoC like '[A-Z][A-Z][A-Z]'),
	Nombre varchar(30) not null check(LEN(Nombre) > 0),
	CodigoP varchar(3) not null foreign key references Paises(CodigoP),
	primary key(CodigoC, CodigoP)
)
go

create table Usuarios
(
	UserName varchar(30) not null primary key check(LEN(UserName) >= 3),
	Pass varchar(30) not null check(LEN(Pass) >= 8),
	Nombre varchar(30) not null check(LEN(Nombre) > 0),
	Apellido varchar(30) not null check(LEN(Apellido) > 0)
)
go

create table Pronosticos
(
	Codigo int not null identity primary key,
	ProbLluvias int not null check(ProbLluvias >= 0 and ProbLluvias <= 100),
	FechaHora datetime not null, check(FechaHora >= GETDATE()),
	TipoCielo varchar(19) not null check (TipoCielo in('Despejado', 'Parcialmente nuboso', 'Nuboso')),
	VelViento int not null check(VelViento > 0),
	MaxTemp int not null,
	MinTemp int not null,
	CodigoC varchar(3) not null,
	CodigoP varchar(3) not null,
	foreign key (CodigoC, CodigoP) references Ciudades(CodigoC, CodigoP),
	UserName varchar(30) not null foreign key references Usuarios(UserName)
)
go

-------------------------------------------------------------------------------------

-- DATOS DE PRUEBA

insert Paises values ('URU', 'Uruguay'),
					 ('ARG', 'Argentina'),
					 ('BRA', 'Brasil'),
					 ('ESP', 'España'),
					 ('ALE', 'Alemania'),
					 ('POR', 'Portugal')
go

insert Ciudades values ('MON', 'Montevideo', 'URU'),
					   ('MAL', 'Maldonado', 'URU'),
					   ('RIV', 'Rivera', 'URU'),
					   ('BAS', 'Buenos Aires', 'ARG'),
					   ('COR', 'Cordoba', 'ARG'),
					   ('TFU', 'Tierra del Fuego', 'ARG'),
					   ('BRA', 'Brasilia', 'BRA'),
					   ('RIO', 'Rio de Janeiro', 'BRA'),
					   ('FOR', 'Fortaleza', 'BRA'),
					   ('BAR', 'Barcelona', 'ESP'),
					   ('MAD', 'Madrid', 'ESP'),
					   ('COR', 'Coruña', 'ESP'),
					   ('MUN', 'Munich', 'ALE'),
					   ('NUR', 'Nuremberg', 'ALE'),
					   ('BER', 'Berlin', 'ALE')
go

insert Usuarios values ('tmcpharlain0', 'lEX85fZH', 'Thelma', 'McPharlain'),
					   ('ciorizzi1', 'gGFpMFHAkj', 'Carmela', 'Iorizzi'),
					   ('hdackombe2', 'XAjco6ee', 'Hendrika', 'Dackombe'),
					   ('febbotts3', 'X2gEFLIe', 'Fionna', 'Ebbotts'),
					   ('mshatliff4', 'VvZPkqExt', 'Myles', 'Shatliff'),
					   ('bpirt5', '9VVsOPEe', 'Blinny', 'Pirt'),
					   ('jparram6', '5QHxNefA', 'Johnny', 'Parram'),
					   ('jtooke7', 'YnomHf7f7', 'Jeffry', 'Tooke'),
					   ('cparbrook8', 'kkEWBdqq', 'Candi', 'Parbrook'),
					   ('pleggen9', 'PzYg8Mww', 'Piggy', 'Leggen')
go


insert Pronosticos values (15, '19/02/2032 17:11', 'Despejado', 7, 33, 12, 'MON', 'URU', 'bpirt5'),
						  (45, '22/06/2023 12:10', 'Parcialmente nuboso', 47, 23, 10, 'MON', 'URU', 'jparram6'),
						  (90, '19/02/2032 17:45', 'Nuboso', 75, 15, 8, 'BAR', 'ESP', 'febbotts3')
go


-------------------------------------------------------------------------------------


-- PROCEDIMIENTOS

-- LOGUEO

create proc Logueo
@Nom varchar(30),
@Pass varchar(30)
as
begin
	select * from Usuarios where UserName = @Nom and Pass = @Pass
end
go


-- ABM PAISES

-- BUSCAR PAIS

create proc BuscarPais
@CodP varchar(3)
as
begin
	select * from Paises where CodigoP = @CodP
end
go

--declare @res int
--exec @res = BuscarPais 'ALE'

create proc AltaPais
@Cod varchar(3),
@Nom varchar(30)
as
begin
	if exists (select * from Paises where CodigoP = @Cod)
		return -1
		
	insert Paises (CodigoP, Nombre) values (@Cod, @Nom)
	if @@ERROR <> 0
		return -2
		
	return 1
end
go

create proc BajaPais
@Cod varchar(3)
as
begin
	if not exists (select * from Paises where CodigoP = @Cod)
		return -1
	if exists (select * from Pronosticos where CodigoP = @Cod)
		return -2
		
	begin tran
		delete Ciudades where CodigoP = @Cod
		if @@ERROR <> 0
			begin
				rollback tran
				return -3
			end
			
		delete Paises where CodigoP = @Cod
		if @@ERROR <> 0
			begin
				rollback tran
				return -3
			end
		
	commit tran
	return 1
end
go

create proc ModificarPais
@Cod varchar(3),
@Nom varchar(30)
as
begin
	if not exists (select * from Paises where CodigoP = @Cod)
		return -1
		
	update Paises set Nombre = @Nom
	where CodigoP = @Cod
	if @@ERROR <> 0
		return -2
		
	return 1
end
go

-- ABM CIUDADES

-- BUSCAR CIUDAD

create proc BuscarCiudad
@CodC varchar(3),
@CodP varchar(3)
as
begin
	select * from Ciudades where CodigoC = @CodC and CodigoP = @CodP
end
go

--declare @res int
--exec @res = BuscarCiudad 'MON'

create proc AltaCiudad
@CodP varchar(3),
@CodC varchar(3),
@Nom varchar(30)
as
begin
	if not exists (select * from Paises where CodigoP = @CodP)
		return -1
	if exists (select * from Ciudades where CodigoC = @CodC)
		return -2
	
	insert Ciudades (CodigoC, Nombre, CodigoP) values (@CodC, @Nom, @CodP)
	if @@ERROR <> 0
		return -3
	
	return 1
end
go

create proc BajaCiudad
@CodC varchar(3)
as
begin
	if not exists (select * from Ciudades where CodigoC = @CodC)
		return -1
		
	begin tran
		delete Pronosticos where CodigoC = @CodC
		if @@ERROR <> 0
			begin
				rollback tran
				return -2
			end
		delete Ciudades where CodigoC = @CodC
		if @@ERROR <> 0
			begin
				rollback tran
				return -2
			end
	commit tran
	return 1
end
go

create proc ModificarCiudad
@CodC varchar(3),
@Nom varchar(30)
as
begin
	if not exists (select * from Ciudades where CodigoC = @CodC)
		return -1
		
	update Ciudades set Nombre = @Nom
	where CodigoC = @CodC
	if @@ERROR <> 0
		return -2
		
	return 1
end
go

-- ABM USUARIOS

-- BUSCAR USUARIO

create proc BuscarUsuario
@UserName varchar(30)
as
begin
	select * from Usuarios where UserName = @UserName
end
go


create proc AltaUsuario
@UserName varchar(30),
@Pass varchar(30),
@Nom varchar(30),
@Ape varchar(30)
as
begin
	if exists (select * from Usuarios where UserName = @UserName)
		return -1
		
	insert Usuarios (UserName, Pass, Nombre, Apellido) 
	values (@UserName, @Pass, @Nom, @Ape)
	if @@ERROR <> 0
		return -2
	
	return 1
end
go

create proc BajaUsuario
@UserName varchar(30)
as
begin
	if not exists (select * from Usuarios where UserName = @UserName)
		return -1
	if exists (select * from Pronosticos where UserName = @UserName)
		return -2
	
	delete Usuarios where UserName = @UserName
	if @@ERROR <> 0
		return -3
	
	return 1
end
go

create proc ModificarUsuario
@UserName varchar(30),
@Pass varchar(30),
@Nom varchar(30),
@Ape varchar(30)
as
begin
	if not exists (select * from Usuarios where UserName = @UserName)
		return -1
		
	update Usuarios set Pass = @Pass, Nombre = @Nom, Apellido = @Ape 
	where UserName = @UserName
	if @@ERROR <> 0
		return -2
	
	return 1
end
go

-- REGISTRAR PRONOSTICO

create proc BuscarUsuProno
@UserName varchar(30)
as
begin
	select * from Pronosticos where UserName = @UserName
end
go

create proc AltaPronostico
@Lluvias int,
@FechaHora datetime,
@TipoCielo varchar(19),
@VelViento int,
@MaxTemp int,
@MinTemp int,
@CodC varchar(3),
@CodP varchar(3),
@UserName varchar(30)
as
begin
	declare @CodPro int
	
	if exists (select * from Pronosticos where FechaHora = @FechaHora and CodigoC = @CodC)
		return -1
		
	insert Pronosticos (ProbLluvias, FechaHora, TipoCielo, VelViento, MaxTemp, MinTemp, CodigoC, CodigoP, UserName)
		values (@Lluvias, @FechaHora, @TipoCielo, @VelViento, @MaxTemp, @MinTemp, @CodC, @CodP, @UserName)
	if @@ERROR <> 0
		return -2
		
	set @CodPro = IDENT_CURRENT('Pronosticos')
	
	return @CodPro
end
go

--declare @res int
--exec @res = AltaPronostico 100, '17/02/2023 17:45', 'Nuboso', 75, 15, 8, 'MAD', 'ESP', 'febbotts3'

--if (@res = -1)
--	print 'Ya existe un pronostico para esa ciudad con la misma fecha y hora'
--else if (@res = -2)
--	print 'Error inesperado'
--else
--	print 'Se agrego correctamente Pronostico con ID: ' + Convert(varchar,@res)

-- LISTADO PAISES

create proc ListadoPaises
as
begin
	select * from Paises
end
go

--exec ListadoPaises

-- LISTADO CIUDADES

create proc ListadoCiudades
as
begin
	select * from Ciudades
end
go


-- LISTADO CIUDADES POR PAIS


create proc ListadoCiudadesXPais
@CodP varchar(3)
as
begin
	select * from Ciudades where CodigoP = @CodP
end
go

--declare @res int
--exec @res = ListadoCiudadesXPais 'URU'

-- LISTADO PRONOSTICOS POR CIUDAD

create proc ListadoPronosticosXCiudad
@CodC varchar(3),
@CodP varchar(3)
as
begin
	select * from Pronosticos where CodigoC = @CodC and CodigoP = @CodP
end
go

--declare @res int
--exec @res = ListadoPronosticosXCiudad 'MON', 'URU'

-- LISTADO POR FECHA

create proc ListadoPronosticoXFecha
@Fecha date
as
begin
	select * from Pronosticos where CONVERT(varchar,FechaHora,3) = @Fecha
end
go

