using AngularJSCRUD.Models;
using AngularJSCRUD.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AngularJSCRUD.Controllers
{
    public class HomeController : Controller
    {
        private CustomerService objCust;
        public HomeController()
        {
            this.objCust = new CustomerService();
        }

        // GET: Home
        public ActionResult Index()
        {
            return View();
        }

        // GET: All Customer
        [HttpGet]
        public JsonResult GetAllData()
        {
            int Count = 10; IEnumerable<object> customers = null;
            try
            {
                object[] parameters = { Count };
                customers = objCust.GetAll(parameters);
            }
            catch { }
            return Json(customers.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Get Single Customer
        [HttpGet]
        public JsonResult GetbyID(int id)
        {
            object customer = null;
            try
            {
                object[] parameters = { id };
                customer = this.objCust.GetbyID(parameters);
            }
            catch { }
            return Json(customer, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Insert()
        {
            return View();
        }

        // POST: Save New Customer
        [HttpPost]
        public JsonResult Insert(Customer model)
        {
            int result = 0; bool status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    object[] parameters = { model.CustName, model.CustEmail };
                    result = objCust.Insert(parameters);
                    if (result == 1)
                    {
                        status = true;
                    }
                    return Json(new { success = status });
                }
                catch { }
            }
            return Json(new
            {
                success = false,
                errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
            });
        }

        public ActionResult Update()
        {
            return View();
        }

        // POST: Update Existing Customer
        [HttpPost]
        public JsonResult Update(Customer model)
        {
            int result = 0; bool status = false;
            if (ModelState.IsValid)
            {
                try
                {
                    object[] parameters = { model.Id, model.CustName, model.CustEmail };
                    result = objCust.Update(parameters);
                    if (result == 1)
                    {
                        status = true;
                    }
                    return Json(new { success = status });
                }
                catch { }
            }
            return Json(new
            {
                success = false,
                errors = ModelState.Keys.SelectMany(i => ModelState[i].Errors).Select(m => m.ErrorMessage).ToArray()
            });
        }

        // DELETE: Delete Customer
        [HttpDelete]
        public JsonResult Delete(int id)
        {
            int result = 0; bool status = false;
            try
            {
                object[] parameters = { id };
                result = objCust.Delete(parameters);
                if (result == 1)
                {
                    status = true;
                }
            }
            catch { }
            return Json(new
            {
                success = status
            });
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
        }
    }
}