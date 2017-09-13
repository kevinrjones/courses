using System;

namespace BankTransfer
{
    public abstract class AccountBase : MarshalByRefObject
    {
        public abstract decimal Balance { get; set; }
        public abstract void Credit(decimal amount);
    }
}