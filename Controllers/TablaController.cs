using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCCrud.Models;
using MVCCrud.Models.ViewModels;

namespace MVCCrud.Controllers
{
    public class TablaController : Controller
    {
        // GET: Tabla
        public ActionResult Index()
        {
            List<TablaViewModel> list = new List<TablaViewModel>();
            using (CrudEntities db = new CrudEntities())
            {
                list = (from d in db.tabla
                            select new TablaViewModel
                            {
                                Id = d.id,
                                Nombre = d.nombre,
                                Correo = d.correo,
                                Fecha_nacimiento = (DateTime)d.fecha_nacimiento
                            }).ToList();
            }
                return View(list);
        }

        public ActionResult Nuevo()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Nuevo(NuevoTablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oTabla = new tabla();
                        oTabla.correo = model.Correo;
                        oTabla.nombre = model.Nombre;
                        oTabla.fecha_nacimiento = model.Fecha_nacimiento;
                        db.tabla.Add(oTabla);
                        db.SaveChanges();

                    }

                    return Redirect("/tabla");
                }

                return View(model);

                
            }
            catch (Exception ex)
            {
                 
                throw new Exception(ex.Message);
            }
        }

        
        public ActionResult Editar(int id)
        {
            NuevoTablaViewModel model = new NuevoTablaViewModel();
            using (CrudEntities db = new CrudEntities())
            {
                var oTabla = db.tabla.Find(id);
                model.Nombre = oTabla.nombre;
                model.Correo = oTabla.correo;
                model.Fecha_nacimiento = (DateTime)oTabla.fecha_nacimiento;
                model.Id = oTabla.id;
            }

                return View(model);
        }

        [HttpPost]
        public ActionResult Editar(NuevoTablaViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    using (CrudEntities db = new CrudEntities())
                    {
                        var oTabla = db.tabla.Find(model.Id);
                        oTabla.correo = model.Correo;
                        oTabla.nombre = model.Nombre;
                        oTabla.fecha_nacimiento = model.Fecha_nacimiento;
                        db.Entry(oTabla).State = System.Data.Entity.EntityState.Modified;
                        db.SaveChanges();

                    }

                    return Redirect("/tabla");
                }

                return View(model);


            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult Eliminar(int id)
        {

            using (CrudEntities db = new CrudEntities())
            {
                var oTabla = db.tabla.Find(id);
                db.tabla.Remove(oTabla);
                db.SaveChanges();
            }

            return Redirect("/tabla");
        }


    }
}