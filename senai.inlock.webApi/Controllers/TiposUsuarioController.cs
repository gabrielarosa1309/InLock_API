using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using senai.inlock.webApi.Domains;
using senai.inlock.webApi.Interfaces;
using senai.inlock.webApi.Repositories;

namespace senai.inlock.webApi.Controllers
{
    [Route("api/[controller]")]

    [ApiController]

    [Produces("application/json")]
    public class TiposUsuarioController : ControllerBase
    {
        private ITiposUsuarioRepository _tiposusuarioRepository { get; set; }
        public TiposUsuarioController()
        {
            //_tiposusuarioRepository = new TiposUsuarioRepository();
        }
    }
}