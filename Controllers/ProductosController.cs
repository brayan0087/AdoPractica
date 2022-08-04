using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AdoPractica.Datos;
using AdoPractica.Models;
namespace AdoPractica.Controllers
{
    public class ProductosController : Controller
    {
        Productos prod = new Productos();

        // GET: Products
        [HttpGet]
        public ActionResult Index()
        {
              IEnumerable<ProductoModel>list=prod.GetAll();
                
              return View(list);
        }


        // GET: NewProductos
        [HttpGet]
        public ActionResult New()
        {
            return View();
        }


        // POST: NewProducts
        [HttpPost]
        public ActionResult New(ProductoModel model)
        {
            
            if (ModelState.IsValid)
            {
               
                prod.NewProduct(model);
                return Redirect("~/Productos/");
            }
                

            return RedirectToAction("Index");
        }



        // GET: EditProducts
        [HttpGet]
        public ActionResult Edit(int Id)
        {
            return View(prod.GetId(Id));
            
        }



        // POST: EditProducts
        [HttpPost]
        public ActionResult Edit(ProductoModel model)
        {

            if (ModelState.IsValid)
            {
                prod.Edit(model);
            }


            return RedirectToAction("Index");
        }

        // GET: DeleteProducts
        [HttpGet]
        public ActionResult Delete(int Id)
        {
            return View(prod.GetId(Id));

        }

        // POST: DeleteProducts
        [HttpPost]
        public ActionResult Delete(ProductoModel model)
        {
             prod.Delete(model);
            return RedirectToAction("Index");
        }

        // GET: DetailsProducts
        [HttpGet]
        public ActionResult Details(int Id)
        {
            return View(prod.GetId(Id));
        }


        // GET: SellProducts
        [HttpGet]
        public ActionResult Sell(int Id)
        {
            return View(prod.Sell(Id));
        }


        // POST: EditProducts
        [HttpPost]
        public ActionResult Sell(SellModel model)
        {

                prod.Sell(model);
           
            return RedirectToAction("Index");
        }



    }
}