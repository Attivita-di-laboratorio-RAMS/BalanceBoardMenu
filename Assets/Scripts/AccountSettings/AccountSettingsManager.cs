using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AccountSettings{
  public class AccountSettingsManager : MonoBehaviour{
    [SerializeField] private Button _exitButton;
    [SerializeField] private AccountSettings _accountSettings;
    [SerializeField] private TMP_InputField usernameInputField;
    [SerializeField] private Button searchUsernameButton;

    private AccountSettingsCaretaker _accountSettingsCaretaker;

    private void Awake(){
      _accountSettingsCaretaker=new AccountSettingsCaretaker(_accountSettings);
      
      _exitButton.onClick.AddListener(() => {
        _accountSettingsCaretaker.Backup();

        var json=JsonUtility.ToJson(_accountSettingsCaretaker.GetLastMemento().getAccountSettings(), true);
        File.WriteAllText(@"Assets/UsernameSettings/" + usernameInputField.text + ".json", json);
      });

      searchUsernameButton.onClick.AddListener(() => {
        //Ricerca username nel file system
        var i=0;
        var trovato=false;
        while(!trovato && i < Directory.GetFiles(@"Assets/UsernameSettings/").Length){
          if(usernameInputField.text + ".json" ==
             Path.GetFileName(Directory.GetFiles(@"Assets/UsernameSettings/")[i]))
            trovato=true; //end-if

          i+=1;
        } //end-while

        if(trovato)
          //conversione a gamesettings con settings specifiche
          JsonUtility.FromJson<AccountSettingsSerializable>(
              File.ReadAllText(@"Assets/UsernameSettings/" + usernameInputField.text + ".json"))
            .FillAccountSettings(_accountSettings);
        else
          //conversione a gamesettings con settings di default
          JsonUtility.FromJson<AccountSettingsSerializable>(
              File.ReadAllText(@"Assets/UsernameSettings/default.json"))
            .FillAccountSettings(_accountSettings); //end-if
      });
    }
  }
}