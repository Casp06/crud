using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using crud.Models;

public class ReporteController : Controller
{
    private static List<Reporte> registros = new List<Reporte>();

    public ActionResult Index()
    {
        // Podríamos pasar los registros y las estadísticas al modelo de la vista
        return View(registros);
    }

    [HttpPost]
    public ActionResult Crear(Reporte nuevoRegistro)
    {
        nuevoRegistro.Id = registros.Count + 1; // Simulamos un Id único
        registros.Add(nuevoRegistro);
        return RedirectToAction("Index");
    }

    public ActionResult Eliminar(int id)
    {
        var registro = registros.FirstOrDefault(r => r.Id == id);
        if (registro != null)
        {
            registros.Remove(registro);
        }
        return RedirectToAction("Index");
    }

    // Método para obtener estadísticas
    public ActionResult Estadisticas()
    {
        var estadisticas = new EstadisticasViewModel
        {
            TotalMuertos = registros.Sum(r => r.Muertos),
            TotalHeridos = registros.Sum(r => r.Heridos),
            TotalVehiculosInvolucrados = registros.Sum(r => r.VehiculosInvolucrados),
            TotalAccidentes = registros.Count,
            TotalCostosEstimados = registros.Sum(r => r.CostoEstimado)
        };

        return View("Estadisticas", estadisticas); // Vista separada para estadísticas
    }
}

