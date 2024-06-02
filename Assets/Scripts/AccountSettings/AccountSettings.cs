using System;
using System.Collections.Generic;
using System.Linq;
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

        [SerializeField] private List<TMP_InputField> defaultMovementsAmpInputFieldsList;

        [SerializeField] private List<TMP_InputField> defaultMovementsFreqInputFieldsList;

        [SerializeField] private List<TMP_InputField> defaultMovementsOffsetInputFieldsList;

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

        public List<TMP_InputField> GetDefaultMovementAmpInputFieldsList()
        {
            return defaultMovementsAmpInputFieldsList;
        }

        public List<TMP_InputField> GetDefaultMovementFreqInputFieldsList()
        {
            return defaultMovementsFreqInputFieldsList;
        }

        public List<TMP_InputField> GetDefaultMovementOffsetInputFieldsList()
        {
            return defaultMovementsOffsetInputFieldsList;
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

        public void OnEnable()
        {
            for (int i = 0; i < activeAnglesInputFieldsList.Count - 1; i += 1)
            {
                int currentInputIndex = i;
                activeAnglesInputFieldsList[i].onValueChanged.AddListener((input =>
                {
                    try
                    {
                        if (Int32.Parse(input) > 5)
                        {
                            activeAnglesInputFieldsList[currentInputIndex].text = "5";
                        }
                        else if (Int32.Parse(input) < 0)
                        {
                            activeAnglesInputFieldsList[currentInputIndex].text = "0";
                        }
                    }
                    catch (FormatException e)
                    {
                        activeAnglesInputFieldsList[currentInputIndex].text = input;
                    }
                }));

                activeAnglesInputFieldsList.Last().onValueChanged.AddListener((input =>
                {
                    try
                    {
                        if (Int32.Parse(input) > 50)
                        {
                            activeAnglesInputFieldsList.Last().text = "50";
                        }
                        else if (Int32.Parse(input) < 0)
                        {
                            activeAnglesInputFieldsList.Last().text = "0";
                        }
                    }
                    catch (FormatException e)
                    {
                        activeAnglesInputFieldsList.Last().text = input;
                    }
                }));
            }


            foreach (var amp in defaultMovementsAmpInputFieldsList)
            {
                amp.onValueChanged.AddListener(input =>
                {
                    CheckInput((defaultMovementsAmpInputFieldsList.Concat(defaultMovementsFreqInputFieldsList)
                        .ToList()).Concat(defaultMovementsOffsetInputFieldsList).ToList());
                });
            }

            foreach (var freq in defaultMovementsFreqInputFieldsList)
            {
                freq.onValueChanged.AddListener(input =>
                {
                    CheckInput((defaultMovementsAmpInputFieldsList.Concat(defaultMovementsFreqInputFieldsList)
                        .ToList()).Concat(defaultMovementsOffsetInputFieldsList).ToList());
                });
            }

            foreach (var offset in defaultMovementsOffsetInputFieldsList)
            {
                offset.onValueChanged.AddListener(input =>
                {
                    CheckInput((defaultMovementsAmpInputFieldsList.Concat(defaultMovementsFreqInputFieldsList)
                        .ToList()).Concat(defaultMovementsOffsetInputFieldsList).ToList());
                });
            }
        }

        public void DisableSettings()
        {
            gameModeToggle.interactable = false;
            foreach (var checkbox in activeAnglesCheckboxesList) checkbox.interactable = false; //end-foreach

            foreach (var input in activeAnglesInputFieldsList) input.interactable = false; //end-foreach

            difficultySlider.interactable = false;

            visualFeedbackDropdown.interactable = false;

            anchorPointDropdown.interactable = false;

            foreach (var input in defaultMovementsAmpInputFieldsList) input.interactable = false; //end-foreach

            foreach (var input in defaultMovementsFreqInputFieldsList) input.interactable = false; //end-foreach

            foreach (var input in defaultMovementsOffsetInputFieldsList) input.interactable = false; //end-foreach
        }

        public void EnableSettings()
        {
            gameModeToggle.interactable = true;
            foreach (var checkbox in activeAnglesCheckboxesList)
            {
                checkbox.interactable = true; //end-foreach
                checkbox.onValueChanged.Invoke(checkbox.isOn); //end-foreach
            }

            if (gameModeToggle.value == 0)
                difficultySlider.interactable = true;

            visualFeedbackDropdown.interactable = true;

            anchorPointDropdown.interactable = true;

            if (gameModeToggle.value == 0)
                foreach (var checkbox in activeAnglesCheckboxesList)
                {
                    checkbox.interactable = true; //end-foreach
                    checkbox.onValueChanged.Invoke(checkbox.isOn); //end-foreach
                }
        }


        private void CheckInput(List<TMP_InputField> inputFields)
        {
            foreach (var input in inputFields)
            {
                /**/
            }
        }
        /***************************************/
    }
}