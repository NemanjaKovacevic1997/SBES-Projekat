using ClientServerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

/*
TIPOVI KLIJENATA : 
    -> OBICAN KLIJENT : 
        -> zahtev za obracun potrosnje ele. energije
    -> OPERATOR : 
        -> modifikacija vrednosti utrosenje energije ili ID pametnog brojila u bazi podataka
    -> ADMINISTRATOR :
        -> dodaju novi entitet u bazu podataka
        -> brisanje postojeceg iz baze podataka  (NEMAJU pravo na modifikaciju !)
    -> SUPER-ADMINISTRATORI :
        -> brisu CELU bazu podataka 
        -> arhiviraju bazu podataka ???  (NEMAJU pravo da izvrsavaju operacije kao administratori i operatori !)
    
*/

namespace Client
{
    public class ClientProxy : ChannelFactory<IService>, IService, IDisposable
    {
        IService factory;
        
        public ClientProxy(NetTcpBinding binding, EndpointAddress address) : base(binding, address)
        {
            factory = this.CreateChannel();
        }

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
