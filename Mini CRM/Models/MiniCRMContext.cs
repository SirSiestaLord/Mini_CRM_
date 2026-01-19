using System.Data.Entity;
// Veritabanı bağlamı sınıfı ve varlık yapılandırması
namespace Mini_CRM.Models
{
    public class MiniCrmContext : DbContext
    {
        public MiniCrmContext()
            : base("name=MiniCRMConnection")
        {
        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                .ToTable("company_table");

            modelBuilder.Entity<Meeting>()
                .ToTable("meetings_table");

            base.OnModelCreating(modelBuilder);
        
            modelBuilder.Entity<Meeting>()
                .HasRequired(m => m.Company)
                .WithMany(c => c.Meetings)
                .HasForeignKey(m => m.CompanyId)
                .WillCascadeOnDelete(true);
        

    }

}
}
