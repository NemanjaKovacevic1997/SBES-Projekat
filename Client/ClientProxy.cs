using ClientServerContracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using System.ServiceModel;
using System.ServiceModel.Security;
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
            
            try
            {
                factory.AddNewEntity(id,name,elEnergy);
            }
            catch(SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch(SecurityAccessDeniedException e)
            {
                Console.WriteLine(e.Message);
            }
            
        }

        public void ArchiveDatabase()
        {
            try
            {
                factory.ArchiveDatabase();
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public double CalculateElectricEnergy()
        {
            double ret;
            try
            {
                ret = factory.CalculateElectricEnergy();
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
                ret = -1;
            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine(e.Message);
                ret = -1;
            }

            return ret;
        }

        public void DeleteEntity(int id)
        {
            try
            {
                factory.DeleteEntity(id);
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void DeleteWholeDatabase()
        {
            try
            {
                factory.DeleteWholeDatabase();
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ModifyValueOfElectricEnergy(int id, double newElEnergy)
        {
            try
            {
                factory.ModifyValueOfElectricEnergy(id, newElEnergy);
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void ModifyValueOfId(int oldId, int newId)
        {
            try
            {
                factory.ModifyValueOfId(oldId, newId);
            }
            catch (SecurityException e)
            {
                Console.WriteLine(e.Message);
            }
            catch (SecurityAccessDeniedException e)
            {
                Console.WriteLine(e.Message);
            }
        }

        public void Dispose()
        {
            if (factory != null)
            {
                factory = null;
            }

            this.Close();
        }
    }
}
