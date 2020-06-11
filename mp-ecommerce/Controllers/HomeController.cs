using MercadoPago.Resources;
using MercadoPago.DataStructures.Preference;
using mp_ecommerce.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using System.IO;

namespace mp_ecommerce.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            List<Product> ObjEmp = new List<Product>()
            {
                new Product {Id=1234,Name="Samsung S10",Price=45000,Url="https://media-esp-buyviu-com.s3.amazonaws.com/products/354fe6a874d854d3b9f1a01e1c9fcab8_image_1.jpg" },
                new Product {Id=1234,Name="iPhone 11 pro",Price=42000,Url="https://media-esp-buyviu-com.s3.amazonaws.com/products/e166ba0b9f18e08c078df16032ee4d42_image_1.png" },
                new Product {Id=1234,Name="Motorola C115",Price=100000,Url="https://liberar-tu-movil.es/img/motorola/15_28_Motorola_C115.jpg" }
            };
            return View(ObjEmp);
        }
        public void Pay(Product item)
        {

            // Create a preference object
            Preference preference = new Preference();
            preference.CollectorId = 469485398;
            // Adding an item object
            preference.Items.Add(
              new Item()
              {
                  Id = item.Id.ToString(),
                  Title = item.Name,
                  Description = "Dispositivo móvil de Tienda e-commerce",
                  PictureUrl = item.Url,
                  Quantity = 1,
                  CurrencyId = MercadoPago.Common.CurrencyId.ARS,
                  UnitPrice = Convert.ToDecimal(item.Price)
              }
            );

            // Setting a payer object as value for Payer property
            preference.Payer = new Payer()
            {
                Name = "Lalo",
                Surname = "Landa",
                Email = "test_user_63274575@testuser.com",
                Phone = new Phone()
                {
                    AreaCode = "11",
                    Number = "22223333",
                },
                Address = new Address()
                {
                    ZipCode = "1111",
                    StreetNumber = 123,
                    StreetName = "False"
                }
            };

            preference.BackUrls = new BackUrls()
            {
                Success = Request.Url.GetLeftPart(UriPartial.Authority) + "/Home/SuccessPay",
                Failure = Request.Url.GetLeftPart(UriPartial.Authority) + "/Home/ErrorPay",
                Pending = Request.Url.GetLeftPart(UriPartial.Authority) + "/Home/PendingPay"
            };


            preference.PaymentMethods = new PaymentMethods()
            {
                ExcludedPaymentMethods = new List<MercadoPago.DataStructures.Preference.PaymentMethod>() {
                    new MercadoPago.DataStructures.Preference.PaymentMethod() {
                        Id = "amex"
                    }
                },

                ExcludedPaymentTypes = new List<PaymentType>() {
                    new PaymentType() {
                        Id = "atm"
                    }
                },
                Installments = 6,
            };

            preference.ExternalReference = "facundopossee@gmail.com";
            preference.AutoReturn = MercadoPago.Common.AutoReturnType.approved;
            preference.NotificationUrl = Request.Url.GetLeftPart(UriPartial.Authority) + "/Home/Notifications";
            // Save and posting preference
            preference.Save();
            Response.Redirect(preference.InitPoint);
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
        public ActionResult ErrorPay()
        {
            return View();
        }
        public ActionResult PendingPay()
        {
            return View();
        }
        public ActionResult SuccessPay()
        {
            //Recibe Querystring
            CallBack callBack = new CallBack()
            {
                collection_id = Request.Params["collection_id"],
                external_reference = Request.Params["external_reference"],
                collection_status = Request.Params["collection_status"],
                site_id = Request.Params["site_id"],
                merchant_account_id = Request.Params["merchant_account_id"],
                payment_id = Request.Params["payment_id"],
                preference_id = Request.Params["preference_id"],
                processing_mode = Request.Params["processing_mode"]
            };
            return View(callBack);
        }
        [HttpPost]
        public HttpStatusCodeResult Notifications()
        {
            string json = JsonConvert.SerializeObject(Request.QueryString);

            //write string to file
            System.IO.File.WriteAllText(Path.Combine(Server.MapPath("~/Content"), "json"), json);

            return new HttpStatusCodeResult(200);
        }
    }
}