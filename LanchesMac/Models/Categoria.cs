using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Categorias")]
    public class Categoria
    {
        [Key]
        public int CategoriaId { get; set; }

        [StringLength(100, ErrorMessage = "o tamanho máximo é 100 caracteres")]
        [Required(ErrorMessage = "Informe o nome da categoria")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [StringLength(200, ErrorMessage ="O tamanho máximo é 200 caracteres")]
        [Required(ErrorMessage ="Informe da descrição da categoria")]
        [Display(Name ="Descrição da Categoria")]
        public string Descricao { get; set; }

        public List<Lanche> Lanches { get; set; }
    }
}
