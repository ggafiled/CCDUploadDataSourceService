using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Collections.Concurrent;

namespace CCDUploadDataSourceService
{
    class TaskQueue
    {
        private BlockingCollection<object> _jobs = new BlockingCollection<object>();

        public TaskQueue()
        {
            var thread = new Thread(new ThreadStart(OnStart));
        }

        public void Enqueue(object job)
        {
            _jobs.Add(job);
        }

        private void OnStart()
        {
            foreach (var job in _jobs.GetConsumingEnumerable(CancellationToken.None))
            {
                Console.WriteLine(job);
            }
        }
    }
}
