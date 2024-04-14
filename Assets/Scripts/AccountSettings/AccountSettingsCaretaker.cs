using System.Collections.Generic;
using System.Linq;

namespace AccountSettings
{
    public class AccountSettingsCaretaker
    {
        private List<IMemento> _mementos = new List<IMemento>();

        private AccountSettings _accountSettings = null;

        public AccountSettingsCaretaker(AccountSettings accountSettings)
        {
            this._accountSettings = accountSettings;
        }

        public void Backup()
        {
            this._mementos.Add(this._accountSettings.Save());
        }

        public IMemento GetLastMemento()
        {
            return this._mementos.Last();
        }
    }
}