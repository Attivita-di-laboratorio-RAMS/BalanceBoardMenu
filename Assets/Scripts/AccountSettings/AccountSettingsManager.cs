using Newtonsoft.Json;
using UnityEngine;
using UnityEngine.UI;

namespace AccountSettings
{
    public class AccountSettingsManager : MonoBehaviour
    {
        [SerializeField] private Button _exitButton;
        [SerializeField] private AccountSettings _accountSettings;
        private AccountSettingsCaretaker _accountSettingsCaretaker;

        private void Awake()
        {
            _accountSettingsCaretaker = new AccountSettingsCaretaker(_accountSettings);
            _exitButton.onClick.AddListener(() =>
            {
                _accountSettingsCaretaker.Backup();
                print(_accountSettingsCaretaker.GetLastMemento().getAccountSettings().ToString());
                string json = JsonConvert.SerializeObject(
                    _accountSettingsCaretaker.GetLastMemento().getAccountSettings(), Formatting.Indented,
                    new JsonSerializerSettings
                    {
                        ReferenceLoopHandling = ReferenceLoopHandling.Ignore
                    });
                print(json);
            });
        }
    }
}