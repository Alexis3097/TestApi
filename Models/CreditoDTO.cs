

using System.ComponentModel.DataAnnotations;

namespace TestApi.Models
{
    public class CreditoDTO
    {
        [Required]
        public decimal MontoPrestamo { get; set; }
        [Required]
        public decimal Tasa { get; set; }
        [Required]
        public int Plazo { get; set; }
    }
}
