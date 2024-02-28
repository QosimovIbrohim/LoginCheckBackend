﻿using EmailSender.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmailSender.Application.Services.LoginServices
{
    public interface ILoginService
    {
        public Task<string> Login(LoginDTO us);
    }
}
