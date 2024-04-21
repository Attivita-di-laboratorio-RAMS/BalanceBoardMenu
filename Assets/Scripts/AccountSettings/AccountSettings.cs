using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AccountSettings
{
    public class AccountSettings : MonoBehaviour
    {
        [SerializeField] private Slider _gameModeToggle;
        [SerializeField] private List<Toggle> _activeAnglesCheckboxesList;
        [SerializeField] private List<TMP_InputField> _activeAnglesInputFieldsList;
        [SerializeField] private Slider _difficultySlider;
        [SerializeField] private TMP_Dropdown _visualFeedbackDropdown;
        [SerializeField] private List<Toggle> _defaultMovementsCheckboxesList;
        [SerializeField] private List<TMP_InputField> _defaultMovementsAmpInputFieldsList;
        [SerializeField] private List<TMP_InputField> _defaultMovementsFreqInputFieldsList;

        //getters and setters

        public Slider getGameModeToggle()
        {
            return _gameModeToggle;
        }

        public List<Toggle> getActiveAnglesCheckboxesList()
        {
            return _activeAnglesCheckboxesList;
        }

        public List<TMP_InputField> getActiveAnglesInputFieldsList()
        {
            return _activeAnglesInputFieldsList;
        }

        public Slider getDifficultySlider()
        {
            return _difficultySlider;
        }

        public TMP_Dropdown getVisualFeedbackDropdown()
        {
            return _visualFeedbackDropdown;
        }

        public List<Toggle> getDefaultMovementCheckboxesList()
        {
            return _defaultMovementsCheckboxesList;
        }

        public List<TMP_InputField> getDefaultMovementAmpInputFieldsList()
        {
            return _defaultMovementsAmpInputFieldsList;
        }

        public List<TMP_InputField> getDefaultMovementFreqInputFieldsList()
        {
            return _defaultMovementsFreqInputFieldsList;
        }

        public IMemento Save()
        {
            return new ConcreteMemento(this);
        }
    }
}