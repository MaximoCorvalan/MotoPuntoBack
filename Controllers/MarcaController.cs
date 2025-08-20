using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MotoPuntoBack.DTOs;
using MotoPuntoBack.Models;

namespace MotoPuntoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MarcaController : ControllerBase
    {
    
        private readonly MotopuntoContext _context;
        private readonly IMapper _mapper;  // campo para el mapper
        public MarcaController( MotopuntoContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        [HttpPost]
        public ActionResult subirMarca(MarcaDTO marca)        
        {
            try
            {
                var marc = _mapper.Map<Marca>(marca);

                _context.Add(marc);
                _context.SaveChanges();


                return Ok(marca);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public IEnumerable<Marca> Get()
        {

            return _context.Marcas;
        }


    }
}
