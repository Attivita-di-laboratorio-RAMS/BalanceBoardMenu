namespace AccountSettings
{
    public class ConcreteMemento : IMemento
    {
        private AccountSettingsSerializable _accountSettingsSerializable;

        public ConcreteMemento(AccountSettings _accountSettings)
        {
            this._accountSettingsSerializable = new AccountSettingsSerializable(_accountSettings);
        }

        public AccountSettingsSerializable getAccountSettings()
        {
            return _accountSettingsSerializable;
        }
    }
}