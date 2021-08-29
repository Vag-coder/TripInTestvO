using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TripIn.Core.Models;

namespace TripIn.Core.Interfaces
{
    public interface IUserBusinessServiceAsync : IBusinessServiceAsync<User>
    {
        string GetFullName(User user);
    }
}
