using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.IdentityModel.Tokens;
using MotoPuntoBack.DTOs;
using MotoPuntoBack.Helpers;
using MotoPuntoBack.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Net.WebSockets;
using System.Security.Claims;
using System.Text;

namespace MotoPuntoBack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly MotopuntoContext _context;
        private readonly IMapper _mapper;  // campo para el mapper
        private readonly IConfiguration _configuration;
        public UsuarioController(MotopuntoContext motocontext, IMapper mapper, IConfiguration configuration)
        {
            _context = motocontext;
            _mapper = mapper;
            _configuration = configuration;
        }


        [HttpPost("EXISTE")]
        public ActionResult<UsuarioDTO> Get([FromBody] Helpers.LoginRequest login) //aca tengo que crear el jwt m
        {
            try
            {
                var jwt = _configuration.GetSection("Jwt").Get<Jwt>();

                var usuarioEntity = _context.Usuarios.FirstOrDefault(u => u.Nombre == login.Usuario && u.Contrasena == login.Contrasena);
                if (usuarioEntity == null)

                {
                    return NotFound();
                }
                var usuarioDto = _mapper.Map<UsuarioDTO>(usuarioEntity);
                if (jwt != null)
                {
                    var claims = new[]
                    {
                    new Claim(JwtRegisteredClaimNames.Sub,jwt.Subject),
                    new Claim(JwtRegisteredClaimNames.Jti,Guid.NewGuid().ToString()),
                    new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                    new Claim(JwtRegisteredClaimNames.Name,usuarioDto.Nombre),
                    new Claim ("Admin" , usuarioDto.Idrol.ToString())

                };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.Key));
                    var SingIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var token = new JwtSecurityToken(
                     issuer: jwt.Issuer,
                     audience: jwt.Audience, // <- coincide con ValidAudience en Program.cs
                     claims: claims,
                     expires: DateTime.UtcNow.AddDays(1),
                     signingCredentials: SingIn
                 );


                    var Objet_Json = new
                    {
                        Token = new JwtSecurityTokenHandler().WriteToken(token),
                        UsuarioA = usuarioDto




                    };
                    return Ok(Objet_Json);

                }
                return NotFound();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost("subirUsuario")]
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
