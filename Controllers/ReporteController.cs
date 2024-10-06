using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using crud.Models;

public class ReporteController : Controller
{
    private static List<Reporte> registros = new List<Reporte>();

    public ActionResult Index()
    {
        return View( registros);
    }

    public ActionResult Crear()
    {
        return View("RegistrosEdit", new Reporte());
    }

    [HttpPost]
    public ActionResult Crear(Reporte nuevoRegistro)
    {
        nuevoRegistro.Id = registros.Count + 1; // Simulamos un Id único
        registros.Add(nuevoRegistro);
        return RedirectToAction("Index");
    }

    public ActionResult Editar(int id)
    {
        var registro = registros.FirstOrDefault(r => r.Id == id);
        if (registro == null)
        {
            return NotFound();
        }

        return View("RegistrosEdit", registro);
    }

    [HttpPost]
    public ActionResult GuardarCambios(Reporte registroActualizado)
    {
        var registro = registros.FirstOrDefault(r => r.Id == registroActualizado.Id);
        if (registro != null)
        {
            // Actualizamos el registro existente
            registro.Fecha = registroActualizado.Fecha;
            registro.Descripcion = registroActualizado.Descripcion;
            registro.CostoEstimado = registroActualizado.CostoEstimado;
            registro.Muertos = registroActualizado.Muertos;
            registro.Heridos = registroActualizado.Heridos;
            registro.VehiculosInvolucrados = registroActualizado.VehiculosInvolucrados;
        }

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

        return View("Estadisticas", estadisticas);
    }
}
