using Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Repository
{
    public interface IWineDBRepository
    {
        List<Wine> GetWines();
        Wine? Get(int id);
        void AddWine(Wine wine);
        Dictionary<string, int> GetAllWinesStock();
        void WineStockUpdate(int id, int stock)
    }
}
