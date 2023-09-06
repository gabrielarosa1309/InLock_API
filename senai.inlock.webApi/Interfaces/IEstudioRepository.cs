using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IEstudioRepository
    {
        //GET
        List<EstudioDomain> ListarTodos();

        //GET (por id)
        EstudioDomain GetById(int id);

        //POST
        void Cadastrar(EstudioDomain novoEstudio);

        //PUT
        void UpdateByIdUrl(int id, EstudioDomain estudioUpdateUrl);

        //DELETE
        void Deletar(int id);
    }
}
