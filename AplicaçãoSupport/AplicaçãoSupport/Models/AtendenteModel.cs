using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AplicaçãoSupport.Models
{
    public class AtendenteModel
    {

        public AtendenteModel()
        {
            Atendimentos = new Collection<AtendimentosModel>();
        }
        [Key]
        public int Atendente_Id { get; set; }
        [Required]
        [MaxLength(100)]
        public string? Nome_Atendente { get; set; }
        [Required]
        public int? Cargo { get; set; }

        public ICollection<AtendimentosModel> Atendimentos { get; set; }

    }
}
