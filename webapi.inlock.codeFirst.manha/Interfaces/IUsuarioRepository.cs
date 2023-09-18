using webApi.inlock.codeFirst.manha.Domains;

namespace webApi.inlock.codeFirst.manha.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario BuscarUsuario(string email, string senha);
        void Cadastrar(Usuario usuario);
    }
}
