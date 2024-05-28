using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace SliderPercentage{
  /******************************************************/
  // CLASS SliderScript IS USED TO BIND TOGETHER THE 
  // SLIDER AND ITS TEXT
  /******************************************************/
  public class SliderScript : MonoBehaviour{
    /***************************************/
    //SerializedFields
    /***************************************/
    [SerializeField] private Slider slider;

    [SerializeField] private TextMeshProUGUI sliderText;

    /***************************************/
    //Methods
    /***************************************/
    private void Awake(){
      slider.onValueChanged.AddListener((v) => {
        sliderText.text=v.ToString("0");
        sliderText.text=string.Concat(sliderText.text, "%");
      });
    }
    /***************************************/
  }
}