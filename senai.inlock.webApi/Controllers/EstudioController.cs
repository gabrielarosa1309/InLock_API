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
    public class EstudioController : ControllerBase
    {
        private IEstudioRepository _estudioRepository { get; set; }
        public EstudioController()
        {
            _estudioRepository = new EstudioRepository();
        }

        /// <summary>
        /// Endpoint que aciona o método ListarTodos no repositório
        /// </summary>
        /// <returns> Retorna a resposta para o usuário (front-end) </returns>
        [HttpGet]
        ///[Authorize(Roles = "Administrador , Comum")]
        public IActionResult Get()
        {
            try
            {
                //Cria uma lista que recebe os dados da requisição
                List<EstudioDomain> listaEstudios = _estudioRepository.ListarTodos();

                //Retorna a lista no formato JSON com o status code Ok(200)
                return Ok(listaEstudios);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de buscar estúdio pelo id
        /// </summary>
        /// <param name="id"> Objeto recebido na requisição </param>
        /// <returns> Retorna a resposta para o usuário (front-end) </returns>
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                //Cria um objeto estudioBuscado que irá receber o estúdio buscado no db
                EstudioDomain estudioBuscado = _estudioRepository.GetById(id);

                //Verifica se nenhum estúdio foi encontrado
                if (estudioBuscado == null)
                {
                    //Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                    return NotFound("Nenhum estúdio foi encontrado!");
                }

                //Caso seja encontrado, retorna o estúdio buscado com um status code 200 - Ok
                return Ok(estudioBuscado);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de cadastro do estúdio
        /// </summary>
        /// <param name="novoEstudio"> Objeto recebido na requisição </param>
        /// <returns> Retorna a resposta para o usuário (front-end) </returns>
        [HttpPost]
        //[Authorize(Roles = "Administrador")]
        public IActionResult Post(EstudioDomain novoEstudio)
        {
            try
            {
                //Fazendo a chamada para o método cadastrar passando o objeto como parâmetro
                _estudioRepository.Cadastrar(novoEstudio);

                //Retorna um status code 201 - Created
                return StatusCode(201);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de atualizar estúdio buscando pelo id
        /// </summary>
        /// <param name="id"> Objeto recebido na requisição </param>
        /// <param name="estudioUpdateUrl"> Objeto devolvido na requisição </param>
        /// <returns> Retorna a resposta para o usuário (front-end) </returns>
        [HttpPut("{id}")]
        public IActionResult PutIdUrl(int id, EstudioDomain estudioUpdateUrl)
        {
            try
            {
                EstudioDomain estudioBuscado = _estudioRepository.GetById(id);

                if (estudioBuscado == null)
                {
                    //Caso não seja encontrado, retorna um status code 404 - Not Found com a mensagem personalizada
                    return NotFound("Nenhum estúdio foi encontrado para ser atualizado!");
                }

                _estudioRepository.UpdateByIdUrl(id, estudioUpdateUrl);

                //Retorna o gênero atualizado com um status code 200 - Ok
                return StatusCode(200);
            }
            catch (Exception erro)
            {
                //Retorna um status code 400 - BadRequest e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }

        /// <summary>
        /// Endpoint que aciona o método de deletar o estúdio
        /// </summary>
        /// <param name="id"> Objeto recebido na requisição </param>
        /// <returns> Retorna a resposta para o usuário (front-end) </returns>
        [HttpDelete]
        public IActionResult Deletar(int id)
        {
            try
            {
                //Fazendo a chamada para o método deletar passando o objeto como parâmetro
                _estudioRepository.Deletar(id);

                //Retorna um status code 202 - Deleted
                return StatusCode(202);
            }
            catch (Exception erro)
            {   
                //Retorna um status code 400 - BadRequest e a mensagem do erro
                return BadRequest(erro.Message);
            }
        }
    }
}
