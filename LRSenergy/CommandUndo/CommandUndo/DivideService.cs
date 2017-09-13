using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;
using DM;
using System.Transactions;

namespace CommandUndo
{
    public class DivideService
    {
        private TransactionalQueue requests = new TransactionalQueue();
        private TransactionalQueue responses = new TransactionalQueue();

        public void EnqueueRequest(object n1, object n2)
        {
            using (TransactionScope scope = new TransactionScope())
            {
                requests.Enqueue(n1);
                requests.Enqueue(n2);
                scope.Complete();
            }
        }
        public void ProcessNextRequest()
        {
            using (TransactionScope scope = new TransactionScope())
            {
                int lhs = (int)requests.Dequeue();
                int rhs = (int)requests.Dequeue();
                int result = lhs / rhs;
                responses.Enqueue(String.Format("{0}/{1}={2}", lhs, rhs, result));
                scope.Complete();
            }
        }
        public string GetNextResponse()
        {
            object temp = "";
            using (TransactionScope scope = new TransactionScope())
            {
                temp = responses.Dequeue();
                scope.Complete();
            }
            return temp.ToString();
        }
        public int NumberOfRequestsPending
        {
            get { return requests.Count / 2; }
        }
    }
    public class OldDivideService
    {
        private SafeQueue requests = new SafeQueue();
        private SafeQueue responses = new SafeQueue();

        public void EnqueueRequest(object n1, object n2)
        {
            try
            {
                requests.StartTransaction();
                requests.Enqueue(n1);
                requests.Enqueue(n2);
            }
            catch
            {
                requests.Rollback();
                throw;
            }
            requests.Commit();
        }
        public void ProcessNextRequest()
        {
            try
            {
                requests.StartTransaction();
                responses.StartTransaction();
                int lhs = (int)requests.Dequeue();
                int rhs = (int)requests.Dequeue();
                int result = lhs / rhs;
                responses.Enqueue(String.Format("{0}/{1}={2}", lhs, rhs, result));
            }
            catch
            {
                requests.Rollback();
                responses.Rollback();
                throw;
            }
            requests.Commit();
            responses.Commit();
        }
        public string GetNextResponse()
        {
            object temp = "";
            try
            {
                responses.StartTransaction();
                temp = responses.Dequeue();
            }
            catch
            {
                responses.Rollback();
                throw;
            }
            responses.Commit();
            return temp.ToString();
        }
        public int NumberOfRequestsPending
        {
            get { return requests.Count / 2; }
        }
    }
}
