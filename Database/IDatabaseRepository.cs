using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Database
{
    interface IDatabaseRepository
    {
        void Add(UserMeter newUserMeter);
        //void Modify(int oldId, UserMeter newUserMeter);
        void ModifyId(int oldId, int newId);
        void ModifyValueOfElectricEnergy(int oldId, double newValue);
        void Delete(int id);
    }
}
