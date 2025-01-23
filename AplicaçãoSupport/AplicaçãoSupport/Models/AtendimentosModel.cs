using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema; 

namespace AplicaçãoSupport.Models
{
    public class AtendimentosModel
    {
        [Key, Required]
        public int Atendimento_Id { get; set; }  

        public AtendenteModel? Atendente { get; set; }

        [Required, MaxLength(500)]
        public string? Problema { get; set; }
        public ClienteModel? Cliente { get; set; }
        [Required]
        public DateTime Data_Atendimento { get; set; }
        [Required]
        public DateTime Data_Inclusão { get; set; }
        

    }
}
