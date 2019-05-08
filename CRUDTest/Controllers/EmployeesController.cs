using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDTest.Models;

namespace CRUDTest.Controllers
{
    public class EmployeesController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();


        /// READ
        public ActionResult Index()
        {
            var x = db.Employees.ToList();

            //return Json(new { Data = x }, JsonRequestBehavior.AllowGet);
            return View(x);
        }

        /// CREATE
        public ActionResult Create()
        {
            return View();
        }
        public JsonResult Save(string FName, string LName, string Phone, string Address)
        {
            bool status = false;
            try
            {
                //define the model  
                if (FName == "")
                {
                    status = false;
                }
                else
                {
                    Employee data = new Employee();
                    data.FirstName = FName;
                    data.LastName = LName;
                    data.Phone = Phone;
                    data.Address = Address;

                    db.Employees.Add(data);
                    status = true;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }


        /// UPDATE
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
            //Employee employee = db.Employees.Where(x => x.Id == id).SingleOrDefault();
            //return Json(new { Data = employee }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(int Id, string FName, string LName, string Phone, string Address)
        {
            bool status = false;
            try
            {
                if (FName == "")
                {
                    status = false;
                }
                else
                {
                    //define the model  
                    var data = db.Employees.Where(x => x.Id.Equals(Id)).SingleOrDefault();
                    data.FirstName = FName;
                    data.LastName = LName;
                    data.Phone = Phone;
                    data.Address = Address;

                    db.Entry(data).State = EntityState.Modified;
                    status = true;
                    db.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }

        /// DELETE
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Employee employee = db.Employees.Find(id);
            if (employee == null)
            {
                return HttpNotFound();
            }
            return View(employee);
        }
        public JsonResult Del(int Id)
        {
            bool status = false;
            try
            {
                //define the model  
                Employee data = db.Employees.Find(Id);

                db.Employees.Remove(data);
                status = true;
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                System.Console.Write(ex.InnerException);
                status = false;
            }
            return new JsonResult { Data = new { status = status } };
        }
    }
}
