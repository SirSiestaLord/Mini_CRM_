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
git clone (https://github.com/SirSiestaLord/Mini_CRM_.git)
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
| `ActionDate` | datetime | Görüşme Zamanı |
| `MeetingNote` | nvarchar(200) | Görüşme Konusu |
| `MeetingType` | nvarchar(200) | Görüşme Tipi |
| `NextActionDate` | datetime | Gelecek Görüşme Zamanı |

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

<img width="1318" height="322" alt="image" src="https://github.com/user-attachments/assets/68a70d86-3354-4487-a8d3-cbb5bccaa153" />
<img width="1297" height="257" alt="image" src="https://github.com/user-attachments/assets/6c227339-4567-4978-9ff1-732b31f5ce0a" />
<img width="395" height="372" alt="image" src="https://github.com/user-attachments/assets/e1b24b28-7bd6-40c5-99a6-c5f812671d18" />
<img width="1383" height="201" alt="image" src="https://github.com/user-attachments/assets/1b1ce57d-515b-4647-8f0f-c5608736fec7" />
<img width="427" height="601" alt="image" src="https://github.com/user-attachments/assets/8b4067e1-f120-4bb3-aac1-cddd2df87b42" />
<img width="1373" height="198" alt="image" src="https://github.com/user-attachments/assets/cd692582-86c7-4c64-9fd6-bf5e64737f41" />


> **Not #1:** Projeyi çalıştırmak için Visual Studio 2019 veya 2022 kullanmanız önerilir.
> **Not #2:** Başlangıçta bin\roslyn\csc.exe hatası alırsanız projeyi kapatın ve dosya üzerinden master dosyasını kapsayacak şekilde açın. daha sonrasında .sln dosyası ile projeyi açabilirsiniz.
