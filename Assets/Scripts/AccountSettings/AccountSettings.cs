using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AccountSettings{
  /******************************************************/
  // CLASS AccountSettings IS THE ORIGINATOR
  /******************************************************/
  public class AccountSettings : MonoBehaviour{
    /***************************************/
    //SerializedFields
    /***************************************/
    [SerializeField] private Slider gameModeToggle;
    [SerializeField] private List<Toggle> activeAnglesCheckboxesList;
    [SerializeField] private List<TMP_InputField> activeAnglesInputFieldsList;
    [SerializeField] private Slider difficultySlider;
    [SerializeField] private TMP_Dropdown visualFeedbackDropdown;
    [SerializeField] private List<Toggle> defaultMovementsCheckboxesList;
    [SerializeField] private List<TMP_InputField> defaultMovementsAmpInputFieldsList;
    [SerializeField] private List<TMP_InputField> defaultMovementsFreqInputFieldsList;
    /***************************************/
    //Getter/Setter
    /***************************************/
    public Slider GetGameModeToggle(){
      return gameModeToggle;
    }

    public List<Toggle> GetActiveAnglesCheckboxesList(){
      return activeAnglesCheckboxesList;
    }

    public List<TMP_InputField> GetActiveAnglesInputFieldsList(){
      return activeAnglesInputFieldsList;
    }

    public Slider GetDifficultySlider(){
      return difficultySlider;
    }

    public TMP_Dropdown GetVisualFeedbackDropdown(){
      return visualFeedbackDropdown;
    }

    public List<Toggle> GetDefaultMovementCheckboxesList(){
      return defaultMovementsCheckboxesList;
    }

    public List<TMP_InputField> GetDefaultMovementAmpInputFieldsList(){
      return defaultMovementsAmpInputFieldsList;
    }

    public List<TMP_InputField> GetDefaultMovementFreqInputFieldsList(){
      return defaultMovementsFreqInputFieldsList;
    }

    public IMemento Save(){
      return new ConcreteMemento(this);
    }
    /***************************************/
  }
}