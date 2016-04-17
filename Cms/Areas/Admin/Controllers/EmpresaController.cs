using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Model.Entities;
using Common;
using Model.BussinesLogic;

namespace Cms.Areas.Admin.Controllers
{
    public class EmpresaController : Controller
    {
        private CmsContext db = new CmsContext();
        private EmpresaLogic empresalogic = new EmpresaLogic();
        // GET: Admin/Empresa
        public ActionResult Index()
        {
            return View(db.Empresa.ToList());
        }

        // GET: Admin/Empresa/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // GET: Admin/Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Empresa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "idEmpresa,Nombre,Imagen,Vision,Mision,NumeroCalle,Calle,Colonia,Pais,Coordenadas,Telefono,Celular,Correo,Facebook,Twitter,CreadoFecha,CreadoPor,ActualizadoPor,ActualizadoFecha")] Empresa empresa)
        {
            if (ModelState.IsValid)
            {
                db.Empresa.Add(empresa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(empresa);
        }

        // GET: Admin/Empresa/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Admin/Empresa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
   
      
        public JsonResult Guardar(Empresa model, HttpPostedFileBase Foto)
        {
            var rm = new ResponseModel();

            if (ModelState.IsValid)
            {

                rm = empresalogic.Guardar(model, Foto);

                if (rm.response)
                {
                    rm.href = Url.Content("~/admin/contenido/");

                }
            }

            return Json(rm);
        }


        // GET: Admin/Empresa/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Empresa empresa = db.Empresa.Find(id);
            if (empresa == null)
            {
                return HttpNotFound();
            }
            return View(empresa);
        }

        // POST: Admin/Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Empresa empresa = db.Empresa.Find(id);
            db.Empresa.Remove(empresa);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
