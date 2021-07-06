using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UdemyDatingApp.EventNotifier
{
    public class WorkflowEventArgs
    {
        public string name { get; set; }

        public Guid id { get; set; }

        public string status { get; set; }
    }
    public class ExecutePublisher
    {
        public event EventHandler<WorkflowEventArgs> WorkflowEventHandler;

        public void MainPublisher(WorkflowEventArgs wf)
        {
            Console.WriteLine("finished Workflow, fire Demon");
            OnWorkflowEventHandler(wf);

        }
        protected virtual void OnWorkflowEventHandler(WorkflowEventArgs wf)
        {
            if (WorkflowEventHandler != null)
                WorkflowEventHandler(this,wf);
        }
    }
}
