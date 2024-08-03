using System.Data.SqlClient;

namespace Registro.Datos
{
    public class Conexion
    {
        private string cadenaSQL = string.Empty;
        public Conexion()
        {
            var builer = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json").Build();
            cadenaSQL = builer.GetSection("ConnectionStrings:SQLconnection").Value;
        }
        public string getCatedenaSQL()
        {
            return cadenaSQL;
        }
    }
}


//query de sql server

/*
 
create database Users

use Users

create table Datos(
IdUsers int identity(1,1) primary key,
Name varchar(25),
Date Date,
Service varchar(25)
)
 

create procedure sp_listar
as
begin
 select * from Datos where Service = 'Activo'
end


create procedure sp_obtener(
@IdUsers int
)
as
begin
 select * from Datos where IdUsers = @IdUsers
end


create procedure sp_guardar(
@Name varchar(25),
@Date date,
@Service varchar(25)
)
as
begin
 insert into Datos(Name,Date,Service) values (@Name,@Date,@Service)
end
 

create procedure sp_editar(
@IdUsers int,
@Name varchar(25),
@Date date,
@Service varchar(25)
)
as
begin
	update Datos set Name = @Name, Date = @Date, Service = @Service where IdUsers = @IdUsers
end


create procedure sp_eliminar(
@IdUsers int
)
as
begin
	delete from Datos where IdUsers = @IdUsers
end


 */