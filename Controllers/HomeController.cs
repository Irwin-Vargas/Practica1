using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Practica1.Models;
using System.Text.Json;


namespace Practica1.Controllers
{
    public class HomeController : Controller
    {
        private readonly HttpClient _httpClient;

        public HomeController()
        {
            _httpClient = new HttpClient();
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult EnviasRecibe()
        {
            return View();
        }

        public IActionResult Boleta()
        {
            return View();
        }

        [HttpPost]
        public IActionResult ProcesarCambio(string monedaOrigen, string monedaDestino, decimal cantidad)
        {
            decimal tipoCambio = 1.0m;

            if (monedaOrigen == "BRL" && monedaDestino == "PEN")
            {
                tipoCambio = 0.634m;
            }
            else if (monedaOrigen == "PEN" && monedaDestino == "BRL")
            {
                tipoCambio = 1 / 0.634m;
            }

            decimal montoConvertido = cantidad * tipoCambio;

            TempData["MonedaOrigen"] = monedaOrigen;
            TempData["MonedaDestino"] = monedaDestino;
            TempData["Cantidad"] = cantidad.ToString(); 
            TempData["MontoConvertido"] = montoConvertido.ToString(); 

            return RedirectToAction("Boleta");
        }

        [HttpPost]
        public IActionResult GenerarBoleta(string nombre, string documento)
        {
            return RedirectToAction("EnviasRecibe");
        }
    }
}