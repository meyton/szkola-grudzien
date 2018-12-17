﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Szkola.Services.Interfaces
{
    public interface IHttpService
    {
        Task<GetResponse> Authorize(string username, string password);
        Task<GetResponse> AccessToken(string code);
    }
}
