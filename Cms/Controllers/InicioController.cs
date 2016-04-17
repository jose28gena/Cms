using Cms.Areas.Admin.Filters;
using Common;
using Model.BussinesLogic;
using System.Web.Mvc;

namespace Cms.Controllers
{
    public class InicioController : Controller
    {
      private EmpresaLogic empresalogic = new EmpresaLogic();

    
        public ActionResult Index()
        {
            return View(empresalogic.Obtener(1));
        }

        //public JsonResult Acceder(string Email, string Password)
        //{
        //    var rm = usuario.Acceder(Email, Password);

        //    if (rm.response)
        //    {
        //        rm.href = Url.Content("~/admin/contenido/");
        //    }

        //    return Json(rm);
        //}

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/");
        }
    }
}