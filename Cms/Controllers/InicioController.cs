using Cms.Areas.Admin.Filters;
using Common;
using System.Web.Mvc;

namespace Cms.Controllers
{
    public class InicioController : Controller
    {
      //  private UsuarioLogic usuario = new UsuarioLogic();

    
        public ActionResult Index()
        {
            return View();
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