using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace CapaDatos
{
    public  class DMarca
    {
        private int _idMarca;
        private string _nombre;
        private string _descripcion;

        public string Descripcion
        {
            get { return _descripcion; }
            set { _descripcion = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public int IDMarca
        {
            get { return _idMarca; }
            set { _idMarca = value; }
        }


        public DMarca() { }

        public DMarca(int idmarca,string nombre,string descripcion)
        {
            this.IDMarca = idmarca;
            this.Nombre = nombre;
            this.Descripcion = descripcion;
        }

        public string InsertarMarca(DMarca Marca)
        {
            string retorno = "";
            Conexion con = new Conexion();
            
            try
            {
              
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.AbriConexion();
                cmd.CommandText = "spIngresarMarca";
                cmd.CommandType = CommandType.StoredProcedure;


                SqlParameter parIdMarca = new SqlParameter();
                parIdMarca.ParameterName = "@idmarca";
                parIdMarca.SqlDbType = SqlDbType.Int;
                parIdMarca.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(parIdMarca);

                SqlParameter parNombre = new SqlParameter();
                parNombre.ParameterName = "@nombre";
                parNombre.SqlDbType = SqlDbType.VarChar;
                parNombre.Size = 50;
                parNombre.Value = Marca.Nombre;
                cmd.Parameters.Add(parNombre);

                SqlParameter parDescripcion = new SqlParameter();
                parDescripcion.ParameterName = "@descripcion";
                parDescripcion.SqlDbType = SqlDbType.VarChar;
                parDescripcion.Size = 50;
                parDescripcion.Value = Marca.Descripcion;
                cmd.Parameters.Add(parDescripcion);

                retorno = cmd.ExecuteNonQuery() == 1 ? "Ok" : "No es posible ingresar los datos";
            }
            catch (Exception ex)
            {

                retorno = ex.Message;
            }
            finally { con.CerrarConexion(); }
           


            return retorno;
        }
        public string EditarMarca(DMarca Marca)
        {
            string retorno = "";

            Conexion con = new Conexion();
            try
            {
               
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con.AbriConexion();
                cmd.CommandText = "spModificarMarca";

            }
            catch (Exception ex)
            {

                retorno = ex.Message;
            }
            finally
            {
                con.CerrarConexion();
            }

            return retorno;
        }


    }
}
