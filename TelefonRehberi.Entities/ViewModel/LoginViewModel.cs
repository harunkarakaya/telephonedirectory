using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TelefonRehberi.Entities.ViewModel
{
    public class LoginViewModel
    {
        [DisplayName("Kullanıcı Adı"),
            Required(ErrorMessage ="{0} kısmı boş geçilemez"),
            StringLength(20,ErrorMessage ="{0} kısmı max. {1} karakter olmalıdır.")]
        public string KullanıcıAdı { get; set; }

        [DisplayName("Şifre"),
            Required(ErrorMessage = "{0} kısmı boş geçilemez"),
            StringLength(15, ErrorMessage = "{0} kısmı max. {1} karakter olmalıdır."),
            DataType(DataType.Password)]
        public string Sifre { get; set; }
    }
}