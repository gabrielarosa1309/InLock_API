using webApi.inlock.codeFirst.manha.Contexts;
using webApi.inlock.codeFirst.manha.Domains;
using webApi.inlock.codeFirst.manha.Interfaces;
using webApi.inlock.codeFirst.manha.Utils;

namespace webApi.inlock.codeFirst.manha.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        /// <summary>
        /// Variável privada e somente leitura para armazenar os dados do contexto
        /// </summary>
        private readonly InlockContext ctx;

        /// <summary>
        /// Construtor do repositório
        /// Toda vez que o repositório for instanciado, ele terá acesso aos dados fornecidos pelo contexto
        /// </summary>
        public UsuarioRepository()
        {
            ctx = new InlockContext();
        }

        public Usuario BuscarUsuario(string email, string senha)
        {
            try
            {
                Usuario usuarioBuscado = ctx.Usuario.FirstOrDefault(u => u.Email == email)!;

                if (usuarioBuscado != null) 
                {
                    bool confere = Criptografia.CompararHash(senha, usuarioBuscado.Senha!);

                    if (confere) 
                    {
                        return usuarioBuscado;
                    };
                }

                return null!;
            }

            catch (Exception)
            {
                throw;
            }
        }

        public void Cadastrar(Usuario usuario)
        {
            try
            {
                usuario.Senha = Criptografia.GerarHash(usuario.Senha!);

                ctx.Add(usuario);

                ctx.SaveChanges();
            }
            catch (Exception) 
            {
                throw;
            }
        }
    }
}
