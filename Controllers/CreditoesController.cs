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

         
        // POST: api/Creditoes
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<IActionResult> PostCredito(Credito credito)
        {
            if (ModelState.IsValid)
            {
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
            }
            else
            {
                //return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                return UnprocessableEntity( ModelState);
                //BadRequest
            }

            
        }

      
    }
}
