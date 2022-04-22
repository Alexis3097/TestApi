using TestApi.IServices;
using TestApi.Models;

namespace TestApi.Services
{
    public class CreditoService : ICreditoService
    {
     

        public List<AmortizacionDTO> amortizacion(decimal montoDeCredito, decimal tasa, int plazo)
        {
            try
            {
                decimal montoDeCapital = montoDeCredito / plazo;
                List<AmortizacionDTO> amortization = new List<AmortizacionDTO>();
                for (int i = 0; i < plazo; i++)
                {
                    int numeroDeCuota = i + 1;
                    decimal saldoInsolutoPendiente = montoDeCredito - (i * montoDeCapital);
                    decimal tasaCalculada = (tasa / 100) / 360;
                    decimal montoDeInteres = saldoInsolutoPendiente * tasaCalculada * 30;
                    decimal saldoInsolutoActual = saldoInsolutoPendiente - montoDeCapital;
                    amortization.Add(new AmortizacionDTO(numeroDeCuota, montoDeCapital, montoDeInteres, saldoInsolutoActual));

                }


                return amortization;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
