using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

namespace CalibrationSettings{
  public class LedManager : MonoBehaviour{
    private readonly Color _red=new(253, 94, 86, 255);
    [CanBeNull] private readonly Color _green=new(147, 196, 125, 255);
    [SerializeField] private Image led;

    private void Update(){
      /*
      if (CamerasManager.Instance.Status==(int)CamerasStatus.Offline || CamerasManager.Instance.Status==(int)CamerasStatus.Calibration)
      {
          led.color = _red;
      }
      else
      {
          led.color = _green;
      }
      */
    }
  }
}