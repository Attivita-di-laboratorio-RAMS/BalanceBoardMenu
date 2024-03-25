using UnityEngine;
using UnityEngine.UI;

public class Recalibrate : MonoBehaviour{
  [SerializeField] private Button _recalibrateButton;
  [SerializeField] private Transform _avatar;
  [SerializeField] private Transform _plane;
  private Quaternion _rotation=new Quaternion(0, 0, 0, 1);

  private void Awake(){
    _recalibrateButton.onClick.AddListener(() => {
      /* Resetting Spacial movement */
      Vector3 tmp=new Vector3(_plane.position.x, _plane.position.y, _plane.position.z);
      _avatar.position=tmp;

      /* Resetting rotational movement */
      _avatar.rotation=_rotation;
    });
  }
}
