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
        public readonly IWineDBRepository _wineHardCodedDBRepository;
        public WineServices(IWineDBRepository hardCodedDBRepository)
        {
            _wineHardCodedDBRepository = hardCodedDBRepository;
        }


        public void AddWine(WineDTO createWineDTO)
        {
            if (_wineHardCodedDBRepository.GetWines().All(wine => wine.Name != createWineDTO.Name))
            {
                _wineHardCodedDBRepository.AddWine(
                new Wine
                {
                    Id = _wineHardCodedDBRepository.GetWines().Max(x => x.Id) + 1,
                    Name = createWineDTO.Name,
                    Variety = createWineDTO.Variety,
                    Year = createWineDTO.Year,
                    Region = createWineDTO.Region,
                    Stock = createWineDTO.Stock,
                    CreatedAt = DateTime.UtcNow,
                }
                );
            }
            else throw new InvalidOperationException();
        }

        public Dictionary<string, int> GetAllWinesStock()
        {
            return _wineHardCodedDBRepository.GetAllWinesStock();
        }
    }

}
