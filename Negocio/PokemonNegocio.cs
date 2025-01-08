using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Microsoft.Win32;
using Dominio;


namespace Negocio
{
     public class PokemonNegocio
    {
        //registro para insertar datos a la base de datos.
        public void agregar(Pokemon nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setearConsulta("Insert into POKEMONS (Numero, Nombre, Descripcion, Activo)values(" + nuevo.Numero + ", '" + nuevo.Nombre + "', '" + nuevo.Descripcion + "', 1)");
                datos.ejecutarLectura();
            }
            catch (Exception ex)
            {

                throw ex;
            }
            finally
            { 
                datos.cerrarConexion();
            }
        
        
        }

        public void modificar(Pokemon modificar)
        { }

        public List<Pokemon> listar()
        {

            List<Pokemon> lista = new List<Pokemon>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;
          

            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=CalapapaDB; integrated security= true";

                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "Select Numero, Nombre, P.Descripcion, UrlImagen, E.Descripcion Tipo, D.Descripcion Debilidad From POKEMONS P, ELEMENTOS E, ELEMENTOS D where E.Id = P.IdTipo and D.Id = P.IdDebilidad";
                comando.Connection = conexion;
               
                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                { 
                  Pokemon aux = new Pokemon();
                   aux.Numero = lector.GetInt32(0);
                   aux.Nombre = (string)lector["Nombre"];
                   aux.Descripcion = (string)lector["Descripcion"];
                   aux.UrlImagen = (string)lector["UrlImagen"];
                   aux.Tipo = new Elemento(); //porque tipo no tiene instancia.
                   aux.Tipo.Descripcion = (string)lector["Tipo"]; // de tipo me estoy trayendo la Descripcion. Tipo es un objeto.
                   aux.Debilidad = new Elemento();
                   aux.Debilidad.Descripcion = (string)lector["Debilidad"];

                    lista.Add(aux);
                }
                conexion.Close();
                return lista;
            }
            catch (Exception ex)
            {
                 throw ex;
            }

          }
        
        
                

    }
}
