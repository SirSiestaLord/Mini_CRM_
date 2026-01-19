# Mini CRM Projesi

![Mini CRM](https://img.shields.io/badge/MVC-ASP.NET-blue)
![Database](https://img.shields.io/badge/DB-MS_SQL-green)
![Frontend](https://img.shields.io/badge/Frontend-Bootstrap5-orange)

**Mini CRM**, küçük ve orta ölçekli işletmeler için geliştirilmiş bir müşteri ilişkileri yönetimi uygulamasıdır.  
Projede **ASP.NET MVC 5**, **.NET Framework 4.8**, **Entity Framework (Code First)**, **MS SQL** ve **Bootstrap 5** kullanılmıştır.  

---

## Özellikler

- Firma ekleme, listeleme, düzenleme ve silme
- Görüşmelerin yönetimi
- Partial View ve Layout kullanımı ile temiz UI
- Form doğrulama (jQuery)
- Responsive tasarım (Bootstrap 5)
- Temiz ve anlaşılır Controller yapısı
- Entity Framework Code First ile veri tabanı yönetimi  

---

## Gereksinimler

- Visual Studio 2019/2022  
- .NET Framework 4.8+  
- MS SQL Server  
- NuGet Paketleri:  
  - EntityFramework  
  - Newtonsoft.Json  

---

## Kurulum

1️⃣ Projeyi klonlayın
```bash
git clone https://github.com/kullaniciadi/mini-crm.git
cd mini-crm

2️⃣ NuGet paketlerini yükleyin
Visual Studio: Tools -> NuGet Package Manager -> Manage NuGet Packages for Solution

Paketler: EntityFramework, Newtonsoft.Json

3️⃣ Web.config ayarları
Connection String ekleyin:

xml
Kodu kopyala
<connectionStrings>
    <add name="MiniCrmContext" 
         connectionString="Server=.;Database=MiniCRM_DB;Trusted_Connection=True;" 
         providerName="System.Data.SqlClient" />
</connectionStrings>
Not: Server=.; kısmını kendi SQL Server instance’ınıza göre değiştirin.
Database=MiniCRM_DB istediğiniz veritabanı adı olabilir.

Veritabanı Entegrasyonu (Entity Framework Code First)
1️⃣ DbContext tanımı (MiniCrmContext.cs)
csharp
Kodu kopyala
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

powershell
Kodu kopyala
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

Not: docs/screenshots/ klasörünü projeye ekleyip kendi ekran görüntülerini koyabilirsin.

Lisans
Bu proje MIT lisansı ile yayınlanmıştır. Dilediğiniz şekilde kullanabilirsiniz.

yaml
Kodu kopyala

---

Bu README tamamen **markdown formatında** ve GitHub’a direkt eklenebilir.  
- DB entegrasyonu adım adım anlatıldı  
- Proje yapısı ve ekran görüntü rehberi eklendi  
- Gemma3 veya yapay zekâ kısmı **çıkartıldı**, sadece CRM fonksiyonları anlatıldı  

---

İstersen ben sana buna **otomatik olarak ekran görüntüleri eklenmiş bir `docs/screenshots` klasörü ile birlikte çalışacak repo yapısı** da örnekleyebilirim, böylece GitHub’da profesyonel görünür.  

Bunu da hazırlayayım mı?
