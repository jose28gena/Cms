using Cms.Areas.Admin.Filters;
using Common;
using Model.BussinesLogic;
using Model.Entities;
using System.Web;
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
        public ActionResult Index(int? idcontenido=0,int? idcategoria=7)
        {
            ViewBag.idcontenido = idcontenido;
            ViewBag.idcategoria = idcategoria;
           ViewBag.Title = CategoriaLogic.Obtener(idcategoria).Titulo;
            return View();
        }

        public JsonResult Listar(AnexGRID grid,int idcategoria)
        {
            //return Json(contenido.Listar(grid, SessionHelper.GetUser()));
          return Json(contenidologic.Listar(grid, idcategoria
              ));
        }


        public JsonResult Eliminar(int idcontenido)
        {
            return Json(contenidologic.Eliminar(idcontenido));
        }

   
        public JsonResult Guardar(Contenido model,HttpPostedFileBase Foto)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {

            rm = contenidologic.Guardar(model,Foto);

                if (rm.response)
                {
                    rm.href = Url.Content("~/admin/contenido/?idcategoria=" + model.idCategoria);
                   
                }
            }

            return Json(rm);
        }


        [Autenticado]
        public ActionResult Agregar(int idcategoria,int idcontenido=0)
        {
            //PREGUNTAR SI idCategoria es igual a cero, si es responder badrequest

            if (idcontenido == 0) {
                contenido = new Contenido();
                contenido.idCategoria = idcategoria;
                contenido.idContenido = idcontenido;
           
                    }
            else {
              
                contenido = contenidologic.Obtener(idcontenido);
            }
            ViewBag.Title = CategoriaLogic.Obtener(idcategoria).Titulo;
            return View(contenido);
        }
    }
}