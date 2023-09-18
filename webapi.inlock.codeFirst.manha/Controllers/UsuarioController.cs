using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.inlock.codeFirst.manha.Domains;
using webApi.inlock.codeFirst.manha.Interfaces;
using webApi.inlock.codeFirst.manha.Repositories;

namespace webApi.inlock.codeFirst.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class UsuarioController : ControllerBase
    {
        private IUsuarioRepository _usuarioRepository { get; set; }

        public UsuarioController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Post(Usuario usuario) 
        { 
            try
            {
                _usuarioRepository.Cadastrar(usuario);

                return Ok();
            }
            catch (Exception e) 
            { 
                return BadRequest(e.Message);
            }
        }

        [HttpGet]
        public IActionResult Get(int id) 
        { }
    }
}
