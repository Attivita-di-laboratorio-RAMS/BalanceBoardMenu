using System;
using System.Collections.Generic;
using Avatar;
using UnityEngine;

namespace SystemReport{
  /******************************************************/
  // CLASS BodyCoordinates IS A SINGLETON DICTIONARY
  // USED TO KEEP TRACK OF ALL THE MOVEMENT FROM THE 
  // PATIENT
  /******************************************************/
  [Serializable]
  public class BodyCoordinates : Dictionary<EAvatarBones, Vector3>{
    /******************************************************/
    // CLASS KeyValue IS A NESTED CLASS USED AS THE PAIR 
    // OF <KEY, VALUE> TO ENSURE ENCAPSULATION AND 
    // INFORMATION HIDING
    /******************************************************/
    [Serializable]
    public class KeyValue{
      /***************************************/
      //Attributes
      /***************************************/
      public EAvatarBones boneId;
      public Vector3 position;
      /***************************************/
      //Constructor
      /***************************************/
      public KeyValue(EAvatarBones boneId, Vector3 position){
        this.boneId=boneId;
        this.position=position;
      }
      /***************************************/
    }
    /***************************************/
    //Attributes
    /***************************************/
    private static BodyCoordinates _instance=null;
    private readonly Vector3 _defaultCoordinates=new(0, 0, 0);
    /***************************************/
    //Constructor
    /***************************************/
    private BodyCoordinates(){
      foreach(var bone in(EAvatarBones[])Enum.GetValues(typeof(EAvatarBones))) Add(new KeyValue(bone, _defaultCoordinates)); //end-foreach
    }
    /***************************************/
    //Getter/Setter
    /***************************************/
    public static BodyCoordinates GetInstance(){
      if(_instance == null)
        _instance=new BodyCoordinates();

      return _instance;
    }
    /***************************************/
    //Methods
    /***************************************/
    public void UpdateBodyCoordinates(KeyValue keyValue){
      this[keyValue.boneId]=keyValue.position;
    }

    public Vector3 GetBodyCoordinates(EAvatarBones boneId){
      return this[boneId];
    }

    public void Add(KeyValue keyValue){
      Add(keyValue.boneId, keyValue.position);
    }
    /***************************************/
  }
}