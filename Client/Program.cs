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
            EndpointAddress endpointAdress = new EndpointAddress(new Uri(address), EndpointIdentity.CreateSpnIdentity("udername@domen"));

            using (ClientProxy proxy = new ClientProxy(binding, endpointAdress))
			{
                //proxy.AddUser("test", "test@123");
			}

			Console.ReadLine();
		}
	}
}
