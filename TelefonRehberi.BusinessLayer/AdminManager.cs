using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.BusinessLayer.Results;
using TelefonRehberi.DataAccessLayer.EntityFramework;
using TelefonRehberi.Entities;
using TelefonRehberi.Entities.Messages;
using TelefonRehberi.Entities.ViewModel;

namespace TelefonRehberi.BusinessLayer
{
    public class AdminManager : BaseManager<Admin>
    {
        public BusinessLayerResult<Admin> AdminGiris(LoginViewModel data)
        {
            BusinessLayerResult<Admin> res = new BusinessLayerResult<Admin>();

            res.Result = Find(x => x.KullaniciAdi == data.KullanıcıAdı && x.Sifre == data.Sifre);

            if (res.Result == null)
            {
                res.ErrorAdd(ErrorMessageCode.KullanıcıAdıveSifreEslesmiyor, "Kullanıcı adı ve şifre eşleşmiyor");
            }

            return res;
        }

        public BusinessLayerResult<Admin> AdminUpdate(Admin data)
        {
            
            BusinessLayerResult<Admin> res = new BusinessLayerResult<Admin>();
            Admin db_admin = Find(x => x.KullaniciAdi == data.KullaniciAdi);


            if(db_admin != null && db_admin.ID != data.ID)
            {
                if(db_admin.KullaniciAdi == data.KullaniciAdi)
                {
                    res.ErrorAdd(ErrorMessageCode.BöyleBirAdminAdıKayitli, "Böyle bir admin adı kayıtlıdır");
                }

                return res;
            }

            res.Result = Find(x => x.ID == data.ID);
            res.Result.KullaniciAdi = data.KullaniciAdi;
            res.Result.Sifre = data.Sifre;  

            if(Update(res.Result) == 0)
            {
                res.ErrorAdd(ErrorMessageCode.BilgilerUpdateEdilemedi, "Bilgiler güncellenemedi.");
            }

            return res;
        }
    }  
}
