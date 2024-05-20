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
                comando.CommandText = "select   Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa,  T.Descripcion TipoEdicion, E.Descripcion GeneroMusical, D.IdEstilo, D.IdTipoEdicion, D.Id from TIPOSEDICION T, ESTILOS E, DISCOS D where E.Id = D.IdEstilo and T.Id = D.IdTipoEdicion";
                comando.Connection = conexion;

                conexion.Open();
                lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)lector["Id"];
                    aux.titulo = (string)lector["Titulo"];
                    aux.fechaLanzamiento = (DateTime)lector["FechaLanzamiento"];
                    aux.cantidadCanciones = (int)lector["CantidadCanciones"];

                    //if(!(lector.IsDBNull(lector.GetOrdinal("Descripcion"))))  
                    //aux.urlImagenTapa = (string)lector["UrlImagenTapa"]; //esto es una forma de hacerlo

                    if (!(lector["UrlImagenTapa"]is DBNull))
                        aux.urlImagenTapa = (string)lector["UrlImagenTapa"]; // y esta es otra

                    aux.TipoEdicion = new TipoEdicion();
                    aux.TipoEdicion.Id = (int)lector["IdTipoEdicion"];
                    aux.TipoEdicion.Descripcion = (string)lector["TipoEdicion"];
                    aux.GeneroMusical = new Estilo();
                    aux.GeneroMusical.Id = (int)lector["IdEstilo"];
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
                datos.setarConsulta("insert into DISCOS (Titulo, CantidadCanciones, FechaLanzamiento, IdEstilo, IdTIpoEdicion, UrlImagenTapa) values('" + nuevo.titulo +"',"+ nuevo.cantidadCanciones +", @FechaLanzamiento, @IdEstilo, @IdTipoEdicion,@UrlImagenTapa)");
                datos.setearParametro("@UrlImagenTapa", nuevo.urlImagenTapa);
                datos.setearParametro("@FechaLanzamiento", nuevo.fechaLanzamiento);
                datos.setearParametro("@IdEstilo", nuevo.GeneroMusical.Id);
                datos.setearParametro("@IdTipoEdicion", nuevo.TipoEdicion.Id);
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

        public void modificar(Disco disco) 
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setarConsulta("update DISCOS set Titulo = @Titulo, FechaLanzamiento = @FechaLanzamiento, CantidadCanciones = @CantidadCanciones, UrlImagenTapa = @UrlImagenTapa, IdEstilo = @IdEstilo, IdTipoEdicion = @IdTipoEdicion where id = @id");
                datos.setearParametro("@Titulo", disco.titulo);
                datos.setearParametro("@FechaLanzamiento", disco.fechaLanzamiento);
                datos.setearParametro("@CantidadCanciones", disco.cantidadCanciones);
                datos.setearParametro("@UrlImagenTapa", disco.urlImagenTapa);
                datos.setearParametro("@IdEstilo", disco.GeneroMusical.Id);
                datos.setearParametro("@IdTipoEdicion", disco.TipoEdicion.Id);
                datos.setearParametro("@id", disco.Id);

                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex ;
            } 
            finally
            {
                datos.cerrarConexion();
            }
        }

        public void eliminar(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
                datos.setarConsulta("delete from DISCOS where id = @id");
                datos.setearParametro("@id",id);
                datos.ejecutarAccion();

            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public void eliminarLogico(int id)
        {
            try
            {
                AccesoDatos datos = new AccesoDatos();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public List<Disco> filtrar( string campo,  string criterio,  string filtro)
        {
            List<Disco> lista = new List<Disco>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                string consulta = "select Titulo, FechaLanzamiento, CantidadCanciones, UrlImagenTapa,  T.Descripcion TipoEdicion, E.Descripcion GeneroMusical, D.IdEstilo, D.IdTipoEdicion, D.Id from TIPOSEDICION T, ESTILOS E, DISCOS D where E.Id = D.IdEstilo and T.Id = D.IdTipoEdicion and ";

                if ( campo == "CantidadCanciones")
                {
                    switch(criterio)
                    {
                        case "Mayor a":
                            consulta += "CantidadCanciones > " + filtro;
                            break;
                        case "Menor a":
                            consulta += "CantidadCanciones < " + filtro;
                        break;
                        default:
                            consulta += "CantidadCanciones = " + filtro;
                            break;

                    }
                }    
                else if ( campo == "Titulo")
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "Titulo like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "Titulo like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "Titulo like '%" + filtro + "%' ";
                            break;
                    }
                }
                else
                {
                    switch (criterio)
                    {
                        case "Comienza con":
                            consulta += "E.Descripcion like '" + filtro + "%' ";
                            break;
                        case "Termina con":
                            consulta += "E.Descripcion like '%" + filtro + "' ";
                            break;
                        default:
                            consulta += "E.Descripcion like '%" + filtro + "%' ";
                            break;
                    }
                }

                datos.setarConsulta( consulta );
                datos.ejecutarLectura();

                while ( datos.Lector.Read())
                {
                    Disco aux = new Disco();
                    aux.Id = (int)datos.Lector["Id"];
                    aux.titulo = (string)datos.Lector["Titulo"];
                    aux.fechaLanzamiento = (DateTime)datos.Lector["FechaLanzamiento"];
                    aux.cantidadCanciones = (int)datos.Lector["CantidadCanciones"];

                    if (!(datos.Lector["UrlImagenTapa"] is DBNull))
                        aux.urlImagenTapa = (string)datos.Lector["UrlImagenTapa"];

                    aux.TipoEdicion = new TipoEdicion();
                    aux.TipoEdicion.Id = (int)datos.Lector["IdTipoEdicion"];
                    aux.TipoEdicion.Descripcion = (string)datos.Lector["TipoEdicion"];
                    aux.GeneroMusical = new Estilo();
                    aux.GeneroMusical.Id = (int)datos.Lector["IdEstilo"];
                    aux.GeneroMusical.Descripcion = (string)datos.Lector["GeneroMusical"];


                    lista.Add(aux);
                }

                return lista;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        
        
    }
}
