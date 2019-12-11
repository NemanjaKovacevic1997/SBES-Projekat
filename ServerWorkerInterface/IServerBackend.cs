using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace ServerWorkerInterface
{
    [ServiceContract(CallbackContract = typeof(IWorker), SessionMode = SessionMode.Required)]
    public interface IServerBackend
    {
        [OperationContract(IsOneWay = true)]
        void SignIn();
    }
}
