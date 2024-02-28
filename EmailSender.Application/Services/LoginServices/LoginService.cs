using EmailSender.Application.Abstractions.RepositoryInterfaces;
using EmailSender.Application.DTOs;
using EmailSender.Application.Services.RegisterServices;
using EmailSender.Domain.Entities.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Application.Services.LoginServices
{
    public class LoginService : ILoginService
    {
        public IRegisterRepository _reg;
        public IConfiguration _config;

        public LoginService(IRegisterRepository reg, IConfiguration config)
        {
            _reg = reg;
            _config = config;
        }
        public async Task<string> Login(LoginDTO us)
        {
            var x = await _reg.isExists(us);
            if (x != null)
            {
                if (x.Password == us.Password && x.Code == us.Code)
                {
                    var emailSettings = _config.GetSection("EmailSettings");
                    Random rnd = new Random();
                    var model = new UserAuth()
                    {
                        Email = us.Email,
                        Password = us.Password,
                        Code = rnd.Next(1000, 9999)
                    };
                    try
                    {
                        await _reg.UpdateAsync(us, model.Code);
                    }
                    catch
                    {
                        return "Qandaydir xatolik";
                    }
                    var mailMessage = new MailMessage
                    {
                        From = new MailAddress(emailSettings["Sender"], emailSettings["SenderName"]),
                        Subject = "Code",
                        Body = model.Code.ToString(),
                        IsBodyHtml = true,

                    };
                    mailMessage.To.Add(model.Email);

                    using var smtpClient = new SmtpClient(emailSettings["MailServer"], int.Parse(emailSettings["MailPort"]))
                    {
                        Port = Convert.ToInt32(emailSettings["MailPort"]),
                        DeliveryMethod = SmtpDeliveryMethod.Network,
                        Credentials = new NetworkCredential(emailSettings["Sender"], emailSettings["Password"]),
                        EnableSsl = true,
                    };
                    await smtpClient.SendMailAsync(mailMessage);
                    return "kirildi emailga yangi code jonatildi";

                }
                else if (x.Password != us.Password)
                {
                    return "Password xato";
                }
                else if (x.Code != us.Code)
                {
                    return "Code xato emailni tekshiring";
                }
                else
                {
                    return "2 lasiyam xato";
                }
            }
            return "topilmadi";
        }
    }
}
