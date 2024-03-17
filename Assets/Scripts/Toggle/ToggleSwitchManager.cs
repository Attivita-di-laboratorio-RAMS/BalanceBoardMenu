using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ToggleSwitchManager : MonoBehaviour, IPointerClickHandler
{
    /**********************************************************/
    //Serialized Attributes
    /**********************************************************/
    [Header("Slider setup")] [SerializeField, Range(0, 1f)] protected float sliderValue;
    [Header("Animation")] [SerializeField, Range(0, 1f)] private float animationDuration = 0.5f;
    [SerializeField] private AnimationCurve slideEase = AnimationCurve.EaseInOut(0, 0, 1, 1);
    [Header("Events")] [SerializeField] private UnityEvent onToggleOn;
    [SerializeField] private UnityEvent onToggleOff;
    [SerializeField] private RectTransform _rectTransform;
    /**********************************************************/
    //Attributes
    /**********************************************************/
    public bool CurrentValue { get; private set; }
    private bool _previousValue;
    private Slider _slider;
    private Coroutine _animateSliderCoroutine;
    protected Action TransitionEffect;
    /**********************************************************/
    //Initializers
    /**********************************************************/
    protected virtual void OnValidate()
    {
        SetupToggleComponents();

        _slider.value = sliderValue;
    }
    protected virtual void Awake()
    {
        SetupSliderComponent();
    }
    /**********************************************************/
    //Methods
    /**********************************************************/
    private void SetupSliderComponent()
    {
        _slider = GetComponent<Slider>();

        if (_slider == null)
        {
            Debug.Log("No slider found!", this);
            return;
        }

        _slider.interactable = false;
        var sliderColors = _slider.colors;
        sliderColors.disabledColor = Color.white;
        _slider.colors = sliderColors;
        _slider.transition = Selectable.Transition.None;
    }
    private void SetupToggleComponents()
    {
        if (_slider != null)
            return;

        SetupSliderComponent();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        Toggle();
    }


    private void Toggle()
    {
        SetStateAndStartAnimation(!CurrentValue);
    }


    private void SetStateAndStartAnimation(bool state)
    {
        _previousValue = CurrentValue;
        CurrentValue = state;

        if (_previousValue != CurrentValue)
        {
            if (CurrentValue){
                //Active
                onToggleOn?.Invoke();
            }else {
                //Passive
                onToggleOff?.Invoke();
            }
            ToggleDefaultMovement(!CurrentValue);
        }

        if (_animateSliderCoroutine != null)
            StopCoroutine(_animateSliderCoroutine);

        _animateSliderCoroutine = StartCoroutine(AnimateSlider());
    }


    private IEnumerator AnimateSlider()
    {
        float startValue = _slider.value;
        float endValue = CurrentValue ? 1 : 0;

        float time = 0;
        if (animationDuration > 0)
        {
            while (time < animationDuration)
            {
                time += Time.deltaTime;

                float lerpFactor = slideEase.Evaluate(time / animationDuration);
                _slider.value = sliderValue = Mathf.Lerp(startValue, endValue, lerpFactor);

                TransitionEffect?.Invoke();

                yield return null;
            }
        }

        _slider.value = endValue;
    }
    
    private void ToggleDefaultMovement(bool isDisabled){
        for (int i=0; i<_rectTransform.childCount; i=i+1)
        {   
            for (int j=0; j<_rectTransform.GetChild(i).childCount; j=j+1)
            {
                try
                {
                    _rectTransform.GetChild(i).GetChild(j).GetComponent<Toggle>().interactable = isDisabled;
                }
                catch (NullReferenceException)
                {  
                    _rectTransform.GetChild(i).GetChild(j).GetComponent<TMP_InputField>().interactable = isDisabled;
                }
            }//end-for
        }//end-for
    }
    /**********************************************************/
}