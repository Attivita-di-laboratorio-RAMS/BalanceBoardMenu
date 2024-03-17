using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour{
  [SerializeField] private Button playButton;
  [SerializeField] private Button stopButton;
  [SerializeField] private Button homeButton;
  [SerializeField] private TextMeshProUGUI statusText;
  private bool isPlaying=false;

  private void Awake(){
    playButton.onClick.AddListener(() => {
      if(!isPlaying)
        ((Image)playButton.targetGraphic).sprite=Resources.Load<Sprite>("Sprites/Button/pause");
      else
        ((Image)playButton.targetGraphic).sprite=Resources.Load<Sprite>("Sprites/Button/play");

      isPlaying=!isPlaying;
      print(isPlaying ? "Play" + " has been pressed" : "Pause" + " has been pressed");
      
      //Eventual call to machine param=Machine.callPlay/Pause()
      
      //Eventual change in state statustText.text=param
    });

    stopButton.onClick.AddListener(() => {
      print("Stop has been pressed");
      
      //Eventual call to machine param=Machine.callStop()
      
      //Eventual change in state statustText.text=param
    });

    homeButton.onClick.AddListener(() => {
      print("Home has been pressed");
      
      //Eventual call to machine param=Machine.callHome()
      
      //Eventual change in state statustText.text=param
    });
  }
}