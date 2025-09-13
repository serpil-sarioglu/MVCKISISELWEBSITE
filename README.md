Tanıtım:

ASP.NET Core Web App(MVC) projesi.
Entity Framework Core kullanıldı.
(Code First From Database Yöntemi kullanıldı. Bu yöntemle Scaffold-DbContext komutunu kullanarak var olan veri tabanından DbContext ve ilişkili model sınıfları otomatik oluşur. )
Kurulan paketler:
 Microsoft.EntityFrameworkCore.SqlServer
 Microsoft.EntityFrameworkCore.Design
 Microsoft.EntityFrameworkCore.Tools
PM Console da yazılan komut:
Scaffold-DbContext "data source=.;initial catalog=KISISELWEBSITE;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework;TrustServerCertificate=true" Microsoft.EntityFrameworkCore.SqlServer -OutputDir DAL

Ana sayfada slider, çalışma alanları, videolar listelerinin olduğu view model kullanılıyor. Ana sayfada TruncateTagHelper kullanılarak çalışma alanlarını gösteren içerik metni kısaltıldı. 
Çalışma alanları sayfasında viewbag kullanılarak içerik,başlık listelendi.  
Makaleler sayfasında viewcomponent ile yayımlanan makaleler listeleniyor. Makale detaylarında makalelerin like-dislike ikonu ile beğeni sayısı takip edilir. 
İletişim sayfasında form alanında post metotlu mesaj actionı çalışır form bilgileri veritabanına kaydedilir.

Kişisel Blog Web Sitesi sayfaları:

Ana Sayfa
 
<img width="948" height="615" alt="image" src="https://github.com/user-attachments/assets/7c24795f-76ae-4e04-8c8f-bee657edb27a" />

Hakkımızda

<img width="672" height="357" alt="image" src="https://github.com/user-attachments/assets/04cbcd14-5aab-4387-b585-9bf7741bc6a9" />
 
Çalışma Alanları

 <img width="678" height="360" alt="image" src="https://github.com/user-attachments/assets/c6d420fc-2e53-4212-8d98-889478adee51" />

Makaleler

 <img width="679" height="361" alt="image" src="https://github.com/user-attachments/assets/43922eed-08f4-4549-89dd-b98c2e2c463f" />

Kadromuz

 <img width="681" height="411" alt="image" src="https://github.com/user-attachments/assets/0bc355be-44e5-43c9-ad67-47d444c9cc5d" />
 
İletişim

 <img width="684" height="363" alt="image" src="https://github.com/user-attachments/assets/78d82989-812a-4f82-b4ef-35723d7f8863" />





