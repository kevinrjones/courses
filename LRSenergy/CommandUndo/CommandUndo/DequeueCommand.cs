using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DM;
using System.Collections;

namespace CommandUndo
{
    public class DequeueCommand : Command
    {
        Queue queue;
        object value;

        public DequeueCommand(Queue queue)
        {
            this.queue = queue;
        }

        public override void Execute()
        {
            value = queue.Dequeue();
        }

        public object Value { get { return value; } }

        public override void Undo()
        {
            queue.Enqueue(value);
            for (int i = 0; i < queue.Count - 1; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }

        }
    }
}
