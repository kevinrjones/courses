namespace BankTransfer
{
    public class SynchronisedAccount : AccountBase
    {
        private readonly AccountBase _account;

        public SynchronisedAccount(AccountBase account)
        {
            _account = account;
        }

        public override decimal Balance
        {
            get { return _account.Balance; }
            set
            {
                lock (_account)
                {
                    _account.Balance = value;
                }
            }
        }

        public override void Credit(decimal amount)
        {
            lock (_account)
            {
                _account.Credit(amount);
            }
        }
    }
}