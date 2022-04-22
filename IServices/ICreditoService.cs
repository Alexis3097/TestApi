using TestApi.Models;

namespace TestApi.IServices
{
    public interface ICreditoService
    {
        public List<AmortizacionDTO> amortizacion(decimal montoDeCredito, decimal tasa, int plazo);
    }
}
