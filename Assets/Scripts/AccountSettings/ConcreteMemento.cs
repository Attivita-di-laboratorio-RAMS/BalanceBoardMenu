namespace AccountSettings
{
    public class ConcreteMemento : IMemento
    {
        private AccountSettings _accountSettings;

        public ConcreteMemento(AccountSettings _accountSettings)
        {
            this._accountSettings = _accountSettings;
        }

        public AccountSettings getAccountSettings()
        {
            return _accountSettings;
        }
    }
}