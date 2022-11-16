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
    [Table("TblDepartman")]
    public class Departman
    {
        //Birincil anahtar , Otomatik artan
        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        //Doldurulması zorunlu, karakter boyutu
        [DisplayName("Departman Adı"),
            Required(ErrorMessage ="{0} alanı gereklidir."),
            StringLength(50,ErrorMessage ="{0} alanı max. {1} karakter olmalıdır.")]
        public string DepartmanAdi { get; set; } 

        public List<Calisan> Calisan { get; set; }

        public Departman()
        {
            Calisan = new List<Calisan>();
        }
    }
}
