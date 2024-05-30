using System;
using CustomToggle;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace GameMode
{
    public class GameModeManager : MonoBehaviour
    {
        [SerializeField] private Toggle[] platformActiveAnglesCheckboxes;
        [SerializeField] private TMP_InputField[] activeAnglesInputs;

        [Header("The order is very important! \n\nThe order MUST be by column not by row!")] [SerializeField]
        private TMP_InputField[] defaultMovementInputs;

        [SerializeField] private Slider slider;

        [SerializeField] private ToggleSwitchManager gameModeToggle;

        private void Awake()
        {
            for (int i = 0; i < platformActiveAnglesCheckboxes.Length; i++)
            {
                int checkboxIndex = i;
                platformActiveAnglesCheckboxes[i].onValueChanged.AddListener((isOn) =>
                {
                    //ToggleSwitch logic is reversed, toggled is false and untoggled is true;
                    bool isActive = !gameModeToggle.CurrentValue;

                    //If checkbox isOn activeAngleInput is interactable depending on gameMode
                    //If checkbox !isOn activeAngleInput is NOT interactable independently whether the gameMode is Active or Passive
                    activeAnglesInputs[checkboxIndex].interactable = isOn && isActive;

                    //If checkbox isOn defaultMovementInput is interactable depending on gameMode
                    //If checkbox !isOn defaultMovementInput is NOT interactable independently whether the gameMode is Active or Passive
                    for (int j = 0; j < 3; j++)
                    {
                        //Starting index of column is calculated as checkboxIndex*3, because the column has a length of 3
                        defaultMovementInputs[checkboxIndex * 3 + j].interactable = isOn && !isActive;
                    } //end-for
                });
            } //end-for

            gameModeToggle.onToggle.AddListener((isActive) =>
            {
                /* isActive can be either:
                 * True: Active mode
                 * False: Passive mode
                 */

                //If checkbox isOn activeAngleInput is interactable depending on gameMode
                //If checkbox !isOn activeAngleInput is NOT interactable independently whether the gameMode is Active or Passive
                for (int i = 0; i < activeAnglesInputs.Length; i++)
                {
                    activeAnglesInputs[i].interactable = platformActiveAnglesCheckboxes[i].isOn && isActive;
                } //end-for                                                                                

                //If checkbox isOn slider is interactable depending on gameMode
                slider.interactable = isActive;

                //If checkbox isOn defaultMovementInput is interactable depending on gameMode
                //If checkbox !isOn defaultMovementInput is NOT interactable independently whether the gameMode is Active or Passive
                for (int i = 0; i < defaultMovementInputs.Length; i++)
                {
                    defaultMovementInputs[i].interactable = platformActiveAnglesCheckboxes[i / 3].isOn && !isActive;
                } //end-for                                                                                
            });
        }
    }
}