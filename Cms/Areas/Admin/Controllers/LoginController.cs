using Common;
using Model.BussinesLogic;
using System.Web.Mvc;


namespace Cms.Areas.Admin.Controllers
{
    public class LoginController : Controller
    {
        private  UsuarioLogic usuariologic = new UsuarioLogic();

        public ActionResult Index()
        {
            return View();
        }

        public JsonResult Acceder(string Email, string Password)
        {
            var rm = usuariologic.Acceder(Email, Password);

            if (rm.response)
            {
                rm.href = Url.Content("~/admin/contenido/index?Tipo=6");
            }

            return Json(rm);
        }

        public ActionResult Logout()
        {
            SessionHelper.DestroyUserSession();
            return Redirect("~/");
        }

    
    }
}