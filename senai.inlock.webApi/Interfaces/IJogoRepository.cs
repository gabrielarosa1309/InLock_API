using senai.inlock.webApi.Domains;

namespace senai.inlock.webApi.Interfaces
{
    public interface IJogoRepository
    {
        //GET
        List<JogoDomain> ListarTodos();

        //GET (por id)
        JogoDomain GetById(int id);

        //POST
        void Cadastrar(JogoDomain novoJogo);

        //PUT
        void UpdateByIdUrl(int id, JogoDomain jogoUpdateUrl);

        //DELETE
        void Deletar(int id);
    }
}
