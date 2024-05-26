using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AccountSettings
{
    /******************************************************/
    // CLASS AccountSettings IS THE ORIGINATOR AND IS A 
    // SINGLETON
    /******************************************************/
    public class AccountSettings : MonoBehaviour
    {
        /***************************************/
        //SerializedFields
        /***************************************/
        [SerializeField] private Slider gameModeToggle;
        [SerializeField] private List<Toggle> activeAnglesCheckboxesList;
        [SerializeField] private List<TMP_InputField> activeAnglesInputFieldsList;
        [SerializeField] private Slider difficultySlider;
        [SerializeField] private TMP_Dropdown visualFeedbackDropdown;
        [SerializeField] private TMP_Dropdown anchorPointDropdown;
        [SerializeField] private List<Toggle> defaultMovementsCheckboxesList;
        [SerializeField] private List<TMP_InputField> defaultMovementsAmpInputFieldsList;

        [SerializeField] private List<TMP_InputField> defaultMovementsFreqInputFieldsList;

        /***************************************/
        //Attributes
        /***************************************/
        private static AccountSettings _instance = null;

        /***************************************/
        //Getter/Setter
        /***************************************/
        public static AccountSettings GetInstance()
        {
            return _instance;
        }

        public Slider GetGameModeToggle()
        {
            return gameModeToggle;
        }

        public List<Toggle> GetActiveAnglesCheckboxesList()
        {
            return activeAnglesCheckboxesList;
        }

        public List<TMP_InputField> GetActiveAnglesInputFieldsList()
        {
            return activeAnglesInputFieldsList;
        }

        public Slider GetDifficultySlider()
        {
            return difficultySlider;
        }

        public TMP_Dropdown GetVisualFeedbackDropdown()
        {
            return visualFeedbackDropdown;
        }

        public TMP_Dropdown GetAnchorPointDropdown()
        {
            return anchorPointDropdown;
        }

        public List<Toggle> GetDefaultMovementCheckboxesList()
        {
            return defaultMovementsCheckboxesList;
        }

        public List<TMP_InputField> GetDefaultMovementAmpInputFieldsList()
        {
            return defaultMovementsAmpInputFieldsList;
        }

        public List<TMP_InputField> GetDefaultMovementFreqInputFieldsList()
        {
            return defaultMovementsFreqInputFieldsList;
        }

        public IMemento Save()
        {
            return new ConcreteMemento(this);
        }

        /***************************************/
        //Constructor
        /***************************************/
        private AccountSettings()
        {
        }

        /***************************************/
        //Methods
        /***************************************/
        private void Awake()
        {
            _instance = this;
        }

        public void DisableSettings()
        {
            gameModeToggle.interactable = false;
            foreach (var checkbox in activeAnglesCheckboxesList) checkbox.interactable = false; //end-foreach

            foreach (var input in activeAnglesInputFieldsList) input.interactable = false; //end-foreach

            difficultySlider.interactable = false;

            visualFeedbackDropdown.interactable = false;

            anchorPointDropdown.interactable = false;

            foreach (var checkbox in defaultMovementsCheckboxesList) checkbox.interactable = false; //end-foreach

            foreach (var input in defaultMovementsAmpInputFieldsList) input.interactable = false; //end-foreach

            foreach (var input in defaultMovementsFreqInputFieldsList) input.interactable = false; //end-foreach
        }

        public void EnableSettings()
        {
            gameModeToggle.interactable = true;
            foreach (var checkbox in activeAnglesCheckboxesList)
            {
                checkbox.interactable = true; //end-foreach
                checkbox.onValueChanged.Invoke(checkbox.isOn); //end-foreach
            }

            difficultySlider.interactable = true;

            visualFeedbackDropdown.interactable = true;

            anchorPointDropdown.interactable = true;


            if (gameModeToggle.value == 0)
            {
                foreach (var checkbox in defaultMovementsCheckboxesList)
                {
                    checkbox.interactable = true; //end-foreach
                    checkbox.onValueChanged.Invoke(checkbox.isOn); //end-foreach
                }
            }
        }
        /***************************************/
    }
}