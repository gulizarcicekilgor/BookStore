 dotnet add package Microsoft.EntityFrameworkCore --version 7.0.0
 
 dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 7.0.0

#-----Auto mapper------
 dotnet add package AutoMapper --version 7.0.1
 
 #controllerın constractutuna injection geçebilmek içim
 
 dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 7.0.0

 ---Fluent Validation---------------
 
 dotnet add package FluentValidation --version 7.0.0
 
 dotnet add package Newtonsoft.Json
 
----Projeye DI Container Kullanarak Logger Servis Eklemek

builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();

![Alt text](WebApi/image/image-6.png)

builder.Services.AddSingleton<ILoggerService, DBLooger>();

![Alt text](WebApi/image/image-7.png)



ÖDEV - Projeye Author Controller ve Servislerin Eklenmesi
Yazar Ekleme

![Alt text](WebApi/image/image-14.png)

![Alt text](WebApi/image/image-15.png)

Yazar Bilgileri Güncelleme

![Alt text](WebApi/image/image-16.png)

![Alt text](WebApi/image/image-17.png)

Yazar Silme
"Kitabı yayında olan bir yazar silinememeli. Öncelikle kitap silinmeli, daha sonra yazar silinebilir."
1 idli yazar kitapla eşleştiği için silinemiyor.

![Alt text](WebApi/image/image-22.png)

![Alt text](WebApi/image/image-21.png)



Tüm Yazarları Listeleme

![Alt text](WebApi/image/image-19.png)

Spesifik Bir Yazarın Bilgilerini Getirme

![Alt text](WebApi/image/image-20.png)

dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer --version 7.0.0

![Alt text](WebApi/image/image.png)



