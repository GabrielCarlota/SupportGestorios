using AplicaçãoSupport.Models;
using AplicaçãoSupport.Context;
using Microsoft.EntityFrameworkCore;

namespace AplicaçãoSupport.Context
{
    public class AplicaçãoSupportDbContext : DbContext
    {
        public AplicaçãoSupportDbContext(DbContextOptions<AplicaçãoSupportDbContext> options) : base(options) { } 

        public DbSet<AtendenteModel> Atendente { get; set; }
        public DbSet<AtendimentosModel> Atendimentos { get; set; }
        public DbSet<ClienteModel> Cliente { get; set; }
        public DbSet<EmpresaModel> Empresa { get; set; }
    }
}
