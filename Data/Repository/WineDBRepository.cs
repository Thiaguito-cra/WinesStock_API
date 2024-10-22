using Data.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Data.Repository
{
    public class WineDBRepository : IWineDBRepository
    {
        private readonly ApplicationContext _context;

        public WineDBRepository(ApplicationContext context)
        {
            _context = context;
        }

        public List<Wine> GetWines()
        {
            return _context.Wine.ToList(); 
        }

        public void AddWine(Wine wine)
        {
            _context.Wine.Add(wine);
            _context.SaveChanges(); 
        }

        public Wine? Get(int id)
        {
            return _context.Wine.Find(id);
        }

        public Dictionary<string, int> GetAllWinesStock()
        {
            return _context.Wine.ToDictionary(wine => wine.Name, wine => wine.Stock);
        }

        public void WineStockUpdate(int id, int stock)
        {
            _context.Wine.Single(w => w.Id == id).Stock = stock;
            _context.SaveChanges();
        }
    }
}
