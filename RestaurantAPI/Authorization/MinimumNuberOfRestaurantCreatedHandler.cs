using Microsoft.AspNetCore.Authorization;
using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI.Authorization
{
    public class MinimumNuberOfRestaurantCreatedHandler : AuthorizationHandler<MinimumNumberOfRestaurantsCreated>
    {
        private readonly RestaurantDbContext _restaurantDbContext;

        public MinimumNuberOfRestaurantCreatedHandler(RestaurantDbContext restaurantDbContext)
        {
            _restaurantDbContext = restaurantDbContext;
        }

        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumNumberOfRestaurantsCreated requirement)
        {
            var userId = int.Parse(context.User.FindFirst(i => i.Type == ClaimTypes.NameIdentifier).Value);

            var number = _restaurantDbContext.Restaurants.Count(r => r.CreatedById == userId);

            if(number >= requirement.MinimumNumber)
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
