using System;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WeblawyersBox.Models;

namespace WeblawyersBox.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser, ApplicationRole,Guid>
    {
        public virtual DbSet<Empresa_tb> Empresa_Tbs { get; set; }
        public virtual DbSet<Cliente_tb> Cliente_Tbs { get; set; }
        public virtual DbSet<TpProcesso> TpProcessos { get; set; }
        public virtual DbSet<Processo_tb> Processo_Tbs { get; set; }
        public virtual DbSet<Audiencia_tab> Audiencia_Tabs { get; set; }
        public virtual DbSet<Documentos_Processos_tb> Documentos_Processos_Tbs { get; set; }
        public virtual DbSet<Pessoas_Envolvidas_tb> Pessoas_Envolvidas_Tbs { get; set; }
        public virtual DbSet<ActividadesProcessos> ActividadesProcessos { get; set; }
        public virtual DbSet<Intrevistas> Intrevistas { get; set; }
        public virtual DbSet<EstatusProcess> EstatusProcesses { get; set; }
        public virtual DbSet<FacturacaoTbs> FacturacaoTBs { get; set; }
        public virtual DbSet<timesheetTbs> TimesheetTbs { get; set; }
        public virtual DbSet<CobrancaTB> CobrancaTBs { get; set; }
        public virtual DbSet<licensastbs> Licensastbs { get; set; }
        public virtual DbSet<DetalhesCobranca> DetalhesCobrancas { get; set; }

       
        
        public virtual DbSet<pagamentoLicenca> PagamentoLicencas { get; set; }
      

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

      
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<IdentityUser>(b =>
            //{
            //    b.ToTable("Usuarios");
            //});

            //modelBuilder.Entity<IdentityUserClaim<string>>(b =>
            //{
            //    b.ToTable("MyUserClaims");
            //});

            //modelBuilder.Entity<IdentityUserLogin<string>>(b =>
            //{
            //    b.ToTable("Usuarioslogados");
            //});

            //modelBuilder.Entity<IdentityUserToken<string>>(b =>
            //{
            //    b.ToTable("UserTokens");
            //});

            //modelBuilder.Entity<IdentityRole>(b =>
            //{
            //    b.ToTable("Roles");
            //});

            //modelBuilder.Entity<IdentityRoleClaim<string>>(b =>
            //{
            //    b.ToTable("RoleClaims");
            //});

            //modelBuilder.Entity<IdentityUserRole<string>>(b =>
            //{
            //    b.ToTable("UserRoles");
            //});
            //modelBuilder.Entity<ApplicationUser>(b =>
            //{
            //    // Each User can have many UserClaims
            //    b.HasMany(e => e.Claims)
            //        .WithOne()
            //        .HasForeignKey(uc => uc.UserId)
            //        .IsRequired();

               

               
            //});
           
        }
        
        public DbSet<WeblawyersBox.Models.licensastbs> licensastbs { get; set; }
    }
    
}
