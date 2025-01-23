using System.ComponentModel.DataAnnotations;

namespace AplicaçãoSupport.Models
{
    public class EmpresaModel
    {
        [Key]
        public int Empresa_Id { get; set; }

        [Required, MaxLength(100)]
        public string Nome_Empresa { get; set; }
        
    }
}
