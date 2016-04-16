using Model.BussinesLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Cms
{
    public class MvcApplication : System.Web.HttpApplication
    {
        private CategoriaLogic categorialogic = new CategoriaLogic();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            CrearUpload();
        }



        protected void CrearUpload()
        {
            foreach (var item in categorialogic.Listar() )
            {
                string ruta= HttpContext.Current.Server.MapPath("~/uploads/" + item.Titulo);

                if (!Directory.Exists(ruta))
                {
                    Directory.CreateDirectory(ruta);
                }
                }
        }
    }

}
