using Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public interface IWineServices
    {
        void AddWine(WineDTO wine);
        Dictionary<string, int> GetAllWinesStock();
    }
}
