using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TelefonRehberi.Entities
{
    [Table("TblCalisan")]
    public class Calisan
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DisplayName("Ad"),
            Required(ErrorMessage ="{0} alanı gereklidir."),
            StringLength(40,ErrorMessage ="{0} alanı max. {1} karakter olmalıdır.")]
        public string Ad { get; set; }

        [DisplayName("Soyad"),
            Required(ErrorMessage ="{0} alanı gereklidir."),
            StringLength(50, ErrorMessage = "{0} alanı max. {1} karakter olmalıdır.")]
        public string Soyad { get; set; }
         
        [DisplayName("Telefon Numarası"),
            Required(ErrorMessage = "{0} alanı gereklidir.")]
        public string TelefonNumarası { get; set; }

        public int DepartmanId { get; set; }

        public Departman Departman { get; set; }

        public bool YoneticiMi { get; set; }

        [DisplayName("Yönetici Bilgisi")]
        public string Yonetici { get; set; }

    }
}
