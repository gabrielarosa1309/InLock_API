using System.ComponentModel.DataAnnotations;

namespace senai.inlock.webApi.Domains
{
    public class UsuarioDomain
    {
        public int IdUsuario { get; set; }

        public TiposUsuarioDomain? IdTipoUsuario { get; set; }

        [Required(ErrorMessage = "O campo e-mail é obrigtório!")]
        public string Email { get; set; }

        [StringLength(20, MinimumLength = 3, ErrorMessage = "A senha deve ter de 3 a 20 caracteres!")]
        [Required(ErrorMessage = "O campo senha é obrigtório!")]
        public string Senha { get; set; }
    }
}
