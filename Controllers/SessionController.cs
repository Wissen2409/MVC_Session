using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

public class SessionController:Controller{



    public IActionResult GetSession(){


        // home controller içerisinde atmış olduğumuz session'lara başka bir kontrolleerda da erişebiliriz

        var email = HttpContext.Session.GetString("Email");
        var password = HttpContext.Session.GetString("Password");

        // Session içerisinde bir tip koymak isterseniz,Json'dan faydalanabilirsiniz!!

        // bir .net sınıfını, json tipine çevirdiğinizde, geriye string bir dönüş alırsınız!!

        // dönen string'i, session içerisine yerleştirebilirsiniz!!


        // Ödev : Bilgisayarınıza redis kurup, mvc ile redis'i entegre edip session verisini redis'e basınız!!


        // Home Controllerda, ogrenci nesnesini json'a çevirip, session' atmıştık!!

        // burada, o nesnesi session'dan geri alalım 

       string ogrenciJson = HttpContext.Session.GetString("OgrenciJson");

       // json olarak ogrenci nesnesini session'dan aldık!!. Şimdi json'ı ogrenci tipine çevirelim!!

       Student student =  JsonConvert.DeserializeObject<Student>(ogrenciJson);


        return View();
    }

}