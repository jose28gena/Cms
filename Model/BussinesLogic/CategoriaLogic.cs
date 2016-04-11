using Common;
using Model.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Core;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model.BussinesLogic
{
  public class CategoriaLogic
    {
        private ResponseModel rm;
        private Repository<Categoria> repo;
        private Categoria categoria = new Categoria();

        private int? idEmpresa;
        public CategoriaLogic()
        {

            rm = new ResponseModel();
            repo = new Repository<Categoria>();
            idEmpresa = new UsuarioLogic().Obtener(SessionHelper.GetUser()).idEmpresa;
        }


        public Categoria Obtener(int? idCategoria)
        {
            try
            {
                using (repo.ContextScope(new CmsContext()))
                {
                    return repo.Get(
                        x => x.idEmpresa == idEmpresa && x.idCategoria == idCategoria

                    );
                }
            }
            catch (Exception e)
            {


                throw;
            }


        }

        public List<Categoria> Listar()
        {
            using (var db = repo.ContextScope(new CmsContext()))
            {
                return repo.GetAll().ToList();
            }
        }

   

        public ResponseModel Guardar(Categoria categoria)
        {
            using (repo.ContextScope(new CmsContext()))
            {
                if (categoria.idCategoria == 0) repo.Insert(categoria);
                else repo.Update(categoria);

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
                    categoria.idCategoria = id;
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

        public List<Categoria> ObtenerPor(int idCategoriaRol)
        {
            using (var db = repo.ContextScope(new CmsContext()))
            {
                var tmp = idCategoriaRol==-1 ? repo.FindBy(x => x.idEmpresa == idEmpresa ).ToList():
                    repo.FindBy(x => x.idEmpresa == idEmpresa && x.idCategoriaRol == idCategoriaRol).ToList();
                return tmp;
            }
        }

    }
}
