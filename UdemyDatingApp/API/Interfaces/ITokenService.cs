using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UdemyDatingApp.Entities;

namespace UdemyDatingApp.API.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(User user);
    }
}
