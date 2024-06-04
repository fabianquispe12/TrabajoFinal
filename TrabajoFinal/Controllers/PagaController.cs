using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using System.Windows.Forms;
using WebApplication1.Models.Paypal;
using WebApplication1.Models.Transaccion;

namespace WebApplication1.Controllers
{
    public class PagaController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public async Task<ActionResult> Resultado()
        {
            string token = Request.QueryString["token"];

            bool status = false;


            using (var client = new HttpClient())
            {
                var username = "AYOJ80Gq-WjwfvB5ssHM-udbzkOWFdOejfMs0ub5NsM9Ta2-TFEKhCfVeunTl42uDKogs2UVW5jRk8TM";
                var password = "ED8bR71JdEI6_dry3rPmUh-CQBxIsD2QmKOBENJLZZVkcGNecAkj014-NBEFsWLHWAnGWuXpsk5iIWeh";

                client.BaseAddress = new Uri("https://api-m.sandbox.paypal.com");

                var authToken = Encoding.ASCII.GetBytes($"{username}:{password}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));

                var data = new StringContent("{}", Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"/v2/checkout/orders/{token}/capture", data);


                status = response.IsSuccessStatusCode;

                ViewData["Status"] = status;
                if (status)
                {
                    var jsonRespuesta = response.Content.ReadAsStringAsync().Result;

                    Transaccion objeto = JsonConvert.DeserializeObject<Transaccion>(jsonRespuesta);

                    ViewData["IdTransaccion"] = objeto.purchase_units[0].payments.captures[0].id;
                }

            }

            return View();
        }

        [HttpPost]
        public async Task<JsonResult> Paypal(string precio, string producto)
        {
            bool status = false;
            string respuesta = string.Empty;

            using (var client = new HttpClient())
            {
                var username = "AYOJ80Gq-WjwfvB5ssHM-udbzkOWFdOejfMs0ub5NsM9Ta2-TFEKhCfVeunTl42uDKogs2UVW5jRk8TM";
                var password = "ED8bR71JdEI6_dry3rPmUh-CQBxIsD2QmKOBENJLZZVkcGNecAkj014-NBEFsWLHWAnGWuXpsk5iIWeh";

                client.BaseAddress = new Uri("https://api-m.sandbox.paypal.com");

                var authToken = Encoding.ASCII.GetBytes($"{username}:{password}");
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Basic", Convert.ToBase64String(authToken));


                var orden = new Ordenes()
                {
                    intent = "CAPTURE",
                    purchase_units = new List<Models.Paypal.PurchaseUnit>() {

                        new Models.Paypal.PurchaseUnit() {

                            amount = new Models.Paypal.Amount() {
                                currency_code = "USD",
                                value = precio
                            },
                            description = producto
                        }
                    },
                    application_context = new WebApplication1.Models.Paypal.ApplicationContext()
                    {
                        brand_name = "Mi Tienda",
                        landing_page = "NO_PREFERENCE",
                        user_action = "PAY_NOW",
                        return_url = "https://localhost:44349/Paga/Resultado",
                        cancel_url = "https://localhost:44349/Home/Index"
                    }
                };

                var json = JsonConvert.SerializeObject(orden);
                var data = new StringContent(json, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync("/v2/checkout/orders", data);

                status = response.IsSuccessStatusCode;

                if (status)
                {
                    respuesta = response.Content.ReadAsStringAsync().Result;
                }
            }
            return Json(new { status = status, respuesta = respuesta }, JsonRequestBehavior.AllowGet);
        }
    }
}
