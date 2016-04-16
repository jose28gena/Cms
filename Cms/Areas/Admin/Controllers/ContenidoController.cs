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
        public ActionResult Index(int? idcontenido = 0,int? idcategoria=0)
        {
            ViewBag.idcontenido = idcontenido;
            ViewBag.idcategoria = idcategoria;
            ViewBag.Title = CategoriaLogic.Obtener(idcontenido).Titulo;
            return View();
        }

        public JsonResult Listar(AnexGRID grid,int Tipo=1)
        {
            //return Json(contenido.Listar(grid, SessionHelper.GetUser()));
          return Json(contenidologic.Listar(grid, Tipo
              ));
        }


        public JsonResult Eliminar(int id)
        {
            return Json(contenidologic.Eliminar(id));
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
        public ActionResult Agregar(int id=0)
        {

            if (id == 0)
            {
              return Redirect("~/admin/Contenido");

              
            }
            else contenido = contenidologic.Obtener(id);

            return View(contenido);
        }
    }
}