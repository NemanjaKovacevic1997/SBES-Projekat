using ServerWorkerInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Server
{
    class LoadBalancer
    {
        private static readonly Lazy<LoadBalancer>
        lazy =
        new Lazy<LoadBalancer>
            (() => new LoadBalancer());

        NetTcpBinding _binding;

        private List<IWorker> _workers;
        public static LoadBalancer Instance { get { return lazy.Value; } }
        private static object _lockObj;
        private static int _workerCount;
        private static int _currentWorker;
        private LoadBalancer()
        {
            _lockObj = new object();
            _workerCount = 0;
            _currentWorker = 0;
            _workers = new List<IWorker>();
            _binding = new NetTcpBinding();
        }

        public void SignWorkerIn(IWorker workerCallback)
        {
            lock (_lockObj)
            {
                _workers.Add(workerCallback);

            }
        }

        public void GetPrice()
        {
            while (!SelectWorker()) ;
            //uradi

            lock (_lockObj)
            {
                if (_currentWorker >= _workers.Count)
                    _currentWorker = 0;
                else
                    _currentWorker++;
            }
            
        }

        private bool SelectWorker()
        {

            lock (_lockObj)
            {
                if (((ICommunicationObject)_workers[_currentWorker]).State == CommunicationState.Opened)
                {
                    return true;
                }
                else
                {
                    _workers.RemoveAt(_currentWorker);
                    if (_currentWorker >= _workers.Count)
                        _currentWorker = 0;

                    return false;
                }
            }
        }

       
    }
}

