﻿using System;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;

namespace Authentication.API2.Infrastructure.Services
{
  public class SmsService : IIdentityMessageService
  {
    public Task SendAsync(IdentityMessage message)
    {
      // Plug in your SMS service here to send a text message.
      return Task.FromResult(0);
    }
  }
}