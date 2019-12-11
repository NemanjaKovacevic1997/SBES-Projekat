using ServerWorkerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession, ConcurrencyMode = ConcurrencyMode.Single)]
    class ServerBackend : IServerBackend
    {
        public void SignIn()
        {
            LoadBalancer.Instance.SignWorkerIn(OperationContext.Current.GetCallbackChannel<IWorker>());
        }
    }
}
