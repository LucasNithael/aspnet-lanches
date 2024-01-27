using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace LanchesMac.Models
{
    [Table("Lanches")]
    public class Lanche
    {
        [Key]
        public int LancheId { get; set; }

        [StringLength(100, MinimumLength = 10, ErrorMessage = "O nome do lanche aceita entre {2} e {1} caracteres")]
        [Required(ErrorMessage ="Informa o noem do lanche")]
        [Display(Name ="Nome do lanche")]
        public string Nome { get; set; }

        [MinLength(20, ErrorMessage ="Descrição deve ter no mínimo {1} caracteres")] // Alternativa para definir o tamanho mínimo do campo
        [MaxLength(200, ErrorMessage ="Descrição pode exceder {1} caracteres")] // E aqui o tamanho máximo
        [Required(ErrorMessage ="Informe a breve descrição do lanche")]
        [Display(Name ="Breve Descrição do Lanche")]
        public string DescricaoCurta { get; set; }

        [StringLength(400, ErrorMessage ="A descrição detalhada aceita até 400 caracteres")] // StringLength define o tamaho máximo da string e também pode informa o tamanho mínimo com, igual foi definido no campo Nome
        [Required(ErrorMessage ="Informe da descrição detalhada do lanche")]
        [Display(Name="Descrição Detalhada do Lanche")]
        public string DescricaoDetalhada { get; set; }

        [Required(ErrorMessage ="Informe o preço do lanche")] // Esse atributo de Data Annotation define que o campo é obrigatório
        [Display(Name ="Preço")]
        [Column(TypeName ="decimal(10,2)")] //Mapea o tipo e a precisão da coluna no DB
        [Range(1, 999.99, ErrorMessage ="O preço deve está entre {1} e {2}")]  //Define o intervalo que o valor do atributo deve está
        public decimal Preco { get; set; }

        [Display(Name = "Caminho da imagem Normal")]
        [StringLength(200, ErrorMessage ="O {0} deve ter no máximo {1} caracteres")] // {0} faz referência ao nome do atributo
        public string ImageUrl { get; set; }

        [Display(Name = "Caminho da imagem Miniatura")]
        [StringLength(200, ErrorMessage = "O {0} deve ter no máximo {1} caracteres")] // {0} faz referência ao nome do atributo
        public string ImageThumbnailUrl { get; set; }
        
        [Display(Name ="Preferido?")]
        public bool IsLanchePreferido { get; set; }
        
        [Display(Name ="Estoque")]
        public bool EmEstoque { get; set; }

        public int CategoriaId { get; set; }
        public virtual Categoria Categoria { get; set; }
    }
}
