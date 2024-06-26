using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using StokTakip.Models;

namespace StokTakip.Classes
{
    internal class SifreMail
    {
        StokOtomasyonDbEntities db = new StokOtomasyonDbEntities();
        public void Microsoft(string GondericiAdSoyad, string GondericiMail, string GondericiPass, int AliciId, string AliciMail)
        {
            PersonelTB p = db.PersonelTB.FirstOrDefault(x => x.P_Mail == AliciMail && x.P_Id == AliciId);
            try
            {
                Random rnd = new Random();
                p.P_Sifre = rnd.Next(100000, 1000000).ToString();
                db.SaveChanges();
                SmtpClient sc = new SmtpClient();
                sc.Port = 587;
                sc.Host = "smtp.gmail.com";
                sc.EnableSsl = false;
                sc.Credentials = new NetworkCredential(GondericiMail, GondericiPass);

                MailMessage mail = new MailMessage();
                mail.From = new MailAddress(GondericiMail, "Şifre sıfırlama maili.");
                mail.To.Add(AliciMail);
                mail.Subject = "Sifre sıfırlama talebinde bulundunuz.";
                mail.IsBodyHtml = true;
                mail.Body = $@"Merhaba {GondericiAdSoyad}; {DateTime.Now.ToString()} tarihinde şifre sıfırlama talebinde bulundunuz. Yeni şifreniz: {p.P_Sifre} olarak güncellendi.";
                //sc.Timeout = 100;

                sc.Send(mail);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
