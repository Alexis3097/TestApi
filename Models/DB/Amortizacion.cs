using System;
using System.Collections.Generic;

namespace TestApi.Models.DB
{
    public partial class Amortizacion
    {
        public int Id { get; set; }
        public int FkCreditoId { get; set; }
        public int NumeroDeCuota { get; set; }
        public decimal MontoCapital { get; set; }
        public decimal MontoInteres { get; set; }
        public decimal SaldoInsolutoCredito { get; set; }

        public virtual Credito FkCredito { get; set; } = null!;
    }
}
