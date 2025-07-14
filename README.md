# 📢 AdvertisementApp – ASP.NET Core MVC | N-Tier Architecture | Repository Pattern


Bu proje, bir yazılım şirketinin web sitesi için hazırlanmış, N Katmanlı Mimari prensiplerine uygun şekilde geliştirilmiş bir ASP.NET Core MVC uygulamasıdır. Proje, kullanıcıların sistem üzerinden iş ilanlarını görüntüleyip başvurabildiği; admin panelinden ise ilanların yönetilebildiği bir insan kaynakları modülünü içermektedir.



# 🔧 Kullanılan Teknolojiler ve Mimariler

- ASP.NET Core MVC
- Entity Framework Core
- N-Tier Architecture (Entities, Common, DTOs, DAL, Business, UI)
- Repository & Unit of Work Design Pattern
- Dependency Injection
- FluentValidation
- AutoMapper



# 🗂️ Katmanlar ve Sorumlulukları

📁 AdvertisementApp2.Entities
Veritabanı tablolarını temsil eden Entity sınıflarının bulunduğu katmandır.

📁 AdvertisementApp2.Common
Katmanlar arası ortak kullanılan yardımcı sınıfların ve enum'ların yer aldığı katmandır (örneğin Response, IResponse, CustomValidationError vs.).

📁 AdvertisementApp2.Dtos
Kullanıcıya ya da servislere veri taşımak amacıyla kullanılan DTO sınıflarını içerir.

📁 AdvertisementApp2.DAL
Veri erişim katmanıdır. Repository’ler, DbContext, UnitOfWork gibi yapıların bulunduğu kısımdır.

📁 AdvertisementApp2.Business
İş mantığının yer aldığı katmandır. Servisler, Validasyon Kuralları, AutoMapper profilleri burada yer alır.

📁 AdvertisementApp2.UI
Kullanıcı arayüzünün bulunduğu katmandır. MVC yapısına uygun olarak Controller, View ve Model klasörleri içerir.



# 👤 Kullanıcı Rollerine Göre Özellikler

✅ Ziyaretçi (Login Olmamış Kullanıcı)
- İş ilanlarını sadece görüntüleyebilir.
- Başvuru yapmak için sisteme kayıt olup giriş yapmalıdır.

✅ Üye (Login Olmuş Kullanıcı)
- Sisteme giriş yaparak aktif iş ilanlarına başvuru yapabilir.

✅ Admin
- Yeni iş ilanı ekleyebilir.
- Mevcut ilanları düzenleyebilir veya silebilir.
- Kullanıcı başvurularını inceleyebilir.

# 🔐 Kimlik Doğrulama ve Yetkilendirme
- Role-based authorization sistemi kullanılmıştır.
- Admin ve User rollerine göre erişim kontrolü yapılmaktadır.

# 📬 İletişim
👤 Geliştirici: Emir Ali Girgin
🔗 LinkedIn: https://www.linkedin.com/in/emir-ali-girgin-a190b1201/
💻 GitHub: https://github.com/eag29



