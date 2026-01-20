# 🚀 QA Master - Kurumsal Test Yönetim Sistemi

![License](https://img.shields.io/badge/license-MIT-blue.svg)
![.NET Core](https://img.shields.io/badge/.NET%20Core-8.0-purple)
![Architecture](https://img.shields.io/badge/Architecture-MVC-orange)
![Status](https://img.shields.io/badge/status-Completed-success)

### 🎯QA Master - Kurumsal Test Yönetim Sistemi Kimler İçin Uygundur?
Bu proje; karmaşık Excel dosyaları veya pahalı lisanslı ürünler arasında kaybolmak istemeyen **KOBİ'ler**, **Çevik (Agile) Yazılım Ekipleri** ve **Start-up'lar** için idealdir.

* **Test Mühendisleri (QA Testers):** Günlük test koşumlarını ve veri girişlerini hızlı, göz yormayan bir arayüzde yapmak isteyenler için.
* **QA Yöneticileri (QA Leads):** Projenin genel durumunu grafiklerle izlemek, modül mimarisini kurmak ve ekibin yetkilerini yönetmek isteyenler için.
---

## 🎥 Proje Tanıtım Videosu

Projenin tüm özelliklerini, Admin/User yetki farklarını ve kullanım senaryolarını aşağıdaki videodan izleyebilirsiniz:

[![QA Master Tanıtım](https://img.youtube.com/vi/JNbWjPrlitc/0.jpg)](https://www.youtube.com/watch?v=JNbWjPrlitc)



## 🏗️ Mimari Yapı: ASP.NET Core MVC

Bu proje, **MVC (Model-View-Controller)** mimari deseni üzerine inşa edilmiştir. Bu yapı sayesinde projenin yönetilebilirliği, test edilebilirliği ve geliştirme hızı artırılmıştır.

Projedeki MVC katmanlarının işleyişi şöyledir:

### 1. 🗂️ Model (Veri ve İş Mantığı)
Uygulamanın veri yapısını ve veritabanı ilişkilerini temsil eder. **Entity Framework Core (Code First)** yaklaşımı kullanılmıştır.
* **Entities:** `TestModule`, `TestCase`, `AppUser` gibi veritabanı tablolarına karşılık gelen sınıflar.
* **Validations:** Veri tutarlılığını sağlamak için `[Required]`, `[StringLength]` gibi Data Annotation'lar kullanılmıştır.
* **Relationships:** Modüller ve Test Senaryoları arasında kurulan *One-to-Many* (Bire-Çok) ilişkiler burada tanımlanmıştır.

### 2. ⚙️ Controller (Yönetim ve Karar Mekanizması)
Kullanıcıdan gelen istekleri (Request) karşılar, gerekli iş mantığını çalıştırır ve uygun görünümü (View) seçer.
* **AccessController:** Güvenli giriş/çıkış işlemleri ve rol tabanlı yönlendirmeleri (Admin vs Member) yönetir.
* **TestModulesController:** Modül ekleme, silme ve güncelleme operasyonlarını (CRUD) yönetir.
* **Authorization:** `[Authorize(Roles = "Admin")]` gibi attribute'lar ile yetkisiz erişimler Controller seviyesinde engellenmiştir.

### 3. 🎨 View (Kullanıcı Arayüzü)
Kullanıcıya sunulan görsel katmandır. **Razor View Engine** kullanılarak dinamik HTML sayfaları oluşturulmuştur.
* **UI Design:** Bootstrap 5 kütüphanesi ile Responsive (Mobil Uyumlu) tasarım.
* **User Experience (UX):** Göz yormayan özel **Dark Mode** teması ve kullanıcı dostu form yapıları.
* **Partial Views:** Tekrar eden kodları önlemek için modüler görünüm parçacıkları.

---

## ✨ Öne Çıkan Özellikler

### 🔐 1. Rol Tabanlı Yetkilendirme (RBAC)
Sistemde güvenlik en üst düzeyde tutulmuş olup, kullanıcılar yetkilerine göre ayrıştırılmıştır:
- **Yönetici (Admin):**
    - Özel tasarım **"Kırmızı Güvenlik Paneli"** üzerinden giriş yapar.
    - Test senaryolarını **Silme, Düzenleme ve Ekleme** tam yetkisine sahiptir.
    - Sistemin genel durumunu grafiklerle analiz edebilir.
     - ![Yönetici Yetkinlikleri ](https://github.com/user-attachments/assets/b2fbde23-48ad-4893-b554-2838529a5188)

- **Standart Personel (Member):**
    - Sadece veri girişi ve görüntüleme yapabilir.
    - **Kritik verileri silme yetkisi yoktur** (Arayüzde silme butonları gizlenir).


### 📊 2. Dashboard ve Veri Görselleştirme
Yöneticiler için hazırlanan Dashboard ekranında, projedeki testlerin başarı/hata oranları (Pass/Fail) **dinamik pasta grafikleri** ile sunulmaktadır.
![Admin Dashboard](https://github.com/user-attachments/assets/0da59a8b-2e85-4ab5-a322-a9f7cf7cc7ea)

### 📗 3. Geleneksel Yöntemlerle Uyumluluk (Excel Entegrasyonu)
Alışkanlıklarından vazgeçemeyen veya raporlamayı Excel'de yapmak isteyen ekipler için veriler dışarı aktarılabilir yapıdadır.
- **Veri Özgürlüğü:** Modül ve Test verileri, analiz edilmek üzere Excel/CSV formatına uygun yapıdadır.
- **Hibrit Çalışma:** Hem modern web arayüzü hem de geleneksel raporlama araçları bir arada kullanılabilir.
![Excel Entegrasyonu](https://github.com/user-attachments/assets/06830ee6-9f91-4132-8bd5-ff861ddd88cb)

### 🛠️ 4. Gelişmiş Test Yönetimi
- Projelerin modüllere bölünerek yönetilmesi.
- İlişkisel veritabanı yapısı sayesinde veri bütünlüğünün korunması.
- Test durumlarının (Pass, Fail, Blocked) renk kodları ile görselleştirilmesi.

---

## 💻 Kullanılan Teknolojiler

| Alan | Teknoloji |
|------|-----------|
| **Backend Framework** | ASP.NET Core 8.0 MVC |
| **Veritabanı** | MS SQL Server |
| **ORM** | Entity Framework Core (Code First) |
| **Frontend** | HTML5, CSS3, Bootstrap 5, JavaScript |
| **Güvenlik** | ASP.NET Core Identity |
| **Versiyon Kontrol** | Git & GitHub |

---

## ⚙️ Kurulum Adımları

Projeyi kendi bilgisayarınızda çalıştırmak için:

1.  Repoyu klonlayın:
    ```bash
    git clone [https://github.com/giirgiinbeyza/QA-Master.git](https://github.com/giirgiinbeyza/QA-Master.git)
    ```
2.  Proje klasörüne gidin:
    ```bash
    cd QA-Master
    ```
3.  Veritabanını oluşturun (Migration):
    ```bash
    dotnet ef database update
    ```
4.  Projeyi başlatın:
    ```bash
    dotnet run
    ```

---

## 👤 Geliştirici

**Beyza Girgin**
*Yönetim Bilişim Sistemleri (YBS) 4. Sınıf Öğrencisi*
GitHub: [@giirgiinbeyza](https://github.com/giirgiinbeyza)

---
