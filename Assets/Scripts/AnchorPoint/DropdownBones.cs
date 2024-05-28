using System;
using Avatar;
using TMPro;
using UnityEngine;

public class DropdownBones : MonoBehaviour{
  [SerializeField] private TMP_Dropdown dropdown;

  // Start is called before the first frame update
  private void Start(){
    foreach(var bone in(EAvatarBones[])Enum.GetValues(typeof(EAvatarBones))) dropdown.options.Add(new TMP_Dropdown.OptionData(bone.ToString()));
  }
}