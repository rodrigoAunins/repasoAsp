using Microsoft.VisualBasic.CompilerServices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVCCrud.Models.ViewModels
{
    public class NuevoTablaViewModel
    {
        private int id;
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre")]
        private string nombre;
        [Required]
        [StringLength(50)]
        [EmailAddress]
        [Display(Name = "Correo")]
        private string correo;
        [Required]
        [DataType(DataType.Date)]
        [Display(Name = "Fecha de Nacimiento")]
        private DateTime fecha_nacimiento;


        public int Id { get => id; set => id = value; }
        public string Nombre { get => nombre; set => nombre = value; }
        public string Correo { get => correo; set => correo = value; }
        public DateTime Fecha_nacimiento { get => fecha_nacimiento; set => fecha_nacimiento = value; }
    }
}