using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CustomToggle{
  /******************************************************/
  // CLASS ToggleSwitchManager IS USED TO MANAGE A SLIDER
  // AS IT WAS A "TOGGLE ON/OFF" WHICH IS NOT NATIVE IN 
  // UNITY
  /******************************************************/
  public sealed class ToggleSwitchManager : MonoBehaviour, IPointerClickHandler{
    /**********************************************************/
    //Serialized Attributes
    /**********************************************************/
    [Header("Slider setup")] [SerializeField] [Range(0, 1f)]
    private float sliderValue;

    [Header("Animation")] [SerializeField] [Range(0, 1f)]
    private float animationDuration=0.5f;

    [SerializeField] private AnimationCurve slideEase=AnimationCurve.EaseInOut(0, 0, 1, 1);
    [Header("Events")] [SerializeField] private UnityEvent onToggleOn;
    [SerializeField] private UnityEvent onToggleOff;

    [SerializeField] private RectTransform rectTransform;

    /**********************************************************/
    //Attributes
    /**********************************************************/
    public bool CurrentValue{get; private set;}
    private bool _previousValue;
    private Slider _slider;
    private Coroutine _animateSliderCoroutine;

    private Action _transitionEffect;

    /**********************************************************/
    //Initializers
    /**********************************************************/
    private void OnValidate(){
      SetupToggleComponents();

      _slider.value=sliderValue;
    }

    private void Awake(){
      SetupSliderComponent();
    }

    /**********************************************************/
    //Methods
    /**********************************************************/
    private void SetupSliderComponent(){
      _slider=GetComponent<Slider>();
      _slider.interactable=true;

      if(_slider == null){
        Debug.Log("No slider found!", this);
        return;
      } //end-if

      var sliderColors=_slider.colors;
      sliderColors.disabledColor=Color.white;
      _slider.colors=sliderColors;
      _slider.transition=Selectable.Transition.None;
    }

    private void SetupToggleComponents(){
      if(_slider != null)
        return;

      SetupSliderComponent();
    }

    public void OnPointerClick(PointerEventData eventData){
      if(_slider.interactable)
        Toggle();
    }

    private void Toggle(){
      SetStateAndStartAnimation(!CurrentValue);
    }

    private void SetStateAndStartAnimation(bool state){
      _previousValue=CurrentValue;
      CurrentValue=state;

      if(_previousValue != CurrentValue){
        if(CurrentValue)
          //Active
          onToggleOn?.Invoke();
        else
          //Passive
          onToggleOff?.Invoke();
        ToggleDefaultMovement(!CurrentValue);
      } //end-if

      if(_animateSliderCoroutine != null)
        StopCoroutine(_animateSliderCoroutine);

      _animateSliderCoroutine=StartCoroutine(AnimateSlider());
    }

    private IEnumerator AnimateSlider(){
      var startValue=_slider.value;
      float endValue=CurrentValue ? 1 : 0;

      float time=0;
      if(animationDuration > 0)
        while(time < animationDuration){
          time+=Time.deltaTime;

          var lerpFactor=slideEase.Evaluate(time / animationDuration);
          _slider.value=sliderValue=Mathf.Lerp(startValue, endValue, lerpFactor);

          _transitionEffect?.Invoke();

          yield return null;
        } //end-while

      _slider.value=endValue;
    }

    private void ToggleDefaultMovement(bool isDisabled){
      var isOn=false;
      for(var i=0; i < rectTransform.childCount; i=i + 1){
        for(var j=0; j < rectTransform.GetChild(i).childCount; j=j + 1){
          try{
            rectTransform.GetChild(i).GetChild(j).GetComponent<Toggle>().interactable=isDisabled;
            isOn=rectTransform.GetChild(i).GetChild(j).GetComponent<Toggle>().isOn;
          }
          catch(NullReferenceException){
            try{
              //If the checkbox is not on, i don't need to change the inputField interactable status
              rectTransform.GetChild(i).GetChild(j).GetComponent<TMP_InputField>().interactable=isOn && isDisabled;
            }
            catch(NullReferenceException){
              //ignoring
            } //end-try
          }   //end-try
        }     //end-for
      }       //end-for
    }
    /**********************************************************/
  }
}