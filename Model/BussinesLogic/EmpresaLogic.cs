using Common;
using Model.Entities;
using Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Model.BussinesLogic
{
  

    public class EmpresaLogic
    {
        private ResponseModel rm;
        private Repository<Empresa> repo;
        private Empresa empresa = new Empresa();
        public EmpresaLogic(){
            rm = new ResponseModel();
            repo = new Repository<Empresa>();
        }


        public ResponseModel Guardar(Empresa model, HttpPostedFileBase Foto)
        {
            using (repo.ContextScope(new CmsContext()))
            {
                // Campos que queremos ignorar

                if (Foto != null)
                {
                    // Nombre del archivo, es decir, lo renombramos para que no se repita nunca
                    string archivo = Path.GetFileName(Foto.FileName);

                    if (model.Imagen != null)
                    {
                        File.Delete(HttpContext.Current.Server.MapPath("~/Uploads/" + model.Imagen));
                    }
                    // La ruta donde lo vamos guardar
                    Foto.SaveAs(HttpContext.Current.Server.MapPath("~/Uploads/" + archivo));

                    // Establecemos en nuestro modelo el nombre del archivo
                    model.Imagen = archivo;


                }

                if (model.idEmpresa == 0)
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


        public Empresa Obtener(int? idEmpresa)
        {
            try
            {
                using (repo.ContextScope(new CmsContext()))
                {
                    return repo.Get( 
                        x => x.idEmpresa == idEmpresa, x=> x.Categoria,x=> x.Contenido

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
