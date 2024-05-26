using System;
using UnityEngine;
using UnityEngine.UI;

namespace CalibrationSettings
{
    public class CalibrationSettingsManager : MonoBehaviour
    {
        [SerializeField] private RawImage[] camerasImagesCalibration;
        [SerializeField] private Button recalibrateButton;

        private void Awake()
        {
            recalibrateButton.onClick.AddListener(() =>
            {
                //CamerasManager.Instance.SendCameraRequest(CamerasStatus.Running);
            });
        }


        // Update is called once per frame
        void Update()
        {
            /*if(CamerasManager.camera0 != null && CamerasManager.camera1 != null && CamerasManager.camera2 != null)
            {
                camerasImagesCalibration[0].texture = CamerasManager.camera0;
                camerasImagesCalibration[1].texture = CamerasManager.camera1;
                camerasImagesCalibration[2].texture = CamerasManager.camera2;
            }*/
        }
    }
}