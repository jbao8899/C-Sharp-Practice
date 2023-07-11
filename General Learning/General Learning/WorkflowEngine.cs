using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace General_Learning
{
    public class WorkflowEngine
    {
        private readonly IList<IActivity> _toDo;

        public WorkflowEngine()
        {
            _toDo = new List<IActivity>();
        }

        public void AddActivity(IActivity activity)
        {
            _toDo.Add(activity);
        }

        public void Run()
        {
            foreach (IActivity activity in _toDo)
            {
                activity.Execute();
            }

            _toDo.Clear();
        }
    }
}
