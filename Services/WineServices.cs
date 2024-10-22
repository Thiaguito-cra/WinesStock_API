using Common.Models;
using Data.Entities;
using Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class WineServices : IWineServices
    {
        public readonly IWineDBRepository _wineRepository;
        public WineServices(IWineDBRepository wineRepository)
        {
            _wineRepository = wineRepository;
        }


        public void AddWine(WineDTO createWineDTO)
        {
            if (_wineRepository.GetWines().All(wine => wine.Name != createWineDTO.Name))
            {
                _wineRepository.AddWine(
                new Wine
                {
                    Id = _wineRepository.GetWines().Max(x => x.Id) + 1,
                    Name = createWineDTO.Name,
                    Variety = createWineDTO.Variety,
                    Year = createWineDTO.Year,
                    Region = createWineDTO.Region,
                    Stock = createWineDTO.Stock,
                    CreatedAt = DateTime.UtcNow
                }
            );
            }
        }

        public Dictionary<string, int> GetAllWinesStock()
        {
            return _wineRepository.GetAllWinesStock();
        }

        public void WineStockUpdate(int wineId, int newStock)
        {
            var wine = _wineRepository.Get(wineId);
            if (wine == null)
            {
                throw new KeyNotFoundException("Wine not found.");
            }

            _wineRepository.WineStockUpdate(wineId, newStock);

         
        }
    }
}
