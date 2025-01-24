using System.ComponentModel.DataAnnotations;

namespace AplicaçãoSupport.Models
{
    public class EmpresaModel
    {
        [Key]
        public int Empresa_Id { get; set; }
        public string? Nome_Empresa { get; set; }
        
        public ICollection<ClienteModel> clientes { get; set; }
    }
}
