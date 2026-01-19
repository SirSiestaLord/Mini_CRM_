🏢 Mini CRM ProjesiMini CRM, küçük ve orta ölçekli işletmelerin müşteri portföylerini yönetmeleri, görüşme kayıtlarını tutmaları ve iş süreçlerini dijitalleştirmeleri için geliştirilmiş web tabanlı bir yönetim panelidir.🚀 Öne Çıkan ÖzelliklerFirma Yönetimi: Firma ekleme, listeleme, güncelleme ve silme işlemleri.Görüşme Takibi: Firmalara özel görüşme notları ve tarihsel veri yönetimi.İlişkisel Veri Yapısı: EF Code First ile kurulan 1:N (Bire-Çok) ilişki mimarisi.Modern UI: Bootstrap 5 ile tamamen responsive (mobil uyumlu) arayüz.Validation: jQuery tabanlı form doğrulamaları ile güvenli veri girişi.Cascade Delete: Firma silindiğinde ilgili tüm görüşmelerin otomatik temizlenmesi.🛠️ Kullanılan TeknolojilerBackend: ASP.NET MVC 5, .NET Framework 4.8ORM: Entity Framework 6 (Code First)Veritabanı: MS SQL ServerFrontend: Bootstrap 5, jQuery, Razor View EngineAraçlar: Newtonsoft.Json, NuGet Package Manager💻 Kurulum ve Çalıştırma1. Projeyi Yerel Bilgisayarınıza İndirinBashgit clone https://github.com/kullaniciadi/mini-crm.git
cd mini-crm
2. Veritabanı Ayarları (Web.config)Web.config dosyasını açın ve connectionStrings bölümünü kendi SQL Server bilgilerinize göre güncelleyin:XML<connectionStrings>
  <add name="MiniCrmContext" 
       connectionString="Server=YOUR_SERVER_NAME;Database=MiniCRM_DB;Trusted_Connection=True;" 
       providerName="System.Data.SqlClient" />
</connectionStrings>
3. Migration ve Veritabanı OluşturmaVisual Studio'da Package Manager Console ekranını açın ve aşağıdaki komutları sırasıyla çalıştırın:PowerShellEnable-Migrations
Add-Migration InitialCreate
Update-Database
📊 Veri Modeli ve ŞemaProje iki ana tablo üzerine kurgulanmıştır:Companies (Firmalar)KolonTipAçıklamaCompanyIdint (PK)Birincil AnahtarCompanyNamenvarchar(100)Firma AdıResponsiblenvarchar(100)Yetkili KişiTelephonenvarchar(50)İletişim NumarasıEmailnvarchar(100)E-posta AdresiMeetings (Görüşmeler)KolonTipAçıklamaMeetingIdint (PK)Birincil AnahtarCompanyIdint (FK)İlgili FirmaSubjectnvarchar(200)Görüşme KonusuMeetingDatedatetimeGörüşme Zamanı📂 Proje YapısıPlaintextMini_CRM/
├── Controllers/    # İş mantığının yönetildiği sınıflar
├── Models/         # Entity sınıfları ve DbContext (Code First)
├── Views/          # UI bileşenleri (Partial View & Layout)
├── Scripts/        # JavaScript ve jQuery kütüphaneleri
└── Content/        # CSS ve Tasarım dosyaları
📸 Ekran Görüntüleri(Buraya kendi ekran görüntülerini ekleyebilirsin)Not: Projeyi çalıştırmak için Visual Studio 2019 veya 2022 kullanmanız önerilir.
