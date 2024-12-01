using System.Diagnostics;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using MVC_Session.Models;
using Newtonsoft.Json;

namespace MVC_Session.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {

        // Session uygulamalarda sıklıkla kullanılan bir yöntemdir!!

        // Session içerisine key value olarak değer alır!!

        // Session içerisine aldığı verileri, RAM'de tutar, Session verileri geçiçi olarak tutacaktır

        // Uygulama kapatıldığında, session verileri yok olur!! Onun için sesssion cookie gibi kalıcı değildir!!


        // Session, verileri transfer etmek için kullanılır!!

        SessionModel model = new SessionModel();
        model.Email = "emrahelis@gmail.com";
        model.Password = "1010";
        // Session'a değer atayalım!!

        // HttpContext, web uygulamasına dair bir çok veri taşır!!
        // Örnek : Web'e giren kullanıcının ip numarası vb.
        // 

        // Setstring metodu ile, session'a bir değer gönderebilirsiniz

        // Session key value olara çalışır!!

        HttpContext.Session.SetString("Email", model.Email);
        HttpContext.Session.SetString("Password", model.Password);

        // eğer session içerisine bir tip koymak isterseniz
        // json olarak koyabilirsiniz!!

        // bir .net sınıfın, json'a çevirmek için bir paketten faydalanabiliriz!!

        // json ile çalışmak için, nuget.org'dan newtonsoft json paketini indirebilirsiniz

        // paketin adı : dotnet add package Newtonsoft.Json --version 13.0.3

        // yukarıdaki komutu, terminal ekranına yazdığınızda, artık newtonsoft'u kullanabilirsiniz

        // json'a çevirmek için student nesnemi örnekliyorum

        Student student = new Student()
        {
            Age = 13,
            LastName = "Dinç",
            Name = "Oğuz"
        };

        // Student tipini json'a çevirelim 
        var studentJson = JsonConvert.SerializeObject(student);

        // bu veriyide session'a atalım 
        HttpContext.Session.SetString("OgrenciJson",studentJson);
        // veriler session'a doldururuldu!!


        return View();
    }

    public IActionResult Privacy()
    {

        // Session verilerini okuyalım!!

        var email = HttpContext.Session.GetString("Email");
        var password = HttpContext.Session.GetString("Password");


        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
