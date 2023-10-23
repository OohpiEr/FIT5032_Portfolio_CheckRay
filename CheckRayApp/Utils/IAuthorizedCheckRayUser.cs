using CheckRayApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckRayApp.Utils
{
    internal interface IAuthorizedCheckRayUser
    {
        User GetCurrentUser();
    }
}
