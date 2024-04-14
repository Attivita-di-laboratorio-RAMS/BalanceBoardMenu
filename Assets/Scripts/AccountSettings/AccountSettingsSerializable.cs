using System.Runtime.Serialization;

namespace AccountSettings
{
    public class AccountSettingsSerializable : ISerializable
    {
        private string _gameModeToggle;
        private string[] _activeAnglesCheckboxesArray;
        private string[] _activeAnglesInputFieldsArray;
        private string _difficultySlider;
        private string _visualFeedbackDropdown;
        private string[] _defaultMovementsCheckboxesArray;
        private string[] _defaultMovementsAmpInputFieldsArray;
        private string[] _defaultMovementsFreqInputFieldsArray;


        public AccountSettingsSerializable(AccountSettings _accountSettings)
        {
        }


        public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
        }
    }
}