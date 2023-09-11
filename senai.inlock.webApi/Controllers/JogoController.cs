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
    public class JogoController : ControllerBase
    {
        private IJogoRepository _jogoRepository { get; set; }
        public JogoController()
        {
            //_jogoRepository = new JogoRepository();
        }
    }
}