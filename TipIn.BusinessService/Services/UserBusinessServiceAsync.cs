using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripIn.Core.Base.Services;
using TripIn.Core.Interfaces;
using TripIn.Core.Models;

namespace TipIn.BusinessService.Services
{
    public class UserBusinessServiceAsync : BusinessServiceAsync<User> , IUserBusinessServiceAsync
    {
        public UserBusinessServiceAsync() 
        {
        }
        public string GetFullName(User user)
        {
            return $"{user.FirstName} {user.LastName}";
        }
    }
}
