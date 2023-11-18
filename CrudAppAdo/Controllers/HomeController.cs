using CrudAppAdo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CrudAppAdo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            EmployeeDBContext db = new EmployeeDBContext();
            List<Employee> employee = db.GetEmployees();
            return View(employee);
        }

        public ActionResult Create() 
        {
            return View();
        }


        [HttpPost]
        public ActionResult Create(Employee emp)
        {
            try
            {
                if (ModelState.IsValid == true)
                {
                    EmployeeDBContext context = new EmployeeDBContext();
                    bool check = context.AddEmployee(emp);

                    if (check == true)
                    {
                        TempData["InsertMessage"] = "Data Has been inserted Succesfully";
                        ModelState.Clear();
                        return RedirectToAction("Index");
                    }
                }
                return View();
            }
            catch (Exception ex)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            EmployeeDBContext ctx = new EmployeeDBContext();
            var row = ctx.GetEmployees().Find(model => model.id == id);

            return View(row);
        }


        [HttpPost]
        public ActionResult Edit(int id, Employee emp)
        {
            if (ModelState.IsValid == true)
            {
                EmployeeDBContext context = new EmployeeDBContext();
                bool check = context.UpdateEmployee(emp);

                if (check == true)
                {
                    TempData["UpdateMessage"] = "Data Has been Updated Succesfully";
                    ModelState.Clear();
                    return RedirectToAction("Index");
                }
            }
            return View();
        }


        public ActionResult Delete(int id)
        {
            EmployeeDBContext ctx = new EmployeeDBContext();
            var row = ctx.GetEmployees().Find(model => model.id == id);

            return View(row);
        }

        public ActionResult Details(int id)
        {
            EmployeeDBContext ctx = new EmployeeDBContext();
            var row = ctx.GetEmployees().Find(model => model.id == id);

            return View(row);
        }


        [HttpPost]
        public ActionResult Delete(int id, Employee emp)
        {
            
                EmployeeDBContext context = new EmployeeDBContext();
                bool check = context.DeleteEmployee(id);

                if (check == true)
                {
                    TempData["DeleteMessage"] = "Data Has been Deleted Succesfully";
                    return RedirectToAction("Index");
                }
            
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}