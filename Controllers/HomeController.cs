using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Practica1.Models;
using System.Text.Json;


namespace Practica1.Controllers;

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
        decimal tipoCambio = 1.0m; // Valor por defecto

        // Definir el tipo de cambio fijo
        if (monedaOrigen == "BRL" && monedaDestino == "PEN")
        {
            tipoCambio = 0.634m; // 1 BRL = 0.634 PEN
        }
        else if (monedaOrigen == "PEN" && monedaDestino == "BRL")
        {
            tipoCambio = 1 / 0.634m; // 1 PEN = 1.577 BRL (inverso)
        }

        decimal montoConvertido = cantidad * tipoCambio;

        TempData["MonedaOrigen"] = monedaOrigen;
        TempData["MonedaDestino"] = monedaDestino;
        TempData["Cantidad"] = cantidad;
        TempData["MontoConvertido"] = montoConvertido;

        return RedirectToAction("Boleta");
    }

}