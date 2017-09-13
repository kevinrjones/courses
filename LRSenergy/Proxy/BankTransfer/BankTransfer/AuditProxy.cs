using System;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Threading;

namespace BankTransfer
{
    public class AuditProxy <T> : RealProxy where T : MarshalByRefObject
    {
        private readonly T _real;

        public AuditProxy(T real) : base(typeof(T))
        {
            _real = real;
        }

        public override IMessage Invoke(IMessage msg)
        {
            IMethodCallMessage methodCall = (IMethodCallMessage)msg;

            Console.WriteLine("{0} on object {2} has invoked {1}",
                         Thread.CurrentPrincipal.Identity.Name,
                         methodCall.MethodName,
                         _real);

            // Invoke the message against the realInstance    
            return RemotingServices.ExecuteMessage(_real,
                  (IMethodCallMessage)msg);

        }
    }
}