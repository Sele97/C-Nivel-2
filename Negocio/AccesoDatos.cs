using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

namespace Negocio
{        //No declarar los objetos de conexion a base de datos (los de PokemonNegocio) en todos lados. Se crea esta clase para facilitar la cuestion, que centralize.

    public class AccesoDatos  // Necesito conexion, comando, lector. (arriba) para acceder a la base de datos.

    {
        private SqlConnection conexion; //atributos q necesito para q se genere una lectura a la base de datos.
        private SqlCommand comando;
        private SqlDataReader lector;
        public SqlDataReader Lector //necesito leerlo del exterior, pongo en public.
        {
            get { return lector; }
        }
        
        public AccesoDatos() 
        {
            conexion = new SqlConnection("server=.\\SQLEXPRESS; database=CalapapaDB; integrated security= true");
            comando = new SqlCommand(); //voy hacer una accion en la base de datos.
        }

        public void setearConsulta(string consulta) // encapsulo darle un tipo y la query.
        {
            comando.CommandType = System.Data.CommandType.Text; 
            comando.CommandText = consulta; 
        }

        public void ejecutarLectura() //realiza la lectura y lo guarda en el lector.
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                lector = comando.ExecuteReader(); //guarda en el lector.

            }

            catch (Exception ex)
            {
                throw ex;
            }

        }

        public void ejecutarAccion() //ejecuta la sentencia.
        {
            comando.Connection = conexion;
            try
            {
                conexion.Open();
                comando.ExecuteNonQuery();

            }
            catch (Exception ex)
            {

                throw ex;
            }

        
        }

        public void cerrarConexion()
        {
            if (lector != null) // cierro la conexion si hay un lector utilizandose.
                lector.Close();
            conexion.Close();
        }
    }
}
