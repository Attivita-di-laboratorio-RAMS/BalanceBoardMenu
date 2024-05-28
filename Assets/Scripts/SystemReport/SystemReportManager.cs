using System;
using System.IO;
using Newtonsoft.Json;
using TMPro;
using UnityEngine;

namespace SystemReport{
  public class SystemReportManager : MonoBehaviour{
    [SerializeField] private TMP_InputField usernameInputField;
    private const string FolderPath=@"Assets/UsernameSystemReport/";
    private const string DefaultDirectory="defaultDirectory/";
    private const string DefaultFilename="default";
    private const string Extension=".json";
    private string _timeStamp;

    private BodyCoordinates _bodyCoordinates;

    private void Awake(){
      _bodyCoordinates=BodyCoordinates.GetInstance();

      _timeStamp=DateTime.Now.ToString("ddMMyyyyHHmmss");

      //Creation of new file for username
      var json=JsonConvert.SerializeObject(_bodyCoordinates, Formatting.None, new JsonSerializerSettings(){
        ReferenceLoopHandling=ReferenceLoopHandling.Ignore
      });

      if(usernameInputField.text == ""){
        if(!Directory.Exists(FolderPath + DefaultDirectory)) Directory.CreateDirectory(FolderPath + DefaultDirectory);

        File.WriteAllText(FolderPath + DefaultDirectory + DefaultFilename + _timeStamp + Extension, json);
      }
      else{
        if(!Directory.Exists(FolderPath + usernameInputField.text + "/")) Directory.CreateDirectory(FolderPath + usernameInputField.text + "/");

        File.WriteAllText(
          FolderPath + usernameInputField.text + "/" + usernameInputField.text + _timeStamp + Extension,
          json);
      }

      Time.captureFramerate=60;
    }

    private void Update(){
      //Serialization of BodyCoordinates in json string and in file
      var json="\n" + JsonConvert.SerializeObject(_bodyCoordinates, Formatting.None,
        new JsonSerializerSettings(){
          ReferenceLoopHandling=ReferenceLoopHandling.Ignore
        });
      if(usernameInputField.text == "")
        File.AppendAllText(FolderPath + DefaultDirectory + DefaultFilename + _timeStamp + Extension, json);
      else
        File.AppendAllText(
          FolderPath + usernameInputField.text + "/" + usernameInputField.text + _timeStamp + Extension,
          json);
    }
  }
}