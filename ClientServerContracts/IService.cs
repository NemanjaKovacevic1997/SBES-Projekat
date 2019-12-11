using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerContracts
{
    public interface IService
    {
        double CalculateElectricEnergy();
        void ModifyValueOfId(int oldId, int newId);
        void ModifyValueOfElectricEnergy(int id, double newElEnergy);
        void AddNewEntity(int id, string name, double elEnergy);
        void DeleteEntity(int id);
        void DeleteWholeDatabase();
        void ArchiveDatabase();  //?
    }
}
