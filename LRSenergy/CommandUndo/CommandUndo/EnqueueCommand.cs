using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DM;
using System.Collections;

namespace CommandUndo
{
    public class EnqueueCommand : Command
    {
        Queue queue;
        object value;

        public EnqueueCommand(Queue queue, object value)
        {
            this.queue = queue;
            this.value = value;
        }

        public override void Execute()
        {
            queue.Enqueue(value);
        }

        public override void Undo()
        {
            for (int i = 0; i < queue.Count -1; i++)
            {
                queue.Enqueue(queue.Dequeue());
            }
            queue.Dequeue();
        }
    }
}
