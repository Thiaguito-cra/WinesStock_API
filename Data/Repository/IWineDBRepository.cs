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
        public List<Wine> GetWines();
        void AddWine(Wine wine);
        Dictionary<string, int> GetAllWinesStock();
    }
}
