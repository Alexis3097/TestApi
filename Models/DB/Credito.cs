using System;
using System.Collections.Generic;

namespace TestApi.Models.DB
{
    public partial class Credito
    {
        public Credito()
        {
            Amortizacions = new HashSet<Amortizacion>();
        }

        public int Id { get; set; }
        public decimal MontoPrestamo { get; set; }
        public decimal Tasa { get; set; }
        public int Plazo { get; set; }

        public virtual ICollection<Amortizacion> Amortizacions { get; set; }
    }
}
