Harika bir başlangıç! Paylaştığın bilgiler ışığında, projenin profesyonel görünmesini sağlayacak, kullanıcı dostu ve teknik detayları düzenli bir şekilde sunan kapsamlı bir **README.md** hazırladım.

Aşağıdaki metni doğrudan projenin ana dizinine kopyalayıp yapıştırabilirsin.

---

# 🏢 Mini CRM Projesi

**Mini CRM**, küçük ve orta ölçekli işletmelerin müşteri portföylerini yönetmeleri, görüşme kayıtlarını tutmaları ve iş süreçlerini dijitalleştirmeleri için geliştirilmiş web tabanlı bir yönetim panelidir.

## 🚀 Öne Çıkan Özellikler

* **Firma Yönetimi:** Firma ekleme, listeleme, güncelleme ve silme işlemleri.
* **Görüşme Takibi:** Firmalara özel görüşme notları ve tarihsel veri yönetimi.
* **İlişkisel Veri Yapısı:** EF Code First ile kurulan 1:N (Bire-Çok) ilişki mimarisi.
* **Modern UI:** Bootstrap 5 ile tamamen responsive (mobil uyumlu) arayüz.
* **Validation:** jQuery tabanlı form doğrulamaları ile güvenli veri girişi.
* **Cascade Delete:** Firma silindiğinde ilgili tüm görüşmelerin otomatik temizlenmesi.

---

## 🛠️ Kullanılan Teknolojiler

* **Backend:** ASP.NET MVC 5, .NET Framework 4.8
* **ORM:** Entity Framework 6 (Code First)
* **Veritabanı:** MS SQL Server
* **Frontend:** Bootstrap 5, jQuery, Razor View Engine
* **Araçlar:** Newtonsoft.Json, NuGet Package Manager

---

## 💻 Kurulum ve Çalıştırma

### 1. Projeyi Yerel Bilgisayarınıza İndirin

```bash
git clone https://github.com/kullaniciadi/mini-crm.git
cd mini-crm

```

### 2. Veritabanı Ayarları (Web.config)

`Web.config` dosyasını açın ve `connectionStrings` bölümünü kendi SQL Server bilgilerinize göre güncelleyin:

```xml
<connectionStrings>
  <add name="MiniCrmContext" 
       connectionString="Server=YOUR_SERVER_NAME;Database=MiniCRM_DB;Trusted_Connection=True;" 
       providerName="System.Data.SqlClient" />
</connectionStrings>

```

### 3. Migration ve Veritabanı Oluşturma

Visual Studio'da **Package Manager Console** ekranını açın ve aşağıdaki komutları sırasıyla çalıştırın:

```powershell
Enable-Migrations
Add-Migration InitialCreate
Update-Database

```

---

## 📊 Veri Modeli ve Şema

Proje iki ana tablo üzerine kurgulanmıştır:

### **Companies (Firmalar)**

| Kolon | Tip | Açıklama |
| --- | --- | --- |
| `CompanyId` | int (PK) | Birincil Anahtar |
| `CompanyName` | nvarchar(100) | Firma Adı |
| `Responsible` | nvarchar(100) | Yetkili Kişi |
| `Telephone` | nvarchar(50) | İletişim Numarası |
| `Email` | nvarchar(100) | E-posta Adresi |

### **Meetings (Görüşmeler)**

| Kolon | Tip | Açıklama |
| --- | --- | --- |
| `MeetingId` | int (PK) | Birincil Anahtar |
| `CompanyId` | int (FK) | İlgili Firma |
| `Subject` | nvarchar(200) | Görüşme Konusu |
| `MeetingDate` | datetime | Görüşme Zamanı |

---

## 📂 Proje Yapısı

```text
Mini_CRM/
├── Controllers/    # İş mantığının yönetildiği sınıflar
├── Models/         # Entity sınıfları ve DbContext (Code First)
├── Views/          # UI bileşenleri (Partial View & Layout)
├── Scripts/        # JavaScript ve jQuery kütüphaneleri
└── Content/        # CSS ve Tasarım dosyaları

```

---

## 📸 Ekran Görüntüleri

*(Buraya kendi ekran görüntülerini ekleyebilirsin)*

> **Not:** Projeyi çalıştırmak için Visual Studio 2019 veya 2022 kullanmanız önerilir.
