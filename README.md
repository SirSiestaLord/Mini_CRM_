2️⃣ NuGet paketlerini yükleyin

Visual Studio: Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution

Paketler: EntityFramework, Newtonsoft.Json

3️⃣ Web.config ayarları

Connection String ekleyin:

<connectionStrings>
    <add name="MiniCrmContext" 
         connectionString="Server=.;Database=MiniCRM_DB;Trusted_Connection=True;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>


Not: Server=.; kısmını kendi SQL Server instance’ınıza göre değiştirin.
Database=MiniCRM_DB istediğiniz veritabanı adı olabilir.

Veritabanı Entegrasyonu (Entity Framework Code First)
1️⃣ DbContext tanımı (MiniCrmContext.cs)
using System.Data.Entity;

namespace Mini_CRM.Models
{
    public class MiniCrmContext : DbContext
    {
        public MiniCrmContext() : base("name=MiniCrmContext") { }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Meeting> Meetings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Company>()
                        .HasMany(c => c.Meetings)
                        .WithRequired(m => m.Company)
                        .HasForeignKey(m => m.CompanyId)
                        .WillCascadeOnDelete(true);

            base.OnModelCreating(modelBuilder);
        }
    }
}

2️⃣ Database’i oluşturmak

Package Manager Console kullanın ve sırasıyla çalıştırın:

Enable-Migrations
Add-Migration InitialCreate
Update-Database


Bu işlemler Code First ile tabloları ve ilişkileri oluşturur.

Veri Tabanı Şeması

Company Tablosu (Companies)

Column	Tip	Açıklama
CompanyId	int (PK)	Otomatik artan ID
CompanyName	nvarchar(100)	Firma adı
Responsible	nvarchar(100)	Yetkili kişi
Telephone	nvarchar(50)	Telefon numarası
Email	nvarchar(100)	Email adresi
CreatedAt	datetime	Oluşturulma zamanı (default GETDATE())

Meeting Tablosu (Meetings)

Column	Tip	Açıklama
MeetingId	int (PK)	Otomatik artan ID
CompanyId	int (FK)	İlişkili firma ID (Companies.CompanyId)
Subject	nvarchar(200)	Görüşme konusu
Description	nvarchar(max)	Açıklama
MeetingDate	datetime	Görüşme tarihi

Not: Company → Meeting ilişkisi 1:N şeklindedir ve Cascade on Delete aktif.

Kullanım

Visual Studio’da projeyi açın.

F5 tuşuna basarak uygulamayı çalıştırın.

Üst menüden Firma İşlemleri veya Görüşmeler sayfalarına erişin.

Yeni firmalar ekleyin, düzenleyin veya silin.

Görüşmeleri firma ile ilişkilendirin.

Proje Yapısı

Controllers/ → Controller dosyaları

Models/ → Entity Framework modelleri

Views/ → Razor sayfaları (Partial ve Layout kullanımı)

Scripts/ → jQuery, Bootstrap JS

Content/ → CSS ve görseller

Örnek Ekran Görüntüleri

Firma Listesi


Firma Ekle / Düzenle


Görüşmeler


Not: docs/screenshots/ klasörünü projeye ekleyip kendi ekran görüntülerinizi koyabilirsiniz.
