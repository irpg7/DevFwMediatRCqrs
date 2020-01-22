using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string UserCreated => "Kullanıcı Başarıyla oluşturuldu.";

        public static string ProductDeleted => "Ürün Başarıyla Silindi.";
        public static string ProductAdded => "Ürün Başarıyla Eklendi.";
        public static string ProductUpdated => "Ürün Başarıyla Güncellendi.";

        public static string UserExists => "Bu İsimde Kullanıcı mevcut.";

        public static string UserNotFound => "Kullanıcı bulunamadı.";

        public static string WrongPassword => "Şifre Hatalı";

        public static string SuccessfulLogin => "Sisteme Giriş Başarılı";
    }
}
