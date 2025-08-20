using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using MotoPuntoBack.DTOs;
using MotoPuntoBack.Helpers;
using MotoPuntoBack.Models;

namespace MotoPuntoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly MotopuntoContext _context;
        private readonly IMapper _mapper;  // campo para el mapper
        public UsuarioController(MotopuntoContext motocontext , IMapper mapper) 
        {
            _context = motocontext;
            _mapper = mapper;
        }


        [HttpPost ("EXISTE")]
        public ActionResult<UsuarioDTO> Get([FromBody] Helpers.LoginRequest login) 
        {
            try
            {

                var usuarioEntity = _context.Usuarios.FirstOrDefault(u => u.Nombre == login.Usuario && u.Contrasena == login.Contrasena);
                if (usuarioEntity == null)
                {
                    return NotFound();
                }
                var usuarioDto = _mapper.Map<UsuarioDTO>(usuarioEntity);
                return Ok(usuarioDto);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost ("subirUsuario")]
        public ActionResult Post(UsuarioDTO usuario) 
        {
            try
            {
                if (usuario == null)
                {
                    return BadRequest();
                }

                var usuarioAux = _mapper.Map<Usuario>(usuario);
                _context.Add(usuarioAux);
                _context.SaveChanges();

                return StatusCode(201);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }


        }

        [HttpGet]
        public ActionResult<IEnumerable<Usuario>> Get() 
        {
            var usuarios = _context.Usuarios.Include(u => u.IdrolNavigation).ToList();

            // Usar AutoMapper para convertir lista de entidades a DTOs
            var usuariosDto = _mapper.Map<List<UsuarioDTO>>(usuarios);
            return Ok(usuariosDto);

        }
    }
}
