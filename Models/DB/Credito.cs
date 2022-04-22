using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
namespace TestApi.Models.DB
{
    public partial class Credito
    {
        public Credito()
        {
            Amortizacions = new HashSet<Amortizacion>();
        }

        public int Id { get; set; }
        [Required(ErrorMessage = "El monto del prestamo es requerido")]
        public decimal MontoPrestamo { get; set; }
        [Required(ErrorMessage = "La tasa es requerida")]
        public decimal Tasa { get; set; }
        [Required(ErrorMessage = "El plazo es requerido")]
        public int Plazo { get; set; }

        public virtual ICollection<Amortizacion> Amortizacions { get; set; }
    }
}
