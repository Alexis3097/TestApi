using TestApi.Models;

namespace TestApi.IServices
{
    public interface ICreditoService
    {
        public decimal calcularMontoCapital(decimal montoCredito, int plazo);
        public List<Amortizacion> amortizacion(decimal montoDeCredito, decimal tasa, decimal montoDeCapital, int plazo);
    }
}
