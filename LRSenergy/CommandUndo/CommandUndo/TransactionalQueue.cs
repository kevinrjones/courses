using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DM;
using System.Transactions;

namespace CommandUndo
{
    public class TransactionalQueue : IEnlistmentNotification
    {
        Queue queue = new Queue();
        CommandUndoInvoker invoker;
        Transaction currentTransaction = null;

        public void Enqueue(object item)
        {
            EnsureEnlistedInTransaction();
            EnqueueCommand cmd = new EnqueueCommand(queue, item);
            invoker.Execute(cmd);
        }

        public object Dequeue()
        {
            EnsureEnlistedInTransaction();
            DequeueCommand cmd = new DequeueCommand(queue);
            invoker.Execute(cmd);
            return cmd.Value;
        }

        public int Count { get { return queue.Count;} }

        private void EnsureEnlistedInTransaction()
        {
            if (Transaction.Current == null)
            {
                throw new InvalidOperationException("I must be in a transaction");
            }
            if (currentTransaction == null)
            {
                currentTransaction = Transaction.Current;
                currentTransaction.EnlistVolatile(this, EnlistmentOptions.None);
                invoker = new CommandUndoInvoker();
            }
            if (currentTransaction != Transaction.Current)
            {
                throw new InvalidOperationException("I must always be called on the same transaction");
            }
        }

        #region IEnlistmentNotification Members

        public void Commit(Enlistment enlistment)
        {
            invoker = null;
            currentTransaction = null;
            enlistment.Done();
        }

        public void InDoubt(Enlistment enlistment)
        {
            enlistment.Done();
        }

        public void Prepare(PreparingEnlistment preparingEnlistment)
        {
            preparingEnlistment.Prepared();
        }

        public void Rollback(Enlistment enlistment)
        {
            invoker.Undo();
            invoker = null;
            currentTransaction = null;
            enlistment.Done();
        }

        #endregion
    }
}
