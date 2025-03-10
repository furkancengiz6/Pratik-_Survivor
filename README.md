# Survivor API

Bu proje, Survivor yarışması için bir Web API uygulamasıdır. Yarışmacılar ve kategoriler arasında bir ilişki içerir ve bu ilişkilerle ilgili CRUD (Create, Read, Update, Delete) işlemlerini gerçekleştiren API endpointleri sunar.

## Teknolojiler

* ASP.NET Core Web API
* Entity Framework Core
* SQL Server (veya tercih ettiğiniz veritabanı)
* Visual Studio 2022

## Kurulum

1.  Bu projeyi GitHub'dan klonlayın:

    ```bash
    git clone [repo_url]
    ```

2.  Visual Studio 2022'yi açın ve projeyi yükleyin.
3.  `appsettings.json` dosyasındaki `ConnectionStrings` bölümünü veritabanı ayarlarınıza göre düzenleyin.
4.  NuGet paketlerini yükleyin:

    * `Microsoft.EntityFrameworkCore.SqlServer` (veya tercih ettiğiniz veritabanı paketi)
    * `Microsoft.EntityFrameworkCore.Tools`
    * `Microsoft.AspNetCore.Mvc.NewtonsoftJson`

5.  Veritabanı migrasyonlarını çalıştırın:

    * Paket Yöneticisi Konsolu'nu açın.
    * Aşağıdaki komutları çalıştırın:

        ```bash
        Add-Migration InitialCreate
        Update-Database
        ```

6.  Projeyi çalıştırın.

## Kullanım

API endpointlerine Swagger veya Postman gibi bir araç kullanarak erişebilirsiniz.

### Endpointler

#### CompetitorController

* `GET /api/competitors`: Tüm yarışmacıları listeler.
* `GET /api/competitors/{id}`: Belirli bir yarışmacıyı getirir.
* `GET /api/competitors/categories/{categoryId}`: Kategori ID'sine göre yarışmacıları getirir.
* `POST /api/competitors`: Yeni bir yarışmacı oluşturur.
* `PUT /api/competitors/{id}`: Belirli bir yarışmacıyı günceller.
* `DELETE /api/competitors/{id}`: Belirli bir yarışmacıyı siler.

#### CategoryController

* `GET /api/categories`: Tüm kategorileri listeler.
* `GET /api/categories/{id}`: Belirli bir kategoriyi getirir.
* `POST /api/categories`: Yeni bir kategori oluşturur.
* `PUT /api/categories/{id}`: Belirli bir kategoriyi günceller.
* `DELETE /api/categories/{id}`: Belirli bir kategoriyi siler.

## Katkıda Bulunma

Katkılarınızı bekliyoruz! Lütfen bir "pull request" göndererek değişikliklerinizi önerin.

## Lisans

Bu proje MIT lisansı altında lisanslanmıştır.
