# eCommerce

Proje Açıklaması: Bu proje, Angular ve ASP.NET Core teknolojileri kullanılarak geliştirilmiş bir e-ticaret platformudur. Aşağıda, projede kullanılan teknolojiler, metotlar ve geliştirilen özellikler hakkında genel bilgiler bulunmaktadır.

## Kullanılan Teknolojiler

- **Angular ile Zengin Kullanıcı Arayüzü Tasarımı:** Kullanıcı arayüzü Angular framework'ü kullanılarak geliştirilmiş, etkileşimli ve kullanıcı dostu tasarımlara sahiptir.

- **ASP.NET Core ile Güçlü Backend Servisleri:** Güçlü ve güvenilir backend servisleri ASP.NET Core kullanılarak oluşturulmuştur.

- **AutoMapper ile Veri Transferi Kolaylığı:** AutoMapper, nesne-mapper olarak kullanılarak veri transferi işlemleri kolay ve hızlı bir şekilde gerçekleştirilmiştir.

- **JWT ile Güvenli Kimlik Doğrulama ve Yetkilendirme:** JSON Web Token (JWT) kullanılarak güvenli kimlik doğrulama ve yetkilendirme sağlanmıştır.

## Kullanılan Metotlar

- **FluentValidation ile Giriş ve Kayıt Validasyonları:** Giriş ve kayıt işlemleri için FluentValidation kullanılarak güvenli ve doğruluk kontrolleri yapılmıştır.

- **Swagger API Belgeleri:** API'lar, Swagger API belgeleri ile belgelendirilmiş ve test edilebilir hale getirilmiştir.

- **Kullanıcı Dostu Bildirimler:** SweetAlert ve PrimeNG MessageService kullanılarak kullanıcı dostu bildirimler sağlanmıştır.

- **Modern Arayüz Tasarımı:** Bootstrap ve CSS ile modern ve kullanıcı dostu arayüz tasarımı gerçekleştirilmiştir.

## Geliştirilen Özellikler

- **Sepet Yönetimi ve Ödeme İşlemleri:** Shopping cart servisleri sayesinde kullanıcılar, sepet yönetimi ve ödeme işlemlerini kolayca gerçekleştirebilirler.

- **Güvenli Authentication:** Kullanıcı girişi ve kaydı için güvenli authentication sistemi uygulanmıştır.

- **Sipariş Geçmişi ve Takip:** Kullanıcılar, geçmiş siparişlerini görüntüleyebilir ve takip edebilirler.

- **Ürün Listeleme ve Detaylı Bilgiler:** Kullanıcılar, platformda bulunan ürünleri listeleyebilir ve detaylı bilgilerini inceleyebilirler.

## Kurulum

Projeyi yerel ortamınıza kurmak için şu adımları takip edebilirsiniz:

1. [Angular CLI](https://cli.angular.io/) ve [ASP.NET Core SDK](https://dotnet.microsoft.com/download) kurulumlarını gerçekleştirin.
2. Repoyu klonlayın: `git clone https://github.com/kullanici/proje.git`
3. Frontend ve backend klasörlerine giderek gerekli bağımlılıkları yükleyin:
    ```
    cd frontend
    npm install
    ```
    ```
    cd backend
    dotnet restore
    ```

## Kullanım

Projeyi başlatmak için aşağıdaki adımları takip edebilirsiniz:

1. Frontend uygulamasını başlatın:
    ```
    cd frontend
    ng serve
    ```

2. Backend uygulamasını başlatın:
    ```
    cd backend
    dotnet run
    ```

Uygulama varsayılan olarak `http://localhost:4200/` adresinde çalışacaktır.
