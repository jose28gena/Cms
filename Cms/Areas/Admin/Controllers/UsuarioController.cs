using Cms.Areas.Admin.Filters;
using System.Web.Mvc;

namespace Cms.Areas.Admin.Controllers
{
    public class UsuarioController : Controller
    {
        // GET: Admin/Usuario

        [Autenticado]
        public ActionResult Index()
        {
            return View();
        }




    }
}