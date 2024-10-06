using System;
using System.ComponentModel.DataAnnotations;

namespace crud.Models{
    public class Reporte{
    public int Id {get; set;} = 0;
    public DateTime Fecha {get; set;} = DateTime.Now;

    [Required (ErrorMessage = "El campo Descripcion es requerido")]
    [MinLength(10, ErrorMessage = "Debe cumplir con al menos 10 caracteres")]
    public string Descripcion {get; set;} = "";

    public double CostoEstimado {get; set;} = 0;

    public int Muertos {get; set;} = 0;

    public int Heridos {get; set;} = 0;

    public int VehiculosInvolucrados {get; set;} = 0;

    }

}
