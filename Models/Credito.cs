namespace TestApi.Models
{
    public class Credito
    {
        public int Id { get; set; }
        public decimal MontoPrestamo { get; set; }
        public decimal Tasa { get; set; }
        public int Plazo { get; set; }
    }
}
