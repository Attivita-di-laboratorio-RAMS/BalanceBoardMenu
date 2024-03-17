using System;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Button playButton;
    [SerializeField] private Button stopButton;
    [SerializeField] private Button homeButton;
    private bool isPlaying = false;

    private void Awake()
    {
        playButton.onClick.AddListener((() =>
        {
           
            
            if (!isPlaying)
            {
                ((Image)playButton.targetGraphic).sprite= Resources.Load<Sprite>("Sprites/Button/pause");
                
            }
            else
            {
                ((Image)playButton.targetGraphic).sprite= Resources.Load<Sprite>("Sprites/Button/play");

            }

            isPlaying = !isPlaying;
            print(isPlaying? "Play" + " has been pressed" : "Pause" + " has been pressed");
            
        }));
        
        stopButton.onClick.AddListener((() =>
        {
            print("Stop has been pressed");
        }));
        
        homeButton.onClick.AddListener((() =>
        {
            print("Home has been pressed");
        }));
        
        
    }
}
