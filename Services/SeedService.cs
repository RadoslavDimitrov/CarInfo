using CarInfo.Data;
using Data.Data.Infrastructure;
using Data.Data.Models;
using System;

namespace CarInfo.Services
{
    public class SeedService : ISeedService
    {
        private readonly ApplicationDbContext dbContext;
        public SeedService(ApplicationDbContext db)
        {
            this.dbContext = db;
        }
        public bool Seed()
        {
            if (dbContext.Parts.Any())
            {
                return true;
            }

            var part = new Parts("tanpon", "44567");
            var car = new Car(Guid.NewGuid().ToString(), "honda", "1GNEK13ZX3R298984", "civic", 1999, 200000, "0888123456", "gosho");
            var shop = new CarRepairShop("emkomplekt", "drujba", "hubav serviz", "0877123456");
            var repair = new Repair(car.Id, shop.Id, "smeneni chasti", RepairStatusEnum.Pending.ToString());

            repair.PartsChanged.Add(part);

            dbContext.Parts.Add(part);
            dbContext.Cars.Add(car);
            dbContext.CarRepairShops.Add(shop);
            dbContext.Repairs.Add(repair);

            dbContext.SaveChanges();

            var currrepairs = shop.PendingRepairs.ToList();

            return false;
        }
    }
}
