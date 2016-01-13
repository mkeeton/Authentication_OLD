﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Authentication.Domain.Models;

namespace Authentication.Infrastructure.Interfaces
{
  public interface IUserRepository : IRepository, IUserStore<User, Guid>
  {

  }
}