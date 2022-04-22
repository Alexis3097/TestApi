namespace TestApi.Models
{
    public class Amortizacion
    {
        public Amortizacion(int NumeroDeCuota, decimal MontoCapital, decimal MontoInteres, decimal SaldoInsolutoCredito)
        {
            this.NumeroDeCuota = NumeroDeCuota;
            this.MontoCapital = MontoCapital;
            this.MontoInteres = MontoInteres;
            this.SaldoInsolutoCredito = SaldoInsolutoCredito;
        }
        public int FkCreditoId { get; set; }
        public int NumeroDeCuota { get; set; }
        public decimal MontoCapital { get; set; }
        public decimal MontoInteres { get; set; }
        public decimal SaldoInsolutoCredito { get; set; }
    }
}
