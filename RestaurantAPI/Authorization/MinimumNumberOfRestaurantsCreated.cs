using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Authorization
{
    public class MinimumNumberOfRestaurantsCreated : IAuthorizationRequirement
    {
        public int MinimumNumber { get; }

        public MinimumNumberOfRestaurantsCreated(int minimumNumber)
        {
            MinimumNumber = minimumNumber;
        }
    }
}
