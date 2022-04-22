using TestApi.IServices;
using TestApi.Models;

namespace TestApi.Services
{
    public class CreditoService : ICreditoService
    {
        public decimal calcularMontoCapital(decimal montoCredito, int plazo)
        {

            try
            {
                return montoCredito / plazo;
            }
            catch (Exception)
            {
                return 0;
            }

        }

        public List<Amortizacion> amortizacion(decimal montoDeCredito, decimal tasa, decimal montoDeCapital, int plazo)
        {
            try
            {
                List<Amortizacion> amortization = new List<Amortizacion>();
                for (int i = 0; i < plazo; i++)
                {
                    int numeroDeCuota = i + 1;
                    decimal saldoInsolutoPendiente = montoDeCredito - (i * montoDeCapital);
                    decimal tasaCalculada = (tasa / 100) / 360;
                    decimal montoDeInteres = saldoInsolutoPendiente * tasaCalculada * 30;
                    decimal saldoInsolutoActual = saldoInsolutoPendiente - montoDeCapital;
                    amortization.Add(new Amortizacion(numeroDeCuota, montoDeCapital, montoDeInteres, saldoInsolutoActual));

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
