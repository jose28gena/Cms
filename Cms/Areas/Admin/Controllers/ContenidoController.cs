using Cms.Areas.Admin.Filters;
using Common;
using Model.BussinesLogic;
using Model.Entities;
using System.Web.Mvc;

namespace Cms.Areas.Admin.Controllers
{
    public class ContenidoController : Controller
    {
        // GET: Admin/Contenido
        private ContenidoLogic contenidologic = new ContenidoLogic();
        private CategoriaLogic CategoriaLogic = new CategoriaLogic();
        private UsuarioLogic UsuarioLogic = new UsuarioLogic();
        private Contenido contenido = new Contenido();
       
        [Autenticado]
        public ActionResult Index(int? idcontenido = 1,int? idcategoria=0)
        {
            ViewBag.idcontenido = idcontenido;
            ViewBag.idcategoria = idcategoria;
            ViewBag.Title = CategoriaLogic.Obtener(idcontenido).Titulo;
            return View();
        }

        public JsonResult Listar(AnexGRID grid,int idcategoria=1)
        {
            //return Json(contenido.Listar(grid, SessionHelper.GetUser()));
          return Json(contenidologic.Listar(grid, idcategoria
              ));
        }


        public JsonResult Eliminar(int idcontenido)
        {
            return Json(contenidologic.Eliminar(idcontenido));
        }

   
        public JsonResult Guardar(Contenido model)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {
            rm = contenidologic.Guardar(model);

                if (rm.response)
                {
                    rm.href = Url.Content("~/admin/categoria/?Tipo=" + model.idCategoria);
                   
                }
            }

            return Json(rm);
        }


        [Autenticado]
        public ActionResult Agregar(int? idcontenido=0)
        {
            //PREGUNTAR SI idCategoria es igual a cero, si es responder badrequest

          
             contenido =idcontenido==0? new Contenido(): contenidologic.Obtener(idcontenido);

            return View(contenido);
        }
    }
}