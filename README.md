 dotnet add package Microsoft.EntityFrameworkCore --version 7.0.0

 
 dotnet add package Microsoft.EntityFrameworkCore.InMemory --version 7.0.0


#-----Auto mapper------
 dotnet add package AutoMapper --version 7.0.1
 #controllerın constractutuna injection geçebilmek içim
 dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection --version 7.0.0

 ---Fluent Validation---------------
 dotnet add package FluentValidation --version 7.0.0
 
 Post
 ![Alt text](image.png)
 Delete
 ![Alt text](image-1.png)
 GetbyId
 ![Alt text](image-2.png)
 Put (update)
 ![Alt text](image-3.png)

 ----Request Loglama---------------

 ![Alt text](image-4.png)

 dotnet add package Newtonsoft.Json
![Alt text](image-5.png)


----Projeye DI Container Kullanarak Logger Servis Eklemek
builder.Services.AddSingleton<ILoggerService, ConsoleLogger>();

![Alt text](image-6.png)

builder.Services.AddSingleton<ILoggerService, DBLooger>();

![Alt text](image-7.png)



ÖDEV - Projeye Author Controller ve Servislerin Eklenmesi
Yazar Ekleme
![Alt text](image-10.png)
![Alt text](image-11.png)

Yazar Bilgileri Güncelleme

![Alt text](image-12.png)

![Alt text](image-13.png)
Yazar Silme

Tüm Yazarları Listeleme

![Alt text](image-8.png)

Spesifik Bir Yazarın Bilgilerini Getirme

![Alt text](image-9.png)

