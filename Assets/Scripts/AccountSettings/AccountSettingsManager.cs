using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AccountSettings{
  /******************************************************/
  // CLASS AccountSettingsManager ACTS AS THE CLIENT.
  // HANDLES ALL THE BUTTONS CLICKING EVENT TRIGGERING
  // EITHER EXIT OR RESEARCH
  /******************************************************/
  public class AccountSettingsManager : MonoBehaviour{
    /***************************************/
    //SerializedFields
    /***************************************/
    [SerializeField] private Button exitButton;
    [SerializeField] private TMP_InputField usernameInputField;

    [SerializeField] private Button searchUsernameButton;

    /***************************************/
    //Attributes
    /***************************************/
    private const string FolderPath=@"Assets/UsernameSettings/";
    private const string DefaultFilename="default";
    private const string Extension=".json";

    private AccountSettingsCaretaker _accountSettingsCaretaker;

    /***************************************/
    //Methods
    /***************************************/
    private void Awake(){
      _accountSettingsCaretaker=new AccountSettingsCaretaker(AccountSettings.GetInstance());

      exitButton.onClick.AddListener(() => {
        _accountSettingsCaretaker.Backup();

        //Serialization of AccountSettings in json string and in file
        var json=JsonUtility.ToJson(_accountSettingsCaretaker.GetLastMemento().GetAccountSettings(), true);
        File.WriteAllText(FolderPath + usernameInputField.text + Extension, json);
      });

      searchUsernameButton.onClick.AddListener(() => {
        /*****************/
        /* TODO: REGEX!! */
        /*****************/

        //Username research in file system
        var i=0;
        var found=false;
        while(!found && i < Directory.GetFiles(FolderPath).Length){
          if(usernameInputField.text + Extension == Path.GetFileName(Directory.GetFiles(FolderPath)[i]))
            found=true; //end-if

          i+=1;
        } //end-while

        if(found)
          //GameSettings with username specific settings
          JsonUtility.FromJson<AccountSettingsSerializable>(File.ReadAllText(FolderPath + usernameInputField.text + Extension)).FillAccountSettings();
        else
          //GameSettings with default settings
          JsonUtility.FromJson<AccountSettingsSerializable>(File.ReadAllText(FolderPath + DefaultFilename + Extension)).FillAccountSettings(); //end-if
      });
    }
    /***************************************/
  }
}