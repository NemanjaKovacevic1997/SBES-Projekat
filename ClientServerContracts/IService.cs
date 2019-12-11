using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ClientServerContracts
{
    [ServiceContract]
    public interface IService
    {
        [OperationContract]
        double CalculateElectricEnergy();

        [OperationContract]
        void ModifyValueOfId(int oldId, int newId);

        [OperationContract]
        void ModifyValueOfElectricEnergy(int id, double newElEnergy);

        [OperationContract]
        void AddNewEntity(int id, string name, double elEnergy);

        [OperationContract]
        void DeleteEntity(int id);

        [OperationContract]
        void DeleteWholeDatabase();

        [OperationContract]
        void ArchiveDatabase();  //?
    }
}
