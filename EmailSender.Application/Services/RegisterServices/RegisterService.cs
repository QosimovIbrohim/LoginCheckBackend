using EmailSender.Application.Abstractions.RepositoryInterfaces;
using EmailSender.Application.DTOs;
using EmailSender.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Net;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using Microsoft.Extensions.Configuration;

namespace EmailSender.Application.Services.RegisterServices
{
    public class RegisterService : IRegisterService
    {
        public IRegisterRepository _reg;
        public IConfiguration _config;


        public RegisterService(IRegisterRepository reg, IConfiguration config)
        {
            _reg = reg;
            _config = config;
        }

        public async Task<string> Create(UserDTO loginDTO)
        {
            if (!(await _reg.isExists(loginDTO)))
            {
                var emailSettings = _config.GetSection("EmailSettings");
                Random rnd = new Random();
                var model = new UserAuth()
                {
                    Email = loginDTO.Email,
                    Password = loginDTO.Password,
                    Code = rnd.Next(1000, 9999)
                };
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
                return await _reg.InsertAsync(model);
            }
            return "Mavjud ekan";
        }
        public async Task<IEnumerable<UserAuth>> GetAll()
        {
            return await _reg.GetAll();
        }
    }
}
