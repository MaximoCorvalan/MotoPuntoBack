using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MotoPuntoBack.DTOs;
using MotoPuntoBack.Models;

namespace MotoPuntoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MotoController : ControllerBase
    {
        private readonly MotopuntoContext _context;
        private readonly IMapper _mapper;  // campo para el mapper
        public MotoController(MotopuntoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public ActionResult<IEnumerable<Moto>> Get()
        {
            try
            {
                var motos = _context.Motos.Include(m => m.IdmarcaNavigation).Include(m => m.Imagens).ToList();

                // Usar AutoMapper para convertir lista de entidades a DTOs
                var motosDto = _mapper.Map<List<MotoDTO>>(motos);
                return Ok(motosDto);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }


  

        [HttpGet("{id}")]
        public ActionResult<Moto> Get(int id)
        {
            try
            {
                var moto = _context.Motos.Find(id);
                if (moto == null)
                {
                    return NotFound();
                }
                return moto;
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] PostMotoDTO dto)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                var moto = _mapper.Map<Moto>(dto);

                _context.Motos.Add(moto);

                _context.SaveChanges();

                return Ok(moto);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
