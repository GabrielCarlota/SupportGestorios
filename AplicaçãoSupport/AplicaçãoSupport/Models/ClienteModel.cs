using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicaçãoSupport.Models
{
    public class ClienteModel
    {
        [Key]
        public int Cliente_Id { get; set; }
        [Required, MaxLength(150)]
        public string? Nome_Cliente { get; set; }
        public EmpresaModel? Empresa { get; set; }

    }
}
