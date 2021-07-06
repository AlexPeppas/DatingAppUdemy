using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyDatingApp.EventNotifier
{
    public class MainEventNotifier
    {
        public void MainFunctionality() 
        {
            var publisher = new ExecutePublisher();
            var subscriber = new CleanerSubscriber();

            publisher.WorkflowEventHandler += subscriber.OnWorkflowEventHandler; //contract between publisher and subscriber

            publisher.MainPublisher(new WorkflowEventArgs { name = "WF1" });
        }
    }
}
