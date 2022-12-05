using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using dominio;

namespace negocio
{
    public class ArticuloNegocio
    {
        public List<Articulo> listarArticulos()
        {
            List<Articulo> lista = new List<Articulo>();
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("select Nombre, A.Id, Codigo, A.Descripcion, M.Descripcion Marca, M.Id IdMarca, C.Descripcion Categoria, C.Id IdCategoria, ImagenUrl, Precio from ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdMarca = M.Id And A.IdCategoria = C.Id");
                datos.ejecutarLector();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Marca.Id = (int)datos.Lector["IdMarca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.Categoria.Id = (int)datos.Lector["IdCategoria"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }
                return lista;
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
        public List<Articulo> filtrar(string filtro, string campo, string criterio, string marca, string categoria)
        {
            AccesoDatos datos = new AccesoDatos();
            List<Articulo> lista = new List<Articulo>();
            string consulta = "select Nombre, A.Id, Codigo, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdMarca = M.Id And A.IdCategoria = C.Id and ";
            try
            {
                switch (campo)
                {
                    case "Nombre":
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "Nombre like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "Nombre like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Nombre like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    case "Precio":
                        switch (criterio)
                        {
                            case "De menor a mayor":
                                consulta = "select Nombre, A.Id, Codigo, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdMarca = M.Id And A.IdCategoria = C.Id order by Precio asc";
                                break;
                            case "De mayor a menor":
                                consulta = "select Nombre, A.Id, Codigo, A.Descripcion, M.Descripcion Marca, C.Descripcion Categoria, ImagenUrl, Precio from ARTICULOS A, CATEGORIAS C, MARCAS M Where A.IdMarca = M.Id And A.IdCategoria = C.Id order by Precio desc";
                                break;
                            case "Exactamente":
                                consulta += "Precio = " + filtro;
                                break;
                            case "Por encima de":
                                consulta += "Precio > " + filtro;
                                break;
                            case "Por debajo de":
                                consulta += "Precio < " + filtro;
                                break;
                            default:
                                consulta += "Precio > 0";
                                break;
                        }
                        break;
                    case "Código":
                        switch (criterio)
                        {
                            case "Código exacto":
                                consulta += "Codigo = " + filtro;
                                break;
                            case "Comienza con":
                                consulta += "Codigo like '" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "Codigo like '%" + filtro + "'";
                                break;
                            default:
                                consulta += "Codigo like '%" + filtro + "%'";
                                break;
                        }
                        break;
                    default:
                        switch (criterio)
                        {
                            case "Comienza con":
                                consulta += "A.Descripcion like'" + filtro + "%'";
                                break;
                            case "Termina con":
                                consulta += "A.Descripcion like'%" + filtro + "'";
                                break;
                            default:
                                consulta += "A.Descripcion like '%" + filtro + "%'";
                                break;
                        }
                        break;
                }
                consulta += filtrosExtras(marca, categoria);
                datos.setConsulta(consulta);
                datos.ejecutarLector();
                while (datos.Lector.Read())
                {
                    Articulo aux = new Articulo();
                    aux.Nombre = (string)datos.Lector["Nombre"];
                    aux.Id = (int)datos.Lector["Id"];
                    aux.Codigo = (string)datos.Lector["Codigo"];
                    aux.Descripcion = (string)datos.Lector["Descripcion"];
                    aux.Marca = new Marca();
                    aux.Marca.Descripcion = (string)datos.Lector["Marca"];
                    aux.Categoria = new Categoria();
                    aux.Categoria.Descripcion = (string)datos.Lector["Categoria"];
                    aux.UrlImagen = (string)datos.Lector["ImagenUrl"];
                    aux.Precio = (decimal)datos.Lector["Precio"];
                    lista.Add(aux);
                }
                return lista;
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
        public string filtrosExtras(string marca, string categoria)
        {
            string consulta;
            try
            {
                if (marca == "Todas las marcas" && categoria != "Todas las categorías")
                    consulta = "And C.Descripcion = '" + categoria + "'";
                else if (marca != "Todas las marcas" && categoria == "Todas las categorías")
                    consulta = "And M.Descripcion = '" + marca + "'";
                else if (marca != "Todas las marcas" && categoria != "Todas las categorías")
                    consulta = "And M.Descripcion = '" + marca + "' And C.Descripcion = '" + categoria + "'";
                else
                    consulta = null;
                return consulta;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public void altaArticulo(Articulo articuloNuevo)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("insert into ARTICULOS values (@codigo, @nombre, @descripcion, @idMarca, @idCategoria, @urlImagen, @precio)");
                datos.setParametro("@codigo", articuloNuevo.Codigo);
                datos.setParametro("@nombre", articuloNuevo.Nombre );
                datos.setParametro("@descripcion", articuloNuevo.Descripcion );
                datos.setParametro("@idMarca", articuloNuevo.Marca.Id);
                datos.setParametro("@idCategoria", articuloNuevo.Categoria.Id);
                datos.setParametro("@urlImagen", articuloNuevo.UrlImagen);
                datos.setParametro("@precio", articuloNuevo.Precio);
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
        public void modificarArticulo(Articulo modificado)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("update ARTICULOS set Codigo = @codigo, Nombre = @nombre, Descripcion = @descripcion, IdMarca = @idMarca, IdCategoria = @idCategoria, ImagenUrl = @imagenUrl, Precio = @precio where Id = @id");
                datos.setParametro("@codigo", modificado.Codigo);
                datos.setParametro("@nombre", modificado.Nombre);
                datos.setParametro("@descripcion", modificado.Descripcion);
                datos.setParametro("@idMarca", modificado.Marca.Id);
                datos.setParametro("@idCategoria", modificado.Categoria.Id);
                datos.setParametro("@imagenUrl", modificado.UrlImagen);
                datos.setParametro("@precio", modificado.Precio);
                datos.setParametro("@id", modificado.Id);
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
        public void eliminarArticulo(Articulo aEliminar)
        {
            AccesoDatos datos = new AccesoDatos();
            try
            {
                datos.setConsulta("delete from ARTICULOS where Id = @id");
                datos.setParametro("@id", aEliminar.Id);
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
