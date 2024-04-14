using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace AccountSettings
{
    public class AccountSettings : MonoBehaviour
    {
        [SerializeField] private Slider _gameModeToggle { get; set; }
        [SerializeField] private Toggle[] _activeAnglesCheckboxesArray { get; set; }
        [SerializeField] private TMP_InputField[] _activeAnglesInputFieldsArray { get; set; }
        [SerializeField] private Slider _difficultySlider { get; set; }
        [SerializeField] private TMP_Dropdown _visualFeedbackDropdown { get; set; }
        [SerializeField] private Toggle[] _defaultMovementsCheckboxesArray { get; set; }
        [SerializeField] private TMP_InputField[] _defaultMovementsAmpInputFieldsArray { get; set; }
        [SerializeField] private TMP_InputField[] _defaultMovementsFreqInputFieldsArray { get; set; }

        //getters and setters
        public IMemento Save()
        {
            return new ConcreteMemento(this);
        }
    }
}