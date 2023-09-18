using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using webApi.inlock.codeFirst.manha.Interfaces;
using webApi.inlock.codeFirst.manha.Repositories;
using webApi.inlock.codeFirst.manha.ViewModels;

namespace webApi.inlock.codeFirst.manha.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public LoginController()
        {
            _usuarioRepository = new UsuarioRepository();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel usuario)
        {

        }
    }
}
