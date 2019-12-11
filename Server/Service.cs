using ClientServerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Service : IService
    {
        public void AddNewEntity(int id, string name, double elEnergy)
        {
            throw new NotImplementedException();
        }

        public void ArchiveDatabase()
        {
            throw new NotImplementedException();
        }

        public double CalculateElectricEnergy()
        {
            throw new NotImplementedException();
        }

        public void DeleteEntity(int id)
        {
            throw new NotImplementedException();
        }

        public void DeleteWholeDatabase()
        {
            throw new NotImplementedException();
        }

        public void ModifyValueOfElectricEnergy(int id, double newElEnergy)
        {
            throw new NotImplementedException();
        }

        public void ModifyValueOfId(int oldId, int newId)
        {
            throw new NotImplementedException();
        }
    }
}
