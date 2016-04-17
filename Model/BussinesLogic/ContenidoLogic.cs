using Common;
using Model.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.IO;
using System.Linq;
using System.Web;

namespace Model.BussinesLogic
{
    public class ContenidoLogic
    {

        private ResponseModel rm;
        private Repository<Contenido> repo;
        private Contenido contenido = new Contenido();
        private CategoriaLogic categorialogic = new CategoriaLogic();
        int? idEmpresa;
        public ContenidoLogic()
        {

            rm = new ResponseModel();
            repo = new Repository<Contenido>();
            idEmpresa =1;
        }

        public List<Contenido> Listar()
        {
            using (var db = repo.ContextScope(new CmsContext()))
            {
                return repo.GetAll(
                 
                    ).ToList();
            }
        }

        public AnexGRIDResponde Listar(AnexGRID grid, int idCategoria)
        {
            try
            {
                using (var ctx = new CmsContext())
                {
                    ctx.Configuration.LazyLoadingEnabled = false;

                    grid.Inicializar();


                    var query = ctx.Contenido.Include("Usuario")
                        .Where(x => x.idEmpresa == idEmpresa && x.idCategoria == idCategoria);


                    // Ordenamiento
                    //if (grid.columna == "id")
                    //{
                    //    query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.id)
                    //                                         : query.OrderBy(x => x.id);
                    //}

                    if (grid.columna == "Titulo")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Titulo)
                                                             : query.OrderBy(x => x.Titulo);
                    }

                    if (grid.columna == "Nombre")
                    {
                        query = grid.columna_orden == "DESC" ? query.OrderByDescending(x => x.Usuario.Nombre)
                                                             : query.OrderBy(x => x.Usuario.Nombre);
                    }


                    // id, Nombre, Titulo, Desde, Hasta
                    // Filtrar
                    foreach (var f in grid.filtros)
                    {
                        if (f.columna == "Titulo")
                            query = query.Where(x => x.Titulo.StartsWith(f.valor));

                        if (f.columna == "Nombre")
                            query = query.Where(x => x.Usuario.Nombre.StartsWith(f.valor) || x.Usuario.Apellido.Contains(f.valor));

                        if (f.columna == "Descripcion")
                            query = query.Where(x => x.Titulo.Contains(f.valor));
                    }


                    var contenido = query.Skip(grid.pagina)
                                            .Take(grid.limite)
                                            .ToList();


                    var total = query.Count();

                    grid.SetData(
                        from e in contenido
                        select new
                        {
                            e.idContenido,
                            e.Titulo,
                            e.Descripcion,
                            Usuario = new
                            {
                                Nombre = e.Usuario.Nombre + ' ' + e.Usuario.Apellido
                            }
                        }

                        , total);
                }
            }
            catch (EntityException ex)
            {
                throw new Exception(ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return grid.responde();
        }

        public ResponseModel Guardar(Contenido model, HttpPostedFileBase Foto)
        {
            using (repo.ContextScope(new CmsContext()))
            {
                // Campos que queremos ignorar
               
                if (Foto != null)
                {
                    // Nombre del archivo, es decir, lo renombramos para que no se repita nunca
                    string archivo =  Path.GetFileName(Foto.FileName);
                  
                    if(model.Imagen!= null)
                    {
                        File.Delete(HttpContext.Current.Server.MapPath("~/Uploads/" + categorialogic.Obtener(model.idCategoria).Titulo + "/" + model.Imagen    ));
                    }
                    // La ruta donde lo vamos guardar
                    Foto.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/"+ categorialogic.Obtener( model.idCategoria).Titulo+"/"+ archivo));

                    // Establecemos en nuestro modelo el nombre del archivo
                   model.Imagen = archivo;

                     
                }

                if (model.idContenido == 0)
                {
                    repo.Insert(model);
                }
                else
                {
                    repo.Update(model);
                }


        
                repo.Save();

                rm.SetResponse(true);
                return rm;
            }
        }

        public ResponseModel Eliminar(int id)
        {
            var rm = new ResponseModel();

            try
            {
                using (var ctx = new CmsContext())
                {
                    contenido.idContenido = id;
                    ctx.Entry(this).State = EntityState.Deleted;

                    ctx.SaveChanges();
                    rm.SetResponse(true);
                }
            }
            catch (Exception)
            {

                throw;
            }

            return rm;
        }

        public Contenido Obtener(int? idContenido)
        {
            try
            {
                using (repo.ContextScope(new CmsContext()))
                {
                    return repo.Get(
                        x => x.idContenido == idContenido

                    );
                }
            }
            catch (Exception e)
            {


                throw;
            }


        }
    }
}
