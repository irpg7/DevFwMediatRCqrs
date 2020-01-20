DevFramework CQRS ve Mediatr
•	DataAccess

  	RepositoryPattern kullanılmaya devam edilecek. Klasör yapıları abstract ve concrete olarak kalabilir.
    
  	Context singleton pattern’de mi yoksa mevcut halinde mi kullanılmalı testler sonucunda belirlenmeli. 
    
  	Get operasyonları Repository’de Queryable olarak tanımlanabilir. Böylece ileri de doğabilecek olan IQueryableRepository ihtiyacı da         ortadan kalkmış olur. Get ve GetAll işlemlerinin yanı sıra da eklenebilir.

•	Business
 	 Abstract ve Concrete klasörleri,  Commands ve Queries olarak ikiye ayrılabilir. Daha sonra altlarında ilgili nesneler klasörlenebilir ve    kaynak yönetimi böyle gerçekleştirilebilir. Yada Direkt olarak ilgili Entity’nin Adı kök klasör olarak verilip, daha sonra altında          Commands ve Queries olarak ayrıştırılabilir.(Bu daha iyi olur okunurluk açısından.) Command ve Queryler MediatR kütüphanesinde bulunan      IRequest’den implemente edilir.
   
   Commandlar veya Querylerde filtreme yapılmak istendiğinde ilgili Command veya Query class’ı içine property tanımlanarak yapılabilir.
   
   Command veya Query handlerlar yine aynı classlar içerisinde gerçekleştirilebilir. Handler’ı Command class’ın bir child class’ı haline      getirerek kullanmak uygundur. Mevcut kodun bir parçası ve işlem yapılan nesneye ait olması gerekçesiyle Solid’in S harfini ihlal            etmemektedir. Dikkat edilmesi gereken husus her class’ın, method’ un kendi işini yapıyor olmasıdır.
   
   IRequestHandler iki parametre almaktadır. Birincisi yapılmak istenen işleme ait Class(IRequest implementasyonu olan Command veya Query      Class ı), diğeri ise return edilecek nesnenin tipidir. Sadece Command da verilebilir. Ancak bu durumda Handle methodu Unit.Value            dönmelidir.
   
   Aspectler Handlerlarda bulunan Handle methodu üzerinde kullanılabilir.(Deneme yapmadım. Değişebilir.)

Kaynaklar ;
https://medium.com/@ducmeit/net-core-using-cqrs-pattern-with-mediatr-part-1-55557e90931b
https://medium.com/@dmytrohridin/why-you-need-to-try-mediatr-library-on-your-net-project-653165735c36
https://github.com/JasonGT/CleanArchitecture  CQRS ve MediatR’e ait yapı incelendi.
