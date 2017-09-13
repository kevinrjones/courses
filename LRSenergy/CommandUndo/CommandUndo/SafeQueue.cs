using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DM;

namespace CommandUndo
{
    public class SafeQueue
    {
        Queue queue = new Queue();
        CommandUndoInvoker invoker;

        public void Enqueue(object item)
        {
            EnqueueCommand cmd = new EnqueueCommand(queue, item);
            invoker.Execute(cmd);
        }

        public object Dequeue()
        {
            DequeueCommand cmd = new DequeueCommand(queue);
            invoker.Execute(cmd);
            return cmd.Value;
        }

        public int Count { get { return queue.Count;} }

        public void StartTransaction()
        {
            invoker = new CommandUndoInvoker();
        }

        public void Commit()
        {
            invoker = null;
        }

        public void Rollback()
        {
            invoker.Undo();
            invoker = null;
        }
    }
}
