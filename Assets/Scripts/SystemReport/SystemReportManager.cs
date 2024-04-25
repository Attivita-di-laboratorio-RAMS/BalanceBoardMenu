using System;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

namespace SystemReport
{
    public class SystemReportManager : MonoBehaviour
    {
        [SerializeField] private TMP_InputField usernameInputField;
        private const string FolderPath = @"Assets/UsernameSystemReport/";
        private const string DefaultFilename = "default";
        private const string Extension = ".json";
        private string _timeStamp;

        private BodyCoordinates _bodyCoordinates;

        private void Awake()
        {
            _bodyCoordinates = new BodyCoordinates();

            _timeStamp = DateTime.Now.ToString("ddMMyyyyHHmmss");

            //Creation of new file for username
            string json = JsonConvert.SerializeObject(_bodyCoordinates);

            if (usernameInputField.text == "")
                File.WriteAllText(FolderPath + DefaultFilename + _timeStamp + Extension, json);
            else
                File.WriteAllText(FolderPath + usernameInputField.text + _timeStamp + Extension, json);

            Time.captureFramerate = 60;
        }

        private void Update()
        {
            _bodyCoordinates.UpdateBodyCoordinates(GetFromCamera());

            //Serialization of BodyCoordinates in json string and in file
            string json = "\n" + JsonConvert.SerializeObject(_bodyCoordinates);
            if (usernameInputField.text == "")
                File.AppendAllText(FolderPath + DefaultFilename + _timeStamp + Extension, json);
            else
                File.AppendAllText(FolderPath + usernameInputField.text + _timeStamp + Extension, json);
        }

        private BodyCoordinates.KeyValue GetFromCamera()
        {
            return new BodyCoordinates.KeyValue(0, new float[] { 0, 0, 0 });
        }
    }
}