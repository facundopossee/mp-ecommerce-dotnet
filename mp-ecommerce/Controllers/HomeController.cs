﻿using mp_ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mp_ecommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Product> ObjEmp = new List<Product>()
            {
        new Product {Id=1234,Name="Samsung S10",Description="Latur",Price="45000",Url="https://media-esp-buyviu-com.s3.amazonaws.com/products/354fe6a874d854d3b9f1a01e1c9fcab8_image_1.jpg" },
        new Product {Id=1234,Name="iPhone 11 pro",Description="Latur",Price="42000",Url="https://media-esp-buyviu-com.s3.amazonaws.com/products/e166ba0b9f18e08c078df16032ee4d42_image_1.png" },
        new Product {Id=1234,Name="Motorola C115",Description="Latur",Price="100000",Url="https://liberar-tu-movil.es/img/motorola/15_28_Motorola_C115.jpg" }
            };
            return View(ObjEmp);
        }
        public ActionResult Pay(Product item)
        {
            var asd = item;
            return View(asd);
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