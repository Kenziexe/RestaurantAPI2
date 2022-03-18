using RestaurantAPI.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantAPI
{
    public class RestaurantSeeder
    {
        private readonly RestaurantDbContext _context;

        public RestaurantSeeder(RestaurantDbContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if(_context.Database.CanConnect())
            {
                if(!_context.Roles.Any())
                {
                    var roles = GetRoles();
                    _context.Roles.AddRange(roles);
                    _context.SaveChanges();
                }

                if(!_context.Restaurants.Any())
                {
                    var restaurants = GetRestaurants();
                    _context.Restaurants.AddRange(restaurants);
                    _context.SaveChanges();
                }
            }
        }

        private IEnumerable<Role> GetRoles()
        {
            var roles = new List<Role>()
            {
                new Role()
                {
                    Name = "User"
                },
                new Role()
                {
                    Name = "Manager"
                },
                new Role()
                {
                    Name = "Admin"
                },
            };
            return roles;
        }

        private IEnumerable<Restaurant> GetRestaurants()
        {
            var restaurants = new List<Restaurant>()
            {
                new Restaurant()
                {
                    Name = "KFC",
                    Category = "Fast Food",
                    Description = "KFC is an American fast food restaurant chain headquartered in Louisville, Kentucky that specializes in fried chicken. It is the world's second-largest restaurant chain after McDonald's, with 22,621 locations globally in 150 countries as of December 2019.",
                    ContactEmail = "contact@kfc.com",
                    HasDelivery = false, 

                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Nashville Hot Chicken",
                            Price = 10.30M,
                        },

                        new Dish()
                        {
                            Name = "Chicken Nuggets",
                            Price = 5.30M,
                        },
                    },

                    Address = new Address()
                    {
                        City = "Kraków", 
                        Street = "Długa 5",
                        PostalCode = "30-001"
                    }
                }, 
                new Restaurant()
                {
                    Name = "McDonald's",
                    Category = "Fast Food",
                    Description = "McDonald's is an American multinational fast food corporation, founded in 1940 as a restaurant operated by Richard and Maurice McDonald, in San Bernardino, California, United States.",
                    ContactEmail = "contact@mcdonalds.com",
                    HasDelivery=false,

                    Dishes = new List<Dish>()
                    {
                        new Dish()
                        {
                            Name = "Big Mac",
                            Price = 4.30M,
                        }, 

                        new Dish()
                        {
                            Name = "Cheeseburger",
                            Price = 1.2M,
                        }
                    }, 

                    Address = new Address()
                    {
                        City = "Gdańsk",
                        Street = "Długa 22",
                        PostalCode = "22-111",
                    }
                }
            };

            return restaurants;
        }
    }
}
