using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace AccountSettings
{
    [Serializable]
    public class AccountSettingsSerializable
    {
        public string _gameModeToggle;
        public List<string> _activeAnglesCheckboxesList = new List<string>();
        public List<string> _activeAnglesInputFieldsList = new List<string>();
        public string _difficultySlider;
        public string _visualFeedbackDropdown;
        public List<string> _defaultMovementsCheckboxesList = new List<string>();
        public List<string> _defaultMovementsAmpInputFieldsList = new List<string>();
        public List<string> _defaultMovementsFreqInputFieldsList = new List<string>();

        public AccountSettingsSerializable(AccountSettings _accountSettings)
        {
            this._gameModeToggle = _accountSettings.getGameModeToggle().value.ToString();

            for (int i = 0; i < _accountSettings.getActiveAnglesCheckboxesList().Count; i += 1)
            {
                this._activeAnglesCheckboxesList.Add(
                    _accountSettings.getActiveAnglesCheckboxesList()[i].isOn.ToString());
            }

            for (int i = 0; i < _accountSettings.getActiveAnglesInputFieldsList().Count; i += 1)
            {
                this._activeAnglesInputFieldsList.Add(_accountSettings.getActiveAnglesInputFieldsList()[i].text);
            }

            this._difficultySlider = _accountSettings.getDifficultySlider().value.ToString();

            this._visualFeedbackDropdown = _accountSettings.getVisualFeedbackDropdown().value.ToString();
            
            for (int i = 0; i < _accountSettings.getDefaultMovementCheckboxesList().Count; i += 1)
            {
                _defaultMovementsCheckboxesList.Add(_accountSettings.getDefaultMovementCheckboxesList()[i].isOn.ToString());
                _defaultMovementsCheckboxesList.Add(_accountSettings.getDefaultMovementCheckboxesList()[i].interactable.ToString());
            }//end-for

            for (int i = 0; i < _accountSettings.getDefaultMovementAmpInputFieldsList().Count; i += 1)
            {
                _defaultMovementsAmpInputFieldsList.Add(_accountSettings.getDefaultMovementAmpInputFieldsList()[i].text);
                _defaultMovementsAmpInputFieldsList.Add(_accountSettings.getDefaultMovementAmpInputFieldsList()[i].interactable.ToString());
            }

            for (int i = 0; i < _accountSettings.getDefaultMovementFreqInputFieldsList().Count; i += 1)
            {
                _defaultMovementsFreqInputFieldsList.Add(_accountSettings.getDefaultMovementFreqInputFieldsList()[i].text);
                _defaultMovementsFreqInputFieldsList.Add(_accountSettings.getDefaultMovementFreqInputFieldsList()[i].interactable.ToString());
                
            }
        }

        public void FillAccountSettings(AccountSettings accountSettings)
        {
            accountSettings.getGameModeToggle().value = float.Parse(_gameModeToggle);

            for (int i = 0; i < _activeAnglesCheckboxesList.Count; i += 1)
            {
                accountSettings.getActiveAnglesCheckboxesList()[i].isOn =
                    Convert.ToBoolean(this._activeAnglesCheckboxesList[i]);
            }

            for (int i = 0; i < _activeAnglesInputFieldsList.Count; i += 1)
            {
                accountSettings.getActiveAnglesInputFieldsList()[i].text = this._activeAnglesInputFieldsList[i];
            }

            accountSettings.getDifficultySlider().value = float.Parse(this._difficultySlider);

            accountSettings.getVisualFeedbackDropdown().value = int.Parse(this._visualFeedbackDropdown);
            
            for (int i = 0; i < _defaultMovementsCheckboxesList.Count; i += 2)
            {
                accountSettings.getDefaultMovementCheckboxesList()[i/2].isOn=Convert.ToBoolean(_defaultMovementsCheckboxesList[i]);
                accountSettings.getDefaultMovementCheckboxesList()[i/2].interactable=Convert.ToBoolean(_defaultMovementsCheckboxesList[i+1]);
            }

            for (int i = 0; i < _defaultMovementsAmpInputFieldsList.Count; i += 2)
            {
                accountSettings.getDefaultMovementAmpInputFieldsList()[i/2].text=_defaultMovementsAmpInputFieldsList[i];
                accountSettings.getDefaultMovementAmpInputFieldsList()[i/2].interactable=Convert.ToBoolean(_defaultMovementsAmpInputFieldsList[i+1]);
            }

            for (int i = 0; i < _defaultMovementsFreqInputFieldsList.Count; i += 2)
            {
                accountSettings.getDefaultMovementFreqInputFieldsList()[i/2].text=_defaultMovementsFreqInputFieldsList[i];
                accountSettings.getDefaultMovementFreqInputFieldsList()[i/2].interactable=Convert.ToBoolean(_defaultMovementsFreqInputFieldsList[i+1]);
            }
        }
    }
}