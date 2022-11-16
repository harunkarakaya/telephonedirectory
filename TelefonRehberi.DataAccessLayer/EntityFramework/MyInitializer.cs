using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TelefonRehberi.Entities;

namespace TelefonRehberi.DataAccessLayer.EntityFramework
{
    public class MyInitializer : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {
            for (int i = 0; i < 6; i++)
            {
                Admin admin = new Admin
                {
                    KullaniciAdi = $"admin{i}",
                    Sifre = $"password{i}"
                };

                context.TblAdmin.Add(admin);
            }

            context.SaveChanges();

            for (int i = 0; i < FakeData.NumberData.GetNumber(5,7); i++)
            {
                Departman dept = new Departman()
                {
                    DepartmanAdi = FakeData.PlaceData.GetCity().ToString()
                };

                for (int j = 0; j < FakeData.NumberData.GetNumber(1,1); j++)
                {
                    Calisan yonetici = new Calisan()
                    {
                        Ad = FakeData.NameData.GetFirstName(),
                        Soyad = FakeData.NameData.GetSurname(),
                        TelefonNumarası = FakeData.PhoneNumberData.GetPhoneNumber(),
                        Yonetici = "Yönetici",
                        YoneticiMi = true
                    };

                    for (int k = 0; k < FakeData.NumberData.GetNumber(5,8); k++)
                    {
                        Calisan calisan = new Calisan()
                        {
                            Ad = FakeData.NameData.GetFirstName(),
                            Soyad = FakeData.NameData.GetSurname(),
                            TelefonNumarası = FakeData.PhoneNumberData.GetPhoneNumber(),
                            Yonetici = yonetici.Ad + " " + yonetici.Soyad,
                            YoneticiMi = false
                        };

                        dept.Calisan.Add(calisan);
                        context.TblCalisan.Add(calisan);
                    }

                    dept.Calisan.Add(yonetici);
                    context.TblCalisan.Add(yonetici);

                }
                context.TblDepartman.Add(dept);
            }
            context.SaveChanges();
            
        }
    }
}
