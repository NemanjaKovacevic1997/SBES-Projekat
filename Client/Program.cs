using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.ServiceModel;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Client
{
	public class Program
	{
		static void Main(string[] args)
		{
			NetTcpBinding binding = new NetTcpBinding();
			string address = "net.tcp://localhost:9999/SecurityService";

            binding.Security.Mode = SecurityMode.Transport;
            binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Windows;
            binding.Security.Transport.ProtectionLevel = System.Net.Security.ProtectionLevel.EncryptAndSign;

            Console.WriteLine("User {0} ", WindowsIdentity.GetCurrent().Name);
            EndpointAddress endpointAdress = new EndpointAddress(new Uri(address));

            using (ClientProxy proxy = new ClientProxy(binding, endpointAdress))
			{
                string input;
                bool done = false;
                while (!done)
                {
                    input = Meni();
                    Console.WriteLine(Environment.NewLine);
                    switch (input[0])
                    {
                        case '1':
                            double ret = proxy.CalculateElectricEnergy();
                            Console.WriteLine("Calculated : " + ret);
                            break;
                        case '2':
                            int oldId, newId;
                            Console.WriteLine("Old ID : ");
                            
                            if(!int.TryParse(Console.ReadLine(), out oldId))
                            {
                                Console.WriteLine("Greska");
                                break;
                            }
                            Console.WriteLine(Environment.NewLine + "New ID : ");
                            if (!int.TryParse(Console.ReadLine(), out newId))
                            {
                                Console.WriteLine("Greska");
                                break;
                            }
                            proxy.ModifyValueOfId(oldId, newId);
                            break;

                        case '3':
                            int id, newElEnergy;
                            Console.WriteLine("ID : ");
                            if (!int.TryParse(Console.ReadLine(), out id))
                            {
                                Console.WriteLine("Greska");
                                break;
                            }
                            Console.WriteLine(Environment.NewLine + "ElectricEnergy :");
                            if (!int.TryParse(Console.ReadLine(), out newElEnergy))
                            {
                                Console.WriteLine("Greska");
                                break;
                            }
                            proxy.ModifyValueOfElectricEnergy(id, newElEnergy);
                            break;
                        case '4':
                            
                            int Id;
                            string name;
                            double elEnergy;
                            Console.WriteLine("ID : ");
                            if (!int.TryParse(Console.ReadLine(), out Id))
                            {
                                Console.WriteLine("Greska");
                                break;
                            }
                            Console.WriteLine("Name : ");
                            name = Console.ReadLine();

                            Console.WriteLine("Electrical energy : ");
                            if (!double.TryParse(Console.ReadLine(), out elEnergy))
                            {
                                Console.WriteLine("Greska");
                                break;
                            }

                            proxy.AddNewEntity(Id, name, elEnergy);

                            break;

                        case '5':
                            Console.WriteLine("ID : ");
                            if (!int.TryParse(Console.ReadLine(), out Id))
                            {
                                Console.WriteLine("Greska");
                                break;
                            }

                            proxy.DeleteEntity(Id);

                            break;
                        case '6':
                            proxy.DeleteWholeDatabase();
                            break;

                        case '7':
                            proxy.ArchiveDatabase();
                            break;
                        
                        default:
                            done = true;
                            break;
                    }
                }
            }

			Console.ReadLine();
		}

        static string Meni()
        {
            Console.WriteLine("Meni : " + Environment.NewLine);
            Console.WriteLine("1. Calculate electric energy" + Environment.NewLine);
            Console.WriteLine("2. Modify ID in database" + Environment.NewLine);
            Console.WriteLine("3. Modify value of electric energy in database" + Environment.NewLine);
            Console.WriteLine("4. Add new entity in database" + Environment.NewLine);
            Console.WriteLine("5. Delete entity from database" + Environment.NewLine);
            Console.WriteLine("6. Delete whole database" + Environment.NewLine);
            Console.WriteLine("7. Archive database" + Environment.NewLine);
            Console.WriteLine("Your choise :");
            string input = Console.ReadLine();

            return input;
        }
	}
}
