using ClientServerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class Service : IService
    {
        [PrincipalPermission(SecurityAction.Demand, Role = "AddEntity")]
        public void AddNewEntity(int id, string name, double elEnergy)
        {
            Console.WriteLine("AddNewEntity");
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "MacroDBOperation")]
        public void ArchiveDatabase()
        {
            Console.WriteLine("ArchiveDatabase");
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "CalculateEnergy")]
        public double CalculateElectricEnergy()
        {
            Console.WriteLine("CalculateElectricEnergy");
            return -1;
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "DeleteEntity")]
        public void DeleteEntity(int id)
        {
            Console.WriteLine("DeleteEntity");
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "MacroDBOperation")]
        public void DeleteWholeDatabase()
        {
            Console.WriteLine("DeleteWholeDatabase");
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public void ModifyValueOfElectricEnergy(int id, double newElEnergy)
        {
            Console.WriteLine("ModifyValueOfElectricEnergy");
        }

        [PrincipalPermission(SecurityAction.Demand, Role = "Modify")]
        public void ModifyValueOfId(int oldId, int newId)
        {
            Console.WriteLine("ModifyValueOfId");
        }
    }
}
