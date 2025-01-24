using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AplicaçãoSupport.Models
{
    public class ClienteModel
    {
        [Key]
        public int? ClienteId { get; set; }
        [MaxLength(150)]
        public string? Nome_Cliente { get; set; }

        public int? Empresa_id { get; set; }
                

    }
}
