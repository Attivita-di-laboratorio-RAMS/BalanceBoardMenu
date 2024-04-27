using System;
using System.Collections.Generic;
using System.Globalization;

namespace AccountSettings{
  /******************************************************/
  // CLASS AccountSettingsSerializable IS A DUMMY CLASS
  // USED ONLY TO SERIALIZE AccountSettings (ORIGINATOR)
  /******************************************************/
  [Serializable]
  public class AccountSettingsSerializable{
    /******************************************************/
    // CLASS CustomString IS A NESTED DUMMY CLASS
    // USED ONLY TO SERIALIZE FIELD WITH MULTIPLE STRINGS
    /******************************************************/
    [Serializable]
    public class CustomString{
      /***************************************/
      //Attributes
      /***************************************/
      public string s1;
      public string s2;
      /***************************************/
      //Constructor
      /***************************************/
      public CustomString(string s1, string s2){
        this.s1=s1;
        this.s2=s2;
      }
      /***************************************/
    }
    /***************************************/
    //Attributes
    /***************************************/
    public string gameModeToggle;
    public List<string> activeAnglesCheckboxesList=new();
    public List<string> activeAnglesInputFieldsList=new();
    public string difficultySlider;
    public string visualFeedbackDropdown;
    public List<CustomString> defaultMovementsCheckboxesList=new();
    public List<CustomString> defaultMovementsAmpInputFieldsList=new();
    public List<CustomString> defaultMovementsFreqInputFieldsList=new();
    /***************************************/
    //Constructor
    /***************************************/
    public AccountSettingsSerializable(AccountSettings accountSettings){
      gameModeToggle=accountSettings.GetGameModeToggle().value.ToString(CultureInfo.InvariantCulture);

      for(var i=0; i < accountSettings.GetActiveAnglesCheckboxesList().Count; i+=1)
        activeAnglesCheckboxesList.Add(accountSettings.GetActiveAnglesCheckboxesList()[i].isOn.ToString());

      for(var i=0; i < accountSettings.GetActiveAnglesInputFieldsList().Count; i+=1) activeAnglesInputFieldsList.Add(accountSettings.GetActiveAnglesInputFieldsList()[i].text);

      difficultySlider=accountSettings.GetDifficultySlider().value.ToString(CultureInfo.InvariantCulture);

      visualFeedbackDropdown=accountSettings.GetVisualFeedbackDropdown().value.ToString();

      for(var i=0; i < accountSettings.GetDefaultMovementCheckboxesList().Count; i+=1){
        defaultMovementsCheckboxesList.Add(new CustomString(accountSettings.GetDefaultMovementCheckboxesList()[i].isOn.ToString(), accountSettings.GetDefaultMovementCheckboxesList()[i].interactable.ToString()));
      }//end-for

      for(var i=0; i < accountSettings.GetDefaultMovementAmpInputFieldsList().Count; i+=1){
        defaultMovementsAmpInputFieldsList.Add(new CustomString(accountSettings.GetDefaultMovementAmpInputFieldsList()[i].text, accountSettings.GetDefaultMovementAmpInputFieldsList()[i].interactable.ToString()));
      }//end-for

      for(var i=0; i < accountSettings.GetDefaultMovementFreqInputFieldsList().Count; i+=1){
        defaultMovementsFreqInputFieldsList.Add(new CustomString(accountSettings.GetDefaultMovementFreqInputFieldsList()[i].text, accountSettings.GetDefaultMovementFreqInputFieldsList()[i].interactable.ToString()));
      }//end-for
    }
    /***************************************/
    //Methods
    /***************************************/
    public void FillAccountSettings()
    {
      var accountSettings = AccountSettings.GetInstance();
      
      accountSettings.GetGameModeToggle().value=float.Parse(gameModeToggle);

      for(var i=0; i < activeAnglesCheckboxesList.Count; i+=1)
        accountSettings.GetActiveAnglesCheckboxesList()[i].isOn=Convert.ToBoolean(activeAnglesCheckboxesList[i]);

      for(var i=0; i < activeAnglesInputFieldsList.Count; i+=1) accountSettings.GetActiveAnglesInputFieldsList()[i].text=activeAnglesInputFieldsList[i];

      accountSettings.GetDifficultySlider().value=float.Parse(difficultySlider);

      accountSettings.GetVisualFeedbackDropdown().value=int.Parse(visualFeedbackDropdown);

      for(var i=0; i < defaultMovementsCheckboxesList.Count; i+=1){
        accountSettings.GetDefaultMovementCheckboxesList()[i].isOn=Convert.ToBoolean(defaultMovementsCheckboxesList[i].s1);
        accountSettings.GetDefaultMovementCheckboxesList()[i].interactable=Convert.ToBoolean(defaultMovementsCheckboxesList[i].s2);
      } //end-for

      for(var i=0; i < defaultMovementsAmpInputFieldsList.Count; i+=1){
        accountSettings.GetDefaultMovementAmpInputFieldsList()[i].text=defaultMovementsAmpInputFieldsList[i].s1;
        accountSettings.GetDefaultMovementAmpInputFieldsList()[i].interactable=Convert.ToBoolean(defaultMovementsAmpInputFieldsList[i].s2);
      } //end-for

      for(var i=0; i < defaultMovementsFreqInputFieldsList.Count; i+=1){
        accountSettings.GetDefaultMovementFreqInputFieldsList()[i].text=defaultMovementsFreqInputFieldsList[i].s1;
        accountSettings.GetDefaultMovementFreqInputFieldsList()[i].interactable=Convert.ToBoolean(defaultMovementsFreqInputFieldsList[i].s2);
      } //end-for
    }
    /***************************************/
  }
}