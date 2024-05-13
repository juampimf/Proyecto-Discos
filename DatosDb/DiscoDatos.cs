using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using dominio;
using System.Security.Cryptography.X509Certificates;

namespace DatosDb
{
    public class DiscoDatos
    {
        public List<Disco> listar()
        {
            List<Disco> lista = new List<Disco>();
            SqlConnection conexion = new SqlConnection();
            SqlCommand comando = new SqlCommand();
            SqlDataReader lector;


            try
            {
                conexion.ConnectionString = "server=.\\SQLEXPRESS; database=DISCOS_DB; integrated security=true";
                comando.CommandType = System.Data.CommandType.Text;
                comando.CommandText = "select   Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa,  T.Descripcion TipoEdicion, E.Descripcion GeneroMusical\r\nfrom TIPOSEDICION T, ESTILOS E, DISCOS D \r\nwhere E.Id = D.IdEstilo \r\nand T.Id = D.IdTipoEdicion";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.titulo = (string)lector["Titulo"];
                    aux.fechaLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.cantidadCanciones = (int)lector["CantidadCanciones"];
                    aux.urlImagenTapa = (string)lector["UrlImagenTapa"];
                    aux.TipoEdicion = new TipoEdicion();
                    aux.TipoEdicion.Descripcion = (string)lector["TipoEdicion"];
                    aux.GeneroMusical = new Estilo();
                    aux.GeneroMusical.Descripcion = (string)lector["GeneroMusical"]; 

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
        public void agregar(Disco nuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setarConsulta("insert into DISCOS (Titulo, CantidadCanciones, FechaLanzamiento) values('" + nuevo.titulo +"',"+ nuevo.cantidadCanciones +",@FechaLanzamiento)");
                datos.setearParametro("@FechaLanzamiento", nuevo.fechaLanzamiento);
                datos.ejecutarAccion();
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
    }
}
