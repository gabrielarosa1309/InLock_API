using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webApi.inlock.codeFirst.manha.Domains
{
    [Table("Usuario")]
    [Index(nameof(Email), IsUnique=true)] //Cria um índice único para
    public class Usuario
    {
        [Key]
        public Guid IdUsuario { get; set; } = Guid.NewGuid();

        [Column(TypeName = "VARCHAR(100)")]
        [Required(ErrorMessage = "Email obrigatório!")]
        public string? Email { get; set; }

        [Column(TypeName = "VARCHAR(60)")] //60 caracteres é o tamanho padrão da Hash que estamos usando
        [Required(ErrorMessage = "Senha obrigatória!")]
        [StringLength(60, MinimumLength = 6, ErrorMessage = "Senha deve conter de 6 á 20 caracteres")]
        public string? Senha { get; set; }

        //Referência da chave estrangeira (tabela de tipos de usuário)
        [Required(ErrorMessage = "Informe o tipo do usuário!")]
        public Guid IdTipoUsuario { get; set; }

        [ForeignKey("IdTipoUsuario")]
        public TiposUsuario? TipoUsuario { get; set; }
    }
}
