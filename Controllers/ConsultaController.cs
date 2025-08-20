using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoPuntoBack.DTOs;
using MotoPuntoBack.Models;
using MotoPuntoBack.Helpers;

namespace MotoPuntoBack.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class ConsultaController : ControllerBase
    {
       private readonly MotopuntoContext _context;
        private readonly IMapper _mapper;  // campo para el mapper

        public ConsultaController(MotopuntoContext context, IMapper mapper)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpPut ("CambiarEstado")]
        public ActionResult CambiarEstado([FromBody] Request request)
        {
            try
            {
                var consulta = _context.Consulta.Find(request.IdConsulta);
                if (consulta == null)
                {
                    return NotFound();
                }

                consulta.Estado = request.Estado;
                consulta.FechaContacto = DateTime.Now;
                _context.SaveChanges();

                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public ActionResult<IEnumerable<Consultum>> Get() 
        {
            try
            {
                var consultas = _context.Consulta
           .Include(c => c.IdusuarioNavigation)
           .Include(c => c.IdmotoNavigation)
           .ToList();

                var resp = _mapper.Map<List<ConsultaDTO>>(consultas);

                return Ok(resp);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("crearconsulta")]
        public ActionResult crearConsulta([FromBody] ConsultaDTOPost consulta) 
        {
            try
            {
                if (consulta == null)
                {
                    return BadRequest("ERROR AL INTENTAR CREAR LA CONSULTA");
                }
                consulta.Fecha = DateTime.Now;

                var consultaR = _mapper.Map<Consultum>(consulta);

                _context.Add(consultaR);
                _context.SaveChanges();


                return Ok();
            }
            catch (Exception ex) 
            {
                return BadRequest("ERROR AL INTENTAR CREAR LA CONSULTA");
            }
        }
    }
}
