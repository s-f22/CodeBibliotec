using System.ComponentModel.DataAnnotations;

namespace CodeBibliotec.ViewModels
{
    public class CategoriaViewModel
    {
        [Required(ErrorMessage = "O nome da categoria é obrigatório")]
        [StringLength(50, ErrorMessage = "O nome não pode conter mais de 50 caracteres")]
        public string Nome { get; set; }
    }
}
