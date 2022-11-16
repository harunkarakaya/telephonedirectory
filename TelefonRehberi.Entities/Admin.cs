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
    [Table("TblAdmin")]
    public class Admin
    {

        [Key,DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }

        [DisplayName("Kullanıcı Adı"),Required,StringLength(20)]
        public string KullaniciAdi { get; set; }

        [DisplayName("Şifre"),Required,StringLength(15)]
        public string Sifre { get; set; }

    }
}
