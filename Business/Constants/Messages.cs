using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Constants
{
    public static class Messages
    {
        public static string ProductAdded = "Ürün eklendi";

        public static string ProductNameInvalid = "Ürün ismi gecersiz";

        public static string MaintenanceTime = "Serverler bakımda";

        public static string ProductListed = "Ürünler listelendi";

        public static string ProductCountOfCategoryError = "Bir kategoride en fazla 10 urun ola bilir";

        public static string ProductNameAlreadyExists = "Boyle bir urun ismi var";

        public static string CategoryCountIsTooMuch = "Kategori limiti asildi";

        public static string AuthorizationDenied = "Yetkiniz yok";

        public static string UserRegistered = "Kullanici kayit oldu";

        public static string UserNotFound  = "Kullanici bulunamadi";

        public static string PasswordError = "Sifre hatali";

        public static string SuccessfulLogin = "Basarili giris";

        public static string UserAlreadyExists = "Kullanici mevcut";

        public static string AccessTokenCreated = " Tokeni olusturuldu";
    }
}
