#nullable disable
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestApi.IServices;
using TestApi.Models.DB;
using TestApi.Models;
using System.Net;

namespace TestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditoesController : ControllerBase
    {
        private readonly testApiContext _context;
        private readonly ICreditoService _icreditoService;

        public CreditoesController(testApiContext context, ICreditoService icreditoService)
        {
            _context = context;
            _icreditoService = icreditoService;
        }

        // GET: api/Creditoes
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Credito>>> GetCreditos()
        {
            return await _context.Creditos.ToListAsync();
        }

        // GET: api/Creditoes/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Credito>> GetCredito(int id)
        {
            var credito = await _context.Creditos.FindAsync(id);

            if (credito == null)
            {
                return NotFound();
            }

            return credito;
        }



        //POST: api/Creditoes
        //To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCredito(CreditoDTO creditoDTO)
        {

            try
            {

                //validacion de campos
                if (creditoDTO.MontoPrestamo == null)
                {
                    ModelState.AddModelError("MontoPrestamo", "El campo es requerido");
                }
                else if (creditoDTO.MontoPrestamo.GetType() != typeof(decimal))
                {
                    ModelState.AddModelError("MontoPrestamo", "El campo debe ser numerico");

                }

                if (creditoDTO.Tasa == null)
                {
                    ModelState.AddModelError("Tasa", "El campo es requerido");
                }
                else if (creditoDTO.Tasa.GetType() != typeof(decimal))
                {
                    ModelState.AddModelError("Tasa", "El campo debe ser numerico");

                }


                if (creditoDTO.Plazo == null)
                {
                    ModelState.AddModelError("Plazo", "El campo es requerido");
                    //ModelState.IsValid = true;
                }
                else if (creditoDTO.Plazo.GetType() != typeof(int))
                {
                    ModelState.AddModelError("Plazo", "El campo debe ser numerico");

                }
                else if (creditoDTO.Plazo == 0)
                {
                    ModelState.AddModelError("Plazo", "El campo debe ser mayor a 0");
                }
                if (ModelState.Count > 0)
                {
                    return BadRequest(ModelState);
                }

                //hacemos el mappin del objeto
                Credito credito = new Credito
                {
                    MontoPrestamo = creditoDTO.MontoPrestamo,
                    Tasa = creditoDTO.Tasa,
                    Plazo = creditoDTO.Plazo
                };

                List<AmortizacionDTO> amotizacionListDTO = _icreditoService.amortizacion(credito.MontoPrestamo, credito.Tasa, credito.Plazo);
                List<Amortizacion> amotizacionList = new List<Amortizacion>();
                foreach (AmortizacionDTO amortizacion in amotizacionListDTO)
                {
                    amotizacionList.Add(new Amortizacion
                    {
                        NumeroDeCuota = amortizacion.NumeroDeCuota,
                        MontoCapital = amortizacion.MontoCapital,
                        MontoInteres = amortizacion.MontoInteres,
                        SaldoInsolutoCredito = amortizacion.SaldoInsolutoCredito,
                    });
                }
                credito.Amortizacions = amotizacionList;
                await _context.Creditos.AddAsync(credito);
                await _context.SaveChangesAsync();

                return Ok(amotizacionListDTO);

            }catch (Exception ex)
            {
                return BadRequest(ex);
            }


        }


    }
}
