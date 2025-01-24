using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace AplicaçãoSupport.Models
{
    public class AtendenteModel
    {

        [Key]
        public int Atendente_Id { get; set; }
        [MaxLength(100)]
        public string? Nome_Atendente { get; set; }
        public string? Senha { get; set; }

        public ICollection<AtendimentosModel> Atendimentos { get; set; }


    }
}
