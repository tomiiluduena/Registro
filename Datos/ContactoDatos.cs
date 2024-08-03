using Registro.Models;
using System.Data.SqlClient;
using System.Data;

namespace Registro.Datos
{
    public class ContactoDatos
    {
        public List<UsersModel> Listar()
        {
            var olista = new List<UsersModel>();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCatedenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_listar", conexion);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        olista.Add(new UsersModel()
                        {
                            IdUsers = Convert.ToInt32(dr["IdUsers"]),
                            Name = dr["Name"].ToString(),
                            Date = Convert.ToDateTime(dr["Date"]),
                            Service = dr["Service"].ToString(),
                        });
                    }
                }
            }
            return olista;

        }

        public UsersModel Obtener(int IdUsers)
        {
            var ocontacto = new UsersModel();
            var cn = new Conexion();
            using (var conexion = new SqlConnection(cn.getCatedenaSQL()))
            {
                conexion.Open();
                SqlCommand cmd = new SqlCommand("sp_obtener", conexion);
                cmd.Parameters.AddWithValue("IdUsers", IdUsers);
                cmd.CommandType = CommandType.StoredProcedure;

                using (var dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        ocontacto.IdUsers = Convert.ToInt32(dr["IdUsers"]);
                        ocontacto.Name = dr["Name"].ToString();
                        ocontacto.Date = Convert.ToDateTime(dr["Date"]);
                        ocontacto.Service = dr["Service"].ToString();
                    }
                }
            }
            return ocontacto;
        }

        public bool Guardar(UsersModel ousuario)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCatedenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cdm = new SqlCommand("sp_guardar", conexion);
                    cdm.Parameters.AddWithValue("Name", ousuario.Name);
                    cdm.Parameters.AddWithValue("Date", ousuario.Date);
                    cdm.Parameters.AddWithValue("Service", ousuario.Service);
                    cdm.CommandType = CommandType.StoredProcedure;
                    cdm.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }


        public bool Editar(UsersModel ousuario)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCatedenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cdm = new SqlCommand("sp_editar", conexion);
                    cdm.Parameters.AddWithValue("IdUsers", ousuario.IdUsers);
                    cdm.Parameters.AddWithValue("Name", ousuario.Name);
                    cdm.Parameters.AddWithValue("Date", ousuario.Date);
                    cdm.Parameters.AddWithValue("Service", ousuario.Service);
                    cdm.CommandType = CommandType.StoredProcedure;
                    cdm.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
        public bool Eliminar(int IdUsers)
        {
            bool rpta;
            try
            {
                var cn = new Conexion();
                using (var conexion = new SqlConnection(cn.getCatedenaSQL()))
                {
                    conexion.Open();
                    SqlCommand cdm = new SqlCommand("sp_eliminar", conexion);
                    cdm.Parameters.AddWithValue("IdUsers", IdUsers);
                    cdm.CommandType = CommandType.StoredProcedure;
                    cdm.ExecuteNonQuery();
                }
                rpta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
                rpta = false;
            }
            return rpta;
        }
    }
}
