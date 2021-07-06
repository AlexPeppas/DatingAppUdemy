using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace UdemyDatingApp.EventNotifier
{
    public class CleanerSubscriber
    {
        public void OnWorkflowEventHandler(object source,WorkflowEventArgs wf)
        {
            Console.WriteLine("Cleaning the workflow "+wf.name);
            Thread.Sleep(3000);
        }
    }
}
