using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button stopButton;
    [SerializeField] private Button homeButton;
    [SerializeField] private TextMeshProUGUI statusText;
    private bool _isPlaying = false;

    private void Awake()
    {
        playButton.onClick.AddListener(() =>
        {
            if (!_isPlaying)
            {
                ((Image)playButton.targetGraphic).sprite = Resources.Load<Sprite>("Sprites/Button/pause");
                AccountSettings.AccountSettings.GetInstance().DisableSettings();
                
                
            }
            else
            {
                ((Image)playButton.targetGraphic).sprite = Resources.Load<Sprite>("Sprites/Button/play");
                AccountSettings.AccountSettings.GetInstance().EnableSettings();
                
                
            } //end-if

            _isPlaying = !_isPlaying;
            print(_isPlaying ? "Play" + " has been pressed" : "Pause" + " has been pressed");

            //Eventual call to machine param=Machine.callPlay/Pause()

            //Eventual change in state statustText.text=param
        });

        stopButton.onClick.AddListener(() =>
        {
            print("Stop has been pressed");
            AccountSettings.AccountSettings.GetInstance().EnableSettings();

            ((Image)playButton.targetGraphic).sprite = Resources.Load<Sprite>("Sprites/Button/play");
            _isPlaying = !_isPlaying;

            //Eventual call to machine param=Machine.callStop()

            //Eventual change in state statustText.text=param
        });

        homeButton.onClick.AddListener(() =>
        {
            print("Home has been pressed");

            //Eventual call to machine param=Machine.callHome()

            //Eventual change in state statustText.text=param
        });
    }
}