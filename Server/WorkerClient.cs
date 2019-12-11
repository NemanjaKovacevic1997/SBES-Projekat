using ServerWorkerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Security;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class WorkerClient : IWorker, IDisposable
    {
        IWorker _workerGateway;
        NetTcpBinding _binding;
        ChannelFactory<IWorker> _factory;
        public WorkerClient(EndpointAddress address) 
        {
            _binding = new NetTcpBinding();
            _binding.Security.Transport.ClientCredentialType = TcpClientCredentialType.Certificate;
            
            _factory = new ChannelFactory<IWorker>(_binding,address);
            _factory.Credentials.ServiceCertificate.Authentication.CertificateValidationMode = X509CertificateValidationMode.ChainTrust;
            _workerGateway = _factory.CreateChannel();
        }

        public void Dispose()
        {
            _factory.Close();
        }
    }
}
