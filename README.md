# SismoTrack Console Application

Bu proje, USGS (United States Geological Survey) API'sinden deprem verilerini çeken bir C# konsol uygulamasıdır. Kullanıcıların belirli bir coğrafi konum etrafındaki son depremleri sorgulamalarını ve bu depremlerin detaylarını görmelerini sağlar.

## Özellikler

- Belirli bir coğrafi konuma (enlem ve boylam) göre depremleri sorgular.
- Her deprem için temel bilgileri (ID, büyüklük, yer, zaman) ve detaylı bilgileri (hissedilen seviye, CDI, MMI, tsunami bilgisi, önem derecesi) gösterir.

## Nasıl Çalışır

Uygulama, USGS'nin sağladığı bir API endpoint'ine HTTP GET isteği yapar ve JSON formatında deprem verilerini alır. Ardından, bu verileri parse eder ve kullanıcıya konsol üzerinden sunar.

## Kurulum

Bu projeyi kullanmadan önce bilgisayarınızda [.NET](https://dotnet.microsoft.com/download) yüklü olmalıdır.

1. Projeyi klonlayın veya indirin:

git clone https://github.com/yilmazeyup/sismo-track.git

2. Proje dizinine gidin:

cd sismo-track

## Kullanım

Uygulamayı çalıştırmak için aşağıdaki komutu kullanın:

dotnet run


Bu komut, belirtilen enlem ve boylam etrafındaki son 10 depremin temel ve detaylı bilgilerini konsol ekranında listeler.

## Katkıda Bulunmak

Katkıda bulunmak isteyenler için pull request'ler kabul edilir. Büyük değişiklikler için, lütfen önce neyi değiştirmek istediğinizi tartışmak üzere bir konu açınız.

## Lisans

Bu proje [MIT Lisansı](License) altındadır.
