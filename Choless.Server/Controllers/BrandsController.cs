using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Choless.Core.Brands;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Choless.Server.Controllers
{
    public class BrandsController : Controller
    {
        BrandManager brandManager;
        // GET: /<controller>/
        public IActionResult Index()
        {
            // Creates the database if not exists
            brandManager.Database.EnsureCreated();

            var scope = new BusinessScope { CommodityClass = "Information Platform" };
            var brand = new Brand
            {
                BrandId = "00000000000000000000000000000001",
                BrandName = "Choless",
                BusinessScopes = new BusinessScope[] { scope },
                WebSite = "www.choless.com",
                Headquarters = new Headquarters
                {
                    HeadquartersId = "headquarters id",
                    Country = "China",
                    Province = "Shanghai",
                    City = "Shanghai",
                    Address = "No. 800 Dongchuan Road"
                },
                EstablishedTime = new DateTime(2018, 3, 30),
                Description = "A company to make less choices."
            };
            scope.Brand = brand;

            brandManager.Brands.Add(brand);
            brandManager.SaveChanges();

            return View();
        }


        public BrandsController(BrandManager manager)
        {
            brandManager = manager;
        }
    }
}
