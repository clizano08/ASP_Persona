use master;
create database DBPersona;
Go
--table
Create Table Persona(
Id varchar(50) not null,
Nombre varchar(50),
Correo varchar(50),
Telefono varchar(50),
Nacimiento datetime
)
Go
--pk
Alter Table Persona add constraint PK_Persona Primary Key (Id)  
Go
--sp
--Insert
Create Procedure spInsertPersona
(@Id varchar(50),
@Nombre varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Nacimiento datetime
)
As
	Insert into Persona(Id,Nombre,Correo,Telefono,Nacimiento) values(@Id,@Nombre,@Correo,@Telefono,@Nacimiento) 
Go

--Update
Create Procedure spUpdatePersona
(@Id varchar(50),
@Nombre varchar(50),
@Correo varchar(50),
@Telefono varchar(50),
@Nacimiento datetime
)
As
	Update Persona 
	Set Nombre =@Nombre,
	Correo =@Correo,
	Telefono =@Telefono,
	Nacimiento = @Nacimiento
	Where (Id = @Id)
Go
-- Delete
Create Procedure spDeletePersona
(@Id varchar(50))
As
	Delete From Persona
	Where (id = @Id)
Go
--GetbyId
Create Procedure spGetPersonaById
(@Id varchar(50))
As
	Select Id,Nombre,Correo,Telefono,Nacimiento From Persona 
	Where(Id = @Id)
Go
--GetAll
Create Procedure spGetAllPersona
As
	Select Id,Nombre,Correo,Telefono,Nacimiento From Persona
Go

